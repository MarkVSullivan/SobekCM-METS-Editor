using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace DLC.Tools.Database
{
    public class Database_SQL : iDatabase
    {
        private DataTable BibVidList;
        private string connectionString;
        private bool lookup_tables_loaded;

        private DataTable tbl_complete_items_with_identifiers;
        private DataTable tbl_Locations;
        private DataTable tbl_Projects;
        private DataTable tbl_MaterialTypes;

        public Database_SQL()
        {
            connectionString = "data source=" + Settings.App_Config_Reader.Database_Server + ";initial catalog=" + Settings.App_Config_Reader.Database_Name + ";integrated security=SSPI;persist security info=False;packet size=4096";

            lookup_tables_loaded = false;
        }


        public Database_SQL( string Server, string Database )
        {
            connectionString = "data source=" + Server + ";initial catalog=" + Database + ";integrated security=SSPI;persist security info=False;packet size=4096";

            lookup_tables_loaded = false;
        }

        public void Set_Connection_String(string server, string name)
        {
            connectionString = "data source=" + server + ";initial catalog=" + name + ";integrated security=SSPI;persist security info=False;packet size=4096";

        }

        /// <summary> Gets the database type </summary>
        public Database_Type DB_Type 
        {
            get
            {
                return Database_Type.SQL;
            }
        }

        /// <summary> Gets and sets a flag if this database should show errors messages  </summary>
        public bool Show_Errors 
        {
            get { return this.DISPLAY_ERRORS; }
            set { this.DISPLAY_ERRORS = value; }  
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

            // If no list was read, return false (SQL is required for this)
            if (BibVidList == null)
                return false;

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
                if (BibVidList != null)
                    return BibVidList;
                else
                {
                    try
                    {

                        // Build the parameter list
                        SqlParameter[] param_list = new SqlParameter[1];
                        param_list[0] = new SqlParameter("@include_private", true);

                        // Define a temporary dataset
                        DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SobekCM_Item_List_Brief2", param_list);
                        BibVidList = tempSet.Tables[0];

                        // Return the first table from the returned dataset
                        return BibVidList;
                    }
                    catch (Exception ee)
                    {
                        return null;
                    }
                }
            }
            set
            {
                BibVidList = value;
            }
        }


        /// <summary> Submit a log about QCing a volume </summary>
        /// <param name="volumeid"> </param>
        /// <param name="notes"> </param>
        /// <param name="scanqc"> </param>
        /// <param name="qcstatusid"> </param>
        /// <param name="volumeerrortypeid"> </param>
        /// <param name="storage_location"> </param>
        /// <remarks> This method calls the stored procedure 'Tracking_Submit_QC_Log'. </remarks>
        /// <exception cref="qc_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public void Submit_QC_Log(string bibid, string vid, string notes, string scanqc, int qcstatusid, int volumeerrortypeid, string storage_location)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[7];
                param_list[0] = new SqlParameter("@bibid", bibid);
                param_list[1] = new SqlParameter("@vid", vid);
                param_list[2] = new SqlParameter("@notes", notes);
                param_list[3] = new SqlParameter("@scanqc", scanqc);
                param_list[4] = new SqlParameter("@qcstatusid", qcstatusid);
                param_list[5] = new SqlParameter("@volumeerrortypeid", volumeerrortypeid);
                param_list[6] = new SqlParameter("@storagelocation", storage_location);

                // Execute this non-query stored procedure
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Tracking_Submit_QC_Log", param_list);
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("Tracking_Submit_QC_Log", ee);
            }
        }


        /// <summary> Marks an item as having been Pre-QCd</summary>
        /// <param name="bibid">Bibliographic Identifier for this digital resource</param>
        /// <param name="vid">Volume identifier for this digital resource</param>
        /// <remarks> This method calls the stored procedure 'Tracking_PreQC_Complete'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        public void PreQC_Complete(string bibid, string vid, string username, string storagelocation )
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[4];
                param_list[0] = new SqlParameter("@bibid", bibid);
                param_list[1] = new SqlParameter("@vid", vid);
                param_list[2] = new SqlParameter("@user", username);
                param_list[3] = new SqlParameter("@storagelocation", storagelocation);

                // Execute this non-query stored procedure
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Tracking_PreQC_Complete", param_list);
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("Tracking_PreQC_Complete", ee);
            }
        }

        #endregion

        #region Go UFDC Procedures

        /// <summary> Checks to see if this item is DARK, in which case 
        /// it should not have resource files loaded to the web </summary>
        /// <param name="bibid">BibID for this item</param>
        /// <param name="vid">Volume ID for this item</param>
        public bool Is_Item_Dark(string bibid, string vid)
        {
            DataSet itemDetails = Get_Item_Details(bibid, vid);
            if (itemDetails != null)
            {
                return Convert.ToBoolean(itemDetails.Tables[2].Rows[0]["Dark"].ToString());
            }
            return false;
        }

        #endregion

        #region Importer Procedures

        /// <summary> Method refreshes all of the importer tables </summary>
        public void Refresh_Importer_Tables()
        {
            try
            {
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Importer_Load_Lookup_Tables");

                // assign tables from the dataset   
                tbl_complete_items_with_identifiers = tempSet.Tables[0];        
                tbl_Locations = tempSet.Tables[1];
                tbl_Projects = tempSet.Tables[2];
                tbl_MaterialTypes = tempSet.Tables[4];

                lookup_tables_loaded = true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("Importer_Load_Lookup_Tables", ee);
            }
        }

        /// <summary> Gets the list of all valid project codes </summary>
        public DataTable Project_Codes
        {
            get
            {
                if (!lookup_tables_loaded)
                {
                    Refresh_Importer_Tables();
                }

                return tbl_Projects;
            }
        }

        /// <summary> Gets the list of all valid material types</summary>
        public DataTable Material_Types
        {
            get
            {
                if (!lookup_tables_loaded)
                {
                    Refresh_Importer_Tables();
                }

                return tbl_MaterialTypes;
            }
        }

        /// <summary> Gets the list of all locations from the database</summary>
        public DataTable Locations
        {
            get
            {
                if (!lookup_tables_loaded)
                {
                    Refresh_Importer_Tables();
                }

                return tbl_Locations;
            }
        }

        /// <summary> Gets the list of all items with any specific external 
        /// identifiers from the database to ensure no replication is occurring </summary>
        public DataTable Bib_VID_List_With_External_Identifiers
        {
            get
            {
                if (!lookup_tables_loaded)
                {
                    Refresh_Importer_Tables();
                }

                return tbl_complete_items_with_identifiers;
            }
        }


        #endregion

        #region Internal Flags

        /// <summary> Flag indicates whether exceptions should be thrown </summary>
        /// <remarks> If this flag is set to TRUE, a <see cref="CS_Sample_Exception"/> 
        /// will be thrown if any error occurs while accessing the database. </remarks>
        protected bool THROW_EXCEPTIONS = true;

        /// <summary> Flag indicates whether a message should be displayed when
        /// errors occur. </summary>
        /// <remarks> Set this flag to TRUE to show a message box when errors occur. </remarks>
        public bool DISPLAY_ERRORS = false;

        /// <summary> Flag indicates if the text of the internal exception should
        /// be included in any message or exception thrown.  </summary>
        /// <remarks> Set to TRUE to show the text from the inner exception. </remarks>
        protected bool DISPLAY_INNER_EXCEPTIONS = true;

        /// <summary> Error string displayed in the case of an error </summary>
        private string ERROR_STRING = "Error while executing stored procedure '{0}'.       ";

        #endregion

        #region Exception catching helper method

        /// <summary> Method is called when an exception is caught while accessing the database. </summary>
        /// <param name="stored_procedure_name"> Name of the stored procedure called </param>
        /// <param name="exception"> Exception caught while accessing the database </param>
        /// <exception cref="qc_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        private void exception_caught(string stored_procedure_name, Exception exception)
        {
            // Determine the text to either show or throw
            string exception_text = string.Format(ERROR_STRING, stored_procedure_name);

            // If display is set, then display the errors
            if (DISPLAY_ERRORS)
            {
                // If the server timed out, show a particular message for that
                if (exception_text.ToUpper().IndexOf("TIMEOUT EXPIRED") >= 0)
                {
                    Tools.Forms.ErrorMessageBox.Show("SQL Server Timed Out.      ", "Server Error", exception);
                }
                else
                {
                    Tools.Forms.ErrorMessageBox.Show(exception_text, "Database Error", exception);
                }
            }

            // If an exception should be thrown, throw it
            if (THROW_EXCEPTIONS)
            {
                throw new Database_Exception(exception_text);
            }
        }

        #endregion

        /// <summary> Gets some basic information about an item before displaying it, such as the descriptive notes from the database, ability to add notes, etc.. </summary>
        /// <param name="BibID"> Bibliographic identifier for the volume to retrieve </param>
        /// <param name="VID"> Volume identifier for the volume to retrieve </param>
        /// <returns> DataSet with detailed information about this item from the database </returns>
        /// <remarks> This calls the 'SobekCM_Get_Item_Details2' stored procedure </remarks> 
        public DataSet Get_Item_Details(string BibID, string VID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@BibID", BibID);
                parameters[1] = new SqlParameter("@VID", VID);

                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SobekCM_Get_Item_Details2", parameters);

                // Return the first table from the returned dataset
                return tempSet;
            }
            catch 
            {
                return null;
            }
        }

    }
}
