#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class RecordStatus_Form : Form
    {

        public RecordStatus_Form()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        public RecordStatus_Form( string Status )
        {
            InitializeComponent();

            statusTextBox.Text = Status;
            DialogResult = DialogResult.Cancel;
        }

        public string Status
        {
            get
            {
                return statusTextBox.Text.Trim();
            }
            set
            {
                statusTextBox.Text = value;
            }
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

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
