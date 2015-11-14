#region Using directives

using System;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form5 : Form
    {
        public First_Launch_Form5()
        {
            InitializeComponent();

            // Set the check boxes
            checksumsCheckBox.Checked = MetaTemplate_UserSettings.Include_Checksums;
            alwaysAddPageImagesCheckBox.Checked = MetaTemplate_UserSettings.Always_Add_Page_Images;
            sobekcmFileCheckBox.Checked = MetaTemplate_UserSettings.Include_SobekCM_File_Section;
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            MetaTemplate_UserSettings.Include_Checksums = checksumsCheckBox.Checked;
            MetaTemplate_UserSettings.Always_Add_Page_Images = alwaysAddPageImagesCheckBox.Checked;
            MetaTemplate_UserSettings.Include_SobekCM_File_Section = sobekcmFileCheckBox.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
