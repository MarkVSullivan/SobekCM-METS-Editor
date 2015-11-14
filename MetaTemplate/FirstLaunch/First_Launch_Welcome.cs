#region Using directives

using System;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Welcome : Form
    {
        public First_Launch_Welcome()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/software/mets";
                onlineHelp.Start();
            }
            catch
            {
                MessageBox.Show("Unable to display web page.", "Error");
            }
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
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
