#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Z3950_Endpoint_Save_Dialog : Form
    {
        public bool Save_Password { get; private set; }
        public string Endpoint_Name { get; private set; }

        public Z3950_Endpoint_Save_Dialog(   )
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            Endpoint_Name = String.Empty;
        }

        public Z3950_Endpoint_Save_Dialog( bool show_password_checkbox, string endpoint_name )
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            passwordCheckBox.Visible = show_password_checkbox;
            nameTextBox.Text = endpoint_name;
            Endpoint_Name = endpoint_name;
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Must have a valid enpoint name
            string endpoint_temp = nameTextBox.Text.Trim();
            if ((String.Compare(endpoint_temp, "(new)") == 0) || (String.Compare(endpoint_temp, "(temporary)") == 0))
            {
                MessageBox.Show("You have chosen a reserved name for this endpoint.            \n\nPlease enter a different endpoint name.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ( endpoint_temp.Length == 0 )
            {
                MessageBox.Show("You must enter a name for this endpoint.            ", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validated, so save the values and close the form
            DialogResult = DialogResult.OK;
            if (passwordCheckBox.Visible)
                Save_Password = passwordCheckBox.Checked;
            else
                Save_Password = false;
            Endpoint_Name = endpoint_temp;
            Close();
        }
    }
}
