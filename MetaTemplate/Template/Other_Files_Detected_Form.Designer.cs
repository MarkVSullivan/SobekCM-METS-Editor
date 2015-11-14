namespace SobekCM.METS_Editor.Template
{
    partial class Other_Files_Detected_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Other_Files_Detected_Form));
            this.mainLabel1 = new System.Windows.Forms.Label();
            this.mainLabel2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.downloadUrlButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.selectAllButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.addAllButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.alwaysCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainLabel1
            // 
            this.mainLabel1.AutoSize = true;
            this.mainLabel1.Location = new System.Drawing.Point(13, 13);
            this.mainLabel1.Name = "mainLabel1";
            this.mainLabel1.Size = new System.Drawing.Size(324, 14);
            this.mainLabel1.TabIndex = 0;
            this.mainLabel1.Text = "The following additional files were found in the directory. ";
            // 
            // mainLabel2
            // 
            this.mainLabel2.AutoSize = true;
            this.mainLabel2.Location = new System.Drawing.Point(12, 42);
            this.mainLabel2.Name = "mainLabel2";
            this.mainLabel2.Size = new System.Drawing.Size(287, 14);
            this.mainLabel2.TabIndex = 1;
            this.mainLabel2.Text = "Select the files you wish to include in this package.";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(12, 70);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 326);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // downloadUrlButton
            // 
            this.downloadUrlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadUrlButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadUrlButton.Button_Enabled = true;
            this.downloadUrlButton.Button_Text = "CONTINUE";
            this.downloadUrlButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.downloadUrlButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadUrlButton.Location = new System.Drawing.Point(418, 411);
            this.downloadUrlButton.Name = "downloadUrlButton";
            this.downloadUrlButton.Size = new System.Drawing.Size(119, 26);
            this.downloadUrlButton.TabIndex = 3;
            this.downloadUrlButton.Button_Pressed += new System.EventHandler(this.downloadUrlButton_Button_Pressed);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllButton.BackColor = System.Drawing.Color.Transparent;
            this.selectAllButton.Button_Enabled = true;
            this.selectAllButton.Button_Text = "SELECT ALL";
            this.selectAllButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.selectAllButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllButton.Location = new System.Drawing.Point(3, 411);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(119, 26);
            this.selectAllButton.TabIndex = 4;
            this.selectAllButton.Button_Pressed += new System.EventHandler(this.selectAllButton_Button_Pressed);
            // 
            // addAllButton
            // 
            this.addAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAllButton.BackColor = System.Drawing.Color.Transparent;
            this.addAllButton.Button_Enabled = true;
            this.addAllButton.Button_Text = "ADD ALL";
            this.addAllButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.addAllButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAllButton.Location = new System.Drawing.Point(140, 411);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(119, 26);
            this.addAllButton.TabIndex = 5;
            this.addAllButton.Button_Pressed += new System.EventHandler(this.addAllButton_Button_Pressed);
            // 
            // alwaysCheckBox
            // 
            this.alwaysCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alwaysCheckBox.AutoSize = true;
            this.alwaysCheckBox.Location = new System.Drawing.Point(15, 454);
            this.alwaysCheckBox.Name = "alwaysCheckBox";
            this.alwaysCheckBox.Size = new System.Drawing.Size(333, 18);
            this.alwaysCheckBox.TabIndex = 25;
            this.alwaysCheckBox.Text = "Always add all non-page images to new digital resources";
            this.alwaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // Other_Files_Detected_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(573, 480);
            this.Controls.Add(this.alwaysCheckBox);
            this.Controls.Add(this.addAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.downloadUrlButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.mainLabel2);
            this.Controls.Add(this.mainLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Other_Files_Detected_Form";
            this.Text = "METS Viewer and Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel1;
        private System.Windows.Forms.Label mainLabel2;
        private System.Windows.Forms.ListView listView1;
        private SobekCM.METS_Editor.Forms.Round_Button downloadUrlButton;
        private SobekCM.METS_Editor.Forms.Round_Button selectAllButton;
        private SobekCM.METS_Editor.Forms.Round_Button addAllButton;
        private System.Windows.Forms.CheckBox alwaysCheckBox;
    }
}