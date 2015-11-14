#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.Template
{
    /// <summary> Form is used to allow a user to select any non-page iamges files to include
    /// in a new digital resource  </summary>
    public partial class Other_Files_Detected_Form : Form
    {

        /// <summary> Constructor for a new instance of this form </summary>
        /// <param name="filenames"> Complete list of files </param>
        public Other_Files_Detected_Form( IEnumerable<string> filenames )
        {
            InitializeComponent();

            foreach (string thisFileName in filenames)
            {
                listView1.Items.Add(thisFileName);
            }
        }

        /// <summary> List of all files selected to be included, to be read once the form is closed and 
        /// determine which files the user selected. </summary>
        public ReadOnlyCollection<string> Selected_Files
        {
            get
            {
                List<string> selectedFiles = (from ListViewItem selectedItem in listView1.CheckedItems select selectedItem.Text).ToList();
                return new ReadOnlyCollection<string>(selectedFiles);
            }
        }

        private void downloadUrlButton_Button_Pressed(object sender, EventArgs e)
        {
            // Also, set the setting from the checkbox
            if (alwaysCheckBox.Checked)
            {
                // Set the user settings to always include non-page image files
                MetaTemplate_UserSettings.Always_Add_NonPage_Files = true;
                MetaTemplate_UserSettings.Save();

                // Show a message box
                MessageBox.Show("Non-page image files will now be automatically added to new resources.    \n\nYou can change this option in the Metadata Preferences at any time.\n\nMain menu: Actions --> Metadata Preferences --> Resource Files.", "Preference Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Close this form
            Close();
        }

        private void selectAllButton_Button_Pressed(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listView1.Items)
            {
                selectedItem.Checked = true;
            }
        }

        private void addAllButton_Button_Pressed(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listView1.Items)
            {
                selectedItem.Checked = true;
            }

            // Also, set the setting from the checkbox
            if (alwaysCheckBox.Checked)
            {
                // Set the user settings to always include non-page image files
                MetaTemplate_UserSettings.Always_Add_NonPage_Files = true;
                MetaTemplate_UserSettings.Save();

                // Show a message box
                MessageBox.Show("Non-page image files will now be automatically added to new resources.    \n\nYou can change this option in the Metadata Preferences at any time.\n\nMain menu: Actions --> Metadata Preferences --> Resource Files.", "Preference Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Close this form
            Close();
        }
    }
}
