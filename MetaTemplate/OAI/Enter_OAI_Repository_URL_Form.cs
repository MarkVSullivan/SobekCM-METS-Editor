#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.OAI;

#endregion

namespace SobekCM.METS_Editor.OAI
{
    public partial class Enter_OAI_Repository_URL_Form : Form
    {
        private string oaiUrl;
        private OAI_Repository_Information repositoryInfo;


        public Enter_OAI_Repository_URL_Form()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            oaiUrl = string.Empty;

            if (MetaTemplate_UserSettings.Last_OAI_URL.Length > 0)
                textBox1.Text = MetaTemplate_UserSettings.Last_OAI_URL;
        }

        public string OAI_URL
        {
            get { return oaiUrl; }
        }

        public OAI_Repository_Information Repository_Information
        {
            get { return repositoryInfo; }   
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                if (!testButton.Button_Enabled)
                    testButton.Button_Enabled = true;
            }
            else
            {
                if (testButton.Button_Enabled)
                    testButton.Button_Enabled = false;
            }
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                oaiUrl = textBox1.Text.Trim();

                repositoryInfo = OAI_Repository_Stream_Reader.Identify(oaiUrl);
                if (repositoryInfo.Is_Valid)
                {
                    OAI_Repository_Stream_Reader.List_Metadata_Formats(repositoryInfo);
                    if (!repositoryInfo.Metadata_Formats.Contains("oai_dc"))
                    {
                        MessageBox.Show(repositoryInfo.Name + " does not support 'oai_dc' metadata format.    ", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MetaTemplate_UserSettings.Last_OAI_URL = oaiUrl;
                        MetaTemplate_UserSettings.Save();
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connect to the OAI-PMH repository listed.\n\nTry checking the URL or your network connections.    ", "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the OAI-PMH Repository URL to continue.  ","Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
            
        }

        private void testButton_Button_Pressed(object sender, EventArgs e)
        {
            OAI_Repository_Information repositoryInfo = OAI_Repository_Stream_Reader.Identify(textBox1.Text.Trim());
            if (repositoryInfo.Is_Valid)
            {
                OAI_Repository_Stream_Reader.List_Metadata_Formats(repositoryInfo);
                if ( repositoryInfo.Metadata_Formats.Contains("oai_dc"))
                    MessageBox.Show("Connection to '" + repositoryInfo.Name + "' successful!  ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show( repositoryInfo.Name + " does not support 'oai_dc' metadata format.    ", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Unable to connect to the OAI-PMH repository listed.\n\nTry checking the URL or your network connections.    ", "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
