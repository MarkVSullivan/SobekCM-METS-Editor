using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DLC.Tools.Settings
{
    public class Division_Types_Errors_Reader
    {
        protected static Division_Types_Errors_Table appWide_Tables;
        protected static Division_Types_Errors_Table.Division_TypeDataTable imageClassDivisionTable;

        static Division_Types_Errors_Reader()
        {
            // Load the application wide tables here into 'appWide_Tables'
            appWide_Tables = new Division_Types_Errors_Table();
            appWide_Tables.ReadXml(System.Windows.Forms.Application.StartupPath + "/Data/Division_Types_Errors.xml");


            // Create the image class division table
            imageClassDivisionTable = new Division_Types_Errors_Table.Division_TypeDataTable();
            imageClassDivisionTable.AddDivision_TypeRow(5, "Group", true, true, "Group", "Group", "Grupo", "Groupe");
        }

        /// <summary> Gets the table of possible volume error types </summary>
        public static Division_Types_Errors_Table.Volume_Error_TypeDataTable Volume_Error_Types_Table
        {
            get
            {
                return appWide_Tables.Volume_Error_Type;
            }
        }

        /// <summary> Gets the complete table of possible division types</summary>
        public static Division_Types_Errors_Table.Division_TypeDataTable Division_Types_Table
        {
            get
            {
                return appWide_Tables.Division_Type;
            }
        }

        /// <summary> Gets the table of division types for an image class item</summary>
        public static Division_Types_Errors_Table.Division_TypeDataTable Image_Division_Types_Table
        {
            get
            {
                return imageClassDivisionTable;
            }
        }

        /// <summary> Gets the division table applicable to the current
        /// type of class.  </summary>
        /// <remarks>This returns a trimmed down list if this is an image class
        /// item, and the complete list if this is a text class item. </remarks>
        /// <param name="imageClass"></param>
        public static Division_Types_Errors_Table.Division_TypeDataTable get_Division_Types_Table(bool imageClass)
        {
            if (imageClass)
            {
                return imageClassDivisionTable;
            }
            else
            {
                return appWide_Tables.Division_Type;
            }
        }

        /// <summary> Gets the table of possible file error types </summary>
        public static Division_Types_Errors_Table.File_Error_TypeDataTable File_Error_Types_Table
        {
            get
            {
                return appWide_Tables.File_Error_Type;
            }
        }

        /// <summary> Gets the name of the division type </summary>
        /// <param name="divTypeID"> Division Type ID </param>
        /// <returns> Name of the division </returns>
        public static string Division_Type(int divTypeID)
        {
            DataRow[] select = Division_Types_Table.Select("DivisionTypeID = " + divTypeID);
            if (select.Length == 0)
                return "INVALID";
            else
                return Convert.ToString(select[0]["TypeName"]);
        }
    }
}
