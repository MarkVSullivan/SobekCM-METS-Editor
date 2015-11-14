#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DLC.Tools.Settings;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.ImageDerivative
{
    public partial class ImageMagick_Location_Form : Form
    {
        public ImageMagick_Location_Form()
        {
            InitializeComponent();

            round_Button1.Button_Text = "CANCEL";
            round_Button2.Button_Text = "OK";
            round_Button1.Button_Type = Round_Button.Button_Type_Enum.Full_Backward;
            round_Button2.Button_Type = Round_Button.Button_Type_Enum.Full_Forward;
        }

        private void locationTextBox_Enter(object sender, EventArgs e)
        {
            locationTextBox.BackColor = DLC_UserSettings.Active_Control_Highlight_Color;
        }

        private void locationTextBox_Leave(object sender, EventArgs e)
        {
            locationTextBox.BackColor = Color.White;
        }

        private void locationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                locationTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                locationTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void round_Button1_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void round_Button2_Button_Pressed(object sender, EventArgs e)
        {
            if ((locationTextBox.Text.Trim().Length == 0) || (!File.Exists(locationTextBox.Text.Trim())))
            {
                MessageBox.Show("Select the ImageMagick executable file 'convert.exe' before continuing.   ", "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;

            MetaTemplate_UserSettings.ImageMagick_Executable = locationTextBox.Text;
            MetaTemplate_UserSettings.Save();
            Close();
        }
    }
}
