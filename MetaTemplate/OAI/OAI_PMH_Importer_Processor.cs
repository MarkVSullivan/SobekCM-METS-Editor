#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using SobekCM.METS_Editor.BatchImport;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_File_ReaderWriters;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.OAI;

#endregion

namespace SobekCM.METS_Editor.OAI
{
  /// <summary> Enumeration used to return any errors to the processing form or process </summary>
  public enum OAI_PMH_Importer_Error_Enum : byte
  {
    /// <summary>No error encountered during processing </summary>
    NO_ERROR,

    /// <summary> Was either unable to pull the feed data, or the feed data is empty </summary>
    Unable_to_pull_feed_data,

    /// <summary> Unable to read existing mappings file or unable to read that directory </summary>
    Unable_to_read_existing_mappings_file,

    /// <summary> Unable to save the new mappings file </summary>
    Unable_to_save_mappings_file,

    /// <summary> Unknown error encountered during processing </summary>
    Unknown_error_while_processing_feed
  }

  /// <summary> Class used in a background thread to read the OAI-PMH feed from a repository 
  /// and create metadata files for each record within the feed </summary>
  public class OAI_PMH_Importer_Processor
  {
    /// <summary> Delegate for an event which passes out the new progress for this processor </summary>
    /// <param name="New_Progress"> Current progress </param>
    /// <param name="Max_Progress"> Complete number of records currently being processed </param>
    public delegate void OAI_Progress_Delegate(int New_Progress, int Max_Progress );

    /// <summary> Delegate for an event which passes out the completeness of this process </summary>
    /// <param name="Total_Processed"> Total number successfully processed </param>
    /// <param name="Error_Encountered"> Error encountered during processing </param>
    public delegate void OAI_Progress_Complete(int Total_Processed, OAI_PMH_Importer_Error_Enum Error_Encountered);

    /// <summary> Event fired when a new progress has been completed, for updating any forms </summary>
    public event OAI_Progress_Delegate New_Progress;

    /// <summary> Event fired when process is complete </summary>
    public event OAI_Progress_Complete Complete;


    private Constant_Fields constantCollection;
    private string destination_folder;
    private OAI_Repository_Information repository;
    private string set_to_import;
    private string bibid_start;
    private int next_bibid_counter;
    private string mapping_directory;
    
    /// <summary> Constructor for a new instance of the OAI_PMH_Importer_Processor </summary>
    /// <param name="Constant_Collection"> Collection of constant fields and values to be applied to the resulting metadata file</param>
    /// <param name="Destination_Folder"> Destination folder where all metadata should be written </param>
    /// <param name="Repository"> Information about the OAI-PMH repository </param>
    /// <param name="Set_To_Import"> Name of the set of records to import </param>
    /// <param name="BibID_Start"> First portion of the resulting BibID's (i.e., 'UF', 'TEST', etc.. )</param>
    /// <param name="First_BibID"> First numeric value for the resulting BibIDs</param>
    /// <param name="Mappings_Directory"> Directory where the resulting mappings file should be written</param>
    /// <remarks> Each new metadata file will have a BibID which is ten digits long and composed of the BibID_Start and then the next numeric value </remarks>
    public OAI_PMH_Importer_Processor(Constant_Fields Constant_Collection, string Destination_Folder, OAI_Repository_Information Repository, string Set_To_Import, string BibID_Start, int First_BibID, string Mappings_Directory )
    {
      constantCollection = Constant_Collection;
      destination_folder = Destination_Folder;
      repository = Repository;
      set_to_import = Set_To_Import;
      mapping_directory = Mappings_Directory;

      bibid_start = BibID_Start;
      next_bibid_counter = First_BibID;
    }

