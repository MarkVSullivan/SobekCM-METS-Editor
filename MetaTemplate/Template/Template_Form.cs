#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using DLC.Tools.Forms;
using DLC.Tools.StartUp;
using SobekCM.METS_Editor.BatchImport;
using SobekCM.METS_Editor.Elements;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Help;
using SobekCM.METS_Editor.ImageDerivative;
using SobekCM.METS_Editor.Messages;
using SobekCM.METS_Editor.OAI;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Bib_Info;
using SobekCM.Resource_Object.Builder;
using SobekCM.Resource_Object.MARC;
using SobekCM.Resource_Object.Metadata_File_ReaderWriters;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.OAI;

#endregion

namespace SobekCM.METS_Editor.Template
{
    /// <summary> Main form which displays all the template options and allows templates to 
    /// be displayed for viewing and editing metadata files </summary>
    public sealed class Template_Form : Form
    {
        private Thread checksumThread;
        private readonly bool excludeDivisions;
        private readonly abstract_HelpProvider helpProvider;
        private string inprocessFile;
        private SobekCM_Item inprocessItem;
        private string metsDirectory;
        private string metsFile;
        private readonly string saveDirectory;
        private readonly Color selectedTabPageColor = SystemColors.ControlLightLight;
        private readonly Color tabPageBorderLineColor = Color.Black;
        private Template thisTemplate;

        #region Form related class members

        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem actionToolStripMenuItem;
        private Label appDescLabel;
        private Round_Button applyButton;
        private ToolStripMenuItem arialToolStripMenuItem;
        private ToolStripMenuItem automaticNumberingToolStripMenuItem;
        private LinkLabel batchImportCancelLink;
        private Label batchImportDirectoryLabel;
        private LinkLabel batchImportDirectoryLink;
        private Label batchImportMainLabel;
        private Label batchImportMarcLabel;
        private LinkLabel batchImportMarcLink;
        private Label batchImportOaiLabel;
        private LinkLabel batchImportOaiLink;
        private Panel batchImportPanel;
        private Label batchImportSpreadsheetLabe;
        private LinkLabel batchImportSpreadsheetLink;
        private LinkLabel batchMetsCreateLinkLabel;
        private ToolStripMenuItem csvOrExcelToolStripMenuItem;
        private IContainer components;
        private LinkLabel derivativesMetsLinkLabel;
        private ToolStripMenuItem dublinCoreFileToolStripMenuItem;
        private ToolStripMenuItem dublinCoreFileToolStripMenuItem1;
        private ToolStripMenuItem dublinCorerecordsToolStripMenuItem;
        private ToolStripMenuItem eadToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem entireDocumentToolStripMenuItem;
        private Round_Button exitButton;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStripMenuItem fontFaceToolStripMenuItem;
        private ToolStripMenuItem fontSizeToolStripMenuItem;
        private ToolStripMenuItem frenchToolStripMenuItem;
        private ToolStripMenuItem garamondToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ImageList imageList1;
        private ImageList imageList2;
        private ToolStripMenuItem importFromMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem largeToolStripMenuItem;
        private ToolStripMenuItem marcRecordToolStripMenuItem;
        private ToolStripMenuItem metsFileToolStripMenuItem1;
        private ToolStripMenuItem metsFileToolStripMenuItem2;
        private ToolStripMenuItem modsFileToolStripMenuItem;
        private ToolStripMenuItem modsFileToolStripMenuItem1;
        private ToolStripMenuItem mxfFileToolStripMenuItem;
        private ToolStripMenuItem marc21DataFileToolStripMenuItem;
        private ToolStripMenuItem marcXMLFileToolStripMenuItem;
        private ToolStripMenuItem marcXMLToolStripMenuItem;
        private ToolStripMenuItem marcXMLToolStripMenuItem1;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem metadataHelpSourceToolStripMenuItem;
        private ToolStripMenuItem metadataPreferencesToolStripMenuItem;
        private LinkLabel newMetsFileLinkLabel;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem noAutomaticNumberingToolStripMenuItem;
        private ToolStripMenuItem noHelpToolStripMenuItem;
        private Panel noMetsPanel;
        private LinkLabel onlineHelpLinkLabel;
        private ToolStripMenuItem onlineHelpToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private LinkLabel openMetsLinkLabel;
        private ToolStripMenuItem openToolStripMenuItem;
        private readonly Color panelColor;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolStripMenuItem projectFilepmetsToolStripMenuItem;
        private ToolStripMenuItem rdfDublinCoreToolStripMenuItem;
        private ToolStripMenuItem recentToolStripMenuItem;
        private ToolStripMenuItem saveAsMetsFileToolStripMenuItem3;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private Round_Button saveButton;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem smallToolStripMenuItem;
        private ToolStripMenuItem sobekHelpPagesToolStripMenuItem;
        private ToolStripMenuItem spanishToolStripMenuItem;
        private TabControl tabControl1;
        private ToolStripMenuItem tahomaToolStripMenuItem;
        private ToolStripMenuItem timesRomanToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem trebuchetToolStripMenuItem;
        private ToolStripMenuItem unanalyzedMetsSectionsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem withingSameDivisionToolStripMenuItem;
        private ToolStripMenuItem z3950EndpointsToolStripMenuItem;
        private ToolStripMenuItem z3950ToolStripMenuItem;
        private ToolStripMenuItem xLargeToolStripMenuItem;

        #endregion

        #region Constructors


        /// <summary> Constructor for a new instance of this form </summary>
        /// <param name="mets_file"></param>
        /// <param name="mets_directory"></param>
        /// <param name="exclude_divisions"></param>
        public Template_Form( string mets_file, string mets_directory, bool exclude_divisions )
        {

            //string aleph = "000097675";
            //SobekCM.Resource_Object.MARC.MARC_Record record = SobekCM.Resource_Object.MARC.MARC_Record_Z3950_Retriever.Get_Record_By_Primary_Identifier(aleph);
            //MessageBox.Show("Tag Count: " + record.Sorted_MARC_Tag_List.Count);

            // Set the language correction
            MessageProvider_Gateway.Set_Language( MetaTemplate_UserSettings.Last_Language );

            // Required for Windows Form Designer support
            InitializeComponent();
            batchImportPanel.Hide();

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += tabControl1_DrawItem;
                panelColor = SystemColors.ControlLightLight;
            }
            else
            {
                panelColor = Color.FromArgb(250, 250, 250);
                panelColor = SystemColors.ControlLightLight;
                selectedTabPageColor = panelColor;
            }

            // Save the information
            saveDirectory = App_Config_Reader.METS_Save_Location;
            metsDirectory = mets_directory;
            metsFile = mets_file;
            excludeDivisions = exclude_divisions;

            // Set the font for this form
            Font = MetaTemplate_UserSettings.Last_Font;

            // Set the size of this form
            //this.Size = new Size(500, 550);
            //			this.WindowState = FormWindowState.Maximized;

            // Open the file, if there was one
            if (mets_file.Length > 0)
            {
                Open_Existing_METS_File(mets_file);
                if (thisTemplate != null)
                {
                    noMetsPanel.Hide();
                    saveButton.Text = "OK";
                }
                else
                {
                    tabControl1.Hide();
                }
            }
            else
            {
                MetaTemplate_UserSettings.Last_Font = Font;
                MetaTemplate_UserSettings.Save();
                metsDirectory = saveDirectory;
                //thisTemplate = load_template(last_template_file, String.Empty, String.Empty );
                //display_template(thisTemplate, true);
                tabControl1.Hide();
            }

            // Set the language checks
            if (MetaTemplate_UserSettings.Last_Language == Template_Language.English)
                englishToolStripMenuItem.Checked = true;
            if (MetaTemplate_UserSettings.Last_Language == Template_Language.French)
                frenchToolStripMenuItem.Checked = true;
            if (MetaTemplate_UserSettings.Last_Language == Template_Language.Spanish)
                spanishToolStripMenuItem.Checked = true;


            // Set the font face checks
            switch (Font.FontFamily.Name)
            {
                case "Trebuchet MS":
                    trebuchetToolStripMenuItem.Checked = true;
                    break;
                case "Arial":
                    arialToolStripMenuItem.Checked = true;
                    break;
                case "Tahoma":
                    tahomaToolStripMenuItem.Checked = true;
                    break;
                case "Garamond":
                    garamondToolStripMenuItem.Checked = true;
                    break;
                case "Times New Roman":
                    timesRomanToolStripMenuItem.Checked = true;
                    break;
            }

            // Set the font size checks
            switch ((int)Font.SizeInPoints)
            {
                case 8:
                    smallToolStripMenuItem.Checked = true;
                    break;
                case 10:
                    largeToolStripMenuItem.Checked = true;
                    break;
                case 12:
                    xLargeToolStripMenuItem.Checked = true;
                    break;
                default:
                    mediumToolStripMenuItem.Checked = true;
                    break;
            }

            if (mets_file.Length == 0)
            {
                saveButton.Text = MessageProvider_Gateway.Exit;
            }

            // Set the metadata source on the form
            string helpProviderString = MetaTemplate_UserSettings.Help_Provider;
            if (helpProviderString == "NONE")
            {
                sobekHelpPagesToolStripMenuItem.Checked = false;
                noHelpToolStripMenuItem.Checked = true;
                abstract_Element.Help_Provider = null;
            }
            else
            {
                sobekHelpPagesToolStripMenuItem.Checked = true;
                noHelpToolStripMenuItem.Checked = false;
                helpProvider = new SobekCM_HelpProvider();
                abstract_Element.Help_Provider = helpProvider;
            }

            // Set the images for the template elements
            abstract_Element.Set_Button_Images(imageList2.Images[0], imageList2.Images[1]);


            // Set the application description
            batchImportSpreadsheetLabe.Text = "This option imports metadata from a spreadsheet or comma-\n" +
                                              "seperated value (CSV) file.  To use this option the first row of\n" +
                                              "your worksheet or file must be a header row with column labels.";

            batchImportMarcLabel.Text =       "This option reads a MARC21 report file and creates METS files\n" +
                                              "with all the bibliographic information from the MARC records.";

            batchImportDirectoryLabel.Text =  "This option recurses through a series of subdirectories attempting\n" +
                                              "to create complete packages, by searching for a metadata file and \n" + 
                                              "adding all files to the package.";

            batchImportOaiLabel.Text = "This option harvests metadata for digital resources from an OAI-PMH\n" +
                                       "data provider/repository and creates METS files for loading.";


