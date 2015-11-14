namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form4));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.instructionLabel2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.instructionLabel2);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.instructionLabel);
            this.mainPanel.Location = new System.Drawing.Point(12, 54);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(685, 400);
            this.mainPanel.TabIndex = 5;
            // 
            // instructionLabel2
            // 
            this.instructionLabel2.AutoSize = true;
            this.instructionLabel2.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.instructionLabel2.Location = new System.Drawing.Point(24, 43);
            this.instructionLabel2.Name = "instructionLabel2";
            this.instructionLabel2.Size = new System.Drawing.Size(462, 14);
            this.instructionLabel2.TabIndex = 9;
            this.instructionLabel2.Text = "the template and generally support more specialized or custom metadata.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 323);
            this.panel1.TabIndex = 8;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.instructionLabel.Location = new System.Drawing.Point(24, 19);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(605, 14);
            this.instructionLabel.TabIndex = 6;
            this.instructionLabel.Text = "Select add-ons to include in the metadata template below.  These options add addi" +
                "tional tabs to";
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "BACK";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(451, 460);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 9;
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
            this.continueButton.Location = new System.Drawing.Point(584, 460);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 8;
            this.continueButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(689, 42);
            this.label3.TabIndex = 12;
            this.label3.Text = "Initialization: Select Template Add-Ons";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // First_Launch_Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(709, 498);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(725, 514);
            this.Name = "First_Launch_Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: Select Template Add-Ons";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label instructionLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label instructionLabel2;
        private System.Windows.Forms.Label label3;
    }
}