using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DLC.Tools;
using Microsoft.Win32;


namespace DLC.Tools.Settings
{
    /// <summary> Software used to create the JPEG derivatives </summary>
    public enum Derivative_Creation_Software
    {
        /// <summary> No software is installed to create the JPEG derivatives </summary>
        None = 0,

        /// <summary> Adobe Photoshop CS </summary>
        Photoshop_CS,

        /// <summary> ImageMagick </summary>
        ImageMagick,

        /// <summary> Kakadu (used for JPEG2000) </summary>
        Kakadu,

        Aurigma
    }

    public enum FTP_Method_Enum
    {
        Secure_FTP = 1,

        Original_FTP,

        Native_FTP
    }

    /// <summary> Enumeration for the different forms of automatic numbering </summary>
    /// <remarks> This controls whether the new pagination cascades down through all the pages </remarks>
    public enum Automatic_Numbering_Enum
    {
        /// <summary> No automatic renumbering cascade </summary>
        None = 1,
        /// <summary> Automatically renumber the same division </summary>
        Division,
        /// <summary> Automatically renumber the entire document </summary>
        Document
    }

    public enum Toolstrip_Container_Panel
    {
        Left = 0,
        Top, 
        Right, 
        Bottom
    }

    public enum Security_Levels_Enum
    {
        Supervisor = 1,
        User,
        Undetermined
    }

    public enum Move_Or_Copy
    {
        UNDEFINED = -1,
        MOVE = 1,
        COPY
    }


	/// <summary> QC_UserSettings is a static class which holds all of the settings for this 
	/// particular user and assemply in the Isolated Storage. </summary>
	public class DLC_UserSettings : IS_UserSettings
	{
		/// <summary> Name of the XML file used to store the QC settings </summary>
		private static string fileName = "DLC_Toolbox_UserSettings_Version_4_0";

		/// <summary> Off black color used for the fonts </summary>
		private static Color custom_black = System.Drawing.Color.FromArgb(((System.Byte)(60)), ((System.Byte)(60)), ((System.Byte)(60)));

        public static Color Active_Control_Highlight_Color = System.Drawing.Color.Khaki;

		private static bool hansard_special_project;

        public static bool just_created;

		private static Automatic_Numbering_Enum automatic_numbering;
        private static FTP_Method_Enum ftp_method;
        private static Move_Or_Copy move_or_copy;

        private static string ufdc_ip, ufdc_subfolder, ufdc_username, ufdc_password;
        private static bool ufdc_passive_ftp, ufdc_use_ssl;

        private static bool allow_go_ufdc, allow_qc, allow_preqc, allow_mets, allow_tracking, allow_importer,
            allow_cd_manager, allow_cd_indexer, allow_ufdc_manager, allow_lister, allow_aerials, allow_fda_reader;

		/// <summary> Static constructor for the QC_UserSettings class. </summary>
		static DLC_UserSettings() 
		{
			hansard_special_project = false;
			automatic_numbering = Automatic_Numbering_Enum.Document;
            just_created = false;
            ftp_method = FTP_Method_Enum.Secure_FTP;
            move_or_copy = Move_Or_Copy.UNDEFINED;
		}

        #region Constant (currently) values for TIVOLI and loading to UFDC directly

        public static bool Move_To_Tivoli
        {
            get { return true; }
        }

