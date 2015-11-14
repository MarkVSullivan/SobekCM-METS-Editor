using System;
using System.Configuration;
using Microsoft.Win32;

namespace DLC.Tools.Settings
{
    /// <summary> App_Config_Reader is a static object which contains the 
    /// information from the Application Configuration file. </summary>
    public class App_Config_Reader
    {
        /// <summary> Flag indicates whether this program is running as a local
        /// instance, without database and network access. </summary>
        public static readonly string Tracking_Database;
        public static readonly string Record_Namespace;
        public static readonly string QC_Title;
        public static readonly string PreQC_Title;
        public static readonly string QC_Online_Help;
        public static readonly bool Use_QC_Final_Option;
        public static readonly string Online_Items_URL;
        public static readonly string Network_MARC_XML_Directory;
        public static readonly string Project_METS_Directory;
        public static readonly string Network_METS_Directory;
        public static readonly string Database;
        public static readonly string Database_Name;
        public static readonly string Database_Server;
        private static string imageMagickPath;
        private static string metadataTemplatePath;
        public static readonly string UFDC_Base_URL;
        public static readonly string Go_UFDC_Title;
        public static readonly string Go_UFDC_Online_Help;
        public static readonly string DLC_Toolbox_Online_Help;
        public static readonly bool Allow_FDA_Send;
        public static readonly string Local_Log_Location;
        public static readonly string UFDC_Base_Location;
        public static readonly string Greenstone_Base;
        public static readonly string CD_Manager_Online_Help;
        public static readonly bool App_Reader_Error;


        /// <summary> Static constructor for the App_Config_Reader object </summary>
        static App_Config_Reader()
        {
            try
            {
                // Get the flag which tracking database to use
                Tracking_Database = ConfigurationSettings.AppSettings["Database"].ToUpper().Trim();
                Record_Namespace = ConfigurationSettings.AppSettings["Record Namespace"];
                QC_Title = ConfigurationSettings.AppSettings["QC Title"];
                PreQC_Title = ConfigurationSettings.AppSettings["PreQC Title"];
                QC_Online_Help = ConfigurationSettings.AppSettings["QC Online Help"];
                Use_QC_Final_Option = Convert.ToBoolean(ConfigurationSettings.AppSettings["QC Use QC Final Option"]);
                UFDC_Base_URL = ConfigurationSettings.AppSettings["UFDC Base URL"];
                Online_Items_URL = ConfigurationSettings.AppSettings["Online Items URL"];
                Network_MARC_XML_Directory = ConfigurationSettings.AppSettings["Network MARC XML Directory"];
                Project_METS_Directory = ConfigurationSettings.AppSettings["Project METS Directory"];
                Network_METS_Directory = ConfigurationSettings.AppSettings["Network METS Directory"];
                Database = ConfigurationSettings.AppSettings["Database"];
                Database_Name = ConfigurationSettings.AppSettings["Database Name"];
                Database_Server = ConfigurationSettings.AppSettings["Database Server"];
                Go_UFDC_Title = ConfigurationSettings.AppSettings["Go UFDC Title"];
                Go_UFDC_Online_Help = ConfigurationSettings.AppSettings["Go UFDC Online Help"];
                Allow_FDA_Send = Convert.ToBoolean( ConfigurationSettings.AppSettings["Allow FDA Send"] );
                Local_Log_Location = ConfigurationSettings.AppSettings["LocalLogDirectory"];

                CD_Manager_Online_Help = ConfigurationSettings.AppSettings["CD Manager Online Help"];

                DLC_Toolbox_Online_Help = ConfigurationSettings.AppSettings["DLC Toolbox Online Help"];

                UFDC_Base_Location = ConfigurationSettings.AppSettings["UFDC Base Location"];
                Greenstone_Base = ConfigurationSettings.AppSettings["Greenstone Base"];


                App_Reader_Error = false;
            }
            catch
            {
                // An error was caught, so set the error flag to true
                App_Reader_Error = true;
            }
        }

        public static string ImageMagick_Path_From_Registry
        {
            get
            {
                try
                {
                    // Attempt to open the key
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\ImageMagick\\Current");

                    // If the return value is null, the key doesn't exist
                    if (key != null)
                    {
                        // The key doesn't exist; create it / open it
                        if (key.GetValue("BinPath") != null)
                        {
                            return key.GetValue("BinPath").ToString();
                        }
                    }
                }
                catch
                {

                }

                try
                {
                    if (System.IO.Directory.Exists(@"C:\Program Files (x86)"))
                    {
                        string[] possible_image_folder = System.IO.Directory.GetDirectories(@"C:\Program Files (x86)", "ImageMagick*");
                        if (possible_image_folder.Length > 0)
                            return possible_image_folder[0];

                    }

                    if (System.IO.Directory.Exists(@"C:\Program Files"))
                    {
                        string[] possible_image_folder = System.IO.Directory.GetDirectories(@"C:\Program Files", "ImageMagick*");
                        if (possible_image_folder.Length > 0)
                            return possible_image_folder[0];
                    }
                }
                catch
                {

                }

                return String.Empty;
            }
        }

        public static string ImageMagick_Path
        {
            set
            {
                imageMagickPath = value;
            }
            get
            {
                if (( imageMagickPath != null ) && (imageMagickPath.Length > 0 ))
                {
                    return imageMagickPath;
                }

                imageMagickPath = ImageMagick_Path_From_Registry;
                return imageMagickPath;
            }
        }

        public static string MetadataTemplate_Path
        {
            get
            {
                if (metadataTemplatePath != null)
                {
                    return metadataTemplatePath;
                }

                try
                {
                    // Attempt to open the key
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\University of Florida\\METS Viewer");

                    // If the return value is null, the key doesn't exist
                    if (key != null)
                    {
                        // The key doesn't exist; create it / open it
                        if (key.GetValue("BinPath") != null)
                        {
                            metadataTemplatePath = key.GetValue("BinPath").ToString();
                            return metadataTemplatePath;
                        }
                    }
                }
                catch
                {
                    return String.Empty;
                }

                return String.Empty;
            }
        }

        public static bool Adobe_Photoshop_Installed
        {
            get
            {
                try
                {
                    // Attempt to open the key
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Adobe\\Photoshop\\8.0");

                    // If the return value is null, the key doesn't exist
                    if (key != null)
                    {
                        // The key doesn't exist; create it / open it
                        if (key.GetValue("ApplicationPath") != null)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }

                return false;
            }
        }
    }
}
