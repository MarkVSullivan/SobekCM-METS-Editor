namespace SobekCM.METS_Editor.ImageDerivative
{
    partial class Image_Derivative_Creation_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Derivative_Creation_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jpegPanel = new System.Windows.Forms.Panel();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.jpegCheckBox = new System.Windows.Forms.CheckBox();
            this.jp2CheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.taskLabel = new System.Windows.Forms.Label();
            this.staticTaskLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.staticVolumeLabel = new System.Windows.Forms.Label();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            this.thumbHeightTextBox = new System.Windows.Forms.TextBox();
            this.thumbWidthTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel2 = new System.Windows.Forms.Label();
            this.widthLabel2 = new System.Windows.Forms.Label();
            this.thumbnailCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jpegPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.thumbnailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(10, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 358);
            this.panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.thumbnailPanel);
            this.groupBox2.Controls.Add(this.thumbnailCheckBox);
            this.groupBox2.Controls.Add(this.jpegPanel);
            this.groupBox2.Controls.Add(this.jpegCheckBox);
            this.groupBox2.Controls.Add(this.jp2CheckBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Derivative Creation Settings";
            // 
            // jpegPanel
            // 
            this.jpegPanel.Controls.Add(this.heightTextBox);
            this.jpegPanel.Controls.Add(this.widthTextBox);
            this.jpegPanel.Controls.Add(this.heightLabel);
            this.jpegPanel.Controls.Add(this.widthLabel);
            this.jpegPanel.Location = new System.Drawing.Point(153, 63);
            this.jpegPanel.Name = "jpegPanel";
            this.jpegPanel.Size = new System.Drawing.Size(429, 40);
            this.jpegPanel.TabIndex = 2;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(309, 13);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(89, 22);
            this.heightTextBox.TabIndex = 3;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(105, 13);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(89, 22);
            this.widthTextBox.TabIndex = 2;
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(213, 16);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(90, 14);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height (pixels):";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 16);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(87, 14);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width (pixels):";
            // 
            // jpegCheckBox
            // 
            this.jpegCheckBox.AutoSize = true;
            this.jpegCheckBox.Location = new System.Drawing.Point(38, 78);
            this.jpegCheckBox.Name = "jpegCheckBox";
            this.jpegCheckBox.Size = new System.Drawing.Size(93, 18);
            this.jpegCheckBox.TabIndex = 1;
            this.jpegCheckBox.Text = "Create JPEG";
            this.jpegCheckBox.UseVisualStyleBackColor = true;
            this.jpegCheckBox.CheckedChanged += new System.EventHandler(this.jpegCheckBox_CheckedChanged);
            // 
            // jp2CheckBox
            // 
            this.jp2CheckBox.AutoSize = true;
            this.jp2CheckBox.Location = new System.Drawing.Point(38, 38);
            this.jp2CheckBox.Name = "jp2CheckBox";
            this.jp2CheckBox.Size = new System.Drawing.Size(121, 18);
            this.jp2CheckBox.TabIndex = 0;
            this.jp2CheckBox.Text = "Create JPEG2000";
            this.jp2CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.volumeLabel);
            this.groupBox1.Controls.Add(this.taskLabel);
            this.groupBox1.Controls.Add(this.staticTaskLabel);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.staticVolumeLabel);
            this.groupBox1.Location = new System.Drawing.Point(14, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 161);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Derivative Creation Progress";
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeLabel.Location = new System.Drawing.Point(141, 38);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(436, 23);
            this.volumeLabel.TabIndex = 4;
            this.volumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskLabel
            // 
            this.taskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taskLabel.Location = new System.Drawing.Point(141, 70);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(436, 23);
            this.taskLabel.TabIndex = 2;
            this.taskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // staticTaskLabel
            // 
            this.staticTaskLabel.Location = new System.Drawing.Point(21, 70);
            this.staticTaskLabel.Name = "staticTaskLabel";
            this.staticTaskLabel.Size = new System.Drawing.Size(96, 23);
            this.staticTaskLabel.TabIndex = 0;
            this.staticTaskLabel.Text = "Current Task:";
            this.staticTaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(21, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(556, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // staticVolumeLabel
            // 
            this.staticVolumeLabel.Location = new System.Drawing.Point(21, 38);
            this.staticVolumeLabel.Name = "staticVolumeLabel";
            this.staticVolumeLabel.Size = new System.Drawing.Size(120, 23);
            this.staticVolumeLabel.TabIndex = 3;
            this.staticVolumeLabel.Text = "Current Folder:";
            this.staticVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "CREATE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(544, 412);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 10;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(432, 412);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(94, 26);
            this.cancelRoundButton.TabIndex = 9;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select folder to perform image derivative creation within.";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleLabel.Location = new System.Drawing.Point(40, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(562, 42);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "Image Derivative Creation";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(614, 12);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 13;
            this.helpPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.helpPictureBox, "Get online help regarding this function");
            this.helpPictureBox.Click += new System.EventHandler(this.helpPictureBox_Click);
            // 
            // thumbnailPanel
            // 
            this.thumbnailPanel.Controls.Add(this.thumbHeightTextBox);
            this.thumbnailPanel.Controls.Add(this.thumbWidthTextBox);
            this.thumbnailPanel.Controls.Add(this.heightLabel2);
            this.thumbnailPanel.Controls.Add(this.widthLabel2);
            this.thumbnailPanel.Location = new System.Drawing.Point(153, 103);
            this.thumbnailPanel.Name = "thumbnailPanel";
            this.thumbnailPanel.Size = new System.Drawing.Size(429, 42);
            this.thumbnailPanel.TabIndex = 4;
            // 
            // thumbHeightTextBox
            // 
            this.thumbHeightTextBox.Location = new System.Drawing.Point(309, 13);
            this.thumbHeightTextBox.Name = "thumbHeightTextBox";
            this.thumbHeightTextBox.Size = new System.Drawing.Size(89, 22);
            this.thumbHeightTextBox.TabIndex = 3;
            // 
            // thumbWidthTextBox
            // 
            this.thumbWidthTextBox.Location = new System.Drawing.Point(105, 13);
            this.thumbWidthTextBox.Name = "thumbWidthTextBox";
            this.thumbWidthTextBox.Size = new System.Drawing.Size(89, 22);
            this.thumbWidthTextBox.TabIndex = 2;
            // 
            // heightLabel2
            // 
            this.heightLabel2.AutoSize = true;
            this.heightLabel2.Location = new System.Drawing.Point(213, 16);
            this.heightLabel2.Name = "heightLabel2";
            this.heightLabel2.Size = new System.Drawing.Size(90, 14);
            this.heightLabel2.TabIndex = 1;
            this.heightLabel2.Text = "Height (pixels):";
            // 
            // widthLabel2
            // 
            this.widthLabel2.AutoSize = true;
            this.widthLabel2.Location = new System.Drawing.Point(12, 16);
            this.widthLabel2.Name = "widthLabel2";
            this.widthLabel2.Size = new System.Drawing.Size(87, 14);
            this.widthLabel2.TabIndex = 0;
            this.widthLabel2.Text = "Width (pixels):";
            // 
            // thumbnailCheckBox
            // 
            this.thumbnailCheckBox.AutoSize = true;
            this.thumbnailCheckBox.Location = new System.Drawing.Point(38, 118);
            this.thumbnailCheckBox.Name = "thumbnailCheckBox";
            this.thumbnailCheckBox.Size = new System.Drawing.Size(122, 18);
            this.thumbnailCheckBox.TabIndex = 3;
            this.thumbnailCheckBox.Text = "Create Thumbnail";
            this.thumbnailCheckBox.UseVisualStyleBackColor = true;
            this.thumbnailCheckBox.CheckedChanged += new System.EventHandler(this.thumbnailCheckBox_CheckedChanged);
            // 
            // Image_Derivative_Creation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Image_Derivative_Creation_Form";
            this.Text = "Image Derivative Creation Form";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.jpegPanel.ResumeLayout(false);
            this.jpegPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.thumbnailPanel.ResumeLayout(false);
            this.thumbnailPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label staticTaskLabel;
        private System.Windows.Forms.Label staticVolumeLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label taskLabel;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox jp2CheckBox;
        private System.Windows.Forms.CheckBox jpegCheckBox;
        private System.Windows.Forms.Panel jpegPanel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.CheckBox thumbnailCheckBox;
        private System.Windows.Forms.Panel thumbnailPanel;
        private System.Windows.Forms.TextBox thumbHeightTextBox;
        private System.Windows.Forms.TextBox thumbWidthTextBox;
        private System.Windows.Forms.Label heightLabel2;
        private System.Windows.Forms.Label widthLabel2;
    }
}