#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Degrees_Minutes_Seconds_Form : Form
    {
        private string result;

        public Degrees_Minutes_Seconds_Form()
        {
            InitializeComponent();
            result = String.Empty;
        }

        public string Result
        {
            get { return result; }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                float degrees = Convert.ToInt16(degreesTextBox.Text.Trim());
                float minutes = 0F;
                if ( minutesTextBox.Text.Trim().Length > 0 )
                    minutes = Convert.ToInt16(minutesTextBox.Text.Trim());
                float seconds = 0F;
                if ( secondsTextBox.Text.Trim().Length > 0 )
                    seconds = Convert.ToInt16(secondsTextBox.Text.Trim());

                float float_result = degrees + (minutes / 60F) + (seconds / 3600F);
                result = float_result.ToString();
            }
            catch
            {

            }

            Close();
        }
    }
}
