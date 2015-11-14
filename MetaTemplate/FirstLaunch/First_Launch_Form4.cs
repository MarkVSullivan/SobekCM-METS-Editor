#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SobekCM.METS_Editor.AddOns;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form4 : Form
    {
        private List<AddOn_Info> addOns;
        private List<CheckBox> checkBoxes;
        private List<string> enabled;

        public First_Launch_Form4()
        {
            InitializeComponent();

            // Get the list of enabled addons
            enabled = MetaTemplate_UserSettings.AddOns_Enabled;

            // Configure the list to hold add ons and radio buttons
            addOns = new List<AddOn_Info>();
            checkBoxes = new List<CheckBox>();


            // Start with a sorted list though
            SortedList<string, AddOn_Info> sorter = new SortedList<string, AddOn_Info>();

            // Look for possible add on files
            string addOnsDirectory = Application.StartupPath + "\\AddOns";
            string[] possible_add_ons = Directory.GetFiles(addOnsDirectory, "*.xml");
            foreach (string possible_add_on in possible_add_ons)
            {
                try
                {
                    // Read this template
                    Template.Template thisTemplate = Template.Template.Read_XML_Template(possible_add_on);

                    // Get the name of this add-on from the filename
                    string filename = (new FileInfo(possible_add_on)).Name.Replace(".xml", "");

                    // Set the language
                    thisTemplate.Set_Language( MetaTemplate_UserSettings.Last_Language);

                    // Create this add on info object
                    AddOn_Info newAddOn = new AddOn_Info( filename, thisTemplate.Title, thisTemplate.Notes);

                    // Add this to the sorted list of add ons
                    sorter.Add(filename.ToUpper(), newAddOn);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("ERROR READING " + possible_add_on + "\n\n" + ee.Message, "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }

            // Now add them to the list, sorted
            foreach( string thisKey in sorter.Keys )
            {
                addOns.Add(sorter[thisKey]);
            }

            // Add data to the form for each add on
            int addOnCount = 0;
            int height = 15;
            foreach (AddOn_Info thisAddOn in addOns)
            {
                draw_this_add_on(addOnCount, height, thisAddOn);
                addOnCount++;
                height += 60;
            }
        }

        private void draw_this_add_on(int Counter, int Height, AddOn_Info AddOn)
        {
            // Flag indicates if more notes are available
            bool moreAvailable = false;

            // Create and add the checkbox
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Font = new Font( Font, FontStyle.Bold);
            checkBox.Location = new Point(42, Height);
            checkBox.Name = "checkBox" + Counter;
            checkBox.Size = new Size(83, 18);
            checkBox.TabIndex = Counter * 4;
            checkBox.Text = AddOn.FileName;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.Tag = Counter;
            if (enabled.Contains(AddOn.FileName.ToUpper()))
                checkBox.Checked = true;
            checkBoxes.Add(checkBox);
            panel1.Controls.Add(checkBox);            

            // Add the title after this
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point( checkBox.Width + checkBox.Location.X + 10, Height + 1);
            titleLabel.Name = "label" + (Counter * 2).ToString();
            titleLabel.Size = new Size(289, 14);
            titleLabel.TabIndex = ( Counter * 4 ) + 1;
            titleLabel.Text = AddOn.Basic_Description;
            panel1.Controls.Add(titleLabel);

            // Add the longer description next
            Label descLabel = new Label();
            descLabel.AutoSize = true;
            descLabel.Location = new Point(82, Height + 25);
            descLabel.Name = "label" + ((Counter * 2) + 1 ).ToString();
            descLabel.Size = new Size(443, 14);
            descLabel.TabIndex = (Counter * 4) + 2;
            if (AddOn.Notes.Length < 90)
            {
                descLabel.Text = AddOn.Notes;
            }
            else
            {
                descLabel.Text = AddOn.Notes.Substring(0, 85) + "...";
                moreAvailable = true;
            }
            panel1.Controls.Add(descLabel);

            // Add the link label to show more of the description, if there is more.
            if (moreAvailable)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.AutoSize = true;
                linkLabel.Location = new Point(descLabel.Width + descLabel.Location.X + 10, Height + 25);
                linkLabel.Name = "linkLabel" + Counter;
                linkLabel.Size = new Size(53, 14);
                linkLabel.TabIndex = (Counter * 4) + 3;
                linkLabel.TabStop = true;
                linkLabel.Text = "( more )";
                linkLabel.Tag = Counter;
                linkLabel.LinkClicked += linkLabel_LinkClicked;
                panel1.Controls.Add(linkLabel);
            }


        }

        void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Find the notes this link label refers to
            LinkLabel senderLinkLabel = (LinkLabel)sender;
            int counter = Convert.ToInt32(senderLinkLabel.Tag);
            string complete_notes = addOns[counter].Notes;
            string name = addOns[counter].FileName;

            // Show the message box
            MessageBox.Show(complete_notes, name + " Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Save the enabled addons
            List<string> newEnabled = new List<string>();
            foreach (CheckBox thisCheckBox in checkBoxes)
            {
                if (thisCheckBox.Checked)
                {
                    int counter = Convert.ToInt32(thisCheckBox.Tag);
                    newEnabled.Add(addOns[counter].FileName.ToUpper());
                }
            }
            MetaTemplate_UserSettings.AddOns_Enabled = newEnabled;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
