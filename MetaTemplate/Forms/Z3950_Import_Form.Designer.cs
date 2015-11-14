namespace SobekCM.METS_Editor.Forms
{
    partial class Z3950_Import_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Z3950_Import_Form));
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.importButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.identifierTextBox = new System.Windows.Forms.TextBox();
            this.newEditButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.endpointComboBox = new System.Windows.Forms.ComboBox();
            this.mainLabel3 = new System.Windows.Forms.Label();
            this.mainLabel1 = new System.Windows.Forms.Label();
            this.mainLabel2 = new System.Windows.Forms.Label();
            this.identifierLabel = new System.Windows.Forms.Label();
            this.endpointLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(503, 16);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 18;
            this.helpPictureBox.TabStop = false;
            this.helpPictureBox.Click += new System.EventHandler(this.helpPictureBox_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.titleLabel.Location = new System.Drawing.Point(40, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(451, 42);
            this.titleLabel.TabIndex = 17;
            this.titleLabel.Text = "Z39.50 Record Import";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.BackColor = System.Drawing.Color.Transparent;
            this.importButton.Button_Enabled = true;
            this.importButton.Button_Text = "IMPORT";
            this.importButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.importButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(433, 296);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(94, 26);
            this.importButton.TabIndex = 16;
            this.importButton.Button_Pressed += new System.EventHandler(this.importButton_Button_Pressed);
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(321, 296);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(94, 26);
            this.cancelRoundButton.TabIndex = 15;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.identifierTextBox);
            this.panel1.Controls.Add(this.newEditButton);
            this.panel1.Controls.Add(this.endpointComboBox);
            this.panel1.Controls.Add(this.mainLabel3);
            this.panel1.Controls.Add(this.mainLabel1);
            this.panel1.Controls.Add(this.mainLabel2);
            this.panel1.Controls.Add(this.identifierLabel);
            this.panel1.Controls.Add(this.endpointLabel);
            this.panel1.Location = new System.Drawing.Point(10, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 238);
            this.panel1.TabIndex = 14;
            // 
            // identifierTextBox
            // 
            this.identifierTextBox.Location = new System.Drawing.Point(140, 169);
            this.identifierTextBox.Name = "identifierTextBox";
            this.identifierTextBox.Size = new System.Drawing.Size(194, 22);
            this.identifierTextBox.TabIndex = 24;
            // 
            // newEditButton
            // 
            this.newEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newEditButton.BackColor = System.Drawing.Color.Transparent;
            this.newEditButton.Button_Enabled = true;
            this.newEditButton.Button_Text = "EDIT";
            this.newEditButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.newEditButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEditButton.Location = new System.Drawing.Point(396, 116);
            this.newEditButton.Name = "newEditButton";
            this.newEditButton.Size = new System.Drawing.Size(94, 26);
            this.newEditButton.TabIndex = 23;
            this.newEditButton.Button_Pressed += new System.EventHandler(this.newEditButton_Button_Pressed);
            // 
            // endpointComboBox
            // 
            this.endpointComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endpointComboBox.FormattingEnabled = true;
            this.endpointComboBox.Location = new System.Drawing.Point(183, 120);
            this.endpointComboBox.Name = "endpointComboBox";
            this.endpointComboBox.Size = new System.Drawing.Size(184, 22);
            this.endpointComboBox.Sorted = true;
            this.endpointComboBox.TabIndex = 22;
            this.endpointComboBox.SelectedIndexChanged += new System.EventHandler(this.endpointComboBox_SelectedIndexChanged);
            // 
            // mainLabel3
            // 
            this.mainLabel3.AutoSize = true;
            this.mainLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mainLabel3.Location = new System.Drawing.Point(15, 70);
            this.mainLabel3.Name = "mainLabel3";
            this.mainLabel3.Size = new System.Drawing.Size(170, 14);
            this.mainLabel3.TabIndex = 21;
            this.mainLabel3.Text = "primary identifer USE case.";
            // 
            // mainLabel1
            // 
            this.mainLabel1.AutoSize = true;
            this.mainLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mainLabel1.Location = new System.Drawing.Point(15, 17);
            this.mainLabel1.Name = "mainLabel1";
            this.mainLabel1.Size = new System.Drawing.Size(468, 14);
            this.mainLabel1.TabIndex = 19;
            this.mainLabel1.Text = "This form allows a MARC record to be pulled via Z39.50 from a valid service";
            // 
            // mainLabel2
            // 
            this.mainLabel2.AutoSize = true;
            this.mainLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mainLabel2.Location = new System.Drawing.Point(15, 43);
            this.mainLabel2.Name = "mainLabel2";
            this.mainLabel2.Size = new System.Drawing.Size(469, 14);
            this.mainLabel2.TabIndex = 20;
            this.mainLabel2.Text = "endpoint.  Currently you can only specify the record to be imported by the";
            // 
            // identifierLabel
            // 
            this.identifierLabel.AutoSize = true;
            this.identifierLabel.Location = new System.Drawing.Point(31, 172);
            this.identifierLabel.Name = "identifierLabel";
            this.identifierLabel.Size = new System.Drawing.Size(103, 14);
            this.identifierLabel.TabIndex = 1;
            this.identifierLabel.Text = "Primary Identifier:";
            // 
            // endpointLabel
            // 
            this.endpointLabel.AutoSize = true;
            this.endpointLabel.Location = new System.Drawing.Point(31, 123);
            this.endpointLabel.Name = "endpointLabel";
            this.endpointLabel.Size = new System.Drawing.Size(146, 14);
            this.endpointLabel.TabIndex = 0;
            this.endpointLabel.Text = "Z39.50 Service Endpoint:";
            // 
            // Z3950_Import_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(539, 330);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Z3950_Import_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Z39.50 Record Import Form";
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private Round_Button importButton;
        private Round_Button cancelRoundButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label identifierLabel;
        private System.Windows.Forms.Label endpointLabel;
        private System.Windows.Forms.TextBox identifierTextBox;
        private Round_Button newEditButton;
        private System.Windows.Forms.ComboBox endpointComboBox;
        private System.Windows.Forms.Label mainLabel3;
        private System.Windows.Forms.Label mainLabel1;
        private System.Windows.Forms.Label mainLabel2;
    }
}