namespace SobekCM.METS_Editor
{
    partial class Show_XML_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show_XML_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.showMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(15, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 534);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 22);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(617, 532);
            this.webBrowser1.TabIndex = 0;
            // 
            // showMetadataCheckBox
            // 
            this.showMetadataCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showMetadataCheckBox.AutoSize = true;
            this.showMetadataCheckBox.Checked = true;
            this.showMetadataCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMetadataCheckBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMetadataCheckBox.Location = new System.Drawing.Point(15, 562);
            this.showMetadataCheckBox.Name = "showMetadataCheckBox";
            this.showMetadataCheckBox.Size = new System.Drawing.Size(225, 18);
            this.showMetadataCheckBox.TabIndex = 7;
            this.showMetadataCheckBox.Text = "Always show metadata after saving?";
            this.showMetadataCheckBox.UseVisualStyleBackColor = true;
            this.showMetadataCheckBox.CheckedChanged += new System.EventHandler(this.showMetadataCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "CLOSE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(535, 557);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 6;
            this.saveButton.Button_Pressed += new System.EventHandler(this.closeButton_Click);
            // 
            // Show_XML_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 592);
            this.Controls.Add(this.showMetadataCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Show_XML_Form";
            this.Text = "Show_XML_Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.CheckBox showMetadataCheckBox;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;

    }
}