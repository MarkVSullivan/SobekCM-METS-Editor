namespace SobekCM.METS_Editor.Template
{
    partial class Existing_Subdirectories_Found_Dialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.alwaysCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.noButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.yesButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 14);
            this.label3.TabIndex = 33;
            this.label3.Text = "Would you like the option to include any files in these subdirectories?";
            // 
            // alwaysCheckBox
            // 
            this.alwaysCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alwaysCheckBox.AutoSize = true;
            this.alwaysCheckBox.Location = new System.Drawing.Point(90, 123);
            this.alwaysCheckBox.Name = "alwaysCheckBox";
            this.alwaysCheckBox.Size = new System.Drawing.Size(221, 18);
            this.alwaysCheckBox.TabIndex = 32;
            this.alwaysCheckBox.Text = "Always include files in subdirectories";
            this.alwaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "The directory you selected has subdirectories.";
            // 
            // noButton
            // 
            this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noButton.BackColor = System.Drawing.Color.Transparent;
            this.noButton.Button_Enabled = true;
            this.noButton.Button_Text = "NO";
            this.noButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.noButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.Location = new System.Drawing.Point(264, 80);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(94, 26);
            this.noButton.TabIndex = 29;
            this.noButton.Button_Pressed += new System.EventHandler(this.noButton_Button_Pressed);
            // 
            // yesButton
            // 
            this.yesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yesButton.BackColor = System.Drawing.Color.Transparent;
            this.yesButton.Button_Enabled = true;
            this.yesButton.Button_Text = "YES";
            this.yesButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.yesButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.Location = new System.Drawing.Point(148, 80);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(94, 26);
            this.yesButton.TabIndex = 28;
            this.yesButton.Button_Pressed += new System.EventHandler(this.yesButton_Button_Pressed);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SobekCM.METS_Editor.Properties.Resources.large_question_mark;
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // Existing_Subdirectories_Found_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(507, 153);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.alwaysCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Existing_Subdirectories_Found_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existing Subdirectories Found";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox alwaysCheckBox;
        private System.Windows.Forms.Label label1;
        private Forms.Round_Button noButton;
        private Forms.Round_Button yesButton;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}