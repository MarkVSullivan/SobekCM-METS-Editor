namespace SobekCM.METS_Editor.Forms
{
    partial class Z3950_Endpoint_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Z3950_Endpoint_Form));
            this.uriLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.dbNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.uriTextBox = new System.Windows.Forms.TextBox();
            this.authenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.authLabel2 = new System.Windows.Forms.Label();
            this.authLabel1 = new System.Windows.Forms.Label();
            this.mainLabel1 = new System.Windows.Forms.Label();
            this.mainLabel2 = new System.Windows.Forms.Label();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.connectButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.helpPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectionGroupBox.SuspendLayout();
            this.authenticationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uriLabel
            // 
            this.uriLabel.AutoSize = true;
            this.uriLabel.Location = new System.Drawing.Point(57, 43);
            this.uriLabel.Name = "uriLabel";
            this.uriLabel.Size = new System.Drawing.Size(30, 14);
            this.uriLabel.TabIndex = 1;
            this.uriLabel.Text = "URI:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(57, 76);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(34, 14);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Location = new System.Drawing.Point(57, 108);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(61, 14);
            this.dbNameLabel.TabIndex = 3;
            this.dbNameLabel.Text = "Database:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(57, 96);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(65, 14);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(57, 134);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(62, 14);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionGroupBox.Controls.Add(this.dbNameTextBox);
            this.connectionGroupBox.Controls.Add(this.portTextBox);
            this.connectionGroupBox.Controls.Add(this.uriTextBox);
            this.connectionGroupBox.Controls.Add(this.uriLabel);
            this.connectionGroupBox.Controls.Add(this.portLabel);
            this.connectionGroupBox.Controls.Add(this.dbNameLabel);
            this.connectionGroupBox.Location = new System.Drawing.Point(18, 74);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(438, 157);
            this.connectionGroupBox.TabIndex = 0;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "Z39.50 Endpoint Connection Information";
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.Location = new System.Drawing.Point(124, 105);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(260, 22);
            this.dbNameTextBox.TabIndex = 6;
            this.dbNameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.dbNameTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(123, 73);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(51, 22);
            this.portTextBox.TabIndex = 5;
            this.portTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.portTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // uriTextBox
            // 
            this.uriTextBox.Location = new System.Drawing.Point(123, 40);
            this.uriTextBox.Name = "uriTextBox";
            this.uriTextBox.Size = new System.Drawing.Size(260, 22);
            this.uriTextBox.TabIndex = 4;
            this.uriTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.uriTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // authenticationGroupBox
            // 
            this.authenticationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.authenticationGroupBox.Controls.Add(this.passwordTextBox);
            this.authenticationGroupBox.Controls.Add(this.usernameTextBox);
            this.authenticationGroupBox.Controls.Add(this.authLabel2);
            this.authenticationGroupBox.Controls.Add(this.authLabel1);
            this.authenticationGroupBox.Controls.Add(this.usernameLabel);
            this.authenticationGroupBox.Controls.Add(this.passwordLabel);
            this.authenticationGroupBox.Location = new System.Drawing.Point(18, 247);
            this.authenticationGroupBox.Name = "authenticationGroupBox";
            this.authenticationGroupBox.Size = new System.Drawing.Size(438, 174);
            this.authenticationGroupBox.TabIndex = 1;
            this.authenticationGroupBox.TabStop = false;
            this.authenticationGroupBox.Text = "Z39.50 Endpoint Authentication Information";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(128, 131);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(148, 22);
            this.passwordTextBox.TabIndex = 9;
            this.passwordTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(128, 93);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(148, 22);
            this.usernameTextBox.TabIndex = 8;
            this.usernameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.usernameTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // authLabel2
            // 
            this.authLabel2.AutoSize = true;
            this.authLabel2.Location = new System.Drawing.Point(20, 55);
            this.authLabel2.Name = "authLabel2";
            this.authLabel2.Size = new System.Drawing.Size(153, 14);
            this.authLabel2.TabIndex = 7;
            this.authLabel2.Text = "case this can be left blank.";
            // 
            // authLabel1
            // 
            this.authLabel1.AutoSize = true;
            this.authLabel1.Location = new System.Drawing.Point(20, 29);
            this.authLabel1.Name = "authLabel1";
            this.authLabel1.Size = new System.Drawing.Size(362, 14);
            this.authLabel1.TabIndex = 6;
            this.authLabel1.Text = "Many Z39.50 services do not require any authentication in which";
            // 
            // mainLabel1
            // 
            this.mainLabel1.AutoSize = true;
            this.mainLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mainLabel1.Location = new System.Drawing.Point(15, 16);
            this.mainLabel1.Name = "mainLabel1";
            this.mainLabel1.Size = new System.Drawing.Size(410, 14);
            this.mainLabel1.TabIndex = 8;
            this.mainLabel1.Text = "Enter the connection and any authentication information for this";
            // 
            // mainLabel2
            // 
            this.mainLabel2.AutoSize = true;
            this.mainLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mainLabel2.Location = new System.Drawing.Point(15, 42);
            this.mainLabel2.Name = "mainLabel2";
            this.mainLabel2.Size = new System.Drawing.Size(193, 14);
            this.mainLabel2.TabIndex = 9;
            this.mainLabel2.Text = "user-specific Z39.50 endpoint.";
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(137, 504);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 2;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "SAVE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(268, 504);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.BackColor = System.Drawing.Color.Transparent;
            this.connectButton.Button_Enabled = true;
            this.connectButton.Button_Text = "CONNECT";
            this.connectButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.connectButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(364, 504);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(113, 26);
            this.connectButton.TabIndex = 4;
            this.connectButton.Button_Pressed += new System.EventHandler(this.connectButton_Button_Pressed);
            // 
            // helpPictureBox
            // 
            this.helpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.helpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPictureBox.Image = global::SobekCM.METS_Editor.Properties.Resources.help_button1;
            this.helpPictureBox.Location = new System.Drawing.Point(456, 16);
            this.helpPictureBox.Name = "helpPictureBox";
            this.helpPictureBox.Size = new System.Drawing.Size(24, 24);
            this.helpPictureBox.TabIndex = 26;
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
            this.titleLabel.Location = new System.Drawing.Point(41, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(403, 42);
            this.titleLabel.TabIndex = 25;
            this.titleLabel.Text = "Z39.50 Service Endpoint";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.connectionGroupBox);
            this.panel1.Controls.Add(this.mainLabel1);
            this.panel1.Controls.Add(this.mainLabel2);
            this.panel1.Controls.Add(this.authenticationGroupBox);
            this.panel1.Location = new System.Drawing.Point(11, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 442);
            this.panel1.TabIndex = 1;
            // 
            // Z3950_Endpoint_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(496, 542);
            this.Controls.Add(this.helpPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Z3950_Endpoint_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Z39.50 Endpoint Form";
            this.connectionGroupBox.ResumeLayout(false);
            this.connectionGroupBox.PerformLayout();
            this.authenticationGroupBox.ResumeLayout(false);
            this.authenticationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uriLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label dbNameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.Label authLabel1;
        private System.Windows.Forms.Label authLabel2;
        private System.Windows.Forms.Label mainLabel1;
        private System.Windows.Forms.Label mainLabel2;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox uriTextBox;
        private System.Windows.Forms.GroupBox authenticationGroupBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private Round_Button cancelRoundButton;
        private Round_Button saveButton;
        private Round_Button connectButton;
        private System.Windows.Forms.PictureBox helpPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
    }
}