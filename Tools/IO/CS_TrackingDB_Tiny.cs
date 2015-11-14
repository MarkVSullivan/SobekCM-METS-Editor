using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.ApplicationBlocks.Data;
using System.Windows.Forms;


namespace DLC.Tools.IO
{
	/// <summary> CS_TrackingDatabase is the main object used to query the database for information </summary>
	/// <remarks> This class contains a static constructor and contains mostly static 
	/// members.   Since this is a database class, it does not make sense to have multiple
	/// instances to access a single database. <br /><br />
	/// Object created for University of Florida's Digital Library Center.  </remarks>
	public class CS_TrackingDB_Tiny
	{

		private static DataTable bib_list;
		private static DataTable bib_vid_list;

		/// <summary> Private constant string variable stores the connection string 
		/// to get to the Tracking Database on the SQL server. </summary>
		private static string connectionString = "data source=LIB-SQL1\\SQLPROD;initial catalog=DLCProduction;integrated security=SSPI;persist security info=False;workstation id=WSID3246;packet size=4096";

		/// <summary> Constructor for the CS_TrackingDB_Tiny class. </summary>
		static CS_TrackingDB_Tiny( )
		{
			bib_list = null;
			bib_vid_list = null;
		}

		/// <summary> Gets a flag indicating if the provided string appears to be in 
		/// bib id format </summary>
		/// <param name="test_string"> string to check for bib id format </param>
		/// <returns> TRUE if this string appears to be in bib id format, otherwise FALSE </returns>
		public static bool is_bibid_format( string test_string )
		{
			// Must be 10 characters long to start with
			if ( test_string.Length != Bib_Length )
				return false;

			// Use regular expressions to check format
			Regex myReg = new Regex( "[A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]" );
			return myReg.IsMatch( test_string );
		}

		/// <summary> Check to see if this is a valid bib id </summary>
		/// <param name="test_string"> String to test </param>
		/// <returns> TRUE if this is valid, otherwise FALSE </returns>
		public static bool is_valid_bibid( string test_string )
		{

			// Is this the correct format?
			if ( !is_bibid_format( test_string ) )
				return false;

            // Populate the bib vid list if not done
            if (bib_vid_list == null)
            {
                bib_vid_list = Get_All_Bibs_VIDS();
            }

			// Is this a valid bib id?
			DataRow[] selected = bib_vid_list.Select( "BibID = '" + test_string + "'" );
			if ( selected.Length > 0 )
				return true;
			else
				return false;
		}

		/// <summary> Gets the length of the bib id </summary>
		public static int Bib_Length
		{
			get
			{
				// Return the length
				return 10;
			}
		}

		/// <summary> Gets the BIB ID from the Receving ID by doing a lookup against the complete
		/// list of VIDS and BIBS. </summary>
		/// <param name="ReceivingID"> Receiving ID to check for </param>
		/// <returns> BIB ID for this material </returns>
		public static string BibID_From_Receiving( int ReceivingID )
		{
			// Populate the bib vid list if not done
			if ( bib_vid_list == null )
			{
				bib_vid_list = Get_All_Bibs_VIDS();
			}

			// Find the matching bib
			DataRow[] selected = bib_vid_list.Select("ReceivingID = " + ReceivingID );
			if ( selected.Length > 0 )
				return selected[0]["BibID"].ToString();
			else
				return "INVALID";
		}

		/// <summary> Gets the VID from the Receving ID by doing a lookup against the complete
		/// list of VIDS and BIBS. </summary>
		/// <param name="VolumeID"> Volume ID to check for </param>
		/// <returns> VID for this material </returns>
		public static string VID_From_Receiving( int VolumeID )
		{
			// Populate the bib vid list if not done
			if ( bib_vid_list == null )
			{
				bib_vid_list = Get_All_Bibs_VIDS();
			}

			// Find the matching volume
			DataRow[] selected = bib_vid_list.Select("VolumeID = " + VolumeID );
			if ( selected.Length > 0 )
				return selected[0]["VIDNumber"].ToString();
			else
				return "INVALID";
		}

