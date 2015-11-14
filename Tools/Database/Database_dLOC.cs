using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DLC.Tools.Database
{
    public class Database_dLOC : iDatabase
    {
        private string connectionString;
        private string INSTANCE_NAME = "DLOC_v2";

        //private string connectionString;
        //private const string APPDB = "DLOC_Tracking";
        //private const string INSTANCE_NAME = "DLOC";
        //private const string CONNECTSTRING_INTEGRATED = "Server={0};Database={1};Trusted_Connection=true";

//        private static string connectionString = "data source=Smathers2k3sql.smatherslib.uflib.int;initial catalog=DLCProduction;integrated security=SSPI;persist security info=False;packet size=4096";

        private DataTable BibVidList;

        public Database_dLOC( string database_server_override, string database_name_override )
        {
            if ((database_name_override.Length > 0) || (database_server_override.Length > 0) || (Settings.App_Config_Reader.Database_Server.Length > 0))
            {
                if (database_name_override.Length == 0)
                    database_name_override = Settings.App_Config_Reader.Database_Name;
                if (database_server_override.Length == 0)
                    database_server_override = Settings.App_Config_Reader.Database_Server;

                connectionString = "data source=" + database_server_override + ";initial catalog=" + database_name_override + ";integrated security=SSPI;persist security info=False;packet size=4096";
            }
            else
            {
                string strServerName = Environment.MachineName + "\\" + INSTANCE_NAME;
                string connection_base = "Server={0};Database={1};User ID=dloc_toolkit;Password=dlocdloc;";
                connectionString = String.Format(connection_base, strServerName, Settings.App_Config_Reader.Database_Name);
            }
        }

        public Database_dLOC(string Connection_String)
        {
            connectionString = Connection_String;
        }

        /// <summary> Gets the database type </summary>
        public Database_Type DB_Type
        {
            get
            {
                return Database_Type.DLOC;
            }
        }

        /// <summary> Gets and sets a flag if this database should show errors messages  </summary>
        public bool Show_Errors
        {
            get { return true; }
            set { ; }
        }

        #region Quality Control Procedures

        /// <summary> Gets a flag indicating if the bib id and vid are valid <summary>
        /// <param name="BibID">Bib ID to check</param>
        /// <param name="VID">VID to check</param>
        /// <returns>TRUE if valid, otherwise FALSE</returns>
        public bool Valid_Bib_VID(string BibID, string VID)
        {
            // Read this list in
            if (BibVidList == null)
            {
                BibVidList = Bib_VID_List;
            }

            // If no list was read, return true
            if (BibVidList == null)
                return true;

            // Make sure VID starts with VID
            if (VID.IndexOf("VID") < 0)
                VID = "VID" + VID;

            // See if there is a matching row
            DataRow[] selected = BibVidList.Select("BibID = '" + BibID + "' AND VID = '" + VID + "'");
            if (selected.Length > 0)
                return true;
            else
                return false;
        }


        /// <summary> Get the list of Bib ID's and VIDS from the database </summary>
        public DataTable Bib_VID_List
        {
            get
            {
                try
                {
                    // Define a temporary dataset
                    DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MT_Bib_VID_List");

                    // Return the first table from the returned dataset
                    return tempSet.Tables[0];
                }
                catch (Exception ee)
                {
                    // Pass this exception onto the method to handle it
                    DLC.Tools.Forms.ErrorMessageBox.Show("Unable to get the Bib VID list from the database.", "Error", ee);
                    return null;
                }
            }
            set
            {

            }
        }

        /// <summary> Gets the list of portable drives </summary>
        public DataTable Get_PortableDrives { get { return null; } }


        /// <summary> Gets all of the QC logs for a particular volume </summary>
        /// <param name="volumeid"> </param>
        /// <returns> </returns>
        /// <remarks> This method calls the stored procedure 'CS_Get_QC_Log'. </remarks>
        /// <exception cref="qc_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public DataTable Get_QC_Log(string bibid, string vid)
        {
            return null;
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
        public void Submit_QC_Log(string bibid, string vid, string notes, string scanqc, int qcstatusid, int volumeerrortypeid, string storage_location)
        {
            return;
        }

        /// <summary>  </summary>
        /// <remarks> This property calls the stored procedure 'CS_Get_All_Volumes_QCd'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public DataTable Get_Volumes_QCd
        {
            get
            {
                return null;
            }
        }

        /// <summary> Returns all of the volumes currently in QC process </summary>
        /// <param name="date"> Date from which to return the volumes ready </param>
        /// <returns> </returns>
        /// <remarks> This method calls the stored procedure 'CS_Get_Volumes_in_QC'. </remarks>
        /// <exception cref="qc_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public DataTable Get_Volumes_in_QC(string date)
        {
            return null;
        }

        /// <summary> Marks an item as having been Pre-QCd</summary>
        /// <param name="bibid">Bibliographic Identifier for this digital resource</param>
        /// <param name="vid">Volume identifier for this digital resource</param>
        /// <remarks> This method calls the stored procedure 'CS_PreQC_Complete'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public void PreQC_Complete(string bibid, string vid, string user, string storagelocation )
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[2];
                param_list[0] = new SqlParameter("@bibid", bibid);
                param_list[1] = new SqlParameter("@vid", vid);

                // Execute this non-query stored procedure
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MT_Scanned_Complete", param_list);
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                DLC.Tools.Forms.ErrorMessageBox.Show("Unable to update the Pre-QC complete date in the database.", "Database Error", ee);
            }
        }

        /// <summary> Marks an item as having been QCd</summary>
        /// <param name="bibid">Bibliographic Identifier for this digital resource</param>
        /// <param name="vid">Volume identifier for this digital resource</param>
        /// <remarks> This method calls the stored procedure 'CS_QC_Complete'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public void QC_Complete(string bibid, string vid)
        {
            return;
        }

        #endregion

        #region Go UFDC Procedures

        /// <summary> Checks to see if this item is DARK, in which case 
        /// it should not have resource files loaded to the web </summary>
        /// <param name="bibid">BibID for this item</param>
        /// <param name="vid">Volume ID for this item</param>
        public bool Is_Item_Dark(string bibid, string vid)
        {
            return false;
        }

        #endregion

        #region Importer Procedures

        /// <summary> Gets the list of all valid project codes </summary>
        public DataTable Project_Codes
        {
            get
            {
                return null;
            }
        }

        /// <summary> Gets the list of all valid material types</summary>
        public DataTable Material_Types
        {
            get
            {
                return null;
            }
        }

        /// <summary> Gets the list of all locations from the database</summary>
        public DataTable Locations
        {
            get
            {
                return null;
            }
        }

        /// <summary> Gets the list of all items with any specific external 
        /// identifiers from the database to ensure no replication is occurring </summary>
        public DataTable Bib_VID_List_With_External_Identifiers
        {
            get
            {
                return Bib_VID_List;
            }
        }

        /// <summary> Method refreshes all of the importer tables </summary>
        public void Refresh_Importer_Tables()
        {
            // do nothing
        }

        #endregion

        /// <summary> Gets some basic information about an item before displaying it, such as the descriptive notes from the database, ability to add notes, etc.. </summary>
        /// <param name="BibID"> Bibliographic identifier for the volume to retrieve </param>
        /// <param name="VID"> Volume identifier for the volume to retrieve </param>
        /// <returns> DataSet with detailed information about this item from the database </returns>
        /// <remarks> This calls the 'SobekCM_Get_Item_Details2' stored procedure </remarks> 
        public DataSet Get_Item_Details(string BibID, string VID)
        {
            return null;
        }
    }
}
