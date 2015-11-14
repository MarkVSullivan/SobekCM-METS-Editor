#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.ImageDerivative
{
    public class Multiple_Folders_Processor
    {
        /// <summary> Delegate for the custom event which is fired when the status
        /// string on the main form needs to change </summary>
        public delegate void MFP_New_Status_String_Delegate(string new_message);

        /// <summary> Delegate for the custom event which is fired when the progress
        /// bar should change. </summary>
        public delegate void MFP_New_Progress_Delegate(int Value, int Max);

        /// <summary> Delegate for the custom event which is fired when all the processing is complete </summary>
        public delegate void MFP_Process_Complete_Delegate(int Packages_Processed, int JPEG2000_Warnings);

        private bool create_jpegs;
        private bool create_jp2s;
        private int jpeg_width;
        private int jpeg_height;
        private int thumbnail_width;
        private int thumbnail_height;
        private string directory;

        private int packages_processed_count, kakadu_error_count;

        private string imagemagick_path = String.Empty;
        private string kakadu_path = String.Empty;

        /// <summary> Custom event is fired when the task string on the 
        /// main form needs to change. </summary>
        public event MFP_New_Status_String_Delegate New_Task_String;

        /// <summary> Custom event is fired when the volume string on the 
        /// main form needs to change. </summary>
        public event MFP_New_Status_String_Delegate New_Volume_String;

        /// <summary> Custom event is fired when the progress bar
        /// on the main form needs to change.  </summary>
        public event MFP_New_Progress_Delegate New_Progress;

        /// <summary> Custom event is fired when all processing is complete </summary>
        public event MFP_Process_Complete_Delegate Process_Complete;

        public Multiple_Folders_Processor(bool Create_JPEGs, bool Create_JPEG2000s, int JPEG_Width, int JPEG_Height, string Directory, int Thumbnail_Width, int Thumbnail_Height )
        {
            create_jpegs = Create_JPEGs;
            create_jp2s = Create_JPEG2000s;
            jpeg_height = JPEG_Height;
            jpeg_width = JPEG_Width;
            thumbnail_height = Thumbnail_Height;
            thumbnail_width = Thumbnail_Width;
            directory = Directory;

            imagemagick_path = MetaTemplate_UserSettings.ImageMagick_Executable;
            kakadu_path = Application.StartupPath + "\\Kakadu";
        }

        public void Process()
        {
            // Check for folders with TIFF files
            List<string> directories_to_check = new List<string>();
            OnNewTask("Checking for folders with TIFFs", true);
            recursively_check_for_folders(directory, directories_to_check);

            // If none to process, throw message and complete
            if (directories_to_check.Count == 0)
            {
                OnNewTask("No folders with TIFF files found", true);
                OnProcessComplete();
                return;
            }

            // Step through each folder
            Image_Derivative_Creation_Processor processor = new Image_Derivative_Creation_Processor(imagemagick_path, kakadu_path, create_jpegs, create_jp2s, jpeg_width, jpeg_height, false, thumbnail_width, thumbnail_height);
            processor.New_Progress +=processor_New_Progress;
            processor.New_Task_String +=processor_New_Task_String;
            processor.Process_Complete +=processor_Process_Complete;
            foreach (string thisDir in directories_to_check)
            {
                OnNewVolume(thisDir);
                string[] tiff_files = Directory.GetFiles( thisDir, "*.tif");
                processor.Process(thisDir, String.Empty, String.Empty, tiff_files);
            }

            OnProcessComplete();
        }

        void processor_Process_Complete(int Packages_Processed, int JPEG2000_Warnings)
        {
            // Do nothing since this single directory processor is not run in a seperate thread anyway
        }

        void processor_New_Task_String(string new_message)
        {
            OnNewTask(new_message, true);
        }

        void processor_New_Progress(int Value, int Max)
        {
            OnNewProgress(Value, Max);
        }

        private void recursively_check_for_folders(string CheckDir, List<string> directories_to_check)
        {
            // Look in this directory
            string[] TIFF_Files = Directory.GetFiles(CheckDir, "*.tif");
            if (TIFF_Files.Length > 0)
                directories_to_check.Add(CheckDir);

            // Look in the chil directories
            string[] subdirs = Directory.GetDirectories(CheckDir);
            if (subdirs.Length > 0)
            {
                foreach (string thisSubDir in subdirs)
                {
                    recursively_check_for_folders(thisSubDir, directories_to_check);
                }
            }
        }

        private void OnNewProgress(int Value, int Max)
        {
            if (New_Progress != null)
            {
                if (Value > Max)
                {
                    New_Progress(Value, Value);
                }
                else
                {
                    New_Progress(Value, Max);
                }
            }
        }

        private void OnNewTask(string newMessage, bool includeInLog)
        {
            //if (includeInLog)
            //    myLog.AddNonError(newMessage);

            if (New_Task_String != null)
                New_Task_String(newMessage);
        }

        private void OnNewVolume(string newMessage)
        {
            if (New_Volume_String != null)
                New_Volume_String(newMessage);
           // myLog.AddComplete(newMessage);
        }

        private void OnProcessComplete()
        {
            if (Process_Complete != null)
                Process_Complete(packages_processed_count, kakadu_error_count);
        }
    }
}
