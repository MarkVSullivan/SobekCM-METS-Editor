namespace SobekCM.METS_Editor.OAI
{
    partial class Repository_Details_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repository_Details_Form));
            this.closeButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.metadataLabel = new System.Windows.Forms.Label();
            this.staticMetadataLabel = new System.Windows.Forms.Label();
            this.sampleIdLabel = new System.Windows.Forms.Label();
            this.delimiterLabel = new System.Windows.Forms.Label();
            this.staticSampleIdLabel = new System.Windows.Forms.Label();
            this.staticDelimiterLabel = new System.Windows.Forms.Label();
            this.granularityLabel = new System.Windows.Forms.Label();
            this.deleteRecordLabel = new System.Windows.Forms.Label();
            this.staticGranularityLabel = new System.Windows.Forms.Label();
            this.staticDeleteRecordLabel = new System.Windows.Forms.Label();
            this.datestampLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.staticDatestampLabel = new System.Windows.Forms.Label();
            this.staticEmailLabel = new System.Windows.Forms.Label();
            this.protocolLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.staticProtocolLabel = new System.Windows.Forms.Label();
            this.staticUrlLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.staticIdLabel = new System.Windows.Forms.Label();
            this.staticNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.Button_Enabled = true;
            this.closeButton.Button_Text = "CLOSE";
            this.closeButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.closeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(548, 531);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(113, 26);
            this.closeButton.TabIndex = 15;
            this.closeButton.Button_Pressed += new System.EventHandler(this.closeButton_Button_Pressed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.metadataLabel);
            this.panel1.Controls.Add(this.staticMetadataLabel);
            this.panel1.Controls.Add(this.sampleIdLabel);
            this.panel1.Controls.Add(this.delimiterLabel);
            this.panel1.Controls.Add(this.staticSampleIdLabel);
            this.panel1.Controls.Add(this.staticDelimiterLabel);
            this.panel1.Controls.Add(this.granularityLabel);
            this.panel1.Controls.Add(this.deleteRecordLabel);
            this.panel1.Controls.Add(this.staticGranularityLabel);
            this.panel1.Controls.Add(this.staticDeleteRecordLabel);
            this.panel1.Controls.Add(this.datestampLabel);
            this.panel1.Controls.Add(this.emailLabel);
            this.panel1.Controls.Add(this.staticDatestampLabel);
            this.panel1.Controls.Add(this.staticEmailLabel);
            this.panel1.Controls.Add(this.protocolLabel);
            this.panel1.Controls.Add(this.urlLabel);
            this.panel1.Controls.Add(this.staticProtocolLabel);
            this.panel1.Controls.Add(this.staticUrlLabel);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.staticIdLabel);
            this.panel1.Controls.Add(this.staticNameLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 513);
            this.panel1.TabIndex = 13;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(58, 344);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(572, 152);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Set Code";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Set Name";
            this.columnHeader2.Width = 446;
            // 
            // metadataLabel
            // 
            this.metadataLabel.AutoSize = true;
            this.metadataLabel.Location = new System.Drawing.Point(210, 315);
            this.metadataLabel.Name = "metadataLabel";
            this.metadataLabel.Size = new System.Drawing.Size(37, 14);
            this.metadataLabel.TabIndex = 27;
            this.metadataLabel.Text = "Value";
            // 
            // staticMetadataLabel
            // 
            this.staticMetadataLabel.AutoSize = true;
            this.staticMetadataLabel.Location = new System.Drawing.Point(55, 315);
            this.staticMetadataLabel.Name = "staticMetadataLabel";
            this.staticMetadataLabel.Size = new System.Drawing.Size(109, 14);
            this.staticMetadataLabel.TabIndex = 26;
            this.staticMetadataLabel.Text = "Metadata Formats:";
            // 
            // sampleIdLabel
            // 
            this.sampleIdLabel.AutoSize = true;
            this.sampleIdLabel.Location = new System.Drawing.Point(210, 289);
            this.sampleIdLabel.Name = "sampleIdLabel";
            this.sampleIdLabel.Size = new System.Drawing.Size(37, 14);
            this.sampleIdLabel.TabIndex = 25;
            this.sampleIdLabel.Text = "Value";
            // 
            // delimiterLabel
            // 
            this.delimiterLabel.AutoSize = true;
            this.delimiterLabel.Location = new System.Drawing.Point(210, 263);
            this.delimiterLabel.Name = "delimiterLabel";
            this.delimiterLabel.Size = new System.Drawing.Size(37, 14);
            this.delimiterLabel.TabIndex = 24;
            this.delimiterLabel.Text = "Value";
            // 
            // staticSampleIdLabel
            // 
            this.staticSampleIdLabel.AutoSize = true;
            this.staticSampleIdLabel.Location = new System.Drawing.Point(55, 289);
            this.staticSampleIdLabel.Name = "staticSampleIdLabel";
            this.staticSampleIdLabel.Size = new System.Drawing.Size(103, 14);
            this.staticSampleIdLabel.TabIndex = 23;
            this.staticSampleIdLabel.Text = "Sample Identifier:";
            // 
            // staticDelimiterLabel
            // 
            this.staticDelimiterLabel.AutoSize = true;
            this.staticDelimiterLabel.Location = new System.Drawing.Point(55, 263);
            this.staticDelimiterLabel.Name = "staticDelimiterLabel";
            this.staticDelimiterLabel.Size = new System.Drawing.Size(58, 14);
            this.staticDelimiterLabel.TabIndex = 22;
            this.staticDelimiterLabel.Text = "Delimiter:";
            // 
            // granularityLabel
            // 
            this.granularityLabel.AutoSize = true;
            this.granularityLabel.Location = new System.Drawing.Point(210, 237);
            this.granularityLabel.Name = "granularityLabel";
            this.granularityLabel.Size = new System.Drawing.Size(37, 14);
            this.granularityLabel.TabIndex = 21;
            this.granularityLabel.Text = "Value";
            // 
            // deleteRecordLabel
            // 
            this.deleteRecordLabel.AutoSize = true;
            this.deleteRecordLabel.Location = new System.Drawing.Point(210, 211);
            this.deleteRecordLabel.Name = "deleteRecordLabel";
            this.deleteRecordLabel.Size = new System.Drawing.Size(37, 14);
            this.deleteRecordLabel.TabIndex = 20;
            this.deleteRecordLabel.Text = "Value";
            // 
            // staticGranularityLabel
            // 
            this.staticGranularityLabel.AutoSize = true;
            this.staticGranularityLabel.Location = new System.Drawing.Point(55, 237);
            this.staticGranularityLabel.Name = "staticGranularityLabel";
            this.staticGranularityLabel.Size = new System.Drawing.Size(68, 14);
            this.staticGranularityLabel.TabIndex = 19;
            this.staticGranularityLabel.Text = "Granularity:";
            // 
            // staticDeleteRecordLabel
            // 
            this.staticDeleteRecordLabel.AutoSize = true;
            this.staticDeleteRecordLabel.Location = new System.Drawing.Point(55, 211);
            this.staticDeleteRecordLabel.Name = "staticDeleteRecordLabel";
            this.staticDeleteRecordLabel.Size = new System.Drawing.Size(89, 14);
            this.staticDeleteRecordLabel.TabIndex = 18;
            this.staticDeleteRecordLabel.Text = "Delete Record:";
            // 
            // datestampLabel
            // 
            this.datestampLabel.AutoSize = true;
            this.datestampLabel.Location = new System.Drawing.Point(210, 185);
            this.datestampLabel.Name = "datestampLabel";
            this.datestampLabel.Size = new System.Drawing.Size(37, 14);
            this.datestampLabel.TabIndex = 17;
            this.datestampLabel.Text = "Value";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(210, 159);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(37, 14);
            this.emailLabel.TabIndex = 16;
            this.emailLabel.Text = "Value";
            // 
            // staticDatestampLabel
            // 
            this.staticDatestampLabel.AutoSize = true;
            this.staticDatestampLabel.Location = new System.Drawing.Point(55, 185);
            this.staticDatestampLabel.Name = "staticDatestampLabel";
            this.staticDatestampLabel.Size = new System.Drawing.Size(112, 14);
            this.staticDatestampLabel.TabIndex = 15;
            this.staticDatestampLabel.Text = "Earliest Datestamp:";
            // 
            // staticEmailLabel
            // 
            this.staticEmailLabel.AutoSize = true;
            this.staticEmailLabel.Location = new System.Drawing.Point(55, 159);
            this.staticEmailLabel.Name = "staticEmailLabel";
            this.staticEmailLabel.Size = new System.Drawing.Size(76, 14);
            this.staticEmailLabel.TabIndex = 14;
            this.staticEmailLabel.Text = "Admin Email:";
            // 
            // protocolLabel
            // 
            this.protocolLabel.AutoSize = true;
            this.protocolLabel.Location = new System.Drawing.Point(210, 133);
            this.protocolLabel.Name = "protocolLabel";
            this.protocolLabel.Size = new System.Drawing.Size(37, 14);
            this.protocolLabel.TabIndex = 13;
            this.protocolLabel.Text = "Value";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(210, 107);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(37, 14);
            this.urlLabel.TabIndex = 12;
            this.urlLabel.Text = "Value";
            // 
            // staticProtocolLabel
            // 
            this.staticProtocolLabel.AutoSize = true;
            this.staticProtocolLabel.Location = new System.Drawing.Point(55, 133);
            this.staticProtocolLabel.Name = "staticProtocolLabel";
            this.staticProtocolLabel.Size = new System.Drawing.Size(100, 14);
            this.staticProtocolLabel.TabIndex = 11;
            this.staticProtocolLabel.Text = "Protocol Version:";
            // 
            // staticUrlLabel
            // 
            this.staticUrlLabel.AutoSize = true;
            this.staticUrlLabel.Location = new System.Drawing.Point(55, 107);
            this.staticUrlLabel.Name = "staticUrlLabel";
            this.staticUrlLabel.Size = new System.Drawing.Size(61, 14);
            this.staticUrlLabel.TabIndex = 10;
            this.staticUrlLabel.Text = "Base URL:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(210, 81);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(37, 14);
            this.idLabel.TabIndex = 9;
            this.idLabel.Text = "Value";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(210, 55);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(37, 14);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Value";
            // 
            // staticIdLabel
            // 
            this.staticIdLabel.AutoSize = true;
            this.staticIdLabel.Location = new System.Drawing.Point(55, 81);
            this.staticIdLabel.Name = "staticIdLabel";
            this.staticIdLabel.Size = new System.Drawing.Size(121, 14);
            this.staticIdLabel.TabIndex = 7;
            this.staticIdLabel.Text = "Repository Identifier:";
            // 
            // staticNameLabel
            // 
            this.staticNameLabel.AutoSize = true;
            this.staticNameLabel.Location = new System.Drawing.Point(55, 55);
            this.staticNameLabel.Name = "staticNameLabel";
            this.staticNameLabel.Size = new System.Drawing.Size(103, 14);
            this.staticNameLabel.TabIndex = 6;
            this.staticNameLabel.Text = "Repository Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Below is the information about the OAI-PMH repository you selected:";
            // 
            // Repository_Details_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "Repository_Details_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METS Editor - OAI-PMH Repository Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button closeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label protocolLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label staticProtocolLabel;
        private System.Windows.Forms.Label staticUrlLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label staticIdLabel;
        private System.Windows.Forms.Label staticNameLabel;
        private System.Windows.Forms.Label granularityLabel;
        private System.Windows.Forms.Label deleteRecordLabel;
        private System.Windows.Forms.Label staticGranularityLabel;
        private System.Windows.Forms.Label staticDeleteRecordLabel;
        private System.Windows.Forms.Label datestampLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label staticDatestampLabel;
        private System.Windows.Forms.Label staticEmailLabel;
        private System.Windows.Forms.Label sampleIdLabel;
        private System.Windows.Forms.Label delimiterLabel;
        private System.Windows.Forms.Label staticSampleIdLabel;
        private System.Windows.Forms.Label staticDelimiterLabel;
        private System.Windows.Forms.Label metadataLabel;
        private System.Windows.Forms.Label staticMetadataLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}