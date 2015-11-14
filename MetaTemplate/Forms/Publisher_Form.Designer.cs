namespace SobekCM.METS_Editor.Forms
{
    partial class Publisher_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publisher_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.location4TextBox = new System.Windows.Forms.TextBox();
            this.location3TextBox = new System.Windows.Forms.TextBox();
            this.location2TextBox = new System.Windows.Forms.TextBox();
            this.location1TextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.location4TextBox);
            this.panel1.Controls.Add(this.location3TextBox);
            this.panel1.Controls.Add(this.location2TextBox);
            this.panel1.Controls.Add(this.location1TextBox);
            this.panel1.Controls.Add(this.locationLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 135);
            this.panel1.TabIndex = 0;
            // 
            // location4TextBox
            // 
            this.location4TextBox.BackColor = System.Drawing.Color.White;
            this.location4TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.location4TextBox.Location = new System.Drawing.Point(373, 92);
            this.location4TextBox.Name = "location4TextBox";
            this.location4TextBox.Size = new System.Drawing.Size(255, 22);
            this.location4TextBox.TabIndex = 4;
            this.location4TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.location4TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // location3TextBox
            // 
            this.location3TextBox.BackColor = System.Drawing.Color.White;
            this.location3TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.location3TextBox.Location = new System.Drawing.Point(373, 64);
            this.location3TextBox.Name = "location3TextBox";
            this.location3TextBox.Size = new System.Drawing.Size(255, 22);
            this.location3TextBox.TabIndex = 2;
            this.location3TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.location3TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // location2TextBox
            // 
            this.location2TextBox.BackColor = System.Drawing.Color.White;
            this.location2TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.location2TextBox.Location = new System.Drawing.Point(102, 92);
            this.location2TextBox.Name = "location2TextBox";
            this.location2TextBox.Size = new System.Drawing.Size(255, 22);
            this.location2TextBox.TabIndex = 3;
            this.location2TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.location2TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // location1TextBox
            // 
            this.location1TextBox.BackColor = System.Drawing.Color.White;
            this.location1TextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.location1TextBox.Location = new System.Drawing.Point(102, 64);
            this.location1TextBox.Name = "location1TextBox";
            this.location1TextBox.Size = new System.Drawing.Size(255, 22);
            this.location1TextBox.TabIndex = 1;
            this.location1TextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.location1TextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(18, 81);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(62, 14);
            this.locationLabel.TabIndex = 13;
            this.locationLabel.Text = "Locations:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.nameTextBox.Location = new System.Drawing.Point(102, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(526, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.nameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(18, 19);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 14);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(438, 158);
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
            this.saveButton.Location = new System.Drawing.Point(558, 158);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(272, 253);
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
            this.hiddenCancelButton.Location = new System.Drawing.Point(241, 253);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Publisher_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(685, 195);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Publisher_Form";
            this.Text = "Edit Publisher Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox location4TextBox;
        private System.Windows.Forms.TextBox location3TextBox;
        private System.Windows.Forms.TextBox location2TextBox;
        private System.Windows.Forms.TextBox location1TextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}