		/// <summary> Gets the Resource Type from the Receving ID by doing a lookup against the complete
		/// list of VIDS and BIBS. </summary>
		/// <param name="ReceivingID"> Receiving ID to check for </param>
		/// <returns> Material Type</returns>
		public static string Type_From_Receiving( int ReceivingID )
		{
			// Populate the bib vid list if not done
			if ( bib_vid_list == null )
			{
				bib_vid_list = Get_All_Bibs_VIDS();
			}

			// Find the matching volume
			DataRow[] selected = bib_vid_list.Select("ReceivingID = " + ReceivingID );
			if ( selected.Length > 0 )
				return selected[0]["Type"].ToString();
			else
				return "UNKNOWN";
		}

		#region Custom Public Properties

		/// <summary> Gets the table which has a small bit of information for each bib id in the 
		/// tracking database.  </summary>
		/// <remarks> This can also be SET, and can be used to test applications away from the
		/// actual SQL database. </remarks>
		public static DataTable Bib_List
		{
			get	
			{				
				// Return the data table
				if ( bib_list == null )
				{
					bib_list = Get_All_Bib_List();
				}

				return bib_list;
			}
			set
			{
				bib_list = value;
			}
		}

		/// <summary> Gets the table which has a small bit of information for each bib id in the 
		/// tracking database.  </summary>
		/// <remarks> This can also be SET, and can be used to test applications away from the
		/// actual SQL database. </remarks>
		public static DataTable Bib_VID_List
		{
			get	
			{				
				// Return the data table
				if ( bib_vid_list == null )
				{
					bib_vid_list = Get_All_Bibs_VIDS();
				}

				return bib_vid_list;
			}
			set
			{
				bib_vid_list = value;
			}
		}

		/// <summary> Refreshes the list of bibs and vids </summary>
		public static void Refresh()
		{					
			bib_vid_list = Get_All_Bibs_VIDS();
			bib_list = Get_All_Bib_List();
		}

	
		#endregion

		#region Stored Procedures ( Autogenerated )

		#region Internal Flags

		/// <summary> Flag indicates whether exceptions should be thrown </summary>
		/// <remarks> If this flag is set to TRUE, a <see cref="CS_Sample_Exception"/> 
		/// will be thrown if any error occurs while accessing the database. </remarks>
		protected static bool THROW_EXCEPTIONS = true;

		/// <summary> Flag indicates whether a message should be displayed when
		/// errors occur. </summary>
		/// <remarks> Set this flag to TRUE to show a message box when errors occur. </remarks>
		protected static bool DISPLAY_ERRORS = true;

		/// <summary> Flag indicates if the text of the internal exception should
		/// be included in any message or exception thrown.  </summary>
		/// <remarks> Set to TRUE to show the text from the inner exception. </remarks>
		protected static bool DISPLAY_INNER_EXCEPTIONS = true;

		/// <summary> Error string displayed in the case of an error </summary>
		private static string ERROR_STRING = "Error while executing stored procedure '{0}'.       ";

		#endregion

		#region Helper methods and classes

		/// <summary> Method is called when an exception is caught while accessing the database. </summary>
		/// <param name="stored_procedure_name"> Name of the stored procedure called </param>
		/// <param name="exception"> Exception caught while accessing the database </param>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		private static void exception_caught( string stored_procedure_name, Exception exception )
		{
			// Determine the text to either show or throw
			string exception_text = string.Format( ERROR_STRING, stored_procedure_name );

			// If display is set, then display the errors
			if ( DISPLAY_ERRORS )
			{
                DLC.Tools.Forms.ErrorMessageBox.Show(exception_text, "Database Error", exception);
			}

			// If an exception should be thrown, throw it
			if ( THROW_EXCEPTIONS )
			{
				throw new CS_TrackingDatabase_Exception( exception_text );
			}
		}

