namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form5));
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.alwaysAddPageImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.checksumsCheckBox = new System.Windows.Forms.CheckBox();
            this.sobekcmFileCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "BACK";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(408, 234);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 7;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.Button_Enabled = true;
            this.continueButton.Button_Text = "CONTINUE";
            this.continueButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.continueButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(541, 234);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 6;
            this.continueButton.Button_Pressed += new System.EventHandler(this.continueButton_Button_Pressed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.alwaysAddPageImagesCheckBox);
            this.panel1.Controls.Add(this.checksumsCheckBox);
            this.panel1.Controls.Add(this.sobekcmFileCheckBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 174);
            this.panel1.TabIndex = 5;
            // 
            // alwaysAddPageImagesCheckBox
            // 
            this.alwaysAddPageImagesCheckBox.AutoSize = true;
            this.alwaysAddPageImagesCheckBox.Location = new System.Drawing.Point(80, 62);
            this.alwaysAddPageImagesCheckBox.Name = "alwaysAddPageImagesCheckBox";
            this.alwaysAddPageImagesCheckBox.Size = new System.Drawing.Size(354, 18);
            this.alwaysAddPageImagesCheckBox.TabIndex = 30;
            this.alwaysAddPageImagesCheckBox.Text = "Always add all page images when creating a new METS file?";
            this.alwaysAddPageImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // checksumsCheckBox
            // 
            this.checksumsCheckBox.AutoSize = true;
            this.checksumsCheckBox.Location = new System.Drawing.Point(80, 96);
            this.checksumsCheckBox.Name = "checksumsCheckBox";
            this.checksumsCheckBox.Size = new System.Drawing.Size(172, 18);
            this.checksumsCheckBox.TabIndex = 29;
            this.checksumsCheckBox.Text = "Include checksums for files";
            this.checksumsCheckBox.UseVisualStyleBackColor = true;
            // 
            // sobekcmFileCheckBox
            // 
            this.sobekcmFileCheckBox.AutoSize = true;
            this.sobekcmFileCheckBox.Location = new System.Drawing.Point(80, 129);
            this.sobekcmFileCheckBox.Name = "sobekcmFileCheckBox";
            this.sobekcmFileCheckBox.Size = new System.Drawing.Size(287, 18);
            this.sobekcmFileCheckBox.TabIndex = 28;
            this.sobekcmFileCheckBox.Text = "Include SobekCM File Technical Specs Metadata";
            this.sobekcmFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select options below relating to adding and encoding resource files:";
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
            this.label3.Size = new System.Drawing.Size(642, 42);
            this.label3.TabIndex = 13;
            this.label3.Text = "Initialization: Resource Files";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // First_Launch_Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(668, 272);
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
            this.Name = "First_Launch_Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: Resource Files";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox alwaysAddPageImagesCheckBox;
        private System.Windows.Forms.CheckBox checksumsCheckBox;
        private System.Windows.Forms.CheckBox sobekcmFileCheckBox;
        private System.Windows.Forms.Label label3;
    }
}