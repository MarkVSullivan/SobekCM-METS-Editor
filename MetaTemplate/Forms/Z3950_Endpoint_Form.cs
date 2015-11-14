#region Using directives

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.MARC;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Z3950_Endpoint_Form : Form
    {
        private const string NEW = "(new)";
        private const string TEMP = "(temporary)";
        private bool during_connection;

        public Z3950_Endpoint Endpoint { get; internal set; }

        public Z3950_Endpoint_Form()
        {
            InitializeComponent();

            Endpoint = new Z3950_Endpoint();
        }

        public Z3950_Endpoint_Form( Z3950_Endpoint Endpoint, bool during_connection )
        {
            InitializeComponent();

            if (Endpoint != null)
            {
                this.Endpoint = Endpoint;
                uriTextBox.Text = Endpoint.URI;
                portTextBox.Text = Endpoint.Port.ToString();
                dbNameTextBox.Text = Endpoint.Database_Name;
                usernameTextBox.Text = Endpoint.Username;
                passwordTextBox.Text = Endpoint.Password;
            }
            else
            {
                Endpoint = new Z3950_Endpoint();
            }

            this.during_connection = during_connection;
            if (!during_connection)
            {
                connectButton.Hide();
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
            Endpoint = null;
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Validate all the entered data
            if (!validate_entry())
                return;

            // Save all this data to the endpoint
            save_data_to_endpoint();

            if (during_connection)
            {
                // Need to get a name for this connection
                bool show_password_box = false;
                if (passwordTextBox.Text.Trim().Length > 0)
                    show_password_box = true;
                Z3950_Endpoint_Save_Dialog saveDialog = new Z3950_Endpoint_Save_Dialog(show_password_box, Endpoint.Name);
                Hide();
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Save the new name and password flag 
                    Endpoint.Name = saveDialog.Endpoint_Name;
                    if (saveDialog.Save_Password)
                        Endpoint.Save_Password_Flag = true;

                    // Save this to the user settings
                    MetaTemplate_UserSettings.Add_Z3950_Endpoint(Endpoint);
                    MetaTemplate_UserSettings.Save();

                    // Close this form
                    Close();
                }
                else
                {
                    Show();
                }
            }
            else
            {
                if (passwordTextBox.Text.Trim().Length > 0)
                {
                    Endpoint.Password = passwordTextBox.Text.Trim();
                    Endpoint.Save_Password_Flag = true;
                }

                // Save this to the user settings
                MetaTemplate_UserSettings.Add_Z3950_Endpoint(Endpoint);
                MetaTemplate_UserSettings.Save();

                // Close this form
                Close();
            }
        }

        private void connectButton_Button_Pressed(object sender, EventArgs e)
        {
            // Validate all the entered data
            if (!validate_entry())
                return;

            // Save all this data to the endpoint
            save_data_to_endpoint();

            // Name this the temporary.. don't save
            Endpoint.Name = TEMP;

            Close();
        }

        private void save_data_to_endpoint()
        {
            if (Endpoint == null)
                Endpoint = new Z3950_Endpoint();

            Endpoint.URI = uriTextBox.Text.Trim();
            Endpoint.Port = UInt32.Parse(portTextBox.Text.Trim());
            Endpoint.Database_Name = dbNameTextBox.Text;
            Endpoint.Username = usernameTextBox.Text;
            Endpoint.Password = passwordTextBox.Text;
        }

        private bool validate_entry()
        {
            if (uriTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must include a URI to access the Z39.50 endpoint.    ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (portTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must include a port to access the Z39.50 endpoint.    ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Can we convert the port to an integer?
            uint port_out = 0;
            if (!UInt32.TryParse(portTextBox.Text.Trim(), out port_out))
            {
                MessageBox.Show("Invalid port number.  Port must be a valid positive number.    ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Need the database name
            if (dbNameTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must include a database name to access on the Z39.50 endpoint.    ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Must be valid!
            return true;
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

    }
}
