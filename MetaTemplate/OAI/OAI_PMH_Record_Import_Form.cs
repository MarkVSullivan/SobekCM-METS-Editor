#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.BatchImport;
using SobekCM.Resource_Object.OAI;

#endregion

namespace SobekCM.METS_Editor.OAI
{
    public partial class OAI_PMH_Record_Import_Form : Form
    {
        private OAI_Repository_Information repository;
        private List<Constant_Assignment_Control> constant_map_inputs;
        private string mappings_directory;

        /// <summary> Thread in which the processor runs </summary>
        protected Thread processThread;


        public OAI_PMH_Record_Import_Form(OAI_Repository_Information Repository)
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            // Try to create a directory under the application first
            try
            {
                mappings_directory = Application.StartupPath + "\\OAI";
                if (!Directory.Exists(mappings_directory))
                    Directory.CreateDirectory(mappings_directory);
                StreamWriter testWriter = new StreamWriter(mappings_directory + "\\test.txt");
                testWriter.WriteLine("PERMISSIONS TEST");
                testWriter.Flush();
                testWriter.Close();
                File.Delete(mappings_directory + "\\test.txt");
            }
            catch ( Exception ee )
            {
                try
                {
                    mappings_directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\METS Editor\\OAI";
                    if (!Directory.Exists(mappings_directory))
                        Directory.CreateDirectory(mappings_directory);
                    StreamWriter testWriter = new StreamWriter(mappings_directory + "\\test.txt");
                    testWriter.WriteLine("PERMISSIONS TEST");
                    testWriter.Flush();
                    testWriter.Close();
                    File.Delete(mappings_directory + "\\test.txt");
                }
                catch (Exception e)
                {
                    mappings_directory = String.Empty;
                }
            }

            repository = Repository;

            // Get the list of sets 
            bool setPullSuccess = OAI_Repository_Stream_Reader.List_Sets(Repository);

            foreach (KeyValuePair<string, string> set in Repository.Sets)
            {
                setComboBox.Items.Add(set.Key + " ( " + set.Value + " )");
            }

            step1Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step2Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);

            constant_map_inputs = new List<Constant_Assignment_Control>();

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
            constant_map_inputs[1].Mapped_Name = "Aggregation Code";
        }

        private void cancelButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void setComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            step1Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step2Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step3Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            browseButton.Enabled = true;
            folderTextBox.Enabled = true;
            folderLabel.ForeColor = SystemColors.WindowText;


            if (folderTextBox.Text.Trim().Length > 0)
            {
                step4Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            }
            else
            {
                step4Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            }
        }

        private void repositoryDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repository_Details_Form showDetails = new Repository_Details_Form(repository);
            showDetails.ShowDialog();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result  = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (folderTextBox.Text.Trim().Length > 0)
            {
                step4Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
                if (!executeButton.Button_Enabled)
                    executeButton.Button_Enabled = true;
            }
            else
            {
                step4Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
                if (executeButton.Button_Enabled)
                    executeButton.Button_Enabled = false;
            }

        }

        private void executeButton_Button_Pressed(object sender, EventArgs e)
        {
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
            if (( folderTextBox.Text.Trim().Length == 0 ) || ( !Directory.Exists( folderTextBox.Text.Trim() )))
            {
                MessageBox.Show("Enter a valid destination folder.   ","Invalid Destination Folder", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

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
            if (( !Char.IsLetter(first_bibid[0] )) || ( !Char.IsLetter(first_bibid[1] )))
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
            string bibid_start = first_bibid.Substring(0, numbers_start);
            int first_bibid_int = Convert.ToInt32(first_bibid.Substring(numbers_start));

            executeButton.Button_Enabled = false;

            string set_to_import = setComboBox.Text;
            if (set_to_import.IndexOf("(") > 0)
                set_to_import = set_to_import.Substring(0, set_to_import.IndexOf("(")).Trim();

            // Show the progress bar
            progressBar1.Visible = true;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;

            // reset the status label
            labelStatus.Text = "";

            try
            {
                // Create the Processor and assign the Delegate method for event processing.
                OAI_PMH_Importer_Processor processor = new OAI_PMH_Importer_Processor(constantCollection, folderTextBox.Text.Trim(), repository, set_to_import, bibid_start, first_bibid_int, mappings_directory);
                processor.New_Progress +=processor_New_Progress;
                processor.Complete += processor_Complete;

                // Create the thread to do the processing work, and start it.                        
                processThread = new Thread(processor.Do_Work);
                processThread.SetApartmentState(ApartmentState.STA);
                processThread.Start();
            }
            catch (Exception ee)
            {
                // display the error message
                
                ErrorMessageBox.Show("Error encountered while processing!\n\n" + ee.Message, "METS Editor Error", ee);

                Cursor = Cursors.Default;
                progressBar1.Value = progressBar1.Minimum;

                executeButton.Button_Enabled = true;
            }      
        }

        void processor_Complete(int New_Progress, OAI_PMH_Importer_Error_Enum Error_Encountered )
        {
            // update status label
            labelStatus.Text = "Processed " + New_Progress.ToString("#,##0;") + " records";
            progressBar1.Value = progressBar1.Maximum;
            MessageBox.Show("COMPLETE!");

            executeButton.Button_Enabled = true;
        }

        void processor_New_Progress(int New_Progress, int Max_Progress)
        {
             // set the Cursor and ProgressBar back to default values.
            if (progressBar1.Maximum != Max_Progress)
                progressBar1.Maximum = Max_Progress;

            // Just increment the progress bar
            if (progressBar1.Value + 1 > progressBar1.Maximum)
                progressBar1.Value = 0;
            else
                progressBar1.Value = progressBar1.Value + 1;


        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/batch/oai";
                onlineHelp.Start();
            }
            catch
            {

            }
        }


    }
}
