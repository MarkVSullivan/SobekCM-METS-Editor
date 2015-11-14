#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class Institution_Form : Form
    {
        public Institution_Form()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        public Institution_Form( string Code, string Institution_Name )
        {
            InitializeComponent();

            codeTextBox.Text = Code;
            nameTextBox.Text = Institution_Name;

            DialogResult = DialogResult.Cancel;
        }

        public string Code
        {
            get
            {
                return codeTextBox.Text.Trim();
            }
            set
            {
                codeTextBox.Text = value;
            }
        }

        public string Institution_Name
        {
            get
            {
                return nameTextBox.Text.Trim();
            }
            set
            {
                nameTextBox.Text = value;
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
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