		/// <summary> CS_TrackingDatabase_Exception is an exception which can be thrown when there
		/// is an error while accessing the database.  This extends the <see cref="ApplicationException"/>
		/// class.  </summary>
		internal class CS_TrackingDatabase_Exception : ApplicationException
		{
			/// <summary> Constructor for a new CS_TrackingDatabase_Exception object </summary>
			/// <param name="exceptionText"> Text of the exception to be displayed </param>
			public CS_TrackingDatabase_Exception( string exceptionText ) : base ( exceptionText )
			{
				// All work completed in the base class
			}
		}

		#endregion

		#region Public Properties and Methods

		/// <summary> Stored Procedure to get the next cd number Written by: Mark Sullivan ( 9/28/2004 ) </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_NextCD'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static DataTable Get_NextCD
		{
			get
			{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_NextCD");

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_NextCD", ee );
					return null;
				}
			}
		}

		/// <summary> Get all the portable drive information </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_PortableDrives'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static DataTable Get_PortableDrives
		{
			get
			{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_PortableDrives");

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_PortableDrives", ee );
					return null;
				}
			}
		}

		/// <summary> Stored Procedure to set the next cd number Written by: Mark Sullivan ( 9/28/2004 ) </summary>
		/// <param name="nextcd"> </param>
		/// <remarks> This method calls the stored procedure 'CS_Set_NextCD'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static void Set_NextCD( int nextcd )
		{
			try
			{
				// Build the parameter list
				SqlParameter[] param_list = new SqlParameter[1];
				param_list[0] = new SqlParameter( "@nextcd", nextcd );

				// Execute this non-query stored procedure
				SqlHelper.ExecuteNonQuery( connectionString, CommandType.StoredProcedure, "CS_Set_NextCD", param_list );
			}
			catch (Exception ee)
			{
				// Pass this exception onto the method to handle it
				exception_caught( "CS_Set_NextCD", ee );
			}
		}

		/// <summary>  </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_All_CDArchives'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static DataTable Get_All_CDArchives
		{
			get
			{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_All_CDArchives");

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_All_CDArchives", ee );
					return null;
				}
			}
		}

		/// <summary> Gets the list of bib id's with some summary information about each </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_All_Bib_List'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		private static DataTable Get_All_Bib_List()
		{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_All_Bib_List" );

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_All_Bib_List", ee );
					return null;
				}
		}

		/// <summary> Get flags which indicate the type of user role </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_Current_User_App_Roles'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static DataTable Get_Current_User_App_Roles
		{
			get
			{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_Current_User_App_Roles");

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_Current_User_App_Roles", ee );
					return null;
				}
			}
		}

		/// <summary> Get information about all the FTP servers </summary>
		/// <remarks> This property calls the stored procedure 'CS_Get_FTP_Server_Info'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static DataTable Get_FTP_Server_Info
		{
			get
			{
				try
				{
					// Define a temporary dataset
					DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Get_FTP_Server_Info");

					// Return the first table from the returned dataset
					return tempSet.Tables[0];
				}
				catch (Exception ee)
				{
					// Pass this exception onto the method to handle it
					exception_caught( "CS_Get_FTP_Server_Info", ee );
					return null;
				}
			}
		}

	

		/// <summary> Gets the receiving id from the bib id </summary>
		/// <param name="institutionCode"> Code for the institutions </param>
		/// <param name="bibid"> 8-digit number portion of the bib id </param>
		/// <remarks> This method calls the stored procedure 'CS_Receiving_From_Bib'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		public static int Receiving_From_Bib( string institutionCode, string bibid )
		{
			try
			{
				// Build the parameter list
				SqlParameter[] param_list = new SqlParameter[2];
				param_list[0] = new SqlParameter( "@institutionCode", institutionCode );
				param_list[1] = new SqlParameter( "@bibid", bibid );

				// Define a temporary dataset
				DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_Receiving_From_Bib", param_list );

				// Find the receiving id
				if (( tempSet == null ) || ( tempSet.Tables.Count == 0 ) || ( tempSet.Tables[0].Rows.Count == 0 ))
					return -1;

				return Convert.ToInt32( tempSet.Tables[0].Rows[0]["ReceivingID"] );
			}
			catch (Exception ee)
			{
				// Pass this exception onto the method to handle it
				exception_caught( "CS_Receiving_From_Bib", ee );

				return -1;
			}
		}

		/// <summary> Gets a list of all the volumes and bibs </summary>
		/// <returns> </returns>
		/// <remarks> This method calls the stored procedure 'CS_All_Bibs_VIDS'. </remarks>
		/// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
		/// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
		private static DataTable Get_All_Bibs_VIDS( )
		{
			try
			{
				// Define a temporary dataset
				DataSet tempSet = SqlHelper.ExecuteDataset( connectionString, CommandType.StoredProcedure, "CS_All_Bibs_VIDS" );

				// Return the first table from the returned dataset
				return tempSet.Tables[0];
			}
			catch (Exception ee)
			{
				// Pass this exception onto the method to handle it
				exception_caught( "CS_All_Bibs_VIDS", ee );
				return null;
			}
		}


		#endregion

		#endregion

        #region Procedures for FileSort

        /// <summary>Method used to get all the archive file types</summary>
        /// <returns></returns>
        public static DataTable Get_Archive_FileType()
        {
            try
            {
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Get_Archiving_FileType");

                // Return the first table from the returned dataset
                return tempSet.Tables[0];
            }
            catch (Exception ee)
            {
                exception_caught("CS_FileSort_Get_Archiving_FileType", ee);
                return null;
            }
        }



        /// <summary>Check to see if a CD has been sorted or not</summary>
        /// <param name="cdnumber"></param>
        /// <returns></returns>
        public static DataTable Check_CD_Existence(int cdnumber)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@archivenumber", cdnumber);

                ////				param_list[1] = new SqlParameter( "@archiveserialnum", cdserialNum );
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Check_CDExistence", param_list);

                // Return the dataset
                return tempSet.Tables[0];
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Check_CDExistence", ee);
                return null;
            }
        }

        /// <summary> Method used to delete a archive meets the specified number</summary>
        /// <param name="archiveNumber"></param>
        /// <returns></returns>
        public static bool Delete_ArchiveNumber(int archiveNumber)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@archivenumber", archiveNumber);
                // Define a temporary dataset
                SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Delete_CDNumber", param_list);
                // Return the dataset
                return true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Delete_CDNumber", ee);
                return false;
            }
        }


        /// <summary> stored procedure used to save the basic CD informaton and get the ID for this CD(ArchiveMedia)</summary>
        /// <param name="cdnumber"></param>
        /// <param name="cdserialNum"></param>
        /// <returns></returns>
        public static int Save_Basic_CD_Info(int cdnumber, string cdserialNum)
        {

            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[3];
                param_list[0] = new SqlParameter("@archivenumber", cdnumber);
                param_list[1] = new SqlParameter("@archiveserialnum", cdserialNum);
                param_list[2] = new SqlParameter("@archivemediaid", -1);
                param_list[2].Direction = ParameterDirection.InputOutput;
                // Define a temporary dataset
                SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Save_Basic_CDInfo", param_list);
                // Return the dataset
                return (int)param_list[2].Value;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Save_Basic_CDInfo", ee);
                return -1;
            }
        }

        /// <summary>Stored procedures used to save the file range for a volume on a CD</summary>
        /// <param name="archiveMediaID"></param>
        /// <param name="volumeid"></param>
        /// <param name="filerange"></param>
        /// <returns></returns>
        public static bool Save_FileRange(int archiveMediaID, int volumeid, string filerange, int totalFiles, int totalSize)
        {

            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[5];
                param_list[0] = new SqlParameter("@archivemediaid", archiveMediaID);
                param_list[1] = new SqlParameter("@volumeid", volumeid);
                param_list[2] = new SqlParameter("@filerange", filerange);
                param_list[3] = new SqlParameter("@totalimages", totalFiles);
                param_list[4] = new SqlParameter("@totalsize", totalSize);
                // Define a temporary dataset
                SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Save_FileRange", param_list);
                // Return the dataset
                return true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Save_FileRange", ee);
                return false;
            }
        }


        public static bool Update_ArchivMedia_InspectionDate(int archiveMediaID)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@archivemediaid", archiveMediaID);
                // Define a temporary dataset
                SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Update_ArchiveMedia_InspectionDate", param_list);
                // Return the dataset
                return true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Update_ArchiveMedia_InspectionDate", ee);
                return false;
            }

        }

        /// <summary>static method used to get all the files and their check sums on the CD</summary>
        /// <param name="archiveMediaID"></param>
        /// <returns></returns>
        public static DataTable Get_All_File_CheckSums(int archiveMediaID)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@archivemediaid", archiveMediaID);
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Get_FileDetails_By_AchiveMediaNumber", param_list);
                // Return the dataset
                return tempSet.Tables[0];
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Get_FileDetails_By_AchiveMediaNumber", ee);
                return null;
            }
        }

        /// <summary>static method used to get the cd information by the cd number</summary>
        /// <param name="cdNumber"></param>
        /// <returns></returns>
        public static DataSet Get_CD_Infor_By_CDNumber(int cdNumber)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@cdnumber", cdNumber);
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_GetCDInfo_By_CDNumber", param_list);
                // Return the dataset
                return tempSet;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_GetCDInfo_By_CDNumber", ee);
                return null;
            }
        }

        /// <summary>static method used to get all files and their checksums for a specific cd number</summary>
        /// <param name="cdNumber"></param>
        /// <returns></returns>
        public static DataTable Get_CD_Files_By_CDNumber(int cdNumber)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[1];
                param_list[0] = new SqlParameter("@cdnumber", cdNumber);
                // Define a temporary dataset
                DataSet tempSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_GetFiles_By_CDNumber", param_list);
                // Return the datatable
                return tempSet.Tables[0];
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_GetFiles_By_CDNumber", ee);
                return null;
            }
        }


        /// <summary>Stored procedure used to save the check sum(s) for each file</summary>
        /// <param name="volumeid"></param>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        /// <param name="extension"></param>
        /// <param name="archiveMediaID"></param>
        /// <param name="checksumType1"></param>
        /// <param name="checkSum1"></param>
        /// <param name="checksumType2"></param>
        /// <param name="checkSum2"></param>
        /// <returns></returns>
        public static bool Save_File_CheckSum(int volumeid, string fileName, int fileSize, string dateCreated, string dateModified,
            string extension, int archiveMediaID)
        {
            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[11];
                param_list[0] = new SqlParameter("@volumeid", volumeid);
                param_list[1] = new SqlParameter("@filename", fileName);
                param_list[2] = new SqlParameter("@filesize", fileSize);
                try
                {
                    param_list[3] = new SqlParameter("@datecreated", Convert.ToDateTime(dateCreated));
                }
                catch
                {
                    param_list[3] = new SqlParameter("@datecreated", DBNull.Value);
                }
                try
                {
                    param_list[4] = new SqlParameter("@datemodified", Convert.ToDateTime(dateModified));
                }
                catch
                {
                    param_list[4] = new SqlParameter("@datemodified", DBNull.Value);
                }
                param_list[5] = new SqlParameter("@extension", extension);
                param_list[6] = new SqlParameter("@archivemediaid", archiveMediaID);
                param_list[7] = new SqlParameter("@checksumtype1", String.Empty);
                param_list[8] = new SqlParameter("@checksum1", String.Empty);
                param_list[9] = new SqlParameter("@checksumtype2", String.Empty);
                param_list[10] = new SqlParameter("@checksum2", String.Empty);

                // Define a temporary dataset
                SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CS_FileSort_Save_FileCheckSum", param_list);

                return true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                exception_caught("CS_FileSort_Save_FileCheckSum", ee);
                return false;
            }
        }

        #endregion

    }
}