    /// <summary> Perform the requested work </summary>
    public void Do_Work()
    {
      // Get the current user name
      string username = WindowsIdentity.GetCurrent().Name;
      int recordsProcessed = 0;

      // Look for a mappings file for this repository
      Dictionary<string, string> oai_objectid_mapping = new Dictionary<string, string>();
      string mappings_file = mapping_directory + "\\" + repository.Repository_Identifier + ".xml";
      try
      {
        if (String.IsNullOrEmpty(repository.Repository_Identifier))
          mappings_file = mapping_directory + "\\" + repository.Name + ".xml";
        if ((mapping_directory.Length > 0) && (Directory.Exists(mapping_directory)) && (File.Exists(mappings_file)))
        {
          DataSet mappingSet = new DataSet();
          mappingSet.ReadXml(mappings_file);
          foreach (DataRow thisRow in mappingSet.Tables[0].Rows)
          {
            oai_objectid_mapping[thisRow[0].ToString()] = thisRow[1].ToString();
          }
        }
      }
      catch ( Exception ee )
      {
        Debug.WriteLine(ee.Message);
        OnComplete(0, OAI_PMH_Importer_Error_Enum.Unable_to_read_existing_mappings_file);
      }

      // Get the first set of records
      OAI_Repository_Records_List records = OAI_Repository_Stream_Reader.List_Records(repository.Harvested_URL, set_to_import, "oai_dc");
      if ((records == null) || (records.Count == 0))
      {
        OnComplete(0, OAI_PMH_Importer_Error_Enum.Unable_to_pull_feed_data);
        return;
      }

      // Flag used to keep the user request if a previous mapping is found that matches a record
      Nullable<bool> use_previous_mappings = null;
      try
      {
        // Continue through each pull using the resumption token
        while ((records != null) && (records.Count > 0))
        {
          // Step through these records
          int total_count = records.Count;
          for (int i = 0; i < total_count; i++)
          {
            // Get this record out
            OAI_Repository_DublinCore_Record record = records[i];

            // Create the bib package
            SobekCM_Item bibPackage = new SobekCM_Item(record);

            // Add some more information about the repository here
            bibPackage.Bib_Info.Add_Identifier(record.OAI_Identifier, "oai");
            bibPackage.Bib_Info.Record.Main_Record_Identifier.Type = "oai";
            bibPackage.Bib_Info.Record.Main_Record_Identifier.Identifier = record.OAI_Identifier;
            bibPackage.Bib_Info.Location.Other_URL_Note = repository.Name;
            bibPackage.Bib_Info.Location.Other_URL_Display_Label = "External Link";
            bibPackage.Bib_Info.Source.Statement = repository.Name;

            // Add constant data from each mapped column into the bib package
            constantCollection.Add_To_Package(bibPackage);

            // Make sure there is a title
            if (bibPackage.Bib_Info.Main_Title.ToString().Trim().Length == 0)
              bibPackage.Bib_Info.Main_Title.Title = "Missing Title";

            // Set some defaults
            bibPackage.Source_Directory = destination_folder;
            if (MetaTemplate_UserSettings.Individual_Creator.Length > 0)
              bibPackage.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;
            else
              bibPackage.METS_Header.Creator_Individual = username;
            bibPackage.METS_Header.Add_Creator_Individual_Notes("Imported via OAI from " + repository.Name);
            bibPackage.VID = "00001";
            bibPackage.METS_Header.Creator_Software = "SobekCM METS Editor";

            // See if this already exists in the mapping
            if (( !use_previous_mappings.HasValue ) && ( oai_objectid_mapping.ContainsKey(record.OAI_Identifier)))
            {
              DialogResult result = MessageBox.Show("Record from OAI set appears in previous mapping file.   \n\nShould the previous mappings be used?   \n\nIf you select 'YES' the ObjectID will be the same as the previous harvest.\n\nIf you select 'NO' a new ObjectID will be assigned from your range.     ", "Previous Mapping Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (result == DialogResult.Yes)
                use_previous_mappings = true;
              if (result == DialogResult.No)
                use_previous_mappings = false;
            }

            // Assign a BibId
            if ((use_previous_mappings.HasValue) && (use_previous_mappings.Value) && (oai_objectid_mapping.ContainsKey(record.OAI_Identifier)))
            {
              // Use the existing BibId from the previous mapping
              bibPackage.BibID = oai_objectid_mapping[record.OAI_Identifier];
            }
            else
            {
              // Determine the next BibID to be assigned
              string next_bibid = next_bibid_counter.ToString();
              next_bibid_counter++;
              bibPackage.BibID = (bibid_start + next_bibid.PadLeft(10 - bibid_start.Length, '0')).ToUpper();

              // Save this mapping to the dictionary
              oai_objectid_mapping[record.OAI_Identifier] = bibPackage.BibID;
            }

            // Set some values
            bibPackage.METS_Header.Creator_Organization = bibPackage.Bib_Info.Source.Code + "," + bibPackage.Bib_Info.Source.Statement;
              if (MetaTemplate_UserSettings.AddOns_Enabled.Contains("FCLA"))
              {
                  PALMM_Info palmmInfo =
                      bibPackage.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                  if (palmmInfo == null)
                  {
                      palmmInfo = new PALMM_Info();
                      bibPackage.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
                  }

                  if ((palmmInfo.toPALMM) && (palmmInfo.PALMM_Project.Length > 0))
                  {
                      string creator_org_to_remove = String.Empty;
                      foreach (string thisString in bibPackage.METS_Header.Creator_Org_Notes)
                      {
                          if (thisString.IndexOf("projects=") >= 0)
                          {
                              creator_org_to_remove = thisString;
                              break;
                          }
                      }
                      if (creator_org_to_remove.Length > 0)
                          bibPackage.METS_Header.Replace_Creator_Org_Notes(creator_org_to_remove,
                                                                           "projects=" + palmmInfo.PALMM_Project);
                      else
                          bibPackage.METS_Header.Add_Creator_Org_Notes("projects=" + palmmInfo.PALMM_Project);
                  }
              }

              // Determine the filename
            string mets_file = destination_folder + "\\" + bibPackage.BibID + "_" + bibPackage.VID + MetaTemplate_UserSettings.METS_File_Extension;

            // Save the actual file
            METS_File_ReaderWriter metsWriter = new METS_File_ReaderWriter();
            string writing_error = String.Empty;
            metsWriter.Write_Metadata(mets_file, bibPackage, null, out writing_error);

            // Increment progress
            recordsProcessed++;
            OnNewProgress(recordsProcessed, total_count);
          }

          // If there was a resumption token, pull the next set of records from the repository
          if (String.IsNullOrEmpty(records.Resumption_Token))
            records = null;
          else
            records = OAI_Repository_Stream_Reader.List_Records(repository.Harvested_URL, records.Resumption_Token);

        }
      }
      catch (Exception ee)
      {
        Debug.WriteLine(ee.Message);
        OnComplete(recordsProcessed, OAI_PMH_Importer_Error_Enum.Unknown_error_while_processing_feed);
      }

      // Now, save this mapping
      if (mapping_directory.Length > 0)
      {
        try
        {
          // Ensure the directory exists
          if (!Directory.Exists(mapping_directory))
            Directory.CreateDirectory(mapping_directory);

          // Create the dataset/table with the new mappings (includes old if one was found)
          DataSet mappingSet2 = new DataSet("SobekCM_METS_Editor_OAI_Mapping");
          DataTable mappingTable = new DataTable("OAI_ObjectID_Map");
          mappingSet2.Tables.Add(mappingTable);
          mappingTable.Columns.Add("OAI_Identifier");
          mappingTable.Columns.Add("SobekCM_ObjectID");

          // Copy over the data into the new datatable
          foreach (string thisKey in oai_objectid_mapping.Keys)
          {
            DataRow newRow = mappingTable.NewRow();
            newRow[0] = thisKey;
            newRow[1] = oai_objectid_mapping[thisKey];
            mappingTable.Rows.Add(newRow);
          }

          // Write the mappings as the dataset in XML format
          mappingSet2.WriteXml(mappings_file, XmlWriteMode.WriteSchema);
        }
        catch ( Exception ee )
        {
          Debug.WriteLine(ee.Message);
          OnComplete(recordsProcessed, OAI_PMH_Importer_Error_Enum.Unable_to_save_mappings_file);
        }
      }

      // Process complete!
      OnComplete(recordsProcessed, OAI_PMH_Importer_Error_Enum.NO_ERROR);
    }

    private void OnNewProgress(int Progress, int Maximum)
    {
      if (New_Progress != null)
        New_Progress(Progress, Maximum);
    }

    private void OnComplete(int Progress, OAI_PMH_Importer_Error_Enum Error_Encountered)
    {
      if (Complete != null)
        Complete(Progress, Error_Encountered );
    }
  }
}
