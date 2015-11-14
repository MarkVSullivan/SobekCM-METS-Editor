#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Material_Details_Continuing_Materials_Form : Form
    {
        private string extent, marc_date_start, marc_date_end, place_code, language_code;
        private List<Origin_Info_Frequency> frequencies;
        private List<Genre_Info> genres;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Material_Details_Continuing_Materials_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                showMarcCheckBox.FlatStyle = FlatStyle.Flat;
                conferenceCheckBox.FlatStyle = FlatStyle.Flat;
                languageCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                placeCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                date1TextBox.BorderStyle = BorderStyle.FixedSingle;
                date2TextBox.BorderStyle = BorderStyle.FixedSingle;
                extentTextBox.BorderStyle = BorderStyle.FixedSingle;
                frequencyComboBox.FlatStyle = FlatStyle.Flat;
                regularityComboBox.FlatStyle = FlatStyle.Flat;
                nature1ComboBox.FlatStyle = FlatStyle.Flat;
                nature2ComboBox.FlatStyle = FlatStyle.Flat;
                nature3ComboBox.FlatStyle = FlatStyle.Flat;
                nature4ComboBox.FlatStyle = FlatStyle.Flat;
                govtComboBox.FlatStyle = FlatStyle.Flat;
                subTypeComboBox.FlatStyle = FlatStyle.Flat;
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

                    frequencyComboBox.Enabled = false;
                    regularityComboBox.Enabled = false;
                    nature1ComboBox.Enabled = false;
                    nature2ComboBox.Enabled = false;
                    nature3ComboBox.Enabled = false;
                    nature4ComboBox.Enabled = false;
                    govtComboBox.Enabled = false;
                    subTypeComboBox.Enabled = false;

                    conferenceCheckBox.Enabled = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        private void specificGroupBox_Paint(object sender, PaintEventArgs e)
        {
            if ((!isXP) && (!read_only))
            {
                Pen blackPen = new Pen(Color.Black, 1);

                e.Graphics.DrawRectangle(blackPen, frequencyComboBox.Location.X - 1, frequencyComboBox.Location.Y - 1, frequencyComboBox.Width + 1, frequencyComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, regularityComboBox.Location.X - 1, regularityComboBox.Location.Y - 1, regularityComboBox.Width + 1, regularityComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, nature1ComboBox.Location.X - 1, nature1ComboBox.Location.Y - 1, nature1ComboBox.Width + 1, nature1ComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, nature2ComboBox.Location.X - 1, nature2ComboBox.Location.Y - 1, nature2ComboBox.Width + 1, nature2ComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, nature3ComboBox.Location.X - 1, nature3ComboBox.Location.Y - 1, nature3ComboBox.Width + 1, nature3ComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, nature4ComboBox.Location.X - 1, nature4ComboBox.Location.Y - 1, nature4ComboBox.Width + 1, nature4ComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, govtComboBox.Location.X - 1, govtComboBox.Location.Y - 1, govtComboBox.Width + 1, govtComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, subTypeComboBox.Location.X - 1, subTypeComboBox.Location.Y - 1, subTypeComboBox.Width + 1, subTypeComboBox.Height + 1);
            }
        }

        public void Add_Data(string Extent, string Marc_Date_Start, string Marc_Date_End, string Place_Code, string Language_Code, List<Origin_Info_Frequency> Frequencies, List<Genre_Info> Genres)
        {
            // Save all the values first
            extent = Extent;
            marc_date_start = Marc_Date_Start;
            marc_date_end = Marc_Date_End;
            place_code = Place_Code;
            language_code = Language_Code;
            frequencies = Frequencies;
            genres = Genres;

            // Show the values
            extentTextBox.Text = extent;
            date1TextBox.Text = marc_date_start;
            date2TextBox.Text = marc_date_end;
            placeCodeTextBox.Text = place_code;
            languageCodeTextBox.Text = language_code;

            // Step through each frequency
            foreach (Origin_Info_Frequency thisFrequency in frequencies)
            {
                // Check for frequency information
                foreach (string thisItem in frequencyComboBox.Items)
                {
                    if (thisFrequency.Term == thisItem)
                    {
                        frequencyComboBox.Text = thisFrequency.Term;
                    }
                }

                // Check for regularity information
                foreach (string thisItem in regularityComboBox.Items)
                {
                    if (thisFrequency.Term == thisItem)
                    {
                        regularityComboBox.Text = thisFrequency.Term;
                    }
                }
            }

            // Step through each genre
            int nature_index = 1;
            foreach (Genre_Info thisGenre in genres)
            {
                if (thisGenre.Genre_Term == "conference publication") 
                {
                    if (thisGenre.Genre_Term == "conference publication")
                        conferenceCheckBox.Checked = true;
                }
                else
                {
                    // Check for the nature of contents 
                    foreach (string thisItem in nature1ComboBox.Items)
                    {
                        if (thisGenre.Genre_Term == thisItem)
                        {
                            switch (nature_index)
                            {
                                case 1:
                                    nature1ComboBox.Text = thisGenre.Genre_Term;
                                    break;

                                case 2:
                                    nature2ComboBox.Text = thisGenre.Genre_Term;
                                    break;

                                case 3:
                                    nature3ComboBox.Text = thisGenre.Genre_Term;
                                    break;

                                case 4:
                                    nature4ComboBox.Text = thisGenre.Genre_Term;
                                    break;
                            }
                            nature_index++;
                        }
                    }

                    // Check for government publications
                    foreach (string thisItem in govtComboBox.Items)
                    {
                        if (thisGenre.Genre_Term == thisItem)
                        {
                            govtComboBox.Text = thisGenre.Genre_Term;
                        }
                    }

                    // Check for subtype
                    foreach (string thisItem in subTypeComboBox.Items)
                    {
                        if (thisGenre.Genre_Term == thisItem)
                        {
                            subTypeComboBox.Text = thisGenre.Genre_Term;
                        }
                    }
                }
            }

            languageCodeTextBox.TextChanged += textChanged;
            placeCodeTextBox.TextChanged += textChanged;
            date1TextBox.TextChanged += textChanged;
            date2TextBox.TextChanged += textChanged;
            extentTextBox.TextChanged += textChanged;
            frequencyComboBox.TextChanged += textChanged;
            regularityComboBox.TextChanged += textChanged;
            nature1ComboBox.TextChanged += textChanged;
            nature2ComboBox.TextChanged += textChanged;
            nature3ComboBox.TextChanged += textChanged;
            nature4ComboBox.TextChanged += textChanged;
            govtComboBox.TextChanged += textChanged;
            subTypeComboBox.TextChanged += textChanged;

            conferenceCheckBox.CheckedChanged += checkedChanged;
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
            saved = true;

            extent = extentTextBox.Text.Trim();
            marc_date_start = date1TextBox.Text.Trim();
            marc_date_end = date2TextBox.Text.Trim();
            place_code = placeCodeTextBox.Text.Trim();
            language_code = languageCodeTextBox.Text.Trim();


            frequencies.Clear();
            genres.Clear();

            if ( frequencyComboBox.Text.Trim().Length > 0)
            {
                frequencies.Add(new Origin_Info_Frequency(frequencyComboBox.Text.Trim(), "marcfrequency"));
            }

            if (regularityComboBox.Text.Trim().Length > 0)
            {
                frequencies.Add(new Origin_Info_Frequency(regularityComboBox.Text.Trim(), "marcfrequency"));
            }

            Genre_Info newGenre;
            if (nature1ComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(nature1ComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (nature2ComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(nature2ComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (nature3ComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(nature3ComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (nature4ComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(nature4ComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (govtComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(govtComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (subTypeComboBox.Text.Trim().Length > 0)
            {
                newGenre = new Genre_Info(subTypeComboBox.Text.Trim(), "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
            }
            if (conferenceCheckBox.Checked)
            {
                newGenre = new Genre_Info("conference publication", "marcgt");
                if (!genres.Contains(newGenre))
                {
                    genres.Add(newGenre);
                }
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
