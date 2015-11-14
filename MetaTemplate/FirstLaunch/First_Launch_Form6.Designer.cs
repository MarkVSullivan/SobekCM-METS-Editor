namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form6));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rightsTextBox = new System.Windows.Forms.TextBox();
            this.fundingLabel = new System.Windows.Forms.Label();
            this.rightsLabel = new System.Windows.Forms.Label();
            this.fundingTextBox = new System.Windows.Forms.TextBox();
            this.individualGroupBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.sourceInstitutionGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceCodeTextBox = new System.Windows.Forms.TextBox();
            this.sourceStatementLabel = new System.Windows.Forms.Label();
            this.sourceCodeLabel = new System.Windows.Forms.Label();
            this.sourceStatementTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.individualGroupBox.SuspendLayout();
            this.sourceInstitutionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.individualGroupBox);
            this.panel1.Controls.Add(this.sourceInstitutionGroupBox);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 417);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rightsTextBox);
            this.groupBox1.Controls.Add(this.fundingLabel);
            this.groupBox1.Controls.Add(this.rightsLabel);
            this.groupBox1.Controls.Add(this.fundingTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(16, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Defaults";
            // 
            // rightsTextBox
            // 
            this.rightsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rightsTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightsTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rightsTextBox.Location = new System.Drawing.Point(153, 35);
            this.rightsTextBox.Multiline = true;
            this.rightsTextBox.Name = "rightsTextBox";
            this.rightsTextBox.Size = new System.Drawing.Size(520, 51);
            this.rightsTextBox.TabIndex = 0;
            this.rightsTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.rightsTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // fundingLabel
            // 
            this.fundingLabel.AutoSize = true;
            this.fundingLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fundingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fundingLabel.Location = new System.Drawing.Point(26, 108);
            this.fundingLabel.Name = "fundingLabel";
            this.fundingLabel.Size = new System.Drawing.Size(85, 14);
            this.fundingLabel.TabIndex = 21;
            this.fundingLabel.Text = "Funding Note:";
            // 
            // rightsLabel
            // 
            this.rightsLabel.AutoSize = true;
            this.rightsLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rightsLabel.Location = new System.Drawing.Point(26, 38);
            this.rightsLabel.Name = "rightsLabel";
            this.rightsLabel.Size = new System.Drawing.Size(44, 14);
            this.rightsLabel.TabIndex = 20;
            this.rightsLabel.Text = "Rights:";
            // 
            // fundingTextBox
            // 
            this.fundingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fundingTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fundingTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fundingTextBox.Location = new System.Drawing.Point(153, 105);
            this.fundingTextBox.Multiline = true;
            this.fundingTextBox.Name = "fundingTextBox";
            this.fundingTextBox.Size = new System.Drawing.Size(520, 51);
            this.fundingTextBox.TabIndex = 1;
            this.fundingTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.fundingTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // individualGroupBox
            // 
            this.individualGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.individualGroupBox.Controls.Add(this.nameLabel);
            this.individualGroupBox.Controls.Add(this.nameTextBox);
            this.individualGroupBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.individualGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.individualGroupBox.Location = new System.Drawing.Point(16, 17);
            this.individualGroupBox.Name = "individualGroupBox";
            this.individualGroupBox.Size = new System.Drawing.Size(703, 77);
            this.individualGroupBox.TabIndex = 0;
            this.individualGroupBox.TabStop = false;
            this.individualGroupBox.Text = "Your Name ( or default name for individual creator of METS files )";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameLabel.Location = new System.Drawing.Point(26, 39);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 14);
            this.nameLabel.TabIndex = 21;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameTextBox.Location = new System.Drawing.Point(153, 36);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(520, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.nameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // sourceInstitutionGroupBox
            // 
            this.sourceInstitutionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceInstitutionGroupBox.Controls.Add(this.sourceCodeTextBox);
            this.sourceInstitutionGroupBox.Controls.Add(this.sourceStatementLabel);
            this.sourceInstitutionGroupBox.Controls.Add(this.sourceCodeLabel);
            this.sourceInstitutionGroupBox.Controls.Add(this.sourceStatementTextBox);
            this.sourceInstitutionGroupBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceInstitutionGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.sourceInstitutionGroupBox.Location = new System.Drawing.Point(16, 100);
            this.sourceInstitutionGroupBox.Name = "sourceInstitutionGroupBox";
            this.sourceInstitutionGroupBox.Size = new System.Drawing.Size(703, 123);
            this.sourceInstitutionGroupBox.TabIndex = 1;
            this.sourceInstitutionGroupBox.TabStop = false;
            this.sourceInstitutionGroupBox.Text = "Your Institution ( or default institution for source and holding location )  ";
            // 
            // sourceCodeTextBox
            // 
            this.sourceCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceCodeTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceCodeTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sourceCodeTextBox.Location = new System.Drawing.Point(153, 35);
            this.sourceCodeTextBox.Name = "sourceCodeTextBox";
            this.sourceCodeTextBox.Size = new System.Drawing.Size(145, 22);
            this.sourceCodeTextBox.TabIndex = 0;
            this.sourceCodeTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.sourceCodeTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // sourceStatementLabel
            // 
            this.sourceStatementLabel.AutoSize = true;
            this.sourceStatementLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceStatementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sourceStatementLabel.Location = new System.Drawing.Point(26, 78);
            this.sourceStatementLabel.Name = "sourceStatementLabel";
            this.sourceStatementLabel.Size = new System.Drawing.Size(98, 14);
            this.sourceStatementLabel.TabIndex = 21;
            this.sourceStatementLabel.Text = "Complete Name:";
            // 
            // sourceCodeLabel
            // 
            this.sourceCodeLabel.AutoSize = true;
            this.sourceCodeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceCodeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sourceCodeLabel.Location = new System.Drawing.Point(26, 38);
            this.sourceCodeLabel.Name = "sourceCodeLabel";
            this.sourceCodeLabel.Size = new System.Drawing.Size(121, 14);
            this.sourceCodeLabel.TabIndex = 20;
            this.sourceCodeLabel.Text = "Abbreviation (Code):";
            // 
            // sourceStatementTextBox
            // 
            this.sourceStatementTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceStatementTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceStatementTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sourceStatementTextBox.Location = new System.Drawing.Point(153, 75);
            this.sourceStatementTextBox.Name = "sourceStatementTextBox";
            this.sourceStatementTextBox.Size = new System.Drawing.Size(520, 22);
            this.sourceStatementTextBox.TabIndex = 1;
            this.sourceStatementTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.sourceStatementTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(739, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Initialization: Localization and Defaults";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "BACK";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(505, 477);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 2;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.Button_Enabled = true;
            this.continueButton.Button_Text = "COMPLETE";
            this.continueButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.continueButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(638, 477);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 3;
            this.continueButton.Button_Pressed += new System.EventHandler(this.continueButton_Button_Pressed);
            // 
            // First_Launch_Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(765, 515);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "First_Launch_Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: Localization and Defaults";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.individualGroupBox.ResumeLayout(false);
            this.individualGroupBox.PerformLayout();
            this.sourceInstitutionGroupBox.ResumeLayout(false);
            this.sourceInstitutionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox sourceInstitutionGroupBox;
        private System.Windows.Forms.TextBox sourceCodeTextBox;
        private System.Windows.Forms.Label sourceStatementLabel;
        private System.Windows.Forms.Label sourceCodeLabel;
        private System.Windows.Forms.TextBox sourceStatementTextBox;
        private System.Windows.Forms.GroupBox individualGroupBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rightsTextBox;
        private System.Windows.Forms.Label fundingLabel;
        private System.Windows.Forms.Label rightsLabel;
        private System.Windows.Forms.TextBox fundingTextBox;
    }
}