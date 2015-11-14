#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form6 : Form
    {
        public First_Launch_Form6()
        {
            InitializeComponent();

            sourceCodeTextBox.Text = MetaTemplate_UserSettings.Default_Source_Code;
            sourceStatementTextBox.Text = MetaTemplate_UserSettings.Default_Source_Statement;
            nameTextBox.Text = MetaTemplate_UserSettings.Individual_Creator;
            rightsTextBox.Text = MetaTemplate_UserSettings.Default_Rights_Statement;
            fundingTextBox.Text = MetaTemplate_UserSettings.Default_Funding_Note;

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
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            
            MetaTemplate_UserSettings.Default_Source_Code = sourceCodeTextBox.Text;
            MetaTemplate_UserSettings.Default_Source_Statement = sourceStatementTextBox.Text;
            MetaTemplate_UserSettings.Individual_Creator = nameTextBox.Text;
            MetaTemplate_UserSettings.Default_Rights_Statement = rightsTextBox.Text;
            MetaTemplate_UserSettings.Default_Funding_Note = fundingTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
