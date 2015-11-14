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
    public partial class Name_Info_Form : Form
    {
        private Name_Info nameObject;
        private Affiliation_Info affiliationInfo;
        private bool showMARC;
        private bool usedAsSubject;
        private bool isDonor;
        private bool isXP;
        private bool read_only;
        private bool mainEntry;
        private bool saved;
        private bool changed;
        private bool affiliation_changed;

        public Name_Info_Form()
        {
            InitializeComponent();

            nameTypeComboBox.SelectedIndex = 2;

            role1authorityTextBox.SelectedIndex = 0;
            role2authorityTextBox.SelectedIndex = 0;
            role3authorityTextBox.SelectedIndex = 0;
            role4authorityTextBox.SelectedIndex = 0;

            role1typeTextBox.SelectedIndex = 1;
            role2typeTextBox.SelectedIndex = 1;
            role3typeTextBox.SelectedIndex = 1;
            role4typeTextBox.SelectedIndex = 1;

            showMARC = false;
            usedAsSubject = false;
            nameObject = new Name_Info();
            mainEntry = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                nameTypeComboBox.FlatStyle = FlatStyle.Flat;
                fullNameTextBox.BorderStyle = BorderStyle.FixedSingle;
                familyNameTextBox.BorderStyle = BorderStyle.FixedSingle;
                givenNameTextBox.BorderStyle = BorderStyle.FixedSingle;
                displayFormTextBox.BorderStyle = BorderStyle.FixedSingle;
                descriptionTextBox.BorderStyle = BorderStyle.FixedSingle;
                affiliationTextBox.BorderStyle = BorderStyle.FixedSingle;
                datesTextBox.BorderStyle = BorderStyle.FixedSingle;
                termsOfAddressTextBox.BorderStyle = BorderStyle.FixedSingle;
                checkBox1.FlatStyle = FlatStyle.Flat;
                mainEntryRadioButton.FlatStyle = FlatStyle.Flat;
                addedEntryRadioButton.FlatStyle = FlatStyle.Flat;
                hierAffiliationTextBox.BorderStyle = BorderStyle.FixedSingle;

                role1termTextBox.Multiline = true;
                role2termTextBox.Multiline = true;
                role3termTextBox.Multiline = true;
                role4termTextBox.Multiline = true;
                role1termTextBox.BorderStyle = BorderStyle.None;
                role2termTextBox.BorderStyle = BorderStyle.None;
                role3termTextBox.BorderStyle = BorderStyle.None;
                role4termTextBox.BorderStyle = BorderStyle.None;

                role1authorityTextBox.FlatStyle = FlatStyle.Flat;
                role2authorityTextBox.FlatStyle = FlatStyle.Flat;
                role3authorityTextBox.FlatStyle = FlatStyle.Flat;
                role4authorityTextBox.FlatStyle = FlatStyle.Flat;

                role1typeTextBox.FlatStyle = FlatStyle.Flat;
                role2typeTextBox.FlatStyle = FlatStyle.Flat;
                role3typeTextBox.FlatStyle = FlatStyle.Flat;
                role4typeTextBox.FlatStyle = FlatStyle.Flat;
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
                    mainEntryRadioButton.Enabled = false;
                    addedEntryRadioButton.Enabled = false;
                    role1termTextBox.ReadOnly = true;
                    role1termTextBox.BackColor = Color.WhiteSmoke;
                    role1termTextBox.TabStop = false;
                    role2termTextBox.ReadOnly = true;
                    role2termTextBox.BackColor = Color.WhiteSmoke;
                    role2termTextBox.TabStop = false;
                    role3termTextBox.ReadOnly = true;
                    role3termTextBox.BackColor = Color.WhiteSmoke;
                    role3termTextBox.TabStop = false;
                    role4termTextBox.ReadOnly = true;
                    role4termTextBox.BackColor = Color.WhiteSmoke;
                    role4termTextBox.TabStop = false;
                    fullNameTextBox.ReadOnly = true;
                    fullNameTextBox.BackColor = Color.WhiteSmoke;
                    fullNameTextBox.TabStop = false;
                    familyNameTextBox.ReadOnly = true;
                    familyNameTextBox.BackColor = Color.WhiteSmoke;
                    familyNameTextBox.TabStop = false;
                    givenNameTextBox.ReadOnly = true;
                    givenNameTextBox.BackColor = Color.WhiteSmoke;
                    givenNameTextBox.TabStop = false;
                    displayFormTextBox.ReadOnly = true;
                    displayFormTextBox.BackColor = Color.WhiteSmoke;
                    displayFormTextBox.TabStop = false;
                    descriptionTextBox.ReadOnly = true;
                    descriptionTextBox.BackColor = Color.WhiteSmoke;
                    descriptionTextBox.TabStop = false;
                    affiliationTextBox.ReadOnly = true;
                    affiliationTextBox.BackColor = Color.WhiteSmoke;
                    affiliationTextBox.TabStop = false;
                    datesTextBox.ReadOnly = true;
                    datesTextBox.BackColor = Color.WhiteSmoke;
                    datesTextBox.TabStop = false;
                    termsOfAddressTextBox.ReadOnly = true;
                    termsOfAddressTextBox.BackColor = Color.WhiteSmoke;
                    termsOfAddressTextBox.TabStop = false;
                    hierAffiliationTextBox.ReadOnly = true;
                    hierAffiliationTextBox.BackColor = Color.WhiteSmoke;
                    hierAffiliationTextBox.TabStop = false;

                    role1authorityTextBox.Enabled = false;
                    role2authorityTextBox.Enabled = false;
                    role3authorityTextBox.Enabled = false;
                    role4authorityTextBox.Enabled = false;

                    role1typeTextBox.Enabled = false;
                    role2typeTextBox.Enabled = false;
                    role3typeTextBox.Enabled = false;
                    role4typeTextBox.Enabled = false;

                    nameTypeComboBox.Enabled = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        private void roleGroupBox_Paint(object sender, PaintEventArgs e)
        {
            if (!isXP)
            {
                Pen blackPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(blackPen, role1termTextBox.Location.X - 1, role1authorityTextBox.Location.Y - 1, role1termTextBox.Width + role1authorityTextBox.Width + role1typeTextBox.Width - 2, role1authorityTextBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, role2termTextBox.Location.X - 1, role2authorityTextBox.Location.Y - 1, role2termTextBox.Width + role2authorityTextBox.Width + role2typeTextBox.Width - 2, role2authorityTextBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, role3termTextBox.Location.X - 1, role3authorityTextBox.Location.Y - 1, role3termTextBox.Width + role3authorityTextBox.Width + role3typeTextBox.Width - 2, role3authorityTextBox.Height + 1);
                e.Graphics.DrawRectangle(blackPen, role4termTextBox.Location.X - 1, role4authorityTextBox.Location.Y - 1, role4termTextBox.Width + role4authorityTextBox.Width + role4typeTextBox.Width - 2, role4authorityTextBox.Height + 1);
            }
        }

        private void nameInfoGroupBox_Paint(object sender, PaintEventArgs e)
        {
            if ((!isXP) && (!read_only))
            {
                Pen blackPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(blackPen, nameTypeComboBox.Location.X - 1, nameTypeComboBox.Location.Y - 1, nameTypeComboBox.Width + 1, nameTypeComboBox.Height + 1);
            }
        }

        public Affiliation_Info Affiliation
        {
            get { return affiliationInfo; }
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
            string title = "Edit Name Information ";
            if (isDonor)
            {
                title = "Edit Donor Information ";
            }

            if (!showMARC)
            {
                Text = title;           
            }
            else
            {

                switch (nameTypeComboBox.SelectedIndex)
                {
                    case 0:
                        if (isDonor)
                        {
                            Text = title + "[797]";
                        }
                        else
                        {
                            if (mainEntryRadioButton.Checked)
                                Text = title + "[110]";
                            else
                                Text = title + "[710]";
                        }
                        break;

                    case 1:
                        if (isDonor)
                        {
                            Text = title + "[797]";
                        }
                        else
                        {
                            if (mainEntryRadioButton.Checked)
                                Text = title + "[111]";
                            else
                                Text = title + "[711]";
                        }
                        break;

                    case 2:
                        if (isDonor)
                        {
                            Text = title + "[796]";
                        }
                        else
                        {
                            if (mainEntryRadioButton.Checked)
                                Text = title + "[100]";
                            else
                                Text = title + "[700]";
                        }
                        break;
                }
            }

            // If this is not personal, hide some elements
            if (nameTypeComboBox.SelectedIndex != 2)
            {
                familyNameLabel.Hide();
                familyNameTextBox.Hide();
                givenNameLabel.Hide();
                givenNameTextBox.Hide();
                termsOfAddressLabel.Hide();
                termsOfAddressTextBox.Hide();
                displayFormLabel.Hide();
                displayFormTextBox.Hide();
                descriptionLabel.Location = new Point(16, 123);
                descriptionTextBox.Location = new Point(116, 121);
                descriptionTextBox.TabIndex = 7;
            }
            else
            {
                familyNameLabel.Show();
                familyNameTextBox.Show();
                givenNameLabel.Show();
                givenNameTextBox.Show();
                termsOfAddressLabel.Show();
                termsOfAddressTextBox.Show();
                displayFormLabel.Show();
                displayFormTextBox.Show();
                descriptionLabel.Location = new Point(16, 187);
                descriptionTextBox.Location = new Point(116, 185);
                descriptionTextBox.TabIndex = 9;
            }

            if (showMARC)
            {
                datesLabel.Text = "Dates [d]:";
                termsOfAddressLabel.Text = "Terms of Address [c]:";
                affiliationLabel.Text = "Affiliation [u]:";
                displayFormLabel.Text = "Display Form [q]:";
                if ( nameTypeComboBox.SelectedIndex == 2 )
                    descriptionLabel.Text = "Description [g]:";
                else
                    descriptionLabel.Text = "Location [c]:";
                familyNameLabel.Text = "Family Name [a]:";
                fullNameLabel.Text = "Full Name [a]:";
                givenNameLabel.Text = "Given Name [a]:";
                roleGroupBox.Text = "Information about how this named entity relates to this resource [e,4]";
            }
            else
            {
                datesLabel.Text = "Dates:";
                termsOfAddressLabel.Text = "Terms of Address:";
                affiliationLabel.Text = "Affiliation:";
                displayFormLabel.Text = "Display Form:";
                if (nameTypeComboBox.SelectedIndex == 2)
                    descriptionLabel.Text = "Description:";
                else
                    descriptionLabel.Text = "Location:";
                familyNameLabel.Text = "Family Name:";
                fullNameLabel.Text = "Full Name:";
                givenNameLabel.Text = "Given Name:";
                roleGroupBox.Text = "Information about how this named entity relates to this resource";
            }
        }

        public void SetName(Name_Info Name, bool UsedAsSubject, bool IsDonor, Affiliation_Info Affiliation, bool Main_Entity )
        {

            nameObject = Name;
            affiliationInfo = Affiliation;
            usedAsSubject = UsedAsSubject;
            isDonor = IsDonor;
            mainEntry = Main_Entity;

            if ((usedAsSubject) || ( isDonor ))
            {
                addedEntryRadioButton.Hide();
                mainEntryRadioButton.Hide();
                addedEntryRadioButton.Enabled = false;
                mainEntryRadioButton.Enabled = false;
                hierAffiliationTextBox.Hide();
                hierAffiliatonLabel.Hide();
            }
            if (IsDonor)
            {
                roleGroupBox.Hide();
                Text = "Edit Donor Information";
            }

            fullNameTextBox.Text = Name.Full_Name;
            familyNameTextBox.Text = Name.Family_Name;
            givenNameTextBox.Text = Name.Given_Name;
            displayFormTextBox.Text = Name.Display_Form;
            descriptionTextBox.Text = Name.Description;
            affiliationTextBox.Text = Name.Affiliation;
            datesTextBox.Text = Name.Dates;
            termsOfAddressTextBox.Text = Name.Terms_Of_Address;

            switch (Name.Name_Type)
            {
                case Name_Info_Type_Enum.conference:
                    nameTypeComboBox.SelectedIndex = 1;
                    break;

                case Name_Info_Type_Enum.corporate:
                    nameTypeComboBox.SelectedIndex = 0;
                    break;

                default:
                    nameTypeComboBox.SelectedIndex = 2;
                    break;
            }

            if (Name.Roles.Count > 0)
            {
                role1termTextBox.Text = Name.Roles[0].Role;
                switch (Name.Roles[0].Role_Type)
                {
                    case Name_Info_Role_Type_Enum.code:
                        role1typeTextBox.SelectedIndex = 0;
                        break;

                    default:
                        role1typeTextBox.SelectedIndex = 1;
                        break;
                }
                if (Name.Roles[0].Authority == "marcrelator")
                {
                    role1authorityTextBox.SelectedIndex = 1;
                }
                else
                {
                    role1authorityTextBox.SelectedIndex = 0;
                }
            }

            if (Name.Roles.Count > 1)
            {
                role2termTextBox.Text = Name.Roles[1].Role;
                switch (Name.Roles[1].Role_Type)
                {
                    case Name_Info_Role_Type_Enum.code:
                        role2typeTextBox.SelectedIndex = 0;
                        break;

                    default:
                        role2typeTextBox.SelectedIndex = 1;
                        break;
                }
                if (Name.Roles[1].Authority == "marcrelator")
                {
                    role2authorityTextBox.SelectedIndex = 1;
                }
                else
                {
                    role2authorityTextBox.SelectedIndex = 0;
                }
            }

            if (Name.Roles.Count > 2)
            {
                role3termTextBox.Text = Name.Roles[2].Role;
                switch (Name.Roles[2].Role_Type)
                {
                    case Name_Info_Role_Type_Enum.code:
                        role3typeTextBox.SelectedIndex = 0;
                        break;

                    default:
                        role3typeTextBox.SelectedIndex = 1;
                        break;
                }
                if (Name.Roles[2].Authority == "marcrelator")
                {
                    role3authorityTextBox.SelectedIndex = 1;
                }
                else
                {
                    role3authorityTextBox.SelectedIndex = 0;
                }
            }

            if (Name.Roles.Count > 3)
            {
                role4termTextBox.Text = Name.Roles[3].Role;
                switch (Name.Roles[3].Role_Type)
                {
                    case Name_Info_Role_Type_Enum.code:
                        role4typeTextBox.SelectedIndex = 0;
                        break;

                    default:
                        role4typeTextBox.SelectedIndex = 1;
                        break;
                }
                if (Name.Roles[3].Authority == "marcrelator")
                {
                    role4authorityTextBox.SelectedIndex = 1;
                }
                else
                {
                    role4authorityTextBox.SelectedIndex = 0;
                }
            }

            if (mainEntryRadioButton.Enabled)
            {
                if (Main_Entity)
                    mainEntryRadioButton.Checked = true;
                else
                    addedEntryRadioButton.Checked = true;
            }

            if (affiliationInfo != null)
            {
                hierAffiliationTextBox.Text = affiliationInfo.ToString();
            }

            show_values_correctly();

            nameTypeComboBox.TextChanged += textChanged;
            fullNameTextBox.TextChanged += textChanged;
            familyNameTextBox.TextChanged += textChanged;
            givenNameTextBox.TextChanged += textChanged;
            displayFormTextBox.TextChanged += textChanged;
            descriptionTextBox.TextChanged += textChanged;
            affiliationTextBox.TextChanged += textChanged;
            datesTextBox.TextChanged += textChanged;
            termsOfAddressTextBox.TextChanged += textChanged;
            hierAffiliationTextBox.TextChanged += textChanged;
            role1termTextBox.TextChanged += textChanged;
            role2termTextBox.TextChanged += textChanged;
            role3termTextBox.TextChanged += textChanged;
            role4termTextBox.TextChanged += textChanged;
            role1authorityTextBox.TextChanged += textChanged;
            role2authorityTextBox.TextChanged += textChanged;
            role3authorityTextBox.TextChanged += textChanged;
            role4authorityTextBox.TextChanged += textChanged;
            role1typeTextBox.TextChanged += textChanged;
            role2typeTextBox.TextChanged += textChanged;
            role3typeTextBox.TextChanged += textChanged;
            role4typeTextBox.TextChanged += textChanged;

            mainEntryRadioButton.CheckedChanged += checkedChanged;
            addedEntryRadioButton.CheckedChanged += checkedChanged;
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

                nameObject.Full_Name = fullNameTextBox.Text.Trim();

                if ((mainEntryRadioButton.Visible) && (mainEntryRadioButton.Checked))
                {
                    mainEntry = true;
                }
                else
                {
                    mainEntry = false;
                }

                if (familyNameTextBox.Visible)
                    nameObject.Family_Name = familyNameTextBox.Text.Trim();
                else
                    nameObject.Family_Name = String.Empty;

                if (givenNameTextBox.Visible)
                {
                    nameObject.Given_Name = givenNameTextBox.Text.Trim();
                }
                else
                {
                    nameObject.Given_Name = String.Empty;
                }
                if (termsOfAddressTextBox.Visible)
                {
                    nameObject.Terms_Of_Address = termsOfAddressTextBox.Text.Trim();
                }
                else
                {
                    nameObject.Terms_Of_Address = String.Empty;
                }
                if (displayFormTextBox.Visible)
                {
                    nameObject.Display_Form = displayFormTextBox.Text.Trim();
                }
                else
                {
                    nameObject.Display_Form = String.Empty;
                }
                nameObject.Description = descriptionTextBox.Text.Trim();
                nameObject.Affiliation = affiliationTextBox.Text.Trim();
                nameObject.Dates = datesTextBox.Text.Trim();

                switch (nameTypeComboBox.SelectedIndex)
                {
                    case 0:
                        nameObject.Name_Type = Name_Info_Type_Enum.corporate;
                        break;

                    case 1:
                        nameObject.Name_Type = Name_Info_Type_Enum.conference;
                        break;

                    case 2:
                        nameObject.Name_Type = Name_Info_Type_Enum.personal;
                        break;
                }

                nameObject.Roles.Clear();
                if (role1termTextBox.Text.Trim().Length > 0)
                {
                    if (role1typeTextBox.SelectedIndex == 0)
                    {
                        if (role1authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role1termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.code);
                        }
                        else
                        {
                            nameObject.Add_Role(role1termTextBox.Text.Trim(), role1authorityTextBox.Text, Name_Info_Role_Type_Enum.code);
                        }
                    }
                    else
                    {
                        if (role1authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role1termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.text);
                        }
                        else
                        {
                            nameObject.Add_Role(role1termTextBox.Text.Trim(), role1authorityTextBox.Text, Name_Info_Role_Type_Enum.text);
                        }
                    }
                }

                if (role2termTextBox.Text.Trim().Length > 0)
                {
                    if (role2typeTextBox.SelectedIndex == 0)
                    {
                        if (role2authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role2termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.code);
                        }
                        else
                        {
                            nameObject.Add_Role(role2termTextBox.Text.Trim(), role2authorityTextBox.Text, Name_Info_Role_Type_Enum.code);
                        }
                    }
                    else
                    {
                        if (role2authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role2termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.text);
                        }
                        else
                        {
                            nameObject.Add_Role(role2termTextBox.Text.Trim(), role2authorityTextBox.Text, Name_Info_Role_Type_Enum.text);
                        }
                    }
                }

                if (role3termTextBox.Text.Trim().Length > 0)
                {
                    if (role3typeTextBox.SelectedIndex == 0)
                    {
                        if (role3authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role3termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.code);
                        }
                        else
                        {
                            nameObject.Add_Role(role3termTextBox.Text.Trim(), role3authorityTextBox.Text, Name_Info_Role_Type_Enum.code);
                        }
                    }
                    else
                    {
                        if (role3authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role3termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.text);
                        }
                        else
                        {
                            nameObject.Add_Role(role3termTextBox.Text.Trim(), role3authorityTextBox.Text, Name_Info_Role_Type_Enum.text);
                        }
                    }
                }

                if (role4termTextBox.Text.Trim().Length > 0)
                {
                    if (role4typeTextBox.SelectedIndex == 0)
                    {
                        if (role4authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role4termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.code);
                        }
                        else
                        {
                            nameObject.Add_Role(role4termTextBox.Text.Trim(), role4authorityTextBox.Text, Name_Info_Role_Type_Enum.code);
                        }
                    }
                    else
                    {
                        if (role4authorityTextBox.SelectedIndex == 0)
                        {
                            nameObject.Add_Role(role4termTextBox.Text.Trim(), String.Empty, Name_Info_Role_Type_Enum.text);
                        }
                        else
                        {
                            nameObject.Add_Role(role4termTextBox.Text.Trim(), role4authorityTextBox.Text, Name_Info_Role_Type_Enum.text);
                        }
                    }
                }
            }

            Close();
        }

        public bool Main_Entity
        {
            get { return mainEntry; }
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

        private void nameTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_values_correctly();
        }

        private void mainEntryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            show_values_correctly();
        }

        private void addedEntryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            show_values_correctly();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Show_MARC = checkBox1.Checked;

        }

        private void hierAffiliationTextBox_DoubleClick(object sender, EventArgs e)
        {
            Affiliation_Form showAffiliation = new Affiliation_Form();
            if (affiliationInfo == null)
                affiliationInfo = new Affiliation_Info();       
         
            showAffiliation.SetAffiliation(affiliationInfo);
            showAffiliation.Read_Only = read_only;
            showAffiliation.ShowDialog();

            if (showAffiliation.Changed)
                affiliation_changed = true;

            if (!affiliationInfo.hasData)
                hierAffiliationTextBox.Clear();
            else
                hierAffiliationTextBox.Text = affiliationInfo.ToString();
        }

        private void hierAffiliationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Affiliation_Form showAffiliation = new Affiliation_Form();
            if (affiliationInfo == null)
                affiliationInfo = new Affiliation_Info();

            showAffiliation.SetAffiliation(affiliationInfo);
            showAffiliation.Read_Only = read_only;
            showAffiliation.ShowDialog();

            if (showAffiliation.Changed)
                affiliation_changed = true;

            if (!affiliationInfo.hasData)
                hierAffiliationTextBox.Clear();
            else
                hierAffiliationTextBox.Text = affiliationInfo.ToString();
        }

        public bool Changed
        {
            get
            {
                return ((changed) && (saved) && (!read_only)) || ( affiliation_changed );
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
