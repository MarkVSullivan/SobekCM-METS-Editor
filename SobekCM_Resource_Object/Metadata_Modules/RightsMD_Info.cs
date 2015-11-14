﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

#endregion

namespace SobekCM.Resource_Object.Metadata_Modules
{
    /// <summary> Object holds all the information from the RightsMD schema, used initially
    /// for reading/writing ETDs </summary>
    [Serializable]
    public class RightsMD_Info : XML_Writing_Base_Type, iMetadata_Module
    {
        #region AccessCode_Enum enum

        /// <summary> Enumeration holds the access code which dictates who can 
        /// access the digital resource and record </summary>
        public enum AccessCode_Enum : byte
        {
            /// <summary> No access code is specified </summary>
            NOT_SPECIFIED,

            /// <summary> Anyone can access this resource </summary>
            Public,

            /// <summary> Access is restricted to UF campus only </summary>
            Campus,

            /// <summary> Noone should be able to access this resource </summary>
            Private
        }

        #endregion

        private AccessCode_Enum accessCode;
        private string copyrightStatement;
        private Nullable<DateTime> embargoEnd;
        private string versionStatement;

        public RightsMD_Info()
        {
            accessCode = AccessCode_Enum.NOT_SPECIFIED;
        }

        public bool hasData
        {
            get
            {
                if ((!String.IsNullOrEmpty(versionStatement)) || (!String.IsNullOrEmpty(copyrightStatement)) || (embargoEnd.HasValue) || (accessCode != AccessCode_Enum.NOT_SPECIFIED))
                    return true;
                else
                    return false;
            }
        }

        public string Version_Statement
        {
            get { return versionStatement ?? String.Empty; }
            set { versionStatement = value; }
        }

        public string Copyright_Statement
        {
            get { return copyrightStatement ?? String.Empty; }
            set { copyrightStatement = value; }
        }

        public AccessCode_Enum Access_Code
        {
            get { return accessCode; }
            set { accessCode = value; }
        }

        public string Access_Code_String
        {
            get
            {
                switch (accessCode)
                {
                    case AccessCode_Enum.Public:
                        return "public";
                    case AccessCode_Enum.Campus:
                        return "campus";
                    case AccessCode_Enum.Private:
                        return "private";
                    default:
                        return String.Empty;
                }
            }
        }

        public bool Has_Embargo_End
        {
            get { return embargoEnd.HasValue; }
        }

        public DateTime Embargo_End
        {
            get { return embargoEnd.HasValue ? embargoEnd.Value : new DateTime(1900, 1, 1); }
            set { embargoEnd = value; }
        }

        #region Methods/Properties to implement the iMetadata_Module interface

        /// <summary> Name for this metadata module </summary>
        /// <value> This always returns 'PalmmRightsMD'</value>
        public string Module_Name
        {
            get { return "PalmmRightsMD"; }
        }

        /// <summary> Gets the metadata search terms and values to be saved to the database
        /// to allow searching to occur over the data in this metadata module </summary>
        public List<KeyValuePair<string, string>> Metadata_Search_Terms
        {
            get { return null; }
        }

        /// <summary> Chance for this metadata module to perform any additional database work
        /// such as saving digital resource data into custom tables </summary>
        /// <param name="ItemID"> Primary key for this item within the SobekCM database </param>
        /// <param name="DB_ConnectionString"> Connection string for the current database </param>
        /// <param name="BibObject"> Entire resource, in case there are dependencies between this module and somethingt in the full resource </param>
        /// <param name="Error_Message"> In the case of an error, this contains text of the error </param>
        /// <returns> TRUE if no error occurred, otherwise FALSE </returns>
        /// <remarks> This module currently  does no additional processing in this method </remarks>
        public bool Save_Additional_Info_To_Database(int ItemID, string DB_ConnectionString, SobekCM_Item BibObject, out string Error_Message)
        {
            // Set the default error mesasge
            Error_Message = String.Empty;

            // Get the UMI flag from the organizational notes
            string UMI = String.Empty; //BibObject.Tracking.UMI_Flag
            if ( BibObject.METS_Header.Creator_Org_Notes_Count > 0 ) 
            {
                foreach (string thisNote in BibObject.METS_Header.Creator_Org_Notes)
                {
                    int umi_index = thisNote.ToUpper().IndexOf("UMI=");
                    if ((umi_index >= 0) && (umi_index + 4 < thisNote.Length))
                    {
                        UMI = thisNote.Substring(umi_index + 4).Trim();
                        break;
                    }
                }
            }

            try
            {
                // Build the parameter list
                SqlParameter[] param_list = new SqlParameter[4];
                param_list[0] = new SqlParameter("@ItemID", ItemID);
                param_list[1] = new SqlParameter("@Original_AccessCode", Access_Code_String);

                if ( Has_Embargo_End )
                    param_list[2] = new SqlParameter("@EmbargoEnd", Embargo_End);
                else
                    param_list[2] = new SqlParameter("@EmbargoEnd", DBNull.Value);
                param_list[3] = new SqlParameter("@UMI", UMI);

                // Execute this query stored procedure
                SqlHelper.ExecuteNonQuery(DB_ConnectionString, CommandType.StoredProcedure, "PalmmRightsMD_Save_Access_Embargo_UMI", param_list);

                return true;
            }
            catch (Exception ee)
            {
                // Pass this exception onto the method to handle it
                Error_Message = "Error encountered in RightsMD_Info.Save_Additional_Info_To_Database: " + ee.Message;
                return false;
            }

            return true;
        }

        /// <summary> Chance for this metadata module to load any additional data from the 
        /// database when building this digital resource  in memory </summary>
        /// <param name="ItemID"> Primary key for this item within the SobekCM database </param>
        /// <param name="DB_ConnectionString">Connection string for the current database</param>
        /// <param name="BibObject"> Entire resource, in case there are dependencies between this module and somethingt in the full resource </param>
        /// <param name="Error_Message"> In the case of an error, this contains text of the error </param>
        /// <returns> TRUE if no error occurred, otherwise FALSE </returns>
        /// <remarks> This module currently  does no additional processing in this method </remarks>
        public bool Retrieve_Additional_Info_From_Database(int ItemID, string DB_ConnectionString, SobekCM_Item BibObject, out string Error_Message)
        {
            // Set the default error mesasge
            Error_Message = String.Empty;

            return true;
        }

        #endregion
    }
}