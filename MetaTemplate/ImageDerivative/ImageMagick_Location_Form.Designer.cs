namespace SobekCM.METS_Editor.ImageDerivative
{
    partial class ImageMagick_Location_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageMagick_Location_Form));
            this.round_Button2 = new SobekCM.METS_Editor.Forms.Round_Button();
            this.round_Button1 = new SobekCM.METS_Editor.Forms.Round_Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.databaseServerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorLabel2 = new System.Windows.Forms.Label();
            this.errorLabel1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // round_Button2
            // 
            this.round_Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.round_Button2.Button_Enabled = true;
            this.round_Button2.Button_Text = "";
            this.round_Button2.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.round_Button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_Button2.Location = new System.Drawing.Point(470, 263);
            this.round_Button2.Name = "round_Button2";
            this.round_Button2.Size = new System.Drawing.Size(96, 29);
            this.round_Button2.TabIndex = 11;
            this.round_Button2.Button_Pressed += new System.EventHandler(this.round_Button2_Button_Pressed);
            // 
            // round_Button1
            // 
            this.round_Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.round_Button1.Button_Enabled = true;
            this.round_Button1.Button_Text = "";
            this.round_Button1.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.round_Button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_Button1.Location = new System.Drawing.Point(356, 263);
            this.round_Button1.Name = "round_Button1";
            this.round_Button1.Size = new System.Drawing.Size(96, 29);
            this.round_Button1.TabIndex = 10;
            this.round_Button1.Button_Pressed += new System.EventHandler(this.round_Button1_Button_Pressed);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.databaseNameLabel);
            this.groupBox1.Controls.Add(this.locationTextBox);
            this.groupBox1.Controls.Add(this.databaseServerLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.errorLabel2);
            this.groupBox1.Controls.Add(this.errorLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 237);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ImageMagick Setting";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(433, 152);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 12;
            this.browseButton.Text = "BROWSE";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseNameLabel.Location = new System.Drawing.Point(58, 196);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(465, 36);
            this.databaseNameLabel.TabIndex = 11;
            this.databaseNameLabel.Text = "If you have added the ImageMagick directory to your path statement, you do not ne" +
                "ed to input the location, although it is still recommended.";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.Location = new System.Drawing.Point(138, 153);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(284, 22);
            this.locationTextBox.TabIndex = 10;
            this.locationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.locationTextBox_KeyDown);
            this.locationTextBox.Leave += new System.EventHandler(this.locationTextBox_Leave);
            this.locationTextBox.Enter += new System.EventHandler(this.locationTextBox_Enter);
            // 
            // databaseServerLabel
            // 
            this.databaseServerLabel.AutoSize = true;
            this.databaseServerLabel.Location = new System.Drawing.Point(75, 156);
            this.databaseServerLabel.Name = "databaseServerLabel";
            this.databaseServerLabel.Size = new System.Drawing.Size(57, 14);
            this.databaseServerLabel.TabIndex = 9;
            this.databaseServerLabel.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(417, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Navigate to the appropriate executable file below (usually convert.exe):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "1. Download and install the latest version of ImageMagick and restart your comput" +
                "er.";
            // 
            // errorLabel2
            // 
            this.errorLabel2.AutoSize = true;
            this.errorLabel2.Location = new System.Drawing.Point(22, 65);
            this.errorLabel2.Name = "errorLabel2";
            this.errorLabel2.Size = new System.Drawing.Size(162, 14);
            this.errorLabel2.TabIndex = 1;
            this.errorLabel2.Text = "To correct this issue, either:";
            // 
            // errorLabel1
            // 
            this.errorLabel1.AutoSize = true;
            this.errorLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel1.ForeColor = System.Drawing.Color.Red;
            this.errorLabel1.Location = new System.Drawing.Point(22, 32);
            this.errorLabel1.Name = "errorLabel1";
            this.errorLabel1.Size = new System.Drawing.Size(473, 18);
            this.errorLabel1.TabIndex = 0;
            this.errorLabel1.Text = "Unable to determine the path for the ImageMagick executable!";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.Filter = "ImageMagic|convert.exe|Any Executable File|*.exe";
            this.openFileDialog1.Title = "Select valid ImageMagick executable file.";
            // 
            // ImageMagick_Location_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 302);
            this.Controls.Add(this.round_Button2);
            this.Controls.Add(this.round_Button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 338);
            this.Name = "ImageMagick_Location_Form";
            this.Text = "ImageMagick Not Found";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button round_Button2;
        private SobekCM.METS_Editor.Forms.Round_Button round_Button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label databaseServerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorLabel2;
        private System.Windows.Forms.Label errorLabel1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}