using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DLC.Tools.FDA
{

    #region FDA Report Type Enumeration

    /// <summary> Enumeration indicates the type of FDA Ingest Report </summary>
    public enum FDA_Report_Type
    {
        /// <summary> FDA Ingest Report when a SIP is successfully ingested into the digital archive </summary>
        INGEST = 1,

        /// <summary> Report is created when an item is withdrawn from the digital archive </summary>
        WITHDRAWAL,

        /// <summary> Dissemination Report is written when an item is re-ingested into the archive </summary>
        DISSEMINATION,

        /// <summary> FDA Ingest Error Report when a SIP is not ingested into the digital archive </summary>
        ERROR,

        /// <summary> Used to indicate an unrecognized FDA report type </summary>
        INVALID
    }


    #endregion

    #region FDA Report Data

    /// <summary> Class stores all the important data from a FDA Ingest Report </summary>
    public class FDA_Report_Data
    {
        private string ieid, package, account, project, message_note, filename;
        private DateTime date;
        private ArrayList files;
        private FDA_Report_Type type;
        private int warnings;

        /// <summary> Constructor creates a new instance of the FDA_Report_Data class </summary>
        public FDA_Report_Data()
        {
            // Initialize all values
            ieid = String.Empty;
            package = String.Empty;
            account = String.Empty;
            project = String.Empty;
            message_note = String.Empty;
            filename = String.Empty;
            files = new ArrayList();
            type = FDA_Report_Type.INVALID;
            warnings = 0;
        }

        /// <summary> Gets or sets the type of report which generated this data </summary>
        public FDA_Report_Type Report_Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary> Gets the collection of files associated with this IEID </summary>
        /// <remarks>Returned as an ArrayList of FDA_File objects</remarks>
        public ArrayList Files
        {
            get { return files; }
        }

        /// <summary> Gets the IEID (Intellectual Entity ID) for this FDA report </summary>
        public string IEID
        {
            get { return ieid; }
            set { ieid = value; }
        }

        /// <summary> Gets the submitted package name for this IEID </summary>
        public string Package
        {
            get { return package; }
            set { package = value; }
        }

        /// <summary> Gets the account information submitted with this package </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        /// <summary> Gets the project information submitted with this package </summary>
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        /// <summary> Gets the message or note returned with the report </summary>
        public string Message_Note
        {
            get { return message_note; }
            set { message_note = value; }
        }

        /// <summary> Gets or sets the name of the file read for this report </summary>
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary> Gets the date this report was created </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary> Gets or sets the number of warnings in this package </summary>
        public int Warnings
        {
            get { return warnings; }
            set { warnings = value; }
        }

        /// <summary> Gets the report type as a string </summary>
        public string Report_Type_String
        {
            get
            {
                switch (type)
                {
                    case FDA_Report_Type.DISSEMINATION:
                        return "Dissemination";

                    case FDA_Report_Type.ERROR:
                        return "Error";

                    case FDA_Report_Type.INGEST:
                        return "Ingest";

                    case FDA_Report_Type.WITHDRAWAL:
                        return "Withdrawal";

                    default:
                        return "INVALID REPORT TYPE";
                }
            }
        }

        public bool Save_To_Database()
        {
            // Try to get the bibid and vid from the package name
            string bibid = String.Empty;
            string vid = String.Empty;
            if ((package.Length == 16) && (package[10] == '_'))
            {
                bibid = package.Substring(0, 10);
                vid = package.Substring(11, 5);
            }

            // If the package name was bib id without VID
            if (package.Length == 10)
            {
                bibid = package;
            }

            return true;

            // Save the report information to the database
            //int reportid = Database.Database_Gateway.FDA_Report_Save(package, ieid, Report_Type_String, date, account, project, warnings, message_note, bibid, vid);

            //// If no error, continue
            //if (reportid > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //    // Step through each file in the package
            //    string warningcode1, warningcode2, warningcode3, warningtext1, warningtext2, warningtext3;
            //    foreach (FDA_File file in files)
            //    {
            //        // Get any warning codes which are linked to this file
            //        if (file.Warnings.Count > 0)
            //        {
            //            warningcode1 = ((FDA_File_Warning)file.Warnings[0]).Code;
            //            warningtext1 = ((FDA_File_Warning)file.Warnings[0]).Text;
            //        }
            //        else
            //        {
            //            warningcode1 = String.Empty;
            //            warningtext1 = String.Empty;
            //        }

            //        if (file.Warnings.Count > 1)
            //        {
            //            warningcode2 = ((FDA_File_Warning)file.Warnings[1]).Code;
            //            warningtext2 = ((FDA_File_Warning)file.Warnings[1]).Text;
            //        }
            //        else
            //        {
            //            warningcode2 = String.Empty;
            //            warningtext2 = String.Empty;
            //        }

            //        if (file.Warnings.Count > 2)
            //        {
            //            warningcode3 = ((FDA_File_Warning)file.Warnings[2]).Code;
            //            warningtext3 = ((FDA_File_Warning)file.Warnings[2]).Text;
            //        }
            //        else
            //        {
            //            warningcode3 = String.Empty;
            //            warningtext3 = String.Empty;
            //        }

            //        // Save to the database
            //        if (!FDA_Database_Gateway.FDA_Report_File_Save(reportid, file.Name, file.ID, file.Preservation, file.Size, file.MD5_Checksum, file.SHA1_Checksum, file.Event, warningcode1, warningtext1, warningcode2, warningtext2, warningcode3, warningtext3))
            //        {
            //            // On error saving, return FALSE
            //            return false;
            //        }
            //    }
            //    // Everything saved fine, so return TRUE
            //    return true;
            //}            
        }

        /// <summary> Returns the basic information about this report </summary>
        /// <returns>Report information as text </returns>
        public override string ToString()
        {
            // Use a string builder
            StringBuilder writer = new StringBuilder();

            // Write the basic data
            writer.Append("------------------------------------------\r\n");
            writer.Append("REPORT:\t\t" + filename + "\r\n");
            writer.Append("TYPE:\t\t" + Report_Type_String + "\r\n" );

            if ( IEID.Length > 0)
            {
                writer.Append("IEID:\t\t" + IEID + "\r\n");
            }

            if (Package.Length > 0)
            {
                writer.Append("PACKAGE:\t" + Package + "\r\n");
            }

            if (Date != null)
            {
                writer.Append("DATE:\t\t" + Date.ToString() + "\r\n");
            }

            if (Account.Length > 0)
            {
                writer.Append("ACCOUNT:\t" + Account + "\r\n");
            }

            if (Project.Length > 0)
            {
                writer.Append("PROJECT:\t" + Project + "\r\n");
            }

            if (Message_Note.Length > 0)
            {
                writer.Append("NOTE:\t\t" + Message_Note + "\r\n");
            }

            // Write the files
            foreach (FDA_File file in Files)
            {
                writer.Append("\r\n");
                writer.Append("\tFILE ID:\t" + file.ID + "\r\n");
                writer.Append("\tNAME:\t\t" + file.Name + "\r\n");
                writer.Append("\tPRESERVATION:\t" + file.Preservation + "\r\n");
                writer.Append("\tSIZE:\t\t" + file.Size + "\r\n");
            }
            return writer.ToString();
        }
    }

    #endregion

    #region FDA File Class

    /// <summary> Class stores all the information about a file which was submitted
    /// to the FDA. </summary>
    public class FDA_File
    {
        private string name, md5_checksum, sha1_checksum, preservation, id, event_text;
        private long size;
        private XmlNode xmlNode;
        private ArrayList warnings;

        /// <summary> Constructor creates a new instance of the FDA_File class </summary>
        public FDA_File()
        {
            // Initialize all values
            name = String.Empty;
            md5_checksum = String.Empty;
            sha1_checksum = String.Empty;
            preservation = String.Empty;
            id = String.Empty;
            event_text = String.Empty;
            size = -1;
            warnings = new ArrayList();
        }

        /// <summary> Constructor creates a new instance of the FDA_File class </summary>
        /// <param name="id">ID for this file in the FDA</param>
        /// <param name="name">Name (or path) of the file</param>
        /// <param name="size">Size of the file</param>
        /// <param name="md5_checksum">MD5 checksum for the file</param>
        /// <param name="sha1_checksum">SHA-1 checksum for the file</param>
        /// <param name="preservation">Preservation level applied to this file</param>
        public FDA_File(string id, string name, long size, string md5_checksum, string sha1_checksum, string preservation)
        {
            // Set all values
            this.name = name;
            this.md5_checksum = md5_checksum;
            this.sha1_checksum = sha1_checksum;
            this.preservation = preservation;
            this.id = id;
            this.size = size;
            event_text = String.Empty;
            warnings = new ArrayList();
        }

        /// <summary> Gets or sets the ID for this file in the FDA </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary> Gets or sets the name (or path) for this file in the FDA </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary> Gets or sets the MD5 checksum result for this file in the FDA </summary>
        public string MD5_Checksum
        {
            get { return md5_checksum; }
            set { md5_checksum = value; }
        }

        /// <summary> Gets or sets the SHA-1 checksum result for this file in the FDA </summary>
        public string SHA1_Checksum
        {
            get { return sha1_checksum; }
            set { sha1_checksum = value; }
        }

        /// <summary> Gets or sets the preservation level for this file in the FDA </summary>
        public string Preservation
        {
            get { return preservation; }
            set { preservation = value; }
        }

        /// <summary> Gets or sets the text of any event linked to this file </summary>
        public string Event
        {
            get { return event_text; }
            set { event_text = value; }
        }

        /// <summary> Gets or sets the size of this file in the FDA </summary>
        public long Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary> Gets or sets the source XML node for this file from the FDA report </summary>
        /// <remarks>This is used when creating a new, more compact version of the FDA Ingest Report</remarks>
        public XmlNode XML_Node
        {
            get { return xmlNode; }
            set { xmlNode = value; }
        }

        /// <summary> Gets the collection of warnings linked to this file </summary>
        /// <remarks>Returned as an ArrayList of FDA_File_Warning objects</remarks>
        public ArrayList Warnings
        {
            get { return warnings; }
        }

        /// <summary> Add a new warning to this file </summary>
        /// <param name="Code"> Warning code for this file-level warning </param>
        /// <param name="Text"> Warning text for this file-level warning </param>
        public void Add_Warning(string Code, string Text)
        {
            warnings.Add(new FDA_File_Warning(Code, Text));
        }
    }

    #endregion

    #region FDA_File_Warning

    /// <summary> Class stores the basic information about a file-level warning in a FDA report </summary>
    public class FDA_File_Warning
    {
        private string code, text;

        /// <summary> Constructor creates a new instance of the FDA_File_Warning class </summary>
        public FDA_File_Warning()
        {
            code = String.Empty;
            text = String.Empty;
        }

        /// <summary> Constructor creates a new instance of the FDA_File_Warning class </summary>
        /// <param name="Code"> Warning code for this file-level warning </param>
        /// <param name="Text"> Warning text for this file-level warning </param>
        public FDA_File_Warning( string Code, string Text )
        {
            code = Code;
            text = Text;
        }

        /// <summary> Gets or sets the code for this file-level warning </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary> Gets or sets the text for this file-level warning </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }

    #endregion

}
