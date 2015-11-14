#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class EAD_Form : Form
    {
        private string ead_name;
        private string ead_url;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public EAD_Form()
        {
            InitializeComponent();

            ead_name = String.Empty;
            ead_url = String.Empty;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                nameTextBox.BorderStyle = BorderStyle.FixedSingle;
                urlTextBox.BorderStyle = BorderStyle.FixedSingle;
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
                    urlTextBox.ReadOnly = true;
                    urlTextBox.BackColor = Color.WhiteSmoke;
                    urlTextBox.TabStop = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
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

        public void Add_Data(string EAD_Name, string EAD_URL)
        {
            ead_name = EAD_Name;
            ead_url = EAD_URL;
            urlTextBox.Text = EAD_URL;
            nameTextBox.Text = EAD_Name;

            nameTextBox.TextChanged += textChanged;
            urlTextBox.TextChanged += textChanged;
        }

        public void Save_Data(ref string EAD_Name, ref string EAD_URL)
        {
            if (saved)
            {
                EAD_Name = ead_name;
                EAD_URL = ead_url;
            }
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                if ((nameTextBox.Text.Trim().Length > 0) && (urlTextBox.Text.Trim().Length == 0))
                {
                    MessageBox.Show("EAD will only be saved if there is a URL provided.    ", "EAD URL Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                saved = true;
                ead_name = nameTextBox.Text;
                ead_url = urlTextBox.Text.Replace("\\", "/");
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
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
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
