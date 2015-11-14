#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.MARC;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Z3950_Import_Form : Form
    {
        private const string NEW = "(new)";
        private const string TEMP = "(temporary)";
        private Z3950_Endpoint temporaryEndpoint;
        private Z3950_Endpoint endpoint;

        public MARC_Record Record { get; internal set; }

        public Z3950_Import_Form()
        {
            InitializeComponent();

            // Create the empty endpoint
            endpoint = new Z3950_Endpoint();

            // Populate the combo box
            endpointComboBox.Items.Add(NEW);
            IEnumerable<string> endpoints = MetaTemplate_UserSettings.Z3950_Endpoint_Names;
            foreach (string thisEndpoint in endpoints)
                endpointComboBox.Items.Add(thisEndpoint);
            endpointComboBox.Text = NEW;

            // Restore last endpoint, if it exists
            if (MetaTemplate_UserSettings.Last_Z3950_Endpoint.Length > 0)
            {
                if ( endpointComboBox.Items.Contains( MetaTemplate_UserSettings.Last_Z3950_Endpoint ))
                    endpointComboBox.Text = MetaTemplate_UserSettings.Last_Z3950_Endpoint;
            }
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void importButton_Button_Pressed(object sender, EventArgs e)
        {
            // Check the primary key is provided
            if (identifierTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter the primary identifier to import the Z39.50 records.    ", "Missing Primary Identifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Check the Z39.50 endpoint
            if (endpoint == null )
            {
                Z3950_Endpoint_Form endpointForm = new Z3950_Endpoint_Form();
                Hide();
                endpointForm.ShowDialog();
                Show();

                endpoint = endpointForm.Endpoint;
                if (endpoint == null)
                {
                    MessageBox.Show("Select a Z39.50 endpoint or enter information for a new or temporary endpoint.     ", "Missing Endpoint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Since this was a VALID entry, save this as the last Z39.50 endpoint used
            if ((endpoint.Name != NEW) && (endpoint.Name != TEMP))
            {
                MetaTemplate_UserSettings.Last_Z3950_Endpoint = endpoint.Name;
                MetaTemplate_UserSettings.Save();
            }

            string identifier = identifierTextBox.Text.Trim();
            string out_message = String.Empty;
            MARC_Record record_from_z3950 = MARC_Record_Z3950_Retriever.Get_Record_By_Primary_Identifier(identifier, endpoint, out out_message );
            if (record_from_z3950 == null)
            {
                if (out_message.Length > 0)
                {
                    MessageBox.Show(out_message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unknown error occurred during request", "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("Found!!\n\n" + record_from_z3950.To_Machine_Readable_Record());
                Record = record_from_z3950;
            }
            Close();
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/z3950";
                onlineHelp.Start();
            }
            catch
            {

            }
        }

        private void newEditButton_Button_Pressed(object sender, EventArgs e)
        {
                Z3950_Endpoint_Form endpointForm = new Z3950_Endpoint_Form( endpoint, true  );
                Hide();
                endpointForm.ShowDialog();

            // Was an item added?
                if ( endpointForm.Endpoint != null )
                {
                    if ( String.Compare( endpointForm.Endpoint.Name, endpointComboBox.Text, true ) != 0 )
                    {
                        endpoint = endpointForm.Endpoint;
                             
                        // Now, reload the list of endpoints
                        endpointComboBox.Items.Clear();
                        endpointComboBox.Items.Add(NEW);

                        if (endpoint.Name == TEMP)
                        {
                            temporaryEndpoint = endpoint;
                            endpointComboBox.Items.Add(TEMP);
                        }

                        IEnumerable<string> endpoints = MetaTemplate_UserSettings.Z3950_Endpoint_Names;
                        foreach (string thisEndpoint in endpoints)
                            endpointComboBox.Items.Add(thisEndpoint);

                        // Select the selected 
                        endpointComboBox.Text = endpointForm.Endpoint.Name;
                    }
                }

                Show();
        }

        private void endpointComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((endpointComboBox.Text != NEW) && (endpointComboBox.Text  != TEMP))
            {
                endpoint = MetaTemplate_UserSettings.Get_Endpoint_By_Name(endpointComboBox.Text);
                if (endpoint == null)
                    endpointComboBox.Text = NEW;
            }
            else if ( endpointComboBox.Text == TEMP )
            {
                endpoint = temporaryEndpoint;
            }
            else if (endpointComboBox.Text == NEW)
            {
                endpoint = null;
            }
        }
    }
}
