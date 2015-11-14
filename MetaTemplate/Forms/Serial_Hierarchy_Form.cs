#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Serial_Hierarchy_Form : Form
    {
        private Part_Info partInfo;
        private Serial_Info serialInfo;
        private bool read_only;
        private bool saved;
        private bool changed;

        public Serial_Hierarchy_Form()
        {
            InitializeComponent();

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                dayOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                dayDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                monthOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                monthDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                yearOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                yearDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                partOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                partDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                issueOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                issueDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                volumeDisplayTextBox.BorderStyle = BorderStyle.FixedSingle;
                volumeOrderTextBox.BorderStyle = BorderStyle.FixedSingle;
                enumRadioButton.FlatStyle = FlatStyle.Flat;
                chronRadioButton.FlatStyle = FlatStyle.Flat;
            }
        }

        public bool Read_Only
        {
            set
            {
                read_only = value;

                if (read_only)
                {
                    dayOrderTextBox.ReadOnly = true;
                    dayOrderTextBox.BackColor = Color.WhiteSmoke;
                    dayOrderTextBox.TabStop = false;
                    dayDisplayTextBox.ReadOnly = true;
                    dayDisplayTextBox.BackColor = Color.WhiteSmoke;
                    dayDisplayTextBox.TabStop = false;
                    monthOrderTextBox.ReadOnly = true;
                    monthOrderTextBox.BackColor = Color.WhiteSmoke;
                    monthOrderTextBox.TabStop = false;
                    monthDisplayTextBox.ReadOnly = true;
                    monthDisplayTextBox.BackColor = Color.WhiteSmoke;
                    monthDisplayTextBox.TabStop = false;
                    yearOrderTextBox.ReadOnly = true;
                    yearOrderTextBox.BackColor = Color.WhiteSmoke;
                    yearOrderTextBox.TabStop = false;
                    yearDisplayTextBox.ReadOnly = true;
                    yearDisplayTextBox.BackColor = Color.WhiteSmoke;
                    yearDisplayTextBox.TabStop = false;
                    partOrderTextBox.ReadOnly = true;
                    partOrderTextBox.BackColor = Color.WhiteSmoke;
                    partOrderTextBox.TabStop = false;
                    partDisplayTextBox.ReadOnly = true;
                    partDisplayTextBox.BackColor = Color.WhiteSmoke;
                    partDisplayTextBox.TabStop = false;
                    issueOrderTextBox.ReadOnly = true;
                    issueOrderTextBox.BackColor = Color.WhiteSmoke;
                    issueOrderTextBox.TabStop = false;
                    issueDisplayTextBox.ReadOnly = true;
                    issueDisplayTextBox.BackColor = Color.WhiteSmoke;
                    issueDisplayTextBox.TabStop = false;
                    volumeDisplayTextBox.ReadOnly = true;
                    volumeDisplayTextBox.BackColor = Color.WhiteSmoke;
                    volumeDisplayTextBox.TabStop = false;
                    volumeOrderTextBox.ReadOnly = true;
                    volumeOrderTextBox.BackColor = Color.WhiteSmoke;
                    volumeOrderTextBox.TabStop = false;

                    enumRadioButton.Enabled = false;
                    chronRadioButton.Enabled = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        public void Set_PartInfo(Part_Info PartInfo, Serial_Info SerialInfo, bool isNewspaper )
        {
            partInfo = PartInfo;
            serialInfo = SerialInfo;

            volumeDisplayTextBox.Text = partInfo.Enum1;
            if (partInfo.Enum1_Index >= 0)
            {
                volumeOrderTextBox.Text = partInfo.Enum1_Index.ToString();
            }

            issueDisplayTextBox.Text = partInfo.Enum2;
            if (partInfo.Enum2_Index >= 0)
            {
                issueOrderTextBox.Text = partInfo.Enum2_Index.ToString();
            }

            partDisplayTextBox.Text = partInfo.Enum3;
            if (partInfo.Enum3_Index >= 0)
            {
                partOrderTextBox.Text = partInfo.Enum3_Index.ToString();
            }

            yearDisplayTextBox.Text = partInfo.Year;
            if (partInfo.Year_Index >= 0)
            {
                yearOrderTextBox.Text = partInfo.Year_Index.ToString();
            }

            monthDisplayTextBox.Text = partInfo.Month;
            if (partInfo.Month_Index >= 0)
            {
                monthOrderTextBox.Text = partInfo.Month_Index.ToString();
            }

            dayDisplayTextBox.Text = partInfo.Day;
            if (partInfo.Day_Index >= 0)
            {
                dayOrderTextBox.Text = partInfo.Day_Index.ToString();
            }

            if (serialInfo.Count > 0)
            {
                if (partInfo.Year == serialInfo[0].Display)
                {
                    yearDisplayTextBox.Focus();
                    chronRadioButton.Checked = true;
                }
                else
                {
                    volumeDisplayTextBox.Focus();
                    enumRadioButton.Checked = true;
                }
            }
            else
            {
                // If no default, set it by type
                if ( isNewspaper )
                {
                    yearDisplayTextBox.Focus();
                    chronRadioButton.Checked = true;
                }
                else
                {
                    volumeDisplayTextBox.Focus();
                    enumRadioButton.Checked = true;
                }              
            }


            dayOrderTextBox.TextChanged += textChanged;
            dayDisplayTextBox.TextChanged += textChanged;
            monthOrderTextBox.TextChanged += textChanged;
            monthDisplayTextBox.TextChanged += textChanged;
            yearOrderTextBox.TextChanged += textChanged;
            yearDisplayTextBox.TextChanged += textChanged;
            partOrderTextBox.TextChanged += textChanged;
            partDisplayTextBox.TextChanged += textChanged;
            issueOrderTextBox.TextChanged += textChanged;
            issueDisplayTextBox.TextChanged += textChanged;
            volumeDisplayTextBox.TextChanged += textChanged;
            volumeOrderTextBox.TextChanged += textChanged;

            enumRadioButton.CheckedChanged += checkedChanged;
            chronRadioButton.CheckedChanged += checkedChanged;
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

                int year_order = -1;
                int month_order = -1;
                int day_order = -1;
                int volume_order = -1;
                int issue_order = -1;
                int part_order = -1;
                try
                {
                    if (yearOrderTextBox.Text.Trim().Length > 0)
                        year_order = Convert.ToInt32(yearOrderTextBox.Text.Trim());
                    if (monthOrderTextBox.Text.Trim().Length > 0)
                        month_order = Convert.ToInt32(monthOrderTextBox.Text.Trim());
                    if (dayOrderTextBox.Text.Trim().Length > 0)
                        day_order = Convert.ToInt32(dayOrderTextBox.Text.Trim());
                    if (volumeOrderTextBox.Text.Trim().Length > 0)
                        volume_order = Convert.ToInt32(volumeOrderTextBox.Text.Trim());
                    if (issueOrderTextBox.Text.Trim().Length > 0)
                        issue_order = Convert.ToInt32(issueOrderTextBox.Text.Trim());
                    if (partOrderTextBox.Text.Trim().Length > 0)
                        part_order = Convert.ToInt32(partOrderTextBox.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("All order values must be numeric.     ");
                    return;
                }

                partInfo.Year = yearDisplayTextBox.Text.Trim();
                partInfo.Year_Index = year_order;
                partInfo.Month = monthDisplayTextBox.Text.Trim();
                partInfo.Month_Index = month_order;
                partInfo.Day = dayDisplayTextBox.Text.Trim();
                partInfo.Day_Index = day_order;

                partInfo.Enum1 = volumeDisplayTextBox.Text.Trim();
                partInfo.Enum1_Index = volume_order;
                partInfo.Enum2 = issueDisplayTextBox.Text.Trim();
                partInfo.Enum2_Index = issue_order;
                partInfo.Enum3 = partDisplayTextBox.Text.Trim();
                partInfo.Enum3_Index = part_order;

                if (chronRadioButton.Checked)
                {
                    serialInfo.Clear();
                    serialInfo.Add_Hierarchy(1, partInfo.Year_Index, partInfo.Year);
                    serialInfo.Add_Hierarchy(2, partInfo.Month_Index, partInfo.Month);
                    serialInfo.Add_Hierarchy(3, partInfo.Day_Index, partInfo.Day);
                }

                if (enumRadioButton.Checked)
                {
                    serialInfo.Clear();
                    serialInfo.Add_Hierarchy(1, partInfo.Enum1_Index, partInfo.Enum1);
                    serialInfo.Add_Hierarchy(2, partInfo.Enum2_Index, partInfo.Enum2);
                    serialInfo.Add_Hierarchy(3, partInfo.Enum3_Index, partInfo.Enum3);
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
                ((RadioButton)sender).BackColor = Color.White;
            }
        }

        #endregion

        private void chronRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chronRadioButton.Checked)
            {
                enumRadioButton.Checked = false;
            }
        }

        private void enumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (enumRadioButton.Checked)
            {
                chronRadioButton.Checked = false;
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
