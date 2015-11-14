#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    /// <summary> Processor object steps through the MARC file, and does all the necessary work. <br /> <br /> </summary>
    /// <remarks> This runs in a seperate thread than the main form class. <br /> <br /> </remarks>
    public class SpreadSheet_Importer_Processor : baseImporter_Processor
    {
        private DataTable inputDataTbl;
        private List<Mapped_Fields> mapping;
        private DataRow currentRow;
        private bool stopThread;

        private string marc_folder;
        private string error_folder;

        private string destination_folder;
        private string bibid_start;
        private int next_bibid_counter;

        private string matching_message = "Found a row in the spreadsheet ( {0} ) \nthat matches an existing Bib record ( {1} ).          \n\nSelect an option below on how to process this matching row.";

        /// <summary> Constructor for a new instance of this class </summary>
        /// <param name="InputDataTable">Table from the Excel spreadsheet being processed</param>
        /// <param name="Mapping">Arraylist of 'enum Mapped_Fields' members.</param>
        public SpreadSheet_Importer_Processor(DataTable InputDataTable, List<Mapped_Fields> Mapping, Constant_Fields constantCollection, string Destination_Folder, string BibID_Start, int First_BibID)
            : base(constantCollection )
        {
            // Save the parameters
            inputDataTbl = InputDataTable;
            mapping = Mapping;
            destination_folder = Destination_Folder;
            bibid_start = BibID_Start;
            next_bibid_counter = First_BibID;

            // Set the error and marc subfolders
            marc_folder = destination_folder + "\\MARC";
            error_folder = destination_folder + "\\Error";
        }

        public List<Mapped_Fields> Mapping
        {
            get { return mapping; }
            set { mapping = value; }
        }

        public bool StopThread
        {
            get { return stopThread; }
            set { stopThread = value; }
        }

        /// <summary> Do the bulk of the work of stepping through the input file and
        /// copying the data from the Bib Package to the Tracking Database and creating METS files.</summary>
        public void Do_Work()
        {
            string username = WindowsIdentity.GetCurrent().Name;

            try
            {

                // check for empty rows in the input table
                foreach (DataRow row in inputDataTbl.Rows)
                {
                    // Save this row in case there is an exception caught
                    currentRow = row;

                    // Load the data and constant into a SobekCM_Item object
                    SobekCM_Item newItem = Load_Data_From_DataRow_And_Constants(row);

                    // If that was successful, continnue
                    if (newItem != null)
                    {
                        // If there is a series, bib title but no bib id, use that title as the bib id as well
                        if ((newItem.Behaviors.GroupTitle.Length > 0) && (newItem.BibID.Length == 0))
                            newItem.BibID = newItem.Behaviors.GroupTitle;

                        // Save the original bib id
                        string original_bibid = newItem.BibID;

                        // Make sure there is a title
                        if (newItem.Bib_Info.Main_Title.ToString().Trim().Length == 0)
                            newItem.Bib_Info.Main_Title.Title = "Missing Title";

                        // Save the METS
                        newItem.METS_Header.Creator_Software = "SobekCM METS Editor";
                        if (MetaTemplate_UserSettings.Individual_Creator.Length > 0)
                            newItem.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;
                        else
                            newItem.METS_Header.Creator_Individual = username;
                        newItem.METS_Header.Add_Creator_Individual_Notes("Imported from spreadsheet");
                        newItem.METS_Header.Creator_Software = "SobekCM METS Editor";

                        // Only keep BibID if it is bib id format
                        if (!is_bibid_format(newItem.BibID))
                        {
                            if (base.Provided_Bib_To_New_Bib.ContainsKey(original_bibid))
                                newItem.BibID = base.Provided_Bib_To_New_Bib[original_bibid];
                            else
                            {
                                // Set the next BIBID
                                string next_bibid = next_bibid_counter.ToString();
                                next_bibid_counter++;
                                newItem.BibID = (bibid_start + next_bibid.PadLeft(10 - bibid_start.Length, '0')).ToUpper();

                                // Save for later lookup
                                base.Provided_Bib_To_New_Bib[original_bibid] = newItem.BibID;
                            }
                        }

                        // Set the VID if there is none
                        if (newItem.VID.Length == 0)
                        {
                            if (base.BibID_To_Last_VID.ContainsKey(newItem.BibID))
                            {
                                int next_vid = (BibID_To_Last_VID[newItem.BibID] + 1);
                                BibID_To_Last_VID[newItem.BibID] = next_vid;
                                newItem.VID = next_vid.ToString().PadLeft(5, '0');
                            }
                            else
                            {
                                BibID_To_Last_VID[newItem.BibID] = 1;
                                newItem.VID = "00001";
                            }
                        }
                                                 

                        // Save the METS
                        save_to_mets(newItem, destination_folder);

                        // Add this to the result table being built
                        report.Add_Item(newItem, String.Empty);

                        // Also set the BibID/VID on the spreadsheet
                        if (inputDataTbl.Columns.Contains("New BIB ID"))
                            row["New Bib ID"] = newItem.BibID;
                        if (inputDataTbl.Columns.Contains("New VID"))
                            row["New VID"] = newItem.VID;

                        recordsProcessed++;
                    }

                    // check stopThread flag to see if processing should contine                  
                    if (stopThread)
                    {
                        // write message to indicate where processing stopped
                        row["Messages"] += " Processing stopped by user.  This is the last row processed.";
                        item_import_comments += " Processing stopped by user.  This is the last row processed.";

                        // Add this to the result table being built
                        report.Add_Item(newItem, item_import_comments.Trim());
                        return;
                    }

                    // Fire the event that one item is complete
                    OnNewProgress(base.recordsProcessed);

                    errors.Clear();

                    // check stopThread flag to see if processing should contine                  
                    if (stopThread)
                    {
                        break;
                    }
                } // end of processing loop 


                if (stopThread)
                {

                    // Fire the event that the entire work has been stopped
                    OnComplete(999999);

                }
                else
                {

                    // display messagebox that import is complete
                        MessageBox.Show("records processed:\t\t[ " + recordsProcessed.ToString("#,##0;") + " ]" +
                "\n\n records skipped:\t\t[ " + recordsSkipped.ToString("#,##0;") + " ]" +
                "\n\n records with errors:\t\t[ " + errorCnt.ToString("#,##0;") + " ]", "Batch METS File Creation Complete!");
                    
                    // Fire the event that the entire work is complete
                    OnComplete(999999);
                }


            }
            catch (ThreadAbortException)
            {
                // A ThreadAbortException has been invoked on the
                // Processor thread.  This exception will be caught here
                // in addition to being caught in the delegate method
                // 'processor_Volume_Processed', where processing of this 
                // exception will take place.                
            }
            catch (Exception e)
            {
                // display the error message
                ErrorMessageBox.Show("Error encountered while processing!\n\n" + e.Message, "DLC Importer Error", e);
                try
                {
                    // write message to indicate where processing stopped
                    currentRow["Messages"] = "Processing stopped by application.  Error Message: " + e.Message + "\n\nThis is the last row processed.";
                    item_import_comments = "Processing stopped by application.  Error Message: " + e.Message + "\n\nThis is the last row processed.";

                    // Add this to the result table being built
                    report.Add_Item(null, item_import_comments.Trim());

                    // set the flag to stop the Processor thread
                    stopThread = true;

                    // Fire the event that the entire work has been stopped
                    OnComplete(999999);
                }
                catch { }
            }
        }

        private SobekCM_Item Load_Data_From_DataRow_And_Constants(DataRow currentRow)
        {
            // Check to see if this is a completely empty row
            bool empty_row = true;
            for (int i = 0; i < currentRow.ItemArray.Length; i++)
            {
                if (currentRow[i].ToString().Trim().Length > 0)
                {
                    empty_row = false;
                    break;
                }
            }

            // If this is empty, skip it
            if (empty_row)
            {
                return null;
            }

            // Create the bibliographic package
            SobekCM_Item bibPackage = new SobekCM_Item();

            // reset the static variables in the mappings class
            Bibliographic_Mapping.clear_static_variables();

            // Step through each column in the data row and add the data into the bib package
            for (int i = 0; (i < inputDataTbl.Columns.Count) && (i < mapping.Count); i++)
            {
                if (currentRow[i].ToString().Length > 0)
                {
                    Bibliographic_Mapping.Add_Data(bibPackage, currentRow[i].ToString(), mapping[i]);
                }
            }

            // Copy all user settings to this package
            base.Copy_User_Settings_To_Package(bibPackage);

            // Return the built object
            return bibPackage;
        }

        private bool isLocationValid(string location)
        {
            DataRow[] instRows = allInstitutions.Select("itemcode = '" + location.Replace("'", "''") + "'");

            if (instRows.Length > 0)
                return true;
            else
                return false;
        }

        public override Importer_Type_Enum Importer_Type
        {
            get { return Importer_Type_Enum.Spreadsheet; }
        }
    }
}