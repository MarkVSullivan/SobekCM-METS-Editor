namespace SobekCM.METS_Editor.BatchImport
{
    partial class SpreadSheet_Importer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpreadSheet_Importer_Form));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sheetComboBox = new System.Windows.Forms.ComboBox();
            this.sheetLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnShowData = new System.Windows.Forms.Button();
            this.step1Label = new System.Windows.Forms.Label();
            this.step2Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.step3Label = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.columnNamePanel = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlConstants = new System.Windows.Forms.Panel();
            this.step5Label = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browse2Button = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.step4Label = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.executeButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 633);
            this.progressBar1.Maximum = 4;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(560, 13);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // sheetComboBox
            // 
            this.sheetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheetComboBox.Enabled = false;
            this.sheetComboBox.Location = new System.Drawing.Point(84, 84);
            this.sheetComboBox.Name = "sheetComboBox";
            this.sheetComboBox.Size = new System.Drawing.Size(160, 21);
            this.sheetComboBox.TabIndex = 2;
            this.sheetComboBox.SelectedIndexChanged += new System.EventHandler(this.sheetComboBox_SelectedIndexChanged);
            // 
            // sheetLabel
            // 
            this.sheetLabel.BackColor = System.Drawing.Color.Transparent;
            this.sheetLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetLabel.Location = new System.Drawing.Point(25, 82);
            this.sheetLabel.Name = "sheetLabel";
            this.sheetLabel.Size = new System.Drawing.Size(53, 23);
            this.sheetLabel.TabIndex = 18;
            this.sheetLabel.Text = "Sheet:";
            this.sheetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(476, 34);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 24);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "SELECT";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTextBox.BackColor = System.Drawing.Color.White;
            this.fileTextBox.Location = new System.Drawing.Point(63, 34);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(403, 20);
            this.fileTextBox.TabIndex = 1;
            this.fileTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.directoryTextBox_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel files|*.xls;*.xlsx|CSV files|*.csv";
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(264, 84);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 4;
            this.btnShowData.Text = "Show Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Visible = false;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // step1Label
            // 
            this.step1Label.BackColor = System.Drawing.Color.Transparent;
            this.step1Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step1Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step1Label.Location = new System.Drawing.Point(3, 9);
            this.step1Label.Name = "step1Label";
            this.step1Label.Size = new System.Drawing.Size(568, 22);
            this.step1Label.TabIndex = 25;
            this.step1Label.Text = "Step 1: Select the source data file to import an Excel spreadsheet.";
            // 
            // step2Label
            // 
            this.step2Label.AutoSize = true;
            this.step2Label.BackColor = System.Drawing.Color.Transparent;
            this.step2Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step2Label.Location = new System.Drawing.Point(5, 63);
            this.step2Label.Name = "step2Label";
            this.step2Label.Size = new System.Drawing.Size(373, 18);
            this.step2Label.TabIndex = 26;
            this.step2Label.Text = "Step 2: Select worksheet from the dropdown list.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.step3Label);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(3, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 338);
            this.panel1.TabIndex = 27;
            // 
            // step3Label
            // 
            this.step3Label.BackColor = System.Drawing.Color.Transparent;
            this.step3Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step3Label.Location = new System.Drawing.Point(1, 9);
            this.step3Label.Name = "step3Label";
            this.step3Label.Size = new System.Drawing.Size(543, 21);
            this.step3Label.TabIndex = 28;
            this.step3Label.Text = "Step 3: Select column mappings and constants";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 300);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage1.Controls.Add(this.columnNamePanel);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mappings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // columnNamePanel
            // 
            this.columnNamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.columnNamePanel.AutoScroll = true;
            this.columnNamePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.columnNamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.columnNamePanel.Location = new System.Drawing.Point(6, 6);
            this.columnNamePanel.Name = "columnNamePanel";
            this.columnNamePanel.Size = new System.Drawing.Size(532, 262);
            this.columnNamePanel.TabIndex = 24;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage2.Controls.Add(this.pnlConstants);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 273);
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
            this.pnlConstants.Size = new System.Drawing.Size(529, 301);
            this.pnlConstants.TabIndex = 0;
            // 
            // step5Label
            // 
            this.step5Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.step5Label.BackColor = System.Drawing.Color.Transparent;
            this.step5Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step5Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step5Label.Location = new System.Drawing.Point(4, 513);
            this.step5Label.Name = "step5Label";
            this.step5Label.Size = new System.Drawing.Size(564, 33);
            this.step5Label.TabIndex = 29;
            this.step5Label.Text = "Step 5: Click the Execute button";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(29, 612);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(372, 23);
            this.labelStatus.TabIndex = 29;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.folderTextBox);
            this.mainPanel.Controls.Add(this.browse2Button);
            this.mainPanel.Controls.Add(this.folderLabel);
            this.mainPanel.Controls.Add(this.step4Label);
            this.mainPanel.Controls.Add(this.step1Label);
            this.mainPanel.Controls.Add(this.step5Label);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.fileTextBox);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.browseButton);
            this.mainPanel.Controls.Add(this.sheetLabel);
            this.mainPanel.Controls.Add(this.step2Label);
            this.mainPanel.Controls.Add(this.sheetComboBox);
            this.mainPanel.Controls.Add(this.btnShowData);
            this.mainPanel.Location = new System.Drawing.Point(12, 48);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(568, 546);
            this.mainPanel.TabIndex = 30;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Enabled = false;
            this.folderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderTextBox.Location = new System.Drawing.Point(102, 483);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(364, 20);
            this.folderTextBox.TabIndex = 59;
            this.folderTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.folderTextBox_MouseDown);
            // 
            // browse2Button
            // 
            this.browse2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browse2Button.Enabled = false;
            this.browse2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse2Button.Location = new System.Drawing.Point(476, 481);
            this.browse2Button.Name = "browse2Button";
            this.browse2Button.Size = new System.Drawing.Size(75, 24);
            this.browse2Button.TabIndex = 58;
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
            this.folderLabel.Location = new System.Drawing.Point(21, 481);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(93, 23);
            this.folderLabel.TabIndex = 60;
            this.folderLabel.Text = "Destination:";
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // step4Label
            // 
            this.step4Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.step4Label.BackColor = System.Drawing.Color.Transparent;
            this.step4Label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4Label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.step4Label.Location = new System.Drawing.Point(4, 456);
            this.step4Label.Name = "step4Label";
            this.step4Label.Size = new System.Drawing.Size(544, 29);
            this.step4Label.TabIndex = 57;
            this.step4Label.Text = "Step 4: Select destination folder for METS files";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select destination folder for METS files";
            // 
            // executeButton
            // 
            this.executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executeButton.BackColor = System.Drawing.Color.Transparent;
            this.executeButton.Button_Enabled = true;
            this.executeButton.Button_Text = "EXECUTE";
            this.executeButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.executeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.Location = new System.Drawing.Point(464, 601);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(100, 26);
            this.executeButton.TabIndex = 32;
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
            this.cancelButton.Location = new System.Drawing.Point(349, 601);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 26);
            this.cancelButton.TabIndex = 30;
            this.cancelButton.Button_Pressed += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(557, 10);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 47;
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
            this.titleLabel.Location = new System.Drawing.Point(26, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(519, 42);
            this.titleLabel.TabIndex = 46;
            this.titleLabel.Text = "Spreadsheet Batch Processor";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpreadSheet_Importer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(590, 658);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.labelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 696);
            this.MinimumSize = new System.Drawing.Size(606, 696);
            this.Name = "SpreadSheet_Importer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METS Editor - SpreadSheet Batch Processor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox sheetComboBox;
        private System.Windows.Forms.Label sheetLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.Label step1Label;
        private System.Windows.Forms.Label step2Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel columnNamePanel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlConstants;
        private System.Windows.Forms.Label step3Label;
        private System.Windows.Forms.Label step5Label;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel mainPanel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button executeButton;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button browse2Button;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.Label step4Label;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label titleLabel;
    }
}