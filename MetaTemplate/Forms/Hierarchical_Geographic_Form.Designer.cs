namespace SobekCM.METS_Editor.Forms
{
    partial class Hierarchical_Geographic_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hierarchical_Geographic_Form));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.addedEntryRadioButton = new System.Windows.Forms.RadioButton();
            this.subjectRadioButton = new System.Windows.Forms.RadioButton();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.authorityComboBox = new System.Windows.Forms.ComboBox();
            this.areaLabel = new System.Windows.Forms.Label();
            this.authorityLabel = new System.Windows.Forms.Label();
            this.islandTextBox = new System.Windows.Forms.TextBox();
            this.islandLabel = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.countyTextBox = new System.Windows.Forms.TextBox();
            this.countyLabel = new System.Windows.Forms.Label();
            this.territoryTextBox = new System.Windows.Forms.TextBox();
            this.territoryLabel = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.regionLabel = new System.Windows.Forms.Label();
            this.provinceTextBox = new System.Windows.Forms.TextBox();
            this.provinceLabel = new System.Windows.Forms.Label();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.continentTextBox = new System.Windows.Forms.TextBox();
            this.continentLabel = new System.Windows.Forms.Label();
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
            this.checkBox1.Location = new System.Drawing.Point(35, 450);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 18);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show MARC";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.languageLabel);
            this.panel1.Controls.Add(this.addedEntryRadioButton);
            this.panel1.Controls.Add(this.subjectRadioButton);
            this.panel1.Controls.Add(this.areaTextBox);
            this.panel1.Controls.Add(this.authorityComboBox);
            this.panel1.Controls.Add(this.areaLabel);
            this.panel1.Controls.Add(this.authorityLabel);
            this.panel1.Controls.Add(this.islandTextBox);
            this.panel1.Controls.Add(this.islandLabel);
            this.panel1.Controls.Add(this.cityTextBox);
            this.panel1.Controls.Add(this.cityLabel);
            this.panel1.Controls.Add(this.countyTextBox);
            this.panel1.Controls.Add(this.countyLabel);
            this.panel1.Controls.Add(this.territoryTextBox);
            this.panel1.Controls.Add(this.territoryLabel);
            this.panel1.Controls.Add(this.stateTextBox);
            this.panel1.Controls.Add(this.stateLabel);
            this.panel1.Controls.Add(this.regionTextBox);
            this.panel1.Controls.Add(this.regionLabel);
            this.panel1.Controls.Add(this.provinceTextBox);
            this.panel1.Controls.Add(this.provinceLabel);
            this.panel1.Controls.Add(this.countryTextBox);
            this.panel1.Controls.Add(this.countryLabel);
            this.panel1.Controls.Add(this.continentTextBox);
            this.panel1.Controls.Add(this.continentLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 423);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.languageComboBox.Location = new System.Drawing.Point(344, 343);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(121, 22);
            this.languageComboBox.TabIndex = 11;
            this.languageComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.languageComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(260, 346);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(64, 14);
            this.languageLabel.TabIndex = 36;
            this.languageLabel.Text = "Language:";
            // 
            // addedEntryRadioButton
            // 
            this.addedEntryRadioButton.AutoSize = true;
            this.addedEntryRadioButton.Location = new System.Drawing.Point(249, 384);
            this.addedEntryRadioButton.Name = "addedEntryRadioButton";
            this.addedEntryRadioButton.Size = new System.Drawing.Size(158, 18);
            this.addedEntryRadioButton.TabIndex = 13;
            this.addedEntryRadioButton.Text = "Added Hierarchical Entry";
            this.addedEntryRadioButton.UseVisualStyleBackColor = true;
            this.addedEntryRadioButton.Leave += new System.EventHandler(this.radioButton_Leave);
            this.addedEntryRadioButton.Enter += new System.EventHandler(this.radioButton_Enter);
            this.addedEntryRadioButton.CheckedChanged += new System.EventHandler(this.addedEntryRadioButton_CheckedChanged);
            // 
            // subjectRadioButton
            // 
            this.subjectRadioButton.AutoSize = true;
            this.subjectRadioButton.Checked = true;
            this.subjectRadioButton.Location = new System.Drawing.Point(61, 384);
            this.subjectRadioButton.Name = "subjectRadioButton";
            this.subjectRadioButton.Size = new System.Drawing.Size(131, 18);
            this.subjectRadioButton.TabIndex = 12;
            this.subjectRadioButton.TabStop = true;
            this.subjectRadioButton.Text = "Hierarchical Subject";
            this.subjectRadioButton.UseVisualStyleBackColor = true;
            this.subjectRadioButton.Leave += new System.EventHandler(this.radioButton_Leave);
            this.subjectRadioButton.Enter += new System.EventHandler(this.radioButton_Enter);
            this.subjectRadioButton.CheckedChanged += new System.EventHandler(this.subjectRadioButton_CheckedChanged);
            // 
            // areaTextBox
            // 
            this.areaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.areaTextBox.BackColor = System.Drawing.Color.White;
            this.areaTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.areaTextBox.Location = new System.Drawing.Point(104, 311);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(361, 22);
            this.areaTextBox.TabIndex = 9;
            this.areaTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.areaTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // authorityComboBox
            // 
            this.authorityComboBox.BackColor = System.Drawing.Color.White;
            this.authorityComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.authorityComboBox.FormattingEnabled = true;
            this.authorityComboBox.Items.AddRange(new object[] {
            "gnis",
            "lcsh/naf",
            "tgn",
            ""});
            this.authorityComboBox.Location = new System.Drawing.Point(104, 343);
            this.authorityComboBox.Name = "authorityComboBox";
            this.authorityComboBox.Size = new System.Drawing.Size(121, 22);
            this.authorityComboBox.TabIndex = 10;
            this.authorityComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.authorityComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Location = new System.Drawing.Point(23, 314);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(36, 14);
            this.areaLabel.TabIndex = 29;
            this.areaLabel.Text = "Area:";
            // 
            // authorityLabel
            // 
            this.authorityLabel.AutoSize = true;
            this.authorityLabel.Location = new System.Drawing.Point(23, 346);
            this.authorityLabel.Name = "authorityLabel";
            this.authorityLabel.Size = new System.Drawing.Size(62, 14);
            this.authorityLabel.TabIndex = 0;
            this.authorityLabel.Text = "Authority:";
            // 
            // islandTextBox
            // 
            this.islandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.islandTextBox.BackColor = System.Drawing.Color.White;
            this.islandTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.islandTextBox.Location = new System.Drawing.Point(104, 279);
            this.islandTextBox.Name = "islandTextBox";
            this.islandTextBox.Size = new System.Drawing.Size(361, 22);
            this.islandTextBox.TabIndex = 8;
            this.islandTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.islandTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // islandLabel
            // 
            this.islandLabel.AutoSize = true;
            this.islandLabel.Location = new System.Drawing.Point(23, 282);
            this.islandLabel.Name = "islandLabel";
            this.islandLabel.Size = new System.Drawing.Size(42, 14);
            this.islandLabel.TabIndex = 27;
            this.islandLabel.Text = "Island:";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cityTextBox.BackColor = System.Drawing.Color.White;
            this.cityTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.cityTextBox.Location = new System.Drawing.Point(104, 247);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(361, 22);
            this.cityTextBox.TabIndex = 7;
            this.cityTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.cityTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(23, 250);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(31, 14);
            this.cityLabel.TabIndex = 25;
            this.cityLabel.Text = "City:";
            // 
            // countyTextBox
            // 
            this.countyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.countyTextBox.BackColor = System.Drawing.Color.White;
            this.countyTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.countyTextBox.Location = new System.Drawing.Point(104, 215);
            this.countyTextBox.Name = "countyTextBox";
            this.countyTextBox.Size = new System.Drawing.Size(361, 22);
            this.countyTextBox.TabIndex = 6;
            this.countyTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.countyTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // countyLabel
            // 
            this.countyLabel.AutoSize = true;
            this.countyLabel.Location = new System.Drawing.Point(23, 218);
            this.countyLabel.Name = "countyLabel";
            this.countyLabel.Size = new System.Drawing.Size(50, 14);
            this.countyLabel.TabIndex = 23;
            this.countyLabel.Text = "County:";
            // 
            // territoryTextBox
            // 
            this.territoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.territoryTextBox.BackColor = System.Drawing.Color.White;
            this.territoryTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.territoryTextBox.Location = new System.Drawing.Point(104, 183);
            this.territoryTextBox.Name = "territoryTextBox";
            this.territoryTextBox.Size = new System.Drawing.Size(361, 22);
            this.territoryTextBox.TabIndex = 5;
            this.territoryTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.territoryTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // territoryLabel
            // 
            this.territoryLabel.AutoSize = true;
            this.territoryLabel.Location = new System.Drawing.Point(23, 186);
            this.territoryLabel.Name = "territoryLabel";
            this.territoryLabel.Size = new System.Drawing.Size(58, 14);
            this.territoryLabel.TabIndex = 21;
            this.territoryLabel.Text = "Territory:";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stateTextBox.BackColor = System.Drawing.Color.White;
            this.stateTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.stateTextBox.Location = new System.Drawing.Point(104, 151);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(361, 22);
            this.stateTextBox.TabIndex = 4;
            this.stateTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.stateTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(23, 154);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(41, 14);
            this.stateLabel.TabIndex = 19;
            this.stateLabel.Text = "State:";
            // 
            // regionTextBox
            // 
            this.regionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regionTextBox.BackColor = System.Drawing.Color.White;
            this.regionTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.regionTextBox.Location = new System.Drawing.Point(104, 119);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(361, 22);
            this.regionTextBox.TabIndex = 3;
            this.regionTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.regionTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(23, 123);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(48, 14);
            this.regionLabel.TabIndex = 17;
            this.regionLabel.Text = "Region:";
            // 
            // provinceTextBox
            // 
            this.provinceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.provinceTextBox.BackColor = System.Drawing.Color.White;
            this.provinceTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.provinceTextBox.Location = new System.Drawing.Point(104, 87);
            this.provinceTextBox.Name = "provinceTextBox";
            this.provinceTextBox.Size = new System.Drawing.Size(361, 22);
            this.provinceTextBox.TabIndex = 2;
            this.provinceTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.provinceTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // provinceLabel
            // 
            this.provinceLabel.AutoSize = true;
            this.provinceLabel.Location = new System.Drawing.Point(23, 90);
            this.provinceLabel.Name = "provinceLabel";
            this.provinceLabel.Size = new System.Drawing.Size(57, 14);
            this.provinceLabel.TabIndex = 15;
            this.provinceLabel.Text = "Province:";
            // 
            // countryTextBox
            // 
            this.countryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.countryTextBox.BackColor = System.Drawing.Color.White;
            this.countryTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.countryTextBox.Location = new System.Drawing.Point(104, 55);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(361, 22);
            this.countryTextBox.TabIndex = 1;
            this.countryTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.countryTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(23, 58);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(54, 14);
            this.countryLabel.TabIndex = 13;
            this.countryLabel.Text = "Country:";
            // 
            // continentTextBox
            // 
            this.continentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.continentTextBox.BackColor = System.Drawing.Color.White;
            this.continentTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.continentTextBox.Location = new System.Drawing.Point(104, 23);
            this.continentTextBox.Name = "continentTextBox";
            this.continentTextBox.Size = new System.Drawing.Size(361, 22);
            this.continentTextBox.TabIndex = 0;
            this.continentTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.continentTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // continentLabel
            // 
            this.continentLabel.AutoSize = true;
            this.continentLabel.Location = new System.Drawing.Point(23, 26);
            this.continentLabel.Name = "continentLabel";
            this.continentLabel.Size = new System.Drawing.Size(65, 14);
            this.continentLabel.TabIndex = 11;
            this.continentLabel.Text = "Continent:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(276, 442);
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
            this.saveButton.Location = new System.Drawing.Point(390, 442);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(194, 536);
            this.hiddenSaveButton.Name = "hiddenSaveButton";
            this.hiddenSaveButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenSaveButton.TabIndex = 15;
            this.hiddenSaveButton.TabStop = false;
            this.hiddenSaveButton.UseVisualStyleBackColor = true;
            this.hiddenSaveButton.Click += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(163, 536);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 14;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Hierarchical_Geographic_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(519, 480);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hierarchical_Geographic_Form";
            this.Text = "Edit Hierarchical Geographic Subject";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton addedEntryRadioButton;
        private System.Windows.Forms.RadioButton subjectRadioButton;
        private System.Windows.Forms.ComboBox authorityComboBox;
        private System.Windows.Forms.Label authorityLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.TextBox continentTextBox;
        private System.Windows.Forms.Label continentLabel;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.TextBox islandTextBox;
        private System.Windows.Forms.Label islandLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox countyTextBox;
        private System.Windows.Forms.Label countyLabel;
        private System.Windows.Forms.TextBox territoryTextBox;
        private System.Windows.Forms.Label territoryLabel;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.TextBox provinceTextBox;
        private System.Windows.Forms.Label provinceLabel;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}