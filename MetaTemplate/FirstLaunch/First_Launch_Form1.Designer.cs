namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.standaloneRadioButton = new System.Windows.Forms.RadioButton();
            this.fclaRadioButton = new System.Windows.Forms.RadioButton();
            this.sobekRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.urlLabel = new System.Windows.Forms.Label();
            this.round_Button1 = new SobekCM.METS_Editor.Forms.Round_Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.standaloneRadioButton);
            this.panel1.Controls.Add(this.fclaRadioButton);
            this.panel1.Controls.Add(this.sobekRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 214);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(449, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "This will set some default values, which you will be able to change later.";
            // 
            // standaloneRadioButton
            // 
            this.standaloneRadioButton.AutoSize = true;
            this.standaloneRadioButton.Location = new System.Drawing.Point(73, 163);
            this.standaloneRadioButton.Name = "standaloneRadioButton";
            this.standaloneRadioButton.Size = new System.Drawing.Size(327, 18);
            this.standaloneRadioButton.TabIndex = 8;
            this.standaloneRadioButton.Text = "I am using this as a stand-alone tool for METS creation.";
            this.standaloneRadioButton.UseVisualStyleBackColor = true;
            // 
            // fclaRadioButton
            // 
            this.fclaRadioButton.AutoSize = true;
            this.fclaRadioButton.Location = new System.Drawing.Point(73, 127);
            this.fclaRadioButton.Name = "fclaRadioButton";
            this.fclaRadioButton.Size = new System.Drawing.Size(490, 18);
            this.fclaRadioButton.TabIndex = 7;
            this.fclaRadioButton.Text = "I will use this in support of the Florida Digital Archive and/or the PALMM digita" +
                "l library.";
            this.fclaRadioButton.UseVisualStyleBackColor = true;
            // 
            // sobekRadioButton
            // 
            this.sobekRadioButton.AutoSize = true;
            this.sobekRadioButton.Location = new System.Drawing.Point(73, 92);
            this.sobekRadioButton.Name = "sobekRadioButton";
            this.sobekRadioButton.Size = new System.Drawing.Size(454, 18);
            this.sobekRadioButton.TabIndex = 6;
            this.sobekRadioButton.Text = "I will use this in support of a SobekCM digital library ( i.e., UFDC, dLOC, etc.." +
                " ).";
            this.sobekRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(649, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the option below which best describes your expected use of this applicatio" +
                "n and press CONTINUE.";
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.Button_Enabled = true;
            this.continueButton.Button_Text = "CONTINUE";
            this.continueButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.continueButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(591, 274);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 2;
            this.continueButton.Button_Pressed += new System.EventHandler(this.continueButton_Button_Pressed);
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(458, 274);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 4;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // urlLabel
            // 
            this.urlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.urlLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.urlLabel.Location = new System.Drawing.Point(12, 9);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(692, 42);
            this.urlLabel.TabIndex = 5;
            this.urlLabel.Text = "Initialization: General Use";
            this.urlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // round_Button1
            // 
            this.round_Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.round_Button1.BackColor = System.Drawing.Color.Transparent;
            this.round_Button1.Button_Enabled = true;
            this.round_Button1.Button_Text = "IMPORT SETTINGS";
            this.round_Button1.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.round_Button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_Button1.Location = new System.Drawing.Point(12, 274);
            this.round_Button1.Name = "round_Button1";
            this.round_Button1.Size = new System.Drawing.Size(167, 26);
            this.round_Button1.TabIndex = 9;
            this.round_Button1.Button_Pressed += new System.EventHandler(this.round_Button1_Button_Pressed);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Config files|*.config\"";
            this.openFileDialog1.Title = "Select settings file to import";
            // 
            // First_Launch_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(716, 312);
            this.ControlBox = false;
            this.Controls.Add(this.round_Button1);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "First_Launch_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: General Use";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton fclaRadioButton;
        private System.Windows.Forms.RadioButton sobekRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton standaloneRadioButton;
        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label label2;
        private SobekCM.METS_Editor.Forms.Round_Button round_Button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}