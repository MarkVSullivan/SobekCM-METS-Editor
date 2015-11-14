namespace SobekCM.METS_Editor.Forms
{
    partial class Structure_Map_Checksum_Form
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
            this.clearChecksumsButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.calculateChecksumsButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clearChecksumsButton
            // 
            this.clearChecksumsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clearChecksumsButton.BackColor = System.Drawing.Color.Transparent;
            this.clearChecksumsButton.Button_Enabled = true;
            this.clearChecksumsButton.Button_Text = "CLEAR CHECKSUMS";
            this.clearChecksumsButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.clearChecksumsButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearChecksumsButton.Location = new System.Drawing.Point(38, 45);
            this.clearChecksumsButton.Name = "clearChecksumsButton";
            this.clearChecksumsButton.Size = new System.Drawing.Size(184, 28);
            this.clearChecksumsButton.TabIndex = 4;
            this.clearChecksumsButton.Button_Pressed += new System.EventHandler(this.clearChecksumsButton_Button_Pressed);
            // 
            // calculateChecksumsButton
            // 
            this.calculateChecksumsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateChecksumsButton.BackColor = System.Drawing.Color.Transparent;
            this.calculateChecksumsButton.Button_Enabled = true;
            this.calculateChecksumsButton.Button_Text = "CALCULATE CHECKSUMS";
            this.calculateChecksumsButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.calculateChecksumsButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateChecksumsButton.Location = new System.Drawing.Point(38, 101);
            this.calculateChecksumsButton.Name = "calculateChecksumsButton";
            this.calculateChecksumsButton.Size = new System.Drawing.Size(184, 28);
            this.calculateChecksumsButton.TabIndex = 5;
            this.calculateChecksumsButton.Button_Pressed += new System.EventHandler(this.calculateChecksumsButton_Button_Pressed);
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(149, 186);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(128, 28);
            this.cancelRoundButton.TabIndex = 6;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.clearChecksumsButton);
            this.groupBox1.Controls.Add(this.calculateChecksumsButton);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 165);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Possible Actions   ";
            // 
            // Structure_Map_Checksum_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(291, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelRoundButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Structure_Map_Checksum_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Structure Map Checksum Form";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Round_Button clearChecksumsButton;
        private Round_Button calculateChecksumsButton;
        private Round_Button cancelRoundButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}