#region Using directives

using System;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.Template
{
    /// <summary> Form is displayed to allow the user to select any page images to include
    /// with a new digital resource </summary>
    public partial class Existing_Page_Images_Found_Dialog : Form
    {
        /// <summary> Constructor for a new instance of this dialog form  </summary>
        public Existing_Page_Images_Found_Dialog()
        {
            InitializeComponent();

            // Set default dialog result to not include the page images
            DialogResult = DialogResult.No;
        }

        private void noButton_Button_Pressed(object sender, EventArgs e)
        {
            // Set the dialog result
            DialogResult = DialogResult.No;

            // Close this form
            Close();
        }

        private void yesButton_Button_Pressed(object sender, EventArgs e)
        {
            // Set the dialog result
            DialogResult = DialogResult.Yes;

            // Also, set the setting from the checkbox
            if (alwaysCheckBox.Checked)
            {
                // Set the user settings correspondingly
                MetaTemplate_UserSettings.Always_Add_Page_Images = true;
                MetaTemplate_UserSettings.Save();

                // Show a message box
                MessageBox.Show("Page images will now be automatically added to new resources.    \n\nYou can change this option in the Metadata Preferences at any time.\n\nMain menu: Actions --> Metadata Preferences --> Resource Files.", "Preference Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Close this form
            Close();
        }
    }
}
