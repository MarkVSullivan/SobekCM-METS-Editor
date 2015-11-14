#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_File_ReaderWriters;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public delegate void New_Importer_Progress_Delegate(int New_Progress);

    public enum Matching_Record_Choice_Enum
    {
        Undefined = -1,
        Overlay_Bib_Record = 1,
        Create_New_Record,
        Skip
    }

    public abstract class baseImporter_Processor : iImporter_Process
    {
        public static string Default_Institution_Code;
        public static string Default_Institution_Statement;

        protected List<string> default_projects;
        protected string default_material_type;

        public event New_Importer_Progress_Delegate New_Progress;
        public event New_Importer_Progress_Delegate Complete;

        protected Importer_Report report;
        protected List<string> errors;
        protected List<string> warnings;
        protected string item_import_comments;

        protected Constant_Fields constantCollection;

        protected int recordsSavedToDB;
        protected int recordsProcessed;
        protected int recordsSkipped;
        protected int errorCnt;
        protected int preview_counter;

        protected DataTable allInstitutions;

        protected Dictionary<string, string> Provided_Bib_To_New_Bib;
        protected Dictionary<string, int> BibID_To_Last_VID;
        protected Dictionary<string, int> Provided_Bib_To_New_Receiving;
        protected List<string> New_Bib_IDs;

        protected Matching_Record_Choice_Enum matching_record_dialog_form_always_use_value = Matching_Record_Choice_Enum.Undefined;
        protected bool allow_overlay;

        protected baseImporter_Processor(Constant_Fields constantCollection)
        {
            // Create the objects to keep track of errors and items processed
            report = new Importer_Report();
            errors = new List<string>();
            warnings = new List<string>();

            // Save the parameters
            this.constantCollection = constantCollection;

            // Set some constants;
            recordsSavedToDB = 0;
            recordsProcessed = 0;
            recordsSkipped = 0;
            errorCnt = 0;
            preview_counter = 1;
            allow_overlay = false;

            // Load the data tables needed
            //     TrackingDB.CS_TrackingDatabase.Refresh_Bib_Table();
          //  allInstitutions = SobekCM.Library.Database.SobekCM_Database.Get_Codes_Item_Aggregations(true, null);

            // Declare the lists which will hold the new bib id and receiving id information
            Provided_Bib_To_New_Bib = new Dictionary<string, string>();
            Provided_Bib_To_New_Receiving = new Dictionary<string, int>();
            BibID_To_Last_VID = new Dictionary<string, int>();
            New_Bib_IDs = new List<string>();

            // Set some defaults
            default_projects = new List<string>();
            default_material_type = String.Empty;
        }

        /// <summary>Gets the formatted messages for errors that prevent saving</summary>
        public string Error_Message
        {
            get
            {
                if (errors.Count > 0)
                {
                    StringBuilder errors_builder = new StringBuilder();
                    foreach (string thisError in errors)
                    {
                        errors_builder.Append( " " + thisError);
                    }
                    return errors_builder.ToString().Trim();
                }

                return String.Empty;
            }
        }

        /// <summary>Gets the formatted messages for warningd that do not prevent saving</summary>
        public string Tracking_Warnings
        {
            get
            {
                if (warnings.Count > 0)
                {
                    StringBuilder warnings_builder = new StringBuilder();
                    foreach (string thisError in warnings)
                    {
                        warnings_builder.Append(" " + thisError);
                    }
                    return warnings_builder.ToString().Trim();
                }

                return String.Empty;
            }
        }

        public DataTable Report_Data
        {
            get { return report.Data; }
        }

        public abstract Importer_Type_Enum Importer_Type { get; }

        protected void OnNewProgress(int Progress)
        {
            if (New_Progress != null)
                New_Progress(Progress);
        }

        protected void OnComplete(int Progress)
        {
            if (Complete != null)
                Complete(Progress);
        }


        protected void Copy_User_Settings_To_Package(SobekCM_Item bibPackage)
        {
            // Add constant data from each mapped column into the bib package
            constantCollection.Add_To_Package(bibPackage);

            // If there is no source included, add it 
            if (bibPackage.Bib_Info.Source.Code.Length == 0)
                bibPackage.Bib_Info.Source.Code = MetaTemplate_UserSettings.Default_Source_Code;
            if (bibPackage.Bib_Info.Source.Statement.Length == 0)
                bibPackage.Bib_Info.Source.Statement = MetaTemplate_UserSettings.Default_Source_Statement;
        }

        /// <summary> Gets a flag indicating if the provided string appears to be in bib id format </summary>
        /// <param name="test_string"> string to check for bib id format </param>
        /// <returns> TRUE if this string appears to be in bib id format, otherwise FALSE </returns>
        protected bool is_bibid_format(string test_string)
        {
            // Must be 10 characters long to start with
            if (test_string.Length != 10)
                return false;

            // Use regular expressions to check format
            Regex myReg = new Regex("[A-Z]{2}[A-Z|0-9]{4}[0-9]{4}");
            return myReg.IsMatch(test_string.ToUpper());
        }


        protected bool save_to_mets(SobekCM_Item bibPackage, string destination_folder )
        {
            bibPackage.METS_Header.RecordStatus_Enum = METS_Record_Status.COMPLETE;

            // Saves the data members in the SobekCM.Resource_Object to a METS file
            try
            {

                // Set some values
                bibPackage.METS_Header.Creator_Organization = bibPackage.Bib_Info.Source.Code + "," + bibPackage.Bib_Info.Source.Statement;
                if (MetaTemplate_UserSettings.AddOns_Enabled.Contains("FCLA"))
                {
                    PALMM_Info palmmInfo = bibPackage.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                    if (palmmInfo == null)
                    {
                        palmmInfo = new PALMM_Info();
                        bibPackage.Add_Metadata_Module( GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
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
                            bibPackage.METS_Header.Replace_Creator_Org_Notes(creator_org_to_remove, "projects=" + palmmInfo.PALMM_Project);
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

                return true;
            }
            catch (Exception e)
            {
                ErrorMessageBox.Show("Error encountered while creating METS file!\n\n" + e.Message, "METS Editor Batch Import Error", e);
                return false;
            }
        }

    }
}
