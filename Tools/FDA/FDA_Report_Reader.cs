using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DLC.Tools.FDA
{
    /// <summary> Class is used to read the XML report from FDA </summary>
    public class FDA_Report_Reader
    {
        private static string last_error;

        /// <summary>Reads the FDA report and creates the associated data object </summary>
        /// <param name="fileName">Name (including path) of the report</param>
        /// <returns>All the important data from an ingest report</returns>
        public static FDA_Report_Data Read(string fileName)
        {
            // Clear the last error
            last_error = String.Empty;

            // Load the XML Document
            XmlDocument report_xml = new XmlDocument();
            report_xml.Load(fileName);

            // Create the data repository
            FDA_Report_Data report_data = new FDA_Report_Data();
            report_data.FileName = fileName;

            // Step through
            try
            {
                // Find the REPORT node
                foreach (XmlNode reportNode in report_xml.ChildNodes)
                {
                    if (reportNode.Name == "REPORT")
                    {
                        // Find the relevant node
                        foreach (XmlNode ingestNode in reportNode.ChildNodes)
                        {
                            // Is this the INGEST or DISSEMINATION information?
                            if ((ingestNode.Name == "INGEST") || ( ingestNode.Name == "DISSEMINATION" ))
                            {
                                // Set the report type
                                if (ingestNode.Name == "INGEST")
                                {
                                    report_data.Report_Type = FDA_Report_Type.INGEST;
                                }
                                else
                                {
                                    report_data.Report_Type = FDA_Report_Type.WITHDRAWAL;
                                }

                                // Read the attribute information
                                foreach (XmlAttribute thisAttribute in ingestNode.Attributes)
                                {
                                    switch (thisAttribute.Name)
                                    {
                                        case "IEID":
                                            report_data.IEID = thisAttribute.Value;
                                            break;

                                        case "INGEST_TIME":
                                            string date_string_value = thisAttribute.Value.Replace("-0400 ", "").Replace("-0500 ", "");
                                                string[] split = date_string_value.Split(" ".ToCharArray());
                                                if (split.Length == 5)
                                                {
                                                    string new_date_string = split[1] + " " + split[2] + " " + split[4] + " " + split[3];
                                                    try
                                                    {
                                                        report_data.Date = Convert.ToDateTime(new_date_string);
                                                    }
                                                    catch (Exception ee)
                                                    {
                                                        bool date_rorr = true;
                                                    }
                                                }
                                                else
                                                {
                                                    // Just try to convert it as it is
                                                    try
                                                    {
                                                        report_data.Date = Convert.ToDateTime(thisAttribute.Value);
                                                    }
                                                    catch (Exception ee)
                                                    {
                                                        bool date_rorr2 = true;
                                                    }
                                                }
                                            break;

                                        case "PACKAGE":
                                            report_data.Package = thisAttribute.Value;
                                            break;
                                    }
                                }

                                // Find the AGREEMENT and FILES information
                                foreach (XmlNode childNode in ingestNode.ChildNodes)
                                {
                                    switch (childNode.Name)
                                    {
                                        case "AGREEMENT_INFO":
                                            foreach (XmlAttribute thisAttribute in childNode.Attributes )
                                            {
                                                switch (thisAttribute.Name)
                                                {
                                                    case "ACCOUNT":
                                                        report_data.Account = thisAttribute.Value;
                                                        break;

                                                    case "PROJECT":
                                                        report_data.Project = thisAttribute.Value;
                                                        break;
                                                }
                                            }
                                            break;

                                        case "FILES":
                                            read_file_info(childNode, report_data);
                                            break;
                                    }
                                }

                                // No need to continue through this report anymore
                                break;

                            } // End INGEST or DISSEMINATION node

                            // Is this WITHDRAWAL information?
                            if (ingestNode.Name == "WITHDRAWAL")
                            {
                                // Set the report type
                                report_data.Report_Type = FDA_Report_Type.WITHDRAWAL;

                                // Read the attribute information
                                foreach (XmlAttribute thisAttribute in ingestNode.Attributes)
                                {
                                    switch (thisAttribute.Name)
                                    {
                                        case "IEID":
                                            report_data.IEID = thisAttribute.Value;
                                            break;

                                        case "WITHDRAWAL_TIME":
                                            try
                                            {
                                                report_data.Date = Convert.ToDateTime(thisAttribute.Value);
                                            }
                                            catch { }
                                            break;

                                        case "PACKAGE_NAME":
                                            report_data.Package = thisAttribute.Value;
                                            break;

                                        case "NOTE":
                                            report_data.Message_Note = thisAttribute.Value;
                                            break;
                                    }
                                }

                                // No need to continue through this report anymore
                                break;

                            } // End WITHDRAWAL node

                            // Is this ERROR information?
                            if (ingestNode.Name == "ERROR")
                            {
                                // Set the report type
                                report_data.Report_Type = FDA_Report_Type.ERROR;

                                // Read the attribute information
                                foreach (XmlAttribute thisAttribute in ingestNode.Attributes)
                                {
                                    switch (thisAttribute.Name)
                                    {
                                       case "REJECT_TIME":
                                            try
                                            {
                                                report_data.Date = Convert.ToDateTime(thisAttribute.Value);
                                            }
                                            catch { }
                                            break;
                                    }
                                }

                                // Step through the children nodes
                                foreach (XmlNode childNode in ingestNode.ChildNodes)
                                {
                                    // Is this the MESSAGE?
                                    if (childNode.Name == "MESSAGE")
                                    {
                                        // Remove alot of empty space, if it exists
                                        string message = childNode.InnerText.Replace("\n", ". ").Replace("\r", "");
                                        while (message.IndexOf("  ") >= 0)
                                        {
                                            message = message.Replace("  ", " ");
                                        }

                                        // Save the cleaned up message
                                        report_data.Message_Note = message;                                        
                                    }

                                    // Is this the PACKAGE name?
                                    if (childNode.Name == "PACKAGE")
                                    {
                                        report_data.Package = childNode.InnerText;
                                    }
                                }

                                // No need to continue through this report anymore
                                break;

                            } // End ERROR node

                        } // End stepping through subchildren under REPORT

                    } // End REPORT node

                } // End stepping through all the nodes in the XML document
            }
            catch (Exception ee)
            {
                last_error = ee.ToString();
                return null;
            }

            return report_data;
        }

        public string Last_Exception
        {
            get { return last_error; }
        }


        private static void read_file_info(XmlNode filesNode, FDA_Report_Data report_data)
        {
            // Declare some variables for all the files
            string dfid, global, origin, path, preservation, size;
            ArrayList storage_nodes = new ArrayList();

            // Step through all the individual files
            foreach (XmlNode fileNode in filesNode)
            {
                // Clear the values
                dfid = String.Empty;
                global = String.Empty;
                origin = String.Empty;
                path = String.Empty;
                preservation = String.Empty;
                size = String.Empty;
                storage_nodes.Clear();

                // Parse the attributes associated with this file
                foreach (XmlAttribute fileAttribute in fileNode.Attributes)
                {
                    switch (fileAttribute.Name)
                    {
                        case "DFID":
                            dfid = fileAttribute.Value;
                            break;

                        case "GLOBAL":
                            global = fileAttribute.Value;
                            break;

                        case "ORIGIN":
                            origin = fileAttribute.Value;
                            break;

                        case "PATH":
                            path = fileAttribute.Value;
                            break;

                        case "PRESERVATION":
                            preservation = fileAttribute.Value;
                            break;

                        case "SIZE":
                            size = fileAttribute.Value;
                            break;
                    }
                }

                // Is this a NON-GLOBAL and DEPOSITOR originated file?
                if ((global.ToLower() == "false") && (origin.ToUpper() == "DEPOSITOR"))
                {
                    // This is a valid file to save
                    FDA_File file = new FDA_File();
                    file.ID = dfid;
                    file.Name = path;
                    file.Preservation = preservation;
                    file.XML_Node = fileNode;
                    report_data.Files.Add(file);
                    try
                    {
                        file.Size = Convert.ToInt64(size);
                    }
                    catch { }

                    // Step through the subnodes associated with this file
                    foreach (XmlNode subNode in fileNode)
                    {
                        // Collect the checksums for this file
                        if (subNode.Name == "MESSAGE_DIGEST")
                        {
                            if ((subNode.Attributes.Count > 0) && (subNode.Attributes[0].Value == "MD5"))
                            {
                                file.MD5_Checksum = subNode.InnerText;
                            }
                            if ((subNode.Attributes.Count > 0) && (subNode.Attributes[0].Value == "SHA-1"))
                            {
                                file.SHA1_Checksum = subNode.InnerText;
                            }
                        }

                        // Collect the STORAGE subnodes to remove later
                        if ( subNode.Name == "STORAGE" )
                        {
                            storage_nodes.Add( subNode );
                        }

                        // Count the number of warnings, and save them at the file level
                        if (subNode.Name == "WARNING")
                        {
                            // Increment the warning count
                            report_data.Warnings++;

                            // Get the information about this warning
                            if ((subNode.Attributes.Count > 0) && (subNode.Attributes[0].Name == "CODE"))
                            {
                                // Add this warning to the file
                                file.Add_Warning(subNode.Attributes[0].Value, subNode.InnerText);
                            }
                        }

                        // Get the NOTE from any EVENT listed
                        if (subNode.Name == "EVENT")
                        {
                            // Look for the NOTE subnode
                            foreach (XmlNode eventNode in subNode.ChildNodes)
                            {
                                if (eventNode.Name == "NOTE")
                                {
                                    file.Event = file.Event + eventNode.InnerText + ". ";
                                }
                            }
                        }
                    }

                    // Remove all the storage nodes
                    foreach (XmlNode deleteNode in storage_nodes)
                    {
                        fileNode.RemoveChild(deleteNode);
                    }
                }
            }
        }
    }
}
