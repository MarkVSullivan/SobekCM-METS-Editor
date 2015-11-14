namespace SobekCM.METS_Editor.BatchImport
{
    partial class Batch_Import_Directory_Traverse_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batch_Import_Directory_Traverse_Form));
            this.label2 = new System.Windows.Forms.Label();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectIdFolderNameRadioButton = new System.Windows.Forms.RadioButton();
            this.firstBibIdTextBox = new System.Windows.Forms.TextBox();
            this.objectIdNewRadioButton = new System.Windows.Forms.RadioButton();
            this.objectIdFileNameRadioButton = new System.Windows.Forms.RadioButton();
            this.objectIdSourceLabel = new System.Windows.Forms.Label();
            this.overallProgressBar = new System.Windows.Forms.ProgressBar();
            this.folderLabel = new System.Windows.Forms.Label();
            this.overallProgressLabel = new System.Windows.Forms.Label();
            this.staticFolderLabel = new System.Windows.Forms.Label();
            this.metadataFilterComboBox = new System.Windows.Forms.ComboBox();
            this.fileFilterLabel = new System.Windows.Forms.Label();
            this.metadataComboBox = new System.Windows.Forms.ComboBox();
            this.metadataTypeLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.parentDirLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parentDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(608, 42);
            this.label2.TabIndex = 16;
            this.label2.Text = "Batch Import Directory Recursion";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "BACK";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(367, 322);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 15;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.Button_Enabled = true;
            this.continueButton.Button_Text = "CONTINUE";
            this.continueButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.continueButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(500, 322);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 14;
            this.continueButton.Button_Pressed += new System.EventHandler(this.continueButton_Button_Pressed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.objectIdFolderNameRadioButton);
            this.panel1.Controls.Add(this.firstBibIdTextBox);
            this.panel1.Controls.Add(this.objectIdNewRadioButton);
            this.panel1.Controls.Add(this.objectIdFileNameRadioButton);
            this.panel1.Controls.Add(this.objectIdSourceLabel);
            this.panel1.Controls.Add(this.overallProgressBar);
            this.panel1.Controls.Add(this.folderLabel);
            this.panel1.Controls.Add(this.overallProgressLabel);
            this.panel1.Controls.Add(this.staticFolderLabel);
            this.panel1.Controls.Add(this.metadataFilterComboBox);
            this.panel1.Controls.Add(this.fileFilterLabel);
            this.panel1.Controls.Add(this.metadataComboBox);
            this.panel1.Controls.Add(this.metadataTypeLabel);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Controls.Add(this.parentDirLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.parentDirTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 265);
            this.panel1.TabIndex = 13;
            // 
            // objectIdFolderNameRadioButton
            // 
            this.objectIdFolderNameRadioButton.AutoSize = true;
            this.objectIdFolderNameRadioButton.Location = new System.Drawing.Point(337, 189);
            this.objectIdFolderNameRadioButton.Name = "objectIdFolderNameRadioButton";
            this.objectIdFolderNameRadioButton.Size = new System.Drawing.Size(117, 18);
            this.objectIdFolderNameRadioButton.TabIndex = 24;
            this.objectIdFolderNameRadioButton.Text = "Use Folder Name";
            this.objectIdFolderNameRadioButton.UseVisualStyleBackColor = true;
            this.objectIdFolderNameRadioButton.CheckedChanged += new System.EventHandler(this.objectIdFolderNameRadioButton_CheckedChanged);
            // 
            // firstBibIdTextBox
            // 
            this.firstBibIdTextBox.Enabled = false;
            this.firstBibIdTextBox.Location = new System.Drawing.Point(304, 219);
            this.firstBibIdTextBox.Name = "firstBibIdTextBox";
            this.firstBibIdTextBox.Size = new System.Drawing.Size(148, 22);
            this.firstBibIdTextBox.TabIndex = 23;
            this.firstBibIdTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.firstBibIdTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // objectIdNewRadioButton
            // 
            this.objectIdNewRadioButton.AutoSize = true;
            this.objectIdNewRadioButton.Location = new System.Drawing.Point(144, 220);
            this.objectIdNewRadioButton.Name = "objectIdNewRadioButton";
            this.objectIdNewRadioButton.Size = new System.Drawing.Size(154, 18);
            this.objectIdNewRadioButton.TabIndex = 22;
            this.objectIdNewRadioButton.Text = "Create new BibID from:";
            this.objectIdNewRadioButton.UseVisualStyleBackColor = true;
            this.objectIdNewRadioButton.CheckedChanged += new System.EventHandler(this.objectIdNewRadioButton_CheckedChanged);
            // 
            // objectIdFileNameRadioButton
            // 
            this.objectIdFileNameRadioButton.AutoSize = true;
            this.objectIdFileNameRadioButton.Checked = true;
            this.objectIdFileNameRadioButton.Location = new System.Drawing.Point(144, 189);
            this.objectIdFileNameRadioButton.Name = "objectIdFileNameRadioButton";
            this.objectIdFileNameRadioButton.Size = new System.Drawing.Size(156, 18);
            this.objectIdFileNameRadioButton.TabIndex = 21;
            this.objectIdFileNameRadioButton.TabStop = true;
            this.objectIdFileNameRadioButton.Text = "Use Metadata File Name";
            this.objectIdFileNameRadioButton.UseVisualStyleBackColor = true;
            this.objectIdFileNameRadioButton.CheckedChanged += new System.EventHandler(this.objectIdFileNameRadioButton_CheckedChanged);
            // 
            // objectIdSourceLabel
            // 
            this.objectIdSourceLabel.AutoSize = true;
            this.objectIdSourceLabel.Location = new System.Drawing.Point(27, 191);
            this.objectIdSourceLabel.Name = "objectIdSourceLabel";
            this.objectIdSourceLabel.Size = new System.Drawing.Size(95, 14);
            this.objectIdSourceLabel.TabIndex = 20;
            this.objectIdSourceLabel.Text = "METS ObjectID:";
            // 
            // overallProgressBar
            // 
            this.overallProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.overallProgressBar.Location = new System.Drawing.Point(145, 329);
            this.overallProgressBar.Name = "overallProgressBar";
            this.overallProgressBar.Size = new System.Drawing.Size(441, 23);
            this.overallProgressBar.TabIndex = 19;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(142, 299);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(98, 14);
            this.folderLabel.TabIndex = 17;
            this.folderLabel.Text = "Checking Folders";
            // 
            // overallProgressLabel
            // 
            this.overallProgressLabel.AutoSize = true;
            this.overallProgressLabel.Location = new System.Drawing.Point(27, 334);
            this.overallProgressLabel.Name = "overallProgressLabel";
            this.overallProgressLabel.Size = new System.Drawing.Size(97, 14);
            this.overallProgressLabel.TabIndex = 16;
            this.overallProgressLabel.Text = "Overall Progress:";
            // 
            // staticFolderLabel
            // 
            this.staticFolderLabel.AutoSize = true;
            this.staticFolderLabel.Location = new System.Drawing.Point(27, 299);
            this.staticFolderLabel.Name = "staticFolderLabel";
            this.staticFolderLabel.Size = new System.Drawing.Size(89, 14);
            this.staticFolderLabel.TabIndex = 14;
            this.staticFolderLabel.Text = "Current Folder:";
            // 
            // metadataFilterComboBox
            // 
            this.metadataFilterComboBox.FormattingEnabled = true;
            this.metadataFilterComboBox.Items.AddRange(new object[] {
            "*.xml",
            "*.mets",
            "*.mets.xml",
            "*.mods",
            "*.dc"});
            this.metadataFilterComboBox.Location = new System.Drawing.Point(145, 153);
            this.metadataFilterComboBox.Name = "metadataFilterComboBox";
            this.metadataFilterComboBox.Size = new System.Drawing.Size(145, 22);
            this.metadataFilterComboBox.TabIndex = 13;
            this.metadataFilterComboBox.Text = "*.mets";
            // 
            // fileFilterLabel
            // 
            this.fileFilterLabel.AutoSize = true;
            this.fileFilterLabel.Location = new System.Drawing.Point(27, 156);
            this.fileFilterLabel.Name = "fileFilterLabel";
            this.fileFilterLabel.Size = new System.Drawing.Size(113, 14);
            this.fileFilterLabel.TabIndex = 12;
            this.fileFilterLabel.Text = "Metadata File Filter:";
            // 
            // metadataComboBox
            // 
            this.metadataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metadataComboBox.FormattingEnabled = true;
            this.metadataComboBox.Items.AddRange(new object[] {
            "Dublin Core File",
            "MarcXML File",
            "METS File",
            "MODS File"});
            this.metadataComboBox.Location = new System.Drawing.Point(145, 118);
            this.metadataComboBox.Name = "metadataComboBox";
            this.metadataComboBox.Size = new System.Drawing.Size(145, 22);
            this.metadataComboBox.TabIndex = 11;
            this.metadataComboBox.SelectedIndexChanged += new System.EventHandler(this.metadataComboBox_SelectedIndexChanged);
            // 
            // metadataTypeLabel
            // 
            this.metadataTypeLabel.AutoSize = true;
            this.metadataTypeLabel.Location = new System.Drawing.Point(27, 121);
            this.metadataTypeLabel.Name = "metadataTypeLabel";
            this.metadataTypeLabel.Size = new System.Drawing.Size(94, 14);
            this.metadataTypeLabel.TabIndex = 10;
            this.metadataTypeLabel.Text = "Metadata Type:";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(511, 82);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "BROWSE";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // parentDirLabel
            // 
            this.parentDirLabel.AutoSize = true;
            this.parentDirLabel.Location = new System.Drawing.Point(27, 86);
            this.parentDirLabel.Name = "parentDirLabel";
            this.parentDirLabel.Size = new System.Drawing.Size(100, 14);
            this.parentDirLabel.TabIndex = 8;
            this.parentDirLabel.Text = "Parent Directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(27, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "complete packages, by searching for a metadata file and adding all files to the p" +
                "ackage.";
            // 
            // parentDirTextBox
            // 
            this.parentDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.parentDirTextBox.Location = new System.Drawing.Point(145, 83);
            this.parentDirTextBox.Name = "parentDirTextBox";
            this.parentDirTextBox.Size = new System.Drawing.Size(360, 22);
            this.parentDirTextBox.TabIndex = 6;
            this.parentDirTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.parentDirTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "This option recurses through a series of subdirectories attempting to create ";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select the parent folder to recurse through subfolders within.";
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(591, 16);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 46;
            this.helpPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.helpPictureBox, "Get online help regarding this function");
            this.helpPictureBox.Click += new System.EventHandler(this.helpPictureBox_Click);
            // 
            // Batch_Import_Directory_Traverse_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(622, 353);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Batch_Import_Directory_Traverse_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METS Editor: Batch Import Directory Recursion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox parentDirTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label parentDirLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label metadataTypeLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox metadataComboBox;
        private System.Windows.Forms.ComboBox metadataFilterComboBox;
        private System.Windows.Forms.Label fileFilterLabel;
        private System.Windows.Forms.Label staticFolderLabel;
        private System.Windows.Forms.Label overallProgressLabel;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.ProgressBar overallProgressBar;
        private System.Windows.Forms.Label objectIdSourceLabel;
        private System.Windows.Forms.RadioButton objectIdNewRadioButton;
        private System.Windows.Forms.RadioButton objectIdFileNameRadioButton;
        private System.Windows.Forms.TextBox firstBibIdTextBox;
        private System.Windows.Forms.RadioButton objectIdFolderNameRadioButton;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}