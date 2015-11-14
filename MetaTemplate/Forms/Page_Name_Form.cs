#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Messages;

#endregion

namespace SobekCM.METS_Editor.Template
{
    public partial class Page_Name_Form : Form
    {
        public Page_Name_Form()
        {
            InitializeComponent();

            nameLabel.Text = MessageProvider_Gateway.Name + ":";
            nameTextBox.Focus();
        }

        public string Page_Name
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        private void hiddenCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            nameTextBox.BackColor = Color.Khaki;
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            nameTextBox.BackColor = Color.White;
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}