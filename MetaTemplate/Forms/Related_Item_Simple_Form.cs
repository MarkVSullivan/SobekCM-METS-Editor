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
    public partial class Related_Item_Simple_Form : Form
    {
        private Related_Item_Info relatedItem;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Related_Item_Simple_Form()
        {
            InitializeComponent();

            relatedItem = new Related_Item_Info();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                ufdcIdTextBox.BorderStyle = BorderStyle.FixedSingle;
                titleTextBox.BorderStyle = BorderStyle.FixedSingle;
                lccnTextBox.BorderStyle = BorderStyle.FixedSingle;
                oclcTextBox.BorderStyle = BorderStyle.FixedSingle;
                issnTextBox.BorderStyle = BorderStyle.FixedSingle;
                displayTextBox.BorderStyle = BorderStyle.FixedSingle;
                urlTextBox.BorderStyle = BorderStyle.FixedSingle;
                relationComboBox.FlatStyle = FlatStyle.Flat;
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
                    ufdcIdTextBox.ReadOnly = true;
                    ufdcIdTextBox.BackColor = Color.WhiteSmoke;
                    ufdcIdTextBox.TabStop = false;
                    titleTextBox.ReadOnly = true;
                    titleTextBox.BackColor = Color.WhiteSmoke;
                    titleTextBox.TabStop = false;
                    lccnTextBox.ReadOnly = true;
                    lccnTextBox.BackColor = Color.WhiteSmoke;
                    lccnTextBox.TabStop = false;
                    oclcTextBox.ReadOnly = true;
                    oclcTextBox.BackColor = Color.WhiteSmoke;
                    oclcTextBox.TabStop = false;
                    issnTextBox.ReadOnly = true;
                    issnTextBox.BackColor = Color.WhiteSmoke;
                    issnTextBox.TabStop = false;
                    displayTextBox.ReadOnly = true;
                    displayTextBox.BackColor = Color.WhiteSmoke;
                    displayTextBox.TabStop = false;
                    urlTextBox.ReadOnly = true;
                    urlTextBox.BackColor = Color.WhiteSmoke;
                    urlTextBox.TabStop = false;
                    relationComboBox.Enabled = false;

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

        public void Set_Related_Item(Related_Item_Info Related_Item)
        {
            relatedItem = Related_Item;

            if (relatedItem.SobekCM_ID.Length > 0)
                ufdcIdTextBox.Text = relatedItem.SobekCM_ID;
            if ( relatedItem.URL.Length > 0 )
                urlTextBox.Text = relatedItem.URL;
            if ( relatedItem.URL_Display_Label.Length > 0 )
                displayTextBox.Text = relatedItem.URL_Display_Label;
            if (relatedItem.Main_Title.Title.Length > 0)
                titleTextBox.Text = relatedItem.Main_Title.Title;
            if (relatedItem.Identifiers.Count > 0)
            {
                foreach (Identifier_Info thisIdentifier in relatedItem.Identifiers)
                {
                    switch (thisIdentifier.Type.ToUpper())
                    {
                        case "LCCN":
                            lccnTextBox.Text = thisIdentifier.Identifier;
                            break;

                        case "ISSN":
                            issnTextBox.Text = thisIdentifier.Identifier;
                            break;

                        case "OCLC":
                            oclcTextBox.Text = thisIdentifier.Identifier;
                            break;
                    }
                }
            }
            switch (relatedItem.Relationship)
            {
                case Related_Item_Type_Enum.UNKNOWN:
                    relationComboBox.Text = "(unknown)";
                    break;

                case Related_Item_Type_Enum.host:
                    relationComboBox.Text = "Host";
                    break;

                case Related_Item_Type_Enum.otherFormat:
                    relationComboBox.Text = "Other Format";
                    break;

                case Related_Item_Type_Enum.otherVersion:
                    relationComboBox.Text = "Other Version";
                    break;

                case Related_Item_Type_Enum.preceding:
                    relationComboBox.Text = "Preceding";
                    break;

                case Related_Item_Type_Enum.succeeding:
                    relationComboBox.Text = "Succeeding";
                    break;
            }

            ufdcIdTextBox.TextChanged += textChanged;
            titleTextBox.TextChanged += textChanged;
            lccnTextBox.TextChanged += textChanged;
            oclcTextBox.TextChanged += textChanged;
            issnTextBox.TextChanged += textChanged;
            displayTextBox.TextChanged += textChanged;
            urlTextBox.TextChanged += textChanged;
            relationComboBox.TextChanged += textChanged;
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (relationComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Select the way this item is related to the main item");
                return;
            }

            if (!read_only)
            {
                saved = true;
                relatedItem.SobekCM_ID = ufdcIdTextBox.Text.Trim();
                relatedItem.URL = urlTextBox.Text.Trim().Replace("\\", "/");
                relatedItem.URL_Display_Label = displayTextBox.Text.Trim();
                relatedItem.Main_Title.Title = titleTextBox.Text.Trim();
                switch (relationComboBox.Text)
                {
                    case "Host":
                        relatedItem.Relationship = Related_Item_Type_Enum.host;
                        break;

                    case "Other Format":
                        relatedItem.Relationship = Related_Item_Type_Enum.otherFormat;
                        break;

                    case "Other Version":
                        relatedItem.Relationship = Related_Item_Type_Enum.otherVersion;
                        break;

                    case "Preceding":
                        relatedItem.Relationship = Related_Item_Type_Enum.preceding;
                        break;

                    case "Succeeding":
                        relatedItem.Relationship = Related_Item_Type_Enum.succeeding;
                        break;

                    default:
                        relatedItem.Relationship = Related_Item_Type_Enum.UNKNOWN;
                        break;
                }
                bool lccnSet = false;
                bool issnSet = false;
                bool oclcSet = false;
                if (relatedItem.Identifiers.Count > 0)
                {
                    foreach (Identifier_Info thisIdentifier in relatedItem.Identifiers)
                    {
                        switch (thisIdentifier.Type.ToUpper())
                        {
                            case "LCCN":
                                thisIdentifier.Identifier = lccnTextBox.Text;
                                lccnSet = true;
                                break;

                            case "ISSN":
                                thisIdentifier.Identifier = issnTextBox.Text;
                                issnSet = true;
                                break;

                            case "OCLC":
                                thisIdentifier.Identifier = oclcTextBox.Text;
                                oclcSet = true;
                                break;
                        }
                    }
                }
                if ((lccnTextBox.Text.Trim().Length > 0) && (!lccnSet))
                {
                    relatedItem.Add_Identifier(new Identifier_Info(lccnTextBox.Text.Trim(), "lccn"));
                }
                if ((issnTextBox.Text.Trim().Length > 0) && (!issnSet))
                {
                    relatedItem.Add_Identifier(new Identifier_Info(issnTextBox.Text.Trim(), "issn"));
                }
                if ((oclcTextBox.Text.Trim().Length > 0) && (!oclcSet))
                {
                    relatedItem.Add_Identifier(new Identifier_Info(oclcTextBox.Text.Trim(), "oclc"));
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if ((!isXP) && (!read_only))
            {
                Pen blackPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(blackPen, relationComboBox.Location.X - 1, relationComboBox.Location.Y - 1, relationComboBox.Width + 1, relationComboBox.Height + 1);
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
