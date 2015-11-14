namespace SobekCM.METS_Editor.Forms
{
    partial class Material_Details_Book_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material_Details_Book_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.specificGroupBox = new System.Windows.Forms.GroupBox();
            this.form2ComboBox = new System.Windows.Forms.ComboBox();
            this.biographyComboBox = new System.Windows.Forms.ComboBox();
            this.biographyLabel = new System.Windows.Forms.Label();
            this.form1ComboBox = new System.Windows.Forms.ComboBox();
            this.formLabel = new System.Windows.Forms.Label();
            this.indexCheckBox = new System.Windows.Forms.CheckBox();
            this.festschriftCheckBox = new System.Windows.Forms.CheckBox();
            this.conferenceCheckBox = new System.Windows.Forms.CheckBox();
            this.govtComboBox = new System.Windows.Forms.ComboBox();
            this.nature4ComboBox = new System.Windows.Forms.ComboBox();
            this.nature3ComboBox = new System.Windows.Forms.ComboBox();
            this.nature2ComboBox = new System.Windows.Forms.ComboBox();
            this.nature1ComboBox = new System.Windows.Forms.ComboBox();
            this.audienceComboBox = new System.Windows.Forms.ComboBox();
            this.govtLabel = new System.Windows.Forms.Label();
            this.natureContentsLabel = new System.Windows.Forms.Label();
            this.audienceLabel = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(661, 451);
            this.panel1.TabIndex = 0;
            // 
            // specificGroupBox
            // 
            this.specificGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.specificGroupBox.Controls.Add(this.form2ComboBox);
            this.specificGroupBox.Controls.Add(this.biographyComboBox);
            this.specificGroupBox.Controls.Add(this.biographyLabel);
            this.specificGroupBox.Controls.Add(this.form1ComboBox);
            this.specificGroupBox.Controls.Add(this.formLabel);
            this.specificGroupBox.Controls.Add(this.indexCheckBox);
            this.specificGroupBox.Controls.Add(this.festschriftCheckBox);
            this.specificGroupBox.Controls.Add(this.conferenceCheckBox);
            this.specificGroupBox.Controls.Add(this.govtComboBox);
            this.specificGroupBox.Controls.Add(this.nature4ComboBox);
            this.specificGroupBox.Controls.Add(this.nature3ComboBox);
            this.specificGroupBox.Controls.Add(this.nature2ComboBox);
            this.specificGroupBox.Controls.Add(this.nature1ComboBox);
            this.specificGroupBox.Controls.Add(this.audienceComboBox);
            this.specificGroupBox.Controls.Add(this.govtLabel);
            this.specificGroupBox.Controls.Add(this.natureContentsLabel);
            this.specificGroupBox.Controls.Add(this.audienceLabel);
            this.specificGroupBox.Location = new System.Drawing.Point(9, 169);
            this.specificGroupBox.Name = "specificGroupBox";
            this.specificGroupBox.Size = new System.Drawing.Size(639, 268);
            this.specificGroupBox.TabIndex = 15;
            this.specificGroupBox.TabStop = false;
            this.specificGroupBox.Text = "Book Details";
            this.specificGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.specificGroupBox_Paint);
            // 
            // form2ComboBox
            // 
            this.form2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.form2ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.form2ComboBox.FormattingEnabled = true;
            this.form2ComboBox.Items.AddRange(new object[] {
            "",
            "comic strip",
            "drama",
            "essay",
            "fiction",
            "humor, satire",
            "letter",
            "novel",
            "non-fiction",
            "poetry",
            "short story",
            "speech"});
            this.form2ComboBox.Location = new System.Drawing.Point(401, 192);
            this.form2ComboBox.Name = "form2ComboBox";
            this.form2ComboBox.Size = new System.Drawing.Size(209, 22);
            this.form2ComboBox.TabIndex = 10;
            this.form2ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.form2ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // biographyComboBox
            // 
            this.biographyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.biographyComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.biographyComboBox.FormattingEnabled = true;
            this.biographyComboBox.Items.AddRange(new object[] {
            "",
            "autobiography",
            "individual biography",
            "collective biography"});
            this.biographyComboBox.Location = new System.Drawing.Point(170, 224);
            this.biographyComboBox.Name = "biographyComboBox";
            this.biographyComboBox.Size = new System.Drawing.Size(209, 22);
            this.biographyComboBox.TabIndex = 11;
            this.biographyComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.biographyComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // biographyLabel
            // 
            this.biographyLabel.AutoSize = true;
            this.biographyLabel.Location = new System.Drawing.Point(22, 227);
            this.biographyLabel.Name = "biographyLabel";
            this.biographyLabel.Size = new System.Drawing.Size(64, 14);
            this.biographyLabel.TabIndex = 29;
            this.biographyLabel.Text = "Biography:";
            // 
            // form1ComboBox
            // 
            this.form1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.form1ComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.form1ComboBox.FormattingEnabled = true;
            this.form1ComboBox.Items.AddRange(new object[] {
            "",
            "comic strip",
            "drama",
            "essay",
            "fiction",
            "humor, satire",
            "letter",
            "novel",
            "non-fiction",
            "poetry",
            "short story",
            "speech"});
            this.form1ComboBox.Location = new System.Drawing.Point(170, 192);
            this.form1ComboBox.Name = "form1ComboBox";
            this.form1ComboBox.Size = new System.Drawing.Size(209, 22);
            this.form1ComboBox.TabIndex = 9;
            this.form1ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.form1ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Location = new System.Drawing.Point(22, 195);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(82, 14);
            this.formLabel.TabIndex = 27;
            this.formLabel.Text = "Literary Form:";
            // 
            // indexCheckBox
            // 
            this.indexCheckBox.AutoSize = true;
            this.indexCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indexCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indexCheckBox.Location = new System.Drawing.Point(503, 158);
            this.indexCheckBox.Name = "indexCheckBox";
            this.indexCheckBox.Size = new System.Drawing.Size(107, 18);
            this.indexCheckBox.TabIndex = 8;
            this.indexCheckBox.Text = "Index Present:";
            this.indexCheckBox.UseVisualStyleBackColor = true;
            this.indexCheckBox.Leave += new System.EventHandler(this.checkBox_Leave);
            this.indexCheckBox.Enter += new System.EventHandler(this.checkBox_Enter);
            // 
            // festschriftCheckBox
            // 
            this.festschriftCheckBox.AutoSize = true;
            this.festschriftCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.festschriftCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.festschriftCheckBox.Location = new System.Drawing.Point(298, 158);
            this.festschriftCheckBox.Name = "festschriftCheckBox";
            this.festschriftCheckBox.Size = new System.Drawing.Size(86, 18);
            this.festschriftCheckBox.TabIndex = 7;
            this.festschriftCheckBox.Text = "Festschrift:";
            this.festschriftCheckBox.UseVisualStyleBackColor = true;
            this.festschriftCheckBox.Leave += new System.EventHandler(this.checkBox_Leave);
            this.festschriftCheckBox.Enter += new System.EventHandler(this.checkBox_Enter);
            // 
            // conferenceCheckBox
            // 
            this.conferenceCheckBox.AutoSize = true;
            this.conferenceCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conferenceCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conferenceCheckBox.Location = new System.Drawing.Point(20, 158);
            this.conferenceCheckBox.Name = "conferenceCheckBox";
            this.conferenceCheckBox.Size = new System.Drawing.Size(155, 18);
            this.conferenceCheckBox.TabIndex = 6;
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
            this.govtComboBox.Location = new System.Drawing.Point(170, 119);
            this.govtComboBox.Name = "govtComboBox";
            this.govtComboBox.Size = new System.Drawing.Size(440, 22);
            this.govtComboBox.TabIndex = 5;
            this.govtComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.govtComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
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
            this.nature4ComboBox.Location = new System.Drawing.Point(401, 87);
            this.nature4ComboBox.Name = "nature4ComboBox";
            this.nature4ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature4ComboBox.TabIndex = 4;
            this.nature4ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature4ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
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
            this.nature3ComboBox.Location = new System.Drawing.Point(170, 87);
            this.nature3ComboBox.Name = "nature3ComboBox";
            this.nature3ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature3ComboBox.TabIndex = 3;
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
            this.nature2ComboBox.Location = new System.Drawing.Point(401, 59);
            this.nature2ComboBox.Name = "nature2ComboBox";
            this.nature2ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature2ComboBox.TabIndex = 2;
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
            this.nature1ComboBox.Location = new System.Drawing.Point(170, 59);
            this.nature1ComboBox.Name = "nature1ComboBox";
            this.nature1ComboBox.Size = new System.Drawing.Size(209, 22);
            this.nature1ComboBox.TabIndex = 1;
            this.nature1ComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.nature1ComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // audienceComboBox
            // 
            this.audienceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audienceComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.audienceComboBox.FormattingEnabled = true;
            this.audienceComboBox.Items.AddRange(new object[] {
            "",
            "adolescent",
            "adult",
            "general",
            "juvenile",
            "pre-adolescent",
            "preschool",
            "primary",
            "specialized"});
            this.audienceComboBox.Location = new System.Drawing.Point(170, 27);
            this.audienceComboBox.Name = "audienceComboBox";
            this.audienceComboBox.Size = new System.Drawing.Size(131, 22);
            this.audienceComboBox.TabIndex = 0;
            this.audienceComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.audienceComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // govtLabel
            // 
            this.govtLabel.AutoSize = true;
            this.govtLabel.Location = new System.Drawing.Point(22, 122);
            this.govtLabel.Name = "govtLabel";
            this.govtLabel.Size = new System.Drawing.Size(79, 14);
            this.govtLabel.TabIndex = 14;
            this.govtLabel.Text = "Government:";
            // 
            // natureContentsLabel
            // 
            this.natureContentsLabel.AutoSize = true;
            this.natureContentsLabel.Location = new System.Drawing.Point(22, 62);
            this.natureContentsLabel.Name = "natureContentsLabel";
            this.natureContentsLabel.Size = new System.Drawing.Size(116, 14);
            this.natureContentsLabel.TabIndex = 12;
            this.natureContentsLabel.Text = "Nature of contents:";
            // 
            // audienceLabel
            // 
            this.audienceLabel.AutoSize = true;
            this.audienceLabel.Location = new System.Drawing.Point(22, 30);
            this.audienceLabel.Name = "audienceLabel";
            this.audienceLabel.Size = new System.Drawing.Size(103, 14);
            this.audienceLabel.TabIndex = 11;
            this.audienceLabel.Text = "Target Audience:";
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
            this.allMaterialsGroupBox.Size = new System.Drawing.Size(639, 160);
            this.allMaterialsGroupBox.TabIndex = 14;
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
            this.showMarcCheckBox.Location = new System.Drawing.Point(34, 478);
            this.showMarcCheckBox.Name = "showMarcCheckBox";
            this.showMarcCheckBox.Size = new System.Drawing.Size(92, 18);
            this.showMarcCheckBox.TabIndex = 1;
            this.showMarcCheckBox.Text = "Show MARC";
            this.showMarcCheckBox.UseVisualStyleBackColor = true;
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
            this.cancelButton.Location = new System.Drawing.Point(440, 473);
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
            this.saveButton.Location = new System.Drawing.Point(560, 473);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(266, 545);
            this.hiddenSaveButton.Name = "hiddenSaveButton";
            this.hiddenSaveButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenSaveButton.TabIndex = 17;
            this.hiddenSaveButton.TabStop = false;
            this.hiddenSaveButton.UseVisualStyleBackColor = true;
            this.hiddenSaveButton.Click += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(235, 545);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 16;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Material_Details_Book_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(685, 508);
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
            this.Name = "Material_Details_Book_Form";
            this.Text = "Edit Book Material Details";
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
        private System.Windows.Forms.TextBox date1TextBox;
        private System.Windows.Forms.TextBox extentTextBox;
        private System.Windows.Forms.Label extentLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.GroupBox allMaterialsGroupBox;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.TextBox languageCodeTextBox;
        private System.Windows.Forms.Label languageCodeLabel;
        private System.Windows.Forms.TextBox placeCodeTextBox;
        private System.Windows.Forms.Label placeCodeLabel;
        private System.Windows.Forms.TextBox date2TextBox;
        private System.Windows.Forms.GroupBox specificGroupBox;
        private System.Windows.Forms.Label govtLabel;
        private System.Windows.Forms.Label natureContentsLabel;
        private System.Windows.Forms.Label audienceLabel;
        private System.Windows.Forms.ComboBox audienceComboBox;
        private System.Windows.Forms.CheckBox showMarcCheckBox;
        private System.Windows.Forms.ComboBox nature1ComboBox;
        private System.Windows.Forms.ComboBox nature4ComboBox;
        private System.Windows.Forms.ComboBox nature3ComboBox;
        private System.Windows.Forms.ComboBox nature2ComboBox;
        private System.Windows.Forms.ComboBox govtComboBox;
        private System.Windows.Forms.CheckBox indexCheckBox;
        private System.Windows.Forms.CheckBox festschriftCheckBox;
        private System.Windows.Forms.CheckBox conferenceCheckBox;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.ComboBox form1ComboBox;
        private System.Windows.Forms.ComboBox biographyComboBox;
        private System.Windows.Forms.Label biographyLabel;
        private System.Windows.Forms.ComboBox form2ComboBox;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}