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
    public partial class Affiliation_Form : Form
    {
        private Affiliation_Info thisAffiliation;
        private bool isXP;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Affiliation_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                universityTextBox.BorderStyle = BorderStyle.FixedSingle;
                campusTextBox.BorderStyle = BorderStyle.FixedSingle;
                collegeTextBox.BorderStyle = BorderStyle.FixedSingle;
                unitTextBox.BorderStyle = BorderStyle.FixedSingle;
                departmentTextBox.BorderStyle = BorderStyle.FixedSingle;
                instituteTextBox.BorderStyle = BorderStyle.FixedSingle;
                centerTextBox.BorderStyle = BorderStyle.FixedSingle;
                sectionTextBox.BorderStyle = BorderStyle.FixedSingle;
                subSectionTextBox.BorderStyle = BorderStyle.FixedSingle;
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
                    universityTextBox.ReadOnly = true;
                    universityTextBox.BackColor = Color.WhiteSmoke;
                    universityTextBox.TabStop = false;
                    campusTextBox.ReadOnly = true;
                    campusTextBox.BackColor = Color.WhiteSmoke;
                    campusTextBox.TabStop = false;
                    collegeTextBox.ReadOnly = true;
                    collegeTextBox.BackColor = Color.WhiteSmoke;
                    collegeTextBox.TabStop = false;
                    unitTextBox.ReadOnly = true;
                    unitTextBox.BackColor = Color.WhiteSmoke;
                    unitTextBox.TabStop = false;
                    departmentTextBox.ReadOnly = true;
                    departmentTextBox.BackColor = Color.WhiteSmoke;
                    departmentTextBox.TabStop = false;
                    instituteTextBox.ReadOnly = true;
                    instituteTextBox.BackColor = Color.WhiteSmoke;
                    instituteTextBox.TabStop = false;
                    centerTextBox.ReadOnly = true;
                    centerTextBox.BackColor = Color.WhiteSmoke;
                    centerTextBox.TabStop = false;
                    sectionTextBox.ReadOnly = true;
                    sectionTextBox.BackColor = Color.WhiteSmoke;
                    sectionTextBox.TabStop = false;
                    subSectionTextBox.ReadOnly = true;
                    subSectionTextBox.BackColor = Color.WhiteSmoke;
                    subSectionTextBox.TabStop = false;
                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        public void SetAffiliation(Affiliation_Info Affiliation)
        {
            thisAffiliation = Affiliation;

            universityTextBox.Text = Affiliation.University;
            campusTextBox.Text = Affiliation.Campus;
            collegeTextBox.Text = Affiliation.College;
            unitTextBox.Text = Affiliation.Unit;
            departmentTextBox.Text = Affiliation.Department;
            instituteTextBox.Text = Affiliation.Institute;
            centerTextBox.Text = Affiliation.Center;
            sectionTextBox.Text = Affiliation.Section;
            subSectionTextBox.Text = Affiliation.SubSection;

            if (Affiliation.Term.Length > 0)
                subSectionTextBox.Text = Affiliation.Term;

            universityTextBox.TextChanged += textChanged;
            campusTextBox.TextChanged += textChanged;
            collegeTextBox.TextChanged += textChanged;
            unitTextBox.TextChanged += textChanged;
            departmentTextBox.TextChanged += textChanged;
            instituteTextBox.TextChanged += textChanged;
            centerTextBox.TextChanged += textChanged;
            sectionTextBox.TextChanged += textChanged;
            subSectionTextBox.TextChanged += textChanged;
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

                thisAffiliation.University = universityTextBox.Text.Trim();
                thisAffiliation.Campus = campusTextBox.Text.Trim();
                thisAffiliation.College = collegeTextBox.Text.Trim();
                thisAffiliation.Unit = unitTextBox.Text.Trim();
                thisAffiliation.Department = departmentTextBox.Text.Trim();
                thisAffiliation.Institute = instituteTextBox.Text.Trim();
                thisAffiliation.Center = centerTextBox.Text.Trim();
                thisAffiliation.Section = sectionTextBox.Text.Trim();
                thisAffiliation.SubSection = subSectionTextBox.Text.Trim();
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