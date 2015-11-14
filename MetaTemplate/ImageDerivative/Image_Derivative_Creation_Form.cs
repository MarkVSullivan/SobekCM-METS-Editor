#region Using directives

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.ImageDerivative
{
    public partial class Image_Derivative_Creation_Form : Form
    {
        private Thread processorThread;


        public Image_Derivative_Creation_Form()
        {
            InitializeComponent();

            // Set the values from the saved settings
            widthTextBox.Text = MetaTemplate_UserSettings.ImageDeriv_Width.ToString();
            heightTextBox.Text = MetaTemplate_UserSettings.ImageDeriv_Height.ToString();
            thumbWidthTextBox.Text = MetaTemplate_UserSettings.ImageDeriv_Thumbnail_Width.ToString();
            thumbHeightTextBox.Text = MetaTemplate_UserSettings.ImageDeriv_Thumbnail_Height.ToString();
            if (MetaTemplate_UserSettings.ImageDeriv_Create_JPEG2000)
                jp2CheckBox.Checked = true;
            else
                jp2CheckBox.Checked = false;
            if (MetaTemplate_UserSettings.ImageDeriv_Create_JPEG)
            {
                jpegCheckBox.Checked = true;
                jpegPanel.Show();
            }
            else
            {
                jpegCheckBox.Checked = false;
                jpegPanel.Hide();
            }
            if (MetaTemplate_UserSettings.ImageDeriv_Create_Thumbnail)
            {
                thumbnailCheckBox.Checked = true;
                thumbnailPanel.Show();
            }
            else
            {
                thumbnailCheckBox.Checked = false;
                thumbnailPanel.Hide();
            }    
        }

        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            return;

            // Get rid of any current background image
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            if (ClientSize.Width > 0)
            {
                // Create the items needed to draw the background
                Bitmap image = new Bitmap(ClientSize.Width, ClientSize.Height);
                Graphics gr = Graphics.FromImage(image);
                Rectangle rect = new Rectangle(new Point(0, 0), ClientSize);

                // Create the brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, SystemColors.Control, ControlPaint.Dark(SystemColors.Control), LinearGradientMode.Vertical);
                brush.SetBlendTriangularShape(0.33F);

                // Create the image
                gr.FillRectangle(brush, rect);
                gr.Dispose();

                // Set this as the backgroundf
                BackgroundImage = image;
            }
        }

        #region Methods to change the background color of each control when focus changes

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        #endregion

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            try
            {
                MetaTemplate_UserSettings.ImageDeriv_Create_JPEG2000 = jp2CheckBox.Checked;

                if (jpegCheckBox.Checked)
                {
                    int new_height = Convert.ToInt32(heightTextBox.Text);
                    int new_width = Convert.ToInt32(widthTextBox.Text);
                    if ((new_height > 0) && (new_width > 0))
                    {
                        MetaTemplate_UserSettings.ImageDeriv_Height = new_height;
                        MetaTemplate_UserSettings.ImageDeriv_Width = new_width;
                        MetaTemplate_UserSettings.ImageDeriv_Create_JPEG = jpegCheckBox.Checked;
                    }
                }
                else
                {
                    MetaTemplate_UserSettings.ImageDeriv_Create_JPEG = jpegCheckBox.Checked;
                }

                int thumb_height = -1;
                int thumb_width = -1;
                if (thumbnailCheckBox.Checked)
                {
                    thumb_height = Convert.ToInt32(thumbHeightTextBox.Text);
                    thumb_width = Convert.ToInt32(thumbWidthTextBox.Text);
                    if ((thumb_height > 0) && (thumb_width > 0))
                    {
                        MetaTemplate_UserSettings.ImageDeriv_Thumbnail_Height = thumb_height;
                        MetaTemplate_UserSettings.ImageDeriv_Thumbnail_Width = thumb_width;
                        MetaTemplate_UserSettings.ImageDeriv_Create_Thumbnail = thumbnailCheckBox.Checked;
                    }
                }
                else
                {
                    MetaTemplate_UserSettings.ImageDeriv_Create_Thumbnail = thumbnailCheckBox.Checked;
                }

                MetaTemplate_UserSettings.Save();

                // Check that ImageMagick exists
                if ((MetaTemplate_UserSettings.ImageMagick_Executable.Length == 0) || (!File.Exists(MetaTemplate_UserSettings.ImageMagick_Executable)))
                {
                    ImageMagick_Location_Form findImageMagick = new ImageMagick_Location_Form();
                    if (findImageMagick.ShowDialog() != DialogResult.OK)
                        return;
                }

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Create the new processor
                    Multiple_Folders_Processor processor = new Multiple_Folders_Processor(MetaTemplate_UserSettings.ImageDeriv_Create_JPEG, MetaTemplate_UserSettings.ImageDeriv_Create_JPEG2000, MetaTemplate_UserSettings.ImageDeriv_Width, MetaTemplate_UserSettings.ImageDeriv_Height, folderBrowserDialog1.SelectedPath, thumb_width, thumb_height );
                    processor.New_Task_String += processor_New_Task_String;
                    processor.New_Volume_String += processor_New_Volume_String;
                    processor.New_Progress += processor_New_Progress;
                    processor.Process_Complete += processor_Process_Complete;

                    // Create the processor thread
                    processorThread = new Thread(processor.Process);
                    processorThread.Start();
                }
            
            }
            catch
            {
                MessageBox.Show("Invalid entries for either width or height");
            }
        }

        void processor_Process_Complete(int Packages_Processed, int JPEG2000_Warnings)
        {
            MessageBox.Show("Image Derivative Creation Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information );
            taskLabel.Text = "PROCESS COMPLETE";
            volumeLabel.Text = "PROCESS COMPLETE";
            Close();
            processorThread.Abort();
        }

        void processor_New_Progress(int Value, int Max)
        {
            if (progressBar1.Value > Max)
                progressBar1.Value = Max;
            if (progressBar1.Maximum != Max)
                progressBar1.Maximum = Max;
            progressBar1.Value = Value;
        }

        void processor_New_Volume_String(string new_message)
        {
            volumeLabel.Text = new_message;
        }

        void processor_New_Task_String(string new_message)
        {
            taskLabel.Text = new_message;
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void jpegCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (jpegCheckBox.Checked)
                jpegPanel.Show();
            else
                jpegPanel.Hide();
        }

        private void thumbnailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (thumbnailCheckBox.Checked)
                thumbnailPanel.Show();
            else
                thumbnailPanel.Hide();
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/imagederiv";
                onlineHelp.Start();
            }
            catch
            {

            }
        }


    }
}
