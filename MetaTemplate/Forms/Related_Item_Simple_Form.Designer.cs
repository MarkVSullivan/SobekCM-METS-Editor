namespace SobekCM.METS_Editor.Forms
{
    partial class Related_Item_Simple_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Related_Item_Simple_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.displayLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.lccnLabel = new System.Windows.Forms.Label();
            this.lccnTextBox = new System.Windows.Forms.TextBox();
            this.oclcLabel = new System.Windows.Forms.Label();
            this.oclcTextBox = new System.Windows.Forms.TextBox();
            this.issnLabel = new System.Windows.Forms.Label();
            this.issnTextBox = new System.Windows.Forms.TextBox();
            this.ufdcIdLabel = new System.Windows.Forms.Label();
            this.relationComboBox = new System.Windows.Forms.ComboBox();
            this.ufdcIdTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.relationLabel = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.displayTextBox);
            this.panel1.Controls.Add(this.displayLabel);
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Controls.Add(this.urlLabel);
            this.panel1.Controls.Add(this.lccnLabel);
            this.panel1.Controls.Add(this.lccnTextBox);
            this.panel1.Controls.Add(this.oclcLabel);
            this.panel1.Controls.Add(this.oclcTextBox);
            this.panel1.Controls.Add(this.issnLabel);
            this.panel1.Controls.Add(this.issnTextBox);
            this.panel1.Controls.Add(this.ufdcIdLabel);
            this.panel1.Controls.Add(this.relationComboBox);
            this.panel1.Controls.Add(this.ufdcIdTextBox);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.titleTextBox);
            this.panel1.Controls.Add(this.relationLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 189);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // displayTextBox
            // 
            this.displayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.displayTextBox.BackColor = System.Drawing.Color.White;
            this.displayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.displayTextBox.Location = new System.Drawing.Point(418, 16);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.Size = new System.Drawing.Size(191, 22);
            this.displayTextBox.TabIndex = 1;
            this.displayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.displayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(333, 19);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(79, 14);
            this.displayLabel.TabIndex = 24;
            this.displayLabel.Text = "Display Label:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.BackColor = System.Drawing.Color.White;
            this.urlTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.urlTextBox.Location = new System.Drawing.Point(98, 80);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(511, 22);
            this.urlTextBox.TabIndex = 3;
            this.urlTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.urlTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(18, 83);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(32, 14);
            this.urlLabel.TabIndex = 22;
            this.urlLabel.Text = "URL:";
            // 
            // lccnLabel
            // 
            this.lccnLabel.AutoSize = true;
            this.lccnLabel.Location = new System.Drawing.Point(375, 147);
            this.lccnLabel.Name = "lccnLabel";
            this.lccnLabel.Size = new System.Drawing.Size(39, 14);
            this.lccnLabel.TabIndex = 21;
            this.lccnLabel.Text = "LCCN:";
            // 
            // lccnTextBox
            // 
            this.lccnTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lccnTextBox.BackColor = System.Drawing.Color.White;
            this.lccnTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.lccnTextBox.Location = new System.Drawing.Point(453, 144);
            this.lccnTextBox.Name = "lccnTextBox";
            this.lccnTextBox.Size = new System.Drawing.Size(156, 22);
            this.lccnTextBox.TabIndex = 7;
            this.lccnTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.lccnTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // oclcLabel
            // 
            this.oclcLabel.AutoSize = true;
            this.oclcLabel.Location = new System.Drawing.Point(18, 147);
            this.oclcLabel.Name = "oclcLabel";
            this.oclcLabel.Size = new System.Drawing.Size(40, 14);
            this.oclcLabel.TabIndex = 19;
            this.oclcLabel.Text = "OCLC:";
            // 
            // oclcTextBox
            // 
            this.oclcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oclcTextBox.BackColor = System.Drawing.Color.White;
            this.oclcTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.oclcTextBox.Location = new System.Drawing.Point(98, 144);
            this.oclcTextBox.Name = "oclcTextBox";
            this.oclcTextBox.Size = new System.Drawing.Size(156, 22);
            this.oclcTextBox.TabIndex = 6;
            this.oclcTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.oclcTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // issnLabel
            // 
            this.issnLabel.AutoSize = true;
            this.issnLabel.Location = new System.Drawing.Point(375, 115);
            this.issnLabel.Name = "issnLabel";
            this.issnLabel.Size = new System.Drawing.Size(37, 14);
            this.issnLabel.TabIndex = 17;
            this.issnLabel.Text = "ISSN:";
            // 
            // issnTextBox
            // 
            this.issnTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.issnTextBox.BackColor = System.Drawing.Color.White;
            this.issnTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.issnTextBox.Location = new System.Drawing.Point(453, 112);
            this.issnTextBox.Name = "issnTextBox";
            this.issnTextBox.Size = new System.Drawing.Size(156, 22);
            this.issnTextBox.TabIndex = 5;
            this.issnTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.issnTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // ufdcIdLabel
            // 
            this.ufdcIdLabel.AutoSize = true;
            this.ufdcIdLabel.Location = new System.Drawing.Point(18, 115);
            this.ufdcIdLabel.Name = "ufdcIdLabel";
            this.ufdcIdLabel.Size = new System.Drawing.Size(56, 14);
            this.ufdcIdLabel.TabIndex = 15;
            this.ufdcIdLabel.Text = "UFDC ID:";
            // 
            // relationComboBox
            // 
            this.relationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.relationComboBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.relationComboBox.FormattingEnabled = true;
            this.relationComboBox.Items.AddRange(new object[] {
            "(unknown)",
            "Host",
            "Other Format",
            "Other Version",
            "Preceding",
            "Succeeding"});
            this.relationComboBox.Location = new System.Drawing.Point(98, 16);
            this.relationComboBox.Name = "relationComboBox";
            this.relationComboBox.Size = new System.Drawing.Size(144, 22);
            this.relationComboBox.TabIndex = 0;
            this.relationComboBox.Leave += new System.EventHandler(this.comboBox_Leave);
            this.relationComboBox.Enter += new System.EventHandler(this.comboBox_Enter);
            // 
            // ufdcIdTextBox
            // 
            this.ufdcIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ufdcIdTextBox.BackColor = System.Drawing.Color.White;
            this.ufdcIdTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.ufdcIdTextBox.Location = new System.Drawing.Point(98, 112);
            this.ufdcIdTextBox.Name = "ufdcIdTextBox";
            this.ufdcIdTextBox.Size = new System.Drawing.Size(156, 22);
            this.ufdcIdTextBox.TabIndex = 4;
            this.ufdcIdTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.ufdcIdTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(18, 51);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 14);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BackColor = System.Drawing.Color.White;
            this.titleTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleTextBox.Location = new System.Drawing.Point(98, 48);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(511, 22);
            this.titleTextBox.TabIndex = 2;
            this.titleTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.titleTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // relationLabel
            // 
            this.relationLabel.AutoSize = true;
            this.relationLabel.Location = new System.Drawing.Point(18, 19);
            this.relationLabel.Name = "relationLabel";
            this.relationLabel.Size = new System.Drawing.Size(54, 14);
            this.relationLabel.TabIndex = 11;
            this.relationLabel.Text = "Relation:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(430, 211);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 26);
            this.cancelButton.TabIndex = 1;
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
            this.saveButton.Location = new System.Drawing.Point(550, 211);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(267, 294);
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
            this.hiddenCancelButton.Location = new System.Drawing.Point(236, 294);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Related_Item_Simple_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(675, 249);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Related_Item_Simple_Form";
            this.Text = "Edit Related Item Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ufdcIdTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label relationLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.ComboBox relationComboBox;
        private System.Windows.Forms.Label ufdcIdLabel;
        private System.Windows.Forms.Label lccnLabel;
        private System.Windows.Forms.TextBox lccnTextBox;
        private System.Windows.Forms.Label oclcLabel;
        private System.Windows.Forms.TextBox oclcTextBox;
        private System.Windows.Forms.Label issnLabel;
        private System.Windows.Forms.TextBox issnTextBox;
        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}