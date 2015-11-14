namespace SobekCM.METS_Editor.Forms
{
    partial class Title_Info_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Title_Info_Form));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleTypeTextBox = new System.Windows.Forms.TextBox();
            this.displayComboBox = new System.Windows.Forms.ComboBox();
            this.partName2TextBox = new System.Windows.Forms.TextBox();
            this.partName1TextBox = new System.Windows.Forms.TextBox();
            this.partNumber2TextBox = new System.Windows.Forms.TextBox();
            this.partNumber1TextBox = new System.Windows.Forms.TextBox();
            this.authorityComboBox = new System.Windows.Forms.ComboBox();
            this.authorityLabel = new System.Windows.Forms.Label();
            this.partNameLabel = new System.Windows.Forms.Label();
            this.partNumberLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.titleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.responsibilityTextBox = new System.Windows.Forms.TextBox();
            this.nonSortLabel = new System.Windows.Forms.Label();
            this.responsibilityLabel = new System.Windows.Forms.Label();
            this.nonSortTextBox = new System.Windows.Forms.TextBox();
            this.subTitleTextBox = new System.Windows.Forms.TextBox();
            this.titleTypeLabel = new System.Windows.Forms.Label();
            this.displayLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.hiddenSaveButton = new System.Windows.Forms.Button();
            this.hiddenCancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(52, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show MARC";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.titleTypeTextBox);
            this.panel1.Controls.Add(this.displayComboBox);
            this.panel1.Controls.Add(this.partName2TextBox);
            this.panel1.Controls.Add(this.partName1TextBox);
            this.panel1.Controls.Add(this.partNumber2TextBox);
            this.panel1.Controls.Add(this.partNumber1TextBox);
            this.panel1.Controls.Add(this.authorityComboBox);
            this.panel1.Controls.Add(this.authorityLabel);
            this.panel1.Controls.Add(this.partNameLabel);
            this.panel1.Controls.Add(this.partNumberLabel);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.languageLabel);
            this.panel1.Controls.Add(this.titleTypeComboBox);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.titleTextBox);
            this.panel1.Controls.Add(this.responsibilityTextBox);
            this.panel1.Controls.Add(this.nonSortLabel);
            this.panel1.Controls.Add(this.responsibilityLabel);
            this.panel1.Controls.Add(this.nonSortTextBox);
            this.panel1.Controls.Add(this.subTitleTextBox);
            this.panel1.Controls.Add(this.titleTypeLabel);
            this.panel1.Controls.Add(this.displayLabel);
            this.panel1.Controls.Add(this.subTitleLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 247);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // titleTypeTextBox
            // 
            this.titleTypeTextBox.BackColor = System.Drawing.Color.White;
            this.titleTypeTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleTypeTextBox.Location = new System.Drawing.Point(119, 12);
            this.titleTypeTextBox.Name = "titleTypeTextBox";
            this.titleTypeTextBox.ReadOnly = true;
            this.titleTypeTextBox.Size = new System.Drawing.Size(121, 20);
            this.titleTypeTextBox.TabIndex = 1;
            this.titleTypeTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.titleTypeTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // displayComboBox
            // 
            this.displayComboBox.BackColor = System.Drawing.Color.White;
            this.displayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.displayComboBox.FormattingEnabled = true;
            this.displayComboBox.Items.AddRange(new object[] {
            "Corporate",
            "Meeting",
            "Personal"});
            this.displayComboBox.Location = new System.Drawing.Point(477, 12);
            this.displayComboBox.Name = "displayComboBox";
            this.displayComboBox.Size = new System.Drawing.Size(202, 21);
            this.displayComboBox.TabIndex = 2;
            this.displayComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.displayComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // partName2TextBox
            // 
            this.partName2TextBox.BackColor = System.Drawing.Color.White;
            this.partName2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partName2TextBox.Location = new System.Drawing.Point(255, 204);
            this.partName2TextBox.Name = "partName2TextBox";
            this.partName2TextBox.Size = new System.Drawing.Size(121, 20);
            this.partName2TextBox.TabIndex = 11;
            this.partName2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partName2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // partName1TextBox
            // 
            this.partName1TextBox.BackColor = System.Drawing.Color.White;
            this.partName1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partName1TextBox.Location = new System.Drawing.Point(119, 204);
            this.partName1TextBox.Name = "partName1TextBox";
            this.partName1TextBox.Size = new System.Drawing.Size(121, 20);
            this.partName1TextBox.TabIndex = 10;
            this.partName1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partName1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // partNumber2TextBox
            // 
            this.partNumber2TextBox.BackColor = System.Drawing.Color.White;
            this.partNumber2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partNumber2TextBox.Location = new System.Drawing.Point(255, 172);
            this.partNumber2TextBox.Name = "partNumber2TextBox";
            this.partNumber2TextBox.Size = new System.Drawing.Size(121, 20);
            this.partNumber2TextBox.TabIndex = 9;
            this.partNumber2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partNumber2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // partNumber1TextBox
            // 
            this.partNumber1TextBox.BackColor = System.Drawing.Color.White;
            this.partNumber1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partNumber1TextBox.Location = new System.Drawing.Point(119, 172);
            this.partNumber1TextBox.Name = "partNumber1TextBox";
            this.partNumber1TextBox.Size = new System.Drawing.Size(121, 20);
            this.partNumber1TextBox.TabIndex = 8;
            this.partNumber1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partNumber1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // authorityComboBox
            // 
            this.authorityComboBox.BackColor = System.Drawing.Color.White;
            this.authorityComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.authorityComboBox.FormattingEnabled = true;
            this.authorityComboBox.Items.AddRange(new object[] {
            "naf"});
            this.authorityComboBox.Location = new System.Drawing.Point(558, 204);
            this.authorityComboBox.Name = "authorityComboBox";
            this.authorityComboBox.Size = new System.Drawing.Size(121, 21);
            this.authorityComboBox.TabIndex = 12;
            this.authorityComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.authorityComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // authorityLabel
            // 
            this.authorityLabel.AutoSize = true;
            this.authorityLabel.Location = new System.Drawing.Point(460, 207);
            this.authorityLabel.Name = "authorityLabel";
            this.authorityLabel.Size = new System.Drawing.Size(51, 13);
            this.authorityLabel.TabIndex = 20;
            this.authorityLabel.Text = "Authority:";
            // 
            // partNameLabel
            // 
            this.partNameLabel.AutoSize = true;
            this.partNameLabel.Location = new System.Drawing.Point(19, 207);
            this.partNameLabel.Name = "partNameLabel";
            this.partNameLabel.Size = new System.Drawing.Size(60, 13);
            this.partNameLabel.TabIndex = 19;
            this.partNameLabel.Text = "Part Name:";
            // 
            // partNumberLabel
            // 
            this.partNumberLabel.AutoSize = true;
            this.partNumberLabel.Location = new System.Drawing.Point(19, 175);
            this.partNumberLabel.Name = "partNumberLabel";
            this.partNumberLabel.Size = new System.Drawing.Size(69, 13);
            this.partNumberLabel.TabIndex = 18;
            this.partNumberLabel.Text = "Part Number:";
            // 
            // languageComboBox
            // 
            this.languageComboBox.BackColor = System.Drawing.Color.White;
            this.languageComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "English",
            "French",
            "Spanish"});
            this.languageComboBox.Location = new System.Drawing.Point(558, 44);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(121, 21);
            this.languageComboBox.TabIndex = 4;
            this.languageComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.languageComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(454, 47);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 16;
            this.languageLabel.Text = "Language:";
            // 
            // titleTypeComboBox
            // 
            this.titleTypeComboBox.BackColor = System.Drawing.Color.White;
            this.titleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleTypeComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleTypeComboBox.FormattingEnabled = true;
            this.titleTypeComboBox.Items.AddRange(new object[] {
            "Corporate",
            "Meeting",
            "Personal"});
            this.titleTypeComboBox.Location = new System.Drawing.Point(119, 12);
            this.titleTypeComboBox.Name = "titleTypeComboBox";
            this.titleTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.titleTypeComboBox.TabIndex = 0;
            this.titleTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.titleTypeComboBox_SelectedIndexChanged);
            this.titleTypeComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.titleTypeComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(19, 79);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.Color.White;
            this.titleTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleTextBox.Location = new System.Drawing.Point(119, 76);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(560, 20);
            this.titleTextBox.TabIndex = 5;
            this.titleTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.titleTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // responsibilityTextBox
            // 
            this.responsibilityTextBox.BackColor = System.Drawing.Color.White;
            this.responsibilityTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.responsibilityTextBox.Location = new System.Drawing.Point(178, 140);
            this.responsibilityTextBox.Name = "responsibilityTextBox";
            this.responsibilityTextBox.Size = new System.Drawing.Size(501, 20);
            this.responsibilityTextBox.TabIndex = 7;
            this.responsibilityTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.responsibilityTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // nonSortLabel
            // 
            this.nonSortLabel.AutoSize = true;
            this.nonSortLabel.Location = new System.Drawing.Point(19, 47);
            this.nonSortLabel.Name = "nonSortLabel";
            this.nonSortLabel.Size = new System.Drawing.Size(52, 13);
            this.nonSortLabel.TabIndex = 3;
            this.nonSortLabel.Text = "Non Sort:";
            // 
            // responsibilityLabel
            // 
            this.responsibilityLabel.AutoSize = true;
            this.responsibilityLabel.Location = new System.Drawing.Point(19, 143);
            this.responsibilityLabel.Name = "responsibilityLabel";
            this.responsibilityLabel.Size = new System.Drawing.Size(137, 13);
            this.responsibilityLabel.TabIndex = 9;
            this.responsibilityLabel.Text = "Statement of Responsibility:";
            // 
            // nonSortTextBox
            // 
            this.nonSortTextBox.BackColor = System.Drawing.Color.White;
            this.nonSortTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nonSortTextBox.Location = new System.Drawing.Point(119, 44);
            this.nonSortTextBox.Name = "nonSortTextBox";
            this.nonSortTextBox.Size = new System.Drawing.Size(102, 20);
            this.nonSortTextBox.TabIndex = 3;
            this.nonSortTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.nonSortTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // subTitleTextBox
            // 
            this.subTitleTextBox.BackColor = System.Drawing.Color.White;
            this.subTitleTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.subTitleTextBox.Location = new System.Drawing.Point(119, 108);
            this.subTitleTextBox.Name = "subTitleTextBox";
            this.subTitleTextBox.Size = new System.Drawing.Size(560, 20);
            this.subTitleTextBox.TabIndex = 6;
            this.subTitleTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.subTitleTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // titleTypeLabel
            // 
            this.titleTypeLabel.AutoSize = true;
            this.titleTypeLabel.Location = new System.Drawing.Point(19, 15);
            this.titleTypeLabel.Name = "titleTypeLabel";
            this.titleTypeLabel.Size = new System.Drawing.Size(57, 13);
            this.titleTypeLabel.TabIndex = 0;
            this.titleTypeLabel.Text = "Title Type:";
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(398, 15);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(73, 13);
            this.displayLabel.TabIndex = 15;
            this.displayLabel.Text = "Display Label:";
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.AutoSize = true;
            this.subTitleLabel.Location = new System.Drawing.Point(19, 111);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(52, 13);
            this.subTitleLabel.TabIndex = 11;
            this.subTitleLabel.Text = "Sub Title:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(485, 266);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 26);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Button_Pressed += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "SAVE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(599, 266);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(328, 421);
            this.hiddenSaveButton.Name = "hiddenSaveButton";
            this.hiddenSaveButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenSaveButton.TabIndex = 19;
            this.hiddenSaveButton.TabStop = false;
            this.hiddenSaveButton.UseVisualStyleBackColor = true;
            this.hiddenSaveButton.Click += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(297, 421);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Title_Info_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(730, 304);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Title_Info_Form";
            this.Text = "Edit Title Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox responsibilityTextBox;
        private System.Windows.Forms.Label responsibilityLabel;
        private System.Windows.Forms.ComboBox titleTypeComboBox;
        private System.Windows.Forms.Label titleTypeLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.TextBox subTitleTextBox;
        private System.Windows.Forms.TextBox nonSortTextBox;
        private System.Windows.Forms.Label nonSortLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label partNameLabel;
        private System.Windows.Forms.Label partNumberLabel;
        private System.Windows.Forms.ComboBox authorityComboBox;
        private System.Windows.Forms.Label authorityLabel;
        private System.Windows.Forms.TextBox partName2TextBox;
        private System.Windows.Forms.TextBox partName1TextBox;
        private System.Windows.Forms.TextBox partNumber2TextBox;
        private System.Windows.Forms.TextBox partNumber1TextBox;
        private System.Windows.Forms.ComboBox displayComboBox;
        private System.Windows.Forms.TextBox titleTypeTextBox;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}