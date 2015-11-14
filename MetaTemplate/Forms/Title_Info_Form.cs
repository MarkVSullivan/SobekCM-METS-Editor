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
    public partial class Title_Info_Form : Form
    {
        private Title_Info titleObject;
        private Note_Info statementOfResponsibility;
        private bool showMARC;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Title_Info_Form()
        {
            InitializeComponent();

            showMARC = false;

            titleObject = new Title_Info();
            statementOfResponsibility = new Note_Info(String.Empty, Note_Type_Enum.statement_of_responsibility);

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                titleTypeComboBox.FlatStyle = FlatStyle.Flat;
                authorityComboBox.FlatStyle = FlatStyle.Flat;
                displayComboBox.FlatStyle = FlatStyle.Flat;
                languageComboBox.FlatStyle = FlatStyle.Flat;
                nonSortTextBox.BorderStyle = BorderStyle.FixedSingle;
                titleTextBox.BorderStyle = BorderStyle.FixedSingle;
                subTitleTextBox.BorderStyle = BorderStyle.FixedSingle;
                responsibilityTextBox.BorderStyle = BorderStyle.FixedSingle;
                partName1TextBox.BorderStyle = BorderStyle.FixedSingle;
                partName2TextBox.BorderStyle = BorderStyle.FixedSingle;
                partNumber1TextBox.BorderStyle = BorderStyle.FixedSingle;
                partNumber2TextBox.BorderStyle = BorderStyle.FixedSingle;
                titleTypeTextBox.BorderStyle = BorderStyle.FixedSingle;
                checkBox1.FlatStyle = FlatStyle.Flat;
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
                    nonSortTextBox.ReadOnly = true;
                    nonSortTextBox.BackColor = Color.WhiteSmoke;
                    nonSortTextBox.TabStop = false;
                    titleTextBox.ReadOnly = true;
                    titleTextBox.BackColor = Color.WhiteSmoke;
                    titleTextBox.TabStop = false;
                    subTitleTextBox.ReadOnly = true;
                    subTitleTextBox.BackColor = Color.WhiteSmoke;
                    subTitleTextBox.TabStop = false;
                    responsibilityTextBox.ReadOnly = true;
                    responsibilityTextBox.BackColor = Color.WhiteSmoke;
                    responsibilityTextBox.TabStop = false;
                    partName1TextBox.ReadOnly = true;
                    partName1TextBox.BackColor = Color.WhiteSmoke;
                    partName1TextBox.TabStop = false;
                    partName2TextBox.ReadOnly = true;
                    partName2TextBox.BackColor = Color.WhiteSmoke;
                    partName2TextBox.TabStop = false;
                    partNumber1TextBox.ReadOnly = true;
                    partNumber1TextBox.BackColor = Color.WhiteSmoke;
                    partNumber1TextBox.TabStop = false;
                    partNumber2TextBox.ReadOnly = true;
                    partNumber2TextBox.BackColor = Color.WhiteSmoke;
                    partNumber2TextBox.TabStop = false;
                    titleTypeTextBox.ReadOnly = true;
                    titleTypeTextBox.BackColor = Color.WhiteSmoke;
                    titleTypeTextBox.TabStop = false;

                    titleTypeComboBox.Enabled = false;
                    authorityComboBox.Enabled = false;
                    displayComboBox.Enabled = false;
                    languageComboBox.Enabled = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if ((!isXP) && (!read_only))
            {
                Pen blackPen = new Pen(Color.Black);

                if (titleTypeComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(blackPen, titleTypeComboBox.Location.X - 1, titleTypeComboBox.Location.Y - 1, titleTypeComboBox.Width + 1, titleTypeComboBox.Height + 1);
                }
                e.Graphics.DrawRectangle(blackPen, authorityComboBox.Location.X - 1, authorityComboBox.Location.Y - 1, authorityComboBox.Width + 1, authorityComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, languageComboBox.Location.X - 1, languageComboBox.Location.Y - 1, languageComboBox.Width + 1, languageComboBox.Height + 1);
                if (displayComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(blackPen, displayComboBox.Location.X - 1, displayComboBox.Location.Y - 1, displayComboBox.Width + 1, displayComboBox.Height + 1);
                }
            }
        }

        public bool Show_MARC
        {
            set 
            { 
                showMARC = value;

                show_values_correctly();
            }
        }

        private void show_values_correctly()
        {
            if (showMARC)
            {
                responsibilityLabel.Text = "Statement of Responsibility [c]:";
                subTitleLabel.Text = "Sub Title [b]:";
                nonSortLabel.Text = "Non Sort [ind2]:";
                titleLabel.Text = "Title [a]:";
                partNameLabel.Text = "Part Name [p]:";
                partNumberLabel.Text = "Part Number [n]:";
            }
            else
            {
                responsibilityLabel.Text = "Statement of Responsibility:";
                subTitleLabel.Text = "Sub Title:";
                nonSortLabel.Text = "Non Sort:";
                titleLabel.Text = "Title:";
                partNameLabel.Text = "Part Name:";
                partNumberLabel.Text = "Part Number:";
            }
        }

        public void SetTitle(Title_Info Title_Object, Note_Info Statement_Of_Responsibility, bool mainTitle, bool seriesTitle, bool subjectTitle )
        {
            titleTypeComboBox.SelectedIndexChanged -= titleTypeComboBox_SelectedIndexChanged;


            // Save this title object
            titleObject = Title_Object;

            //// Set the MARC field
            //marc_field = 245;
            //if (seriesTitle)
            //    marc_field = 490;
            //if (subjectTitle)
            //    marc_field = 630;

            if (mainTitle)
            {
                titleTypeComboBox.Hide();
                titleTypeTextBox.Show();
                titleTypeTextBox.Text = "Main Title";
                displayComboBox.Hide();
                displayLabel.Hide();
                responsibilityLabel.Show();
                responsibilityTextBox.Show();
                if (Statement_Of_Responsibility != null)
                {
                    statementOfResponsibility = Statement_Of_Responsibility;
                    responsibilityTextBox.Text = statementOfResponsibility.Note;
                }
            }
            else
            {
                responsibilityLabel.Hide();
                responsibilityTextBox.Hide();

                if ((seriesTitle) || ( subjectTitle ))
                {
                    titleTypeComboBox.Hide();
                    titleTypeTextBox.Show();
                    if (seriesTitle)
                    {
                        titleTypeTextBox.Text = "Series Title";
                    }
                    else
                    {
                        titleTypeTextBox.Text = "Subject";
                    }
                    displayComboBox.Hide();
                    displayLabel.Hide();
                }
                else
                {
                    switch (titleObject.Title_Type)
                    {
                        case Title_Type_Enum.abbreviated:
                            titleTypeComboBox.Show();
                            titleTypeTextBox.Hide();
                            titleTypeComboBox.Items.Clear();
                            titleTypeComboBox.Items.Add("Abbreviated");
                            titleTypeComboBox.Items.Add("Alternative");
                            titleTypeComboBox.Items.Add("Translated");
                            titleTypeComboBox.SelectedIndex = 0;
                            displayComboBox.Hide();
                            displayLabel.Hide();
                            break;

                        case Title_Type_Enum.alternative:
                        case Title_Type_Enum.UNSPECIFIED:
                            titleTypeComboBox.Show();
                            titleTypeTextBox.Hide();
                            titleTypeComboBox.Items.Clear();
                            titleTypeComboBox.Items.Add("Abbreviated");
                            titleTypeComboBox.Items.Add("Alternative");
                            titleTypeComboBox.Items.Add("Translated");
                            titleTypeComboBox.SelectedIndex = 1;
                            displayComboBox.Show();
                            displayLabel.Show();
                            displayComboBox.Items.Clear();
                            displayComboBox.Items.Add("Added title page title");
                            displayComboBox.Items.Add("Alternate title");
                            displayComboBox.Items.Add("Caption title");
                            displayComboBox.Items.Add("Cover title");
                            displayComboBox.Items.Add("Distinctive title");
                            displayComboBox.Items.Add("Other title");
                            displayComboBox.Items.Add("Portion of title");
                            displayComboBox.Items.Add("Parallel title");
                            displayComboBox.Items.Add("Running title");
                            displayComboBox.Items.Add("Spine title");
                            if (displayComboBox.Items.Contains(titleObject.Display_Label))
                            {
                                displayComboBox.Text = titleObject.Display_Label;
                            }
                            else
                            {
                                displayComboBox.Text = "Alternate title";
                            }
                            break;

                        case Title_Type_Enum.translated:
                            titleTypeComboBox.Show();
                            titleTypeTextBox.Hide();
                            titleTypeComboBox.Items.Clear();
                            titleTypeComboBox.Items.Add("Abbreviated");
                            titleTypeComboBox.Items.Add("Alternative");
                            titleTypeComboBox.Items.Add("Translated");
                            titleTypeComboBox.SelectedIndex = 2;
                            displayComboBox.Hide();
                            displayLabel.Hide();
                            break;

                        case Title_Type_Enum.uniform:
                            titleTypeComboBox.Hide();
                            titleTypeTextBox.Show();
                            titleTypeTextBox.Text = "Uniform";
                            displayComboBox.Show();
                            displayLabel.Show();
                            displayComboBox.Items.Clear();
                            displayComboBox.Items.Add("Main Entry");
                            displayComboBox.Items.Add("Uncontrolled Added Entry");
                            displayComboBox.Items.Add("Uniform Title");
                            if (displayComboBox.Items.Contains(titleObject.Display_Label))
                            {
                                displayComboBox.Text = titleObject.Display_Label;
                            }
                            else
                            {
                                displayComboBox.Text = "Uniform Title";
                            }
                            break;
                    }
                }
            }

            // Set all the values appropriately
            nonSortTextBox.Text = titleObject.NonSort;
            titleTextBox.Text = titleObject.Title;
            subTitleTextBox.Text = titleObject.Subtitle;
            languageComboBox.Text = titleObject.Language;
            authorityComboBox.Text = titleObject.Authority;

            if (titleObject.Part_Names.Count > 0)
            {
                partName1TextBox.Text = titleObject.Part_Names[0];
            }
            if (titleObject.Part_Names.Count > 1)
            {
                partName2TextBox.Text = titleObject.Part_Names[1];
            }

            if (titleObject.Part_Numbers.Count > 0)
            {
                partNumber1TextBox.Text = titleObject.Part_Numbers[0];
            }
            if (titleObject.Part_Names.Count > 1)
            {
                partNumber2TextBox.Text = titleObject.Part_Numbers[1];
            }

            titleTypeComboBox.SelectedIndexChanged += titleTypeComboBox_SelectedIndexChanged;


            titleTypeComboBox.TextChanged += textChanged;
            authorityComboBox.TextChanged += textChanged;
            displayComboBox.TextChanged += textChanged;
            languageComboBox.TextChanged += textChanged;
            nonSortTextBox.TextChanged += textChanged;
            titleTextBox.TextChanged += textChanged;
            subTitleTextBox.TextChanged += textChanged;
            responsibilityTextBox.TextChanged += textChanged;
            partName1TextBox.TextChanged += textChanged;
            partName2TextBox.TextChanged += textChanged;
            partNumber1TextBox.TextChanged += textChanged;
            partNumber2TextBox.TextChanged += textChanged;
            titleTypeTextBox.TextChanged += textChanged;
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

                titleObject.NonSort = nonSortTextBox.Text.Trim();
                titleObject.Title = titleTextBox.Text.Trim();
                titleObject.Subtitle = subTitleTextBox.Text.Trim();
                if (displayComboBox.Visible)
                {
                    titleObject.Display_Label = displayComboBox.Text;
                }
                else
                {
                    titleObject.Display_Label = String.Empty;
                }
                titleObject.Clear_Part_Numbers();
                titleObject.Clear_Part_Names();
                if (partName1TextBox.Text.Trim().Length > 0)
                {
                    titleObject.Add_Part_Name(partName1TextBox.Text.Trim());
                }
                if (partName2TextBox.Text.Trim().Length > 0)
                {
                    titleObject.Add_Part_Name(partName2TextBox.Text.Trim());
                }
                if (partNumber1TextBox.Text.Trim().Length > 0)
                {
                    titleObject.Add_Part_Number(partNumber1TextBox.Text.Trim());
                }
                if (partNumber2TextBox.Text.Trim().Length > 0)
                {
                    titleObject.Add_Part_Number(partNumber2TextBox.Text.Trim());
                }
                titleObject.Language = languageComboBox.Text;
                titleObject.Authority = authorityComboBox.Text;
                if (titleTypeComboBox.Visible)
                {
                    switch (titleTypeComboBox.SelectedIndex)
                    {
                        case 0:
                            titleObject.Title_Type = Title_Type_Enum.abbreviated;
                            break;

                        case 1:
                            titleObject.Title_Type = Title_Type_Enum.alternative;
                            break;

                        case 2:
                            titleObject.Title_Type = Title_Type_Enum.translated;
                            break;
                    }
                }

                if ((statementOfResponsibility != null) && ( responsibilityTextBox.Visible ))
                {
                    statementOfResponsibility.Note = responsibilityTextBox.Text.Trim();
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

        private void radioButton_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((RadioButton)sender).BackColor = Color.Khaki;
            }
        }

        private void radioButton_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((RadioButton)sender).BackColor = panel1.BackColor;
            }
        }

        #endregion


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Show_MARC = checkBox1.Checked;

        }

        private void titleTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (titleTypeComboBox.SelectedIndex)
            {
                case 0:
                    titleObject.Title_Type = Title_Type_Enum.abbreviated;
                    break;

                case 1:
                    titleObject.Title_Type = Title_Type_Enum.alternative;
                    break;

                case 2:
                    titleObject.Title_Type = Title_Type_Enum.translated;
                    break;
            }

            SetTitle(titleObject, statementOfResponsibility, false, false, false);
        }

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
