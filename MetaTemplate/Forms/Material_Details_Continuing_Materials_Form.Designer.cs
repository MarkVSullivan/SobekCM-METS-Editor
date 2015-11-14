namespace SobekCM.METS_Editor.Forms
{
    partial class Material_Details_Continuing_Materials_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material_Details_Continuing_Materials_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.specificGroupBox = new System.Windows.Forms.GroupBox();
            this.nature4ComboBox = new System.Windows.Forms.ComboBox();
            this.subTypeLabel = new System.Windows.Forms.Label();
            this.subTypeComboBox = new System.Windows.Forms.ComboBox();
            this.regularityComboBox = new System.Windows.Forms.ComboBox();
            this.regularityLabel = new System.Windows.Forms.Label();
            this.conferenceCheckBox = new System.Windows.Forms.CheckBox();
            this.govtComboBox = new System.Windows.Forms.ComboBox();
            this.nature3ComboBox = new System.Windows.Forms.ComboBox();
            this.nature2ComboBox = new System.Windows.Forms.ComboBox();
            this.nature1ComboBox = new System.Windows.Forms.ComboBox();
            this.frequencyComboBox = new System.Windows.Forms.ComboBox();
            this.govtLabel = new System.Windows.Forms.Label();
            this.natureContentsLabel = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.allMaterialsGroupBox = new System.Windows.Forms.GroupBox();
            this.languageCodeTextBox = new System.Windows.Forms.TextBox();
            this.languageCodeLabel = new System.Windows.Forms.Label();
            this.placeCodeTextBox = new System.Windows.Forms.TextBox();
            this.placeCodeLabel = new System.Windows.Forms.Label();
            this.date2TextBox = new System.Windows.Forms.TextBox();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.extentLabel = new System.Windows.Forms.Label();
            this.extentTextBox = new System.Windows.Forms.TextBox();
            this.date1TextBox = new System.Windows.Forms.TextBox();
            this.showMarcCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.hiddenSaveButton = new System.Windows.Forms.Button();
            this.hiddenCancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.specificGroupBox.SuspendLayout();
            this.allMaterialsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.specificGroupBox);
            this.panel1.Controls.Add(this.allMaterialsGroupBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 437);
            this.panel1.TabIndex = 0;
            // 
            // specificGroupBox
            // 
            this.specificGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.specificGroupBox.Controls.Add(this.nature4ComboBox);
            this.specificGroupBox.Controls.Add(this.subTypeLabel);
            this.specificGroupBox.Controls.Add(this.subTypeComboBox);
            this.specificGroupBox.Controls.Add(this.regularityComboBox);
            this.specificGroupBox.Controls.Add(this.regularityLabel);
            this.specificGroupBox.Controls.Add(this.conferenceCheckBox);
            this.specificGroupBox.Controls.Add(this.govtComboBox);
            this.specificGroupBox.Controls.Add(this.nature3ComboBox);
            this.specificGroupBox.Controls.Add(this.nature2ComboBox);
            this.specificGroupBox.Controls.Add(this.nature1ComboBox);
            this.specificGroupBox.Controls.Add(this.frequencyComboBox);
            this.specificGroupBox.Controls.Add(this.govtLabel);
            this.specificGroupBox.Controls.Add(this.natureContentsLabel);
            this.specificGroupBox.Controls.Add(this.frequencyLabel);
            this.specificGroupBox.Location = new System.Drawing.Point(9, 169);
            this.specificGroupBox.Name = "specificGroupBox";
            this.specificGroupBox.Size = new System.Drawing.Size(651, 252);
            this.specificGroupBox.TabIndex = 16;
            this.specificGroupBox.TabStop = false;
            this.specificGroupBox.Text = "Continuing Resources Details";
            this.specificGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.specificGroupBox_Paint);
            // 
            // nature4ComboBox
            // 
            this.nature4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nature4ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nature4ComboBox.FormattingEnabled = true;
            this.nature4ComboBox.Items.AddRange(new object[] {
            "",
            "abstract or summary",
            "bibliography",
            "calendar",
            "catalog",
            "comic/graphic novel",
            "dictionary",
            "directory",
            "discography",
            "filmography",
            "handbook",
            "index",
            "law report or digest",
            "legal article",
            "legal case and case notes",
            "legislation",
            "offprint",
            "patent",
            "programmed text",
            "review",
            "statistics",
            "survey of literature",
            "technical report",
            "theses",
            "treaty",
            "yearbook"});
            this.nature4ComboBox.Location = new System.Drawing.Point(401, 151);
            this.nature4ComboBox.Name = "nature4ComboBox";
            this.nature4ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature4ComboBox.TabIndex = 6;
            this.nature4ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature4ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // subTypeLabel
            // 
            this.subTypeLabel.AutoSize = true;
            this.subTypeLabel.Location = new System.Drawing.Point(22, 94);
            this.subTypeLabel.Name = "subTypeLabel";
            this.subTypeLabel.Size = new System.Drawing.Size(61, 14);
            this.subTypeLabel.TabIndex = 33;
            this.subTypeLabel.Text = "Sub-type:";
            // 
            // subTypeComboBox
            // 
            this.subTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subTypeComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.subTypeComboBox.FormattingEnabled = true;
            this.subTypeComboBox.Items.AddRange(new object[] {
            "",
            "database",
            "loose-leaf",
            "newspaper",
            "periodical",
            "series",
            "web site"});
            this.subTypeComboBox.Location = new System.Drawing.Point(170, 91);
            this.subTypeComboBox.Name = "subTypeComboBox";
            this.subTypeComboBox.Size = new System.Drawing.Size(209, 22);
            this.subTypeComboBox.TabIndex = 2;
            this.subTypeComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.subTypeComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // regularityComboBox
            // 
            this.regularityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regularityComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.regularityComboBox.FormattingEnabled = true;
            this.regularityComboBox.Items.AddRange(new object[] {
            "",
            "completely irregular",
            "normalized irregular",
            "regular"});
            this.regularityComboBox.Location = new System.Drawing.Point(170, 59);
            this.regularityComboBox.Name = "regularityComboBox";
            this.regularityComboBox.Size = new System.Drawing.Size(209, 22);
            this.regularityComboBox.TabIndex = 1;
            this.regularityComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.regularityComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // regularityLabel
            // 
            this.regularityLabel.AutoSize = true;
            this.regularityLabel.Location = new System.Drawing.Point(22, 62);
            this.regularityLabel.Name = "regularityLabel";
            this.regularityLabel.Size = new System.Drawing.Size(64, 14);
            this.regularityLabel.TabIndex = 31;
            this.regularityLabel.Text = "Regularity:";
            // 
            // conferenceCheckBox
            // 
            this.conferenceCheckBox.AutoSize = true;
            this.conferenceCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conferenceCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conferenceCheckBox.Location = new System.Drawing.Point(20, 220);
            this.conferenceCheckBox.Name = "conferenceCheckBox";
            this.conferenceCheckBox.Size = new System.Drawing.Size(155, 18);
            this.conferenceCheckBox.TabIndex = 8;
            this.conferenceCheckBox.Text = "Conference Publication:";
            this.conferenceCheckBox.UseVisualStyleBackColor = true;
            this.conferenceCheckBox.Leave += new System.EventHandler(this.checkBox_Leave);
            this.conferenceCheckBox.Enter += new System.EventHandler(this.checkBox_Enter);
            // 
            // govtComboBox
            // 
            this.govtComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.govtComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.govtComboBox.FormattingEnabled = true;
            this.govtComboBox.Items.AddRange(new object[] {
            "",
            "federal government publication",
            "international intergovernmental publication",
            "local government publication",
            "governmental publication",
            "government publication (autonomous or semiautonomous component)",
            "government publication (state, provincial, terriorial, dependent)",
            "multilocal government publication",
            "multistate government publication"});
            this.govtComboBox.Location = new System.Drawing.Point(170, 183);
            this.govtComboBox.Name = "govtComboBox";
            this.govtComboBox.Size = new System.Drawing.Size(440, 22);
            this.govtComboBox.TabIndex = 7;
            this.govtComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.govtComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // nature3ComboBox
            // 
            this.nature3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nature3ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nature3ComboBox.FormattingEnabled = true;
            this.nature3ComboBox.Items.AddRange(new object[] {
            "",
            "abstract or summary",
            "bibliography",
            "calendar",
            "catalog",
            "comic/graphic novel",
            "dictionary",
            "directory",
            "discography",
            "filmography",
            "handbook",
            "index",
            "law report or digest",
            "legal article",
            "legal case and case notes",
            "legislation",
            "offprint",
            "patent",
            "programmed text",
            "review",
            "statistics",
            "survey of literature",
            "technical report",
            "theses",
            "treaty",
            "yearbook"});
            this.nature3ComboBox.Location = new System.Drawing.Point(170, 151);
            this.nature3ComboBox.Name = "nature3ComboBox";
            this.nature3ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature3ComboBox.TabIndex = 5;
            this.nature3ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature3ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // nature2ComboBox
            // 
            this.nature2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nature2ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nature2ComboBox.FormattingEnabled = true;
            this.nature2ComboBox.Items.AddRange(new object[] {
            "",
            "abstract or summary",
            "bibliography",
            "calendar",
            "catalog",
            "comic/graphic novel",
            "dictionary",
            "directory",
            "discography",
            "filmography",
            "handbook",
            "index",
            "law report or digest",
            "legal article",
            "legal case and case notes",
            "legislation",
            "offprint",
            "patent",
            "programmed text",
            "review",
            "statistics",
            "survey of literature",
            "technical report",
            "theses",
            "treaty",
            "yearbook"});
            this.nature2ComboBox.Location = new System.Drawing.Point(401, 123);
            this.nature2ComboBox.Name = "nature2ComboBox";
            this.nature2ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature2ComboBox.TabIndex = 4;
            this.nature2ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature2ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // nature1ComboBox
            // 
            this.nature1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nature1ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nature1ComboBox.FormattingEnabled = true;
            this.nature1ComboBox.Items.AddRange(new object[] {
            "",
            "abstract or summary",
            "bibliography",
            "calendar",
            "catalog",
            "comic/graphic novel",
            "dictionary",
            "directory",
            "discography",
            "filmography",
            "handbook",
            "index",
            "law report or digest",
            "legal article",
            "legal case and case notes",
            "legislation",
            "offprint",
            "patent",
            "programmed text",
            "review",
            "statistics",
            "survey of literature",
            "technical report",
            "theses",
            "treaty",
            "yearbook"});
            this.nature1ComboBox.Location = new System.Drawing.Point(170, 123);
            this.nature1ComboBox.Name = "nature1ComboBox";
            this.nature1ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature1ComboBox.TabIndex = 3;
            this.nature1ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature1ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // frequencyComboBox
            // 
            this.frequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.frequencyComboBox.FormattingEnabled = true;
            this.frequencyComboBox.Items.AddRange(new object[] {
            "",
            "annual",
            "biennial",
            "bimonthly",
            "biweekly",
            "continuously updated",
            "daily",
            "monthly",
            "other",
            "quarterly",
            "semiannual",
            "semimonthly",
            "semiweekly",
            "three times a month",
            "three times a week",
            "three times a year",
            "triennial",
            "weekly"});
            this.frequencyComboBox.Location = new System.Drawing.Point(170, 27);
            this.frequencyComboBox.Name = "frequencyComboBox";
            this.frequencyComboBox.Size = new System.Drawing.Size(209, 22);
            this.frequencyComboBox.TabIndex = 0;
            this.frequencyComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.frequencyComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // govtLabel
            // 
            this.govtLabel.AutoSize = true;
            this.govtLabel.Location = new System.Drawing.Point(22, 186);
            this.govtLabel.Name = "govtLabel";
            this.govtLabel.Size = new System.Drawing.Size(79, 14);
            this.govtLabel.TabIndex = 14;
            this.govtLabel.Text = "Government:";
            // 
            // natureContentsLabel
            // 
            this.natureContentsLabel.AutoSize = true;
            this.natureContentsLabel.Location = new System.Drawing.Point(22, 126);
            this.natureContentsLabel.Name = "natureContentsLabel";
            this.natureContentsLabel.Size = new System.Drawing.Size(116, 14);
            this.natureContentsLabel.TabIndex = 12;
            this.natureContentsLabel.Text = "Nature of contents:";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(22, 30);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(68, 14);
            this.frequencyLabel.TabIndex = 11;
            this.frequencyLabel.Text = "Frequency:";
            // 
            // allMaterialsGroupBox
            // 
            this.allMaterialsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.allMaterialsGroupBox.Controls.Add(this.languageCodeTextBox);
            this.allMaterialsGroupBox.Controls.Add(this.languageCodeLabel);
            this.allMaterialsGroupBox.Controls.Add(this.placeCodeTextBox);
            this.allMaterialsGroupBox.Controls.Add(this.placeCodeLabel);
            this.allMaterialsGroupBox.Controls.Add(this.date2TextBox);
            this.allMaterialsGroupBox.Controls.Add(this.dateRangeLabel);
            this.allMaterialsGroupBox.Controls.Add(this.extentLabel);
            this.allMaterialsGroupBox.Controls.Add(this.extentTextBox);
            this.allMaterialsGroupBox.Controls.Add(this.date1TextBox);
            this.allMaterialsGroupBox.Location = new System.Drawing.Point(9, 3);
            this.allMaterialsGroupBox.Name = "allMaterialsGroupBox";
            this.allMaterialsGroupBox.Size = new System.Drawing.Size(651, 160);
            this.allMaterialsGroupBox.TabIndex = 15;
            this.allMaterialsGroupBox.TabStop = false;
            this.allMaterialsGroupBox.Text = "All Materials";
            // 
            // languageCodeTextBox
            // 
            this.languageCodeTextBox.BackColor = System.Drawing.Color.White;
            this.languageCodeTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.languageCodeTextBox.Location = new System.Drawing.Point(170, 123);
            this.languageCodeTextBox.Name = "languageCodeTextBox";
            this.languageCodeTextBox.Size = new System.Drawing.Size(96, 22);
            this.languageCodeTextBox.TabIndex = 4;
            this.languageCodeTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.languageCodeTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // languageCodeLabel
            // 
            this.languageCodeLabel.AutoSize = true;
            this.languageCodeLabel.Location = new System.Drawing.Point(22, 126);
            this.languageCodeLabel.Name = "languageCodeLabel";
            this.languageCodeLabel.Size = new System.Drawing.Size(96, 14);
            this.languageCodeLabel.TabIndex = 16;
            this.languageCodeLabel.Text = "Language Code:";
            // 
            // placeCodeTextBox
            // 
            this.placeCodeTextBox.BackColor = System.Drawing.Color.White;
            this.placeCodeTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.placeCodeTextBox.Location = new System.Drawing.Point(170, 91);
            this.placeCodeTextBox.Name = "placeCodeTextBox";
            this.placeCodeTextBox.Size = new System.Drawing.Size(96, 22);
            this.placeCodeTextBox.TabIndex = 3;
            this.placeCodeTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.placeCodeTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // placeCodeLabel
            // 
            this.placeCodeLabel.AutoSize = true;
            this.placeCodeLabel.Location = new System.Drawing.Point(22, 94);
            this.placeCodeLabel.Name = "placeCodeLabel";
            this.placeCodeLabel.Size = new System.Drawing.Size(71, 14);
            this.placeCodeLabel.TabIndex = 14;
            this.placeCodeLabel.Text = "Place Code:";
            // 
            // date2TextBox
            // 
            this.date2TextBox.BackColor = System.Drawing.Color.White;
            this.date2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.date2TextBox.Location = new System.Drawing.Point(283, 59);
            this.date2TextBox.Name = "date2TextBox";
            this.date2TextBox.Size = new System.Drawing.Size(96, 22);
            this.date2TextBox.TabIndex = 2;
            this.date2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.date2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.AutoSize = true;
            this.dateRangeLabel.Location = new System.Drawing.Point(22, 62);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(75, 14);
            this.dateRangeLabel.TabIndex = 12;
            this.dateRangeLabel.Text = "Date Range:";
            // 
            // extentLabel
            // 
            this.extentLabel.AutoSize = true;
            this.extentLabel.Location = new System.Drawing.Point(22, 30);
            this.extentLabel.Name = "extentLabel";
            this.extentLabel.Size = new System.Drawing.Size(48, 14);
            this.extentLabel.TabIndex = 11;
            this.extentLabel.Text = "Extent:";
            // 
            // extentTextBox
            // 
            this.extentTextBox.BackColor = System.Drawing.Color.White;
            this.extentTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.extentTextBox.Location = new System.Drawing.Point(170, 27);
            this.extentTextBox.Name = "extentTextBox";
            this.extentTextBox.Size = new System.Drawing.Size(440, 22);
            this.extentTextBox.TabIndex = 0;
            this.extentTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.extentTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // date1TextBox
            // 
            this.date1TextBox.BackColor = System.Drawing.Color.White;
            this.date1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.date1TextBox.Location = new System.Drawing.Point(170, 59);
            this.date1TextBox.Name = "date1TextBox";
            this.date1TextBox.Size = new System.Drawing.Size(96, 22);
            this.date1TextBox.TabIndex = 1;
            this.date1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.date1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // showMarcCheckBox
            // 
            this.showMarcCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showMarcCheckBox.AutoSize = true;
            this.showMarcCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.showMarcCheckBox.Location = new System.Drawing.Point(34, 467);
            this.showMarcCheckBox.Name = "showMarcCheckBox";
            this.showMarcCheckBox.Size = new System.Drawing.Size(92, 18);
            this.showMarcCheckBox.TabIndex = 1;
            this.showMarcCheckBox.Text = "Show MARC";
            this.showMarcCheckBox.UseVisualStyleBackColor = false;
            this.showMarcCheckBox.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(450, 459);
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
            this.saveButton.Location = new System.Drawing.Point(570, 459);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(266, 556);
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
            this.hiddenCancelButton.Location = new System.Drawing.Point(235, 556);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Material_Details_Continuing_Materials_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(695, 495);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.showMarcCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Material_Details_Continuing_Materials_Form";
            this.Text = "Edit Continuing Resources Material Details";
            this.panel1.ResumeLayout(false);
            this.specificGroupBox.ResumeLayout(false);
            this.specificGroupBox.PerformLayout();
            this.allMaterialsGroupBox.ResumeLayout(false);
            this.allMaterialsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.GroupBox allMaterialsGroupBox;
        private System.Windows.Forms.TextBox languageCodeTextBox;
        private System.Windows.Forms.Label languageCodeLabel;
        private System.Windows.Forms.TextBox placeCodeTextBox;
        private System.Windows.Forms.Label placeCodeLabel;
        private System.Windows.Forms.TextBox date2TextBox;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.Label extentLabel;
        private System.Windows.Forms.TextBox extentTextBox;
        private System.Windows.Forms.TextBox date1TextBox;
        private System.Windows.Forms.GroupBox specificGroupBox;
        private System.Windows.Forms.CheckBox conferenceCheckBox;
        private System.Windows.Forms.ComboBox govtComboBox;
        private System.Windows.Forms.ComboBox nature3ComboBox;
        private System.Windows.Forms.ComboBox nature2ComboBox;
        private System.Windows.Forms.ComboBox nature1ComboBox;
        private System.Windows.Forms.ComboBox frequencyComboBox;
        private System.Windows.Forms.Label govtLabel;
        private System.Windows.Forms.Label natureContentsLabel;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.CheckBox showMarcCheckBox;
        private System.Windows.Forms.ComboBox regularityComboBox;
        private System.Windows.Forms.Label regularityLabel;
        private System.Windows.Forms.ComboBox subTypeComboBox;
        private System.Windows.Forms.Label subTypeLabel;
        private System.Windows.Forms.ComboBox nature4ComboBox;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}