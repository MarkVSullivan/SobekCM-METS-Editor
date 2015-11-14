#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Other_URL_Form : Form
    {
        private string other_label;
        private string other_note;
        private string other_url;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Other_URL_Form()
        {
            other_label = String.Empty;
            other_note = String.Empty;
            other_url = String.Empty;

            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                labelTextBox.BorderStyle = BorderStyle.FixedSingle;
                urlTextBox.BorderStyle = BorderStyle.FixedSingle;
                noteTextBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        public bool Read_Only
        {
            set
            {
                read_only = value;

                if (read_only)
                {
                    labelTextBox.ReadOnly = true;
                    labelTextBox.BackColor = Color.WhiteSmoke;
                    labelTextBox.TabStop = false;
                    urlTextBox.ReadOnly = true;
                    urlTextBox.BackColor = Color.WhiteSmoke;
                    urlTextBox.TabStop = false;
                    noteTextBox.ReadOnly = true;
                    noteTextBox.BackColor = Color.WhiteSmoke;
                    noteTextBox.TabStop = false;

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

        public void Add_Data(string Label, string URL, string Note )
        {
            other_label = Label;
            other_note = Note;
            other_url = URL;

            urlTextBox.Text = other_url;
            labelTextBox.Text = other_label;
            noteTextBox.Text = other_note;

            labelTextBox.TextChanged += textChanged;
            urlTextBox.TextChanged += textChanged;
            noteTextBox.TextChanged += textChanged;
        }

        public void Save_Data(ref string Label, ref string URL, ref string Note)
        {
            if (saved)
            {
                Label = other_label;
                Note = other_note;
                URL = other_url;
            }
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                saved = true;
                other_label = labelTextBox.Text;
                other_url = urlTextBox.Text.Replace("\\", "/");
                other_note = noteTextBox.Text;
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
