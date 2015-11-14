#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DLC.Tools;
using DLC.Tools.Forms;
using GemBox.Spreadsheet;
using SobekCM.Resource_Object;
using ThreadState = System.Threading.ThreadState;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public partial class SpreadSheet_Importer_Form : Form
    {
        private SpreadSheet_Importer_Processor processor;
        protected Thread processThread;
        private DataTable excelDataTbl;
        private List<Column_Assignment_Control> column_map_inputs;
        private List<Constant_Assignment_Control> constant_map_inputs;
        private string filename = String.Empty;

        private string tickler;
        private bool has_bibid_mapping;


        #region Constructor
        public SpreadSheet_Importer_Form()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            tickler = String.Empty;

            column_map_inputs = new List<Column_Assignment_Control>();
            constant_map_inputs = new List<Constant_Assignment_Control>();

            ResetFormControls();

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                browseButton.FlatStyle = FlatStyle.Flat;
                sheetComboBox.FlatStyle = FlatStyle.Flat;
                btnShowData.FlatStyle = FlatStyle.Flat;
            }

            // Create the constants mapping custom control
            // Add eight constant user controls to panel
            for (int i = 1; i < 9; i++)
            {
                Constant_Assignment_Control thisConstantCtrl = new Constant_Assignment_Control();
                thisConstantCtrl.Location = new Point(10, 10 + ((i - 1) * 30));
                pnlConstants.Controls.Add(thisConstantCtrl);
                constant_map_inputs.Add(thisConstantCtrl);
            }

            // set some of the constant columns to required tracking fields
            constant_map_inputs[0].Mapped_Name = "First BibID";
            constant_map_inputs[1].Mapped_Name = "Material Type";
            constant_map_inputs[2].Mapped_Name = "Aggregation Code"; 
        }
        #endregion

        #region Class Events 
        
        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Get rid of any current background image
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            if (ClientSize.Width > 0)
            {
                // Create the items needed to draw the background
                Bitmap image = new Bitmap(ClientSize.Width, ClientSize.Height);
                Graphics gr = Graphics.FromImage(image);
                Rectangle rect = new Rectangle(new Point(0, 0), ClientSize);

                // Create the brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, SystemColors.Control, ControlPaint.Dark(SystemColors.Control), LinearGradientMode.Vertical);
                brush.SetBlendTriangularShape(0.33F);

                // Create the image
                gr.FillRectangle(brush, rect);
                gr.Dispose();

                // Set this as the backgroundf
                BackgroundImage = image;
            }
        }     

        private void sheetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExcelBibliographicReader read = new ExcelBibliographicReader();
            
            try
            {                

                // Make sure there is a filename and a sheet name
                if ((fileTextBox.Text.Length > 0) && (sheetComboBox.SelectedIndex >= 0))
                {
                    // reset the status label
                    labelStatus.Text = "";

                    read.Sheet = sheetComboBox.Text;
                    read.Filename = fileTextBox.Text;

                    // Declare constant fields
                    Constant_Fields constants = new Constant_Fields();

                    columnNamePanel.Controls.Clear();
                    column_map_inputs.Clear();

                    columnNamePanel.Enabled = true;
                    pnlConstants.Enabled = true;

                    // Display an hourglass cursor:
                    Cursor = Cursors.WaitCursor;                         


                    // Try reading data from the selected Excel Worksheet
                    bool readFlag = true;

                    while (readFlag)
                    {

                        try
                        {
                            if (!read.Check_Source())
                            {
                                ResetFormControls();
                                return;
                            }
                            else
                            {
                                readFlag = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorMessageBox.Show(ex.Message, "Unexpected Error", ex);
                        }
                    }
                   

                    // change cursor back to default
                    Cursor = Cursors.Default;

                    excelDataTbl = read.excelData;

                    if (read.excelData.Rows.Count > 0 || read.excelData.Columns.Count > 0)
                    {

                        int column_counter = 1;
                        foreach (DataColumn thisColumn in excelDataTbl.Columns)
                        {

                            // Create the column mapping custom control
                            Column_Assignment_Control thisColControl = new Column_Assignment_Control();

                            // Get the column name
                            string thisColumnName = thisColumn.ColumnName;
                            thisColControl.Column_Name = thisColumnName;
                            if (thisColumnName == "F" + column_counter)
                            {
                                thisColControl.Empty = true;
                            }

                            thisColControl.Location = new Point(10, 10 + ((column_counter - 1) * 30));
                            columnNamePanel.Controls.Add(thisColControl);
                            column_map_inputs.Add(thisColControl);

                            // Select value in list control that matches to a Column Name
                            thisColControl.Select_List_Item(thisColumnName);

                            // Increment for the next column
                            column_counter++;
                        }

                        // Move to STEP 3
                        show_step_3();

                        if (column_map_inputs.Count > 0)
                            // Move to STEP 4
                            show_step_4();                       
                    }


                    // Close the reader
                    read.Close();

                }

            }
            catch (Exception ex)
            {
                ErrorMessageBox.Show(ex.Message, "Unexpected Error", ex);
            }
            finally
            {
                // change cursor back to default
                Cursor = Cursors.Default;

                // Close the reader
                read.Close();
            }
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            // Make sure there are rows in the data table
            if (excelDataTbl.Rows.Count >= 0)
            {
                DataGridForm showData = new DataGridForm(excelDataTbl);
                showData.ShowDialog();
            }
        }

        private void MainForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            // The closed event for this form has been invoked.
            // Check if the Processor thread is running.  If the
            // thread is running, idle the current thread so that the 
            // Processor delegate function can write data to 
            // an Excel worksheet.

            try
            {
                // check if the Processor thread is running
                if ((processThread != null) && (processThread.ThreadState == ThreadState.Running))
                {
                    // set flag to indicate that the Process thread will be
                    // aborted tbe next time through the delegate method - 
                    // processor_Volume_Processed()

                    processor.StopThread = true;
                    Thread.Sleep(100);
                }
            }
            catch { }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            Browse_Source();
        }

        private void sourceMenuItem_Click(object sender, EventArgs e)
        {
            Browse_Source();
        }

        private void directoryTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            Browse_Source();
        }
       
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
   
        #endregion

        #region Class Methods

        private void Browse_Source()
        {
            // reset the status label
            labelStatus.Text = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                ExcelBibliographicReader read = new ExcelBibliographicReader();
                List<string> tables;

                try
                {
                    // Set form controls to default state   
                    ResetFormControls();

                    // Write the filename to the text box first
                    fileTextBox.Text = openFileDialog1.FileName;
                    filename = openFileDialog1.FileName;


                    // Try getting the worksheet names from the selected workbook
                    bool readFlag = true;

                    if ((true) || (filename.ToUpper().IndexOf(".XLS") > 0))
                    {
                        while (readFlag)
                        {

                            try
                            {

                                // Get the sheet names
                                read = new ExcelBibliographicReader();
                                tables = read.GetExcelSheetNames(openFileDialog1.FileName);


                                if (tables == null)
                                {
                                    ResetFormControls();
                                    return;
                                }
                                else
                                {
                                    readFlag = false;

                                    // Populate the combo box
                                    sheetComboBox.Enabled = true;
                                    foreach (string thisSheetName in tables)
                                        sheetComboBox.Items.Add(thisSheetName);
                                    sheetComboBox.Enabled = true;
                                    sheetLabel.ForeColor = SystemColors.WindowText;

                                    // show step 2 instructions
                                    show_step_2();
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorMessageBox.Show(ex.Message, "Unexpected Error", ex);
                            }
                        }
                    }
                    else
                    {

                        // show step 2 instructions
                        show_step_2();

                        sheetComboBox.Items.Clear();
                        sheetComboBox.Enabled = false;
                        sheetLabel.ForeColor = SystemColors.GrayText;


                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageBox.Show(ex.Message, "Unexpected Error", ex);
                }
                finally
                {
                    // Close the reader
                    read.Close();
                }
            }
            else
            {
                // reset the form
                ResetFormControls();

                // Move to STEP 1
                show_step_1();
            }
        }                 

        /// <summary> Imports the records from the indicated source file </summary>
        protected void Import_Records(DataTable inputFile)
        {
            // update class variable
            excelDataTbl = inputFile;

            // Display an hourglass cursor and set max value on the ProgressBar
            progressBar1.Maximum = Total_Records;
                                   
            // Step through each column map control
            List<Mapped_Fields> mapping = new List<Mapped_Fields>();      
            foreach (Column_Assignment_Control thisColumn in column_map_inputs)
            {
                mapping.Add(thisColumn.Mapped_Field);            
            }

            // Step through each constant map control
            Constant_Fields constantCollection = new Constant_Fields();
            string first_bibid = String.Empty;

            foreach (Constant_Assignment_Control thisConstant in constant_map_inputs)
            {
                if (thisConstant.Mapped_Name == "First BibID")
                {
                    first_bibid = thisConstant.Mapped_Constant;
                }
                else
                {
                    constantCollection.Add(thisConstant.Mapped_Field, thisConstant.Mapped_Constant);
                }
            }

            // validate the form     
            if ((folderTextBox.Text.Trim().Length == 0) || (!Directory.Exists(folderTextBox.Text.Trim())))
            {
                MessageBox.Show("Enter a valid destination folder.   ", "Invalid Destination Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If a column was mapped to BibID, skip this
            string bibid_start = "nobib";
            int first_bibid_int = 0;
            if (!has_bibid_mapping)
            {
                if (first_bibid.Length < 3)
                {
                    MessageBox.Show("You must enter a constant for the 'First BibID' value and it must begin with two letters.   \n\nThis is the first ObjectID that will be used for the resulting METS files.      ", "Choose First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (first_bibid.Length > 10)
                {
                    MessageBox.Show("The complete BibID/ObjectID cannot be longer than 10 digits.      ", "Invalid First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pad the bibid to 10 digits, in case it is not 10
                first_bibid = first_bibid.PadRight(10, '0');

                // First two must be characters
                if ((!Char.IsLetter(first_bibid[0])) || (!Char.IsLetter(first_bibid[1])))
                {
                    MessageBox.Show("You must enter a constant for the 'First BibID' value and it must begin with two letters.   \n\nThis is the first ObjectID that will be used for the resulting METS files.      ", "Choose First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check that it ends in numbers
                if ((!Char.IsNumber(first_bibid[9])) || (!Char.IsNumber(first_bibid[8])) || (!Char.IsNumber(first_bibid[7])) || (!Char.IsNumber(first_bibid[6])))
                {
                    MessageBox.Show("The last four digits of the BibID must be numeric.    \n\nTry shortening the length or changing trailing characters to numers.      ", "Invalid First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Try to break the first_bibid up into character portion and number portion
                int numbers_start = 9;
                for (int i = 9; i >= 0; i--)
                {
                    if (!Char.IsNumber(first_bibid[i]))
                    {
                        numbers_start = i + 1;
                        break;
                    }
                }
                bibid_start = first_bibid.Substring(0, numbers_start);
                first_bibid_int = Convert.ToInt32(first_bibid.Substring(numbers_start));
            }
                       
            //add columns to the input data table  
            if (!excelDataTbl.Columns.Contains("New BIB ID"))
                excelDataTbl.Columns.Add("New BIB ID");
            else
            {
                excelDataTbl.Columns.Remove("New BIB ID");
                excelDataTbl.Columns.Add("New BIB ID");
            }

            if (!excelDataTbl.Columns.Contains("New VID"))
                excelDataTbl.Columns.Add("New VID");
            else
            {
                excelDataTbl.Columns.Remove("New VID");
                excelDataTbl.Columns.Add("New VID");
            }

            //if (!excelDataTbl.Columns.Contains("Messages"))
            //    excelDataTbl.Columns.Add("Messages");
            //else
            //{
            //    excelDataTbl.Columns.Remove("Messages");
            //    excelDataTbl.Columns.Add("Messages");
            //}

            // disable some of the form controls
            Disable_FormControls();

            // Change color on both the 'step3' and 'step 4 labels
            step3Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step4Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step5Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);

            // Toggle the button text
            executeButton.Button_Text = "STOP";
            cancelButton.Button_Text = "CLEAR";

            // enable the Stop button
            executeButton.Button_Enabled = true;

            // Show the progress bar
            progressBar1.Visible = true;
            progressBar1.Value = progressBar1.Minimum;
            Cursor = Cursors.WaitCursor;

            // reset the status label
            labelStatus.Text = "";

            // Write the current mappings, etc..
            write_mappings_and_constants( inputFile, mapping, constantCollection);

            try
            {
                // Create the Processor and assign the Delegate method for event processing.
                processor = new SpreadSheet_Importer_Processor(inputFile, mapping, constantCollection, folderTextBox.Text.Trim(), bibid_start, first_bibid_int);
                processor.New_Progress += processor_New_Progress;
                processor.Complete += processor_Complete;

                // Create the thread to do the processing work, and start it.            
                processThread = new Thread(processor.Do_Work);
                processThread.SetApartmentState(ApartmentState.STA);    
                processThread.Start();
            }
            catch (Exception e)
            {
                // display the error message
                ErrorMessageBox.Show("Error encountered while processing!\n\n" + e.Message, "DLC Importer Error", e);
                                    
                // enable form controls on the Importer form                    
                Enable_FormControls();

                Cursor = Cursors.Default;
                progressBar1.Value = progressBar1.Minimum;
            }           
        }

        private void write_mappings_and_constants( DataTable inputFile, List<Mapped_Fields> mapping, Constant_Fields constantCollection)
        {
            try
            {
                string mapping_name = filename + ".importdata";
                StreamWriter mappingWriter = new StreamWriter(mapping_name, false);
                mappingWriter.WriteLine("MAPPING:");
                int column = 0;
                foreach (Mapped_Fields mappedField in mapping)
                {
                    mappingWriter.WriteLine("\t\"" + inputFile.Columns[column].ColumnName.Replace("\"", "&quot;") + "\" --> " + Bibliographic_Mapping.Mapped_Field_To_String( mappedField ) );
                    column++;
                }
                mappingWriter.WriteLine();
                mappingWriter.WriteLine("CONSTANTS:");
                foreach (Constant_Field_Data constantData in constantCollection.constantCollection )
                {
                    if ((constantData.Data.Length > 0) && (constantData.Field != Mapped_Fields.None))
                    {
                        mappingWriter.WriteLine("\t" + Bibliographic_Mapping.Mapped_Field_To_String(constantData.Field) + " <-- \"" + constantData.Data.Replace("\"", "&quot;"));
                    }
                }

                mappingWriter.Flush();
                mappingWriter.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to save the import data for this job.    \n\n" + ee, "Error saving mapping", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void processor_Complete(int New_Progress)
        {
            // Check to see if Processor thread should be stopped
            if ((processor != null) && (processor.StopThread))
            {
                try
                {
                    // terminate the Processor thread
                    processThread.Abort();
                    processThread.Join();
                    processor = null;
                }

                catch (ThreadAbortException)
                {

                    // A ThreadAbortException has been invoked on the
                    // Processor thread.  Write the import data to an
                    // Excel worksheet and update the form controls only
                    // if the MainForm is not being disposed.

                    // update the status controls on this form
                    if (!Disposing)
                    {
                        labelStatus.Text = "Processing stopped at record " + (progressBar1.Value + 1).ToString("#,##0;") + " of " + progressBar1.Maximum.ToString("#,##0;") + " records";
                        progressBar1.Value = progressBar1.Minimum;
                        Cursor = Cursors.Default;
                    }

                    try
                    {
                        // Create an Excel Worksheet named 'Output' on the input data file,  
                        // and write the importer results to the spreadsheet.
                        Export_as_Excel();
                    }
                    catch { }
                    finally
                    {
                        // create a table to display the results
                        DataTable displayTbl = processor.Report_Data.Copy();

                        // create the Results form             
                        Results_Form showResults = new Results_Form(displayTbl, processor.Importer_Type, false);

                        // hide the Importer form                  
                        Hide();

                        // show the Results form
                        showResults.ShowDialog();

                        // enable form controls on the Importer form                    
                        Enable_FormControls();

                        // show the Importer form
                        ShowDialog();
                    }
                }
                catch { }

            }
            else
            {
                // The complete flag is true, set the Cursor and ProgressBar back to default values.
                Cursor = Cursors.Default;
                progressBar1.Value = progressBar1.Minimum;

                // disable the Stop button
                executeButton.Button_Enabled = false;

                try
                {
                    // Create an Excel Worksheet named 'Output' on the input data file,  
                    // and write the importer results to the spreadsheet.
                    Export_as_Excel();
                }
                catch { }
                finally
                {
                    // create a table to display the results
                    DataTable displayTbl = processor.Report_Data.Copy();

                    // create the Results form             
                    Results_Form showResults = new Results_Form(displayTbl, processor.Importer_Type, false);

                    // hide the Importer form                  
                    Hide();

                    // show the Results form
                    showResults.ShowDialog();

                    // enable form controls on the Importer form                    
                    Enable_FormControls();

                    // show the Importer form
                    ShowDialog();
                }
            }    
        }

        void processor_New_Progress(int New_Progress)
        {
            // Just increment the progress bar
            progressBar1.Value = New_Progress % progressBar1.Maximum;


            // update status label
            labelStatus.Text = "Processed " + progressBar1.Value.ToString("#,##0;") + " of " + progressBar1.Maximum.ToString("#,##0;") + " records";
        }

        #region Method to export as excel

        public void Export_as_Excel()
        {
            string SHEET_NAME = "OUTPUT";

            // Now, output the data table values to the MS Excel Workbook
            try
            {
                string workbookPath = filename;

                // Load the Excel file
                ExcelFile excelFile = new ExcelFile();
                if (filename.ToLower().IndexOf(".xls") > 0)
                {
                    if (filename.ToLower().IndexOf(".xlsx") > 0)
                        excelFile.LoadXlsx(filename, XlsxOptions.PreserveMakeCopy);
                    else
                        excelFile.LoadXls(filename);
                }
                if (filename.ToLower().IndexOf(".csv") > 0)
                {
                    excelFile.LoadCsv(filename, ',');
                }

                // If there is more than one worksheet and there is one with the matching SHEET_NAME
                // then delete that sheet.  This allows for a new OUTPUT or PREVIEW worksheet to 
                // be added, and delete any existing one
                if (excelFile.Worksheets.Count > 1)
                {
                    ExcelWorksheet deleteSheet = null;
                    foreach (ExcelWorksheet thisSheet in excelFile.Worksheets)
                    {
                        if (thisSheet.Name.ToUpper() == SHEET_NAME)
                        {
                            //suppress Excel prompts and delete the 'Output' Worksheet
                            deleteSheet = thisSheet;
                            break;
                        }
                    }
                    if (deleteSheet != null)
                        deleteSheet.Delete();
                }

                // Add a new worksheet
                ExcelWorksheet excelSheet = null;
                if (filename.ToLower().IndexOf(".csv") > 0)
                {
                    excelSheet = excelFile.Worksheets[0];
                }
                else
                {
                    excelSheet = excelFile.Worksheets.Add(SHEET_NAME);
                    excelFile.Worksheets.ActiveWorksheet = excelSheet;
                }

                // Create the header cell style
                CellStyle headerStyle = new CellStyle();
            //    headerStyle.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                headerStyle.FillPattern.SetSolid(Color.Khaki);
                headerStyle.Font.Weight = ExcelFont.BoldWeight;
                headerStyle.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
               

                // Create the new BibID/VID header cell style
                CellStyle headerStyle2 = new CellStyle();
            //    headerStyle2.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                headerStyle2.FillPattern.SetSolid(Color.Gainsboro);
                headerStyle2.Font.Weight = ExcelFont.BoldWeight;
                headerStyle2.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);

            //    // Create the new Messages header cell style
            //    CellStyle headerStyle3 = new CellStyle();
            ////    headerStyle3.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            //    headerStyle3.FillPattern.SetSolid(Color.Tomato);
            //    headerStyle3.Font.Weight = ExcelFont.BoldWeight;
            //    headerStyle3.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
                

                // Create the title cell style
                CellStyle titleStyle = new CellStyle();
                titleStyle.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                titleStyle.FillPattern.SetSolid(Color.LightSkyBlue);
                titleStyle.Font.Weight = ExcelFont.BoldWeight;
                titleStyle.Font.Size = 14 * 20;

                // Set the default style
                CellStyle defaultStyle = new CellStyle();
                defaultStyle.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);

                // Add the title
                excelSheet.Cells[0, 0].Value = SHEET_NAME;
                excelSheet.Cells[0, 0].Style = titleStyle;

                // Add the header values
                for (int i = 0; i < excelDataTbl.Columns.Count; i++)
                {
                    excelSheet.Cells[1, i].Value = excelDataTbl.Columns[i].ColumnName.ToUpper();

                    int difference = excelDataTbl.Columns.Count - i;
                    if (difference <= 2)
                    {
                        excelSheet.Cells[1, i].Style = headerStyle2;
                    }
                    else
                    {
                        excelSheet.Cells[1, i].Style = headerStyle;
                    }
                }

                // Add each piece of data
                int rowNumber = 2;
                foreach (DataRow thisRow in excelDataTbl.Rows)
                {
                    // Add each cell
                    for (int i = 0; i < excelDataTbl.Columns.Count; i++)
                    {
                        if (!thisRow[excelDataTbl.Columns[i]].Equals(DBNull.Value))
                            excelSheet.Cells[rowNumber, i].Value = thisRow[excelDataTbl.Columns[i]].ToString();
                        else
                            excelSheet.Cells[rowNumber, i].Value = "";
                        excelSheet.Cells[rowNumber, i].Style = defaultStyle;
                    }

                    // Go to next row
                    rowNumber++;
                }

                // Get the final end range for the columns
                String endRange = String.Empty;
                String bibid_col = String.Empty;
                String vidid_col = String.Empty;
                if (excelDataTbl.Columns.Count < 26)
                {
                    int range = (64 + excelDataTbl.Columns.Count);
                    endRange = Convert.ToString((char)range);
                    bibid_col = Convert.ToString((char)(range - 2));
                    vidid_col = Convert.ToString((char)(range - 1));
                }
                else if (excelDataTbl.Columns.Count == 26)
                {
                    int range = (90);   // ASCII 'Z' character
                    endRange = Convert.ToString((char)range);
                    bibid_col = Convert.ToString((char)(range - 2));
                    vidid_col = Convert.ToString((char)(range - 1));
                }
                else if (excelDataTbl.Columns.Count > 26)
                {
                    double column_count = excelDataTbl.Columns.Count;
                    int first_char_ascii = (int)(64 + (Math.Floor(column_count / 26)));
                    int second_char_ascii = (int)(64 + (column_count % 26));

                    // set the end range
                    endRange = Convert.ToString((char)first_char_ascii) + Convert.ToString((char)second_char_ascii);

                    // format the the column header values
                    if (second_char_ascii > Convert.ToInt32('B'))
                    {
                        bibid_col = Convert.ToString((char)first_char_ascii) + Convert.ToString((char)(second_char_ascii - 2));
                        vidid_col = Convert.ToString((char)first_char_ascii) + Convert.ToString((char)(second_char_ascii - 1));
                    }
                    else if (second_char_ascii == Convert.ToInt32('B'))
                    {
                        bibid_col = Convert.ToString((char)(first_char_ascii - 1)) + "Z";
                        vidid_col = Convert.ToString((char)first_char_ascii) + Convert.ToString((char)(second_char_ascii - 1));

                        bibid_col = bibid_col.Replace("@", "");
                    }
                    else
                    {
                        bibid_col = Convert.ToString((char)(first_char_ascii - 1)) + Convert.ToString((char)(Convert.ToInt32('Z') - 1));
                        vidid_col = Convert.ToString((char)(first_char_ascii - 1)) + "Z";

                        bibid_col = bibid_col.Replace("@", "");
                        vidid_col = vidid_col.Replace("@", "");
                    }
                }

                // Set some header properties
                excelSheet.Cells.GetSubrange("A1", endRange + "1").Merged = true;
                excelSheet.Rows[0].Height = 512;
                excelSheet.Rows[1].Height = 512;

                // Set the width on the last columns
                excelSheet.Columns[excelDataTbl.Columns.Count - 2].Width = 18 * 256;
                excelSheet.Columns[excelDataTbl.Columns.Count - 1].Width = 14 * 256;

                // Set the border
                excelSheet.Cells.GetSubrange("A2", endRange + rowNumber.ToString()).SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Medium);
                excelSheet.Cells.GetSubrange("A2", endRange + "2").SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Medium);

                if (filename.ToLower().IndexOf(".xls") > 0)
                {
                    if (filename.ToLower().IndexOf(".xlsx") > 0)
                        excelFile.SaveXlsx(filename);
                    else
                        excelFile.SaveXls(filename);
                }
                if (filename.ToLower().IndexOf(".csv") > 0)
                {
                    FileInfo newFileInfo = new FileInfo(filename);
                    string outputfile = newFileInfo.Directory + "\\" + newFileInfo.Name.Replace(newFileInfo.Extension, "") + "_output.csv";
                    excelFile.SaveCsv(outputfile, ',');
                }

            }
            catch (Exception e)
            {
                ErrorMessageBox.Show("Error while saving the Excel Worksheet.\n\n" + e.Message, "Excel Error", e);
            }
        }

        #endregion

        private void ResetFormControls()
        {
            // Set form controls to default state  
            
            // enable the Browse button and the related Menu Item
            browseButton.Enabled = true;
            fileTextBox.Clear();
            fileTextBox.Enabled = true;

            // disable worksheet list and Show Data Button
            sheetComboBox.Items.Clear();
            sheetComboBox.Enabled = false;
            btnShowData.Visible = false;
            btnShowData.Enabled = false;

            // enable the Clear/Exit button and the related Menu Item
            cancelButton.Button_Text = "EXIT";
            cancelButton.Button_Enabled = true;

            // disable the Execute/Stop button and the related Menu Item
            executeButton.Button_Enabled = false;
            
            // disable the Column Mappings and Constants Tab Panels
            columnNamePanel.Controls.Clear();
            column_map_inputs.Clear();
            tabControl1.SelectedIndex = 0;
            tabControl1.Enabled = false;
          
            // reset the status label
            labelStatus.Text = "";

            Cursor = Cursors.Default;
           
            // Move to STEP 1
            show_step_1();
        }

        private void Disable_FormControls()
        {
            // Disable the Browse button and the related Menu Item
            browseButton.Enabled = false;
            browse2Button.Enabled = false;
            fileTextBox.Enabled = false;
            btnShowData.Enabled = false;

            // Disable worksheet list box
            sheetComboBox.Enabled = false;

            // Disable Tab Panel
            columnNamePanel.Enabled = false;
            pnlConstants.Enabled = false;
            
            // Disable the Execute/Stop button and the related Menu Item
            executeButton.Button_Enabled = false;

            // Disable the Clear/Exit button and the related Menu Item
            cancelButton.Button_Enabled = false;
        }

        private void Enable_FormControls()
        {

            // Enable the Browse button and the related Menu Item
            browseButton.Enabled = true;
            browse2Button.Enabled = true;
            fileTextBox.Enabled = true;
            btnShowData.Enabled = true;

            // Enable worksheet list box
            sheetComboBox.Enabled = true;

            // Enable Tab Panel
            columnNamePanel.Enabled = true;
            pnlConstants.Enabled = true;

            // Enable the Execute/Stop button and the related Menu Item
            executeButton.Button_Text = "EXECUTE";
            executeButton.Button_Enabled = true;

            // Enable the Clear/Exit button and the related Menu Item
            cancelButton.Button_Text = "EXIT";
            cancelButton.Button_Enabled = true;
        }

        private bool Validate_Columns()
        {            
            bool retValue = false;
            has_bibid_mapping = false;

            if (excelDataTbl.Rows.Count >= 0)
            {
                // Check column and constant mappings to determine if the required fields 
                // necessary to create a recored in the tracking database exist. 

                // collection for holding error messages
                StringCollection errors = new StringCollection();
                string material_type = String.Empty;
                bool hasTitle = false;
                bool hasType = false;

                // step through each column mapping
                // check if required field is mapped to a column in the input file
                foreach (Column_Assignment_Control thisColumn in column_map_inputs)
                {
                    // check title
                    //if (thisColumn.Mapped_Name.Equals("Title"))
                    if ((thisColumn.Mapped_Name.Equals("Bib (Series) Title"))
                            || (thisColumn.Mapped_Name.Equals("Bib (Uniform) Title"))
                            || (thisColumn.Mapped_Name.Equals("Title")))                                                                             
                    {
                        hasTitle = true;
                        continue;
                    }

                    // check material type
                    if (thisColumn.Mapped_Name.Equals("Material Type"))
                    {
                        hasType = true;
                        continue;
                    }

                    // check material type
                    if (thisColumn.Mapped_Name.Equals("BibID"))
                    {
                        has_bibid_mapping = true;
                        continue;
                    }

                    if (hasTitle && hasType && has_bibid_mapping)
                        break;
                }

                // step through each constant mapping        
                // check if required field has been selected from the Constants tab control, 
                // and that data has been selected from the adjoining combo box
                foreach (Constant_Assignment_Control thisConstant in constant_map_inputs)
                {

                    // check material type
                    if ((thisConstant.Mapped_Name.Equals("Material Type"))
                            && (thisConstant.Mapped_Constant.Length > 0))
                    {
                        hasType = true;
                        material_type = thisConstant.Mapped_Constant;
                        continue;
                    }
                    
                    if (hasType )
                        break;
                }                
               
                // check flags and assign any error messages

                // Title exist?
                if (!hasTitle)
                    //errors.Add("Title is missing");
                    errors.Add("At least one Title (Bib and/or Volume) value is required");


                // Material Type exist?
                if (!hasType)
                    errors.Add("Material Type is missing");              
                            
                       
                             
                 if (!hasType )
                    tabControl1.SelectedIndex = 1;   



                // if there were validation errors, build error message array                
                if (errors.Count > 0)
                {
                    retValue = false;
                    string[] missing = new string[errors.Count];

                    for (int i = 0; i < errors.Count; i++)
                    {
                        missing[i] = errors[i];
                    }

                    if (missing.Length > 0)
                    {
                        string message = "The following required fields are either missing or invalid:               \n\n";

                        foreach (string thisMissing in missing)
                            message = message +  "* " + thisMissing + "\n\n";
                        MessageBox.Show(message + "\nPlease complete these fields to continue.", "Invalid Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // redisplay step 4 instructions
                        show_step_4();
                    }
                }
                else
                    // passed form validation
                    retValue = true;                
            }

            return retValue;
        }
                    
        private void show_step_1()
        {
            // show Step 1 instructions
            step1Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step2Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step3Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step5Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption); 
        }

        private void show_step_2()
        {
                // show Step 2 instructions
				step1Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
                step2Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
        }

        private void show_step_3()
        {
            // show Step 3 instructions
            step2Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step3Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            panel1.Visible = true;

            // Enable form controls
            btnShowData.Enabled = true;
            btnShowData.Visible = true;
            tabControl1.Enabled = true;
        }

        private void show_step_4()
        {
            // show Step 4 instructions
            step3Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step4Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            browse2Button.Enabled = true;
            folderLabel.ForeColor = SystemColors.WindowText;
            folderTextBox.Enabled = true;
            step5Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);

            // Enable form controls
            Enable_FormControls();
        }
                   

        public int Total_Records
        {
            get
            {
                // count the number of valid records in the input table
                int counter = 0;

                // check for empty rows
                foreach (DataRow row in excelDataTbl.Rows)
                {

                    bool empty_row = true;
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        if (row[i].ToString().Length > 0)
                        {
                            empty_row = false;
                            counter++;
                            break;
                        }
                    }

                    if (empty_row)
                    {
                        // continue to next row in the input table
                        continue;
                    }
                }

                return counter;
            }
        }
        #endregion      

        /// <summary> Last tickler assigned through the form, during an import </summary>
        public string Last_Tickler
        {
            get
            {
                return tickler;
            }
        }

        public void Show_Form()
        {
            // show the SpreadSheet Importer form
            if (this != null)
                ShowDialog();
        }

        private void executeButton_Button_Pressed(object sender, EventArgs e)
        {
            if (executeButton.Button_Text.ToUpper().Equals("EXECUTE"))
            {
                // Make sure there are rows in the data table
                if (excelDataTbl.Rows.Count >= 0)
                {
                    if (!Validate_Columns())
                    {
                        executeButton.Button_Text = "EXECUTE";
                        cancelButton.Button_Text = "EXIT";
                        return;
                    }
                    else
                    {
                        // Import Records                   
                        Import_Records(excelDataTbl);
                    }
                }
                else
                {
                    executeButton.Button_Text = "EXECUTE";
                }
            }
            else if (executeButton.Button_Text.ToUpper().Equals("STOP"))
            {

                // Toggle the button text               
                Disable_FormControls();
                cancelButton.Button_Enabled = true;


                try
                {
                    // check if the Processor thread is running
                    if ((processThread != null) && (processThread.ThreadState == ThreadState.Running))
                    {
                        // Set flag to indicate that the Process thread will be
                        // aborted tbe next time through the delegate method: 
                        // processor_Volume_Processed().

                        processor.StopThread = true;
                        Thread.Sleep(250);
                    }
                }
                catch
                {
                }
            }
        }

        private void cancelButton_Button_Pressed(object sender, EventArgs e)
        {
            if (cancelButton.Button_Text.ToUpper().Equals("CLEAR"))
            {
                // reset the form to its default state
                ResetFormControls();

                // Toggle the button text
                cancelButton.Button_Text = "EXIT";
                executeButton.Button_Text = "EXECUTE";

            }
            else if (cancelButton.Button_Text.ToUpper().Equals("EXIT"))
            {
                Close();
            }
        }

        private void browse2Button_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/batch/spreadsheet";
                onlineHelp.Start();
            }
            catch
            {

            }
        }

        private void folderTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
