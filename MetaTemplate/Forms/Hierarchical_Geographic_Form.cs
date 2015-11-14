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
    public partial class Hierarchical_Geographic_Form : Form
    {
        private Subject_Info_HierarchicalGeographic thisSubject;
        private bool showMARC;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Hierarchical_Geographic_Form()
        {
            InitializeComponent();

            showMARC = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                areaTextBox.BorderStyle = BorderStyle.FixedSingle;
                islandTextBox.BorderStyle = BorderStyle.FixedSingle;
                cityTextBox.BorderStyle = BorderStyle.FixedSingle;
                countyTextBox.BorderStyle = BorderStyle.FixedSingle;
                countryTextBox.BorderStyle = BorderStyle.FixedSingle;
                territoryTextBox.BorderStyle = BorderStyle.FixedSingle;
                stateTextBox.BorderStyle = BorderStyle.FixedSingle;
                regionTextBox.BorderStyle = BorderStyle.FixedSingle;
                provinceTextBox.BorderStyle = BorderStyle.FixedSingle;
                continentTextBox.BorderStyle = BorderStyle.FixedSingle;
                authorityComboBox.FlatStyle = FlatStyle.Flat;
                languageComboBox.FlatStyle = FlatStyle.Flat;
                checkBox1.FlatStyle = FlatStyle.Flat;
                addedEntryRadioButton.FlatStyle = FlatStyle.Flat;
                subjectRadioButton.FlatStyle = FlatStyle.Flat;
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
                    areaTextBox.ReadOnly = true;
                    areaTextBox.BackColor = Color.WhiteSmoke;
                    areaTextBox.TabStop = false;
                    islandTextBox.ReadOnly = true;
                    islandTextBox.BackColor = Color.WhiteSmoke;
                    islandTextBox.TabStop = false;
                    cityTextBox.ReadOnly = true;
                    cityTextBox.BackColor = Color.WhiteSmoke;
                    cityTextBox.TabStop = false;
                    countyTextBox.ReadOnly = true;
                    countyTextBox.BackColor = Color.WhiteSmoke;
                    countyTextBox.TabStop = false;
                    countryTextBox.ReadOnly = true;
                    countryTextBox.BackColor = Color.WhiteSmoke;
                    countryTextBox.TabStop = false;
                    territoryTextBox.ReadOnly = true;
                    territoryTextBox.BackColor = Color.WhiteSmoke;
                    territoryTextBox.TabStop = false;
                    stateTextBox.ReadOnly = true;
                    stateTextBox.BackColor = Color.WhiteSmoke;
                    stateTextBox.TabStop = false;
                    regionTextBox.ReadOnly = true;
                    regionTextBox.BackColor = Color.WhiteSmoke;
                    regionTextBox.TabStop = false;
                    provinceTextBox.ReadOnly = true;
                    provinceTextBox.BackColor = Color.WhiteSmoke;
                    provinceTextBox.TabStop = false;

                    continentTextBox.ReadOnly = true;
                    continentTextBox.BackColor = Color.WhiteSmoke;
                    continentTextBox.TabStop = false;

                    addedEntryRadioButton.Enabled = false;
                    subjectRadioButton.Enabled = false;

                    authorityComboBox.Enabled = false;
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
                if (authorityComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Black), authorityComboBox.Location.X - 1, authorityComboBox.Location.Y - 1, authorityComboBox.Width + 1, authorityComboBox.Height + 1);
                }

                if (languageComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Black), languageComboBox.Location.X - 1, languageComboBox.Location.Y - 1, languageComboBox.Width + 1, languageComboBox.Height + 1);
                }
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


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
            string title = "Edit Hierarchical Geographic Subject ";
            if (addedEntryRadioButton.Checked)
            {
                title = "Edit Added Entry Hierarchical Geographic Place ";
            }

            if (showMARC)
            {
                areaLabel.Text = "Area [g]:";
                islandLabel.Text = "Island [h]:";
                cityLabel.Text = "City [d]:";
                countyLabel.Text = "County [c]:";
                territoryLabel.Text = "Territory [b]:";
                stateLabel.Text = "State [b]:";
                regionLabel.Text = "Region [g]:";
                provinceLabel.Text = "Province [b]:";
                countryLabel.Text = "Country [a]:";
                continentLabel.Text = "Continent [a]:";
                authorityLabel.Text = "Authority [2]:";

                if (addedEntryRadioButton.Checked)
                {
                    Text = title + "[752]";
                }
                else
                {
                    Text = title + "[662]";
                }
            }
            else
            {
                areaLabel.Text = "Area:";
                islandLabel.Text = "Island:";
                cityLabel.Text = "City:";
                countyLabel.Text = "County:";
                territoryLabel.Text = "Territory:";
                stateLabel.Text = "State:";
                regionLabel.Text = "Region:";
                provinceLabel.Text = "Province:";
                countryLabel.Text = "Country:";
                continentLabel.Text = "Continent:";
                authorityLabel.Text = "Authority:";

                Text = title;
            }
        }

        public void SetGeography( Subject_Info_HierarchicalGeographic GeoObject )
        {
            thisSubject = GeoObject;
            areaTextBox.Text = thisSubject.Area;
            islandTextBox.Text = thisSubject.Island;
            cityTextBox.Text = thisSubject.City;
            countyTextBox.Text = thisSubject.County;
            countryTextBox.Text = thisSubject.Country;
            territoryTextBox.Text = thisSubject.Territory;
            stateTextBox.Text = thisSubject.State;
            regionTextBox.Text = thisSubject.Region;
            provinceTextBox.Text = thisSubject.Province;
            continentTextBox.Text = thisSubject.Continent;
            authorityComboBox.Text = thisSubject.Authority;

            if (thisSubject.ID.IndexOf("SUBJ752") >= 0)
                addedEntryRadioButton.Checked = true;
            else
                subjectRadioButton.Checked = true;

            areaTextBox.TextChanged += textChanged;
            islandTextBox.TextChanged += textChanged;
            cityTextBox.TextChanged += textChanged;
            countyTextBox.TextChanged += textChanged;
            countryTextBox.TextChanged += textChanged;
            territoryTextBox.TextChanged += textChanged;
            stateTextBox.TextChanged += textChanged;
            regionTextBox.TextChanged += textChanged;
            provinceTextBox.TextChanged += textChanged;
            continentTextBox.TextChanged += textChanged;
            authorityComboBox.TextChanged += textChanged;
            languageComboBox.TextChanged += textChanged;

            addedEntryRadioButton.CheckedChanged += checkedChanged;
            subjectRadioButton.CheckedChanged += checkedChanged;
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

                thisSubject.Area = areaTextBox.Text.Trim();
                thisSubject.Island = islandTextBox.Text.Trim();
                thisSubject.City = cityTextBox.Text.Trim();
                thisSubject.Country = countryTextBox.Text.Trim();
                thisSubject.County = countyTextBox.Text.Trim();
                thisSubject.Territory = territoryTextBox.Text.Trim();
                thisSubject.State = stateTextBox.Text.Trim();
                thisSubject.Region = regionTextBox.Text.Trim();
                thisSubject.Province = provinceTextBox.Text.Trim();
                thisSubject.Continent = continentTextBox.Text.Trim();
                thisSubject.Authority = authorityComboBox.Text.Trim();

                if (addedEntryRadioButton.Checked)
                    thisSubject.ID = "SUBJ752";
                else
                    thisSubject.ID = "SUBJ662";
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
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void comboBox_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.Khaki;
        }

        private void comboBox_Leave(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.White;
        }

        private void radioButton_Enter(object sender, EventArgs e)
        {
            ((RadioButton)sender).BackColor = Color.Khaki;
        }

        private void radioButton_Leave(object sender, EventArgs e)
        {
            ((RadioButton)sender).BackColor = panel1.BackColor;
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showMARC = checkBox1.Checked;

            show_values_correctly();
        }

        private void subjectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            show_values_correctly();
        }

        private void addedEntryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            show_values_correctly();
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