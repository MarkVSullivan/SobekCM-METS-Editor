using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DLC.Tools.Database
{
    public class Database_Gateway
    {
        private static iDatabase db_instance;

        static Database_Gateway()
        {

        }


        /// <summary> Gets a flag indicating if the provided string appears to be in bib id format </summary>
        /// <param name="test_string"> string to check for bib id format </param>
        /// <returns> TRUE if this string appears to be in bib id format, otherwise FALSE </returns>
        public static bool is_bibid_format(string test_string)
        {
            // Must be 10 characters long to start with
            if (test_string.Length != 10)
                return false;

            // Use regular expressions to check format
            Regex myReg = new Regex("[A-Z]{2}[A-Z|0-9]{4}[0-9]{4}");
            return myReg.IsMatch(test_string.ToUpper());
        }

        public static Database_Type DB_Type
        {
            get 
            {
                if (db_instance == null)
                {
                    return Database_Type.UNDEFINED;
                }
                else
                {
                    return db_instance.DB_Type;
                }
            }
            set { Set_Database_Type(value ); }
        }

        public static void Set_To_dLOC(string ConnectionString)
        {
            db_instance = new Database_dLOC(ConnectionString);
        }

        public static void Set_To_dLOC(string database_server_override, string database_name_override)
        {
            db_instance = new Database_dLOC(database_server_override, database_name_override);
        }

        public static void Set_Database_Type(Database_Type Type )
        {
            switch (Type)
            {
                case Database_Type.SQL:
                    db_instance = new Database_SQL();
                    ((Database_SQL)db_instance).Set_Connection_String("LIB-UFDC-CACHE\\UFDCPROD", "UFDC_Prod");
                    break;
                case Database_Type.SQL_Test:
                    db_instance = new Database_SQL();
                    ((Database_SQL)db_instance).Set_Connection_String("LIB-UFDC-CACHE\\UFDCPROD", "UFDC_Dev");
                    break;
                case Database_Type.DLOC:
                    db_instance = new Database_dLOC(String.Empty, String.Empty);
                    break;
            }
        }

        public static void Set_Database_Type(Database_Type Type, string database_server_override, string database_name_override)
        {
            switch (Type)
            {
                case Database_Type.SQL:
                case Database_Type.SQL_Test:
                    db_instance = new Database_SQL(database_server_override, database_name_override);
                    break;
                case Database_Type.DLOC:
                    db_instance = new Database_dLOC(String.Empty, String.Empty);
                    break;
            }
        }

        public static void Set_Database_Type( string Type)
        {
            switch (Type.ToUpper())
            {
                case "SQL":
                    db_instance = new Database_SQL();
                    break;
                case "DLOC":
                    db_instance = new Database_dLOC(String.Empty, String.Empty);
                    break;
            }
        }

        public static bool Show_Errors
        {
            get { return db_instance.Show_Errors; }
            set { db_instance.Show_Errors = value; }
        }

        #region Quality Control Procedures

        /// <summary> Gets a flag indicating if the bib id and vid are valid <summary>
        /// <param name="BibID">Bib ID to check</param>
        /// <param name="VID">VID to check</param>
        /// <returns>TRUE if valid, otherwise FALSE</returns>
        public static bool Valid_Bib_VID(string BibID, string VID)
        {
            return db_instance.Valid_Bib_VID(BibID, VID);
        }


        /// <summary> Get the list of Bib ID's and VIDS from the database </summary>
        public static DataTable Bib_VID_List
        {
            get
            {
                return db_instance.Bib_VID_List;
            }
            set
            {
                db_instance.Bib_VID_List = value;
            }
        }

        /// <summary> Submit a log about QCing a volume </summary>
        /// <param name="volumeid"> </param>
        /// <param name="notes"> </param>
        /// <param name="scanqc"> </param>
        /// <param name="qcstatusid"> </param>
        /// <param name="volumeerrortypeid"> </param>
        /// <param name="storage_location"> </param>
        /// <remarks> This method calls the stored procedure 'CS_Submit_QC_Log'. </remarks>
        /// <exception cref="qc_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public static void Submit_QC_Log(string bibid, string vid, string notes, string scanqc, int qcstatusid, int volumeerrortypeid, string storage_location)
        {
            db_instance.Submit_QC_Log(bibid, vid, notes, scanqc, qcstatusid, volumeerrortypeid, storage_location);
        }

        /// <summary> Marks an item as having been Pre-QCd</summary>
        /// <param name="bibid">Bibliographic Identifier for this digital resource</param>
        /// <param name="vid">Volume identifier for this digital resource</param>
        /// <remarks> This method calls the stored procedure 'CS_PreQC_Complete'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public static void PreQC_Complete(string bibid, string vid, string user, string storagelocation )
        {
            db_instance.PreQC_Complete(bibid, vid, user , storagelocation);
        }

        #endregion

        #region Go UFDC Procedures

        /// <summary> Checks to see if this item is DARK, in which case 
        /// it should not have resource files loaded to the web </summary>
        /// <param name="bibid">BibID for this item</param>
        /// <param name="vid">Volume ID for this item</param>
        public static bool Is_Item_Dark(string bibid, string vid)
        {
            return db_instance.Is_Item_Dark(bibid, vid);
        }

        #endregion

        #region Importer Procedures

        /// <summary> Gets the list of all valid project codes </summary>
        public static DataTable Project_Codes
        {
            get
            {
                return db_instance.Project_Codes;
            }
        }

        /// <summary> Gets the list of all valid material types</summary>
        public static DataTable Material_Types
        {
            get
            {
                return db_instance.Material_Types;
            }
        }

        /// <summary> Gets the list of all locations from the database</summary>
        public static DataTable Locations
        {
            get
            {
                return db_instance.Locations;
            }
        }

        /// <summary> Gets the list of all languages from the database</summary>
        public static DataTable Languages
        {
            get
            {
                string language_xml_file = System.Windows.Forms.Application.StartupPath + "\\Data\\Languages.xml";
                if (System.IO.File.Exists( language_xml_file ))
                {
                    try
                    {
                        DataSet languageSet = new DataSet();
                        languageSet.ReadXml(language_xml_file);
                        return languageSet.Tables[0];
                    }
                    catch
                    {

                    }
                }

                DataTable languageTable = new DataTable();
                languageTable.Columns.Add("LanguageID");
                languageTable.Columns.Add("LanguageCode");
                languageTable.Columns.Add("LanguageName");

                DataRow english = languageTable.NewRow();
                english[0] = 1;
                english[1] = "eng";
                english[2] = "English";
                languageTable.Rows.Add(languageTable);

                DataRow french = languageTable.NewRow();
                french[0] = 2;
                french[1] = "fre";
                french[2] = "French";
                languageTable.Rows.Add(french);

                DataRow spanish = languageTable.NewRow();
                spanish[0] = 3;
                spanish[1] = "spa";
                spanish[2] = "Spanish";
                languageTable.Rows.Add(spanish);

                return languageTable;
            }
        }

        /// <summary> Gets the list of all items with any specific external 
        /// identifiers from the database to ensure no replication is occurring </summary>
        public static DataTable Bib_VID_List_With_External_Identifiers
        {
            get
            {
                return db_instance.Bib_VID_List_With_External_Identifiers;
            }
        }

        /// <summary> Method refreshes all of the importer tables </summary>
        public static void Refresh_Importer_Tables()
        {
            db_instance.Refresh_Importer_Tables();
        }

        #endregion

        /// <summary> Gets some basic information about an item before displaying it, such as the descriptive notes from the database, ability to add notes, etc.. </summary>
        /// <param name="BibID"> Bibliographic identifier for the volume to retrieve </param>
        /// <param name="VID"> Volume identifier for the volume to retrieve </param>
        /// <returns> DataSet with detailed information about this item from the database </returns>
        /// <remarks> This calls the 'SobekCM_Get_Item_Details2' stored procedure </remarks> 
        public static DataSet Get_Item_Details(string BibID, string VID)
        {
            return db_instance.Get_Item_Details(BibID, VID);
        }

    }
}