        public static string Tivoli_Dropbox_Directory
        {
            get { return @"\\ad.ufl.edu\uflib\DLC\Archive\DROPBOX\"; }
        }

        public static List<string> UFDC_Dropbox_Directories
        {
            get
            {
                List<string> returnValue = new List<string>();
                returnValue.Add(@"\\fcla-sobekfs\UFDC\INCOMING\inbound\");
                return returnValue;
            }
        }

        #endregion

		public static Color Custom_Black
		{
			get	{	return custom_black;		}
		}

		/// <summary> Flag indicates if this is for the Hansard Special Project </summary>
		/// <remarks>This flag is not stored between launches of the QC application</remarks>
		public static bool Hansard_Special_Project
		{
			get	{	return hansard_special_project;		}
			set	{	hansard_special_project = value;	}
		}

		/// <summary> Indicates the type or automatic numbering cascading to occur </summary>
		/// <remarks>This flag is not stored between launches of the QC application</remarks>
		public static Automatic_Numbering_Enum Automatic_Numbering
		{
			get	{	return automatic_numbering;		}
			set	{	automatic_numbering = value;	}
        }

        public static bool Just_Created
        {
            get { return just_created; }
            set { just_created = value; }
        }

        public static int QC_Tree_View_Width
        {
            get
            {
                return Get_Int_Setting("QC_Tree_View_Width");
            }
            set
            {
                Add_Setting("QC_Tree_View_Width", value);
            }
        }


        private static void Set_SIEF_Settings()
        {
            Add_Setting("SIEF_Tools.Edit_Options", "FALSE");
            Add_Setting("SIEF_Tools.IsVisible", "True");
            Add_Setting("SIEF_Tools.IsSnapped", "True");
            Add_Setting("SIEF_Tools.X", 45);
            Add_Setting("SIEF_Tools.Y", 45);
            Add_Setting("SIEF_Tools.SnappedTo", "MainForm");
            Add_Setting("SIEF_Tools.HorizontalEdge", "Top");
            Add_Setting("SIEF_Tools.VerticalEdge", "Left");
            Add_Setting("SIEF_Tools.XOffset", 3);
            Add_Setting("SIEF_Tools.YOffset", 3);

            Add_Setting("SIEF_History.IsVisible", "True");
            Add_Setting("SIEF_History.IsSnapped", "True");
            Add_Setting("SIEF_History.X", 45);
            Add_Setting("SIEF_History.Y", 45);
            Add_Setting("SIEF_History.SnappedTo", "MainForm");
            Add_Setting("SIEF_History.HorizontalEdge", "Top");
            Add_Setting("SIEF_History.VerticalEdge", "Right");
            Add_Setting("SIEF_History.XOffset", 3);
            Add_Setting("SIEF_History.YOffset", 31);

            Add_Setting("SIEF_Previous_Page.IsVisible", "True");
            Add_Setting("SIEF_Previous_Page.IsSnapped", "True");
            Add_Setting("SIEF_Previous_Page.X", 45);
            Add_Setting("SIEF_Previous_Page.Y", 45);
            Add_Setting("SIEF_Previous_Page.SnappedTo", "MainForm");
            Add_Setting("SIEF_Previous_Page.HorizontalEdge", "Bottom");
            Add_Setting("SIEF_Previous_Page.VerticalEdge", "Left");
            Add_Setting("SIEF_Previous_Page.XOffset", 3);
            Add_Setting("SIEF_Previous_Page.YOffset", 3);

            Add_Setting("SIEF_Next_Page.IsVisible", "True");
            Add_Setting("SIEF_Next_Page.IsSnapped", "True");
            Add_Setting("SIEF_Next_Page.X", 45);
            Add_Setting("SIEF_Next_Page.Y", 45);
            Add_Setting("SIEF_Next_Page.SnappedTo", "MainForm");
            Add_Setting("SIEF_Next_Page.HorizontalEdge", "Bottom");
            Add_Setting("SIEF_Next_Page.VerticalEdge", "Right");
            Add_Setting("SIEF_Next_Page.XOffset", 3);
            Add_Setting("SIEF_Next_Page.YOffset", 3);

            Add_Setting("SIEF_GridLines", "FALSE");
            Add_Setting("SIEF_Rulers", "FALSE");
            Add_Setting("SIEF_Units", "Pixels");

            Add_Setting("SIEF_Background_Red", 255);
            Add_Setting("SIEF_Background_Green", 255);
            Add_Setting("SIEF_Background_Blue", 255);
            Add_Setting("SIEF_Foreground_Red", 0);
            Add_Setting("SIEF_Foreground_Green", 0);
            Add_Setting("SIEF_Foreground_Blue", 0);

            Save();
        }

		/// <summary> Load the individual user settings </summary>
		public static void Load( bool default_qc_final_use )
        {
            // Try to read the XML file from isolated storage
            Read_XML_File(fileName);

            // Always add PALMM Subfolder
            Add_Setting("PALMM_SubFolder", "");

            // Make sure this contains one setting. If not, set them to default
            if (Get_Int_Setting("Language") == -1)
            {
                // Set the fact this is being loaded for the first time
                just_created = true;

                // Add the defaults
                Add_Setting("Language", 1);
                Add_Setting("Name_Divisions", "TRUE");
                Add_Setting("Background_Color", "White");
                Add_Setting("Page_Color", "LightSteelBlue");
                Add_Setting("Text_Color", "CustomBlack");
                Add_Setting("Selected_Color", "Gold");
                Add_Setting("Thumbnail_Size", 2);
                Add_Setting("Corner_Arch", 10);
                Add_Setting("Main_Form_Width", 470);
                Add_Setting("Main_Form_Height", 590);
                Add_Setting("Default_Action_On_Save", "NONE");
                Add_Setting("Use_QC_Final_Option", default_qc_final_use.ToString().ToUpper());
                Add_Setting("Show_QC_Final_Packages", "FALSE");
                Add_Setting("Derivative_Software", "NONE");
                Add_Setting("JPEG2000_Software", "KAKADU");
                Add_Setting("Stop_For_Errors", "TRUE");
                Add_Setting("Metadata_Help_Source", 1);

                Add_Setting("SIEF_Tools.Edit_Options", "FALSE");
                Add_Setting("SIEF_Tools.IsVisible", "True");
                Add_Setting("SIEF_Tools.IsSnapped", "True");
                Add_Setting("SIEF_Tools.X", 45);
                Add_Setting("SIEF_Tools.Y", 45);
                Add_Setting("SIEF_Tools.SnappedTo", "MainForm");
                Add_Setting("SIEF_Tools.HorizontalEdge", "Top");
                Add_Setting("SIEF_Tools.VerticalEdge", "Left");
                Add_Setting("SIEF_Tools.XOffset", 3);
                Add_Setting("SIEF_Tools.YOffset", 3);

                Add_Setting("SIEF_History.IsVisible", "True");
                Add_Setting("SIEF_History.IsSnapped", "True");
                Add_Setting("SIEF_History.X", 45);
                Add_Setting("SIEF_History.Y", 45);
                Add_Setting("SIEF_History.SnappedTo", "MainForm");
                Add_Setting("SIEF_History.HorizontalEdge", "Top");
                Add_Setting("SIEF_History.VerticalEdge", "Right");
                Add_Setting("SIEF_History.XOffset", 3);
                Add_Setting("SIEF_History.YOffset", 31);

                Add_Setting("SIEF_Previous_Page.IsVisible", "True");
                Add_Setting("SIEF_Previous_Page.IsSnapped", "True");
                Add_Setting("SIEF_Previous_Page.X", 45);
                Add_Setting("SIEF_Previous_Page.Y", 45);
                Add_Setting("SIEF_Previous_Page.SnappedTo", "MainForm");
                Add_Setting("SIEF_Previous_Page.HorizontalEdge", "Bottom");
                Add_Setting("SIEF_Previous_Page.VerticalEdge", "Left");
                Add_Setting("SIEF_Previous_Page.XOffset", 3);
                Add_Setting("SIEF_Previous_Page.YOffset", 3);

                Add_Setting("SIEF_Next_Page.IsVisible", "True");
                Add_Setting("SIEF_Next_Page.IsSnapped", "True");
                Add_Setting("SIEF_Next_Page.X", 45);
                Add_Setting("SIEF_Next_Page.Y", 45);
                Add_Setting("SIEF_Next_Page.SnappedTo", "MainForm");
                Add_Setting("SIEF_Next_Page.HorizontalEdge", "Bottom");
                Add_Setting("SIEF_Next_Page.VerticalEdge", "Right");
                Add_Setting("SIEF_Next_Page.XOffset", 3);
                Add_Setting("SIEF_Next_Page.YOffset", 3);

                Add_Setting("SIEF_GridLines", "FALSE");
                Add_Setting("SIEF_Rulers", "FALSE");
                Add_Setting("SIEF_Units", "Pixels");

                Add_Setting("SIEF_Background_Red", 255);
                Add_Setting("SIEF_Background_Green", 255);
                Add_Setting("SIEF_Background_Blue", 255);
                Add_Setting("SIEF_Foreground_Red", 0);
                Add_Setting("SIEF_Foreground_Green", 0);
                Add_Setting("SIEF_Foreground_Blue", 0);

                Add_Setting("Toolbox_Width", 597);
                Add_Setting("Toolbox_Height", 416);
                Add_Setting("Toolbox_Workflow_Order", "TRUE");
                Add_Setting("Toolbox_Show_Icons", "TRUE");
                Add_Setting("User_Security_Level", "USER");

                // Attempt to open the key
                RegistryKey read_key = Registry.LocalMachine.OpenSubKey("Software\\University of Florida\\DLC Toolbox\\Settings");
                if (read_key != null)
                {
                    try
                    {
                        // Read all the values
                        if (read_key.GetValue("Custom_Application 1 Name") != null)
                        {
                            Add_Setting("Custom_Application_1_Name", read_key.GetValue("Custom Application 1 Name").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom_Application 1 Link") != null)
                        {
                            Add_Setting("Custom_Application_1_Link", read_key.GetValue("Custom Application 1 Link").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom Application 1 Active") != null)
                        {
                            Add_Setting("Custom_Application_1_Active", read_key.GetValue("Custom Application 1 Active").ToString());
                        }

                        // Read all the values
                        if (read_key.GetValue("Custom Application 1 Icon") != null)
                        {
                            Add_Setting("Custom_Application_1_Icon", read_key.GetValue("Custom Application 1 Icon").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom Application 2 Name") != null)
                        {
                            Add_Setting("Custom_Application_2_Name", read_key.GetValue("Custom Application 2 Name").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom Application 2 Link") != null)
                        {
                            Add_Setting("Custom_Application_2_Link", read_key.GetValue("Custom Application 2 Link").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom Application 2 Active") != null)
                        {
                            Add_Setting("Custom_Application_2_Active", read_key.GetValue("Custom Application 2 Active").ToString());
                        }
                        // Read all the values
                        if (read_key.GetValue("Custom Application 2 Link") != null)
                        {
                            Add_Setting("Custom_Application_2_Icon", read_key.GetValue("Custom Application 2 Icon").ToString());
                        }
                    }
                    catch
                    {
                        Add_Setting("Custom_Application_1_Name", "");
                        Add_Setting("Custom_Application_1_Link", "");
                        Add_Setting("Custom_Application_1_Active", "FALSE");
                        Add_Setting("Custom_Application_1_Icon", -1);
                        Add_Setting("Custom_Application_2_Name", "");
                        Add_Setting("Custom_Application_2_Link", "");
                        Add_Setting("Custom_Application_2_Active", "FALSE");
                        Add_Setting("Custom_Application_2_Icon", -1);
                    }
                }
                else
                {
                    Add_Setting("Custom_Application_1_Name", "");
                    Add_Setting("Custom_Application_1_Link", "");
                    Add_Setting("Custom_Application_1_Active", "FALSE");
                    Add_Setting("Custom_Application_1_Icon", -1);
                    Add_Setting("Custom_Application_2_Name", "");
                    Add_Setting("Custom_Application_2_Link", "");
                    Add_Setting("Custom_Application_2_Active", "FALSE");
                    Add_Setting("Custom_Application_2_Icon", -1);
                }

                Add_Setting("Retain_Detailed_PreQC_Logs", "FALSE");

                Save();
            }


            // Load which applications can be accessed through the toolkit here
            Load_DLC_Toolbox_Allows();

            // Add the table for the source drives
            if (Setting_DataSet.Tables.Count < 2)
            {
                DataTable drives = new DataTable();
                drives.Columns.Add(new DataColumn("Drive_Descriptor"));
                drives.Columns.Add(new DataColumn("Base_Directory"));
                drives.Columns.Add(new DataColumn("PreQC_Directories"));
                drives.Columns.Add(new DataColumn("QC_Directory"));
                drives.Columns.Add(new DataColumn("OCR_Directory"));
                drives.Columns.Add(new DataColumn("Load_Directory"));
                drives.Columns.Add(new DataColumn("Error_Directory"));
                drives.Columns.Add(new DataColumn("Archive_Directory"));
                drives.Columns.Add(new DataColumn("is_Active", Type.GetType("System.Boolean")));
                drives.Columns.Add(new DataColumn("Locked", Type.GetType("System.Boolean")));
                drives.Columns.Add(new DataColumn("Always_Copy", Type.GetType("System.Boolean")));
                Setting_DataSet.Tables.Add(drives);

                //// Add the DLOC fixed folders on C:\
                //ArrayList dloc_preqc = new ArrayList();
                //dloc_preqc.Add("C:\\DLOC\\Ready for QC\\");
                //Add_Drive("Fixed DLOC Subfolder", "C:\\DLOC\\", dloc_preqc, "C:\\DLOC\\QC\\", "C:\\DLOC\\Complete\\", "C:\\DLOC\\Complete\\", "C:\\DLOC\\", "C:\\DLOC\\Archive\\", false, true, false);

                //// Add the UFDC fixed folders on C:\
                //ArrayList ufdc_preqc = new ArrayList();
                //ufdc_preqc.Add("C:\\UFDC\\Ready for QC\\");
                //Add_Drive("Fixed UFDC Subfolder", "C:\\UFDC\\", ufdc_preqc, "C:\\UFDC\\QC\\", "C:\\UFDC\\Complete\\", "C:\\UFDC\\Complete\\", "C:\\UFDC\\", "C:\\UFDC\\Archive\\", false, true, false );

                // Add the DLC SAN
                ArrayList dlc_san_preqc = new ArrayList();
                dlc_san_preqc.Add(@"\\ad.ufl.edu\uflib\DLC\Main\PreQC");
                Add_Drive("DLC SAN", @"\\ad.ufl.edu\uflib\DLC\Main\", dlc_san_preqc, @"\\ad.ufl.edu\uflib\DLC\Main\QC\", @"\\ad.ufl.edu\uflib\DLC\Main\OCR\", @"\\ad.ufl.edu\uflib\DLC\Main\Markup\", @"\\ad.ufl.edu\uflib\DLC\Main\Error\", @"\\ad.ufl.edu\uflib\DLC\Main\Archive\", true, true, false);

                // Save the settings
                Save();
            }

            bool resave = false;
            foreach (DataRow thisRow in Setting_DataSet.Tables[1].Rows)
            {
                string base_dir = thisRow["Base_Directory"].ToString().ToUpper();
                if ((base_dir.IndexOf("C:\\") == 0) || (base_dir.IndexOf("DLCSAN") >= 0))
                {
                    thisRow["Locked"] = false;
                    resave = true;
                }
            }

            if (Setting_DataSet.Tables[1].Rows.Count == 0)
            {
                // Add the DLC SAN
                ArrayList dlc_san_preqc1 = new ArrayList();
                dlc_san_preqc1.Add(@"\\ad.ufl.edu\uflib\DLC\Main\PreQC");
                Add_Drive("DLC SAN", @"\\ad.ufl.edu\uflib\DLC\Main\", dlc_san_preqc1, @"\\ad.ufl.edu\uflib\DLC\Main\QC\", @"\\ad.ufl.edu\uflib\DLC\Main\OCR\", @"\\ad.ufl.edu\uflib\DLC\Main\Markup\", @"\\ad.ufl.edu\uflib\DLC\Main\Error\", @"\\ad.ufl.edu\uflib\DLC\Main\Archive\", true, true, false);
                resave = true;
            }

            if (resave)
                Save();
        }

        public static int Metadata_Help_Source
        {
            get
            {
                return Get_Int_Setting("Metadata_Help_Source");
            }
            set
            {
                Add_Setting("Metadata_Help_Source", value);
            }
        }
       
        public static byte Background_Red
        {
            get {   return byte.Parse( Get_String_Setting( "SIEF_Background_Red" )); }   
            set {   Add_Setting("SIEF_Background_Red", value.ToString() );  }
        }


        public static byte Background_Green
        {
            get { return byte.Parse(Get_String_Setting("SIEF_Background_Green")); }   
            set {   Add_Setting("SIEF_Background_Green", value.ToString() );  }
        }

        public static byte Background_Blue
        {
            get { return byte.Parse(Get_String_Setting("SIEF_Background_Blue")); }   
            set {   Add_Setting("SIEF_Background_Blue", value.ToString() );  }
        }

        public static byte Foreground_Red
        {
            get { return byte.Parse(Get_String_Setting("SIEF_Foreground_Red")); }   
            set {   Add_Setting("SIEF_Foreground_Red", value.ToString() );  }
        }


        public static byte Foreground_Green
        {
            get { return byte.Parse(Get_String_Setting("SIEF_Foreground_Green")); }   
            set {   Add_Setting("SIEF_Foreground_Green", value.ToString() );  }
        }

        public static byte Foreground_Blue
        {
            get 
            { 
                string blue = Get_String_Setting( "SIEF_Foreground_Blue" );
                if (blue.Length == 0)
                {
                    Set_SIEF_Settings();
                }
                return byte.Parse(Get_String_Setting("SIEF_Foreground_Blue")); 
            }   
            set {   Add_Setting("SIEF_Foreground_Blue", value.ToString() );  }
        }

        #region Custom Applications in Toolbox Launch Pad

        public static bool Custom_Application_1_Active
        {
            get 
            {
                if ( Get_String_Setting("Custom_Application_1_Active").ToUpper() == "TRUE" )
                    return true;
                else
                    return false;
            }
            set
            {
                Add_Setting("Custom_Application_1_Active", value.ToString().ToUpper());
            }
        }

        public static string Custom_Application_1_Name
        {
            get 
            {
                return Get_String_Setting("Custom_Application_1_Name");
            }
            set
            {
                Add_Setting("Custom_Application_1_Name", value);
            }
        }

        public static string Custom_Application_1_Link
        {
            get 
            {
                return Get_String_Setting("Custom_Application_1_Link");
            }
            set
            {
                Add_Setting("Custom_Application_1_Link", value);
            }
        }

        public static int Custom_Application_1_Icon
        {
            get
            {
                string value = Get_String_Setting("Custom_Application_1_Icon");
                if (value.Length == 0)
                    return -1;

                try
                {
                    return Convert.ToInt16(value);
                }
                catch
                {
                    return -1;
                }
            }
            set
            {
                Add_Setting("Custom_Application_1_Icon", value);
            }
        }

        public static bool Custom_Application_2_Active
        {
            get
            {
                if (Get_String_Setting("Custom_Application_2_Active").ToUpper() == "TRUE")
                    return true;
                else
                    return false;
            }
            set
            {
                Add_Setting("Custom_Application_2_Active", value.ToString().ToUpper());
            }
        }

        public static string Custom_Application_2_Name
        {
            get
            {
                return Get_String_Setting("Custom_Application_2_Name");
            }
            set
            {
                Add_Setting("Custom_Application_2_Name", value);
            }
        }

        public static string Custom_Application_2_Link
        {
            get
            {
                return Get_String_Setting("Custom_Application_2_Link");
            }
            set
            {
                Add_Setting("Custom_Application_2_Link", value);
            }
        }

        public static int Custom_Application_2_Icon
        {
            get
            {
                string value = Get_String_Setting("Custom_Application_2_Icon");
                if (value.Length == 0)
                    return -1;

                try
                {
                    return Convert.ToInt16(value);
                }
                catch
                {
                    return -1;
                }
            }
            set
            {
                Add_Setting("Custom_Application_2_Icon", value);
            }
        }

        #endregion

        #region Flags that tell if buttons are ALLOWED in the DLC Toolbox

        public static void Load_DLC_Toolbox_Allows()
        {
            // Set the defaults
            allow_go_ufdc = true;
            allow_qc = true;
            allow_preqc = true;
            allow_mets = true;
            allow_tracking = true;
            allow_importer = true;
            allow_cd_manager = true;
            allow_cd_indexer = true;
            allow_ufdc_manager = true;
            allow_lister = true;
            allow_aerials = true;
            allow_fda_reader = true;

            // Attempt to open the key
            RegistryKey read_key = Registry.LocalMachine.OpenSubKey("Software\\University of Florida\\DLC Toolbox\\Settings");
            if (read_key != null)
            {
                // Read all the values
                if (read_key.GetValue("Allow Go UFDC!") != null)
                {
                    if (read_key.GetValue("Allow Go UFDC!").ToString().ToUpper() == "FALSE")
                        allow_go_ufdc = false;
                }
                if (read_key.GetValue("Allow FDA Report Reader") != null)
                {
                    if (read_key.GetValue("Allow FDA Report Reader").ToString().ToUpper() == "FALSE")
                        allow_fda_reader = false;
                }
                if (read_key.GetValue("Allow QC") != null)
                {
                    if (read_key.GetValue("Allow QC").ToString().ToUpper() == "FALSE")
                        allow_qc = false;
                }
                if (read_key.GetValue("Allow PreQC") != null)
                {
                    if (read_key.GetValue("Allow PreQC").ToString().ToUpper() == "FALSE")
                        allow_preqc = false;
                }
                if (read_key.GetValue("Allow METS Editor") != null)
                {
                    if (read_key.GetValue("Allow METS Editor").ToString().ToUpper() == "FALSE")
                        allow_mets = false;
                }
                if (read_key.GetValue("Allow Tracking") != null)
                {
                    if (read_key.GetValue("Allow Tracking").ToString().ToUpper() == "FALSE")
                        allow_tracking = false;
                }
                if (read_key.GetValue("Allow Importer") != null)
                {
                    if (read_key.GetValue("Allow Importer").ToString().ToUpper() == "FALSE")
                        allow_importer = false;
                }
                if (read_key.GetValue("Allow CD Manager") != null)
                {
                    if (read_key.GetValue("Allow CD Manager").ToString().ToUpper() == "FALSE")
                        allow_cd_manager = false;
                }
                if (read_key.GetValue("Allow CD Indexer") != null)
                {
                    if (read_key.GetValue("Allow CD Indexer").ToString().ToUpper() == "FALSE")
                        allow_cd_indexer = false;
                }
                if (read_key.GetValue("Allow UFDC Manager") != null)
                {
                    if (read_key.GetValue("Allow UFDC Manager").ToString().ToUpper() == "FALSE")
                        allow_ufdc_manager = false;
                }
                if (read_key.GetValue("Allow Drive Lister") != null)
                {
                    if (read_key.GetValue("Allow Drive Lister").ToString().ToUpper() == "FALSE")
                        allow_lister = false;
                }
                if (read_key.GetValue("Allow Aerials Database") != null)
                {
                    if (read_key.GetValue("Allow Aerials Database").ToString().ToUpper() == "FALSE")
                        allow_aerials = false;
                }

            }
            else
            {
                Save_DLC_Toolbox_Settings();
            }
        }

        public static void Save_Default_Custom_Applications(string custom1_name, string custom1_link, int custom1_icon, bool custom1_active, string custom2_name, string custom2_link, int custom2_icon, bool custom2_active)
        {
            try
            {
                RegistryKey create_key = Registry.LocalMachine.CreateSubKey("Software\\University of Florida\\DLC Toolbox\\Settings");
                if (create_key != null)
                {
                    create_key.SetValue("Custom Application 1 Name", custom1_name);
                    create_key.SetValue("Custom Application 1 Link", custom1_link);
                    create_key.SetValue("Custom Application 1 Active", custom1_icon);
                    create_key.SetValue("Custom Application 1 Icon", custom1_active);
                    create_key.SetValue("Custom Application 2 Name", custom2_name);
                    create_key.SetValue("Custom Application 2 Link", custom2_link);
                    create_key.SetValue("Custom Application 2 Active", custom2_active);
                    create_key.SetValue("Custom Application 2 Icon", custom2_icon);
                }
            }
            catch (Exception ee)
            {
            }
        }

        public static bool Save_DLC_Toolbox_Settings()
        {
            try
            {
                RegistryKey create_key = Registry.LocalMachine.CreateSubKey("Software\\University of Florida\\DLC Toolbox\\Settings");
                if (create_key != null)
                {
                    create_key.SetValue("Allow FDA Report Reader", allow_fda_reader.ToString().ToUpper());
                    create_key.SetValue("Allow Go UFDC!", allow_go_ufdc.ToString().ToUpper());
                    create_key.SetValue("Allow QC", allow_qc.ToString().ToUpper());
                    create_key.SetValue("Allow PreQC", allow_preqc.ToString().ToUpper());
                    create_key.SetValue("Allow METS Editor", allow_mets.ToString().ToUpper());
                    create_key.SetValue("Allow Tracking", allow_tracking.ToString().ToUpper());
                    create_key.SetValue("Allow Importer", allow_importer.ToString().ToUpper());
                    create_key.SetValue("Allow CD Manager", allow_cd_manager.ToString().ToUpper());
                    create_key.SetValue("Allow CD Indexer", allow_cd_indexer.ToString().ToUpper());
                    create_key.SetValue("Allow UFDC Manager", allow_ufdc_manager.ToString().ToUpper());
                    create_key.SetValue("Allow Drive Lister", allow_lister.ToString().ToUpper());
                    create_key.SetValue("Allow Aerials Database", allow_aerials.ToString().ToUpper());
                    return true;
                }
            }
            catch (Exception ee)
            {
            }

            return false;
        }


        public static bool Toolbox_Allow_Go_UFDC
        {
            get { return allow_go_ufdc; }
            set { allow_go_ufdc = value; }
        }

        public static bool Toolbox_Allow_FDA_Report_Reader
        {
            get { return allow_fda_reader; }
            set { allow_fda_reader = value; }
        }

        public static bool Toolbox_Allow_QC
        {
            get { return allow_qc; }
            set { allow_qc = value; }
        }

        public static bool Toolbox_Allow_PreQC
        {
            get { return allow_preqc; }
            set { allow_preqc = value; }
        }

        public static bool Toolbox_Allow_METS_Editor
        {
            get { return allow_mets; }
            set { allow_mets = value; }
        }

        public static bool Toolbox_Allow_Tracking
        {
            get { return allow_tracking; }
            set { allow_tracking = value; }
        }

        public static bool Toolbox_Allow_Importer
        {
            get { return allow_importer; }
            set { allow_importer = value; }
        }

        public static bool Toolbox_Allow_CD_Manager
        {
            get { return allow_cd_manager; }
            set { allow_cd_manager = value; }
        }

        public static bool Toolbox_Allow_CD_Indexer
        {
            get { return allow_cd_indexer; }
            set { allow_cd_indexer = value; }
        }

        public static bool Toolbox_Allow_UFDC_Manager
        {
            get { return allow_ufdc_manager; }
            set { allow_ufdc_manager = value; }
        }

        public static bool Toolbox_Allow_Drive_Lister
        {
            get { return allow_lister; }
            set { allow_lister = value; }
        }

        public static bool Toolbox_Allow_Aerials_Database
        {
            get { return allow_aerials; }
            set { allow_aerials = value; }
        }

        #endregion

        #region Flags that tell if buttons shouls appear in the DLC Toolbox

        public static bool Toolbox_Show_Go_UFDC
        {
            set
            {
                Add_Setting("Toolbox_Show_Go_UFDC", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_Go_UFDC");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_Go_UFDC;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_FDA_Report_Reader
        {
            set
            {
                Add_Setting("Toolbox_Show_FDA_Report_Reader", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_FDA_Report_Reader");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_FDA_Report_Reader;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_QC
        {
            set
            {
                Add_Setting("Toolbox_Show_QC", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_QC");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_QC;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_PreQC
        {
            set
            {
                Add_Setting("Toolbox_Show_PreQC", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_PreQC");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_PreQC;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_METS_Editor
        {
            set
            {
                Add_Setting("Toolbox_Show_METS_Editor", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_METS_Editor");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_METS_Editor;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_Tracking
        {
            set
            {
                Add_Setting("Toolbox_Show_Tracking", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_Tracking");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_Tracking;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_Importer
        {
            set
            {
                Add_Setting("Toolbox_Show_Importer", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_Importer");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_Importer;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_CD_Manager
        {
            set
            {
                Add_Setting("Toolbox_Show_CD_Manager", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_CD_Manager");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_CD_Manager;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_CD_Indexer
        {
            set
            {
                Add_Setting("Toolbox_Show_CD_Indexer", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_CD_Indexer");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_CD_Indexer;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_UFDC_Manager
        {
            set
            {
                Add_Setting("Toolbox_Show_UFDC_Manager", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_UFDC_Manager");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_UFDC_Manager;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_Drive_Lister
        {
            set
            {
                Add_Setting("Toolbox_Show_Drive_Lister", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_Drive_Lister");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_Drive_Lister;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        public static bool Toolbox_Show_Aerials_Database
        {
            set
            {
                Add_Setting("Toolbox_Show_Aerials", value.ToString().ToUpper());
            }
            get
            {
                string curr_value = Get_String_Setting("Toolbox_Show_Aerials");
                if (curr_value.Length == 0)
                    return Toolbox_Allow_Aerials_Database;
                else
                {
                    if (curr_value.ToUpper().Equals("FALSE"))
                        return false;
                    else
                        return true;
                }
            }
        }

        #endregion

        /// <summary> Flag is used in the dLOC Toolkit to specify if this user has a preference
        /// for moving or copying the files or has not specified </summary>
        public static Move_Or_Copy Move_Or_Copy_Files
        {
            get
            {
                string ftp_method_string = Get_String_Setting("Move_Or_Copy_Files").ToUpper();
                switch (ftp_method_string)
                {
                    case "COPY":
                        return Move_Or_Copy.COPY;

                    case "MOVE":
                        return Move_Or_Copy.MOVE;

                    default:
                        return Move_Or_Copy.UNDEFINED;
                }
            }
            set
            {
                switch (value)
                {
                    case Move_Or_Copy.COPY:
                        Add_Setting("Move_Or_Copy_Files", "COPY");
                        break;

                    case Move_Or_Copy.MOVE:
                        Add_Setting("Move_Or_Copy_Files", "MOVE");
                        break;

                    case Move_Or_Copy.UNDEFINED:
                        Add_Setting("Move_Or_Copy_Files", "UNDEFINED");
                        break;
                }
            }
        }

        public static FTP_Method_Enum FTP_Method
        {
            get
            {
                string ftp_method_string = Get_String_Setting("FTP_Method").ToUpper();
                switch (ftp_method_string)
                {
                    case "ORIGINAL":
                        return FTP_Method_Enum.Original_FTP;

                    case "NATIVE":
                        return FTP_Method_Enum.Native_FTP;

                    default:
                        return FTP_Method_Enum.Secure_FTP;
                }
            }
            set
            {
                switch (value)
                {
                    case FTP_Method_Enum.Original_FTP:
                        Add_Setting("FTP_Method", "ORIGINAL");
                        break;

                    case FTP_Method_Enum.Native_FTP:
                        Add_Setting("FTP_Method", "NATIVE");
                        break;

                    case FTP_Method_Enum.Secure_FTP:
                        Add_Setting("FTP_Method", "SECURE FTP");
                        break;
                }
            }
        }

        public static void Set_Control_Value(string ControlName, string Field, string Data)
        {
            Add_Setting(ControlName + "." + Field, Data);
        }

        public static string Get_Control_Value(string ControlName, string Field)
        {
            return Get_String_Setting(ControlName + "." + Field);
        }

        public static Security_Levels_Enum User_Security
        {
            get
            {
                string security_string = Get_String_Setting("User_Security_Level").ToUpper();
                switch (security_string)
                {
                    case "USER":
                        return Security_Levels_Enum.User;
                        
                    case "SUPERVISOR":
                        return Security_Levels_Enum.Supervisor;

                    default:
                        return Security_Levels_Enum.Undetermined;
                }
            }
            set
            {
                switch (value)
                {
                    case Security_Levels_Enum.User:
                        Add_Setting("User_Security_Level", "USER");
                        break;

                    case Security_Levels_Enum.Supervisor:
                        Add_Setting("User_Security_Level", "SUPERVISOR");
                        break;

                    case Security_Levels_Enum.Undetermined:
                        Add_Setting("User_Security_Level", "");
                        break;
                }
            }
        }

        public static void Clear_Drives()
        {
            Setting_DataSet.Tables[1].Clear();
        }

        public static bool Drive_Descriptor_Exists( string Descriptor )
        {
            DataRow[] existing = Setting_DataSet.Tables[1].Select("Drive_Descriptor = '" + Descriptor + "'");
            if (existing.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable Drive_Table
        {
            get
            {
                return Setting_DataSet.Tables[1];
            }
        }

        public static void Set_Drive_Always_Copy(string Drive_Descriptor, bool Always_Copy)
        {
            DataRow[] existing = Setting_DataSet.Tables[1].Select("Drive_Descriptor = '" + Drive_Descriptor + "'");
            if (existing.Length > 0)
            {
                existing[0]["Always_Copy"] = Always_Copy;
            }
        }

        public static void Add_Drive(string Drive_Descriptor, string Base_Directory, ArrayList PreQC_Directories,  string QC_Directory,
            string OCR_Directory, string Load_Directory, string Error_Directory, string Archive_Directory, bool isActive, bool Locked, bool Always_Copy )
        {
            // Build the preqc directory text string
            StringBuilder builder = new StringBuilder();
            foreach (string preqcdir in PreQC_Directories)
            {
                if (builder.Length > 0)
                {
                    builder.Append("|" + preqcdir);
                }
                else
                {
                    builder.Append(preqcdir);
                }
            }

            // Is this an edit or new?
            DataRow[] existing = Setting_DataSet.Tables[1].Select("Drive_Descriptor = '" + Drive_Descriptor + "'");
            if (existing.Length > 0)
            {
                existing[0]["Drive_Descriptor"] = Drive_Descriptor;
                existing[0]["Base_Directory"] = Base_Directory;
                existing[0]["PreQC_Directories"] = builder.ToString();
                existing[0]["QC_Directory"] = QC_Directory;
                existing[0]["OCR_Directory"] = OCR_Directory;
                existing[0]["Load_Directory"] = Load_Directory;
                existing[0]["Error_Directory"] = Error_Directory;
                existing[0]["Archive_Directory"] = Archive_Directory;
                existing[0]["is_Active"] = isActive;
                existing[0]["Locked"] = Locked;
                existing[0]["Always_Copy"] = Always_Copy;
            }
            else
            {
                // Add this data
                DataRow newRow = Setting_DataSet.Tables[1].NewRow();
                newRow["Drive_Descriptor"] = Drive_Descriptor;
                newRow["Base_Directory"] = Base_Directory;
                newRow["PreQC_Directories"] = builder.ToString();
                newRow["QC_Directory"] = QC_Directory;
                newRow["OCR_Directory"] = OCR_Directory;
                newRow["Load_Directory"] = Load_Directory;
                newRow["Error_Directory"] = Error_Directory;
                newRow["Archive_Directory"] = Archive_Directory;
                newRow["is_Active"] = isActive;
                newRow["Locked"] = Locked;
                newRow["Always_Copy"] = Always_Copy;
                Setting_DataSet.Tables[1].Rows.Add(newRow);
            }
        }

        public static int Source_Drive_Count
        {
            get
            {
                return Setting_DataSet.Tables[1].Rows.Count;
            }
        }

        /// <summary> Save the individual user settings </summary>
        public static void Save()
		{
			string selected_color = Selected_Color.ToString();

			// Ask the base class to save the data
			Write_XML_File( fileName );
		}

        public static bool Show_QC_Splash_Screen
        {
            set
            {
                Add_Setting("Show_QC_Splash_Screen", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("Show_QC_Splash_Screen").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static bool SIEF_GridLines
        {
            set
            {
                Add_Setting("SIEF_GridLines", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_GridLines").Equals("TRUE"))
                    return true;
                else
                    return false;
            }
        }

        public static bool SIEF_Rulers
        {
            set
            {
                Add_Setting("SIEF_Rulers", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_Rulers").Equals("TRUE"))
                    return true;
                else
                    return false;
            }
        }

        public static string SIEF_Units
        {
            set
            {
                Add_Setting("SIEF_Units", value.ToUpper());
            }
            get
            {
                return Get_String_Setting("SIEF_Units").ToUpper();
            }
        }

        public static Point SIEF_Navigation_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_Navigation_X"), Get_Int_Setting("SIEF_Navigation_Y"));
            }
            set
            {
                Add_Setting("SIEF_Navigation_X", value.X);
                Add_Setting("SIEF_Navigation_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_Navigation_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_Navigation_Panel");
            }
            set
            {
                Add_Setting("SIEF_Navigation_Panel", (int) value );
            }
        }

        public static bool SIEF_Navigation_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_Navigation_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_Navigation_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static Point SIEF_PageName_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_PageName_X"), Get_Int_Setting("SIEF_PageName_Y"));
            }
            set
            {
                Add_Setting("SIEF_PageName_X", value.X);
                Add_Setting("SIEF_PageName_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_PageName_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_PageName_Panel");
            }
            set
            {
                Add_Setting("SIEF_PageName_Panel", (int)value);
            }
        }

        public static bool SIEF_PageName_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_PageName_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_PageName_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static Point SIEF_PageTools_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_PageTools_X"), Get_Int_Setting("SIEF_PageTools_Y"));
            }
            set
            {
                Add_Setting("SIEF_PageTools_X", value.X);
                Add_Setting("SIEF_PageTools_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_PageTools_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_PageTools_Panel");
            }
            set
            {
                Add_Setting("SIEF_PageTools_Panel", (int)value);
            }
        }

        public static bool SIEF_PageTools_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_PageTools_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_PageTools_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static Point SIEF_NextPage_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_NextPage_X"), Get_Int_Setting("SIEF_NextPage_Y"));
            }
            set
            {
                Add_Setting("SIEF_NextPage_X", value.X);
                Add_Setting("SIEF_NextPage_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_NextPage_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_NextPage_Panel");
            }
            set
            {
                Add_Setting("SIEF_NextPage_Panel", (int)value);
            }
        }

        public static bool SIEF_NextPage_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_NextPage_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_NextPage_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static Point SIEF_PreviousPage_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_PreviousPage_X"), Get_Int_Setting("SIEF_PreviousPage_Y"));
            }
            set
            {
                Add_Setting("SIEF_PreviousPage_X", value.X);
                Add_Setting("SIEF_PreviousPage_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_PreviousPage_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_PreviousPage_Panel");
            }
            set
            {
                Add_Setting("SIEF_PreviousPage_Panel", (int)value);
            }
        }

        public static bool SIEF_PreviousPage_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_PreviousPage_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_PreviousPage_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static Point SIEF_EditTools_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_EditTools_X"), Get_Int_Setting("SIEF_EditTools_Y"));
            }
            set
            {
                Add_Setting("SIEF_EditTools_X", value.X);
                Add_Setting("SIEF_EditTools_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_EditTools_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_EditTools_Panel");
            }
            set
            {
                Add_Setting("SIEF_EditTools_Panel", (int)value);
            }
        }

        public static bool SIEF_EditTools_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_EditTools_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_EditTools_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

                public static Point SIEF_MainButtons_Toolbar_Location
        {
            get
            {
                return new Point(Get_Int_Setting("SIEF_MainButtons_X"), Get_Int_Setting("SIEF_MainButtons_Y"));
            }
            set
            {
                Add_Setting("SIEF_MainButtons_X", value.X);
                Add_Setting("SIEF_MainButtons_Y", value.Y);
            }
        }

        public static Toolstrip_Container_Panel SIEF_MainButtons_Toolbar_Panel
        {
            get
            {
                return (Toolstrip_Container_Panel)Get_Int_Setting("SIEF_MainButtons_Panel");
            }
            set
            {
                Add_Setting("SIEF_MainButtons_Panel", (int)value);
            }
        }

        public static bool SIEF_MainButtons_Toolbar_Visible
        {
            set
            {
                Add_Setting("SIEF_MainButtons_Visible", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("SIEF_MainButtons_Visible").Equals("FALSE"))
                    return false;
                else
                    return true;
            }
        }

        public static bool Use_QC_Final_Option
        {
            set
            {
                Add_Setting("Use_QC_Final_Option", value.ToString().ToUpper() );
            }
            get
            {
                if (Get_String_Setting("Use_QC_Final_Option").Equals("TRUE"))
                    return true;
                else
                    return false;	
            }
        }

        public static bool Show_QC_Final_Packages
        {
            set
            {
                Add_Setting("Show_QC_Final_Packages", value.ToString().ToUpper());
            }
            get
            {
                if (Get_String_Setting("Show_QC_Final_Packages").Equals("TRUE"))
                    return true;
                else
                    return false;
            }
        }

		/// <summary> Gets and sets the Language ID to use for this application </summary>
		public static int Language
		{
			set	{	Add_Setting( "Language", value );		}
			get	{	return Convert.ToInt16( Get_String_Setting( "Language" ));		}
		}

        public static DLC.Tools.Language.Languages Language_Enum
        {
            get
            {
                //string LanguageString = Get_String_Setting("Language");
                //if (LanguageString.Length == 0)
                //    LanguageString = "1";
                int LanguageInt = Convert.ToInt16(Get_String_Setting("Language"));
                if (LanguageInt == 2)
                    return DLC.Tools.Language.Languages.French;
                if (LanguageInt == 3)
                    return DLC.Tools.Language.Languages.Spanish;
                return DLC.Tools.Language.Languages.English;
            }
            set
            {
                switch (value)
                {
                    case DLC.Tools.Language.Languages.English:
                        Add_Setting("Language", 1);
                        break;

                    case DLC.Tools.Language.Languages.French:
                        Add_Setting("Language", 2);
                        break;

                    case DLC.Tools.Language.Languages.Spanish:
                        Add_Setting("Language", 3);
                        break;

                    default:
                        Add_Setting("Language", 1);
                        break;
                }
            }
        }

		/// <summary> Gets and sets the flag that indicates if the divisions which
		/// can carry a name should be named.   </summary>
		public static bool Name_Divisions
		{
			set	{	Add_Setting( "Name_Divisions", value.ToString().ToUpper() );		}
			get	
			{
				if ( Get_String_Setting( "Name_Divisions" ).Equals("TRUE") )
					return true;
				else
					return false;		
			}
		}

		///<summary> Gets and sets the color to use for the background on the main
		/// image panel. </summary>
		public static Color Background_Color
		{
			set	{	Add_Setting( "Background_Color", value.ToString().Replace("[","").Replace("]","").Replace("Color","").Replace(" ",""));		}
			get
			{
				try
				{
					return Color.FromName( Get_String_Setting("Background_Color") );
				}
				catch
				{
					return Color.White;
				}
			}
		}

		///<summary> Gets and sets the color to use for the background color to use
		///for each page on the main image panel. </summary>
		public static Color Page_Color
		{
			set	{	Add_Setting( "Page_Color", value.ToString().Replace("[","").Replace("]","").Replace("Color","").Replace(" ","") );		}
			get
			{
				try
				{
					return Color.FromName( Get_String_Setting("Page_Color") );
				}
				catch
				{
					return Color.LightSteelBlue;
				}
			}
		}

		///<summary> Gets and sets the color to use for the text related to
		///a single page on the main image panel </summary>
		public static Color Text_Color
		{
			set	
			{	
				if (( value.A == Custom_Black.A ) && ( value.B == Custom_Black.B ) && ( value.G == Custom_Black.G ) && ( value.R == Custom_Black.R ))
                    Add_Setting( "Text_Color", "CustomBlack" );		
				else
					Add_Setting( "Text_Color", value.ToString().Replace("[","").Replace("]","").Replace("Color","").Replace(" ","") );	
			}
			get
			{
				string colorName = Get_String_Setting("Text_Color");
				if ( colorName.ToUpper() == "CUSTOMBLACK" )
				{
					return Custom_Black;
				}

				try
				{
					return Color.FromName( Get_String_Setting("Text_Color") );
				}
				catch
				{
					return Custom_Black;
				}
			}
		}

		///<summary> Gets and sets the color to use for the background on the main
		/// image panel for a selected page. </summary>
		public static Color Selected_Color
		{
			set	{	Add_Setting( "Selected_Color", value.ToString().Replace("[","").Replace("]","").Replace("Color","").Replace(" ","") );		}
			get
			{
				try
				{
					return Color.FromName( Get_String_Setting("Selected_Color") );
				}
				catch
				{
					return Color.Gold;
				}
			}
		}


		/// <summary> Gets and sets the flag which indicates if approval is needed for 
		/// automating adobe </summary>
		public static bool Approval_Reqd_For_Adobe
		{
			set	{	Add_Setting( "Approval_Reqd", value.ToString().ToUpper() );		}
			get	
			{
				if ( Get_String_Setting( "Approval_Reqd" ).Equals("TRUE") )
					return true;
				else
					return false;			
			}
		}


		/// <summary> Gets and sets the flag which indicates if autocropping should occur
		/// automatically when rotating images small angles. </summary>
		public static bool Autocrop
		{
			set	{	Add_Setting( "Autocrop", value.ToString().ToUpper() );		}
			get	
			{
				if ( Get_String_Setting( "Autocrop" ).Equals("TRUE") )
					return true;
				else
					return false;		
			}
		}

		/// <summary> Gets and sets the last rotation angle used </summary>
		public static double Last_Rotation_Angle
		{
			set	{	Add_Setting( "Last_Rotation", value.ToString() );		}
			get	{	return Convert.ToDouble( Get_String_Setting( "Last_Rotation" ));		}
		}

		/// <summary> Gets and sets the last rotation angle used </summary>
		public static string Role
		{
			set	{	Add_Setting( "Role", value );		}
			get	{	return Get_String_Setting( "Role" );		}
		}

		public static string Default_Action_On_Save
		{
			set	{	Add_Setting( "Default_Action_On_Save", value );	}
			get	{	return Get_String_Setting("Default_Action_On_Save" );	}
		}

		public static int Corner_Arch
		{
			set	{	Add_Setting( "Corner_Arch", value );		}
			get	
            {
                string asString = Get_String_Setting("Corner_Arch");
                if (asString.Length == 0)
                {
                    return 10;
                }
                else
                {
                    try
                    {
                        return Convert.ToInt32(Get_String_Setting("Corner_Arch"));
                    }
                    catch
                    {
                        return 10;
                    }
                }
            }
		}

		public static int Thumbnail_Size
		{
			set	{	Add_Setting( "Thumbnail_Size", value );		}
			get	
			{	
				try
				{
					return Convert.ToInt32( Get_String_Setting( "Thumbnail_Size" ));		
				}
				catch
				{
					return 2;
				}
			}
		}

		public static Size Main_Form_Size
		{
			set	
			{	
				Add_Setting( "Main_Form_Height", Math.Max( value.Height - 20, 50 ) );		
				Add_Setting( "Main_Form_Width", value.Width );
			}
			get	
			{	
				int height = Convert.ToInt32( Get_String_Setting( "Main_Form_Height" ));	
				int width = Convert.ToInt32( Get_String_Setting( "Main_Form_Width" ));	
				return new Size( width, height );
			}
		}

        public static Size Toolbox_Size
        {
            set
            {
                Add_Setting("Toolbox_Height", Math.Max(value.Height - 20, 50));
                Add_Setting("Toolbox_Width", value.Width);
            }
            get
            {
                int height = Convert.ToInt32(Get_String_Setting("Toolbox_Height"));
                int width = Convert.ToInt32(Get_String_Setting("Toolbox_Width"));
                return new Size(width, height);
            }
        }

        public static bool Toolbox_Workflow_Order
        {
            get
            {
                if ( Get_String_Setting("Toolbox_Workflow_Order") == "FALSE" )
                    return false;
                else
                    return true;
            }
            set
            {
                Add_Setting("Toolbox_Workflow_Order", value.ToString().ToUpper());
            }
        }


        /// <summary> Gets or sets the flag to indicate that processing should stop 
        /// when the first error is encountered. </summary>
        public static bool Stop_For_Errors
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(Get_String_Setting("Stop_For_Errors"));
                }
                catch
                {
                    Add_Setting("Stop_For_Errors", "TRUE");
                    return true;
                }
            }
            set
            {
                Add_Setting("Stop_For_Errors", value.ToString().ToUpper());
            }
        }

        public static bool Retain_Detailed_PreQC_Logs
        {
            get
            {
                string value = Get_String_Setting("Retain_Detailed_PreQC_Logs");

                if (value.Length == 0)
                    return false;
                else
                {
                    try
                    {
                        return Convert.ToBoolean(value);
                    }
                    catch
                    {
                        Add_Setting("Retain_Detailed_PreQC_Logs", "FALSE");
                        return false;
                    }
                }
            }
            set
            {
                Add_Setting("Retain_Detailed_PreQC_Logs", value.ToString().ToUpper());
            }
        }

        /// <summary> Gets and sets the type of software to use to create derivatives </summary>
        public static Derivative_Creation_Software Derivative_Software
        {
            get
            {
                string stringValue = Get_String_Setting("Derivative_Software").ToUpper();
                switch (stringValue)
                {
                    case "IMAGEMAGICK":
                        return Derivative_Creation_Software.ImageMagick;

                    case "PHOTOSHOP_CS":
                        return Derivative_Creation_Software.Photoshop_CS;

                    case "AURIGMA":
                        return Derivative_Creation_Software.Aurigma;

                    default:
                        return Derivative_Creation_Software.None;
                }
            }
            set
            {
                switch (value)
                {
                    case Derivative_Creation_Software.ImageMagick:
                        Add_Setting("Derivative_Software", "ImageMagick");
                        break;

                    case Derivative_Creation_Software.Photoshop_CS:
                        Add_Setting("Derivative_Software", "Photoshop_CS");
                        break;

                    case Derivative_Creation_Software.None:
                        Add_Setting("Derivative_Software", "None");
                        break;

                    case Derivative_Creation_Software.Aurigma:
                        Add_Setting("Derivative_Software", "AURIGMA");
                        break;
                }
            }
        }

        /// <summary> Gets and sets the type of software to use to create derivatives </summary>
        public static Derivative_Creation_Software JPEG2000_Derivative_Software
        {
            get
            {
                string stringValue = Get_String_Setting("JPEG2000_Software").ToUpper();
                switch (stringValue)
                {
                    case "KAKADU":
                        return Derivative_Creation_Software.Kakadu;

                    default:
                        return Derivative_Creation_Software.Kakadu;
                }
            }
            set
            {
                switch (value)
                {
                    case Derivative_Creation_Software.Kakadu:
                        Add_Setting("Derivative_Software", "Kakadu");
                        break;

                    default:
                        Add_Setting("Derivative_Software", "Kakadu");
                        break;
                }
            }
        }

        public static bool Show_FTP_File_Progress
        {
            get
            {
                string value = Get_String_Setting("Show_File_FTP_Progress");
                if (Get_String_Setting("Show_File_FTP_Progress") == "TRUE")
                    return true;
                else
                    return false;
            }
            set
            {
                Add_Setting("Show_File_FTP_Progress", value.ToString().ToUpper());
                Write_XML_File("Go_UFDC");
            }
        }

        public static bool Enrich_From_PMETS
        {
            get
            {
                if (Get_String_Setting("Enrich_from_PMETS") == "FALSE")
                    return false;
                else
                    return true;
            }
            set
            {
                Add_Setting("Enrich_from_PMETS", value.ToString().ToUpper());
                Write_XML_File("Go_UFDC");
            }
        }

        public static bool Move_Files
        {
            get
            {
                if (Get_String_Setting("Move_Files") == "FALSE")
                    return false;
                else
                    return true;
            }
            set
            {
                Add_Setting("Move_Files", value.ToString().ToUpper());
                Write_XML_File("Go_UFDC");
            }
        }

        public static string Last_Go_UFDC_Directory
        {
            get
            {
                return Get_String_Setting("Last_Go_UFDC_Directory");
            }
            set
            {
                Add_Setting("Last_Go_UFDC_Directory", value);
            }
        }
	}
}
