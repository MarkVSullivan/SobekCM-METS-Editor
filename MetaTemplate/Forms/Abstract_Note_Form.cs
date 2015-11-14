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
    public partial class Abstract_Note_Form : Form
    {
        private bool isAbstract;
        private Note_Info thisNote;
        private Abstract_Info thisAbstract;
        private bool showMARC;
        private bool isXP;
        private bool read_only;
        private bool changed;
        private bool saved;

        public Abstract_Note_Form()
        {
            InitializeComponent();

            isAbstract = false;
            thisNote = new Note_Info();
            showMARC = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                noteTextBox.BorderStyle = BorderStyle.FixedSingle;
                languageComboBox.FlatStyle = FlatStyle.Flat;
                subfieldTextBox.BorderStyle = BorderStyle.FixedSingle;
                castCheckBox.FlatStyle = FlatStyle.Flat;
                typeComboBox.FlatStyle = FlatStyle.Flat;
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
                    castCheckBox.Enabled = false;
                    typeComboBox.Enabled = false;
                    languageComboBox.Enabled = false;
                    noteTextBox.ReadOnly = true;
                    noteTextBox.BackColor = Color.WhiteSmoke;
                    subfieldTextBox.ReadOnly = true;
                    subfieldTextBox.BackColor = Color.WhiteSmoke;
                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                    noteTextBox.TabStop = false;

                }
                else
                {
                    castCheckBox.Enabled = true;
                    typeComboBox.Enabled = true;
                    languageComboBox.Enabled = true;
                    noteTextBox.ReadOnly = false;
                    noteTextBox.BackColor = Color.White;
                    subfieldTextBox.ReadOnly = false;
                    subfieldTextBox.BackColor = Color.White;
                    cancelButton.Show();
                    saveButton.Button_Text = "SAVE";
                }

            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if ((!isXP) && (!read_only))
            {
                Pen blackPen = new Pen(Color.Black);

                if (languageComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(blackPen, languageComboBox.Location.X - 1, languageComboBox.Location.Y - 1, languageComboBox.Width + 1, languageComboBox.Height + 1);
                }
                if (typeComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(blackPen, typeComboBox.Location.X - 1, typeComboBox.Location.Y - 1, typeComboBox.Width + 1, typeComboBox.Height + 1);
                }
            }
        }

        public void SetNote( Note_Info Note )
        {
            thisAbstract = null;
            thisNote = Note;
            isAbstract = false;

            show_values();
        }

        public void SetAbstract( Abstract_Info Abstract )
        {
            thisAbstract = Abstract;
            thisNote = null;
            isAbstract = true;

            show_values();
        }

        private void show_values()
        {
            if (isAbstract)
            {
                if (showMARC)
                {
                    Text = "Edit Abstract [520]";
                    noteLabel.Text = "Abstract [a]:";
                }
                else
                {
                    Text = "Edit Abstract";
                    noteLabel.Text = "Abstract:";
                }
                noteTextBox.Text = thisAbstract.Abstract_Text;
                languageComboBox.Text = thisAbstract.Language;
                subfieldTextBox.Hide();
                castCheckBox.Hide();
                typeComboBox.Items.Clear();
                typeComboBox.Items.Add("Abstract");
                typeComboBox.Items.Add("Content Advice");
                typeComboBox.Items.Add("Review");
                typeComboBox.Items.Add("Scope and Content");
                typeComboBox.Items.Add("Subject");
                typeComboBox.Items.Add("Summary");
                switch( thisAbstract.Type.ToUpper() )
                {
                    case "SUMMARY":
                        typeComboBox.Text = "Summary";
                        break;

                    case "SUBJECT":
                        typeComboBox.Text = "Subject";
                        break;

                    case "REVIEW":
                        typeComboBox.Text = "Review";
                        break;

                    case "SCOPE AND CONTENT":
                        typeComboBox.Text = "Scope and Content";
                        break;

                    case "CONTENT ADVICE":
                        typeComboBox.Text = "Content Advice";
                        break;

                    default:
                        typeComboBox.Text = "Abstract";
                        break;
                }
            }
            else
            {
                if (showMARC)
                {
                    Text = "Edit Note [5xx]";
                    noteLabel.Text = "Note [a]:";
                }
                else
                {
                    Text = "Edit Note";
                    noteLabel.Text = "Note:";
                }
                noteTextBox.Text = thisNote.Note;
                languageComboBox.Hide();
                typeComboBox.Items.Clear();
                if (showMARC)
                {
                    typeComboBox.Items.Add("[500]");
                    typeComboBox.Items.Add("Acquisition [541]");
                    typeComboBox.Items.Add("Additional Physical Form [530]");
                    typeComboBox.Items.Add("Bibliography [504]");
                    typeComboBox.Items.Add("Biographical [545]");
                    typeComboBox.Items.Add("Citation/Reference [510]");
                    typeComboBox.Items.Add("Creation/Production Credits [508]");
                    typeComboBox.Items.Add("Dates or Sequential Designation [362]");
                    typeComboBox.Items.Add("Donation");
                    typeComboBox.Items.Add("Exhibitions [585]");
                    typeComboBox.Items.Add("Funding [536]");
                    typeComboBox.Items.Add("Internal Comments");
                    typeComboBox.Items.Add("Issuing Body [550]");
                    typeComboBox.Items.Add("Language [546]");
                    typeComboBox.Items.Add("Numbering Peculiarities [515]");
                    typeComboBox.Items.Add("Original Location [535]");
                    typeComboBox.Items.Add("Original Version [534]");
                    typeComboBox.Items.Add("Ownership [561]");
                    typeComboBox.Items.Add("Performers [511]");
                    typeComboBox.Items.Add("Preferred Citation [524]");
                    typeComboBox.Items.Add("Publications [581]");
                    typeComboBox.Items.Add("Restriction [506]");
                    typeComboBox.Items.Add("Statement of Responsibility [260 |c]");
                    typeComboBox.Items.Add("System Details [538]");
                    typeComboBox.Items.Add("Thesis [502]");
                    typeComboBox.Items.Add("Venue [518]");
                    typeComboBox.Items.Add("Version Identification [562]");
                }
                else
                {
                    typeComboBox.Items.Add("");
                    typeComboBox.Items.Add("Acquisition");
                    typeComboBox.Items.Add("Additional Physical Form");
                    typeComboBox.Items.Add("Bibliography");
                    typeComboBox.Items.Add("Biographical");
                    typeComboBox.Items.Add("Citation/Reference");
                    typeComboBox.Items.Add("Creation/Production Credits");
                    typeComboBox.Items.Add("Dates or Sequential Designation");
                    typeComboBox.Items.Add("Donation");
                    typeComboBox.Items.Add("Exhibitions");
                    typeComboBox.Items.Add("Funding");
                    typeComboBox.Items.Add("Internal Comments");
                    typeComboBox.Items.Add("Issuing Body");
                    typeComboBox.Items.Add("Language");
                    typeComboBox.Items.Add("Numbering Peculiarities");
                    typeComboBox.Items.Add("Original Location");
                    typeComboBox.Items.Add("Original Version");
                    typeComboBox.Items.Add("Ownership");
                    typeComboBox.Items.Add("Performers");
                    typeComboBox.Items.Add("Preferred Citation");
                    typeComboBox.Items.Add("Publications");
                    typeComboBox.Items.Add("Restriction");
                    typeComboBox.Items.Add("Statement of Responsibility");
                    typeComboBox.Items.Add("System Details");
                    typeComboBox.Items.Add("Thesis");
                    typeComboBox.Items.Add("Venue");
                    typeComboBox.Items.Add("Version Identification");
                }

                int index = 0;
                string note_display_string = thisNote.Note_Type_Display_String;
                if (note_display_string.Trim().Length == 0)
                {
                    typeComboBox.SelectedIndex = 0;
                }
                else
                {
                    for (int i = 1; i < typeComboBox.Items.Count; i++)
                    {
                        if (typeComboBox.Items[i].ToString().IndexOf(note_display_string) == 0)
                        {
                            typeComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }

                if (((typeComboBox.Text == "Performers") || (typeComboBox.Text == "Performers [511]")) && (thisNote.Display_Label == "cast"))
                {
                    castCheckBox.Checked = true;
                }

                show_note_subfield();
            }


            typeComboBox.TextChanged += textChanged;
            languageComboBox.TextChanged += textChanged;
            castCheckBox.CheckedChanged += checkedChanged;
            noteTextBox.TextChanged += textChanged;
            subfieldTextBox.TextChanged += textChanged;
        }

        private void show_note_subfield()
        {
            string typeFromBox = typeComboBox.Text;
            if (typeFromBox.IndexOf("[") > 0)
                typeFromBox = typeFromBox.Substring(0, typeFromBox.IndexOf("[")).Trim();
            if ((typeFromBox == "Ownership") || (typeFromBox == "Venue") || (typeFromBox == "Preferred Citation") ||
                (typeFromBox == "Language") || (typeFromBox == "Publications") || (typeFromBox == "Exhibitions") ||
                (typeFromBox == "Performers") || (typeFromBox == "Dates or Sequential Designation"))
            {
                if ((typeFromBox == "Performers") || (typeFromBox == "Dates or Sequential Designation"))
                {
                    if (typeFromBox == "Performers")
                    {
                        castCheckBox.Show();
                        languageLabel.Hide();
                        subfieldTextBox.Hide();
                    }
                    else
                    {
                        castCheckBox.Hide();
                        languageLabel.Show();
                        subfieldTextBox.Show();
                        if (showMARC)
                        {
                            languageLabel.Text = "Source:";
                        }
                        else
                        {
                            languageLabel.Text = "Source [3]:";
                        }
                        subfieldTextBox.Text = thisNote.Display_Label;
                    }
                }
                else
                {
                    castCheckBox.Hide();
                    languageLabel.Show();
                    subfieldTextBox.Show();
                    if (showMARC)
                    {
                        languageLabel.Text = "Materials Specified [3]:";
                    }
                    else
                    {
                        languageLabel.Text = "Materials Specified:";
                    }
                    subfieldTextBox.Text = thisNote.Display_Label;
                }
            }
            else
            {
                castCheckBox.Hide();
                subfieldTextBox.Hide();
                languageLabel.Hide();
            }
        }

        public bool Show_MARC
        {
            set
            {
                showMARC = value;

                show_values();
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

                if (isAbstract)
                {
                    thisAbstract.Abstract_Text = noteTextBox.Text.Trim();
                    thisAbstract.Language = languageComboBox.Text;
                    switch (typeComboBox.Text)
                    {
                        case "Content Advice":
                            thisAbstract.Type = "content advice";
                            thisAbstract.Display_Label = "Content Advice";
                            break;

                        case "Review":
                            thisAbstract.Type = "review";
                            thisAbstract.Display_Label = "Review";
                            break;

                        case "Scope and Content":
                            thisAbstract.Type = "scope and content";
                            thisAbstract.Display_Label = "Scope and Content";
                            break;

                        case "Subject":
                            thisAbstract.Type = "subject";
                            thisAbstract.Display_Label = "Subject";
                            break;

                        case "Summary":
                            thisAbstract.Type = "summary";
                            thisAbstract.Display_Label = "Summary";
                            break;

                        default:
                            thisAbstract.Type = String.Empty;
                            thisAbstract.Display_Label = String.Empty;
                            break;
                    }
                }
                else
                {
                    thisNote.Note = noteTextBox.Text.Trim();
                    string typeFromBox = typeComboBox.Text;
                    if (typeFromBox.IndexOf("[") > 0)
                        typeFromBox = typeFromBox.Substring(0, typeFromBox.IndexOf("[")).Trim();
                    thisNote.Note_Type_String = typeFromBox;

                    if (subfieldTextBox.Visible)
                    {
                        thisNote.Display_Label = subfieldTextBox.Text;
                    }
                    else
                    {
                        thisNote.Display_Label = String.Empty;
                    }

                    if (castCheckBox.Visible)
                    {
                        if (castCheckBox.Checked)
                        {
                            thisNote.Display_Label = "cast";
                        }
                        else
                        {
                            thisNote.Display_Label = String.Empty;
                        }
                    }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Show_MARC = checkBox1.Checked;

        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAbstract)
            {
                show_note_subfield();
            }

        }

        private void castCheckBox_Enter(object sender, EventArgs e)
        {
            castCheckBox.BackColor = Color.Khaki;
        }

        private void castCheckBox_Leave(object sender, EventArgs e)
        {
            castCheckBox.BackColor = panel1.BackColor;
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
