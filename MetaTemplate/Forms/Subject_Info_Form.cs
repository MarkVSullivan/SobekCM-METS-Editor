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
    public partial class Subject_Info_Form : Form
    {
        private Subject_Info thisSubject;
        private bool fromPackage;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Subject_Info_Form()
        {
            InitializeComponent();

            thisSubject = new Subject_Info_Standard();
            fromPackage = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                checkBox1.FlatStyle = FlatStyle.Flat;
                typeComboBox.FlatStyle = FlatStyle.Flat;
                authorityComboBox.FlatStyle = FlatStyle.Flat;
                languageComboBox.FlatStyle = FlatStyle.Flat;
                marcComboBox.FlatStyle = FlatStyle.Flat;

                optionalTextBox.BorderStyle = BorderStyle.FixedSingle;
                geographic1TextBox.BorderStyle = BorderStyle.FixedSingle;
                temporal1TextBox.BorderStyle = BorderStyle.FixedSingle;
                topical1TextBox.BorderStyle = BorderStyle.FixedSingle;
                topical4TextBox.BorderStyle = BorderStyle.FixedSingle;
                topical2TextBox.BorderStyle = BorderStyle.FixedSingle;
                topical3TextBox.BorderStyle = BorderStyle.FixedSingle;
                temporal2TextBox.BorderStyle = BorderStyle.FixedSingle;
                geographic2TextBox.BorderStyle = BorderStyle.FixedSingle;
                genre2TextBox.BorderStyle = BorderStyle.FixedSingle;
                genre1TextBox.BorderStyle = BorderStyle.FixedSingle;

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
                    optionalTextBox.ReadOnly = true;
                    optionalTextBox.BackColor = Color.WhiteSmoke;
                    optionalTextBox.TabStop = false;
                    geographic1TextBox.ReadOnly = true;
                    geographic1TextBox.BackColor = Color.WhiteSmoke;
                    geographic1TextBox.TabStop = false;
                    temporal1TextBox.ReadOnly = true;
                    temporal1TextBox.BackColor = Color.WhiteSmoke;
                    temporal1TextBox.TabStop = false;
                    topical1TextBox.ReadOnly = true;
                    topical1TextBox.BackColor = Color.WhiteSmoke;
                    topical1TextBox.TabStop = false;
                    topical4TextBox.ReadOnly = true;
                    topical4TextBox.BackColor = Color.WhiteSmoke;
                    topical4TextBox.TabStop = false;
                    topical2TextBox.ReadOnly = true;
                    topical2TextBox.BackColor = Color.WhiteSmoke;
                    topical2TextBox.TabStop = false;
                    topical3TextBox.ReadOnly = true;
                    topical3TextBox.BackColor = Color.WhiteSmoke;
                    topical3TextBox.TabStop = false;
                    temporal2TextBox.ReadOnly = true;
                    temporal2TextBox.BackColor = Color.WhiteSmoke;
                    temporal2TextBox.TabStop = false;
                    geographic2TextBox.ReadOnly = true;
                    geographic2TextBox.BackColor = Color.WhiteSmoke;
                    geographic2TextBox.TabStop = false;
                    genre2TextBox.ReadOnly = true;
                    genre2TextBox.BackColor = Color.WhiteSmoke;
                    genre2TextBox.TabStop = false;
                    genre1TextBox.ReadOnly = true;
                    genre1TextBox.BackColor = Color.WhiteSmoke;
                    genre1TextBox.TabStop = false;

                    typeComboBox.Enabled = false;
                    authorityComboBox.Enabled = false;
                    languageComboBox.Enabled = false;
                    marcComboBox.Enabled = false;

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

                e.Graphics.DrawRectangle(blackPen, typeComboBox.Location.X - 1, typeComboBox.Location.Y - 1, typeComboBox.Width + 1, typeComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, authorityComboBox.Location.X - 1, authorityComboBox.Location.Y - 1, authorityComboBox.Width + 1, authorityComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, languageComboBox.Location.X - 1, languageComboBox.Location.Y - 1, languageComboBox.Width + 1, languageComboBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, marcComboBox.Location.X - 1, marcComboBox.Location.Y - 1, marcComboBox.Width + 1, marcComboBox.Height + 1);
            }
        }

        public void SetSubject(Subject_Info Subject)
        {
            fromPackage = true;
            typeComboBox.SelectedIndexChanged -= typeComboBox_SelectedIndexChanged;

            // Save the subject
            thisSubject = Subject;

            // Display the values at the base class level
            languageComboBox.Text = thisSubject.Language;
            authorityComboBox.Text = thisSubject.Authority;

            // Display data according to subject type
            switch (thisSubject.Class_Type)
            {
                case Subject_Info_Type.Name:
                    marcComboBox.Hide();
                    marcLabel.Hide();
                    optionalLabel.Text = "Name:";
                    typeComboBox.SelectedIndex = 0;
                    Subject_Info_Name nameSubject = (Subject_Info_Name)thisSubject;
                    optionalTextBox.Text = nameSubject.Name_Object.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
                    optionalTextBox.ReadOnly = true;
                    if (nameSubject.Topics.Count > 0)
                    {
                        topical1TextBox.Text = nameSubject.Topics[0];
                    }
                    if (nameSubject.Topics.Count > 1)
                    {
                        topical2TextBox.Text = nameSubject.Topics[1];
                    }
                    if (nameSubject.Topics.Count > 2)
                    {
                        topical3TextBox.Text = nameSubject.Topics[2];
                    }
                    if (nameSubject.Topics.Count > 3)
                    {
                        topical4TextBox.Text = nameSubject.Topics[3];
                    }
                    if (nameSubject.Temporals.Count > 0)
                    {
                        temporal1TextBox.Text = nameSubject.Temporals[0];
                    }
                    if (nameSubject.Temporals.Count > 1)
                    {
                        temporal2TextBox.Text = nameSubject.Temporals[1];
                    }
                    if (nameSubject.Geographics.Count > 0)
                    {
                        geographic1TextBox.Text = nameSubject.Geographics[0];
                    }
                    if (nameSubject.Geographics.Count > 1)
                    {
                        geographic2TextBox.Text = nameSubject.Geographics[1];
                    }
                    if (nameSubject.Genres.Count > 0)
                    {
                        genre1TextBox.Text = nameSubject.Genres[0];
                    }
                    if (nameSubject.Genres.Count > 1)
                    {
                        genre2TextBox.Text = nameSubject.Genres[1];
                    }
                    break;

                case Subject_Info_Type.TitleInfo:
                    marcComboBox.Hide();
                    marcLabel.Hide();
                    optionalLabel.Text = "Title:";
                    typeComboBox.SelectedIndex = 2;
                    Subject_Info_TitleInfo titleSubject = (Subject_Info_TitleInfo)thisSubject;
                    optionalTextBox.Text = titleSubject.Title_Object.ToString();
                    optionalTextBox.ReadOnly = true;
                    if (titleSubject.Topics.Count > 0)
                    {
                        topical1TextBox.Text = titleSubject.Topics[0];
                    }
                    if (titleSubject.Topics.Count > 1)
                    {
                        topical2TextBox.Text = titleSubject.Topics[1];
                    }
                    if (titleSubject.Topics.Count > 2)
                    {
                        topical3TextBox.Text = titleSubject.Topics[2];
                    }
                    if (titleSubject.Topics.Count > 3)
                    {
                        topical4TextBox.Text = titleSubject.Topics[3];
                    }
                    if (titleSubject.Temporals.Count > 0)
                    {
                        temporal1TextBox.Text = titleSubject.Temporals[0];
                    }
                    if (titleSubject.Temporals.Count > 1)
                    {
                        temporal2TextBox.Text = titleSubject.Temporals[1];
                    }
                    if (titleSubject.Geographics.Count > 0)
                    {
                        geographic1TextBox.Text = titleSubject.Geographics[0];
                    }
                    if (titleSubject.Geographics.Count > 1)
                    {
                        geographic2TextBox.Text = titleSubject.Geographics[1];
                    }
                    if (titleSubject.Genres.Count > 0)
                    {
                        genre1TextBox.Text = titleSubject.Genres[0];
                    }
                    if (titleSubject.Genres.Count > 1)
                    {
                        genre2TextBox.Text = titleSubject.Genres[1];
                    }
                    break;

                case Subject_Info_Type.Standard:
                    marcComboBox.Show();
                    marcLabel.Show();
                    optionalLabel.Text = "Occupation:";
                    optionalTextBox.ReadOnly = false;
                    optionalTextBox.Clear();
                    typeComboBox.SelectedIndex = 1;
                    Subject_Info_Standard standardSubject = (Subject_Info_Standard)thisSubject;
                    if (standardSubject.Topics.Count > 0)
                    {
                        topical1TextBox.Text = standardSubject.Topics[0];
                    }
                    if (standardSubject.Topics.Count > 1)
                    {
                        topical2TextBox.Text = standardSubject.Topics[1];
                    }
                    if (standardSubject.Topics.Count > 2)
                    {
                        topical3TextBox.Text = standardSubject.Topics[2];
                    }
                    if (standardSubject.Topics.Count > 3)
                    {
                        topical4TextBox.Text = standardSubject.Topics[3];
                    }
                    if (standardSubject.Temporals.Count > 0)
                    {
                        temporal1TextBox.Text = standardSubject.Temporals[0];
                    }
                    if (standardSubject.Temporals.Count > 1)
                    {
                        temporal2TextBox.Text = standardSubject.Temporals[1];
                    }
                    if (standardSubject.Geographics.Count > 0)
                    {
                        geographic1TextBox.Text = standardSubject.Geographics[0];
                    }
                    if (standardSubject.Geographics.Count > 1)
                    {
                        geographic2TextBox.Text = standardSubject.Geographics[1];
                    }
                    if (standardSubject.Genres.Count > 0)
                    {
                        genre1TextBox.Text = standardSubject.Genres[0];
                    }
                    if (standardSubject.Genres.Count > 1)
                    {
                        genre2TextBox.Text = standardSubject.Genres[1];
                    }
                    if (standardSubject.Occupations.Count > 0)
                    {
                        optionalTextBox.Text = standardSubject.Occupations[0];
                    }
                    if (standardSubject.ID.IndexOf("SUBJ648") >= 0)
                    {
                        marcComboBox.SelectedIndex = 1;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ650") >= 0)
                    {
                        marcComboBox.SelectedIndex = 2;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ651") >= 0)
                    {
                        marcComboBox.SelectedIndex = 3;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ653") >= 0)
                    {
                        marcComboBox.SelectedIndex = 4;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ654") >= 0)
                    {
                        marcComboBox.SelectedIndex = 5;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ655") >= 0)
                    {
                        marcComboBox.SelectedIndex = 6;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ656") >= 0)
                    {
                        marcComboBox.SelectedIndex = 7;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ657") >= 0)
                    {
                        marcComboBox.SelectedIndex = 8;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ690") >= 0)
                    {
                        marcComboBox.SelectedIndex = 9;
                    }
                    if (standardSubject.ID.IndexOf("SUBJ691") >= 0)
                    {
                        marcComboBox.SelectedIndex = 10;
                    }

                    break;
            }

            typeComboBox.SelectedIndexChanged += typeComboBox_SelectedIndexChanged;

            typeComboBox.TextChanged += textChanged;
            authorityComboBox.TextChanged += textChanged;
            languageComboBox.TextChanged += textChanged;
            marcComboBox.TextChanged += textChanged;

            optionalTextBox.TextChanged += textChanged;
            geographic1TextBox.TextChanged += textChanged;
            temporal1TextBox.TextChanged += textChanged;
            topical1TextBox.TextChanged += textChanged;
            topical4TextBox.TextChanged += textChanged;
            topical2TextBox.TextChanged += textChanged;
            topical3TextBox.TextChanged += textChanged;
            temporal2TextBox.TextChanged += textChanged;
            geographic2TextBox.TextChanged += textChanged;
            genre2TextBox.TextChanged += textChanged;
            genre1TextBox.TextChanged += textChanged;
        }

        public bool From_Package
        {
            get { return fromPackage; }
        }

        public Subject_Info Subject_Object
        {
            get 
            {
                if (saved)
                    return thisSubject;
                else
                    return null;
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

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                saved = true;
                switch (typeComboBox.SelectedIndex)
                {
                    case 0:
                        Subject_Info_Name nameSubject = (Subject_Info_Name)thisSubject;
                        nameSubject.Clear_Topics();
                        nameSubject.Clear_Temporals();
                        nameSubject.Clear_Genres();
                        nameSubject.Clear_Geographics();
                        if (topical1TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Topic(topical1TextBox.Text.Trim());
                        if (topical2TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Topic(topical2TextBox.Text.Trim());
                        if (topical3TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Topic(topical3TextBox.Text.Trim());
                        if (topical4TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Topic(topical4TextBox.Text.Trim());
                        if (temporal1TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Temporal(temporal1TextBox.Text.Trim());
                        if (temporal2TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Temporal(temporal2TextBox.Text.Trim());
                        if (geographic1TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Geographic(geographic1TextBox.Text.Trim());
                        if (geographic2TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Geographic(geographic2TextBox.Text.Trim());
                        if (genre1TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Genre(genre1TextBox.Text.Trim());
                        if (genre2TextBox.Text.Trim().Length > 0)
                            nameSubject.Add_Genre(genre2TextBox.Text.Trim());
                        nameSubject.Authority = authorityComboBox.Text;
                        nameSubject.Language = languageComboBox.Text;
                        thisSubject = nameSubject;
                        break;

                    case 1:
                        Subject_Info_Standard standardSubject = (Subject_Info_Standard)thisSubject;
                        standardSubject.Clear_Topics();
                        standardSubject.Clear_Temporals();
                        standardSubject.Clear_Genres();
                        standardSubject.Clear_Geographics();
                        standardSubject.Clear_Occupations();
                        if (topical1TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Topic(topical1TextBox.Text.Trim());
                        if (topical2TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Topic(topical2TextBox.Text.Trim());
                        if (topical3TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Topic(topical3TextBox.Text.Trim());
                        if (topical4TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Topic(topical4TextBox.Text.Trim());
                        if (temporal1TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Temporal(temporal1TextBox.Text.Trim());
                        if (temporal2TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Temporal(temporal2TextBox.Text.Trim());
                        if (geographic1TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Geographic(geographic1TextBox.Text.Trim());
                        if (geographic2TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Geographic(geographic2TextBox.Text.Trim());
                        if (genre1TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Genre(genre1TextBox.Text.Trim());
                        if (genre2TextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Genre(genre2TextBox.Text.Trim());
                        if (optionalTextBox.Text.Trim().Length > 0)
                            standardSubject.Add_Occupation(optionalTextBox.Text.Trim());
                        standardSubject.Authority = authorityComboBox.Text;
                        standardSubject.Language = languageComboBox.Text;
                        thisSubject = standardSubject;

                        if (marcComboBox.Text.Length > 0)
                        {
                            switch (marcComboBox.SelectedIndex)
                            {
                                case 1:
                                    if (standardSubject.ID.IndexOf("SUBJ648") < 0)
                                        standardSubject.ID = "SUBJ648";
                                    break;

                                case 2:
                                    if (standardSubject.ID.IndexOf("SUBJ650") < 0)
                                        standardSubject.ID = "SUBJ650";
                                    break;

                                case 3:
                                    if (standardSubject.ID.IndexOf("SUBJ651") < 0)
                                        standardSubject.ID = "SUBJ651";
                                    break;

                                case 4:
                                    if (standardSubject.ID.IndexOf("SUBJ653") < 0)
                                        standardSubject.ID = "SUBJ653";
                                    break;

                                case 5:
                                    if (standardSubject.ID.IndexOf("SUBJ654") < 0)
                                        standardSubject.ID = "SUBJ654";
                                    break;

                                case 6:
                                    if (standardSubject.ID.IndexOf("SUBJ655") < 0)
                                        standardSubject.ID = "SUBJ655";
                                    break;

                                case 7:
                                    if (standardSubject.ID.IndexOf("SUBJ656") < 0)
                                        standardSubject.ID = "SUBJ656";
                                    break;

                                case 8:
                                    if (standardSubject.ID.IndexOf("SUBJ657") < 0)
                                        standardSubject.ID = "SUBJ657";
                                    break;

                                case 9:
                                    if (standardSubject.ID.IndexOf("SUBJ690") < 0)
                                        standardSubject.ID = "SUBJ690";
                                    break;

                                case 10:
                                    if (standardSubject.ID.IndexOf("SUBJ691") < 0)
                                        standardSubject.ID = "SUBJ691";
                                    break;
                            }
                        }
                        else
                        {
                            if (thisSubject.ID.IndexOf("SUBJ") >= 0)
                                thisSubject.ID = String.Empty;
                        }
                        break;

                    case 2:
                        Subject_Info_TitleInfo titleSubject = (Subject_Info_TitleInfo)thisSubject;
                        titleSubject.Clear_Topics();
                        titleSubject.Clear_Temporals();
                        titleSubject.Clear_Genres();
                        titleSubject.Clear_Geographics();
                        if (topical1TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Topic(topical1TextBox.Text.Trim());
                        if (topical2TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Topic(topical2TextBox.Text.Trim());
                        if (topical3TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Topic(topical3TextBox.Text.Trim());
                        if (topical4TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Topic(topical4TextBox.Text.Trim());
                        if (temporal1TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Temporal(temporal1TextBox.Text.Trim());
                        if (temporal2TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Temporal(temporal2TextBox.Text.Trim());
                        if (geographic1TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Geographic(geographic1TextBox.Text.Trim());
                        if (geographic2TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Geographic(geographic2TextBox.Text.Trim());
                        if (genre1TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Genre(genre1TextBox.Text.Trim());
                        if (genre2TextBox.Text.Trim().Length > 0)
                            titleSubject.Add_Genre(genre2TextBox.Text.Trim());
                        titleSubject.Authority = authorityComboBox.Text;
                        titleSubject.Language = languageComboBox.Text;
                        thisSubject = titleSubject;
                        break;
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

        #endregion

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromPackage = false;

            switch (typeComboBox.SelectedIndex)
            {
                case 0:
                    optionalLabel.Text = "Name:";
                    marcComboBox.Hide();
                    marcLabel.Hide();
                    optionalTextBox.ReadOnly = true;
                    optionalTextBox.Clear();
                    thisSubject = new Subject_Info_Name();
                    break;

                case 1:
                    optionalLabel.Text = "Occupation:";
                    marcComboBox.Show();
                    marcLabel.Show();
                    optionalTextBox.ReadOnly = false;
                    optionalTextBox.Clear();
                    thisSubject = new Subject_Info_Standard();
                    break;

                case 2:
                    optionalLabel.Text = "Title:";
                    marcComboBox.Hide();
                    marcLabel.Hide();
                    optionalTextBox.ReadOnly = true;
                    optionalTextBox.Clear();
                    thisSubject = new Subject_Info_TitleInfo();
                    break;
            }
        }

        private void optionalTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (optionalTextBox.ReadOnly)
            {
                switch (thisSubject.Class_Type)
                {
                    case Subject_Info_Type.TitleInfo:
                        Title_Info_Form showTitleInfo = new Title_Info_Form();
                        showTitleInfo.SetTitle(((Subject_Info_TitleInfo)thisSubject).Title_Object, null, false, false, true );
                        showTitleInfo.Read_Only = read_only;
                        showTitleInfo.ShowDialog();
                        optionalTextBox.Text = ((Subject_Info_TitleInfo)thisSubject).Title_Object.ToString();
                        break;

                    case Subject_Info_Type.Name:
                        Name_Info_Form showNameInfo = new Name_Info_Form();
                        showNameInfo.SetName(((Subject_Info_Name)thisSubject).Name_Object, true, false, null, false);
                        showNameInfo.Read_Only = read_only;
                        showNameInfo.ShowDialog();
                        optionalTextBox.Text = ((Subject_Info_Name)thisSubject).Name_Object.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\""); ;
                        break;
                }
            }
        }

        private void optionalTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (optionalTextBox.ReadOnly)
            {
                switch (thisSubject.Class_Type)
                {
                    case Subject_Info_Type.TitleInfo:
                        Title_Info_Form showTitleInfo = new Title_Info_Form();
                        showTitleInfo.SetTitle(((Subject_Info_TitleInfo)thisSubject).Title_Object, null, false, false, true);
                        showTitleInfo.Read_Only = read_only;
                        showTitleInfo.ShowDialog();
                        optionalTextBox.Text = ((Subject_Info_TitleInfo)thisSubject).Title_Object.ToString();
                        break;

                    case Subject_Info_Type.Name:
                        Name_Info_Form showNameInfo = new Name_Info_Form();
                        showNameInfo.SetName(((Subject_Info_Name)thisSubject).Name_Object, true, false, null, false);
                        showNameInfo.Read_Only = read_only;
                        showNameInfo.ShowDialog();
                        optionalTextBox.Text = ((Subject_Info_Name)thisSubject).Name_Object.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\""); ;
                        break;
                }
            }
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
