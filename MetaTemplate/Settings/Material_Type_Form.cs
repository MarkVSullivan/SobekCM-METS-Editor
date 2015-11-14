#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class Material_Type_Form : Form
    {
        public Material_Type_Form()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            modsComboBox.SelectedIndex = 0;
        }

        public Material_Type_Form(string Display_Name, string MODS_Type, string SobekCM_Genre)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            displayTextBox.Text = Display_Name;
            modsComboBox.Text = MODS_Type;
            sobekTextBox.Text = SobekCM_Genre;
        }

        public string Display_Name
        {
            get
            {
                return displayTextBox.Text.Trim();
            }
            set
            {
                displayTextBox.Text = value;
            }
        }

        public string MODS_Type
        {
            get
            {
                return modsComboBox.Text.Trim();
            }
            set
            {
                modsComboBox.Text = value;
            }
        }

        public string SobekCM_Genre
        {
            get
            {
                return sobekTextBox.Text.Trim();
            }
            set
            {
                sobekTextBox.Text = value;
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
