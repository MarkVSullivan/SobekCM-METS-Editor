#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms;
using SobekCM.METS_Editor.Messages;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class Show_XML_Form : Form
    {
        public Show_XML_Form(string FileToDisplay, bool Shown_By_Default)
        {
            InitializeComponent();

            // Set the title and close text
            Text = MessageProvider_Gateway.METS_File_As_XML;
            saveButton.Button_Text = MessageProvider_Gateway.Close.ToUpper();

            if (!Shown_By_Default)
                showMetadataCheckBox.Hide();

            webBrowser1.Url = new Uri(FileToDisplay);


        }

        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showMetadataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MetaTemplate_UserSettings.Show_Metadata_PostSave = showMetadataCheckBox.Checked;
            MetaTemplate_UserSettings.Save();

            if (!MetaTemplate_UserSettings.Show_Metadata_PostSave)
            {
                MessageBox.Show("To make this form automatically appear again, you can     \nset this value under Settings --> Metadata Preferences.", "Metadata Display Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