            // Set the text from the message provider
            set_text_by_language();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template_Form));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.noMetsPanel = new System.Windows.Forms.Panel();
            this.batchMetsCreateLinkLabel = new System.Windows.Forms.LinkLabel();
            this.newMetsFileLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.onlineHelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.derivativesMetsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.openMetsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.appDescLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metsFileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csvOrExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dublinCoreFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcXMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marc21DataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mxfFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.z3950ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMetsFileToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.dublinCoreFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dublinCorerecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rdfDublinCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.projectFilepmetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metsFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marcRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unanalyzedMetsSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataPreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.z3950EndpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.automaticNumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noAutomaticNumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withingSameDivisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entireDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fontFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.garamondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesRomanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trebuchetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xLargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataHelpSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobekHelpPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.batchImportPanel = new System.Windows.Forms.Panel();
            this.batchImportOaiLabel = new System.Windows.Forms.Label();
            this.batchImportOaiLink = new System.Windows.Forms.LinkLabel();
            this.batchImportCancelLink = new System.Windows.Forms.LinkLabel();
            this.batchImportDirectoryLabel = new System.Windows.Forms.Label();
            this.batchImportMarcLabel = new System.Windows.Forms.Label();
            this.batchImportMainLabel = new System.Windows.Forms.Label();
            this.batchImportSpreadsheetLink = new System.Windows.Forms.LinkLabel();
            this.batchImportDirectoryLink = new System.Windows.Forms.LinkLabel();
            this.batchImportMarcLink = new System.Windows.Forms.LinkLabel();
            this.batchImportSpreadsheetLabe = new System.Windows.Forms.Label();
            this.applyButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.exitButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.noMetsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.batchImportPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(595, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "METS files|*.mets*;*.xml|Project METS files|*.pmets";
            this.openFileDialog1.Title = "Select METS file to edit";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "Blank2.ICO");
            this.imageList1.Images.SetKeyName(6, "Text_Page_Warning.ICO");
            this.imageList1.Images.SetKeyName(7, "Text_Division_Warning.ICO");
            // 
            // noMetsPanel
            // 
            this.noMetsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noMetsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.noMetsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noMetsPanel.Controls.Add(this.batchMetsCreateLinkLabel);
            this.noMetsPanel.Controls.Add(this.newMetsFileLinkLabel);
            this.noMetsPanel.Controls.Add(this.pictureBox1);
            this.noMetsPanel.Controls.Add(this.pictureBox2);
            this.noMetsPanel.Controls.Add(this.onlineHelpLinkLabel);
            this.noMetsPanel.Controls.Add(this.derivativesMetsLinkLabel);
            this.noMetsPanel.Controls.Add(this.openMetsLinkLabel);
            this.noMetsPanel.Controls.Add(this.appDescLabel);
            this.noMetsPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noMetsPanel.Location = new System.Drawing.Point(32, 53);
            this.noMetsPanel.Name = "noMetsPanel";
            this.noMetsPanel.Size = new System.Drawing.Size(550, 461);
            this.noMetsPanel.TabIndex = 6;
            // 
            // batchMetsCreateLinkLabel
            // 
            this.batchMetsCreateLinkLabel.AutoSize = true;
            this.batchMetsCreateLinkLabel.Location = new System.Drawing.Point(119, 253);
            this.batchMetsCreateLinkLabel.Name = "batchMetsCreateLinkLabel";
            this.batchMetsCreateLinkLabel.Size = new System.Drawing.Size(140, 14);
            this.batchMetsCreateLinkLabel.TabIndex = 11;
            this.batchMetsCreateLinkLabel.TabStop = true;
            this.batchMetsCreateLinkLabel.Text = "Batch METS file creation";
            this.batchMetsCreateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchMetsCreateLinkLabel_LinkClicked);
            // 
            // newMetsFileLinkLabel
            // 
            this.newMetsFileLinkLabel.AutoSize = true;
            this.newMetsFileLinkLabel.Location = new System.Drawing.Point(119, 193);
            this.newMetsFileLinkLabel.Name = "newMetsFileLinkLabel";
            this.newMetsFileLinkLabel.Size = new System.Drawing.Size(125, 14);
            this.newMetsFileLinkLabel.TabIndex = 10;
            this.newMetsFileLinkLabel.TabStop = true;
            this.newMetsFileLinkLabel.Text = "Create new METS file";
            this.newMetsFileLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newMetsFileLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(168, 409);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 47);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(280, 71);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // onlineHelpLinkLabel
            // 
            this.onlineHelpLinkLabel.AutoSize = true;
            this.onlineHelpLinkLabel.Location = new System.Drawing.Point(119, 313);
            this.onlineHelpLinkLabel.Name = "onlineHelpLinkLabel";
            this.onlineHelpLinkLabel.Size = new System.Drawing.Size(200, 14);
            this.onlineHelpLinkLabel.TabIndex = 8;
            this.onlineHelpLinkLabel.TabStop = true;
            this.onlineHelpLinkLabel.Text = "View online help for this application";
            this.onlineHelpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onlineHelpLinkLabel_LinkClicked);
            // 
            // derivativesMetsLinkLabel
            // 
            this.derivativesMetsLinkLabel.AutoSize = true;
            this.derivativesMetsLinkLabel.Location = new System.Drawing.Point(119, 283);
            this.derivativesMetsLinkLabel.Name = "derivativesMetsLinkLabel";
            this.derivativesMetsLinkLabel.Size = new System.Drawing.Size(185, 14);
            this.derivativesMetsLinkLabel.TabIndex = 7;
            this.derivativesMetsLinkLabel.TabStop = true;
            this.derivativesMetsLinkLabel.Text = "Create image derivatives for load";
            this.derivativesMetsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.derivativesMetsLinkLabel_LinkClicked);
            // 
            // openMetsLinkLabel
            // 
            this.openMetsLinkLabel.AutoSize = true;
            this.openMetsLinkLabel.Location = new System.Drawing.Point(119, 223);
            this.openMetsLinkLabel.Name = "openMetsLinkLabel";
            this.openMetsLinkLabel.Size = new System.Drawing.Size(136, 14);
            this.openMetsLinkLabel.TabIndex = 6;
            this.openMetsLinkLabel.TabStop = true;
            this.openMetsLinkLabel.Text = "Open existing METS file";
            this.openMetsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openMetsLinkLabel_LinkClicked);
            // 
            // appDescLabel
            // 
            this.appDescLabel.AutoSize = true;
            this.appDescLabel.Location = new System.Drawing.Point(35, 100);
            this.appDescLabel.Name = "appDescLabel";
            this.appDescLabel.Size = new System.Drawing.Size(81, 14);
            this.appDescLabel.TabIndex = 5;
            this.appDescLabel.Text = "appDescLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importFromMenuItem,
            this.recentToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metsFileToolStripMenuItem2});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // metsFileToolStripMenuItem2
            // 
            this.metsFileToolStripMenuItem2.Name = "metsFileToolStripMenuItem2";
            this.metsFileToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.metsFileToolStripMenuItem2.Text = "METS File";
            this.metsFileToolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // importFromMenuItem
            // 
            this.importFromMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csvOrExcelToolStripMenuItem,
            this.dublinCoreFileToolStripMenuItem,
            this.eadToolStripMenuItem,
            this.marcXMLToolStripMenuItem,
            this.modsFileToolStripMenuItem,
            this.mxfFileToolStripMenuItem,
            this.z3950ToolStripMenuItem});
            this.importFromMenuItem.Name = "importFromMenuItem";
            this.importFromMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importFromMenuItem.Text = "Import From...";
            // 
            // csvOrExcelToolStripMenuItem
            // 
            this.csvOrExcelToolStripMenuItem.Enabled = false;
            this.csvOrExcelToolStripMenuItem.Name = "csvOrExcelToolStripMenuItem";
            this.csvOrExcelToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.csvOrExcelToolStripMenuItem.Text = "CSV or Excel File";
            // 
            // dublinCoreFileToolStripMenuItem
            // 
            this.dublinCoreFileToolStripMenuItem.Name = "dublinCoreFileToolStripMenuItem";
            this.dublinCoreFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.dublinCoreFileToolStripMenuItem.Text = "Dublin Core File";
            this.dublinCoreFileToolStripMenuItem.Click += new System.EventHandler(this.dublinCoreFileToolStripMenuItem_Click);
            // 
            // eadToolStripMenuItem
            // 
            this.eadToolStripMenuItem.Name = "eadToolStripMenuItem";
            this.eadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eadToolStripMenuItem.Text = "EAD File";
            this.eadToolStripMenuItem.Click += new System.EventHandler(this.eadStripMenuItem_Click);
            // 
            // marcXMLToolStripMenuItem
            // 
            this.marcXMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcXMLToolStripMenuItem1,
            this.marc21DataFileToolStripMenuItem});
            this.marcXMLToolStripMenuItem.Name = "marcXMLToolStripMenuItem";
            this.marcXMLToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.marcXMLToolStripMenuItem.Text = "MARC Record";
            // 
            // marcXMLToolStripMenuItem1
            // 
            this.marcXMLToolStripMenuItem1.Name = "marcXMLToolStripMenuItem1";
            this.marcXMLToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.marcXMLToolStripMenuItem1.Text = "MarcXML File";
            this.marcXMLToolStripMenuItem1.Click += new System.EventHandler(this.marcXMLToolStripMenuItem_Click);
            // 
            // marc21DataFileToolStripMenuItem
            // 
            this.marc21DataFileToolStripMenuItem.Enabled = false;
            this.marc21DataFileToolStripMenuItem.Name = "marc21DataFileToolStripMenuItem";
            this.marc21DataFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.marc21DataFileToolStripMenuItem.Text = "Marc21 Data File";
            // 
            // modsFileToolStripMenuItem
            // 
            this.modsFileToolStripMenuItem.Name = "modsFileToolStripMenuItem";
            this.modsFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.modsFileToolStripMenuItem.Text = "MODS File";
            this.modsFileToolStripMenuItem.Click += new System.EventHandler(this.mODSFileToolStripMenuItem_Click);
            // 
            // mxfFileToolStripMenuItem
            // 
            this.mxfFileToolStripMenuItem.Name = "mxfFileToolStripMenuItem";
            this.mxfFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.mxfFileToolStripMenuItem.Text = "MXF File";
            this.mxfFileToolStripMenuItem.Click += new System.EventHandler(this.mXFFileToolStripMenuItem_Click);
            // 
            // z3950ToolStripMenuItem
            // 
            this.z3950ToolStripMenuItem.Name = "z3950ToolStripMenuItem";
            this.z3950ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.z3950ToolStripMenuItem.Text = "Z39.50";
            this.z3950ToolStripMenuItem.Click += new System.EventHandler(this.z3950ToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsMetsFileToolStripMenuItem3,
            this.dublinCoreFileToolStripMenuItem1,
            this.marcXMLFileToolStripMenuItem,
            this.modsFileToolStripMenuItem1,
            this.projectFilepmetsToolStripMenuItem});
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // saveAsMetsFileToolStripMenuItem3
            // 
            this.saveAsMetsFileToolStripMenuItem3.Enabled = false;
            this.saveAsMetsFileToolStripMenuItem3.Name = "saveAsMetsFileToolStripMenuItem3";
            this.saveAsMetsFileToolStripMenuItem3.Size = new System.Drawing.Size(158, 22);
            this.saveAsMetsFileToolStripMenuItem3.Text = "METS File";
            this.saveAsMetsFileToolStripMenuItem3.Click += new System.EventHandler(this.saveAsMetsFileToolStripMenuItem3_Click);
            // 
            // dublinCoreFileToolStripMenuItem1
            // 
            this.dublinCoreFileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dublinCorerecordsToolStripMenuItem,
            this.rdfDublinCoreToolStripMenuItem});
            this.dublinCoreFileToolStripMenuItem1.Enabled = false;
            this.dublinCoreFileToolStripMenuItem1.Name = "dublinCoreFileToolStripMenuItem1";
            this.dublinCoreFileToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.dublinCoreFileToolStripMenuItem1.Text = "Dublin Core File";
            // 
            // dublinCorerecordsToolStripMenuItem
            // 
            this.dublinCorerecordsToolStripMenuItem.Enabled = false;
            this.dublinCorerecordsToolStripMenuItem.Name = "dublinCorerecordsToolStripMenuItem";
            this.dublinCorerecordsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dublinCorerecordsToolStripMenuItem.Text = "Dublin Core <records>";
            this.dublinCorerecordsToolStripMenuItem.Click += new System.EventHandler(this.dublinCoreFileToolStripMenuItem1_Click);
            // 
            // rdfDublinCoreToolStripMenuItem
            // 
            this.rdfDublinCoreToolStripMenuItem.Enabled = false;
            this.rdfDublinCoreToolStripMenuItem.Name = "rdfDublinCoreToolStripMenuItem";
            this.rdfDublinCoreToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.rdfDublinCoreToolStripMenuItem.Text = "RDF Dublin Core";
            this.rdfDublinCoreToolStripMenuItem.Click += new System.EventHandler(this.rDFDublinCoreToolStripMenuItem_Click);
            // 
            // marcXMLFileToolStripMenuItem
            // 
            this.marcXMLFileToolStripMenuItem.Enabled = false;
            this.marcXMLFileToolStripMenuItem.Name = "marcXMLFileToolStripMenuItem";
            this.marcXMLFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.marcXMLFileToolStripMenuItem.Text = "MarcXML File";
            this.marcXMLFileToolStripMenuItem.Click += new System.EventHandler(this.marcXMLFileToolStripMenuItem_Click);
            // 
            // modsFileToolStripMenuItem1
            // 
            this.modsFileToolStripMenuItem1.Enabled = false;
            this.modsFileToolStripMenuItem1.Name = "modsFileToolStripMenuItem1";
            this.modsFileToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.modsFileToolStripMenuItem1.Text = "MODS File";
            this.modsFileToolStripMenuItem1.Click += new System.EventHandler(this.mODSFileToolStripMenuItem1_Click);
            // 
            // projectFilepmetsToolStripMenuItem
            // 
            this.projectFilepmetsToolStripMenuItem.Enabled = false;
            this.projectFilepmetsToolStripMenuItem.Name = "projectFilepmetsToolStripMenuItem";
            this.projectFilepmetsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.projectFilepmetsToolStripMenuItem.Text = "New Project";
            this.projectFilepmetsToolStripMenuItem.Click += new System.EventHandler(this.projectFilepmetsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metsFileToolStripMenuItem1,
            this.marcRecordToolStripMenuItem,
            this.unanalyzedMetsSectionsToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // metsFileToolStripMenuItem1
            // 
            this.metsFileToolStripMenuItem1.Name = "metsFileToolStripMenuItem1";
            this.metsFileToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.metsFileToolStripMenuItem1.Text = "METS File";
            this.metsFileToolStripMenuItem1.Click += new System.EventHandler(this.viewMetsToolStripMenuItem_Click);
            // 
            // marcRecordToolStripMenuItem
            // 
            this.marcRecordToolStripMenuItem.Name = "marcRecordToolStripMenuItem";
            this.marcRecordToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.marcRecordToolStripMenuItem.Text = "MARC Record";
            this.marcRecordToolStripMenuItem.Click += new System.EventHandler(this.mARCRecordToolStripMenuItem_Click);
            // 
            // unanalyzedMetsSectionsToolStripMenuItem
            // 
            this.unanalyzedMetsSectionsToolStripMenuItem.Name = "unanalyzedMetsSectionsToolStripMenuItem";
            this.unanalyzedMetsSectionsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.unanalyzedMetsSectionsToolStripMenuItem.Text = "Unanalyzed METS Sections";
            this.unanalyzedMetsSectionsToolStripMenuItem.Click += new System.EventHandler(this.unanalyzedMETSSectionsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metadataPreferencesToolStripMenuItem,
            this.z3950EndpointsToolStripMenuItem,
            this.toolStripSeparator3,
            this.automaticNumberingToolStripMenuItem,
            this.toolStripSeparator6,
            this.languageToolStripMenuItem,
            this.toolStripSeparator4,
            this.fontFaceToolStripMenuItem,
            this.fontSizeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Options";
            // 
            // metadataPreferencesToolStripMenuItem
            // 
            this.metadataPreferencesToolStripMenuItem.Name = "metadataPreferencesToolStripMenuItem";
            this.metadataPreferencesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.metadataPreferencesToolStripMenuItem.Text = "Preferences";
            this.metadataPreferencesToolStripMenuItem.Click += new System.EventHandler(this.metadataPreferencesToolStripMenuItem_Click);
            // 
            // z3950EndpointsToolStripMenuItem
            // 
            this.z3950EndpointsToolStripMenuItem.Name = "z3950EndpointsToolStripMenuItem";
            this.z3950EndpointsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.z3950EndpointsToolStripMenuItem.Text = "Z39.50 Endpoints";
            this.z3950EndpointsToolStripMenuItem.Click += new System.EventHandler(this.z3950EndpointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // automaticNumberingToolStripMenuItem
            // 
            this.automaticNumberingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noAutomaticNumberingToolStripMenuItem,
            this.withingSameDivisionToolStripMenuItem,
            this.entireDocumentToolStripMenuItem});
            this.automaticNumberingToolStripMenuItem.Name = "automaticNumberingToolStripMenuItem";
            this.automaticNumberingToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.automaticNumberingToolStripMenuItem.Text = "Automatic Numbering";
            // 
            // noAutomaticNumberingToolStripMenuItem
            // 
            this.noAutomaticNumberingToolStripMenuItem.Name = "noAutomaticNumberingToolStripMenuItem";
            this.noAutomaticNumberingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.noAutomaticNumberingToolStripMenuItem.Text = "No Automatic Numbering";
            this.noAutomaticNumberingToolStripMenuItem.Click += new System.EventHandler(this.noNumberingMI_Click);
            // 
            // withingSameDivisionToolStripMenuItem
            // 
            this.withingSameDivisionToolStripMenuItem.Name = "withingSameDivisionToolStripMenuItem";
            this.withingSameDivisionToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.withingSameDivisionToolStripMenuItem.Text = "Within Same Division";
            this.withingSameDivisionToolStripMenuItem.Click += new System.EventHandler(this.divisionNumberingMI_Click);
            // 
            // entireDocumentToolStripMenuItem
            // 
            this.entireDocumentToolStripMenuItem.Checked = true;
            this.entireDocumentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entireDocumentToolStripMenuItem.Name = "entireDocumentToolStripMenuItem";
            this.entireDocumentToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.entireDocumentToolStripMenuItem.Text = "Entire Document";
            this.entireDocumentToolStripMenuItem.Click += new System.EventHandler(this.documentNumberingMI_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(191, 6);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.spanishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.frenchToolStripMenuItem.Text = "French";
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(191, 6);
            // 
            // fontFaceToolStripMenuItem
            // 
            this.fontFaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arialToolStripMenuItem,
            this.garamondToolStripMenuItem,
            this.tahomaToolStripMenuItem,
            this.timesRomanToolStripMenuItem,
            this.trebuchetToolStripMenuItem});
            this.fontFaceToolStripMenuItem.Name = "fontFaceToolStripMenuItem";
            this.fontFaceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fontFaceToolStripMenuItem.Text = "Font Face";
            // 
            // arialToolStripMenuItem
            // 
            this.arialToolStripMenuItem.Name = "arialToolStripMenuItem";
            this.arialToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.arialToolStripMenuItem.Text = "Arial";
            this.arialToolStripMenuItem.Click += new System.EventHandler(this.arialToolStripMenuItem_Click);
            // 
            // garamondToolStripMenuItem
            // 
            this.garamondToolStripMenuItem.Name = "garamondToolStripMenuItem";
            this.garamondToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.garamondToolStripMenuItem.Text = "Garamond";
            this.garamondToolStripMenuItem.Click += new System.EventHandler(this.garamondToolStripMenuItem_Click);
            // 
            // tahomaToolStripMenuItem
            // 
            this.tahomaToolStripMenuItem.Name = "tahomaToolStripMenuItem";
            this.tahomaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.tahomaToolStripMenuItem.Text = "Tahoma";
            this.tahomaToolStripMenuItem.Click += new System.EventHandler(this.tahomaToolStripMenuItem_Click);
            // 
            // timesRomanToolStripMenuItem
            // 
            this.timesRomanToolStripMenuItem.Name = "timesRomanToolStripMenuItem";
            this.timesRomanToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.timesRomanToolStripMenuItem.Text = "Times Roman";
            this.timesRomanToolStripMenuItem.Click += new System.EventHandler(this.timesRomanToolStripMenuItem_Click);
            // 
            // trebuchetToolStripMenuItem
            // 
            this.trebuchetToolStripMenuItem.Name = "trebuchetToolStripMenuItem";
            this.trebuchetToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.trebuchetToolStripMenuItem.Text = "Trebuchet";
            this.trebuchetToolStripMenuItem.Click += new System.EventHandler(this.trebuchetToolStripMenuItem_Click);
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.largeToolStripMenuItem,
            this.xLargeToolStripMenuItem});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.largeToolStripMenuItem.Text = "Large";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
            // 
            // xLargeToolStripMenuItem
            // 
            this.xLargeToolStripMenuItem.Name = "xLargeToolStripMenuItem";
            this.xLargeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.xLargeToolStripMenuItem.Text = "X-Large";
            this.xLargeToolStripMenuItem.Click += new System.EventHandler(this.xLargeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.onlineHelpToolStripMenuItem,
            this.metadataHelpSourceToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // onlineHelpToolStripMenuItem
            // 
            this.onlineHelpToolStripMenuItem.Name = "onlineHelpToolStripMenuItem";
            this.onlineHelpToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.onlineHelpToolStripMenuItem.Text = "Online Help";
            this.onlineHelpToolStripMenuItem.Click += new System.EventHandler(this.onlineHelpMI_Click);
            // 
            // metadataHelpSourceToolStripMenuItem
            // 
            this.metadataHelpSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobekHelpPagesToolStripMenuItem,
            this.noHelpToolStripMenuItem});
            this.metadataHelpSourceToolStripMenuItem.Name = "metadataHelpSourceToolStripMenuItem";
            this.metadataHelpSourceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.metadataHelpSourceToolStripMenuItem.Text = "Metadata Help Source";
            // 
            // sobekHelpPagesToolStripMenuItem
            // 
            this.sobekHelpPagesToolStripMenuItem.Checked = true;
            this.sobekHelpPagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sobekHelpPagesToolStripMenuItem.Name = "sobekHelpPagesToolStripMenuItem";
            this.sobekHelpPagesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sobekHelpPagesToolStripMenuItem.Text = "SobekCM Help Pages";
            this.sobekHelpPagesToolStripMenuItem.Click += new System.EventHandler(this.sobekCMHelpPagesToolStripMenuItem_Click);
            // 
            // noHelpToolStripMenuItem
            // 
            this.noHelpToolStripMenuItem.Name = "noHelpToolStripMenuItem";
            this.noHelpToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.noHelpToolStripMenuItem.Text = "No Help";
            this.noHelpToolStripMenuItem.Click += new System.EventHandler(this.noHelpToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "METS files|*.mets|XML files|*.xml";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "Select new METS file location and name";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select a folder that contains your resource files or where you would like to have" +
    " the METS file saved.";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "help_button.jpg");
            this.imageList2.Images.SetKeyName(1, "new_element.jpg");
            // 
            // batchImportPanel
            // 
            this.batchImportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchImportPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.batchImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.batchImportPanel.Controls.Add(this.batchImportOaiLabel);
            this.batchImportPanel.Controls.Add(this.batchImportOaiLink);
            this.batchImportPanel.Controls.Add(this.batchImportCancelLink);
            this.batchImportPanel.Controls.Add(this.batchImportDirectoryLabel);
            this.batchImportPanel.Controls.Add(this.batchImportMarcLabel);
            this.batchImportPanel.Controls.Add(this.batchImportMainLabel);
            this.batchImportPanel.Controls.Add(this.batchImportSpreadsheetLink);
            this.batchImportPanel.Controls.Add(this.batchImportDirectoryLink);
            this.batchImportPanel.Controls.Add(this.batchImportMarcLink);
            this.batchImportPanel.Controls.Add(this.batchImportSpreadsheetLabe);
            this.batchImportPanel.Location = new System.Drawing.Point(32, 45);
            this.batchImportPanel.Name = "batchImportPanel";
            this.batchImportPanel.Size = new System.Drawing.Size(550, 465);
            this.batchImportPanel.TabIndex = 8;
            // 
            // batchImportOaiLabel
            // 
            this.batchImportOaiLabel.AutoSize = true;
            this.batchImportOaiLabel.Location = new System.Drawing.Point(143, 351);
            this.batchImportOaiLabel.Name = "batchImportOaiLabel";
            this.batchImportOaiLabel.Size = new System.Drawing.Size(151, 14);
            this.batchImportOaiLabel.TabIndex = 20;
            this.batchImportOaiLabel.Text = "Directory import text here";
            // 
            // batchImportOaiLink
            // 
            this.batchImportOaiLink.AutoSize = true;
            this.batchImportOaiLink.Location = new System.Drawing.Point(90, 321);
            this.batchImportOaiLink.Name = "batchImportOaiLink";
            this.batchImportOaiLink.Size = new System.Drawing.Size(175, 14);
            this.batchImportOaiLink.TabIndex = 19;
            this.batchImportOaiLink.TabStop = true;
            this.batchImportOaiLink.Text = "Harvest metadata via OAI-PMH";
            this.batchImportOaiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchImportOaiLink_LinkClicked);
            // 
            // batchImportCancelLink
            // 
            this.batchImportCancelLink.AutoSize = true;
            this.batchImportCancelLink.Location = new System.Drawing.Point(90, 400);
            this.batchImportCancelLink.Name = "batchImportCancelLink";
            this.batchImportCancelLink.Size = new System.Drawing.Size(112, 14);
            this.batchImportCancelLink.TabIndex = 18;
            this.batchImportCancelLink.TabStop = true;
            this.batchImportCancelLink.Text = "Back to main menu";
            this.batchImportCancelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchImportCancelLink_LinkClicked);
            // 
            // batchImportDirectoryLabel
            // 
            this.batchImportDirectoryLabel.AutoSize = true;
            this.batchImportDirectoryLabel.Location = new System.Drawing.Point(143, 260);
            this.batchImportDirectoryLabel.Name = "batchImportDirectoryLabel";
            this.batchImportDirectoryLabel.Size = new System.Drawing.Size(151, 14);
            this.batchImportDirectoryLabel.TabIndex = 17;
            this.batchImportDirectoryLabel.Text = "Directory import text here";
            // 
            // batchImportMarcLabel
            // 
            this.batchImportMarcLabel.AutoSize = true;
            this.batchImportMarcLabel.Location = new System.Drawing.Point(143, 184);
            this.batchImportMarcLabel.Name = "batchImportMarcLabel";
            this.batchImportMarcLabel.Size = new System.Drawing.Size(147, 14);
            this.batchImportMarcLabel.TabIndex = 16;
            this.batchImportMarcLabel.Text = "MARC21 import text here";
            // 
            // batchImportMainLabel
            // 
            this.batchImportMainLabel.AutoSize = true;
            this.batchImportMainLabel.Location = new System.Drawing.Point(35, 24);
            this.batchImportMainLabel.Name = "batchImportMainLabel";
            this.batchImportMainLabel.Size = new System.Drawing.Size(325, 14);
            this.batchImportMainLabel.TabIndex = 15;
            this.batchImportMainLabel.Text = "Select the type of batch action you would like to perfom:";
            // 
            // batchImportSpreadsheetLink
            // 
            this.batchImportSpreadsheetLink.AutoSize = true;
            this.batchImportSpreadsheetLink.Location = new System.Drawing.Point(88, 63);
            this.batchImportSpreadsheetLink.Name = "batchImportSpreadsheetLink";
            this.batchImportSpreadsheetLink.Size = new System.Drawing.Size(167, 14);
            this.batchImportSpreadsheetLink.TabIndex = 14;
            this.batchImportSpreadsheetLink.TabStop = true;
            this.batchImportSpreadsheetLink.Text = "Import from Excel or CSV File";
            this.batchImportSpreadsheetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchImportSpreadsheetLink_LinkClicked);
            // 
            // batchImportDirectoryLink
            // 
            this.batchImportDirectoryLink.AutoSize = true;
            this.batchImportDirectoryLink.Location = new System.Drawing.Point(90, 230);
            this.batchImportDirectoryLink.Name = "batchImportDirectoryLink";
            this.batchImportDirectoryLink.Size = new System.Drawing.Size(200, 14);
            this.batchImportDirectoryLink.TabIndex = 13;
            this.batchImportDirectoryLink.TabStop = true;
            this.batchImportDirectoryLink.Text = "Step through a series of directories";
            this.batchImportDirectoryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchImportDirectoryLink_LinkClicked);
            // 
            // batchImportMarcLink
            // 
            this.batchImportMarcLink.AutoSize = true;
            this.batchImportMarcLink.Location = new System.Drawing.Point(88, 156);
            this.batchImportMarcLink.Name = "batchImportMarcLink";
            this.batchImportMarcLink.Size = new System.Drawing.Size(179, 14);
            this.batchImportMarcLink.TabIndex = 12;
            this.batchImportMarcLink.TabStop = true;
            this.batchImportMarcLink.Text = "Convert a MARC21 file to METS";
            this.batchImportMarcLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.batchImportMarcLink_LinkClicked);
            // 
            // batchImportSpreadsheetLabe
            // 
            this.batchImportSpreadsheetLabe.AutoSize = true;
            this.batchImportSpreadsheetLabe.Location = new System.Drawing.Point(143, 88);
            this.batchImportSpreadsheetLabe.Name = "batchImportSpreadsheetLabe";
            this.batchImportSpreadsheetLabe.Size = new System.Drawing.Size(171, 14);
            this.batchImportSpreadsheetLabe.TabIndex = 11;
            this.batchImportSpreadsheetLabe.Text = "Spreadsheet import text here";
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.BackColor = System.Drawing.Color.Transparent;
            this.applyButton.Button_Enabled = false;
            this.applyButton.Button_Text = "APPLY";
            this.applyButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.applyButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(513, 544);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(94, 26);
            this.applyButton.TabIndex = 3;
            this.applyButton.Button_Pressed += new System.EventHandler(this.applyButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Button_Enabled = true;
            this.exitButton.Button_Text = "CANCEL";
            this.exitButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(285, 544);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(94, 26);
            this.exitButton.TabIndex = 1;
            this.exitButton.Button_Pressed += new System.EventHandler(this.exitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "EXIT";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(398, 544);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Click);
            // 
            // Template_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(627, 582);
            this.Controls.Add(this.noMetsPanel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.batchImportPanel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(635, 600);
            this.Name = "Template_Form";
            this.Text = "METS Viewer and Editor";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Template_Form_Closing);
            this.VisibleChanged += new System.EventHandler(this.Template_Form_VisibleChanged);
            this.Resize += new System.EventHandler(this.Template_Form_Resize);
            this.noMetsPanel.ResumeLayout(false);
            this.noMetsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.batchImportPanel.ResumeLayout(false);
            this.batchImportPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Methods for saving a METS file for an open resource

        private SobekCM_Item Save_METS()
        {
            // Check for validity
            if (( metsFile.IndexOf(".pmets") > 0 ) || (thisTemplate.isValid()))
            {
                // Create a bib package to create the METS
                SobekCM_Item newBib = new SobekCM_Item();

                // Was this an existing METS?
                if ((metsFile.Length > 0) && ( File.Exists( metsFile )))
                {
                    newBib = SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);
                }

                
                // Save all the values from the template to this bib
                thisTemplate.Save_To_Bib(newBib);

                // Enusure there is a name here
                if (metsFile.Length == 0)
                {
                    if (newBib.METS_Header.ObjectID.Length > 0)
                    {
                        metsFile = metsDirectory + "\\" + newBib.METS_Header.ObjectID + MetaTemplate_UserSettings.METS_File_Extension; 
                    }
                    else
                    {
                        if (newBib.VID.Length > 0)
                        {
                            metsFile = metsDirectory + "\\" + newBib.BibID + "_" + newBib.VID + MetaTemplate_UserSettings.METS_File_Extension;
                        }
                        else
                        {
                            metsFile = metsDirectory + "\\" + newBib.BibID + MetaTemplate_UserSettings.METS_File_Extension;
                        }
                    }
                }


                // Change the last mofidied date and person
                newBib.METS_Header.Modify_Date = DateTime.Now;
                if (newBib.METS_Header.Creator_Individual.Length == 0)
                {
                    if (MetaTemplate_UserSettings.Individual_Creator.Length > 0)
                    {
                        newBib.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;
                    }
                    else
                    {
                        SecurityInfo getName = new SecurityInfo();
                        newBib.METS_Header.Creator_Individual = getName.UserName;
                    }
                }

                try
                {
                    // If there is no mets location, query for it
                    if (metsDirectory.Length == 0)
                    {
                        saveFileDialog1.InitialDirectory = MetaTemplate_UserSettings.METS_Save_Directory;
                        saveFileDialog1.FileName = newBib.BibID + MetaTemplate_UserSettings.METS_File_Extension;
                        DialogResult saveFileDialogResult = saveFileDialog1.ShowDialog();
                        if (saveFileDialogResult == DialogResult.OK)
                        {
                            metsFile = saveFileDialog1.FileName;
                            var directoryInfo = (new FileInfo(metsFile)).Directory;
                            if (directoryInfo != null)
                                metsDirectory = directoryInfo.ToString();
                            MetaTemplate_UserSettings.METS_Save_Directory = metsDirectory;
                            MetaTemplate_UserSettings.Save();
                        }
                        else
                        {
                            return null;
                        }
                    }

                    newBib.Source_Directory = metsDirectory;
                    if (!Directory.Exists(metsDirectory))
                    {
                        Directory.CreateDirectory(metsDirectory);
                    }

                    // Save the METS file
                    Save_Actual_METS_File(metsFile, newBib);

                    // If this is set to always show the METS do that noe
                    if (MetaTemplate_UserSettings.Show_Metadata_PostSave)
                    {
                        try
                        {
                            Show_XML_Form show = new Show_XML_Form(metsFile, true);
                            show.ShowDialog();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Error while launching XML form.\n\nThis form may require Internet Explorer and full trust.\n\nPlease report this issue to programmer Mark Sullivan ( Mark.V.Sullivan@gmail.com ).           \n\nMessage: " + ee.Message, "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ee)
                {
                    ErrorMessageBox.Show(MessageProvider_Gateway.Error_Saving_METS_File_Message + "\n\n'" + metsDirectory + "\\" + newBib.BibID + "_" + newBib.VID + newBib.VID + MetaTemplate_UserSettings.METS_File_Extension, MessageProvider_Gateway.Error_Saving_METS_File_Title, ee);
                }

                // Return the built object
                return newBib;
            }
            MessageBox.Show(MessageProvider_Gateway.Error_Validating_METS_File_Message + "\n\n" + thisTemplate.Validity_Errors, MessageProvider_Gateway.Error_Validating_METS_File_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void Save_Actual_METS_File(string METS_File, SobekCM_Item newBib)
        {
            // Save these values in the template-wide values
            inprocessItem = newBib;
            inprocessFile = METS_File;

            // If this is a PROJECT file, can skip some of this
            if (METS_File.ToLower().IndexOf(".pmets") < 0)
            {
                // Set some values
                newBib.METS_Header.Creator_Organization = newBib.Bib_Info.Source.Code + "," +
                                                          newBib.Bib_Info.Source.Statement;
                if (MetaTemplate_UserSettings.AddOns_Enabled.Contains("FCLA"))
                {
                    PALMM_Info palmmInfo = newBib.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                    if (palmmInfo == null)
                    {
                        palmmInfo = new PALMM_Info();
                        newBib.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
                    }
                    if ((palmmInfo.toPALMM) && (palmmInfo.PALMM_Project.Length > 0))
                    {
                        string creator_org_to_remove = String.Empty;
                        foreach (string thisString in newBib.METS_Header.Creator_Org_Notes)
                        {
                            if (thisString.IndexOf("projects=") >= 0)
                            {
                                creator_org_to_remove = thisString;
                                break;
                            }
                        }
                        if (creator_org_to_remove.Length > 0)
                            newBib.METS_Header.Replace_Creator_Org_Notes(creator_org_to_remove,
                                                                         "projects=" + palmmInfo.PALMM_Project);
                        else
                            newBib.METS_Header.Add_Creator_Org_Notes("projects=" + palmmInfo.PALMM_Project);
                    }
                }
                newBib.METS_Header.Creator_Software = "SobekCM Metadata Template";
                ////newBib.METS.Creator_Software = "dLOC Toolkit";
                ////newBib.DAITTS.toArchive = false;

                newBib.Divisions.Suppress_Checksum = !MetaTemplate_UserSettings.Include_Checksums;
            }
            else
            {
                newBib.Divisions.Suppress_Checksum = true;
            }

            // Calculate any needed checksums
            if ((!newBib.Divisions.Suppress_Checksum) && (newBib.Divisions.Needs_Checksums))
            {
                Checksum_Calculator calculator = new Checksum_Calculator(newBib.Divisions, false);
                calculator.Complete += calculator_Complete;

                checksumThread = new Thread(calculator.Process);
                checksumThread.Start();
            }
            else
            {
                calculator_Complete(String.Empty, 0, 0);
            }
        }

        void calculator_Complete(string task, int current_value, int maximum_value)
        {
            // Save the actual file
            METS_File_ReaderWriter metsWriter = new METS_File_ReaderWriter();
            string writing_error = String.Empty;
            metsWriter.Write_Metadata(inprocessFile, inprocessItem, null, out writing_error);
        }

        #endregion

        #region Methods for opening an existing METS file, or creating and display a new METS file

        private void Open_Existing_METS_File(string source)
        {
            // If no length, just return
            if (source.Length == 0)
                return;

            // Set the current template to null
            thisTemplate = null;


            if (File.Exists(source))
            {
                // Just a file, so open regularly
                noMetsPanel.Hide();
                tabControl1.Show();
                MetaTemplate_UserSettings.Add_Recent(source);
                update_recents();
                var directoryInfo = (new FileInfo(source)).Directory;
                if (directoryInfo != null) metsDirectory = directoryInfo.FullName;
                metsFile = source;

                SobekCM_Item newItem = SobekCM_Item.Read_METS(source);

                // Build the template object, assign the item, and then display within this form
                Load_And_Display_Template(newItem, true);


                // TEMPREMOVED this.Size = new Size(this.Width - 1, this.Height - 1);
            }
            else
            {
                MessageBox.Show("The indicated file does not exist!     ", "Missing METS File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noMetsPanel.Show();
                tabControl1.Hide();
            }
        }

        private bool New_Project()
        {
            // Determine the directory here
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result != DialogResult.OK)
            {
                return false;
            }

            // Get the directory
            string directory = folderBrowserDialog1.SelectedPath;

            // If this directory does not exist (rarely occurs when adding and then renaming a new folder )
            // try again
            while (!Directory.Exists(directory))
            {
                result = folderBrowserDialog1.ShowDialog();
                if (result != DialogResult.OK)
                    return false;
                directory = folderBrowserDialog1.SelectedPath;
            }

            // Look for an existing METS
            DirectoryInfo thisDirInfo = new DirectoryInfo(directory);
            string directoryName = thisDirInfo.Name;
            string mets_file_check = directory + "\\" + directoryName +
                                     MetaTemplate_UserSettings.METS_File_Extension;
            if (File.Exists(mets_file_check))
            {
                DialogResult dialogResult =
                    MessageBox.Show(
                        "An existing METS file of the same name already exists in this directory.     \nAre you sure you wish to continue and potentially overwrite that file with a new blank file?   ",
                        "Existing METS File Detected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes)
                    return false;
            }

            // Create a new item and add any files as required
            SobekCM_Item newItem = Create_New_METS_File(directory);

            // Set the current template to null
            thisTemplate = null;

            // Just a file, so open regularly
            noMetsPanel.Hide();
            tabControl1.Show();
            applyButton.Button_Enabled = true;

            metsDirectory = folderBrowserDialog1.SelectedPath;
            metsFile = String.Empty;

            // Build the template object, assign the item, and then display within this form
            Load_And_Display_Template(newItem, true);

            return true;
        }

        private bool New_File( )
        {
            // Determine the directory here
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result != DialogResult.OK)
            {
                return false;
            }

            // Get the directory
            string directory = folderBrowserDialog1.SelectedPath;

            // If this directory does not exist (rarely occurs when adding and then renaming a new folder )
            // try again
            while (!Directory.Exists(directory))
            {
                result = folderBrowserDialog1.ShowDialog();
                if (result != DialogResult.OK)
                    return false;
                directory = folderBrowserDialog1.SelectedPath;
            }

            // Look for an existing METS
            DirectoryInfo thisDirInfo = new DirectoryInfo(directory);
            string directoryName = thisDirInfo.Name;
            string mets_file_check = directory + "\\" + directoryName +
                                     MetaTemplate_UserSettings.METS_File_Extension;
            if (File.Exists(mets_file_check))
            {
                DialogResult dialogResult =
                    MessageBox.Show(
                        "An existing METS file of the same name already exists in this directory.     \nAre you sure you wish to continue and potentially overwrite that file with a new blank file?   ",
                        "Existing METS File Detected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes)
                    return false;
            }

            // Create a new item and add any files as required
            SobekCM_Item newItem = Create_New_METS_File(directory);

            // Set the current template to null
            thisTemplate = null;

            // Just a file, so open regularly
            noMetsPanel.Hide();
            tabControl1.Show();
            applyButton.Button_Enabled = true;

            metsDirectory = folderBrowserDialog1.SelectedPath;
            metsFile = String.Empty;

            // Build the template object, assign the item, and then display within this form
            Load_And_Display_Template(newItem, true);

            return true;
        }

        private SobekCM_Item Create_New_METS_File(string New_Directory)
        {
            // Check for files in the main new directory
            string[] existing_files = Directory.GetFiles(New_Directory);
            bool image_files_found = false;
            List<string> otherFiles = new List<string>();
            foreach (string thisFile in existing_files)
            {
                string upper_case = new FileInfo(thisFile).Name.ToUpper();
                if ((upper_case.IndexOf(".TIF") > 0) || (upper_case.IndexOf(".JPG") > 0) || (upper_case.IndexOf(".JP2") > 0) || (upper_case.IndexOf(".PNG") > 0) || (upper_case.IndexOf(".GIF") > 0))
                {
                    image_files_found = true;
                }
                else if ((upper_case.IndexOf(".METS") < 0) && (upper_case.IndexOf(".TXT") < 0) && (upper_case.IndexOf(".PRO") < 0) && (upper_case.IndexOf(".XML") < 0))
                {
                    otherFiles.Add((new FileInfo(thisFile)).Name);
                }
            }

            // Were there subfolders?
            bool include_subdir_files = false;
            if (Directory.GetDirectories(New_Directory).Length > 0)
            {
                // Should these be included?
                include_subdir_files = MetaTemplate_UserSettings.Always_Recurse_Through_Subfolders_On_New;
                if (!include_subdir_files)
                {
                    Existing_Subdirectories_Found_Dialog subDirsDialogForm = new Existing_Subdirectories_Found_Dialog();
                    if (subDirsDialogForm.ShowDialog() == DialogResult.Yes)
                        include_subdir_files = true;
                }

                // Step through all files and add them to the otherFiles
                if (include_subdir_files)
                {
                    foreach (string thisSubDir in Directory.GetDirectories(New_Directory))
                    {
                        recursively_add_files(thisSubDir, (new DirectoryInfo(thisSubDir)).Name, otherFiles, ref image_files_found);
                    }
                }
            }

            // If there was a project, load that
            SobekCM_Item newItem;
            if ((MetaTemplate_UserSettings.Current_Project.Length > 0) && (File.Exists(Application.StartupPath + "\\Projects\\" + MetaTemplate_UserSettings.Current_Project + ".pmets")))
            {
                newItem = SobekCM_Item.Read_METS(Application.StartupPath + "\\Projects\\" + MetaTemplate_UserSettings.Current_Project + ".pmets");

                if (newItem != null)
                {
                    // Now, change the material type stuff
                    Note_Info defaultTypeNote = null;
                    foreach (Note_Info thisNote in newItem.Bib_Info.Notes)
                    {
                        if (thisNote.Note_Type == Note_Type_Enum.default_type)
                        {
                            defaultTypeNote = thisNote;
                            break;
                        }
                    }
                    if (defaultTypeNote != null)
                    {
                        newItem.Bib_Info.Remove_Note(defaultTypeNote);
                        newItem.Bib_Info.SobekCM_Type_String = defaultTypeNote.Note;
                    }
                    else
                    {
                        newItem.Bib_Info.SobekCM_Type = TypeOfResource_SobekCM_Enum.UNKNOWN;
                    }

                    newItem.BibID = String.Empty;
                }
            }
            else
            {
                newItem = new SobekCM_Item();
                List<string> addOns = MetaTemplate_UserSettings.AddOns_Enabled;

                // Set the initial agents
                if ( MetaTemplate_UserSettings.Individual_Creator.Length > 0 )
                    newItem.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;

                // Add FCLA add-on defaults
                if (addOns.Contains("FCLA"))
                {
                    PALMM_Info palmmInfo = newItem.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                    if (palmmInfo == null)
                    {
                        palmmInfo = new PALMM_Info();
                        newItem.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
                    }
                    palmmInfo.PALMM_Project = MetaTemplate_UserSettings.PALMM_Code;
                    palmmInfo.toPALMM = MetaTemplate_UserSettings.FCLA_Flag_PALMM;


                    DAITSS_Info daitssInfo = newItem.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                    if (daitssInfo == null)
                    {
                        daitssInfo = new DAITSS_Info();
                        newItem.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
                    }
                    daitssInfo.toArchive = MetaTemplate_UserSettings.FCLA_Flag_FDA;
                    daitssInfo.Account = MetaTemplate_UserSettings.FDA_Account;
                    daitssInfo.SubAccount = MetaTemplate_UserSettings.FDA_SubAccount;
                    daitssInfo.Project = MetaTemplate_UserSettings.FDA_Project;
                }

                // Add SobekCM add-on defaults
                if (addOns.Contains("SOBEKCM"))
                {
                    // Add any wordmarks
                    List<string> wordmarks = MetaTemplate_UserSettings.SobekCM_Wordmarks;
                    foreach (string thisWordmark in wordmarks)
                        newItem.Behaviors.Add_Wordmark(thisWordmark);

                    // Add any aggregations
                    List<string> aggregations = MetaTemplate_UserSettings.SobekCM_Aggregations;
                    foreach (string thisAggregation in aggregations)
                        newItem.Behaviors.Add_Aggregation(thisAggregation);

                    // Add any web skins
                    List<string> webskins = MetaTemplate_UserSettings.SobekCM_Web_Skins;
                    foreach (string thisWebSkin in webskins)
                        newItem.Behaviors.Add_Web_Skin(thisWebSkin);

                    // Add any viewers
                    List<string> viewers = MetaTemplate_UserSettings.SobekCM_Viewers;
                    foreach (string thisViewer in viewers)
                    {
                        if ( String.CompareOrdinal(thisViewer, "Page Image (JPEG)") == 0 )
                            newItem.Behaviors.Add_View( View_Enum.JPEG );
                        if (String.CompareOrdinal(thisViewer, "Zoomable (JPEG2000)") == 0)
                            newItem.Behaviors.Add_View( View_Enum.JPEG2000 );
                        if (String.CompareOrdinal(thisViewer, "Page Turner") == 0)
                            newItem.Behaviors.Add_View( View_Enum.PAGE_TURNER );
                        if (String.CompareOrdinal(thisViewer, "Text") == 0)
                            newItem.Behaviors.Add_View( View_Enum.TEXT );
                        if (String.CompareOrdinal(thisViewer, "Thumbnails") == 0)
                            newItem.Behaviors.Add_View(View_Enum.RELATED_IMAGES);
                    }
                }

                // Add all other defaults
                newItem.Bib_Info.Source.Code = MetaTemplate_UserSettings.Default_Source_Code;
                newItem.Bib_Info.Source.Statement = MetaTemplate_UserSettings.Default_Source_Statement;
                if (MetaTemplate_UserSettings.Default_Funding_Note.Length > 0)
                    newItem.Bib_Info.Add_Note(MetaTemplate_UserSettings.Default_Funding_Note, Note_Type_Enum.funding);
                if (MetaTemplate_UserSettings.Default_Rights_Statement.Length > 0)
                    newItem.Bib_Info.Access_Condition.Text = MetaTemplate_UserSettings.Default_Rights_Statement;
               
            }

            newItem.Bib_Info.Type.MODS_Type = TypeOfResource_MODS_Enum.Text;
            newItem.Bib_Info.Main_Title.Title = "New Item";
            newItem.METS_Header.ObjectID = (new DirectoryInfo(folderBrowserDialog1.SelectedPath)).Name;
            if ((newItem.METS_Header.ObjectID.Length == 16) && (newItem.METS_Header.ObjectID[10] == '_'))
            {
                string objectid = newItem.METS_Header.ObjectID;
                newItem.VID = objectid.Substring(11);
                newItem.BibID = objectid.Substring(0, 10);
            }

            newItem.Source_Directory = folderBrowserDialog1.SelectedPath;

            // Add image files if they exist
            if (image_files_found)
            {
                if (MetaTemplate_UserSettings.Always_Add_Page_Images)
                {
                    Bib_Package_Builder.Add_All_Files(newItem, "*.tif|*.jpg|*.jp2|*.txt|*.pro|*.gif|*.png", include_subdir_files, MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page);
                }
                else
                {
                    Existing_Page_Images_Found_Dialog secondresultForm = new Existing_Page_Images_Found_Dialog();
                    DialogResult secondresult = secondresultForm.ShowDialog();
                    if (secondresult == DialogResult.Yes)
                    {
                        Bib_Package_Builder.Add_All_Files(newItem, "*.tif|*.jpg|*.jp2|*.txt|*.pro|*.gif|*.png", include_subdir_files, MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page);
                    }
                }
            }

            // Add any other files as well
            if (otherFiles.Count > 0)
            {
                if (MetaTemplate_UserSettings.Always_Add_NonPage_Files)
                {
                    foreach (string thisFile in otherFiles)
                    {
                        newItem.Divisions.Download_Tree.Add_File(thisFile);
                    }
                }
                else
                {
                    Other_Files_Detected_Form addOtherFiles = new Other_Files_Detected_Form(otherFiles);
                    addOtherFiles.ShowDialog();
                    ReadOnlyCollection<string> files_selected = addOtherFiles.Selected_Files;
                    foreach (string thisFile in files_selected)
                    {
                        newItem.Divisions.Download_Tree.Add_File(thisFile);
                    }
                }

            }

            return newItem;
        }

        private static void recursively_add_files( string Subdirectory, string directory_builder, List<string> otherFiles, ref bool image_files_found)
        {
            // Check for files in the main new directory
            string[] existing_files = Directory.GetFiles(Subdirectory);
            foreach (string thisFile in existing_files)
            {
                string upper_case = new FileInfo(thisFile).Name.ToUpper();
                if ((upper_case.IndexOf(".TIF") > 0) || (upper_case.IndexOf(".JPG") > 0) || (upper_case.IndexOf(".JP2") > 0) || (upper_case.IndexOf(".PNG") > 0) || (upper_case.IndexOf(".GIF") > 0))
                {
                    image_files_found = true;
                }
                else if ((upper_case.IndexOf(".METS") < 0) && (upper_case.IndexOf(".TXT") < 0) && (upper_case.IndexOf(".PRO") < 0) && (upper_case.IndexOf(".XML") < 0))
                {
                    otherFiles.Add( directory_builder + "\\" + (new FileInfo(thisFile)).Name);
                }
            }

            // Check subfolders
            foreach (string thisSubDir in Directory.GetDirectories(Subdirectory))
            {
                recursively_add_files( thisSubDir, directory_builder + "\\" + (new DirectoryInfo(thisSubDir)).Name, otherFiles, ref image_files_found );
            }
        }

        #endregion

        #region Methods to load and display the template

        private void Load_And_Display_Template(SobekCM_Item Current_Item, bool Load_New_Template)
        {
            // Should the template be loaded new?
            if (Load_New_Template)
            {
                // Load the template and addons, and pass in the item for any special configuration
                // needed (such as if it is a PROJECT item being edited)
                thisTemplate = Load_Template_And_AddOns(Current_Item);

                inprocessItem = Current_Item;
                string actual_source = Current_Item.Source_Directory;
                thisTemplate.Populate_From_Bib(Current_Item);
                Current_Item.Source_Directory = actual_source;

                // Configure the form for this new template
                saveToolStripMenuItem.Enabled = true;
                metsFileToolStripMenuItem1.Enabled = true;
                tabControl1.Show();
                noMetsPanel.Hide();
            }

            if (thisTemplate == null)
                return;

            SuspendLayout();


            saveButton.Text = "FINISH";

            // Set the form title
            if (thisTemplate.isProject)
            {
                Text = thisTemplate.Title + " - " + thisTemplate.BibID + " Project Template";
            }
            else
            {
                if (thisTemplate.BibID.Length == 0)
                {
                    Text = thisTemplate.Title;
                }
                else
                {
                    if (thisTemplate.VID.Length == 0)
                    {
                        Text = thisTemplate.Title + " - " + thisTemplate.BibID;
                    }
                    else
                    {
                        Text = thisTemplate.Title + " - " + thisTemplate.BibID + " : " + thisTemplate.VID;
                    }
                }
            }

            // Set the font
            thisTemplate.Current_Font = Font;

            // Add a tab control for each page
            tabControl1.TabPages.Clear();
            tabControl1.TabIndex = 1;
            int tabIndex = 2;
            foreach (Template_Page thisPage in thisTemplate.InputPages)
            {
                // Add this page to the tab control
                TabPage thisTabPage = new TabPage(thisPage.Title + "  ")
                                          {AutoScroll = true, Tag = thisPage, BackColor = panelColor};
                tabControl1.TabPages.Add(thisTabPage);

                // Add a panel to the tab control
                Panel tabPagePanel = new Panel
                                         {
                                             Location = new Point(0, 0),
                                             Width = thisTabPage.Width,
                                             Height = thisPage.Height,
                                             Anchor = ((((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)))
                                         };
                tabPagePanel.Paint += tabPagePanel_Paint;
                tabPagePanel.Tag = thisPage;
                thisTabPage.Controls.Add(tabPagePanel);

                // Add each element to the tab panel as well
                foreach (Template_Panel thisPanel in thisPage.Panels)
                {
                    foreach (abstract_Element thisElement in thisPanel.Elements)
                    {
                        // Add this element to this form
                        tabPagePanel.Controls.Add(thisElement);

                        // Add event handlers to this element
                        if (Load_New_Template)
                        {
                            thisElement.New_Element_Requested += thisElement_New_Element_Requested;
                            thisElement.Help_Requested += thisElement_Help_Requested;
                            thisElement.Redraw_Requested += thisElement_Redraw_Requested;
                            thisElement.Data_Changed += thisElement_Data_Changed;
                        }

                        // Some special routines for the structure map
                        if (thisElement.Type == Element_Type.Structure_Map)
                        {
                            ((Structure_Map_Element)thisElement).ImageList = imageList1;
                            ((Structure_Map_Element)thisElement).TemplatePanel = thisPanel;
                            tabPagePanel.Size = new Size(thisTabPage.Width - 15, thisTabPage.Height - 10);
                            tabPagePanel.Resize += ((Structure_Map_Element)thisElement).tabPagePanel_Resize;
                            tabPagePanel.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                      | AnchorStyles.Left) | AnchorStyles.Right)));
                            thisElement.Size = new Size(tabPagePanel.Width - 10, tabPagePanel.Height - 50);
                            thisPanel.Width = tabPagePanel.Width - 10;
                            thisPanel.Height = tabPagePanel.Height - 20;
                            thisElement.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                     | AnchorStyles.Left) | AnchorStyles.Right)));
                            thisTabPage.Name = "TOC";
                            thisPage.Name = "TOC";
                        }

                        // Set the initial tab order as well
                        thisElement.TabIndex = tabIndex++;
                    }
                }
            }

            // Finish setting the tab order
            exitButton.TabIndex = tabIndex++;
            saveButton.TabIndex = tabIndex++;
            applyButton.TabIndex = tabIndex;

            Size = MetaTemplate_UserSettings.Last_Size;

            // Set the menu items appropriately
            viewToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveAsMetsFileToolStripMenuItem3.Enabled = true;
            dublinCoreFileToolStripMenuItem1.Enabled = true;
            marcXMLFileToolStripMenuItem.Enabled = true;
            modsFileToolStripMenuItem1.Enabled = true;
            dublinCorerecordsToolStripMenuItem.Enabled = true;
            rdfDublinCoreToolStripMenuItem.Enabled = true;
            projectFilepmetsToolStripMenuItem.Enabled = true;
            saveButton.Button_Text = MessageProvider_Gateway.Save.ToUpper();

            ResumeLayout();
        }

        private Template Load_Template_And_AddOns(SobekCM_Item Current_Item)
        {
            // Read the template and set the language to the default
            string template_file = Application.StartupPath + "\\Templates\\" + MetaTemplate_UserSettings.Default_Template + ".xml";
            Template returnVal = Template.Read_XML_Template(template_file, excludeDivisions);

            // Now, add each add-on page
            foreach (string addOn in MetaTemplate_UserSettings.AddOns_Enabled)
            {
                string addOnFile = Application.StartupPath + "\\AddOns\\" + addOn + ".xml";
                if (File.Exists(addOnFile))
                {
                    Template addOnTemplate = Template.Read_XML_Template(addOnFile);
                    if (addOnTemplate.InputPages.Count > 0)
                    {
                        Template_Page thisPage = addOnTemplate.InputPages[0];
                        returnVal.InputPages.Add(thisPage);
                    }
                }
            }

            // Finally, add the structure map tab
            if (Current_Item.Bib_Info.SobekCM_Type != TypeOfResource_SobekCM_Enum.Project)
            {
                Template_Page structureMapPage = new Template_Page();
                structureMapPage.Set_Title(Template_Language.English, "Structure Map");
                structureMapPage.Set_Title(Template_Language.Spanish, "Archivose");
                structureMapPage.Set_Title(Template_Language.French, "Dossiers");
                Template_Panel structureMapPanel = new Template_Panel();
                structureMapPanel.Set_Title(Template_Language.English, "Structure Map");
                structureMapPanel.Set_Title(Template_Language.Spanish, "Mapa de Estructura");
                structureMapPanel.Set_Title(Template_Language.French, "Carte de Structure");
                structureMapPage.Panels.Add(structureMapPanel);
                Structure_Map_Element structureMapElement = new Structure_Map_Element();
                structureMapPanel.Elements.Add(structureMapElement);
                returnVal.InputPages.Add(structureMapPage);
            }

            // Set some basic values
            returnVal.Current_Font = MetaTemplate_UserSettings.Last_Font;
            returnVal.Set_Language(MetaTemplate_UserSettings.Last_Language);

            // Set the width and height
            returnVal.Width = MetaTemplate_UserSettings.Last_Size.Width - 50;

            // If the current item is not null, adjust template if it is a PROJECT
            if (Current_Item != null)
            {
                // If the current item is a PROJECT, there are certain fields which should not be available
                // for editing in the template.  Remove those and any emptied panels or pages
                if (Current_Item.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
                {
                    // Build the list of elements, panels, and pages to examine for removal
                    List<abstract_Element> remove_elements = new List<abstract_Element>();
                    List<Template_Panel> remove_panel = new List<Template_Panel>();
                    List<Template_Page> remove_page = new List<Template_Page>();

                    // Step through all the elements looking for elements to remove, and then add to the list
                    // of elements to remove, and panels and pages to examine
                    foreach (Template_Page thisPage in returnVal.InputPages)
                    {
                        foreach (Template_Panel thisPanel in thisPage.Panels)
                        {
                            foreach (abstract_Element thisElement in thisPanel.Elements)
                            {
                                if ((thisElement.Type == Element_Type.SerialHierarchy) || (thisElement.Type == Element_Type.RecordStatus) || (thisElement.Type == Element_Type.VID) || (thisElement.Type == Element_Type.OtherFiles) || (thisElement.Type == Element_Type.MainThumbnail))
                                {
                                    remove_elements.Add(thisElement);
                                    remove_panel.Add(thisPanel);
                                    remove_page.Add(thisPage);
                                }
                            }
                        }
                    }

                    // Step through and remove all unwanted elements and emptied panels and pages
                    for (int i = 0; i < remove_panel.Count; i++)
                    {
                        remove_panel[i].Elements.Remove(remove_elements[i]);
                        if (remove_panel[i].Elements.Count == 0)
                        {
                            remove_page[i].Panels.Remove(remove_panel[i]);
                            if (remove_page[i].Panels.Count == 0)
                            {
                                returnVal.InputPages.Remove(remove_page[i]);
                            }
                        }
                    }
                }
            }

            return returnVal;
        }

        #endregion

        #region Methods for recomputing and redrawing the template after a change (such as adding a new element )

        private void Re_Tab_Index()
        {
            tabControl1.TabIndex = 1;

            int tabIndex = 2;
            // Add a tab control for each page
            foreach (Template_Page thisPage in thisTemplate.InputPages)
            {
                // Add each element to the tab panel as well
                foreach (Template_Panel thisPanel in thisPage.Panels)
                {
                    foreach (abstract_Element thisElement in thisPanel.Elements)
                    {
                        thisElement.TabIndex = tabIndex++;
                    }
                }
            }

            saveButton.TabIndex = tabIndex++;
            exitButton.TabIndex = tabIndex++;
        }

        private void set_tab_page_panel_heights()
        {
            // Recalculate everything
            TabPage thisTabPage;
            for (int i = 0; i < thisTemplate.InputPages.Count; i++)
            {
                thisTabPage = tabControl1.TabPages[i];
                if (thisTabPage.Name != "TOC")
                {
                    (thisTabPage.Controls[0]).Height = thisTemplate.InputPages[i].Height;
                }
            }
        }

        private void ReDraw()
        {
            // Save the selected tab page
            int tab_page = tabControl1.SelectedIndex;

            // Set the title for this
            //this.Text = thisTemplate.Title;

            // Redraw the template
            Load_And_Display_Template(inprocessItem, false);

            // Set back to the selected index
            if (tab_page < tabControl1.TabCount)
                tabControl1.SelectedIndex = tab_page;
        }

        #endregion

        #region abstract_Element Event Handlers

        void thisElement_Data_Changed(abstract_Element thisElement)
        {
            applyButton.Button_Enabled = true;
        }

        private void thisElement_New_Element_Requested(abstract_Element thisElement)
        {
            // Get the current tab page selected 
            int tabPage = tabControl1.SelectedIndex;

            // Get the new element
            abstract_Element newElement = thisElement.Clone();
            newElement.Repeatable = true;
            newElement.Mandatory = false;
            thisElement.Repeatable = false;

            // Insert this new element
            // Step through each page 
            int tabPageIndex = 0;
            foreach (Template_Page thisPage in thisTemplate.InputPages)
            {
                // Look through each panel on this page
                foreach (Template_Panel thisPanel in thisPage.Panels)
                {
                    // Does this panel contain the element that fired?
                    if (thisPanel.Elements.Contains(thisElement))
                    {
                        // Insert this new element into the Template
                        thisPanel.Elements.Insert(thisPanel.Elements.IndexOf(thisElement) + 1, newElement);

                        // Add event handlers to this element
                        newElement.New_Element_Requested += thisElement_New_Element_Requested;
                        newElement.Help_Requested += thisElement_Help_Requested;
                        newElement.Redraw_Requested += thisElement_Redraw_Requested;
                        newElement.Data_Changed += thisElement_Data_Changed;

                        // Recalculate everything
                        thisPanel.Compute_Height_And_Locations();
                        thisPage.Compute_Locations();

                        // Calculate the height of all the panels in this page
                        Panel thisTabPanel = (Panel)(tabControl1.TabPages[tabPageIndex]).Controls[0];
                        thisTabPanel.Controls.Add(newElement);
                        thisTabPanel.Height = thisPage.Height;

                        foreach (Control thisControl in thisTabPanel.Controls)
                        {
                            thisControl.Invalidate();
                        }
                        thisTabPanel.Invalidate();
                        break;
                    }
                }

                tabPageIndex++;
            }

            Re_Tab_Index();

            // Set the current tab page selected 
            tabControl1.SelectedIndex = tabPage;
            newElement.Focus();
        }

        private void thisElement_Help_Requested(abstract_Element thisElement)
        {
            if (helpProvider == null) return;

            try
            {
                Process onlineHelp = new Process
                                         {
                                             StartInfo = { FileName = helpProvider.URL_from_Help_Term(thisElement.Help_URL()) }
                                         };
                onlineHelp.Start();
            }
            catch
            {
                // Error caught, but no reason to really do anything here
                MessageBox.Show("Error displaying the elements help file.");
            }
        }

        private void thisElement_Redraw_Requested(abstract_Element thisElement)
        {
            // Resize the template (which automatically recalculates everything)
            thisTemplate.Width = Width - 30;

            // Re-calculate the height of each tab page panel
            set_tab_page_panel_heights();

            // Redraw this whole form
            ReDraw();
        }

        #endregion

        #region Basic Form Event Handlers (resize, closing, visibility changed, etc.. )

        private void Template_Form_Resize(object sender, EventArgs e)
        {
            // Recompute the location for all the elements and the size of each panel
            if (thisTemplate != null)
            {
                thisTemplate.Width = Width - 50;

                // Compute the height of each panel
                set_tab_page_panel_heights();
            }
        }

        private void Template_Form_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (thisTemplate != null)
                {
                    thisTemplate.Width = Width - 50;
                }
            }
        }

        private void Template_Form_Closing(object sender, CancelEventArgs e)
        {
            // Save the size
            if ((Size.Width != 596) || (Size.Height != 563))
            {
                MetaTemplate_UserSettings.Last_Size = new Size(Size.Width + 2, Size.Height);
            }

            MetaTemplate_UserSettings.Last_Font = Font;
            MetaTemplate_UserSettings.Save();
        }

        #region Code to draw the background on resize

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

        #endregion

        #region Event handlers to paint the tab control and tab pages correctly

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;

            // Define brushes and pens needed to cover residual grey areas
            Brush background = new SolidBrush(selectedTabPageColor);
            Pen blackPen = new Pen(tabPageBorderLineColor, 1);

            // Get the tab control for this
            TabControl parentTabControl = (TabControl)sender;

            // Determine the rectangle to color for this tab button
            Rectangle r_textarea = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height + 1);

            // Gets the background color from the parent control
            Color maincolor = parentTabControl.Parent.BackColor;

            // Get the whole tab control rectangle
            Rectangle wholeTab = parentTabControl.ClientRectangle;

            // Gets the rectangle covered by  the last tab button in the row
            Rectangle r2 = parentTabControl.GetTabRect(parentTabControl.TabCount - 1);

            // Fill the area after the last tab button
            Rectangle r3 = new Rectangle(r2.X + r2.Width, r2.Y - 2, parentTabControl.Width - r2.X - r2.Width, r2.Height + 2);
            SolidBrush brush = new SolidBrush(maincolor);
            e.Graphics.FillRectangle(brush, r3);

            // Set the color and font by whether this tab is selected
            if (e.Index == parentTabControl.SelectedIndex)
            {
                // Set the font and colors for this selected tab button
                fntTab = e.Font; // new Font(e.Font, FontStyle.Bold);
                bshBack = new SolidBrush(selectedTabPageColor);
                bshFore = Brushes.Black;

                // Draw lines at the top of the tab control (previously line was grey)
                e.Graphics.DrawLine(blackPen, wholeTab.X + 5, wholeTab.Y + e.Bounds.Height + 5, wholeTab.X + e.Bounds.X, wholeTab.Y + e.Bounds.Height + 50);
            }
            else
            {
                // Set the font and colors for this non-selected tab button
                fntTab = e.Font;
                bshBack = new SolidBrush(maincolor);
                bshFore = new SolidBrush(Color.Black);
            }

            // Fill in this tab
            e.Graphics.FillRectangle(bshBack, r_textarea);

            // Define the rectangle seperately to determine where to write the text
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X + 2, recTab.Y + 4, recTab.Width, recTab.Height - 4);

            // Draw (write) tab text again 
            string tabName = parentTabControl.TabPages[e.Index].Text;
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, new StringFormat());

            // Color the grey over which was on the left side of the tab control
            Rectangle leftSide = new Rectangle(wholeTab.X, wholeTab.Y + e.Bounds.Height, 4, wholeTab.Height - e.Bounds.Height);
            e.Graphics.FillRectangle(background, leftSide);

            // Draw a line to indicate the left side
            e.Graphics.DrawLine(blackPen, wholeTab.X, wholeTab.Y + e.Bounds.Height + 2, wholeTab.X, wholeTab.Y + wholeTab.Height);

            // Color the grey over which was on the bottom of the tab control
            Rectangle bottom = new Rectangle(wholeTab.X + 1, wholeTab.Y + wholeTab.Height - 4, wholeTab.Width - 2, 4);
            e.Graphics.FillRectangle(background, bottom);

            // Draw a line to indicate the left side
            e.Graphics.DrawLine(blackPen, wholeTab.X, wholeTab.Y + wholeTab.Height - 1, wholeTab.X + wholeTab.Width, wholeTab.Y + wholeTab.Height - 1);

            // Color the grey over which was on the right side of the tab control
            Rectangle rightSide = new Rectangle(wholeTab.X + wholeTab.Width - 4, wholeTab.Y + e.Bounds.Height, 4, wholeTab.Height - e.Bounds.Height - 2);
            e.Graphics.FillRectangle(background, rightSide);

            // Draw a line to indicate the right side
            e.Graphics.DrawLine(blackPen, wholeTab.X + wholeTab.Width - 1, wholeTab.Y + e.Bounds.Height, wholeTab.X + wholeTab.Width - 1, wholeTab.Y + wholeTab.Height);

            if (e.Index == parentTabControl.SelectedIndex)
            {
                // Get this rectangle
                Rectangle selectedTabControl = parentTabControl.GetTabRect(e.Index);

                // Draw lines at the top of the tab control (previously line was grey)
                e.Graphics.DrawLine(blackPen, wholeTab.X + 1, wholeTab.Y + selectedTabControl.Height + 2, wholeTab.X + selectedTabControl.X, wholeTab.Y + selectedTabControl.Height + 2);
                e.Graphics.DrawLine(blackPen, wholeTab.X + selectedTabControl.X + selectedTabControl.Width, wholeTab.Y + selectedTabControl.Height + 2, wholeTab.X + wholeTab.Width, wholeTab.Y + selectedTabControl.Height + 2);

                // Draw lines to the top of the actual tab page button
                e.Graphics.DrawLine(blackPen, selectedTabControl.X, selectedTabControl.Y, selectedTabControl.X + selectedTabControl.Width, selectedTabControl.Y);

                // Draw a line to the left of the actual tab page button
                e.Graphics.DrawLine(blackPen, selectedTabControl.X, selectedTabControl.Y, selectedTabControl.X, selectedTabControl.Y + selectedTabControl.Height);

            }
        }

        private void tabPagePanel_Paint(object sender, PaintEventArgs e)
        {
            // Pull out the needed objects to draw this
            Graphics g = e.Graphics;
            Template_Page thisPage = ((Template_Page)((Panel)sender).Tag);

            // Draw this page on the tab
            thisPage.Draw(g);
        }

        #endregion

        #region Main buttons event handlers

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (applyButton.Button_Enabled)
            {
                DialogResult result = MessageBox.Show("Cancel all changes and close this form?       ", "Cancel Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MetaTemplate_UserSettings.Last_Font = Font;
                    MetaTemplate_UserSettings.Save();
                    metsDirectory = saveDirectory;
                    tabControl1.Hide();
                    saveButton.Text = MessageProvider_Gateway.Exit;
                    applyButton.Button_Enabled = false;
                    viewToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    saveAsMetsFileToolStripMenuItem3.Enabled = false;
                    dublinCoreFileToolStripMenuItem1.Enabled = false;
                    marcXMLFileToolStripMenuItem.Enabled = false;
                    modsFileToolStripMenuItem1.Enabled = false;
                    dublinCorerecordsToolStripMenuItem.Enabled = false;
                    rdfDublinCoreToolStripMenuItem.Enabled = false;
                    projectFilepmetsToolStripMenuItem.Enabled = false;
                    thisTemplate = null;
                    noMetsPanel.Show();
                }
            }
            else
            {
                if (noMetsPanel.Visible)
                {
                    MetaTemplate_UserSettings.Save();
                    Close();
                }
                else
                {
                    MetaTemplate_UserSettings.Last_Font = Font;
                    MetaTemplate_UserSettings.Save();
                    metsDirectory = saveDirectory;
                    tabControl1.Hide();
                    saveButton.Text = MessageProvider_Gateway.Exit;
                    applyButton.Button_Enabled = false;
                    viewToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    saveAsMetsFileToolStripMenuItem3.Enabled = false;
                    dublinCoreFileToolStripMenuItem1.Enabled = false;
                    marcXMLFileToolStripMenuItem.Enabled = false;
                    modsFileToolStripMenuItem1.Enabled = false;
                    dublinCorerecordsToolStripMenuItem.Enabled = false;
                    rdfDublinCoreToolStripMenuItem.Enabled = false;
                    projectFilepmetsToolStripMenuItem.Enabled = false;
                    thisTemplate = null;
                    noMetsPanel.Show();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (noMetsPanel.Visible)
            {
                Close();
            }
            else
            {
                MetaTemplate_UserSettings.Save();
                if (applyButton.Button_Enabled)
                {
                    SobekCM_Item newBib = Save_METS();
                    if (newBib != null)
                    {
                        MetaTemplate_UserSettings.Last_Font = Font;
                        MetaTemplate_UserSettings.Save();
                        metsDirectory = saveDirectory;
                        //thisTemplate = load_template(last_template_file, String.Empty, String.Empty );
                        //display_template(thisTemplate, true);
                        tabControl1.Hide();
                        saveButton.Text = MessageProvider_Gateway.Exit;
                        applyButton.Button_Enabled = false;
                        viewToolStripMenuItem.Enabled = false;
                        saveToolStripMenuItem.Enabled = false;
                        saveAsToolStripMenuItem.Enabled = false;
                        saveAsMetsFileToolStripMenuItem3.Enabled = false;
                        dublinCoreFileToolStripMenuItem1.Enabled = false;
                        marcXMLFileToolStripMenuItem.Enabled = false;
                        modsFileToolStripMenuItem1.Enabled = false;
                        dublinCorerecordsToolStripMenuItem.Enabled = false;
                        rdfDublinCoreToolStripMenuItem.Enabled = false;
                        projectFilepmetsToolStripMenuItem.Enabled = false;
                        thisTemplate = null;
                        noMetsPanel.Show();
                    }
                }
                else
                {
                    MetaTemplate_UserSettings.Last_Font = Font;
                    MetaTemplate_UserSettings.Save();
                    metsDirectory = saveDirectory;
                    //thisTemplate = load_template(last_template_file, String.Empty, String.Empty );
                    //display_template(thisTemplate, true);
                    tabControl1.Hide();
                    saveButton.Text = MessageProvider_Gateway.Exit;
                    viewToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    saveAsMetsFileToolStripMenuItem3.Enabled = false;
                    dublinCoreFileToolStripMenuItem1.Enabled = false;
                    marcXMLFileToolStripMenuItem.Enabled = false;
                    modsFileToolStripMenuItem1.Enabled = false;
                    dublinCorerecordsToolStripMenuItem.Enabled = false;
                    rdfDublinCoreToolStripMenuItem.Enabled = false;
                    projectFilepmetsToolStripMenuItem.Enabled = false;
                    thisTemplate = null;
                    noMetsPanel.Show();
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SobekCM_Item newBib = Save_METS();
            if (newBib != null)
            {
                applyButton.Button_Enabled = false;
            }
        }

        #endregion

        #region Initial menu linked labels event handlers

        private void newMetsFileLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            New_File();
        }

        private void openMetsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "METS files |*.mets*;*.xml|Project METS files|*.pmets";
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                Open_Existing_METS_File(openFileDialog1.FileName);
            }
        }

        private void batchMetsCreateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            noMetsPanel.Hide();
            batchImportPanel.Show();
        }

        private void derivativesMetsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Image_Derivative_Creation_Form createDerivatives = new Image_Derivative_Creation_Form();
            Hide();
            createDerivatives.ShowDialog();
            Show();
        }

        private void onlineHelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process onlineHelp = new Process {StartInfo = {FileName = "http://ufdc.ufl.edu/metseditor"}};
                onlineHelp.Start();
            }
            catch
            {
                // Error caught, but no reason to really do anything here
                MessageBox.Show("Error displaying the main help file.");
            }
        }

        #endregion

        #region Batch importing menu linked labels event handlers

        private void batchImportCancelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            noMetsPanel.Show();
            batchImportPanel.Hide();
        }

        private void batchImportSpreadsheetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create an instance of the SpreadSheet Importer form
            SpreadSheet_Importer_Form spreadSheetImporterForm = new SpreadSheet_Importer_Form();
            Hide();
            spreadSheetImporterForm.ShowDialog();
            noMetsPanel.Show();
            batchImportPanel.Hide();
            Show();
        }

        private void batchImportMarcLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create an instance of the MARC Importer form
            MARC_Importer_Form marcImporterForm = new MARC_Importer_Form();
            Hide();
            marcImporterForm.ShowDialog();
            noMetsPanel.Show();
            batchImportPanel.Hide();
            Show();
        }

        private void batchImportDirectoryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Batch_Import_Directory_Traverse_Form showForm = new Batch_Import_Directory_Traverse_Form();
            Hide();
            showForm.ShowDialog();

            batchImportPanel.Hide();
            noMetsPanel.Show();
            Show();
        }

        #endregion

        #region Main menu bar event handlers

        #region Main menu bar ACTION event handlers

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_File();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "METS files |*.mets*;*.xml|Project METS files|*.pmets";
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                Open_Existing_METS_File(openFileDialog1.FileName);
            }
        }

        private void recent_Click(object sender, EventArgs e)
        {
            try
            {
                string file = ((ToolStripMenuItem)sender).Text;
                if (file.Length > 0)
                {
                    Open_Existing_METS_File(file.Replace("&&", "&"));
                }
            }
            catch
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobekCM_Item newBib = Save_METS();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetaTemplate_UserSettings.Save();
            Close();
        }

        #region Event handlers for saving item in a different format or location

        private void dublinCoreFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (metsFile.Length > 0)
            {
                saveFileDialog1.Filter = "Dublin Core XML files|*.xml*";
                saveFileDialog1.FileName = metsFile.Replace("mets", "xml").Replace(".xml.xml", ".xml");
                DialogResult results = saveFileDialog1.ShowDialog();
                if (results == DialogResult.OK)
                {
                    // Create a bib package to create the METS
                    SobekCM_Item newBib = SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);

                    // Save all the values from the template to this bib
                    thisTemplate.Save_To_Bib(newBib);

                    // Write as dublin core
                    DC_File_ReaderWriter writer = new DC_File_ReaderWriter();
                    string save_error = String.Empty;
                    writer.Write_Metadata(saveFileDialog1.FileName, newBib, null, out save_error);
                }
            }
            else
            {
                MessageBox.Show("Save this METS file before trying to export as a Dublin Core file.   ");
            }
        }

        private void rDFDublinCoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metsFile.Length > 0)
            {
                saveFileDialog1.Filter = "Dublin Core XML files|*.xml*";
                saveFileDialog1.FileName = metsFile.Replace("mets", "xml").Replace(".xml.xml", ".xml");
                DialogResult results = saveFileDialog1.ShowDialog();
                if (results == DialogResult.OK)
                {
                    // Create a bib package to create the METS
                    SobekCM_Item newBib = SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);

                    // Save all the values from the template to this bib
                    thisTemplate.Save_To_Bib(newBib);

                    // Write as dublin core
                    DC_File_ReaderWriter writer = new DC_File_ReaderWriter();
                    string save_error = String.Empty;
                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options["DC_File_ReaderWriter:RDF_Style"] = true;
                    writer.Write_Metadata(saveFileDialog1.FileName, newBib, options, out save_error);
                }
            }
            else
            {
                MessageBox.Show("Save this METS file before trying to export as a Dublin Core file.   ");
            }
        }

        private void marcXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metsFile.Length > 0)
            {
                saveFileDialog1.Filter = "MarcXML files|*.xml*";
                saveFileDialog1.FileName = metsFile.Replace("mets", "xml").Replace(".xml.xml", ".xml");
                DialogResult results = saveFileDialog1.ShowDialog();
                if (results == DialogResult.OK)
                {
                    // Create a bib package to create the METS
                    SobekCM_Item newBib = SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);

                    // Save all the values from the template to this bib
                    thisTemplate.Save_To_Bib(newBib);

                    // Write as marc xml
                    MarcXML_File_ReaderWriter writer = new MarcXML_File_ReaderWriter();
                    string save_error = String.Empty;
                    writer.Write_Metadata(saveFileDialog1.FileName, newBib, null, out save_error);
                }
            }
            else
            {
                MessageBox.Show("Save this METS file before trying to export as a MarcXML file.   ");
            }
        }

        private void mODSFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (metsFile.Length > 0)
            {
                saveFileDialog1.Filter = "MODS XML files|*.xml*";
                saveFileDialog1.FileName = metsFile.Replace("mets", "xml").Replace(".xml.xml", ".xml");
                DialogResult results = saveFileDialog1.ShowDialog();
                if (results == DialogResult.OK)
                {
                    // Create a bib package to create the METS
                    SobekCM_Item newBib =SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);

                    // Save all the values from the template to this bib
                    thisTemplate.Save_To_Bib(newBib);

                    // Write as a stand-alone mods file
                    MODS_File_ReaderWriter writer = new MODS_File_ReaderWriter();
                    string save_error = String.Empty;
                    writer.Write_Metadata(saveFileDialog1.FileName, newBib, null, out save_error);
 
                }
            }
            else
            {
                MessageBox.Show("Save this METS file before trying to export as a MODS file.   ");
            }
        }

        private void saveAsMetsFileToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Check for validity
            if (thisTemplate.isValid())
            {
                // Create a bib package to create the METS
                SobekCM_Item newBib = new SobekCM_Item();

                // Was this an existing METS?
                if ((metsFile.Length > 0) && (File.Exists(metsFile)))
                {
                    newBib = SobekCM_Item.Read_METS(metsFile);
                    thisTemplate.Prepare_For_Save(newBib);
                }


                // Save all the values from the template to this bib
                thisTemplate.Save_To_Bib(newBib);

                // Enusure there is a name here
                if (metsFile.Length == 0)
                {
                    if (newBib.VID.Length > 0)
                    {
                        metsFile = metsDirectory + "\\" + newBib.BibID + "_" + newBib.VID + MetaTemplate_UserSettings.METS_File_Extension;
                    }
                    else
                    {
                        metsFile = metsDirectory + "\\" + newBib.BibID + MetaTemplate_UserSettings.METS_File_Extension; 
                    }
                }


                // Change the last mofidied date and person
                SecurityInfo getName = new SecurityInfo();
                newBib.METS_Header.Modify_Date = DateTime.Now;
                newBib.METS_Header.Creator_Individual = getName.UserName;


                try
                {
                    // In this case, always show the save as file diaglog results
                    saveFileDialog1.InitialDirectory = MetaTemplate_UserSettings.METS_Save_Directory;
                    if (metsDirectory.Length > 0)
                        saveFileDialog1.InitialDirectory = metsDirectory;
                    saveFileDialog1.FileName = newBib.BibID + MetaTemplate_UserSettings.METS_File_Extension;
                    if (newBib.VID.Length > 0)
                        saveFileDialog1.FileName = newBib.BibID + "_" + newBib.VID + MetaTemplate_UserSettings.METS_File_Extension; ;

                    DialogResult saveFileDialogResult = saveFileDialog1.ShowDialog();
                    if (saveFileDialogResult == DialogResult.OK)
                    {
                        metsFile = saveFileDialog1.FileName;
                        var directoryInfo = (new FileInfo(metsFile)).Directory;
                        if (directoryInfo != null)
                            metsDirectory = directoryInfo.ToString();
                        MetaTemplate_UserSettings.METS_Save_Directory = metsDirectory;
                        MetaTemplate_UserSettings.Save();
                    }
                    else
                    {
                        return;
                    }

                    newBib.Source_Directory = metsDirectory;
                    if (!Directory.Exists(metsDirectory))
                    {
                        Directory.CreateDirectory(metsDirectory);
                    }

                    // Save the METS file
                    Save_Actual_METS_File(metsFile, newBib);

                    // If this is set to always show the METS do that noe
                    if (MetaTemplate_UserSettings.Show_Metadata_PostSave)
                    {
                        try
                        {
                            Show_XML_Form show = new Show_XML_Form(metsFile, true);
                            show.ShowDialog();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Error while launching XML form.\n\nThis form may require Internet Explorer and full trust.\n\nPlease report this issue to programmer Mark Sullivan ( Mark.V.Sullivan@gmail.com ).           \n\nMessage: " + ee.Message, "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ee)
                {
                    ErrorMessageBox.Show(MessageProvider_Gateway.Error_Saving_METS_File_Message + "\n\n'" + metsDirectory + "\\" + newBib.BibID + "_" + newBib.VID + MetaTemplate_UserSettings.METS_File_Extension, MessageProvider_Gateway.Error_Saving_METS_File_Title, ee);
                }
            }
            else
            {
                MessageBox.Show(MessageProvider_Gateway.Error_Validating_METS_File_Message + "\n\n" + thisTemplate.Validity_Errors, MessageProvider_Gateway.Error_Validating_METS_File_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void projectFilepmetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check for validity
            if (thisTemplate.isValid())
            {
                New_Project_Form projForm = new New_Project_Form();
                this.Hide();
                projForm.ShowDialog();

                if (projForm.Valid_Project_Code.Length > 0)
                {
                    try
                    {
                        string projCode = projForm.Valid_Project_Code;

                        // Create a bib package to create the METS
                        SobekCM_Item newBib = new SobekCM_Item();

                        // Was this an existing METS?
                        if ((metsFile.Length > 0) && (File.Exists(metsFile)))
                        {
                            newBib = SobekCM_Item.Read_METS(metsFile);
                            thisTemplate.Prepare_For_Save(newBib);
                        }

                        // Save all the values from the template to this bib
                        thisTemplate.Save_To_Bib(newBib);

                        // Change the last mofidied date and person
                        newBib.METS_Header.Modify_Date = DateTime.Now;
                        if (newBib.METS_Header.Creator_Individual.Length == 0)
                        {
                            if (MetaTemplate_UserSettings.Individual_Creator.Length > 0)
                            {
                                newBib.METS_Header.Creator_Individual = MetaTemplate_UserSettings.Individual_Creator;
                            }
                            else
                            {
                                SecurityInfo getName = new SecurityInfo();
                                newBib.METS_Header.Creator_Individual = getName.UserName;
                            }
                        }

                        newBib.Divisions.Clear();
                        
                        newBib.BibID = projCode;
                        newBib.VID = "00001";
                        newBib.Bib_Info.Record.Main_Record_Identifier.Identifier = String.Empty;
                        newBib.Bib_Info.Main_Title.Title = "Project level metadata for '" + projCode + "'";
                        newBib.Bib_Info.Add_Note(newBib.Bib_Info.SobekCM_Type_String, Note_Type_Enum.default_type);
                        newBib.Bib_Info.SobekCM_Type = TypeOfResource_SobekCM_Enum.Project;
                        newBib.Save_METS(Application.StartupPath + "\\Projects\\" + projCode + ".pmets");

                        MessageBox.Show( "New project '" + projCode + "' saved.\n\nYou can set this as your default project by selecting Options --> Metadata Preferences --> Projects.", "New Project Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show( "Unable to save new project file.\n\nEnsure you have access to write in the PROJECTS subfolder.\n\n" + Application.StartupPath + "\\Projects\n\n" + ee.Message);
                    }
                }

                this.Show();
            }
            else
            {
                // Template is not validating
                MessageBox.Show( MessageProvider_Gateway.Error_Validating_METS_File_Message + "\n\n" + thisTemplate.Validity_Errors, MessageProvider_Gateway.Error_Validating_METS_File_Title, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        #endregion

        #region Methods for importing data from a different format

        /// <summary> Creates a new empty item ready for an import from a different format </summary>
        /// <returns></returns>
        /// <remarks> This is used for all import routines, except for from EADs </remarks>
        private SobekCM_Item Create_New_Item_For_Import( string New_Directory )
        {
            SobekCM_Item newItem = new SobekCM_Item();

            // Save the division info if there is one
            if ((metsDirectory.Length > 0) && (thisTemplate != null))
            {
                newItem.Source_Directory = metsDirectory;
                // Copy the division information from the current template
                foreach (Template_Page thisPage in thisTemplate.InputPages)
                {
                    foreach (Template_Panel thisPanel in thisPage.Panels)
                    {
                        foreach (abstract_Element thisElement in thisPanel.Elements)
                        {
                            if (thisElement.Type == Element_Type.Structure_Map)
                            {
                                thisElement.Save_To_Bib(newItem);
                            }
                        }
                    }
                }
            }
            else
            {
                if ( !String.IsNullOrEmpty(New_Directory))
                    newItem.Source_Directory = New_Directory;
            }

            List<string> addOns = MetaTemplate_UserSettings.AddOns_Enabled;

            // Add FCLA add-on defaults
            if (addOns.Contains("FCLA"))
            {
                PALMM_Info palmmInfo = newItem.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
                if (palmmInfo == null)
                {
                    palmmInfo = new PALMM_Info();
                    newItem.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
                }
                palmmInfo.PALMM_Project = MetaTemplate_UserSettings.PALMM_Code;
                palmmInfo.toPALMM = MetaTemplate_UserSettings.FCLA_Flag_PALMM;


                DAITSS_Info daitssInfo = newItem.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                if (daitssInfo == null)
                {
                    daitssInfo = new DAITSS_Info();
                    newItem.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
                }
                daitssInfo.toArchive = MetaTemplate_UserSettings.FCLA_Flag_FDA;
                daitssInfo.Account = MetaTemplate_UserSettings.FDA_Account;
                daitssInfo.SubAccount = MetaTemplate_UserSettings.FDA_SubAccount;
                daitssInfo.Project = MetaTemplate_UserSettings.FDA_Project;
            }

            // Add SobekCM add-on defaults
            if (addOns.Contains("SOBEKCM"))
            {
                // Add any wordmarks
                List<string> wordmarks = MetaTemplate_UserSettings.SobekCM_Wordmarks;
                foreach (string thisWordmark in wordmarks)
                    newItem.Behaviors.Add_Wordmark(thisWordmark);

                // Add any aggregations
                List<string> aggregations = MetaTemplate_UserSettings.SobekCM_Aggregations;
                foreach (string thisAggregation in aggregations)
                    newItem.Behaviors.Add_Aggregation(thisAggregation);

                // Add any web skins
                List<string> webskins = MetaTemplate_UserSettings.SobekCM_Web_Skins;
                foreach (string thisWebSkin in webskins)
                    newItem.Behaviors.Add_Web_Skin(thisWebSkin);

                // Add any viewers
                List<string> viewers = MetaTemplate_UserSettings.SobekCM_Viewers;
                foreach (string thisViewer in viewers)
                {
                    if ( String.CompareOrdinal(thisViewer, "Page Image (JPEG)") == 0)
                        newItem.Behaviors.Add_View(View_Enum.JPEG);
                    if (String.CompareOrdinal(thisViewer, "Zoomable (JPEG2000)") == 0)
                        newItem.Behaviors.Add_View(View_Enum.JPEG2000);
                    if (String.CompareOrdinal(thisViewer, "Page Turner") == 0)
                        newItem.Behaviors.Add_View(View_Enum.PAGE_TURNER);
                    if (String.CompareOrdinal(thisViewer, "Text") == 0)
                        newItem.Behaviors.Add_View(View_Enum.TEXT);
                    if (String.CompareOrdinal(thisViewer, "Thumbnails") == 0)
                        newItem.Behaviors.Add_View(View_Enum.RELATED_IMAGES);
                }
            }

            // Add all other defaults
            newItem.Bib_Info.Source.Code = MetaTemplate_UserSettings.Default_Source_Code;
            newItem.Bib_Info.Source.Statement = MetaTemplate_UserSettings.Default_Source_Statement;
            if (MetaTemplate_UserSettings.Default_Funding_Note.Length > 0)
                newItem.Bib_Info.Add_Note(MetaTemplate_UserSettings.Default_Funding_Note, Note_Type_Enum.funding);
            if (MetaTemplate_UserSettings.Default_Rights_Statement.Length > 0)
                newItem.Bib_Info.Access_Condition.Text = MetaTemplate_UserSettings.Default_Rights_Statement;

            newItem.BibID = (new DirectoryInfo(metsDirectory)).Name;
            if ((newItem.BibID.Length == 16) && (newItem.BibID[10] == '_'))
            {
                newItem.VID = newItem.BibID.Substring(11);
                newItem.BibID = newItem.BibID.Substring(0, 10);
            }
            return newItem;
        }

        private void dublinCoreFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Dublin Core XML files|*.xml*";
            openFileDialog1.FileName = String.Empty;
            if (metsDirectory.Length > 0)
                openFileDialog1.InitialDirectory = metsDirectory;
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    // Save the structure map information and create a new item to receive the
                    // date from this import
                    SobekCM_Item newItem = Create_New_Item_For_Import((new FileInfo(openFileDialog1.FileName)).DirectoryName);

                    // Open a stream to read the indicated import file
                    Stream reader = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                    DC_File_ReaderWriter dcReader = new DC_File_ReaderWriter();
                    string read_errors = String.Empty;
                    dcReader.Read_Metadata(reader, newItem, null, out read_errors);

                    // Just a file, so open regularly
                    noMetsPanel.Hide();
                    tabControl1.Show();


                    metsFile = String.Empty;

                    // Build the template object, assign the item, and then display within this form
                    Load_And_Display_Template(newItem, true);

                    applyButton.Button_Enabled = true;

                }
                catch
                {
                    MessageBox.Show("Error reading dublin core source file.    ");
                }
            }
        }

        private void eadStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "EAD XML files|*.xml*";
            openFileDialog1.FileName = String.Empty;
            if (metsDirectory.Length > 0)
                openFileDialog1.InitialDirectory = metsDirectory;
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    SobekCM_Item newItem = new SobekCM_Item();
                    EAD_File_ReaderWriter eadReader = new EAD_File_ReaderWriter();
                    string read_errors = String.Empty;
                    eadReader.Read_Metadata(openFileDialog1.FileName, newItem, null, out read_errors);

                    // Set some defaults
                    DAITSS_Info daitssInfo = newItem.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                    if (daitssInfo == null)
                    {
                        daitssInfo = new DAITSS_Info();
                        newItem.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
                    }
                    daitssInfo.toArchive = MetaTemplate_UserSettings.FCLA_Flag_FDA;
                    daitssInfo.Account = MetaTemplate_UserSettings.FDA_Account;
                    daitssInfo.SubAccount = MetaTemplate_UserSettings.FDA_SubAccount;
                    daitssInfo.Project = MetaTemplate_UserSettings.FDA_Project;
                    newItem.Bib_Info.Source.Code = MetaTemplate_UserSettings.Default_Source_Code;
                    newItem.Bib_Info.Source.Statement = MetaTemplate_UserSettings.Default_Source_Statement;

                    // Save the division info if there is one
                    if ((metsDirectory.Length > 0) && (thisTemplate != null))
                    {
                        newItem.Source_Directory = metsDirectory;
                        // Copy the division information from the current template
                        foreach (Template_Page thisPage in thisTemplate.InputPages)
                        {
                            foreach (Template_Panel thisPanel in thisPage.Panels)
                            {
                                foreach (abstract_Element thisElement in thisPanel.Elements)
                                {
                                    if (thisElement.Type == Element_Type.Structure_Map)
                                    {
                                        thisElement.Save_To_Bib(newItem);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var directoryInfo = (new FileInfo(openFileDialog1.FileName)).Directory;
                        if (directoryInfo != null)
                            newItem.Source_Directory = directoryInfo.FullName;
                    }

                    // Keep the BIBID from the directory
                    newItem.BibID = (new DirectoryInfo(newItem.Source_Directory)).Name;
                    if ((newItem.BibID.Length == 16) && (newItem.BibID[10] == '_'))
                    {
                        newItem.VID = newItem.BibID.Substring(11);
                        newItem.BibID = newItem.BibID.Substring(0, 10);
                    }

                    // Just a file, so open regularly
                    noMetsPanel.Hide();
                    tabControl1.Show();

                    metsFile = String.Empty;

                    // Build the template object, assign the item, and then display within this form
                    Load_And_Display_Template(newItem, true);

                    applyButton.Button_Enabled = true;

                    //// Now some testing
                    //newItem.EAD.Container_Hierarchy.Clear();
                    //EAD_File_ReaderWriter.Add_EAD_Information(newItem, openFileDialog1.FileName, String.Empty);

                }
                catch
                {
                    MessageBox.Show("Error reading EAD source file.    ");
                }
            }
        }

        private void marcXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MARC XML files|*.xml*";
            openFileDialog1.FileName = String.Empty;
            if (metsDirectory.Length > 0)
                openFileDialog1.InitialDirectory = metsDirectory;
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    // Save the structure map information and create a new item to receive the
                    // date from this import
                    SobekCM_Item newItem = Create_New_Item_For_Import((new FileInfo(openFileDialog1.FileName)).DirectoryName); 

                    MarcXML_File_ReaderWriter reader = new MarcXML_File_ReaderWriter();
                    string read_errors = String.Empty;
                    reader.Read_Metadata(openFileDialog1.FileName, newItem, null, out read_errors);

                    // Just a file, so open regularly
                    noMetsPanel.Hide();
                    tabControl1.Show();

                    metsFile = String.Empty;

                    // Build the template object, assign the item, and then display within this form
                    Load_And_Display_Template(newItem, true);

                    applyButton.Button_Enabled = true;

                }
                catch
                {
                    MessageBox.Show("Error reading MarcXML source file.    ");
                }
            }
        }

        private void mODSFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MODS XML files|*.xml*";
            openFileDialog1.FileName = String.Empty;
            if (metsDirectory.Length > 0)
                openFileDialog1.InitialDirectory = metsDirectory;
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    // Save the structure map information and create a new item to receive the
                    // date from this import
                    SobekCM_Item newItem = Create_New_Item_For_Import((new FileInfo(openFileDialog1.FileName)).DirectoryName); 

                    // Open a stream to read the indicated import file
                    Stream reader = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                    // create the node reader
                    XmlTextReader nodeReader = new XmlTextReader(reader);
                    MODS_File_ReaderWriter modsReader = new MODS_File_ReaderWriter();
                    string read_errors = String.Empty;
                    modsReader.Read_Metadata(reader, newItem, null, out read_errors);

                    // Just a file, so open regularly
                    noMetsPanel.Hide();
                    tabControl1.Show();

                    metsFile = String.Empty;

                    // Build the template object, assign the item, and then display within this form
                    Load_And_Display_Template(newItem, true);

                    applyButton.Button_Enabled = true;

                }
                catch
                {
                    MessageBox.Show("Error reading MODS source file.    ");
                }
            }
        }

        private void mXFFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MXF files|*.xml*";
            openFileDialog1.FileName = String.Empty;
            if (metsDirectory.Length > 0)
                openFileDialog1.InitialDirectory = metsDirectory;
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    // Save the structure map information and create a new item to receive the
                    // date from this import
                    SobekCM_Item newItem = Create_New_Item_For_Import((new FileInfo(openFileDialog1.FileName)).DirectoryName);
                    MXF_File_ReaderWriter mxfReader = new MXF_File_ReaderWriter();
                    string read_errors = String.Empty;
                    mxfReader.Read_Metadata(openFileDialog1.FileName, newItem, null, out read_errors);

                    // Just a file, so open regularly
                    noMetsPanel.Hide();
                    tabControl1.Show();

                    metsFile = String.Empty;

                    // Build the template object, assign the item, and then display within this form
                    Load_And_Display_Template(newItem, true);

                    applyButton.Button_Enabled = true;

                }
                catch 
                {
                    MessageBox.Show("Error reading MXF source file.    ");
                }
            }
        }

        private void z3950ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to import a MARC record from Z39.50
            Z3950_Import_Form importForm = new Z3950_Import_Form();
            importForm.ShowDialog();

            // Get the MARC record
            MARC_Record record = importForm.Record;

            // If no record, skip this
            if ( record == null )
            {
                return;
            }

            try
            {
                // Save the structure map information and create a new item to receive the
                // date from this import
                SobekCM_Item newItem = Create_New_Item_For_Import(String.Empty);

                // Read the MARC item into the item
                MemoryStream stringReader = new MemoryStream(Encoding.UTF8.GetBytes(record.To_MARC_XML()));
                
                MarcXML_File_ReaderWriter marcReader = new MarcXML_File_ReaderWriter();
                string read_errors = String.Empty;
                marcReader.Read_Metadata(stringReader, newItem, null, out read_errors);

                // Just a file, so open regularly
                noMetsPanel.Hide();
                tabControl1.Show();

                metsFile = String.Empty;

                // Build the template object, assign the item, and then display within this form
                Load_And_Display_Template(newItem, true);

                applyButton.Button_Enabled = true;

            }
            catch ( Exception ee )
            {
                MessageBox.Show("Error reading MARC record from Z39.50.    ");
            }
        }

        #endregion

        #endregion

        #region Main menu bar VIEW menu item event handlers

        private void viewMetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (applyButton.Button_Enabled)
            {
                try
                {
                    // Make sure the TEMPORARY folder exsits
                    string documents_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string temp_folder = documents_folder + "\\METS Editor\\Temporary";
                    if (!Directory.Exists(temp_folder))
                        Directory.CreateDirectory(temp_folder);

                    // Create a bib package to create the METS
                    SobekCM_Item newBib = new SobekCM_Item();
                    if ((metsFile.Length > 0) && (File.Exists(metsFile)))
                    {
                        try
                        {
                            // Was this an existing METS?
                            newBib = SobekCM_Item.Read_METS(metsFile);
                        }
                        catch
                        {

                        }
                    }

                    // Set the VID, if there was none
                    if (newBib.VID.Length == 0)
                    {
                        newBib.VID = "00001";
                    }

                    // Prepare to save this new bib
                    thisTemplate.Prepare_For_Save(newBib);

                    // Save all the values from the template to this bib
                    thisTemplate.Save_To_Bib(newBib);

                    // Save the METS file to the temporary location
                    newBib.Source_Directory = temp_folder;
                    Save_Actual_METS_File(temp_folder + "\\temp.mets", newBib);

                    // Now, show this METS file
                    if (File.Exists(temp_folder + "\\temp.mets"))
                    {
                        try
                        {
                            Show_XML_Form show = new Show_XML_Form(temp_folder + "\\temp.mets", false);
                            show.ShowDialog();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Error while launching XML form.\n\nThis form may require Internet Explorer and full trust.\n\nPlease report this issue to programmer Mark Sullivan ( Mark.V.Sullivan@gmail.com ).           \n\nMessage: " + ee.Message, "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error saving recent changes to temporary file.\n\nViewed METS file may not include all your most recent changes.    ", "Error Saving Temporary File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch 
                {
                    MessageBox.Show("Error saving recent changes to temporary file.\n\nViewed METS file may not include all your most recent changes.    ", "Error Saving Temporary File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if ((metsFile.Length > 0) && (File.Exists(metsFile)))
                {
                    try
                    {
                        // Now, show this METS file
                        Show_XML_Form show = new Show_XML_Form(metsFile, false);
                        show.ShowDialog();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Error while launching XML form.\n\nThis form may require Internet Explorer and full trust.\n\nPlease report this issue to programmer Mark Sullivan ( Mark.V.Sullivan@gmail.com ).           \n\nMessage: " + ee.Message, "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must save this digital resource data before you can view it as a MARC record.    ");
                }
            }
        }

        private void mARCRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Create a bib package to create the METS
                SobekCM_Item newBib = new SobekCM_Item();
                if ((metsFile.Length > 0) && (File.Exists(metsFile)))
                {
                    try
                    {
                        // Was this an existing METS?
                        newBib = SobekCM_Item.Read_METS(metsFile);
                    }
                    catch
                    {

                    }
                }

                // Prepare to save this new bib
                thisTemplate.Prepare_For_Save(newBib);

                // Save all the values from the template to this bib
                thisTemplate.Save_To_Bib(newBib);

                Show_MARC_Form marcForm = new Show_MARC_Form(newBib);
                marcForm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error saving data to memory to create MARC record.");
            }
        }

        private void unanalyzedMETSSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((inprocessItem == null) || ((inprocessItem.Unanalyzed_AMDSEC_Count == 0) && (inprocessItem.Unanalyzed_DMDSEC_Count == 0)))
            {
                MessageBox.Show("This item does not have any unanalyzed dmdSec or amdSec portions in the source METS file.       ", "METS File Fully Analyzed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Show_Unanalyzed_METS_Sections showUnanalyzed = new Show_Unanalyzed_METS_Sections(inprocessItem);
                Hide();
                showUnanalyzed.ShowDialog();
                Show();
            }
        }

        #endregion

        #region Main menu bar OPTIONS menu item event handlers

        private void metadataPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the metadata preferences form
            Metadata_Preferences metadataPrefForm = new Metadata_Preferences( tabControl1.Visible );
            Hide();
            DialogResult results = metadataPrefForm.ShowDialog();

            if (metadataPrefForm.Project_File_To_Edit.Length > 0)
            {
                Open_Existing_METS_File(metadataPrefForm.Project_File_To_Edit);
            }
            else
            {
                if ((results == DialogResult.OK) && (!noMetsPanel.Visible))
                {
                    MessageBox.Show("Some changes will not be applied until you close the current item and re-open or recreate a new item within this template.", "Preferences Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            Show();
        }

        #region Automatic numbering menu item event handlers

        private void documentNumberingMI_Click(object sender, EventArgs e)
        {
            // Correct the checkmark location
            entireDocumentToolStripMenuItem.Checked = true;
            withingSameDivisionToolStripMenuItem.Checked = false;
            noAutomaticNumberingToolStripMenuItem.Checked = false;

            // Set the numberiong to be the whole document
            MetaTemplate_UserSettings.Automatic_Numbering = Automatic_Numbering_Enum.Document;
        }

        private void divisionNumberingMI_Click(object sender, EventArgs e)
        {
            // Correct the checkmark location
            entireDocumentToolStripMenuItem.Checked = false;
            withingSameDivisionToolStripMenuItem.Checked = true;
            noAutomaticNumberingToolStripMenuItem.Checked = false;

            // Set the numberiong to be the within a single division
            MetaTemplate_UserSettings.Automatic_Numbering = Automatic_Numbering_Enum.Division;
        }

        private void noNumberingMI_Click(object sender, EventArgs e)
        {
            // Correct the checkmark location
            entireDocumentToolStripMenuItem.Checked = false;
            withingSameDivisionToolStripMenuItem.Checked = false;
            noAutomaticNumberingToolStripMenuItem.Checked = true;

            // Set the numberiong to be the within a single division
            MetaTemplate_UserSettings.Automatic_Numbering = Automatic_Numbering_Enum.None;
        }

        #endregion

        #region Language Menu Item Event Handlers

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            englishToolStripMenuItem.Checked = true;
            frenchToolStripMenuItem.Checked = false;
            spanishToolStripMenuItem.Checked = false;

            // Set the template language
            if (thisTemplate != null)
            {
                thisTemplate.Set_Language(Template_Language.English);
                ReDraw();
            }

            // Set the overall language
            MetaTemplate_UserSettings.Last_Language = Template_Language.English;
            MessageProvider_Gateway.Set_Language(Template_Language.English);
            set_text_by_language();
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            englishToolStripMenuItem.Checked = false;
            frenchToolStripMenuItem.Checked = true;
            spanishToolStripMenuItem.Checked = false;

            // Set the template language
            if (thisTemplate != null)
            {
                thisTemplate.Set_Language(Template_Language.French);
                ReDraw();
            }

            // Set the overall language
            MetaTemplate_UserSettings.Last_Language = Template_Language.French;
            MessageProvider_Gateway.Set_Language(Template_Language.French);
            set_text_by_language();
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            englishToolStripMenuItem.Checked = false;
            frenchToolStripMenuItem.Checked = false;
            spanishToolStripMenuItem.Checked = true;

            // Set the template language
            if (thisTemplate != null)
            {
                thisTemplate.Set_Language(Template_Language.Spanish);
                ReDraw();
            }

            // Set the overall language
            MetaTemplate_UserSettings.Last_Language = Template_Language.Spanish;
            MessageProvider_Gateway.Set_Language(Template_Language.Spanish);
            set_text_by_language();
        }

        #endregion

        #region Font Size Menu Item Event Handlers

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            xLargeToolStripMenuItem.Checked = false;

            // Set the font size
            Font = new Font(Font.FontFamily, 8F);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
            xLargeToolStripMenuItem.Checked = false;

            // Set the font size
            Font = new Font(Font.FontFamily, 9F);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
            xLargeToolStripMenuItem.Checked = false;

            // Set the font size
            Font = new Font(Font.FontFamily, 10.5F);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void xLargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radio buttons correctly
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            xLargeToolStripMenuItem.Checked = true;

            // Set the font size
            Font = new Font(Font.FontFamily, 12F);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        #endregion

        #region Font Face Menu Item Event Handlers

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radion buttons correctly
            arialToolStripMenuItem.Checked = true;
            garamondToolStripMenuItem.Checked = false;
            tahomaToolStripMenuItem.Checked = false;
            timesRomanToolStripMenuItem.Checked = false;
            trebuchetToolStripMenuItem.Checked = false;

            // Set the font size

            Font = new Font("Arial", Font.SizeInPoints);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void garamondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radion buttons correctly
            arialToolStripMenuItem.Checked = false;
            garamondToolStripMenuItem.Checked = true;
            tahomaToolStripMenuItem.Checked = false;
            timesRomanToolStripMenuItem.Checked = false;
            trebuchetToolStripMenuItem.Checked = false;

            // Set the font size
            Font = new Font("Garamond", Font.SizeInPoints);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void tahomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radion buttons correctly
            arialToolStripMenuItem.Checked = false;
            garamondToolStripMenuItem.Checked = false;
            tahomaToolStripMenuItem.Checked = true;
            timesRomanToolStripMenuItem.Checked = false;
            trebuchetToolStripMenuItem.Checked = false;

            // Set the font size
            Font = new Font("Tahoma", Font.SizeInPoints);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        private void timesRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radion buttons correctly
            arialToolStripMenuItem.Checked = false;
            garamondToolStripMenuItem.Checked = false;
            tahomaToolStripMenuItem.Checked = false;
            timesRomanToolStripMenuItem.Checked = true;
            trebuchetToolStripMenuItem.Checked = false;

            // Save the new font
            MetaTemplate_UserSettings.Last_Font = Font;
            MetaTemplate_UserSettings.Save();

            // Redraw the form
            ReDraw();
        }

        private void trebuchetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the radion buttons correctly
            arialToolStripMenuItem.Checked = false;
            garamondToolStripMenuItem.Checked = false;
            tahomaToolStripMenuItem.Checked = false;
            timesRomanToolStripMenuItem.Checked = false;
            trebuchetToolStripMenuItem.Checked = true;

            // Set the font size

            Font = new Font("Trebuchet MS", Font.SizeInPoints);
            if (thisTemplate != null)
            {
                thisTemplate.Current_Font = Font;
            }

            // Redraw the form
            ReDraw();
        }

        #endregion

        #endregion

        #region Main menu bar HELP menu item event handlers

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About showAbout = new About(VersionConfigSettings.AppName, VersionConfigSettings.AppVersion);
            showAbout.ShowDialog();
        }

        private void onlineHelpMI_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process {StartInfo = {FileName = "http://ufdc.ufl.edu/metseditor"}};
                onlineHelp.Start();
            }
            catch
            {
                // Error caught, but no reason to really do anything here
                MessageBox.Show("Error displaying the main help file.");
            }
        }

        private void sobekCMHelpPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sobekHelpPagesToolStripMenuItem.Checked = true;
            noHelpToolStripMenuItem.Checked = false;
            MetaTemplate_UserSettings.Help_Provider = "SobekCM";
            MetaTemplate_UserSettings.Save();
            abstract_Element.Help_Provider = new SobekCM_HelpProvider();
            ReDraw();
        }

        private void noHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noHelpToolStripMenuItem.Checked = true;
            sobekHelpPagesToolStripMenuItem.Checked = false;
            MetaTemplate_UserSettings.Help_Provider = "NONE";
            MetaTemplate_UserSettings.Save();
            abstract_Element.Help_Provider = null;
            ReDraw();
        }

        #endregion

        #endregion

        #region Method to set the form text by language

        private void set_text_by_language()
        {
            string[] menuItems = MessageProvider_Gateway.Menu_Items;

            exitButton.Button_Text = MessageProvider_Gateway.Cancel.ToUpper();
            applyButton.Button_Text = MessageProvider_Gateway.Apply.ToUpper();
            saveButton.Button_Text = MessageProvider_Gateway.Exit.ToUpper();
            importFromMenuItem.Text = menuItems[23];
            csvOrExcelToolStripMenuItem.Text = menuItems[24];
            dublinCoreFileToolStripMenuItem.Text = menuItems[25];
            dublinCoreFileToolStripMenuItem1.Text = menuItems[25];
            eadToolStripMenuItem.Text = menuItems[26];
            marcXMLToolStripMenuItem.Text = menuItems[27];
            marcXMLToolStripMenuItem1.Text = menuItems[28];
            marcXMLFileToolStripMenuItem.Text = menuItems[28];
            marc21DataFileToolStripMenuItem.Text = menuItems[29];
            modsFileToolStripMenuItem.Text = menuItems[30];
            modsFileToolStripMenuItem1.Text = menuItems[30];
            mxfFileToolStripMenuItem.Text = menuItems[31];
            saveAsToolStripMenuItem.Text = menuItems[32];
            metadataPreferencesToolStripMenuItem.Text = menuItems[35];
            automaticNumberingToolStripMenuItem.Text = menuItems[36];
            noAutomaticNumberingToolStripMenuItem.Text = menuItems[37];
            withingSameDivisionToolStripMenuItem.Text = menuItems[38];
            entireDocumentToolStripMenuItem.Text = menuItems[39];
            onlineHelpToolStripMenuItem.Text = menuItems[40];
            metadataHelpSourceToolStripMenuItem.Text = menuItems[41];
            sobekHelpPagesToolStripMenuItem.Text = menuItems[42];
            noHelpToolStripMenuItem.Text = menuItems[43];
            actionToolStripMenuItem.Text = menuItems[0];
            newToolStripMenuItem.Text = menuItems[1];
            metsFileToolStripMenuItem2.Text = menuItems[20];
            openToolStripMenuItem.Text = menuItems[2];
            recentToolStripMenuItem.Text = menuItems[3];
            saveToolStripMenuItem.Text = menuItems[4];
            exitToolStripMenuItem.Text = menuItems[5];
            settingsToolStripMenuItem.Text = menuItems[6];
            languageToolStripMenuItem.Text = menuItems[7];
            englishToolStripMenuItem.Text = menuItems[8];
            frenchToolStripMenuItem.Text = menuItems[9];
            spanishToolStripMenuItem.Text = menuItems[10];
            fontFaceToolStripMenuItem.Text = menuItems[11];
            fontSizeToolStripMenuItem.Text = menuItems[12];
            smallToolStripMenuItem.Text = menuItems[13];
            mediumToolStripMenuItem.Text = menuItems[14];
            largeToolStripMenuItem.Text = menuItems[15];
            xLargeToolStripMenuItem.Text = menuItems[16];
            helpToolStripMenuItem.Text = menuItems[17];
            aboutToolStripMenuItem.Text = menuItems[18];
            viewToolStripMenuItem.Text = menuItems[19];
            metsFileToolStripMenuItem1.Text = menuItems[20];


            switch (MetaTemplate_UserSettings.Last_Language)
            {
                case Template_Language.Spanish:
                    appDescLabel.Text = "Este programa se usa para crear, editar y ver archivos METS para SobekCM.  \nEste programa es gratis y se puede utilizar en cualquier forma que sea \napropiado.\n\n¿Que quisiera hacer hoy?";
                    newMetsFileLinkLabel.Text = "Crear un nuevo archivo METS";
                    openMetsLinkLabel.Text = "Abrir un archivo METS, cual ya existe";
                    batchMetsCreateLinkLabel.Text = "Crear archivos METS por lotes";
                    onlineHelpLinkLabel.Text = "Ver ayuda en línea para este programa";
                    break;

                case Template_Language.French:
                    appDescLabel.Text = "Cette application est utilisée pour visualiser, modifier et créer des fichiers \nMETS pour SobekCM.  Ce logiciel est disponible gratuitement et \npeut être utilisé à des fins correspondantes.\n\nQue souhaitez-vous faire aujourd’hui?";
                    newMetsFileLinkLabel.Text = "Créer un nouveau fichier METS";
                    openMetsLinkLabel.Text = "Ouvrir un fichier METS existant";
                    batchMetsCreateLinkLabel.Text = "Effectuer un chargement par lot";
                    onlineHelpLinkLabel.Text = "Voir l'aide en ligne pour cette application";
                    break;

                default:
                    appDescLabel.Text = "This application is used for viewing, editing, and creating METS files for \nSobekCM.  This software is freely available and can be used for any \nother purpose for which it seems applicable.\n\nWhat would you like to today?";
                    newMetsFileLinkLabel.Text = "Create new METS file";
                    openMetsLinkLabel.Text = "Open existing METS file";
                    batchMetsCreateLinkLabel.Text = "Batch METS file creation";
                    onlineHelpLinkLabel.Text = "View online help for this application";
                    break;
            }
        }

        #endregion

        #region Method to update the recents menu items

        private void update_recents()
        {
            recentToolStripMenuItem.DropDownItems.Clear();
            string[] recents = MetaTemplate_UserSettings.Recents;
            if (recents[0].Length > 0)
            {
                ToolStripMenuItem recent0 = new ToolStripMenuItem(recents[0].Replace("&amp;", "&").Replace("&", "&&"));
                recent0.Click += recent_Click;
                recentToolStripMenuItem.DropDownItems.Add(recent0);
            }

            if (recents[1].Length > 0)
            {
                ToolStripMenuItem recent1 = new ToolStripMenuItem(recents[1].Replace("&amp;", "&").Replace("&", "&&"));
                recent1.Click += recent_Click;
                recentToolStripMenuItem.DropDownItems.Add(recent1);
            }

            if (recents[2].Length > 0)
            {
                ToolStripMenuItem recent2 = new ToolStripMenuItem(recents[2].Replace("&amp;", "&").Replace("&", "&&"));
                recent2.Click += recent_Click;
                recentToolStripMenuItem.DropDownItems.Add(recent2);
            }

            if (recents[3].Length > 0)
            {
                ToolStripMenuItem recent3 = new ToolStripMenuItem(recents[3].Replace("&amp;", "&").Replace("&", "&&"));
                recent3.Click += recent_Click;
                recentToolStripMenuItem.DropDownItems.Add(recent3);
            }

            if (recents[4].Length > 0)
            {
                ToolStripMenuItem recent4 = new ToolStripMenuItem(recents[4].Replace("&amp;", "&").Replace("&", "&&"));
                recent4.Click += recent_Click;
                recentToolStripMenuItem.DropDownItems.Add(recent4);
            }
        }

        #endregion

        private void batchImportOaiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Enter_OAI_Repository_URL_Form getURL = new Enter_OAI_Repository_URL_Form();
            Hide();
            DialogResult result = getURL.ShowDialog();

            if (result == DialogResult.OK)
            {
                OAI_Repository_Information repositoryInfo = getURL.Repository_Information;

                OAI_PMH_Record_Import_Form importForm = new OAI_PMH_Record_Import_Form(repositoryInfo);
                importForm.ShowDialog();

            }

            Show();
        }

        private void z3950EndpointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Z3950_Endpoint_Admin_Form adminForm = new Z3950_Endpoint_Admin_Form();
            Hide();
            adminForm.ShowDialog();
            Show();
        }
    }
}