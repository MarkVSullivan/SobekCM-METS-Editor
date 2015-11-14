namespace SobekCM.METS_Editor.OAI
{
    partial class OAI_PMH_Record_Import_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OAI_PMH_Record_Import_Form));
            this.labelStatus = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.step4Label = new System.Windows.Forms.Label();
            this.folderLabel = new System.Windows.Forms.Label();
            this.setLabel = new System.Windows.Forms.Label();
            this.setComboBox = new System.Windows.Forms.ComboBox();
            this.step3Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlConstants = new System.Windows.Forms.Panel();
            this.step2Label = new System.Windows.Forms.Label();
            this.step1Label = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.executeButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(26, 557);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(372, 23);
            this.labelStatus.TabIndex = 45;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.folderTextBox);
            this.mainPanel.Controls.Add(this.browseButton);
            this.mainPanel.Controls.Add(this.step4Label);
            this.mainPanel.Controls.Add(this.folderLabel);
            this.mainPanel.Controls.Add(this.setLabel);
            this.mainPanel.Controls.Add(this.setComboBox);
            this.mainPanel.Controls.Add(this.step3Label);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.step1Label);
            this.mainPanel.Location = new System.Drawing.Point(12, 66);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(582, 479);
            this.mainPanel.TabIndex = 46;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Enabled = false;
            this.folderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderTextBox.Location = new System.Drawing.Point(105, 419);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(380, 20);
            this.folderTextBox.TabIndex = 51;
            this.folderTextBox.TextChanged += new System.EventHandler(this.folderTextBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Enabled = false;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(491, 416);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 24);
            this.browseButton.TabIndex = 50;
            this.browseButton.Text = "SELECT";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // step4Label
            // 
            this.step4Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step4Label.BackColor = System.Drawing.Color.Transparent;
            this.step4Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step4Label.Location = new System.Drawing.Point(7, 450);
            this.step4Label.Name = "step4Label";
            this.step4Label.Size = new System.Drawing.Size(544, 32);
            this.step4Label.TabIndex = 41;
            this.step4Label.Text = "Step 4: Click the Execute button";
            // 
            // folderLabel
            // 
            this.folderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.folderLabel.BackColor = System.Drawing.Color.Transparent;
            this.folderLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.folderLabel.Location = new System.Drawing.Point(24, 417);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(93, 23);
            this.folderLabel.TabIndex = 52;
            this.folderLabel.Text = "Destination:";
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setLabel
            // 
            this.setLabel.AutoSize = true;
            this.setLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setLabel.Location = new System.Drawing.Point(27, 34);
            this.setLabel.Name = "setLabel";
            this.setLabel.Size = new System.Drawing.Size(32, 14);
            this.setLabel.TabIndex = 40;
            this.setLabel.Text = "Set:";
            // 
            // setComboBox
            // 
            this.setComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.setComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setComboBox.FormattingEnabled = true;
            this.setComboBox.Items.AddRange(new object[] {
            "* ( All records in repository )"});
            this.setComboBox.Location = new System.Drawing.Point(65, 31);
            this.setComboBox.Name = "setComboBox";
            this.setComboBox.Size = new System.Drawing.Size(486, 22);
            this.setComboBox.TabIndex = 39;
            this.setComboBox.SelectedIndexChanged += new System.EventHandler(this.setComboBox_SelectedIndexChanged);
            // 
            // step3Label
            // 
            this.step3Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step3Label.BackColor = System.Drawing.Color.Transparent;
            this.step3Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step3Label.Location = new System.Drawing.Point(7, 395);
            this.step3Label.Name = "step3Label";
            this.step3Label.Size = new System.Drawing.Size(544, 29);
            this.step3Label.TabIndex = 38;
            this.step3Label.Text = "Step 3: Select destination folder for METS files";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.step2Label);
            this.panel1.Location = new System.Drawing.Point(3, 55);
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
            this.step1Label.Text = "Step 1: Select the OAI-PMH set to import.";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(27, 583);
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(541, 13);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 44;
            this.progressBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repositoryDetailsToolStripMenuItem1});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // repositoryDetailsToolStripMenuItem1
            // 
            this.repositoryDetailsToolStripMenuItem1.Name = "repositoryDetailsToolStripMenuItem1";
            this.repositoryDetailsToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.repositoryDetailsToolStripMenuItem1.Text = "Repository Details";
            this.repositoryDetailsToolStripMenuItem1.Click += new System.EventHandler(this.repositoryDetailsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repositoryDetailsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // repositoryDetailsToolStripMenuItem
            // 
            this.repositoryDetailsToolStripMenuItem.Name = "repositoryDetailsToolStripMenuItem";
            this.repositoryDetailsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.repositoryDetailsToolStripMenuItem.Text = "Repository Details";
            this.repositoryDetailsToolStripMenuItem.Click += new System.EventHandler(this.repositoryDetailsToolStripMenuItem_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select destination folder for METS files";
            // 
            // executeButton
            // 
            this.executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executeButton.BackColor = System.Drawing.Color.Transparent;
            this.executeButton.Button_Enabled = false;
            this.executeButton.Button_Text = "EXECUTE";
            this.executeButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.executeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.Location = new System.Drawing.Point(494, 547);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(100, 26);
            this.executeButton.TabIndex = 48;
            this.executeButton.Button_Pressed += new System.EventHandler(this.executeButton_Button_Pressed);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(379, 547);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 26);
            this.cancelButton.TabIndex = 47;
            this.cancelButton.Button_Pressed += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(566, 34);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 54;
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
            this.titleLabel.Location = new System.Drawing.Point(33, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(527, 42);
            this.titleLabel.TabIndex = 53;
            this.titleLabel.Text = "OAI-PMH Batch Processor";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OAI_PMH_Record_Import_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(606, 608);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1000, 646);
            this.MinimumSize = new System.Drawing.Size(622, 646);
            this.Name = "OAI_PMH_Record_Import_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METS Editor - OAI-PMH Batch Processor";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button executeButton;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label step3Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlConstants;
        private System.Windows.Forms.Label step2Label;
        private System.Windows.Forms.Label step1Label;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox setComboBox;
        private System.Windows.Forms.Label setLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repositoryDetailsToolStripMenuItem;
        private System.Windows.Forms.Label step4Label;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem repositoryDetailsToolStripMenuItem1;
    }
}