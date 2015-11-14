#region Using directives

using System;
using System.IO;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form3 : Form
    {
        public First_Launch_Form3()
        {
            InitializeComponent();

            // Populate all other templates
            string directory = Application.StartupPath + "\\Templates";
            if (!Directory.Exists(directory))
            {
                MessageBox.Show("Required TEMPALTE subfolder is missing.\n\nPlease try reinstalling this product.",
                                "Invalid Installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string[] templates = Directory.GetFiles(directory, "*.xml");
                string text = String.Empty;
                foreach (string thisTemplate in templates)
                {
                    FileInfo fileInfo = new FileInfo(thisTemplate);
                    string filename = fileInfo.Name.Replace(fileInfo.Extension, "");
                    string filename_upper = filename.ToUpper();
                    if ((filename_upper != "DUBLINCORE") && (filename_upper != "STANDARD") &&
                        (filename_upper != "COMPLETE"))
                    {
                        otherComboBox.Items.Add(filename);

                        if (filename_upper == MetaTemplate_UserSettings.Default_Template.ToUpper())
                            text = filename;
                    }
                }
                if (text.Length > 0)
                    otherComboBox.Text = text;
                else if (otherComboBox.Items.Count > 0)
                    otherComboBox.SelectedIndex = 0;

                // If no others in the template directory, hide those options
                if (otherComboBox.Items.Count == 0)
                {
                    otherComboBox.Hide();
                    otherRadioButton.Hide();
                }

                switch (MetaTemplate_UserSettings.Default_Template.ToUpper())
                {
                    case "DUBLINCORE":
                        dublinCoreRadioButton.Checked = true;
                        break;

                    case "STANDARD":
                        standardRadioButton.Checked = true;
                        break;

                    case "COMPLETE":
                        completeRadioButton.Checked = true;
                        break;

                    default:
                        if (text.Length != 0)
                        {
                            otherRadioButton.Checked = true;
                            otherComboBox.Enabled = true;
                        }
                        else
                        {
                            if (MetaTemplate_UserSettings.Bibliographic_Metadata ==
                                Bibliographic_Metadata_Enum.DublinCore)
                                dublinCoreRadioButton.Checked = true;
                            else
                                standardRadioButton.Checked = true;
                        }
                        break;
                }
            }
        }

        private void otherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (otherRadioButton.Checked)
                otherComboBox.Enabled = true;
            else
                otherComboBox.Enabled = false;
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            if ((!dublinCoreRadioButton.Checked) && (!standardRadioButton.Checked) && (!completeRadioButton.Checked) && ( !otherRadioButton.Checked ))
            {
                MessageBox.Show("Please select the base template you wish to utilize.\n\nThis can always be changed later through the preferences menu.", "Select Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dublinCoreRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "DUBLINCORE";
            if (standardRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "STANDARD";
            if (completeRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "COMPLETE";
            if (otherRadioButton.Checked)
            {
                MetaTemplate_UserSettings.Default_Template = otherComboBox.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }



    }
}
