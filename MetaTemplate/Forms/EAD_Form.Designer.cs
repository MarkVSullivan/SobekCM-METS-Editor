namespace SobekCM.METS_Editor.Forms
{
    partial class EAD_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EAD_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Controls.Add(this.urlLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 103);
            this.panel1.TabIndex = 3;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.BackColor = System.Drawing.Color.White;
            this.urlTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.urlTextBox.Location = new System.Drawing.Point(102, 55);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(433, 22);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.urlTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(18, 58);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(59, 14);
            this.urlLabel.TabIndex = 13;
            this.urlLabel.Text = "EAD URL:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nameTextBox.Location = new System.Drawing.Point(102, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(433, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.nameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(18, 19);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(69, 14);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "EAD Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(352, 125);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 26);
            this.cancelButton.TabIndex = 4;
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
            this.saveButton.Location = new System.Drawing.Point(472, 125);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 5;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(255, 199);
            this.hiddenSaveButton.Name = "hiddenSaveButton";
            this.hiddenSaveButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenSaveButton.TabIndex = 13;
            this.hiddenSaveButton.TabStop = false;
            this.hiddenSaveButton.UseVisualStyleBackColor = true;
            this.hiddenSaveButton.Click += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(224, 199);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 12;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // EAD_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(597, 161);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EAD_Form";
            this.Text = "Edit EAD (Finding Guide) Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}