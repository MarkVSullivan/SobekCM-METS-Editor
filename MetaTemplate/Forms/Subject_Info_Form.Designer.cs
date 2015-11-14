namespace SobekCM.METS_Editor.Forms
{
    partial class Subject_Info_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subject_Info_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.marcComboBox = new System.Windows.Forms.ComboBox();
            this.marcLabel = new System.Windows.Forms.Label();
            this.authorityComboBox = new System.Windows.Forms.ComboBox();
            this.authorityLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.genre2TextBox = new System.Windows.Forms.TextBox();
            this.genre1TextBox = new System.Windows.Forms.TextBox();
            this.geographic2TextBox = new System.Windows.Forms.TextBox();
            this.temporal2TextBox = new System.Windows.Forms.TextBox();
            this.topical4TextBox = new System.Windows.Forms.TextBox();
            this.topical2TextBox = new System.Windows.Forms.TextBox();
            this.topical3TextBox = new System.Windows.Forms.TextBox();
            this.optionalTextBox = new System.Windows.Forms.TextBox();
            this.optionalLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.geographic1TextBox = new System.Windows.Forms.TextBox();
            this.geographicLabel = new System.Windows.Forms.Label();
            this.temporal1TextBox = new System.Windows.Forms.TextBox();
            this.temporalLabel = new System.Windows.Forms.Label();
            this.topical1TextBox = new System.Windows.Forms.TextBox();
            this.topicalLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.hiddenSaveButton = new System.Windows.Forms.Button();
            this.hiddenCancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.marcComboBox);
            this.panel1.Controls.Add(this.marcLabel);
            this.panel1.Controls.Add(this.authorityComboBox);
            this.panel1.Controls.Add(this.authorityLabel);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.languageLabel);
            this.panel1.Controls.Add(this.typeComboBox);
            this.panel1.Controls.Add(this.typeLabel);
            this.panel1.Controls.Add(this.genre2TextBox);
            this.panel1.Controls.Add(this.genre1TextBox);
            this.panel1.Controls.Add(this.geographic2TextBox);
            this.panel1.Controls.Add(this.temporal2TextBox);
            this.panel1.Controls.Add(this.topical4TextBox);
            this.panel1.Controls.Add(this.topical2TextBox);
            this.panel1.Controls.Add(this.topical3TextBox);
            this.panel1.Controls.Add(this.optionalTextBox);
            this.panel1.Controls.Add(this.optionalLabel);
            this.panel1.Controls.Add(this.genreLabel);
            this.panel1.Controls.Add(this.geographic1TextBox);
            this.panel1.Controls.Add(this.geographicLabel);
            this.panel1.Controls.Add(this.temporal1TextBox);
            this.panel1.Controls.Add(this.temporalLabel);
            this.panel1.Controls.Add(this.topical1TextBox);
            this.panel1.Controls.Add(this.topicalLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 301);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // marcComboBox
            // 
            this.marcComboBox.BackColor = System.Drawing.Color.White;
            this.marcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marcComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.marcComboBox.FormattingEnabled = true;
            this.marcComboBox.Items.AddRange(new object[] {
            "",
            "648 - Chronological Term",
            "650 - Topical Term",
            "651 - Geographic Name",
            "653 - Uncontrolled Index",
            "654 - Faceted Topical",
            "655 - Genre / Form",
            "656 - Occupation",
            "657 - Function",
            "690 - Local Topical",
            "691 - Local Geographic"});
            this.marcComboBox.Location = new System.Drawing.Point(426, 18);
            this.marcComboBox.Name = "marcComboBox";
            this.marcComboBox.Size = new System.Drawing.Size(184, 22);
            this.marcComboBox.TabIndex = 1;
            this.marcComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.marcComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // marcLabel
            // 
            this.marcLabel.AutoSize = true;
            this.marcLabel.Location = new System.Drawing.Point(329, 21);
            this.marcLabel.Name = "marcLabel";
            this.marcLabel.Size = new System.Drawing.Size(91, 14);
            this.marcLabel.TabIndex = 37;
            this.marcLabel.Text = "MARC Mapping:";
            // 
            // authorityComboBox
            // 
            this.authorityComboBox.BackColor = System.Drawing.Color.White;
            this.authorityComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.authorityComboBox.FormattingEnabled = true;
            this.authorityComboBox.Items.AddRange(new object[] {
            "csh",
            "fast",
            "lcsh",
            "lcshac",
            "local",
            "mesh",
            "nal",
            "rvm"});
            this.authorityComboBox.Location = new System.Drawing.Point(157, 256);
            this.authorityComboBox.Name = "authorityComboBox";
            this.authorityComboBox.Size = new System.Drawing.Size(121, 22);
            this.authorityComboBox.TabIndex = 15;
            this.authorityComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.authorityComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // authorityLabel
            // 
            this.authorityLabel.AutoSize = true;
            this.authorityLabel.Location = new System.Drawing.Point(22, 259);
            this.authorityLabel.Name = "authorityLabel";
            this.authorityLabel.Size = new System.Drawing.Size(62, 14);
            this.authorityLabel.TabIndex = 35;
            this.authorityLabel.Text = "Authority:";
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
            this.languageComboBox.Location = new System.Drawing.Point(489, 256);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(121, 22);
            this.languageComboBox.TabIndex = 16;
            this.languageComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.languageComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(375, 259);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(64, 14);
            this.languageLabel.TabIndex = 34;
            this.languageLabel.Text = "Language:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.Color.White;
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Name",
            "Standard",
            "Title"});
            this.typeComboBox.Location = new System.Drawing.Point(157, 18);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 22);
            this.typeComboBox.TabIndex = 0;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            this.typeComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.typeComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(21, 21);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(85, 14);
            this.typeLabel.TabIndex = 31;
            this.typeLabel.Text = "Subject Type:";
            // 
            // genre2TextBox
            // 
            this.genre2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genre2TextBox.BackColor = System.Drawing.Color.White;
            this.genre2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.genre2TextBox.Location = new System.Drawing.Point(390, 186);
            this.genre2TextBox.Name = "genre2TextBox";
            this.genre2TextBox.Size = new System.Drawing.Size(220, 22);
            this.genre2TextBox.TabIndex = 11;
            this.genre2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.genre2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // genre1TextBox
            // 
            this.genre1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genre1TextBox.BackColor = System.Drawing.Color.White;
            this.genre1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.genre1TextBox.Location = new System.Drawing.Point(157, 186);
            this.genre1TextBox.Name = "genre1TextBox";
            this.genre1TextBox.Size = new System.Drawing.Size(220, 22);
            this.genre1TextBox.TabIndex = 10;
            this.genre1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.genre1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // geographic2TextBox
            // 
            this.geographic2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.geographic2TextBox.BackColor = System.Drawing.Color.White;
            this.geographic2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.geographic2TextBox.Location = new System.Drawing.Point(390, 151);
            this.geographic2TextBox.Name = "geographic2TextBox";
            this.geographic2TextBox.Size = new System.Drawing.Size(220, 22);
            this.geographic2TextBox.TabIndex = 9;
            this.geographic2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.geographic2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // temporal2TextBox
            // 
            this.temporal2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.temporal2TextBox.BackColor = System.Drawing.Color.White;
            this.temporal2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.temporal2TextBox.Location = new System.Drawing.Point(390, 116);
            this.temporal2TextBox.Name = "temporal2TextBox";
            this.temporal2TextBox.Size = new System.Drawing.Size(220, 22);
            this.temporal2TextBox.TabIndex = 7;
            this.temporal2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.temporal2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // topical4TextBox
            // 
            this.topical4TextBox.BackColor = System.Drawing.Color.White;
            this.topical4TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.topical4TextBox.Location = new System.Drawing.Point(390, 81);
            this.topical4TextBox.Name = "topical4TextBox";
            this.topical4TextBox.Size = new System.Drawing.Size(220, 22);
            this.topical4TextBox.TabIndex = 5;
            this.topical4TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.topical4TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // topical2TextBox
            // 
            this.topical2TextBox.BackColor = System.Drawing.Color.White;
            this.topical2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.topical2TextBox.Location = new System.Drawing.Point(390, 53);
            this.topical2TextBox.Name = "topical2TextBox";
            this.topical2TextBox.Size = new System.Drawing.Size(220, 22);
            this.topical2TextBox.TabIndex = 3;
            this.topical2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.topical2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // topical3TextBox
            // 
            this.topical3TextBox.BackColor = System.Drawing.Color.White;
            this.topical3TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.topical3TextBox.Location = new System.Drawing.Point(157, 81);
            this.topical3TextBox.Name = "topical3TextBox";
            this.topical3TextBox.Size = new System.Drawing.Size(220, 22);
            this.topical3TextBox.TabIndex = 4;
            this.topical3TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.topical3TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // optionalTextBox
            // 
            this.optionalTextBox.BackColor = System.Drawing.Color.White;
            this.optionalTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.optionalTextBox.Location = new System.Drawing.Point(157, 221);
            this.optionalTextBox.Name = "optionalTextBox";
            this.optionalTextBox.Size = new System.Drawing.Size(453, 22);
            this.optionalTextBox.TabIndex = 12;
            this.optionalTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.optionalTextBox_KeyDown);
            this.optionalTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.optionalTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionalTextBox_MouseDown);
            this.optionalTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // optionalLabel
            // 
            this.optionalLabel.AutoSize = true;
            this.optionalLabel.Location = new System.Drawing.Point(21, 224);
            this.optionalLabel.Name = "optionalLabel";
            this.optionalLabel.Size = new System.Drawing.Size(105, 14);
            this.optionalLabel.TabIndex = 19;
            this.optionalLabel.Text = "Optional Element:";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(21, 189);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(132, 14);
            this.genreLabel.TabIndex = 17;
            this.genreLabel.Text = "Form / Genre Term(s):";
            // 
            // geographic1TextBox
            // 
            this.geographic1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.geographic1TextBox.BackColor = System.Drawing.Color.White;
            this.geographic1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.geographic1TextBox.Location = new System.Drawing.Point(157, 151);
            this.geographic1TextBox.Name = "geographic1TextBox";
            this.geographic1TextBox.Size = new System.Drawing.Size(220, 22);
            this.geographic1TextBox.TabIndex = 8;
            this.geographic1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.geographic1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // geographicLabel
            // 
            this.geographicLabel.AutoSize = true;
            this.geographicLabel.Location = new System.Drawing.Point(21, 154);
            this.geographicLabel.Name = "geographicLabel";
            this.geographicLabel.Size = new System.Drawing.Size(120, 14);
            this.geographicLabel.TabIndex = 15;
            this.geographicLabel.Text = "Geographic Term(s):";
            // 
            // temporal1TextBox
            // 
            this.temporal1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.temporal1TextBox.BackColor = System.Drawing.Color.White;
            this.temporal1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.temporal1TextBox.Location = new System.Drawing.Point(157, 116);
            this.temporal1TextBox.Name = "temporal1TextBox";
            this.temporal1TextBox.Size = new System.Drawing.Size(220, 22);
            this.temporal1TextBox.TabIndex = 6;
            this.temporal1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.temporal1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // temporalLabel
            // 
            this.temporalLabel.AutoSize = true;
            this.temporalLabel.Location = new System.Drawing.Point(21, 119);
            this.temporalLabel.Name = "temporalLabel";
            this.temporalLabel.Size = new System.Drawing.Size(130, 14);
            this.temporalLabel.TabIndex = 13;
            this.temporalLabel.Text = "Chronological Term(s):";
            // 
            // topical1TextBox
            // 
            this.topical1TextBox.BackColor = System.Drawing.Color.White;
            this.topical1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.topical1TextBox.Location = new System.Drawing.Point(157, 53);
            this.topical1TextBox.Name = "topical1TextBox";
            this.topical1TextBox.Size = new System.Drawing.Size(220, 22);
            this.topical1TextBox.TabIndex = 2;
            this.topical1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.topical1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // topicalLabel
            // 
            this.topicalLabel.AutoSize = true;
            this.topicalLabel.Location = new System.Drawing.Point(21, 72);
            this.topicalLabel.Name = "topicalLabel";
            this.topicalLabel.Size = new System.Drawing.Size(97, 14);
            this.topicalLabel.TabIndex = 11;
            this.topicalLabel.Text = "Topical Term(s):";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(43, 322);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 18);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show MARC";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(418, 322);
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
            this.saveButton.Location = new System.Drawing.Point(542, 322);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(254, 419);
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
            this.hiddenCancelButton.Location = new System.Drawing.Point(223, 419);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Subject_Info_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(665, 357);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Subject_Info_Form";
            this.Text = "Edit Subject Term";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox optionalTextBox;
        private System.Windows.Forms.Label optionalLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.TextBox geographic1TextBox;
        private System.Windows.Forms.Label geographicLabel;
        private System.Windows.Forms.TextBox temporal1TextBox;
        private System.Windows.Forms.Label temporalLabel;
        private System.Windows.Forms.TextBox topical1TextBox;
        private System.Windows.Forms.Label topicalLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox topical4TextBox;
        private System.Windows.Forms.TextBox topical2TextBox;
        private System.Windows.Forms.TextBox topical3TextBox;
        private System.Windows.Forms.TextBox temporal2TextBox;
        private System.Windows.Forms.TextBox geographic2TextBox;
        private System.Windows.Forms.TextBox genre2TextBox;
        private System.Windows.Forms.TextBox genre1TextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox authorityComboBox;
        private System.Windows.Forms.Label authorityLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox marcComboBox;
        private System.Windows.Forms.Label marcLabel;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}