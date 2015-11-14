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
    public partial class Material_Details_Maps_Form : Form
    {
        private string extent, marc_date_start, marc_date_end, place_code, language_code;
        private List<Subject_Info_Cartographics> cartographics;
        private List<Genre_Info> genres;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Material_Details_Maps_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                indexCheckBox.FlatStyle = FlatStyle.Flat;
                showMarcCheckBox.FlatStyle = FlatStyle.Flat;
                languageCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                placeCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                date1TextBox.BorderStyle = BorderStyle.FixedSingle;
                date2TextBox.BorderStyle = BorderStyle.FixedSingle;
                extentTextBox.BorderStyle = BorderStyle.FixedSingle;
                scaleTextBox.BorderStyle = BorderStyle.FixedSingle;
                projCodeTextBox.BorderStyle = BorderStyle.FixedSingle;
                subTypeComboBox.FlatStyle = FlatStyle.Flat;
                govtComboBox.FlatStyle = FlatStyle.Flat;
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

                    scaleTextBox.ReadOnly = true;
                    scaleTextBox.BackColor = Color.WhiteSmoke;
                    scaleTextBox.TabStop = false;
                    projCodeTextBox.ReadOnly = true;
                    projCodeTextBox.BackColor = Color.WhiteSmoke;
                    projCodeTextBox.TabStop = false;

                    subTypeComboBox.Enabled = false;
                    govtComboBox.Enabled = false;

                    indexCheckBox.Enabled = false;

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
                Pen blackPen = new Pen(Color.Black);

                e.Graphics.DrawRectangle(blackPen, subTypeComboBox.Location.X - 1, subTypeComboBox.Location.Y - 1, subTypeComboBox.Width + 1, subTypeComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, govtComboBox.Location.X - 1, govtComboBox.Location.Y - 1, govtComboBox.Width + 1, govtComboBox.Height + 1);
            }
        }

        public void Add_Data(string Extent, string Marc_Date_Start, string Marc_Date_End, string Place_Code, string Language_Code, List<Subject_Info_Cartographics> Cartographics, List<Genre_Info> Genres)
        {
            // Save all the values first
            extent = Extent;
            marc_date_start = Marc_Date_Start;
            marc_date_end = Marc_Date_End;
            place_code = Place_Code;
            language_code = Language_Code;
            cartographics = Cartographics;
            genres = Genres;

            // Show the values
            extentTextBox.Text = extent;
            date1TextBox.Text = marc_date_start;
            date2TextBox.Text = marc_date_end;
            placeCodeTextBox.Text = place_code;
            languageCodeTextBox.Text = language_code;

            // Step through each genre
            foreach (Genre_Info thisGenre in genres)
            {
                // Check for sub type
                foreach (string thisItem in subTypeComboBox.Items)
                {
                    if (thisGenre.Genre_Term == thisItem)
                    {
                        subTypeComboBox.Text = thisGenre.Genre_Term;
                    }
                }

                // Check for sub type
                foreach (string thisItem in govtComboBox.Items)
                {
                    if (thisGenre.Genre_Term == thisItem)
                    {
                        govtComboBox.Text = thisGenre.Genre_Term;
                    }
                }

                if (thisGenre.Genre_Term == "indexed")
                    indexCheckBox.Checked = true;
            }


            // Step through each cartographic
            string scale = String.Empty;
            string scale_034 = String.Empty;
            string scale_255 = String.Empty;
            foreach (Subject_Info_Cartographics carto in cartographics)
            {
                if (carto.Scale.Length > 0)
                {
                    if (carto.ID.IndexOf("SUBJ034") >= 0)
                        scale_034 = carto.Scale;
                    else
                    {
                        if (carto.ID.IndexOf("SUBJ255") >= 0)
                            scale_255 = carto.Scale;
                        else
                            scale = carto.Scale;
                    }
                }
            }

            if (scale_255.Length > 0)
            {
                scaleTextBox.Text = scale_255.Replace("Scale", "").Replace("ca.", "").Trim();
            }

            if (scale_034.Length > 0)
            {
                scaleTextBox.Text = "1:" + scale_034;
            }

            if (scale.Length > 0)
            {
                scaleTextBox.Text = scale;
            }
           
            languageCodeTextBox.TextChanged += textChanged;
            placeCodeTextBox.TextChanged += textChanged;
            date1TextBox.TextChanged += textChanged;
            date2TextBox.TextChanged += textChanged;
            extentTextBox.TextChanged += textChanged;
            scaleTextBox.TextChanged += textChanged;
            projCodeTextBox.TextChanged += textChanged;
            subTypeComboBox.TextChanged += textChanged;
            govtComboBox.TextChanged += textChanged;
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

                cartographics.Clear();
                genres.Clear();

                if (subTypeComboBox.Text.Trim().Length > 0)
                {
                    genres.Add(new Genre_Info(subTypeComboBox.Text.Trim(), "marcgt"));
                }

                if (govtComboBox.Text.Trim().Length > 0)
                {
                    genres.Add(new Genre_Info(govtComboBox.Text.Trim(), "marcgt"));
                }

                if (indexCheckBox.Checked)
                {
                    genres.Add(new Genre_Info("indexed", "marcgt"));
                }

                if (projCodeTextBox.Text.Trim().Length > 0)
                {
                    Subject_Info_Cartographics projSubj = new Subject_Info_Cartographics();
                    projSubj.ID = "SUBJ008";
                    projSubj.Projection = projCodeTextBox.Text.Trim();
                    cartographics.Add(projSubj);
                }

                if (scaleTextBox.Text.Trim().Length > 0)
                {
                    string thisScale = scaleTextBox.Text.Trim();

                    Subject_Info_Cartographics scaleSubj = new Subject_Info_Cartographics();
                    scaleSubj.ID = "SUBJ034";
                    scaleSubj.Scale = thisScale.Replace("1:", "");
                    cartographics.Add(scaleSubj);

                    Subject_Info_Cartographics scaleSubj2 = new Subject_Info_Cartographics();
                    scaleSubj2.ID = "SUBJ255";
                    scaleSubj2.Scale = "Scale ca. " + thisScale;
                    cartographics.Add(scaleSubj2);
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
