#region Using directives

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public partial class Batch_Import_Directory_Traverse_Form : Form
    {
        private Thread processThread;

        public Batch_Import_Directory_Traverse_Form()
        {
            InitializeComponent();

            if (MetaTemplate_UserSettings.Directory_Batching_Metadata_Filter.Length > 0)
                metadataFilterComboBox.Text = MetaTemplate_UserSettings.Directory_Batching_Metadata_Filter;
            else
                metadataFilterComboBox.SelectedIndex = 1;

            if (MetaTemplate_UserSettings.Directory_Batching_Metadata_Type_Index >= 0)
                metadataComboBox.SelectedIndex = MetaTemplate_UserSettings.Directory_Batching_Metadata_Type_Index;
            else
                metadataComboBox.SelectedIndex = 2;

            switch (MetaTemplate_UserSettings.Directory_Batching_METS_ObjectID_Index)
            {
                case 1:
                    objectIdFileNameRadioButton.Checked = false;
                    objectIdFolderNameRadioButton.Checked = true;
                    objectIdNewRadioButton.Checked = false;
                    break;

                case 2:
                    objectIdFileNameRadioButton.Checked = false;
                    objectIdFolderNameRadioButton.Checked = false;
                    objectIdNewRadioButton.Checked = true;
                    break;

                default:
                    objectIdFileNameRadioButton.Checked = true;
                    objectIdFolderNameRadioButton.Checked = false;
                    objectIdNewRadioButton.Checked = false;
                    break;
            }            
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            if ((parentDirTextBox.Text.Trim().Length == 0) || (!Directory.Exists(parentDirTextBox.Text.Trim())))
            {
                MessageBox.Show("Enter a valid directory to recurse through all subdirectories recursively.      ", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((Directory.GetDirectories(parentDirTextBox.Text.Trim()).Length == 0) && ( Directory.GetFiles( parentDirTextBox.Text.Trim() ).Length == 0 ))
            {
                MessageBox.Show("Parent directory has no subdirectories and no files!   ", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (metadataFilterComboBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a filter for the metadata file names.    \n\nExamples: '*.mets.xml', '*.xml', '*.mods', etc..  ", "Invalid File Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string bibid_start = String.Empty;
            int first_bibid_int = -1;
            if (objectIdFileNameRadioButton.Checked)
                first_bibid_int = -2;
            if (objectIdNewRadioButton.Checked)
            {
                string first_bibid = firstBibIdTextBox.Text.Trim();
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

            string filter = metadataFilterComboBox.Text.Trim();
            string directory = parentDirTextBox.Text.Trim();
            string metadata_type = metadataComboBox.Text.Trim().ToUpper();

            parentDirTextBox.Enabled = false;
            metadataComboBox.Enabled = false;
            metadataFilterComboBox.Enabled = false;
            browseButton.Enabled = false;
            objectIdFolderNameRadioButton.Enabled = false;
            objectIdFileNameRadioButton.Enabled = false;
            firstBibIdTextBox.Enabled = false;
            objectIdNewRadioButton.Enabled = false;

            // Also, save these settings for next time
            MetaTemplate_UserSettings.Directory_Batching_Metadata_Filter = metadataFilterComboBox.Text;
            MetaTemplate_UserSettings.Directory_Batching_Metadata_Type_Index = metadataComboBox.SelectedIndex;

            if ((objectIdNewRadioButton.Checked) || (objectIdFolderNameRadioButton.Checked))
            {
                if (objectIdFolderNameRadioButton.Checked)
                    MetaTemplate_UserSettings.Directory_Batching_METS_ObjectID_Index = 1;
                else
                    MetaTemplate_UserSettings.Directory_Batching_METS_ObjectID_Index = 2;
            }
            else
            {
                MetaTemplate_UserSettings.Directory_Batching_METS_ObjectID_Index = 0;
            }
            MetaTemplate_UserSettings.Save();

            Size = new Size(628, 490);
            Cursor = Cursors.WaitCursor;
            try
            {
                // Create the Processor and assign the Delegate method for event processing.
                Batch_Directory_Processor processor = new Batch_Directory_Processor(filter, directory, metadata_type, bibid_start, first_bibid_int );
                processor.New_Progress += processor_New_Progress;
                processor.Complete += processor_Complete;
                processor.New_Folder += processor_New_Folder;

                // Create the thread to do the processing work, and start it.            
                processThread = new Thread(processor.Do_Work);
                processThread.SetApartmentState(ApartmentState.STA);
                processThread.Start();
            }
            catch (Exception ee)
            {
                // display the error message
                ErrorMessageBox.Show("Error encountered while processing!\n\n" + ee.Message, "METS Editor - Directory Batch Error", ee);
                Close();
            }  

        }

        void processor_Complete(int New_Progress, int Max_Progress)
        {
            MessageBox.Show("Batch process complete.     \n\n" + New_Progress + " directories processed.\n\n" + Max_Progress + " errors encountered.", "Batch Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        void processor_New_Folder(string New_Progress)
        {
            folderLabel.Text = New_Progress;
        }



        void processor_New_Progress(int New_Progress, int Max_Progress)
        {
            if (overallProgressBar.Maximum != Max_Progress)
                overallProgressBar.Maximum = Max_Progress;

            overallProgressBar.Value = New_Progress;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                parentDirTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void objectIdFolderNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectIdFolderNameRadioButton.Checked)
                firstBibIdTextBox.Enabled = false;
        }

        private void objectIdFileNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectIdFileNameRadioButton.Checked)
                firstBibIdTextBox.Enabled = false;
        }

        private void objectIdNewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectIdNewRadioButton.Checked)
                firstBibIdTextBox.Enabled = true;
        }

        private void metadataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metadataComboBox.SelectedIndex == 2)
            {
                objectIdFileNameRadioButton.Hide();
                objectIdNewRadioButton.Hide();
                firstBibIdTextBox.Hide();
                objectIdSourceLabel.Hide();
                objectIdFolderNameRadioButton.Hide();
            }
            else
            {
                objectIdFileNameRadioButton.Show();
                objectIdNewRadioButton.Show();
                firstBibIdTextBox.Show();
                objectIdSourceLabel.Show();
                objectIdFolderNameRadioButton.Show();
            }
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/batch/directory";
                onlineHelp.Start();
            }
            catch
            {

            }
        }


    }
}
