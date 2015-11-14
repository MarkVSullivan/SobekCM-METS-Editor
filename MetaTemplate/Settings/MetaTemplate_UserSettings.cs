#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using DLC.Tools;
using DLC.Tools.StartUp;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.MARC;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    /// <summary> Enumeration controls the type of bibliographic sections to include in the METS file </summary>
    public enum Bibliographic_Metadata_Enum
    {
        /// <summary> Unknown, or un-analyzed, default </summary>
        UNKNOWN = -1,

        /// <summary> Simplified Dublin Core </summary>
        DublinCore = 1,

        /// <summary> Marc21 Slim XML Metadata Format  </summary>
        MarcXML,

        /// <summary> Metadata Object and Descriptive Standard Format </summary>
        MODS

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

	/// <summary> Class provides access to th.  user settings, preferences, and information
    /// about the previous runs of the SobekCM METS Editor and Viewer. </summary>
    /// <remarks> This class stores all of the user information as XML within the
    /// Isolated Storage section of the windows machine upon which it runs </remarks>
	public class MetaTemplate_UserSettings : IS_UserSettings
	{
        /// <summary> Flag indicates this was the first launch for this user and a default user 
        /// setting file was created. </summary>
        public static bool First_Launch;

	    /// <summary> Name of the XML file used to store the QC settings </summary>
	    private const string SETTINGS_FILENAME = "MetaTemplate_UserSettings";

	    // Some defaulta
	    private const int DEFAULT_IMAGE_HEIGHT = 1000;
	    private const int DEFAULT_IMAGE_WIDTH = 630;
	    private const int DEFAULT_IMAGE_THUMBNAIL_HEIGHT = 300;
	    private const int DEFAULT_IMAGE_THUMBNAIL_WIDTH = 150;

	    // List values, to prevent multiple string parsings
        private static List<string> addons;
        private static List<string> sobekcmAggregations;
        private static List<string> sobekcmWebskins;
        private static List<string> sobekcmWordmarks;
        private static List<string> sobekcmViewers;
        private static List<string> metsRecordstatusList;
        private static List<Aggregation_Info> institutionsList;
        private static List<Material_Type_Setting> materialTypesList;

        // List of Z39.50 endpoints
        private static List<Z3950_Endpoint> z3950_endpoints;

		static MetaTemplate_UserSettings()
		{
            Automatic_Numbering = Automatic_Numbering_Enum.Document;

            z3950_endpoints = new List<Z3950_Endpoint>();

			Load();
        }

        /// <summary> Last Z39.50 endpoint used for importing a record </summary>
        public static string Last_Z3950_Endpoint
        {
            get
            {
                return Get_String_Setting("Last_Z3950_Endpoint");
            }
            set
            {
                Add_Setting("Last_Z3950_Endpoint", value);
            }
        }

        /// <summary> Location and file for the currently installed instance of ImageMagick, used for
        /// creating image derivative files </summary>
        public static string ImageMagick_Executable
        {
            get
            {
                return Get_String_Setting("ImageMagick_Executable");
            }
            set
            {
                Add_Setting("ImageMagick_Executable", value);
            }
        }


        /// <summary> Flag indicates if the user wishes to perform version check each time
        /// the application is launched </summary>
        public static bool Perform_Version_Check_On_StartUp
        {
            get
            {
                return Get_Boolean_Setting("Perform_Version_Check_On_StartUp", true );
            }
            set
            {
                Add_Setting("Perform_Version_Check_On_StartUp", value);
            }
        }

        /// <summary> Default METS save directory, used when a METS file is created w/o directory info </summary>
        public static string METS_Save_Directory
        {
            get
            {
                return Get_String_Setting("METS_Save_Directory");
            }
            set
            {
                Add_Setting("METS_Save_Directory", value);
            }
        }
        

        /// <summary> Flag indicates if the user would like to view the generated METS file for any 
        /// saved digital resource </summary>
        public static bool Show_Metadata_PostSave
        {
            get
            {
                return Get_Boolean_Setting("Show_Metadata_PostSave", false );
            }
            set
            {
                Add_Setting("Show_Metadata_PostSave", value);
            }
        }

        /// <summary> Gets the last OAI-PMH repository URL used for batch importing </summary>
        public static string Last_OAI_URL
        {
            get
            {
                return Get_String_Setting("Last_OAI_URL");
            }
            set
            {
                Add_Setting("Last_OAI_URL", value);
            }
        }

        /// <summary> Last template preference as indicated through the user interface </summary>
        public static string Default_Template
        {
            get
            {
                return Get_String_Setting("Template");
            }
            set
            {
                Add_Setting("Template", value);
            }
        }

        /// <summary> Last project ( or default metadata to use when creating a digital resource
        /// from scratch ) selected through the user interface </summary>
        public static string Current_Project
        {
            get
            {
                return Get_String_Setting("Project");
            }
            set
            {
                Add_Setting("Project", value);
            }
        }

        /// <summary> Last selection for the type of metadata encoding to use to encode the 
        /// bulk of the bibliographic metadata for a digital resource </summary>
        public static Bibliographic_Metadata_Enum Bibliographic_Metadata
        {
            get
            {
                int currentSetting = Get_Int_Setting("Bibliographic_Metadata");
                switch (currentSetting)
                {
                    case 1:
                        return Bibliographic_Metadata_Enum.DublinCore;
                       
                    case 2:
                        return Bibliographic_Metadata_Enum.MarcXML;

                    case 3:
                        return Bibliographic_Metadata_Enum.MODS;

                    default:
                        return Bibliographic_Metadata_Enum.MODS;
                }
            }
            set
            {
                Add_Setting("Bibliographic_Metadata", (int)value);
            }
        }


        /// <summary> Flag indicates if existing page images should always be added automatically when 
        /// creating a new METS in a folder which has page image files </summary>
        public static bool Always_Add_Page_Images
        {
            get
            {
                return Get_Boolean_Setting("Always_Add_Page_Images", false);
            }
            set
            {
                Add_Setting("Always_Add_Page_Images", value);
            }
        }

        /// <summary> Flag indicates if existing nono-page image files should always be added automatically when 
        /// creating a new METS in a folder which has page image files </summary>
        public static bool Always_Add_NonPage_Files
        {
            get
            {
                return Get_Boolean_Setting("Always_Add_NonPage_Files", false);
            }
            set
            {
                Add_Setting("Always_Add_NonPage_Files", value);
            }
        }


        /// <summary> Flag indicates if the system should always recurse through subfolders to find files
        /// to add to a new digital resource  </summary>
        public static bool Always_Recurse_Through_Subfolders_On_New
        {
            get
            {
                return Get_Boolean_Setting("Always_Recurse_Through_Subfolders_On_New", false);
            }
            set
            {
                Add_Setting("Always_Recurse_Through_Subfolders_On_New", value);
            }
        }

        /// <summary> Flag indicates if the system should place files with the same root, but different subfolders,
        /// into the same page division by default </summary>
        public static bool Page_Images_In_Seperate_Folders_Can_Be_Same_Page
        {
            get
            {
                return Get_Boolean_Setting("Page_Images_In_Seperate_Folders_Can_Be_Same_Page", false);
            }
            set
            {
                Add_Setting("Page_Images_In_Seperate_Folders_Can_Be_Same_Page", value);
            }
        }

        /// <summary> Flag indicates if checksums should be calculated and included in the resulting
        /// METS files generated by this application </summary>
        public static bool Include_Checksums
        {
            get
            {
                return Get_Boolean_Setting("Include_Checksums", true );
            }
            set
            {
                Add_Setting("Include_Checksums", value);
            }
        }

        /// <summary> File extension to use for the resulting METS files when saved from 
        /// this application ( i.e., ".xml" or ".mets" ) </summary>
        public static string METS_File_Extension
        {
            get
            {
                string value = Get_String_Setting("Extension");
                if ( value == ".xml" )
                    return ".xml";
                return ".mets";
            }
            set
            {
                Add_Setting("Extension", value );
            }
        }


        /// <summary> Gets the list of all add ons currently enabled for this user  </summary>
        public static List<string> AddOns_Enabled
        {
            get { return addons ?? (addons = Get_String_Collection_Setting("Add_Ons_Enabled")); }
            set
            {
                addons = value;
                Add_Setting("Add_Ons_Enabled", value);
            }
        }

	    /// <summary> Indicates the type or automatic numbering cascading to occur </summary>
	    /// <remarks> This flag is not stored between launches of the application </remarks>
	    public static Automatic_Numbering_Enum Automatic_Numbering { get; set; }

	    #region Methods for loading, saving and importing, exporting user settings

	    /// <summary> Load the individual user settings </summary>
	    public static void Load()
	    {
	        try
	        {


	        // Try to read the XML file from isolated storage
	        Read_XML_File(SETTINGS_FILENAME);

	        // Make sure this contains one setting. If not, set them to default
	        if (Get_String_Setting("Settings_Version") != "1.1")
	        {
	            // Add the defaults
	            First_Launch = true;
	            Add_Setting("Language", 1);
	            Add_Setting("Font_Face", "Arial");
	            Add_Setting("Font_Size", "Medium");
	            Add_Setting("Width", "700");
	            Add_Setting("Height", "500");
	            Add_Setting("Recent1", "");
	            Add_Setting("Recent2", "");
	            Add_Setting("Recent3", "");
	            Add_Setting("Recent4", "");
	            Add_Setting("Recent5", "");
	            Add_Setting("Template", "");
	            Add_Setting("Help_Source", 0);
	            Add_Setting("Include_FDA", 0);
	            Add_Setting("Include_Checksums", 0);
	            Add_Setting("Include_SobekCM_File", 1);
	            Add_Setting("Extension", ".mets");
	            Add_Setting("Show_Metadata_PostSave", "false");
	            Add_Setting("ImageDeriv_Create_JPEG", 1);
	            Add_Setting("ImageDeriv_Create_JPEG2000", 1);
	            Add_Setting("ImageDeriv_Width", DEFAULT_IMAGE_WIDTH);
	            Add_Setting("ImageDeriv_Height", DEFAULT_IMAGE_HEIGHT);
	            var windowsIdentity = WindowsIdentity.GetCurrent();
	            if (windowsIdentity != null)
	                Add_Setting("Individual_Creator", windowsIdentity.Name);
	            Add_Setting("Default_Rights_Statement", "All rights reserved by the source institution");
	            Add_Setting("METS_RecordStatus_List", "COMPLETE|METADATA_UPDATE|PARTIAL");

	            // Add the MODS types as default
	            List<Material_Type_Setting> materialTypes = new List<Material_Type_Setting>
	                                                            {
	                                                                new Material_Type_Setting("text", "text", ""),
	                                                                new Material_Type_Setting("cartographic", "cartographic",""),
	                                                                new Material_Type_Setting("notated music", "notated music",""),
	                                                                new Material_Type_Setting("sound recording","sound recording", ""),
	                                                                new Material_Type_Setting("sound recording-musical","sound recording-musical", ""),
	                                                                new Material_Type_Setting("sound recording-nonmusical","sound recording-nonmusical", ""),
	                                                                new Material_Type_Setting("still image", "still image", ""),
                                                                    new Material_Type_Setting("moving image", "moving image",""),
	                                                                new Material_Type_Setting("three dimensional object","three dimensional object", ""),
	                                                                new Material_Type_Setting("software, multimedia","software, multimedia", ""),
	                                                                new Material_Type_Setting("mixed material","mixed material", "")
	                                                            };
	            Material_Types_List = materialTypes;
	        }

	        // May not have these settings added later
	        if (Get_String_Setting("Always_Add_Page_Images").Length == 0)
	            Add_Setting("Always_Add_Page_Images", "FALSE");

            // Load the list of Z39.50 endpoints
            if (dsSettings.Tables.Contains("Z3950_Endpoints"))
            {
                // Get information from unencrypting the passwords
                SecurityInfo securityInfo = new SecurityInfo();
                string machine_name = (Environment.MachineName + "abcedefgh").Substring(0, 8);
                string user = (Environment.UserName.Replace("\\", "").Replace("//", "") + "abcedefgh").Substring(0, 8);

                // Step through each row in the Z39.50 endpoints 
                foreach (DataRow thisRow in dsSettings.Tables["Z3950_Endpoints"].Rows)
                {
                    // Pull out the information about this endpoint
                    string name = thisRow["Name"].ToString();
                    string uri = thisRow["URI"].ToString();
                    uint port = 0;
                    UInt32.TryParse(thisRow["Port"].ToString(), out port);
                    string db_name = thisRow["Database_Name"].ToString();
                    string username = thisRow["UserName"].ToString();
                    string encrypted_password = thisRow["Password"].ToString();
                    string password = String.Empty;
                    if (encrypted_password.Length > 0)
                    {
                        try
                        {
                            string unencrypted_password = securityInfo.DecryptString(encrypted_password, machine_name, user);
                            if ((unencrypted_password.Length > 0) && (unencrypted_password[0] == 'x') && (unencrypted_password[unencrypted_password.Length - 1] == 'x'))
                            {
                                password = unencrypted_password.Substring(1, unencrypted_password.Length - 2);

                            }
                        }
                        catch (Exception ee)
                        {
                            bool error = false;
                        }
                    }

                    // Create the new endpoint 
                    Z3950_Endpoint endpoint = new Z3950_Endpoint(name, uri, port, db_name, username);
                    if (password.Length > 0)
                    {
                        endpoint.Password = password;
                        endpoint.Save_Password_Flag = true;
                    }

                    // Add this to the list of endpoints
                    z3950_endpoints.Add(endpoint);
                }
            }
            else
            {
                // Just add the empty table
                DataTable zTable = new DataTable("Z3950_Endpoints");
                zTable.Columns.Add("Name");
                zTable.Columns.Add("URI");
                zTable.Columns.Add("Port");
                zTable.Columns.Add("Database_Name");
                zTable.Columns.Add("UserName");
                zTable.Columns.Add("Password");
                dsSettings.Tables.Add(zTable);
            }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR CAUGHT IN META TEMPLATE SETTINGS READ: " + ee.Message + "\n\n" + ee.StackTrace);
            }
	    }


	    /// <summary> Save the individual user settings </summary>
	    public static void Save()
	    {
	        // If this is the save after first launch, then include the new version number
	        if (First_Launch)
	        {
	            Add_Setting("Settings_Version", "1.1");
	        }

            // Clear existing Z39.50 endpints from the dataset
            DataTable z3950_table = dsSettings.Tables["Z3950_Endpoints"];
            z3950_table.Rows.Clear();

            // Get information for encrypting the password
            SecurityInfo securityInfo = new SecurityInfo();
            string machine_name = (Environment.MachineName + "abcedefgh").Substring(0, 8);
            string user = (Environment.UserName.Replace("\\", "").Replace("//", "") + "abcedefgh").Substring(0, 8);

            // Copy each endpoint over into the dataset
            foreach (Z3950_Endpoint thisEndpoint in z3950_endpoints)
            {
                DataRow thisRow = z3950_table.NewRow();
                thisRow["Name"] = thisEndpoint.Name;
                thisRow["URI"] = thisEndpoint.URI;
                thisRow["Port"] = thisEndpoint.Port;
                thisRow["Database_Name"] = thisEndpoint.Database_Name;
                thisRow["UserName"] = thisEndpoint.Username;
                if ((thisEndpoint.Save_Password_Flag) && ( thisEndpoint.Password.Length > 0 ))
                {
                    string password = "x" + thisEndpoint.Password + "x";
                    string encrypted_password = securityInfo.EncryptString( password, machine_name, user );
                    thisRow["Password"] = encrypted_password;

                }
                z3950_table.Rows.Add(thisRow);
            }

	        // Ask the base class to save the data
	        Write_XML_File(SETTINGS_FILENAME);
	    }

	    /// <summary> Export the current settings as a XML file </summary>
	    /// <param name="Export_File">File to export the settings to </param>
	    public static void Export_Settings(string Export_File)
	    {
	        // Write the XML file
	        dsSettings.WriteXml(Export_File, XmlWriteMode.WriteSchema);
	    }

        /// <summary> Import settings from a XML file  </summary>
        /// <param name="Import_File"> File to import the settings from </param>
	    public static void Import_Settings(string Import_File)
	    {
	        Read_XML_File(Import_File);
	    }

	    #endregion

	    #region User settings for the user interface options ( language, size, font, etc.. )

	    /// <summary> Gets the help provider information for this application's metadata help  </summary>
	    public static string Help_Provider
	    {
	        get
	        {
	            return Get_String_Setting("Help_Provider");
	        }
	        set
	        {
	            Add_Setting("Help_Provider", value);
	        }
	    }

	    /// <summary> Last language preference indicated for the user interface </summary>
	    public static Template_Language Last_Language
	    {
	        get
	        {
	            int languageInt = Get_Int_Setting("Language");
	            switch (languageInt)
	            {
	                case 2:
	                    return Template_Language.French;
	                case 3:
	                    return Template_Language.Spanish;
	                default:
	                    return Template_Language.English;
	            }
	        }
	        set
	        {
	            switch (value)
	            {
	                case Template_Language.French:
	                    Add_Setting("Language", 2);
	                    break;

	                case Template_Language.Spanish:
	                    Add_Setting("Language", 3);
	                    break;

	                default:
	                    Add_Setting("Language", 1);
	                    break;

	            }
	        }
	    }

	    /// <summary> Size of the main form selected by the user through user interface 
	    /// during the last execution of the application </summary>
	    public static Size Last_Size
	    {
	        get
	        {
	            return new Size(Get_Int_Setting("Width"), Get_Int_Setting("Height"));
	        }
	        set
	        {
	            Add_Setting("Width", value.Width);
	            Add_Setting("Height", value.Height);
	        }
	    }

	    /// <summary> Last font selected for use within the user interface template </summary>
	    public static Font Last_Font
	    {
	        get
	        {
	            float size = 9F;
	            switch (Get_String_Setting("Font_Size").ToUpper())
	            {
	                case "SMALL":
	                    size = 8F;
	                    break;
	                case "MEDIUM":
	                    size = 9F;
	                    break;
	                case "LARGE":
	                    size = 10.5F;
	                    break;
	                case "XLARGE":
	                    size = 12F;
	                    break;
	            }

	            return new Font(Get_String_Setting("Font_Face"), size);
	        }
	        set
	        {
	            string size = "MEDIUM";
	            if (value.Size < 8.75F)
	                size = "SMALL";
	            if (value.Size > 11.0F)
	                size = "XLARGE";
	            if ((value.Size > 9.5F) && (value.Size <= 11.0F))
	                size = "LARGE";

	            Add_Setting("Font_Size", size);
	            Add_Setting("Font_Face", value.FontFamily.Name);

	        }
	    }

	    #endregion

	    #region User settings which retains the last five files edited/created

	    /// <summary> Array of up to five recent files opened through the application </summary>
	    public static string[] Recents
	    {
	        get
	        {
	            // Create a list of the recents
	            ArrayList recents = new ArrayList
	                                    {
	                                        Get_String_Setting("Recent1"),
	                                        Get_String_Setting("Recent2"),
	                                        Get_String_Setting("Recent3"),
	                                        Get_String_Setting("Recent4"),
	                                        Get_String_Setting("Recent5")
	                                    };

	            // Now, return the built array
	            return new[] { recents[0].ToString(), recents[1].ToString(), recents[2].ToString(), recents[3].ToString(), recents[4].ToString() };
	        }
	    }

	    /// <summary> Adds a recently opened file name to be accessed through the 'Recent Files' section
	    /// of the main menu within the application  </summary>
	    /// <param name="NewRecent"> New file to be possibly added to the recent files </param>
	    /// <returns> New array of up to five recent files opened through the application </returns>
	    public static string[] Add_Recent(string NewRecent)
	    {
	        // Create a list of the recents
	        ArrayList recents = new ArrayList
	                                {
	                                    Get_String_Setting("Recent1"),
	                                    Get_String_Setting("Recent2"),
	                                    Get_String_Setting("Recent3"),
	                                    Get_String_Setting("Recent4"),
	                                    Get_String_Setting("Recent5")
	                                };

	        // Insert this one at the beginning
	        recents.Insert(0, NewRecent);

	        // Make sure there are at least five
	        while (recents.Count < 6)
	            recents.Add(String.Empty);

	        // If this new Recent already existed in this list, take it out
	        if (recents[1].ToString() == NewRecent)
	            recents.RemoveAt(1);
	        if (recents[2].ToString() == NewRecent)
	            recents.RemoveAt(2);
	        if ((recents.Count > 3) && (recents[3].ToString() == NewRecent))
	            recents.RemoveAt(3);
	        if ((recents.Count > 4) && (recents[4].ToString() == NewRecent))
	            recents.RemoveAt(4);
	        if ((recents.Count > 5) && (recents[5].ToString() == NewRecent))
	            recents.RemoveAt(5);

	        // Make sure there are at least five
	        while (recents.Count < 5)
	            recents.Add(String.Empty);

	        // Store back into the settings
	        Add_Setting("Recent1", recents[0].ToString());
	        Add_Setting("Recent2", recents[1].ToString());
	        Add_Setting("Recent3", recents[2].ToString());
	        Add_Setting("Recent4", recents[3].ToString());
	        Add_Setting("Recent5", recents[4].ToString());
	        Save();

	        // Now, return the built array
	        return new[] { recents[0].ToString(), recents[1].ToString(), recents[2].ToString(), recents[3].ToString(), recents[4].ToString() };
	    }

	    #endregion

	    #region User settings related to defaults to auto-populate when creating new items

	    /// <summary> Name of the individual creator, to be used in the METS </summary>
	    public static string Individual_Creator
	    {
	        get
	        {
	            return Get_String_Setting("Individual_Creator");
	        }
	        set
	        {
	            Add_Setting("Individual_Creator", value);
	        }
	    }

	    /// <summary> Source institution code to use as the default when a new item is created from scratch </summary>
	    /// <remarks> The source institution is the institution creating the metadata and/or digital resource. </remarks>
	    public static string Default_Source_Code
	    {
	        get
	        {
	            return Get_String_Setting("Default_Source_Code");
	        }
	        set
	        {
	            Add_Setting("Default_Source_Code", value);
	        }
	    }

	    /// <summary> Source institution statement to use as the default when a new item is created from scratch </summary>
	    /// <remarks> The source institution is the institution creating the metadata and/or digital resource. </remarks>
	    public static string Default_Source_Statement
	    {
	        get
	        {
	            return Get_String_Setting("Default_Source_Statement");
	        }
	        set
	        {
	            Add_Setting("Default_Source_Statement", value);
	        }
	    }

	    /// <summary> Default rights statement to be used when creating metadata from scratch </summary>
	    public static string Default_Rights_Statement
	    {
	        get
	        {
	            return Get_String_Setting("Default_Rights_Statement");
	        }
	        set
	        {
	            Add_Setting("Default_Rights_Statement", value);
	        }
	    }

	    /// <summary> Default funding note to be used when creating metadata from scratch </summary>
	    public static string Default_Funding_Note
	    {
	        get
	        {
	            return Get_String_Setting("Default_Funding_Note");
	        }
	        set
	        {
	            Add_Setting("Default_Funding_Note", value);
	        }
	    }

	    #endregion

	    #region User settings related to creating image derivatives

	    /// <summary> Flag indicates if, during image derivative creation, the user
	    /// wishes to create the JPEG images </summary>
	    public static bool ImageDeriv_Create_JPEG
	    {
	        get
	        {
	            return Get_Boolean_Setting("ImageDeriv_Create_JPEG", true);
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Create_JPEG", value);
	        }
	    }

	    /// <summary> Flag indicates if, during image derivative creation, the user
	    /// wishes to create the JPEG2000 images </summary>
	    public static bool ImageDeriv_Create_JPEG2000
	    {
	        get
	        {
	            return Get_Boolean_Setting("ImageDeriv_Create_JPEG2000", true);
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Create_JPEG2000", value);
	        }
	    }


	    /// <summary> Flag indicates if, during image derivative creation, the user
	    /// wishes to create the thumbnail jpeg images </summary>
	    public static bool ImageDeriv_Create_Thumbnail
	    {
	        get
	        {
	            return Get_Boolean_Setting("ImageDeriv_Create_Thumbnail", true);
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Create_Thumbnail", value);
	        }
	    }

	    /// <summary> Width (in pixels) of the JPEG images created during image derivative creation</summary>
	    public static int ImageDeriv_Width
	    {
	        get
	        {
	            int returnValue = Get_Int_Setting("ImageDeriv_Width");
	            return returnValue < 100 ? DEFAULT_IMAGE_WIDTH : returnValue;
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Width", value);
	        }
	    }

	    /// <summary> Height (in pixels) of the JPEG images created during image derivative creation</summary>
	    public static int ImageDeriv_Height
	    {
	        get
	        {
	            int returnValue = Get_Int_Setting("ImageDeriv_Height");
	            return returnValue < 100 ? DEFAULT_IMAGE_HEIGHT : returnValue;
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Height", value);
	        }
	    }


	    /// <summary> Width (in pixels) of the JPEG thumbnail images created during image derivative creation</summary>
	    public static int ImageDeriv_Thumbnail_Width
	    {
	        get
	        {
	            int returnValue = Get_Int_Setting("ImageDeriv_Thumbnail_Width");
	            return returnValue < 30 ? DEFAULT_IMAGE_THUMBNAIL_WIDTH : returnValue;
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Thumbnail_Width", value);
	        }
	    }

	    /// <summary> Height (in pixels) of the JPEG thumbnail images created during image derivative creation</summary>
	    public static int ImageDeriv_Thumbnail_Height
	    {
	        get
	        {
	            int returnValue = Get_Int_Setting("ImageDeriv_Thumbnail_Height");
	            return returnValue < 30 ? DEFAULT_IMAGE_THUMBNAIL_HEIGHT : returnValue;
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Thumbnail_Height", value);
	        }
	    }

	    /// <summary> Directory where the last image derivative creation occurred </summary>
	    public static string ImageDerive_Last_Directory
	    {
	        get
	        {
	            return Get_String_Setting("ImageDeriv_Last_Directory");
	        }
	        set
	        {
	            Add_Setting("ImageDeriv_Last_Directory", value);
	        }
	    }

	    #endregion

	    #region User settings related to defaults for SobekCM Add-On

	    /// <summary> Flag indicates if the SobekCM-specific bibliographic enhancement
	    /// section should be included when writing METS files in the application </summary>
	    public static bool Include_SobekCM_Bib_Section
	    {
	        get
	        {
	            return Get_Boolean_Setting("Include_SobekCM_Bib", false);
	        }
	        set
	        {
	            Add_Setting("Include_SobekCM_Bib", value);
	        }
	    }

	    /// <summary> Flag indicates if the SobekCM_specific file technical information
	    /// section should be included when writing the METS files in this application </summary>
	    public static bool Include_SobekCM_File_Section
	    {
	        get
	        {
	            return Get_Boolean_Setting("Include_SobekCM_File", false);
	        }
	        set
	        {
	            Add_Setting("Include_SobekCM_File", value);
	        }
	    }

	    /// <summary> Gets the list of the default aggregations to add if the SobekCM add-on is enabled  </summary>
	    public static List<string> SobekCM_Aggregations
	    {
	        get { return sobekcmAggregations ?? (sobekcmAggregations = Get_String_Collection_Setting("SobekCM_Aggregations")); }
	        set
	        {
	            sobekcmAggregations = value;
	            Add_Setting("SobekCM_Aggregations", value);
	        }
	    }

	    /// <summary> Gets the list of the default web skins to add if the SobekCM add-on is enabled  </summary>
	    public static List<string> SobekCM_Web_Skins
	    {
	        get { return sobekcmWebskins ?? (sobekcmWebskins = Get_String_Collection_Setting("SobekCM_Web_Skins")); }
	        set
	        {
	            sobekcmWebskins = value;
	            Add_Setting("SobekCM_Web_Skins", value);
	        }
	    }

	    /// <summary> Gets the list of the default wordmarks to add if the SobekCM add-on is enabled  </summary>
	    public static List<string> SobekCM_Wordmarks
	    {
	        get { return sobekcmWordmarks ?? (sobekcmWordmarks = Get_String_Collection_Setting("SobekCM_Wordmarks")); }
	        set
	        {
	            sobekcmWordmarks = value;
	            Add_Setting("SobekCM_Wordmarks", value);
	        }
	    }

	    /// <summary> Gets the list of the default viewers to add if the SobekCM add-on is enabled  </summary>
	    public static List<string> SobekCM_Viewers
	    {
	        get { return sobekcmViewers ?? (sobekcmViewers = Get_String_Collection_Setting("SobekCM_Viewers")); }
	        set
	        {
	            sobekcmViewers = value;
	            Add_Setting("SobekCM_Viewers", value);
	        }
	    }

	    #endregion

	    #region User settings related to defaults for FCLA Add-On

	    /// <summary> FCLA Flag indicates item should be sent to PALMM if the FCLA Add-On is enabled </summary>
	    public static bool FCLA_Flag_PALMM
	    {
	        get
	        {
	            return Get_Boolean_Setting("FCLA_Flag_PALMM", false);
	        }
	        set
	        {
	            Add_Setting("FCLA_Flag_PALMM", value);
	        }
	    }

	    /// <summary> FCLA Flag indicates item should be sent to the Florida Digital Archive (FDA) if the FCLA Add-On is enabled </summary>
	    public static bool FCLA_Flag_FDA
	    {
	        get
	        {
	            return Get_Boolean_Setting("FCLA_Flag_FDA", true);
	        }
	        set
	        {
	            Add_Setting("FCLA_Flag_FDA", value);
	        }
	    }

	    /// <summary> PALMM collection code to be included if the FCLA Add-On is enabled </summary>
	    public static string PALMM_Code
	    {
	        get
	        {
	            return Get_String_Setting("PALMM_Code");
	        }
	        set
	        {
	            Add_Setting("PALMM_Code", value);
	        }
	    }

	    /// <summary> Default established Florida Dark Archive (FDA) account code to be included 
	    /// in the METS if the FDA information should be included </summary>
	    public static string FDA_Account
	    {
	        get
	        {
	            return Get_String_Setting("FDA_Account");
	        }
	        set
	        {
	            Add_Setting("FDA_Account", value);
	        }
	    }

	    /// <summary> Default established Florida Dark Archive (FDA) sub-account code to be 
	    /// included in the METS if the FDA information should be included </summary>
	    public static string FDA_SubAccount
	    {
	        get
	        {
	            return Get_String_Setting("FDA_SubAccount");
	        }
	        set
	        {
	            Add_Setting("FDA_SubAccount", value);
	        }
	    }

	    /// <summary> Default established Florida Dark Archive (FDA) project code to be 
	    /// included in the METS if the FDA information should be included </summary>
	    public static string FDA_Project
	    {
	        get
	        {
	            return Get_String_Setting("FDA_Project");
	        }
	        set
	        {
	            Add_Setting("FDA_Project", value);
	        }
	    }

	    #endregion

	    #region User settings related to controlled vocabularies

	    /// <summary> Gets the list of METS Record Statuses </summary>
	    public static List<string> METS_RecordStatus_List
	    {
	        get {
	            return metsRecordstatusList ?? (metsRecordstatusList = Get_String_Collection_Setting("METS_RecordStatus_List"));
	        }
	        set
	        {
	            metsRecordstatusList = value;
	            Add_Setting("METS_RecordStatus_List", value);
	        }
	    }

	    /// <summary> Gets the list of all institutions in the controlled list </summary>
	    public static List<Aggregation_Info> Institutions_List
	    {
	        get
	        {
	            if (institutionsList == null)
	            {
	                institutionsList = new List<Aggregation_Info>();
	                if (Setting_DataSet.Tables.Count > 1)
	                {
	                    DataView sortedView = new DataView(Setting_DataSet.Tables[1]) {Sort = "Code ASC"};
	                    foreach (DataRowView thisRow in sortedView)
	                    {
	                        institutionsList.Add(new Aggregation_Info(thisRow.Row[0].ToString(), thisRow.Row[1].ToString()));
	                    }
	                }
	            }
	            return institutionsList;
	        }
	        set
	        {
	            institutionsList = value;
	            if ( Setting_DataSet.Tables.Count < 2 )
	            {
	                DataTable institutionTable = new DataTable("Institutions");
	                institutionTable.Columns.Add( "Code");
	                institutionTable.Columns.Add( "Name");
	                Setting_DataSet.Tables.Add( institutionTable );
	            }
	            Setting_DataSet.Tables[1].Clear();
	            foreach( Aggregation_Info thisInstitution in value )
	            {
	                DataRow newRow = Setting_DataSet.Tables[1].NewRow();
	                newRow[0]  = thisInstitution.Code;
	                newRow[1] = thisInstitution.Name;
	                Setting_DataSet.Tables[1].Rows.Add( newRow );
	            }
	        }
	    }

	    /// <summary> Gets the list of all material types in the controlled list </summary>
	    public static List<Material_Type_Setting> Material_Types_List
	    {
	        get
	        {
	            if (materialTypesList == null)
	            {
	                materialTypesList = new List<Material_Type_Setting>();
	                if (Setting_DataSet.Tables.Count > 2)
	                {
	                    DataView sortedView = new DataView(Setting_DataSet.Tables[2]) {Sort = "Display_Name ASC"};
	                    foreach (DataRowView thisRow in sortedView)
	                    {
	                        Material_Type_Setting materialType = new Material_Type_Setting(thisRow.Row[0].ToString(), thisRow.Row[1].ToString(), thisRow.Row[2].ToString());
	                        materialTypesList.Add( materialType );
	                    }
	                }
	            }
	            return materialTypesList;
	        }
	        set
	        {
	            materialTypesList = value;
	            if (Setting_DataSet.Tables.Count < 2)
	            {
	                DataTable institutionTable = new DataTable("Institutions");
	                institutionTable.Columns.Add("Code");
	                institutionTable.Columns.Add("Name");
	                Setting_DataSet.Tables.Add(institutionTable);
	            }
	            if (Setting_DataSet.Tables.Count < 3)
	            {
	                DataTable materialTypeTable = new DataTable("Material_Types");
	                materialTypeTable.Columns.Add("Display_Name");
	                materialTypeTable.Columns.Add("MODS_Type");
	                materialTypeTable.Columns.Add("SobekCM_Genre");
	                Setting_DataSet.Tables.Add(materialTypeTable);
	            }
	            Setting_DataSet.Tables[2].Clear();
	            foreach (Material_Type_Setting thisType in value)
	            {
	                DataRow newRow = Setting_DataSet.Tables[2].NewRow();
	                newRow[0] = thisType.Display_Name;
	                newRow[1] = thisType.MODS_Type;
	                newRow[2] = thisType.SobekCM_Genre;
	                Setting_DataSet.Tables[2].Rows.Add(newRow);
	            }
	        }
	    }

	    #endregion

	    #region User settings related to the batch processing of directories

	    /// <summary> Gets the last selected index for the metadata type selection combo box, or -1, 
	    /// used during directory traversing batch processing </summary>
	    public static int Directory_Batching_Metadata_Type_Index
	    {
	        get
	        {
	            return Get_Int_Setting("Directory_Batching_Metadata_Type_Index");
	        }
	        set
	        {
	            Add_Setting("Directory_Batching_Metadata_Type_Index", value);
	        }
	    }

	    /// <summary> Gets the last metadata filter entered during directory traversing batch processing </summary>
	    public static string Directory_Batching_Metadata_Filter
	    {
	        get
	        {
	            return Get_String_Setting("Directory_Batching_Metadata_Filter");
	        }
	        set
	        {
	            Add_Setting("Directory_Batching_Metadata_Filter", value);
	        }
	    }

	    /// <summary> Gets the last selected source for the METS ObjectID (for non METS source metadata), or -1, 
	    /// used during directory traversing batch processing </summary>
	    public static int Directory_Batching_METS_ObjectID_Index
	    {
	        get
	        {
	            return Get_Int_Setting("Directory_Batching_METS_ObjectID_Index");
	        }
	        set
	        {
	            Add_Setting("Directory_Batching_METS_ObjectID_Index", value);
	        }
	    }

	    #endregion

        #region User settings related to the z39.50 endpoints

        /// <summary> Updates the list of Z39.50 endpoints to either add this new endpoint 
        /// or update an existing endpoint of the same name </summary>
        /// <param name="New_Endpoint"> New or existing endpoint to put in the collection of endpoints </param>
        public static void Add_Z3950_Endpoint(Z3950_Endpoint New_Endpoint)
        {
            // Look for an existing endpoint 
            foreach (Z3950_Endpoint thisEndpoint in z3950_endpoints)
            {
                if (thisEndpoint.Name == New_Endpoint.Name)
                {
                    thisEndpoint.Database_Name = New_Endpoint.Database_Name;
                    thisEndpoint.Port = New_Endpoint.Port;
                    thisEndpoint.URI = New_Endpoint.URI;
                    thisEndpoint.Username = New_Endpoint.Username;
                    if (New_Endpoint.Save_Password_Flag)
                    {
                        thisEndpoint.Password = New_Endpoint.Password;
                        thisEndpoint.Save_Password_Flag = true;
                    }
                    else
                        thisEndpoint.Password = String.Empty;
                    return;
                }
            }

            // Must not be an existing endpoint, so copy this and add the copy
            z3950_endpoints.Add( New_Endpoint.Copy() );
        }

        /// <summary>Returns the collection of arbitrary names assigned by the user to his/her
        /// Z39.50 endpoints </summary>
        public static ReadOnlyCollection<string> Z3950_Endpoint_Names
        {
            get
            {
                List<string> returnValue = new List<string>();
                foreach ( Z3950_Endpoint thisEndpoint in z3950_endpoints )
                    returnValue.Add( thisEndpoint.Name );
                return new ReadOnlyCollection<string>(returnValue);
            }
        }

        /// <summary> Retrieves the information associated with a given endpoint by the arbitrary name
        /// associated by the user with the Z39.50 endpoint information </summary>
        /// <param name="Name">Arbitrary name associated with this Z39.50 endpoint to retrieve</param>
        /// <returns>A copy of the Z39.50 endpoint information</returns>
        public static Z3950_Endpoint Get_Endpoint_By_Name(string Name)
        {
            foreach (Z3950_Endpoint thisEndpoint in z3950_endpoints)
            {
                if (String.Compare(thisEndpoint.Name, Name, true) == 0)
                    return thisEndpoint.Copy();
            }
            return null;
        }

        /// <summary>Delete an existing Z39.50 endpoint from the list of this user's endpoints </summary>
        /// <param name="Name">Arbitrary name associated with this Z39.50 endpoint to delete</param>
        public static void Delete_Z3950_Endpoint(string Name)
        {
            List<Z3950_Endpoint> deletes = new List<Z3950_Endpoint>();
            foreach (Z3950_Endpoint thisEndpoint in z3950_endpoints)
            {
                if (String.Compare(thisEndpoint.Name, Name, true) == 0)
                    deletes.Add(thisEndpoint);
            }
            foreach (Z3950_Endpoint thisEndpoint in deletes)
            {
                z3950_endpoints.Remove(thisEndpoint);
            }
        }

        #endregion

        #region Constants used for code shared between these application and others

        /// <summary> Constant always returns an empty string since this application works 
	    /// outside of a SobekCM library instance.  If the user is running a SobekCM library
	    /// instance, than they should probably be using the SMaRT Tool </summary>
	    public static string SobekCM_Inbound_Folder
	    {
	        get { return String.Empty; }
	    }

	    /// <summary> Constant always returns an empty string since this application works 
	    /// outside of a SobekCM library instance.  If the user is running a SobekCM library
	    /// instance, than they should probably be using the SMaRT Tool </summary>
	    public static string Network_METS_Directory
	    {
	        get { return String.Empty; }
	    }

	    /// <summary> Constant always returns an empty string since this application works 
	    /// outside of a SobekCM library instance.  If the user is running a SobekCM library
	    /// instance, than they should probably be using the SMaRT Tool </summary>
	    public static string Network_MARC_XML_Directory
	    {
	        get { return String.Empty; }
	    }

	    #endregion
	}
}
