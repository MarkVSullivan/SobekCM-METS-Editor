using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace DLC.Tools.Database
{
    public enum Database_Type
    {
        SQL = 1,
        DLOC,
        DETACHED,
        XML,
        UNDEFINED,
        SQL_Test
    }

    interface iDatabase
    {
        /// <summary> Gets the database type </summary>
        Database_Type DB_Type { get; }

        /// <summary> Gets and sets a flag if this database should show errors messages  </summary>
        bool Show_Errors { get; set;  }

        #region Quality Control Procedures

        /// <summary> Gets a flag indicating if the bib id and vid are valid <summary>
        /// <param name="BibID">Bib ID to check</param>
        /// <param name="VID">VID to check</param>
        /// <returns>TRUE if valid, otherwise FALSE</returns>
        bool Valid_Bib_VID(string BibID, string VID);

        /// <summary> Get the list of Bib ID's and VIDS from the database </summary>
        DataTable Bib_VID_List { get; set;  }

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
        void Submit_QC_Log(string bibid, string vid, string notes, string scanqc, int qcstatusid, int volumeerrortypeid, string storage_location);

        /// <summary> Marks an item as having been Pre-QCd</summary>
        /// <param name="bibid">Bibliographic Identifier for this digital resource</param>
        /// <param name="vid">Volume identifier for this digital resource</param>
        /// <remarks> This method calls the stored procedure 'CS_PreQC_Complete'. </remarks>
        /// <exception cref="CS_TrackingDatabase_Exception"> Exception is thrown if an error is caught during 
        /// the database work and the THROW_EXCEPTIONS internal flag is set to true. </exception>
        void PreQC_Complete(string bibid, string vid, string username, string storagelocation );

        #endregion

        #region Go UFDC Procedures

        /// <summary> Checks to see if this item is DARK, in which case 
        /// it should not have resource files loaded to the web </summary>
        /// <param name="bibid">BibID for this item</param>
        /// <param name="vid">Volume ID for this item</param>
        bool Is_Item_Dark(string bibid, string vid);

        #endregion

        #region Importer Procedures

        /// <summary> Gets the list of all valid project codes </summary>
        DataTable Project_Codes { get; }

        /// <summary> Gets the list of all valid material types</summary>
        DataTable Material_Types { get; }

        /// <summary> Gets the list of all locations from the database</summary>
        DataTable Locations { get; }

        /// <summary> Gets the list of all items with any specific external 
        /// identifiers from the database to ensure no replication is occurring </summary>
        DataTable Bib_VID_List_With_External_Identifiers { get; }

        /// <summary> Method refreshes all of the importer tables </summary>
        void Refresh_Importer_Tables();


        #endregion

        /// <summary> Gets some basic information about an item before displaying it, such as the descriptive notes from the database, ability to add notes, etc.. </summary>
        /// <param name="BibID"> Bibliographic identifier for the volume to retrieve </param>
        /// <param name="VID"> Volume identifier for the volume to retrieve </param>
        /// <returns> DataSet with detailed information about this item from the database </returns>
        /// <remarks> This calls the 'SobekCM_Get_Item_Details2' stored procedure </remarks> 
        DataSet Get_Item_Details(string BibID, string VID);


    }
}