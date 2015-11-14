#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DLC.Tools;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.Forms;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
	/// <summary> Form allows the user to set the source and destination
	/// files for this process.  <br /> <br /> </summary>
	/// <remarks> Written by Mark Sullivan (2005) </remarks>
	/// <example> <img src="Source_Setup_Form2.jpg" /> </example>
	public class MARC_Importer_Form : Form
	{
		#region Form-Related Private Class Members

        private OpenFileDialog openFileDialog1;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Label step2Label;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Panel pnlConstants;
        private Label step1Label;
        private Button browseButton;
        private TextBox sourceTextBox;
        private Label label3;
        private Label labelStatus;
        private Panel mainPanel;
        private Label step4Label;

		#endregion

        private IContainer components;

		/// <summary> Thread in which the processor runs </summary>
		protected Thread processThread;

		/// <summary> Processor object which actually parses the input file and
		/// gets the data for each item. </summary>
        protected MARC_Importer_Processor processor;

        private List<Column_Assignment_Control> column_map_inputs;
        private List<Constant_Assignment_Control> constant_map_inputs;

        private short user_specified_copyright_permissions;
        private Round_Button executeButton;
        private Round_Button cancelButton;
        private string workingFolder;
        private TextBox folderTextBox;
        private Button browse2Button;
        private Label folderLabel;
        private Label step3Label;
        private FolderBrowserDialog folderBrowserDialog1;
        private PictureBox helpPictureBox;
        private ToolTip toolTip1;
        private Label titleLabel;

        private string tickler;


		/// <summary> Constructor for a new instance of this class </summary>
		public MARC_Importer_Form()
		{
			// Initialize this form 
			InitializeComponent();

            Constructor_Helper();

            workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SMaRT";

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                browseButton.FlatStyle = FlatStyle.Flat;
                sourceTextBox.BorderStyle = BorderStyle.FixedSingle;
            }

            // Create the constants mapping custom control
            // Add eight constant user controls to panel
            for (int i = 1; i < 9; i++)
            {
                Constant_Assignment_Control thisConstantCtrl = new Constant_Assignment_Control();
                thisConstantCtrl.Location = new Point(10, 10 + ((i - 1) * 30));
                pnlConstants.Controls.Add(thisConstantCtrl);
                constant_map_inputs.Add(thisConstantCtrl);
            }

            // set some of the constant columns to required tracking fields
            constant_map_inputs[0].Mapped_Name = "First BibID";
            constant_map_inputs[1].Mapped_Name = "Material Type";
            constant_map_inputs[2].Mapped_Name = "Aggregation Code"; 
		}

        private void Constructor_Helper()
        {
            CheckForIllegalCrossThreadCalls = false;
            tickler = String.Empty;

            column_map_inputs = new List<Column_Assignment_Control>();
            constant_map_inputs = new List<Constant_Assignment_Control>();

            ResetFormControls();

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                browseButton.FlatStyle = FlatStyle.Flat;
                sourceTextBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MARC_Importer_Form));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlConstants = new System.Windows.Forms.Panel();
            this.step2Label = new System.Windows.Forms.Label();
            this.step1Label = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.step4Label = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browse2Button = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.step3Label = new System.Windows.Forms.Label();
            this.executeButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "MARC Source File";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(27, 568);
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(541, 13);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.step2Label);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 335);
            this.panel1.TabIndex = 29;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(13, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 300);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage2.Controls.Add(this.pnlConstants);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Constants";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlConstants
            // 
            this.pnlConstants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConstants.AutoScroll = true;
            this.pnlConstants.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlConstants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConstants.Location = new System.Drawing.Point(6, 6);
            this.pnlConstants.Name = "pnlConstants";
            this.pnlConstants.Size = new System.Drawing.Size(532, 262);
            this.pnlConstants.TabIndex = 0;
            // 
            // step2Label
            // 
            this.step2Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step2Label.Location = new System.Drawing.Point(4, 8);
            this.step2Label.Name = "step2Label";
            this.step2Label.Size = new System.Drawing.Size(544, 21);
            this.step2Label.TabIndex = 28;
            this.step2Label.Text = "Step 2: Select constants to apply to resulting METS files";
            // 
            // step1Label
            // 
            this.step1Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step1Label.BackColor = System.Drawing.Color.Transparent;
            this.step1Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step1Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step1Label.Location = new System.Drawing.Point(7, 4);
            this.step1Label.Name = "step1Label";
            this.step1Label.Size = new System.Drawing.Size(574, 23);
            this.step1Label.TabIndex = 8;
            this.step1Label.Text = "Step 1: Select the source data file to import MARC files.";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(491, 30);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 24);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "SELECT";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.Location = new System.Drawing.Point(69, 32);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(416, 20);
            this.sourceTextBox.TabIndex = 1;
            this.sourceTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.directoryTextBox_MouseDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "File:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(26, 535);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(372, 23);
            this.labelStatus.TabIndex = 37;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // step4Label
            // 
            this.step4Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step4Label.BackColor = System.Drawing.Color.Transparent;
            this.step4Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step4Label.Location = new System.Drawing.Point(7, 448);
            this.step4Label.Name = "step4Label";
            this.step4Label.Size = new System.Drawing.Size(544, 29);
            this.step4Label.TabIndex = 38;
            this.step4Label.Text = "Step 4: Click the Execute button";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.folderTextBox);
            this.mainPanel.Controls.Add(this.browse2Button);
            this.mainPanel.Controls.Add(this.browseButton);
            this.mainPanel.Controls.Add(this.folderLabel);
            this.mainPanel.Controls.Add(this.step3Label);
            this.mainPanel.Controls.Add(this.sourceTextBox);
            this.mainPanel.Controls.Add(this.step4Label);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.step1Label);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Location = new System.Drawing.Point(12, 48);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(582, 478);
            this.mainPanel.TabIndex = 39;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Enabled = false;
            this.folderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderTextBox.Location = new System.Drawing.Point(105, 421);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(380, 20);
            this.folderTextBox.TabIndex = 55;
            // 
            // browse2Button
            // 
            this.browse2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browse2Button.Enabled = false;
            this.browse2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse2Button.Location = new System.Drawing.Point(491, 419);
            this.browse2Button.Name = "browse2Button";
            this.browse2Button.Size = new System.Drawing.Size(75, 24);
            this.browse2Button.TabIndex = 54;
            this.browse2Button.Text = "SELECT";
            this.browse2Button.UseVisualStyleBackColor = true;
            this.browse2Button.Click += new System.EventHandler(this.browse2Button_Click);
            // 
            // folderLabel
            // 
            this.folderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.folderLabel.BackColor = System.Drawing.Color.Transparent;
            this.folderLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.folderLabel.Location = new System.Drawing.Point(24, 419);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(93, 23);
            this.folderLabel.TabIndex = 56;
            this.folderLabel.Text = "Destination:";
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // step3Label
            // 
            this.step3Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step3Label.BackColor = System.Drawing.Color.Transparent;
            this.step3Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step3Label.Location = new System.Drawing.Point(7, 394);
            this.step3Label.Name = "step3Label";
            this.step3Label.Size = new System.Drawing.Size(544, 29);
            this.step3Label.TabIndex = 53;
            this.step3Label.Text = "Step 3: Select destination folder for METS files";
            // 
            // executeButton
            // 
            this.executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executeButton.BackColor = System.Drawing.Color.Transparent;
            this.executeButton.Button_Enabled = true;
            this.executeButton.Button_Text = "EXECUTE";
            this.executeButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.executeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.Location = new System.Drawing.Point(494, 532);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(100, 26);
            this.executeButton.TabIndex = 43;
            this.executeButton.Button_Pressed += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(379, 532);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 26);
            this.cancelButton.TabIndex = 42;
            this.cancelButton.Button_Pressed += new System.EventHandler(this.cancelButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select destination folder for METS files";
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(570, 12);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 45;
            this.helpPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.helpPictureBox, "Get online help regarding this function");
            this.helpPictureBox.Click += new System.EventHandler(this.helpPictureBox_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleLabel.Location = new System.Drawing.Point(39, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(519, 42);
            this.titleLabel.TabIndex = 44;
            this.titleLabel.Text = "MARC21 Batch Processor";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MARC_Importer_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(606, 592);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 630);
            this.MinimumSize = new System.Drawing.Size(622, 630);
            this.Name = "MARC_Importer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METS Editor - MARC21 Batch Processor";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Form-Related Event Handlers
      
		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			Browse_Source();
		}

		private void sourceMenuItem_Click(object sender, EventArgs e)
		{
			Browse_Source();
		}

        private void directoryTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            Browse_Source();
        }

		private void okButton_Click(object sender, EventArgs e)
		{        
			Import_Records();
		}

		private void importMenuItem_Click(object sender, EventArgs e)
		{
			Import_Records();
		}


		private void instructionMenuItem_Click(object sender, EventArgs e)
		{
			Process showInstructions = new Process();
			showInstructions.StartInfo.FileName = Application.StartupPath + "\\Instructions.htm";
			showInstructions.Start();
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

		#endregion

        /// <summary> Last tickler assigned through the form, during an import </summary>
        public string Last_Tickler
        {
            get
            {
                return tickler;
            }
        }

		/// <summary> Imports the records from the indicated source file </summary>
		protected void Import_Records()
		{
            // Step through each constant map control
            Constant_Fields constantCollection = new Constant_Fields();
            string first_bibid = String.Empty;

            foreach (Constant_Assignment_Control thisConstant in constant_map_inputs)
            {
                if (thisConstant.Mapped_Name == "First BibID")
                {
                    first_bibid = thisConstant.Mapped_Constant;
                }
                else
                {
                    constantCollection.Add(thisConstant.Mapped_Field, thisConstant.Mapped_Constant);
                }
            }

            // validate the form     
            if ((folderTextBox.Text.Trim().Length == 0) || (!Directory.Exists(folderTextBox.Text.Trim())))
            {
                MessageBox.Show("Enter a valid destination folder.   ", "Invalid Destination Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (first_bibid.Length < 3)
            {
                MessageBox.Show("You must enter a constant for the 'First BibID' value and it must begin with two letters.   \n\nThis is the first ObjectID that will be used for the resulting METS files.      ", "Choose First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (first_bibid.Length > 10)
            {
                MessageBox.Show("The complete BibID/ObjectID cannot be longer than 10 digits.      ", "Invalid First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pad the bibid to 10 digits, in case it is not 10
            first_bibid = first_bibid.PadRight(10, '0');

            // First two must be characters
            if ((!Char.IsLetter(first_bibid[0])) || (!Char.IsLetter(first_bibid[1])))
            {
                MessageBox.Show("You must enter a constant for the 'First BibID' value and it must begin with two letters.   \n\nThis is the first ObjectID that will be used for the resulting METS files.      ", "Choose First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check that it ends in numbers
            if ((!Char.IsNumber(first_bibid[9])) || (!Char.IsNumber(first_bibid[8])) || (!Char.IsNumber(first_bibid[7])) || (!Char.IsNumber(first_bibid[6])))
            {
                MessageBox.Show("The last four digits of the BibID must be numeric.    \n\nTry shortening the length or changing trailing characters to numers.      ", "Invalid First BibID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Try to break the first_bibid up into character portion and number portion
            int numbers_start = 9;
            for (int i = 9; i >= 0; i--)
            {
                if (!Char.IsNumber(first_bibid[i]))
                {
                    numbers_start = i + 1;
                    break;
                }
            }
            string bibid_start = first_bibid.Substring(0, numbers_start);
            int first_bibid_int = Convert.ToInt32(first_bibid.Substring(numbers_start));

            // disable some of the form controls
            Disable_FormControls();

            // Show the progress bar
            progressBar1.Visible = true;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;           

            // reset the status label
            labelStatus.Text = "";

            try
            {
                // Create the Processor and assign the Delegate method for event processing.
                processor = new MARC_Importer_Processor(sourceTextBox.Text, constantCollection, folderTextBox.Text, bibid_start, first_bibid_int);
                processor.New_Progress += processor_New_Progress;
                processor.Complete += processor_Complete;

                // Create the thread to do the processing work, and start it.                        
                processThread = new Thread(processor.Do_Work);
                processThread.SetApartmentState(ApartmentState.STA);    
                processThread.Start();
            }
            catch (Exception e)
            {
                // display the error message
                ErrorMessageBox.Show("Error encountered while processing!\n\n" + e.Message, "DLC Importer Error", e);
                     
                // enable form controls on the Importer form                    
                Enable_FormControls();

                Cursor = Cursors.Default;
                progressBar1.Value = progressBar1.Minimum;
            }      
		}

        void processor_Complete(int New_Progress)
        {
            // set the Cursor and ProgressBar back to default values.
            Cursor = Cursors.Default;
            progressBar1.Value = progressBar1.Minimum;

            // enable the form controls
            Enable_FormControls();

            // Only continue if there are records already
            if (processor.Report_Data.Rows.Count == 0)
            {
                MessageBox.Show("No imported records!    ", "Batch Importer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Create a table to display the results
                DataTable displayTbl = processor.Report_Data.Copy();

                // create the Results form
                Results_Form showResults = new Results_Form(processor.Report_Data, processor.Importer_Type, false);

                // hide the Importer form
                Hide();

                // show the Results form
                showResults.ShowDialog();

                // show the Importer form
                ShowDialog();
            }    
        }

        void processor_New_Progress(int New_Progress)
        {
            // Just increment the progress bar
            if (progressBar1.Value + 1 > progressBar1.Maximum)
                progressBar1.Value = 0;
            else
                progressBar1.Value = progressBar1.Value + 1;

            // update status label
            labelStatus.Text = "Processed " + New_Progress.ToString("#,##0;") + " records";                
        }

		/// <summary> Browse to the source file to import </summary>
		protected void Browse_Source()
		{
            // reset the status label
            labelStatus.Text = "";
            openFileDialog1.Title = "";
            openFileDialog1.Filter = "";

			// Launch the open file dialog
			if ( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				// Save this file name
				sourceTextBox.Text = openFileDialog1.FileName;

				// Determine the output file
				FileInfo inputInfo = new FileInfo( sourceTextBox.Text );

				// Enable the ok button
				executeButton.Button_Enabled = true;

                // show step 2 instructions
                show_step_2();      
			}
			else
			{
				// Clear the current file
				sourceTextBox.Clear();
                executeButton.Button_Enabled = false;

                // show step 1 instructions
                show_step_1();  
			}
		}      

        #region Private Methods

        private void ResetFormControls()
        {           
            // set volume copyright permissions to default setting of 'public domain'
            user_specified_copyright_permissions = -1;

            // reset the status label
            labelStatus.Text = "";

            // show step 1 instructions
            show_step_1();  
        }

        private void Disable_FormControls()
        {
            // Disable the OK button and the related Menu Item
            executeButton.Button_Enabled = false;

            // Disable Tab Panel
            pnlConstants.Enabled = false;

            // Disable the Exit button and the related Menu Item
            cancelButton.Enabled = false;

            // Disable the Browse button and the related Menu Item
            browseButton.Enabled = false;
            browse2Button.Enabled = false;
            sourceTextBox.Enabled = false;
        }

        private void Enable_FormControls()
        {
            // Enable the OK button and the related Menu Item
            executeButton.Button_Enabled = true;

            // Enable Tab Panel
            pnlConstants.Enabled = true;

            // Enable the Exit button and the related Menu Item
            cancelButton.Enabled = true;

            // Enable the Browse button and the related Menu Item
            browseButton.Enabled = true;
            browse2Button.Enabled = true;
            sourceTextBox.Enabled = true;
        }

        private void show_step_1()
        {
            // show Step 1 instructions
            step1Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step2Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step3Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step4Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);

            browse2Button.Enabled = false;
            folderTextBox.Enabled = false;
            folderLabel.ForeColor = SystemColors.GrayText;
        }

        private void show_step_2()
        {
            // show Step 2 instructions          
            step1Label.ForeColor = ControlPaint.LightLight(SystemColors.ActiveCaption);
            step2Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step3Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);
            step4Label.ForeColor = ControlPaint.Dark(SystemColors.ActiveCaption);

            browse2Button.Enabled = true;
            folderTextBox.Enabled = true;
            folderLabel.ForeColor = SystemColors.WindowText;
        }
        #endregion   
        
        public void Show_Form()
        {
            // show the MARC Importer form
            if (this != null)
                ShowDialog();
        }

        private void browse2Button_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Process onlineHelp = new Process();
                onlineHelp.StartInfo.FileName = "http://ufdc.ufl.edu/metseditor/batch/marc21";
                onlineHelp.Start();
            }
            catch
            {

            }
        }
    }
}
