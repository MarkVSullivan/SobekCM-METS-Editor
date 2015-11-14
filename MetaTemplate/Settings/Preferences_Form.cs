#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using DLC.Tools.StartUp;
using SobekCM.METS_Editor.AddOns;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class Metadata_Preferences : Form
    {
        private List<AddOn_Info> addOns;
        private List<CheckBox> checkBoxes;
        private List<string> enabled;
        private bool editingItemCurrently;

        public string Project_File_To_Edit { get; private set; }


        public Metadata_Preferences( bool Editing_Item_Currently )
        {
            InitializeComponent();
            editingItemCurrently = Editing_Item_Currently;
            Project_File_To_Edit = String.Empty;

            // Set the primary metadata scheme
            switch (MetaTemplate_UserSettings.Bibliographic_Metadata)
            {
                case Bibliographic_Metadata_Enum.DublinCore:
                    dublinCoreRadioButton.Checked = true;
                    break;

                case Bibliographic_Metadata_Enum.MarcXML:
                    marcXmlRadioButton.Checked = true;
                    break;

                case Bibliographic_Metadata_Enum.MODS:
                    modsRadioButton.Checked = true;
                    break;
            }

            // Populate all other templates
            string directory = Application.StartupPath + "\\Templates";
            string[] templates = Directory.GetFiles(directory, "*.xml");
            string text = String.Empty;
            foreach (string thisTemplate in templates)
            {
                FileInfo fileInfo = new FileInfo(thisTemplate);
                string filename = fileInfo.Name.Replace(fileInfo.Extension, "");
                string filename_upper = filename.ToUpper();
                if ((filename_upper != "DUBLINCORE") && (filename_upper != "STANDARD") && (filename_upper != "COMPLETE"))
                {
                    otherComboBox.Items.Add(filename);

                    if (filename_upper == MetaTemplate_UserSettings.Default_Template.ToUpper())
                        text = filename;
                }
            }
            if (text.Length > 0)
                otherComboBox.Text = text;
            else if (otherComboBox.Items.Count > 0)
                otherComboBox.SelectedIndex = 0;

            // If no others in the template directory, hide those options
            if (otherComboBox.Items.Count == 0)
            {
                otherComboBox.Hide();
                otherRadioButton.Hide();
            }

            switch (MetaTemplate_UserSettings.Default_Template.ToUpper())
            {
                case "DUBLINCORE":
                    dcTemplateRadioButton.Checked = true;
                    break;

                case "STANDARD":
                    standardRadioButton.Checked = true;
                    break;

                case "COMPLETE":
                    completeRadioButton.Checked = true;
                    break;

                default:
                    if (text.Length != 0)
                    {
                        otherRadioButton.Checked = true;
                        otherComboBox.Enabled = true;
                    }
                    else
                    {
                        if (MetaTemplate_UserSettings.Bibliographic_Metadata == Bibliographic_Metadata_Enum.DublinCore)
                            dublinCoreRadioButton.Checked = true;
                        else
                            standardRadioButton.Checked = true;
                    }
                    break;
            }

            // Get the list of PROJECTS
            string[] project_files = Directory.GetFiles(Application.StartupPath + "\\Projects\\", "*.pmets");
            foreach (string thisFile in project_files)
            {
                FileInfo thisFileInfo = new FileInfo(thisFile);
                string name = thisFileInfo.Name.Replace(thisFileInfo.Extension, "");
                projectComboBox.Items.Add(name);
            }
            if ((MetaTemplate_UserSettings.Current_Project.Length > 0) && (projectComboBox.Items.Contains(MetaTemplate_UserSettings.Current_Project)))
                projectComboBox.Text = MetaTemplate_UserSettings.Current_Project;
            else
                projectComboBox.SelectedIndex = 0;

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
                    thisTemplate.Set_Language(MetaTemplate_UserSettings.Last_Language);

                    // Create this add on info object
                    AddOn_Info newAddOn = new AddOn_Info(filename, thisTemplate.Title, thisTemplate.Notes);

                    // Add this to the sorted list of add ons
                    sorter.Add(filename.ToUpper(), newAddOn);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("ERROR READING " + possible_add_on + "\n\n" + ee.Message, "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Now add them to the list, sorted
            foreach (string thisKey in sorter.Keys)
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

            accountTextBox.Text = MetaTemplate_UserSettings.FDA_Account;
            subAccountTextBox.Text = MetaTemplate_UserSettings.FDA_SubAccount;
            projectTextBox.Text = MetaTemplate_UserSettings.FDA_Project;
            fdaCheckBox.Checked = MetaTemplate_UserSettings.FCLA_Flag_FDA;
            palmmCheckBox.Checked = MetaTemplate_UserSettings.FCLA_Flag_PALMM;
            palmmCodeTextBox.Text = MetaTemplate_UserSettings.PALMM_Code;
            sourceCodeTextBox.Text = MetaTemplate_UserSettings.Default_Source_Code;
            sourceStatementTextBox.Text = MetaTemplate_UserSettings.Default_Source_Statement;
            nameTextBox.Text = MetaTemplate_UserSettings.Individual_Creator;
            rightsTextBox.Text = MetaTemplate_UserSettings.Default_Rights_Statement;
            fundingTextBox.Text = MetaTemplate_UserSettings.Default_Funding_Note;
            checksumsCheckBox.Checked = MetaTemplate_UserSettings.Include_Checksums;
            showMetadataCheckBox.Checked = MetaTemplate_UserSettings.Show_Metadata_PostSave;
            alwaysAddPageImagesCheckBox.Checked = MetaTemplate_UserSettings.Always_Add_Page_Images;
            alwaysAddNonPageFilesCheckBox.Checked = MetaTemplate_UserSettings.Always_Add_NonPage_Files;
            alwaysRecurseWhenAddingFilesCheckBox.Checked =MetaTemplate_UserSettings.Always_Recurse_Through_Subfolders_On_New;
            subfoldersPageImagesSepFolderCheckBox.Checked = MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page;


            if (MetaTemplate_UserSettings.METS_File_Extension == ".xml")
            {
                metsExtensionRadioButton.Checked = false;
                xmlExtensionRadioButton.Checked = true;
            }
            else
            {
                metsExtensionRadioButton.Checked = true;
                xmlExtensionRadioButton.Checked = false;
            }

            if (MetaTemplate_UserSettings.Perform_Version_Check_On_StartUp)
            {
                disableVersionCheckBox.Checked = false;
            }
            else
            {
                disableVersionCheckBox.Checked = true;
            }
            versionLabel.Text = "You are currently running version " + VersionConfigSettings.AppVersion + " of this application.";

            // Populate all the sobekcm default aggregations
            List<string> aggregations = MetaTemplate_UserSettings.SobekCM_Aggregations;
            if (aggregations != null)
            {
                if (aggregations.Count > 0) aggregationTextBox1.Text = aggregations[0];
                if (aggregations.Count > 1) aggregationTextBox2.Text = aggregations[1];
                if (aggregations.Count > 2) aggregationTextBox3.Text = aggregations[2];
                if (aggregations.Count > 3) aggregationTextBox4.Text = aggregations[3];
                if (aggregations.Count > 4) aggregationTextBox5.Text = aggregations[4];
            }

            // Populate all the sobekcm default wordmarks
            List<string> wordmars = MetaTemplate_UserSettings.SobekCM_Wordmarks;
            if (wordmars != null)
            {
                if (wordmars.Count > 0) wordmarksTextBox1.Text = wordmars[0];
                if (wordmars.Count > 1) wordmarksTextBox2.Text = wordmars[1];
                if (wordmars.Count > 2) wordmarksTextBox3.Text = wordmars[2];
                if (wordmars.Count > 3) wordmarksTextBox4.Text = wordmars[3];
                if (wordmars.Count > 4) wordmarksTextBox5.Text = wordmars[4];
            }

            // Populate all the sobekcm default web skins
            List<string> webskins = MetaTemplate_UserSettings.SobekCM_Web_Skins;
            if (webskins != null)
            {
                if (webskins.Count > 0) webSkinTextBox1.Text = webskins[0];
                if (webskins.Count > 1) webSkinTextBox2.Text = webskins[1];
                if (webskins.Count > 2) webSkinTextBox3.Text = webskins[2];
                if (webskins.Count > 3) webSkinTextBox4.Text = webskins[3];
                if (webskins.Count > 4) webSkinTextBox5.Text = webskins[4];
            }

            // Populate all the sobekcm default viewers
            List<string> viewers = MetaTemplate_UserSettings.SobekCM_Viewers;
            if (viewers != null)
            {
                if (viewers.Count > 0) viewersComboBox1.Text = viewers[0];
                if (viewers.Count > 1) viewersComboBox2.Text = viewers[1];
                if (viewers.Count > 2) viewersComboBox3.Text = viewers[2];
                if (viewers.Count > 3) viewersComboBox4.Text = viewers[3];
            }

            // Hide the FCLA and SobekCM tabs to start with, if not selected as add-ons
            List<string> addons = MetaTemplate_UserSettings.AddOns_Enabled;
            int removed = 0;
            if (!addons.Contains("FCLA"))
            {
                tabControl1.TabPages.Remove(fclaTabPage);
                removed++;
            }

            if (!addons.Contains("SOBEKCM"))
            {
                tabControl1.TabPages.Remove(sobekcmTabPage);
                removed++;
            }

            if (removed >= 1)
                generalOptionsTabPage.Text = "General Options";
            if (removed == 2)
                schemeTabPage.Text = "Metadata Scheme";

            DialogResult = DialogResult.Cancel;
        }

        private void draw_this_add_on(int Counter, int Height, AddOn_Info AddOn)
        {
            // Flag indicates if more notes are available
            bool moreAvailable = false;

            // Create and add the checkbox
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Font = new Font(Font, FontStyle.Bold);
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

            if (AddOn.FileName == "FCLA")
            {
                checkBox.CheckedChanged += fclaCheckBox_CheckedChanged;
            }
            if (AddOn.FileName.ToUpper() == "SOBEKCM")
            {
                checkBox.CheckedChanged += sobekCheckBox_CheckedChanged;
            }

            // Add the title after this
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(checkBox.Width + checkBox.Location.X + 10, Height + 1);
            titleLabel.Name = "label" + (Counter * 2).ToString();
            titleLabel.Size = new Size(289, 14);
            titleLabel.TabIndex = (Counter * 4) + 1;
            titleLabel.Text = AddOn.Basic_Description;
            panel1.Controls.Add(titleLabel);

            // Add the longer description next
            Label descLabel = new Label();
            descLabel.AutoSize = true;
            descLabel.Location = new Point(82, Height + 25);
            descLabel.Name = "label" + ((Counter * 2) + 1).ToString();
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

        void sobekCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (!tabControl1.TabPages.Contains(sobekcmTabPage))
                {
                    tabControl1.TabPages.Add(sobekcmTabPage);
                    schemeTabPage.Text = "Scheme";
                    if (tabControl1.TabPages.Contains(fclaTabPage))
                        generalOptionsTabPage.Text = "General";
                }
            }
            else
            {
                if (tabControl1.TabPages.Contains(sobekcmTabPage))
                {
                    tabControl1.TabPages.Remove(sobekcmTabPage);
                    generalOptionsTabPage.Text = "General Options";
                    if ( !tabControl1.TabPages.Contains(fclaTabPage))
                        schemeTabPage.Text = "Metadata Scheme";
                }
            }
        }

        void fclaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (!tabControl1.TabPages.Contains(fclaTabPage))
                {
                    tabControl1.TabPages.Add(fclaTabPage);
                    schemeTabPage.Text = "Scheme";
                    if (tabControl1.TabPages.Contains(sobekcmTabPage))
                        generalOptionsTabPage.Text = "General";
                }
            }
            else
            {
                if (tabControl1.TabPages.Contains(fclaTabPage))
                {
                    tabControl1.TabPages.Remove(fclaTabPage);
                    generalOptionsTabPage.Text = "General Options";
                    if (!tabControl1.TabPages.Contains(sobekcmTabPage))
                        schemeTabPage.Text = "Metadata Scheme";
                }
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

        #region Methods to change the background color of each control when focus changes

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }


        #endregion

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            Save_Settings();
        }

        private void Save_Settings()
        {
            // Save the primary metadata schema
            if ((!dublinCoreRadioButton.Checked) && (!marcXmlRadioButton.Checked) && (!modsRadioButton.Checked))
            {
                MessageBox.Show("Please select the bibliograhpic schema to use when creating metadata for your resource.\n\nThis can always be changed later through the preferences menu.", "Select Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dublinCoreRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.DublinCore;

            if (modsRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.MODS;

            if (marcXmlRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.MarcXML;

            // Save the base template
            if ((!dcTemplateRadioButton.Checked) && (!standardRadioButton.Checked) && (!completeRadioButton.Checked) && (!otherRadioButton.Checked))
            {
                MessageBox.Show("Please select the base template you wish to utilize.\n\nThis can always be changed later through the preferences menu.", "Select Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dcTemplateRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "DUBLINCORE";
            if (standardRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "STANDARD";
            if (completeRadioButton.Checked)
                MetaTemplate_UserSettings.Default_Template = "COMPLETE";
            if (otherRadioButton.Checked)
            {
                MetaTemplate_UserSettings.Default_Template = otherComboBox.Text;
            }

            // Save the add-ons
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

            if (xmlExtensionRadioButton.Checked)
                MetaTemplate_UserSettings.METS_File_Extension = ".xml";
            else
                MetaTemplate_UserSettings.METS_File_Extension = ".mets";

            // Populate all the sobekcm default aggregations
            List<string> aggregations = new List<string>();
            if (aggregationTextBox1.Text.Trim().Length > 0) aggregations.Add(aggregationTextBox1.Text.Trim().ToUpper());
            if ((aggregationTextBox2.Text.Trim().Length > 0) && (!aggregations.Contains(aggregationTextBox2.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox2.Text.Trim().ToUpper());
            if ((aggregationTextBox3.Text.Trim().Length > 0) && (!aggregations.Contains(aggregationTextBox3.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox3.Text.Trim().ToUpper());
            if ((aggregationTextBox4.Text.Trim().Length > 0) && (!aggregations.Contains(aggregationTextBox4.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox4.Text.Trim().ToUpper());
            if ((aggregationTextBox5.Text.Trim().Length > 0) && (!aggregations.Contains(aggregationTextBox5.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Aggregations = aggregations;

            // Populate all the sobekcm default wordmarks
            List<string> wordmars = new List<string>();
            if (wordmarksTextBox1.Text.Trim().Length > 0) wordmars.Add(wordmarksTextBox1.Text.Trim().ToUpper());
            if ((wordmarksTextBox2.Text.Trim().Length > 0) && (!wordmars.Contains(wordmarksTextBox2.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox2.Text.Trim().ToUpper());
            if ((wordmarksTextBox3.Text.Trim().Length > 0) && (!wordmars.Contains(wordmarksTextBox3.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox3.Text.Trim().ToUpper());
            if ((wordmarksTextBox4.Text.Trim().Length > 0) && (!wordmars.Contains(wordmarksTextBox4.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox4.Text.Trim().ToUpper());
            if ((wordmarksTextBox5.Text.Trim().Length > 0) && (!wordmars.Contains(wordmarksTextBox5.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Wordmarks = wordmars;

            // Populate all the sobekcm default web skins
            List<string> webskins = new List<string>();
            if (webSkinTextBox1.Text.Trim().Length > 0) webskins.Add(webSkinTextBox1.Text.Trim().ToUpper());
            if ((webSkinTextBox2.Text.Trim().Length > 0) && (!webskins.Contains(webSkinTextBox2.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox2.Text.Trim().ToUpper());
            if ((webSkinTextBox3.Text.Trim().Length > 0) && (!webskins.Contains(webSkinTextBox3.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox3.Text.Trim().ToUpper());
            if ((webSkinTextBox4.Text.Trim().Length > 0) && (!webskins.Contains(webSkinTextBox4.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox4.Text.Trim().ToUpper());
            if ((webSkinTextBox5.Text.Trim().Length > 0) && (!webskins.Contains(webSkinTextBox5.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Web_Skins = webskins;

            // Populate all the sobekcm default viewers
            List<string> viewers = new List<string>();
            if (viewersComboBox1.Text.Trim().Length > 0) viewers.Add(viewersComboBox1.Text.Trim());
            if (viewersComboBox2.Text.Trim().Length > 0) viewers.Add(viewersComboBox2.Text.Trim());
            if (viewersComboBox3.Text.Trim().Length > 0) viewers.Add(viewersComboBox3.Text.Trim());
            if (viewersComboBox4.Text.Trim().Length > 0) viewers.Add(viewersComboBox4.Text.Trim());
            MetaTemplate_UserSettings.SobekCM_Viewers = viewers;

            // Set the default project
            if (projectComboBox.Text != "(none)")
                MetaTemplate_UserSettings.Current_Project = projectComboBox.Text;
            else
                MetaTemplate_UserSettings.Current_Project = String.Empty;

            MetaTemplate_UserSettings.Individual_Creator = nameTextBox.Text;
            MetaTemplate_UserSettings.Perform_Version_Check_On_StartUp = !disableVersionCheckBox.Checked;
            MetaTemplate_UserSettings.Include_SobekCM_File_Section = sobekcmFileCheckBox.Checked;
            MetaTemplate_UserSettings.FDA_Account = accountTextBox.Text.Trim();
            MetaTemplate_UserSettings.FDA_SubAccount = subAccountTextBox.Text.Trim();
            MetaTemplate_UserSettings.FDA_Project = projectTextBox.Text.Trim();
            MetaTemplate_UserSettings.FCLA_Flag_FDA = fdaCheckBox.Checked;
            MetaTemplate_UserSettings.FCLA_Flag_PALMM = palmmCheckBox.Checked;
            MetaTemplate_UserSettings.PALMM_Code = palmmCodeTextBox.Text;
            MetaTemplate_UserSettings.Include_Checksums = checksumsCheckBox.Checked;
            MetaTemplate_UserSettings.Default_Source_Code = sourceCodeTextBox.Text;
            MetaTemplate_UserSettings.Default_Source_Statement = sourceStatementTextBox.Text;
            MetaTemplate_UserSettings.Show_Metadata_PostSave = showMetadataCheckBox.Checked;
            MetaTemplate_UserSettings.Always_Add_Page_Images = alwaysAddPageImagesCheckBox.Checked;
            MetaTemplate_UserSettings.Always_Add_NonPage_Files = alwaysAddNonPageFilesCheckBox.Checked;
            MetaTemplate_UserSettings.Always_Recurse_Through_Subfolders_On_New = alwaysRecurseWhenAddingFilesCheckBox.Checked;
            MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page = subfoldersPageImagesSepFolderCheckBox.Checked;
            MetaTemplate_UserSettings.Default_Rights_Statement = rightsTextBox.Text;
            MetaTemplate_UserSettings.Default_Funding_Note = fundingTextBox.Text;
            MetaTemplate_UserSettings.Save();


            // Configure the metadata
            Metadata_Profile_Configurer.Configure_Metadata_From_UserSettings();


            DialogResult = DialogResult.OK;

            Close();

        }

        private void exportButton_Button_Pressed(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "currentsettings" + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2,'0') + DateTime.Now.Day.ToString().PadLeft(2,'0') + ".config";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MetaTemplate_UserSettings.Export_Settings(saveFileDialog1.FileName);
            }
        }

        private void importButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult firstResult = MessageBox.Show("Would you like to save your current settings before importing new settings?   ", "Save current settings first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (firstResult == DialogResult.Cancel)
                return;
            if (firstResult == DialogResult.Yes)
            {
                saveFileDialog1.FileName = "currentsettings" + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".config";
                DialogResult resultSave = saveFileDialog1.ShowDialog();
                if (resultSave == DialogResult.OK)
                {
                    MetaTemplate_UserSettings.Export_Settings(saveFileDialog1.FileName);
                }
                else
                {
                    return;
                }
            }

            // Now open the settings
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MetaTemplate_UserSettings.Import_Settings(openFileDialog1.FileName);
            }
        }


        private void editProjectButton_Button_Pressed(object sender, EventArgs e)
        {
            if (projectComboBox.Text == "(none)")
                return;

            if (editingItemCurrently)
            {
                MessageBox.Show("You are already editing an item!\n\nClose the current item in the METS Editor and relaunch the metadata preferences to enable project editing.", "Operation Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Project_File_To_Edit = Application.StartupPath + "\\Projects\\" + projectComboBox.Text + ".pmets";
                Save_Settings();
            }
        }

        private void newProjectButton_Button_Pressed(object sender, EventArgs e)
        {
            New_Project_Form projForm = new New_Project_Form();
            this.Hide();
            projForm.ShowDialog();

            if (projForm.Valid_Project_Code.Length > 0)
            {
                try
                {
                    string projCode = projForm.Valid_Project_Code;
                    SobekCM_Item newProj = new SobekCM_Item();
                    newProj.BibID = projCode;
                    newProj.VID = "00001";
                    newProj.Bib_Info.Main_Title.Title = "Project level metadata for '" + projCode + "'";
                    newProj.Bib_Info.SobekCM_Type = TypeOfResource_SobekCM_Enum.Project;
                    newProj.Save_METS(Application.StartupPath + "\\Projects\\" + projCode + ".pmets");

                    MetaTemplate_UserSettings.Current_Project = projCode;
                    MetaTemplate_UserSettings.Save();

                    MessageBox.Show( "New project '" + projCode + "' created and set to be your new default project.\n\nClick EDIT PROJECT to make any changes to the new project.", "New Project Saved", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                catch (Exception ee)
                {
                    MessageBox.Show( "Unable to save new project file.\n\nEnsure you have access to write in the PROJECTS subfolder.\n\n" + Application.StartupPath + "\\Projects\n\n" + ee.Message);
                }
            }

            // Get the list of PROJECTS
            projectComboBox.Items.Clear();
            projectComboBox.Items.Add("(none)");
            string[] project_files = Directory.GetFiles(Application.StartupPath + "\\Projects\\", "*.pmets");
            foreach (string thisFile in project_files)
            {
                FileInfo thisFileInfo = new FileInfo(thisFile);
                string name = thisFileInfo.Name.Replace(thisFileInfo.Extension, "");
                projectComboBox.Items.Add(name);
            }
            if ((MetaTemplate_UserSettings.Current_Project.Length > 0) && ( projectComboBox.Items.Contains(MetaTemplate_UserSettings.Current_Project )))
                projectComboBox.Text = MetaTemplate_UserSettings.Current_Project;
            else
                projectComboBox.SelectedIndex = 0;

            this.Show();
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectComboBox.SelectedIndex == 0)
                editProjectButton.Button_Enabled = false;
            else
                editProjectButton.Button_Enabled = true;
        }

        private void recordStatusButton_Button_Pressed(object sender, EventArgs e)
        {
            RecordStatus_Controlled_List_Form showForm = new RecordStatus_Controlled_List_Form();
            showForm.ShowDialog();
        }

        private void institutionListButton_Button_Pressed(object sender, EventArgs e)
        {
            Institution_Controlled_List_Form showForm = new Institution_Controlled_List_Form();
            showForm.ShowDialog();
        }

        private void typeListButton_Button_Pressed(object sender, EventArgs e)
        {
            Material_Type_Controlled_List_Form showForm = new Material_Type_Controlled_List_Form();
            showForm.ShowDialog();
        }
    }
}
