#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Bib_Info;
using SobekCM.Resource_Object.Builder;
using SobekCM.Resource_Object.Metadata_File_ReaderWriters;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public class Batch_Directory_Processor
    {
        public delegate void Directory_Batch_Progress_Delegate(int New_Progress, int Max_Progress);
        public delegate void Directory_Batch_Task_Delegate(string New_Task);

        private string filter;
        private string directory;
        private string metadata_type;
        private string bibid_start;
        private int next_bibid_counter;

        public event Directory_Batch_Progress_Delegate New_Progress;
        public event Directory_Batch_Task_Delegate New_Folder;
        public event Directory_Batch_Progress_Delegate Complete;

        public Batch_Directory_Processor(string Filter, string Directory, string Metadata_Type, string BibID_Start, int First_BibID)
        {
            filter = Filter;
            directory = Directory;
            metadata_type = Metadata_Type.ToUpper();
            bibid_start = BibID_Start;
            next_bibid_counter = First_BibID;
        }

        public void Do_Work()
        {
            string username = WindowsIdentity.GetCurrent().Name;
            List<string> directories_to_process = new List<string>();

            try
            {
                recurse_through_directories(directory, directories_to_process);
            }
            catch
            {

            }

            // Now, iterate through all the directories
            int current_directory = 1;
            int errors_encountered = 0;
            foreach (string thisDirectory in directories_to_process)
            {
                try
                {
                    DirectoryInfo thisDirectoryInfo = new DirectoryInfo(thisDirectory);

                    string folder_name_for_progress = thisDirectoryInfo.Name;
                    if (folder_name_for_progress.Length <= 5)
                        folder_name_for_progress = (thisDirectoryInfo.Parent.Name) + "\\" + folder_name_for_progress;
                    OnNewFolder(folder_name_for_progress + " ( " + current_directory + " of " + directories_to_process.Count + " )");

                    // Get the metadata file
                    string[] metadata = Directory.GetFiles(thisDirectory, filter);
                    if (metadata.Length > 0)
                    {
                        SobekCM_Item newItem = null;
                        if (metadata_type.IndexOf("METS") >= 0)
                        {
                            newItem = SobekCM_Item.Read_METS(metadata[0]);
                        }
                        else
                        {
                            newItem = new SobekCM_Item();
                            newItem.Source_Directory = thisDirectory;

                            newItem = new SobekCM_Item();
                            List<string> addOns = MetaTemplate_UserSettings.AddOns_Enabled;

                            // Set the initial agents
                            if (MetaTemplate_UserSettings.Individual_Creator.Length > 0)
                                newItem.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;
                            else
                                newItem.METS_Header.Creator_Individual = username;
                            newItem.METS_Header.Creator_Software = "SobekCM METS Editor";

                            // Add FCLA add-on defaults
                            if (addOns.Contains("FCLA"))
                            {
                                PALMM_Info palmmInfo = newItem.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                                if (palmmInfo == null)
                                {
                                    palmmInfo = new PALMM_Info();
                                    newItem.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
                                }
                                palmmInfo.PALMM_Project = MetaTemplate_UserSettings.PALMM_Code;
                                palmmInfo.toPALMM = MetaTemplate_UserSettings.FCLA_Flag_PALMM;


                                DAITSS_Info daitssInfo = newItem.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                                if (daitssInfo == null)
                                {
                                    daitssInfo = new DAITSS_Info();
                                    newItem.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
                                }
                                daitssInfo.toArchive = MetaTemplate_UserSettings.FCLA_Flag_FDA;
                                daitssInfo.Account = MetaTemplate_UserSettings.FDA_Account;
                                daitssInfo.SubAccount = MetaTemplate_UserSettings.FDA_SubAccount;
                                daitssInfo.Project = MetaTemplate_UserSettings.FDA_Project;
                            }

                            // Add SobekCM add-on defaults
                            if (addOns.Contains("SOBEKCM"))
                            {
                                // Add any wordmarks
                                List<string> wordmarks = MetaTemplate_UserSettings.SobekCM_Wordmarks;
                                foreach (string thisWordmark in wordmarks)
                                    newItem.Behaviors.Add_Wordmark(thisWordmark);

                                // Add any aggregations
                                List<string> aggregations = MetaTemplate_UserSettings.SobekCM_Aggregations;
                                foreach (string thisAggregation in aggregations)
                                    newItem.Behaviors.Add_Aggregation(thisAggregation);

                                // Add any web skins
                                List<string> webskins = MetaTemplate_UserSettings.SobekCM_Web_Skins;
                                foreach (string thisWebSkin in webskins)
                                    newItem.Behaviors.Add_Web_Skin(thisWebSkin);

                                // Add any viewers
                                List<string> viewers = MetaTemplate_UserSettings.SobekCM_Viewers;
                                foreach (string thisViewer in viewers)
                                {
                                    if (String.Compare(thisViewer, "Page Image (JPEG)") == 0)
                                        newItem.Behaviors.Add_View(View_Enum.JPEG);
                                    if (String.Compare(thisViewer, "Zoomable (JPEG2000)") == 0)
                                        newItem.Behaviors.Add_View(View_Enum.JPEG2000);
                                    if (String.Compare(thisViewer, "Page Turner") == 0)
                                        newItem.Behaviors.Add_View(View_Enum.PAGE_TURNER);
                                    if (String.Compare(thisViewer, "Text") == 0)
                                        newItem.Behaviors.Add_View(View_Enum.TEXT);
                                    if (String.Compare(thisViewer, "Thumbnails") == 0)
                                        newItem.Behaviors.Add_View(View_Enum.RELATED_IMAGES);
                                }
                            }

                            // Add all other defaults
                            newItem.Bib_Info.Source.Code = MetaTemplate_UserSettings.Default_Source_Code;
                            newItem.Bib_Info.Source.Statement = MetaTemplate_UserSettings.Default_Source_Statement;
                            if (MetaTemplate_UserSettings.Default_Funding_Note.Length > 0)
                                newItem.Bib_Info.Add_Note(MetaTemplate_UserSettings.Default_Funding_Note, Note_Type_Enum.funding);
                            if (MetaTemplate_UserSettings.Default_Rights_Statement.Length > 0)
                                newItem.Bib_Info.Access_Condition.Text = MetaTemplate_UserSettings.Default_Rights_Statement;

                            // Set some final values
                            newItem.Bib_Info.Type.MODS_Type = TypeOfResource_MODS_Enum.Text;

                            // Assign an ObjectID
                            switch (next_bibid_counter)
                            {
                                case -1:
                                    newItem.METS_Header.ObjectID = thisDirectoryInfo.Name;
                                    if ((newItem.METS_Header.ObjectID.Length == 16) && (newItem.METS_Header.ObjectID[10] == '_'))
                                    {
                                        newItem.VID = newItem.BibID.Substring(11);
                                        newItem.BibID = newItem.BibID.Substring(0, 10).ToUpper();
                                    }
                                    break;

                                case -2:
                                    newItem.METS_Header.ObjectID = (new FileInfo(metadata[0])).Name;
                                    if ((newItem.METS_Header.ObjectID.Length == 16) && (newItem.METS_Header.ObjectID[10] == '_'))
                                    {
                                        newItem.VID = newItem.BibID.Substring(11);
                                        newItem.BibID = newItem.BibID.Substring(0, 10).ToUpper();
                                    }
                                    break;

                                default:
                                    string next_bibid = next_bibid_counter.ToString();
                                    next_bibid_counter++;
                                    newItem.BibID = (bibid_start + next_bibid.PadLeft(10 - bibid_start.Length, '0')).ToUpper();
                                    newItem.VID = "00001";
                                    break;
                            }

                            string errors = String.Empty;
                            if (metadata_type.IndexOf("DUBLIN CORE") >= 0)
                            {
                                // Open a stream to read the indicated import file
                                Stream reader = new FileStream(metadata[0], FileMode.Open, FileAccess.Read);
                                DC_File_ReaderWriter dcreader = new DC_File_ReaderWriter();
                                dcreader.Read_Metadata(reader, newItem, null, out errors );
                            }

                            if (metadata_type.IndexOf("MODS") >= 0)
                            {
                                // Open a stream to read the indicated import file
                                Stream reader = new FileStream(metadata[0], FileMode.Open, FileAccess.Read);
                                MODS_File_ReaderWriter dcreader = new MODS_File_ReaderWriter();
                                dcreader.Read_Metadata(reader, newItem, null, out errors );
                            }

                            if (metadata_type.IndexOf("MARCXML") >= 0)
                            {
                                // Open a stream to read the indicated import file
                                Stream reader = new FileStream(metadata[0], FileMode.Open, FileAccess.Read);
                                MarcXML_File_ReaderWriter dcreader = new MarcXML_File_ReaderWriter();
                                dcreader.Read_Metadata(reader, newItem, null, out errors);
                            }
                        }

                        // Make sure there is a title
                        if (newItem.Bib_Info.Main_Title.ToString().Trim().Length == 0)
                            newItem.Bib_Info.Main_Title.Title = "Missing Title";

                        // We now have a good METS file, so let's look for files to add
                        string[] existing_files = Directory.GetFiles(thisDirectory);
                        bool image_files_found = false;
                        List<string> otherFiles = new List<string>();
                        foreach (string thisFile in existing_files)
                        {
                            string upper_case = new FileInfo(thisFile).Name.ToUpper();
                            if ((upper_case.IndexOf(".TIF") > 0) || (upper_case.IndexOf(".JPG") > 0) || (upper_case.IndexOf(".JP2") > 0))
                            {
                                image_files_found = true;
                            }
                            else if ((upper_case.IndexOf(".METS") < 0) && (upper_case.IndexOf(".TXT") < 0) && (upper_case.IndexOf(".PRO") < 0) && (upper_case.IndexOf(".XML") < 0) && (upper_case.IndexOf(".MODS") < 0) && (upper_case.IndexOf(".DC") < 0))
                            {
                                otherFiles.Add((new FileInfo(thisFile)).Name);
                            }
                        }

                        // Add the image files first
                        newItem.Source_Directory = thisDirectory;
                        Bib_Package_Builder.Add_All_Files(newItem, "*.tif|*.jpg|*.jp2|*.txt|*.pro|*.gif", MetaTemplate_UserSettings.Always_Recurse_Through_Subfolders_On_New, MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page);

                        // Add any downloads next
                        foreach (string thisFile in otherFiles)
                        {
                            newItem.Divisions.Download_Tree.Add_File(thisFile);
                        }

                        // Now, save this METS file
                        // Prepare to save the enw METS
 
                        // Determine the filename
                        string mets_file = thisDirectory + "\\" + newItem.METS_Header.ObjectID + MetaTemplate_UserSettings.METS_File_Extension;

                        // Save the actual file
                        newItem.Divisions.Suppress_Checksum = !MetaTemplate_UserSettings.Include_Checksums;

                        // Save the actual file
                        METS_File_ReaderWriter metsWriter = new METS_File_ReaderWriter();
                        string writing_error = String.Empty;
                        metsWriter.Write_Metadata(mets_file, newItem, null, out writing_error);
                    }

                }
                catch ( Exception ee )
                {
                    errors_encountered++;
                }

                OnNewProgress(current_directory, directories_to_process.Count);
                current_directory++;
            }

            OnComplete(current_directory, errors_encountered);
        }

        private void recurse_through_directories(string directory, List<string> directories_to_process)
        {
            string[] metadata = Directory.GetFiles(directory, filter);
            if (metadata.Length > 0)
            {
                directories_to_process.Add(directory);
            }

            string[] subdirs = Directory.GetDirectories(directory);
            foreach (string thisSubDir in subdirs)
            {
                recurse_through_directories(thisSubDir, directories_to_process);
            }
        }

        private void OnNewProgress(int Progress, int Maximum)
        {
            if (New_Progress != null)
                New_Progress(Progress, Maximum);
        }

        private void OnComplete(int Progress, int Errors )
        {
            if (Complete != null)
                Complete(Progress, Errors);
        }


        private void OnNewFolder(string New_Task)
        {
            if (New_Folder != null)
                New_Folder(New_Task);
        }
    }
}
