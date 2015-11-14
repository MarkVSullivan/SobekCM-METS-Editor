#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Publisher_Form : Form
    {
        private Publisher_Info publisherInfo;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Publisher_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                nameTextBox.BorderStyle = BorderStyle.FixedSingle;
                location1TextBox.BorderStyle = BorderStyle.FixedSingle;
                location2TextBox.BorderStyle = BorderStyle.FixedSingle;
                location3TextBox.BorderStyle = BorderStyle.FixedSingle;
                location4TextBox.BorderStyle = BorderStyle.FixedSingle;
                isXP = false;
            }
            else
            {
                isXP = true;
            }
        }

        public bool Read_Only
        {
            set
            {
                read_only = value;

                if (read_only)
                {
                    nameTextBox.ReadOnly = true;
                    nameTextBox.BackColor = Color.WhiteSmoke;
                    nameTextBox.TabStop = false;
                    location1TextBox.ReadOnly = true;
                    location1TextBox.BackColor = Color.WhiteSmoke;
                    location1TextBox.TabStop = false;
                    location2TextBox.ReadOnly = true;
                    location2TextBox.BackColor = Color.WhiteSmoke;
                    location2TextBox.TabStop = false;
                    location3TextBox.ReadOnly = true;
                    location3TextBox.BackColor = Color.WhiteSmoke;
                    location3TextBox.TabStop = false;
                    location4TextBox.ReadOnly = true;
                    location4TextBox.BackColor = Color.WhiteSmoke;
                    location4TextBox.TabStop = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }


        public void SetPublisher(Publisher_Info Publisher, bool isManufacturer )
        {
            if (isManufacturer)
            {
                Text = "Edit Manufacturer Information";
            }

            publisherInfo = Publisher;

            nameTextBox.Text = publisherInfo.Name;

            if ((publisherInfo.Places.Count > 0) && ( publisherInfo.Places[0].Place_Text.Length > 0 ))                
                location1TextBox.Text = publisherInfo.Places[0].Place_Text;

            if ((publisherInfo.Places.Count > 1) && (publisherInfo.Places[1].Place_Text.Length > 0))
                location2TextBox.Text = publisherInfo.Places[1].Place_Text;

            if ((publisherInfo.Places.Count > 2) && (publisherInfo.Places[2].Place_Text.Length > 0))
                location3TextBox.Text = publisherInfo.Places[2].Place_Text;

            if ((publisherInfo.Places.Count > 3) && (publisherInfo.Places[3].Place_Text.Length > 0))
                location4TextBox.Text = publisherInfo.Places[3].Place_Text;

            nameTextBox.TextChanged += textChanged;
            location1TextBox.TextChanged += textChanged;
            location2TextBox.TextChanged += textChanged;
            location3TextBox.TextChanged += textChanged;
            location4TextBox.TextChanged += textChanged;            
        }

        #region Method to draw the form background

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

        #endregion

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                saved = true;

                publisherInfo.Clear_Places();
                publisherInfo.Name = nameTextBox.Text.Trim();

                if (location1TextBox.Text.Trim().Length > 0)
                    publisherInfo.Add_Place(location1TextBox.Text.Trim());

                if (location2TextBox.Text.Trim().Length > 0)
                    publisherInfo.Add_Place(location2TextBox.Text.Trim());

                if (location3TextBox.Text.Trim().Length > 0)
                    publisherInfo.Add_Place(location3TextBox.Text.Trim());

                if (location4TextBox.Text.Trim().Length > 0)
                    publisherInfo.Add_Place(location4TextBox.Text.Trim());
            }

            Close();
        }

        private void cancelButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        #region Methods to change the background color of each control when focus changes

        private void textBox_Enter(object sender, EventArgs e)
        {
            if ( !read_only )
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if ( !read_only )
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        #endregion

        public bool Changed
        {
            get
            {
                return (changed) && (saved) && (!read_only);
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            changed = true;
        }

    }
}
