#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Material_Details_Other_Form : Form
    {
        private string extent, marc_date_start, marc_date_end, place_code, language_code;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Material_Details_Other_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                languageCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                placeCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                date1TextBox.BorderStyle = BorderStyle.FixedSingle;
                date2TextBox.BorderStyle = BorderStyle.FixedSingle;
                extentTextBox.BorderStyle = BorderStyle.FixedSingle;
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
                    languageCodeTextBox.ReadOnly = true;
                    languageCodeTextBox.BackColor = Color.WhiteSmoke;
                    languageCodeTextBox.TabStop = false;
                    placeCodeTextBox.ReadOnly = true;
                    placeCodeTextBox.BackColor = Color.WhiteSmoke;
                    placeCodeTextBox.TabStop = false;
                    date1TextBox.ReadOnly = true;
                    date1TextBox.BackColor = Color.WhiteSmoke;
                    date1TextBox.TabStop = false;
                    date2TextBox.ReadOnly = true;
                    date2TextBox.BackColor = Color.WhiteSmoke;
                    date2TextBox.TabStop = false;
                    extentTextBox.ReadOnly = true;
                    extentTextBox.BackColor = Color.WhiteSmoke;
                    extentTextBox.TabStop = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        public void Add_Data(string Extent, string Marc_Date_Start, string Marc_Date_End, string Place_Code, string Language_Code )
        {
            // Save all the values first
            extent = Extent;
            marc_date_start = Marc_Date_Start;
            marc_date_end = Marc_Date_End;
            place_code = Place_Code;
            language_code = Language_Code;

            // Show the values
            extentTextBox.Text = extent;
            date1TextBox.Text = marc_date_start;
            date2TextBox.Text = marc_date_end;
            placeCodeTextBox.Text = place_code;
            languageCodeTextBox.Text = language_code;

            languageCodeTextBox.TextChanged += textChanged;
            placeCodeTextBox.TextChanged += textChanged;
            date1TextBox.TextChanged += textChanged;
            date2TextBox.TextChanged += textChanged;
            extentTextBox.TextChanged += textChanged;            
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

        public void Save_Data(ref string Extent, ref string Marc_Date_Start, ref string Marc_Date_End, ref string Place_Code, ref string Language_Code)
        {
            if (saved)
            {
                Extent = extent;
                Marc_Date_Start = marc_date_start;
                Marc_Date_End = marc_date_end;
                Place_Code = place_code;
                Language_Code = language_code;
            }
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                saved = true;

                extent = extentTextBox.Text.Trim();
                marc_date_start = date1TextBox.Text.Trim();
                marc_date_end = date2TextBox.Text.Trim();
                place_code = placeCodeTextBox.Text.Trim();
                language_code = languageCodeTextBox.Text.Trim();
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

        private void comboBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.Khaki;
            }
        }

        private void comboBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.White;
            }
        }

        private void checkBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((CheckBox)sender).BackColor = Color.Khaki;
            }
        }

        private void checkBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((CheckBox)sender).BackColor = panel1.BackColor;
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
