#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_FDA_Constants : Form
    {
        public First_Launch_FDA_Constants()
        {
            InitializeComponent();

            accountTextBox.Text = MetaTemplate_UserSettings.FDA_Account;
            subAccountTextBox.Text = MetaTemplate_UserSettings.FDA_SubAccount;
            projectTextBox.Text = MetaTemplate_UserSettings.FDA_Project;
            fdaCheckBox.Checked = MetaTemplate_UserSettings.FCLA_Flag_FDA;
            palmmCheckBox.Checked = MetaTemplate_UserSettings.FCLA_Flag_PALMM;
            palmmCodeTextBox.Text = MetaTemplate_UserSettings.PALMM_Code;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            MetaTemplate_UserSettings.FDA_Account = accountTextBox.Text.Trim();
            MetaTemplate_UserSettings.FDA_SubAccount = subAccountTextBox.Text.Trim();
            MetaTemplate_UserSettings.FDA_Project = projectTextBox.Text.Trim();
            MetaTemplate_UserSettings.FCLA_Flag_FDA = fdaCheckBox.Checked;
            MetaTemplate_UserSettings.FCLA_Flag_PALMM = palmmCheckBox.Checked;
            MetaTemplate_UserSettings.PALMM_Code = palmmCodeTextBox.Text;

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
