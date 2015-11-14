using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DLC.Tools.FDA
{
    /// <summary> Class is used to write the FDA Report data in various formats </summary>
    public class FDA_Report_Writer
    {
        /// <summary> Writes the basic information about a FDA report as a text file </summary>
        /// <param name="report_data">FDA Report information</param>
        /// <param name="fileName">Name for the text output file</param>
        /// <returns>Flag indicating if the report creation was successful</returns>
        public static bool Write_Text(FDA_Report_Data report_data, string fileName)
        {
            try
            {
                // Open connection to file
                StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);

                // Write the information from the data
                writer.WriteLine(report_data.ToString());

                // Finish writing
                writer.Flush();
                writer.Close();

                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to create text report from FDA data.\n\n" + fileName + "\n\nException caught...\n\n" + ee.ToString(), "Text Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary> Writes the basic information about a FDA ingest report as a valid XML file </summary>
        /// <param name="report_data">FDA Report information</param>
        /// <param name="fileName">Name for the XML output file</param>
        /// <returns>Flag indicating if the report creation was successful</returns>
        public static bool Write(FDA_Report_Data report_data, string fileName )
        {
            try
            {
                // Only continue if this is an INGEST or DISSEMINATION report
                if ((report_data.Report_Type != FDA_Report_Type.INGEST) && (report_data.Report_Type != FDA_Report_Type.DISSEMINATION))
                    return true;

                // Open connection to file
                StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);

                // Start this XML file
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                // writer.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"daitss_report_xhtml.xsl\"?>");
                writer.WriteLine("<REPORT xmlns=\"http://www.fcla.edu/dls/md/daitss/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.fcla.edu/dls/md/daitss/ http://www.fcla.edu/dls/md/daitss/daitssReport.xsd\">");
                writer.WriteLine("<" + report_data.Report_Type_String.ToUpper() + " IEID=\"" + report_data.IEID + "\" INGEST_TIME=\"" + format_date(report_data.Date) + "\" PACKAGE=\"" + report_data.Package + "\">");
                writer.WriteLine("<AGREEMENT_INFO ACCOUNT=\"" + report_data.Account + "\" PROJECT=\"" + report_data.Project + "\" />");

                // Write the file information
                writer.WriteLine("<FILES>");

                // Write the files
                foreach (FDA_File file in report_data.Files)
                {
                    writer.WriteLine(file.XML_Node.OuterXml);
                }

                writer.WriteLine("</FILES>");
                writer.WriteLine("</INGEST>");
                writer.WriteLine("</REPORT>");

                // Finish writing
                writer.Flush();
                writer.Close();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to create XML report from FDA data.\n\n" + fileName + "\n\nException caught...\n\n" + ee.ToString(), "Text Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string format_date(DateTime date2)
        {
            DateTime date = date2.ToUniversalTime();
            return date.Year + "-" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Day.ToString().PadLeft(2, '0') + "T" +
                date.Hour.ToString().PadLeft(2, '0') + ":" + date.Minute.ToString().PadLeft(2, '0') + ":" + date.Second.ToString().PadLeft(2, '0') + "Z";
        }
    }
}
