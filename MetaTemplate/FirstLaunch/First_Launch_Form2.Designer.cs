namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form2));
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dublinCoreLabel2 = new System.Windows.Forms.Label();
            this.marcXmlLabel2 = new System.Windows.Forms.Label();
            this.modsLabel2 = new System.Windows.Forms.Label();
            this.modsLabel1 = new System.Windows.Forms.Label();
            this.marcXmlLabel1 = new System.Windows.Forms.Label();
            this.dublinCoreLabel1 = new System.Windows.Forms.Label();
            this.modsRadioButton = new System.Windows.Forms.RadioButton();
            this.marcXmlRadioButton = new System.Windows.Forms.RadioButton();
            this.dublinCoreRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.cancelRoundButton.Location = new System.Drawing.Point(441, 393);
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
            this.continueButton.Location = new System.Drawing.Point(574, 393);
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
            this.panel1.Controls.Add(this.dublinCoreLabel2);
            this.panel1.Controls.Add(this.marcXmlLabel2);
            this.panel1.Controls.Add(this.modsLabel2);
            this.panel1.Controls.Add(this.modsLabel1);
            this.panel1.Controls.Add(this.marcXmlLabel1);
            this.panel1.Controls.Add(this.dublinCoreLabel1);
            this.panel1.Controls.Add(this.modsRadioButton);
            this.panel1.Controls.Add(this.marcXmlRadioButton);
            this.panel1.Controls.Add(this.dublinCoreRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 333);
            this.panel1.TabIndex = 5;
            // 
            // dublinCoreLabel2
            // 
            this.dublinCoreLabel2.AutoSize = true;
            this.dublinCoreLabel2.Location = new System.Drawing.Point(90, 109);
            this.dublinCoreLabel2.Name = "dublinCoreLabel2";
            this.dublinCoreLabel2.Size = new System.Drawing.Size(475, 14);
            this.dublinCoreLabel2.TabIndex = 14;
            this.dublinCoreLabel2.Text = "is stored in 13 simple string fields, without any support for more complex inform" +
                "ation.";
            // 
            // marcXmlLabel2
            // 
            this.marcXmlLabel2.AutoSize = true;
            this.marcXmlLabel2.Location = new System.Drawing.Point(90, 199);
            this.marcXmlLabel2.Name = "marcXmlLabel2";
            this.marcXmlLabel2.Size = new System.Drawing.Size(513, 14);
            this.marcXmlLabel2.TabIndex = 13;
            this.marcXmlLabel2.Text = "support the full range of MARC fields, but generally the subset of fields support" +
                "ed by MODS.";
            // 
            // modsLabel2
            // 
            this.modsLabel2.AutoSize = true;
            this.modsLabel2.Location = new System.Drawing.Point(90, 284);
            this.modsLabel2.Name = "modsLabel2";
            this.modsLabel2.Size = new System.Drawing.Size(391, 14);
            this.modsLabel2.TabIndex = 12;
            this.modsLabel2.Text = "with complex elements for fields such as titles, creators, and subjects.";
            // 
            // modsLabel1
            // 
            this.modsLabel1.AutoSize = true;
            this.modsLabel1.Location = new System.Drawing.Point(90, 260);
            this.modsLabel1.Name = "modsLabel1";
            this.modsLabel1.Size = new System.Drawing.Size(505, 14);
            this.modsLabel1.TabIndex = 11;
            this.modsLabel1.Text = "The Metadata Object Description Standard (MODS) supports rich bibliographic descr" +
                "iptions,";
            // 
            // marcXmlLabel1
            // 
            this.marcXmlLabel1.AutoSize = true;
            this.marcXmlLabel1.Location = new System.Drawing.Point(90, 176);
            this.marcXmlLabel1.Name = "marcXmlLabel1";
            this.marcXmlLabel1.Size = new System.Drawing.Size(490, 14);
            this.marcXmlLabel1.TabIndex = 10;
            this.marcXmlLabel1.Text = "MarcXML encodes standard MARC records within the metadata.  This template does no" +
                "t";
            // 
            // dublinCoreLabel1
            // 
            this.dublinCoreLabel1.AutoSize = true;
            this.dublinCoreLabel1.Location = new System.Drawing.Point(90, 85);
            this.dublinCoreLabel1.Name = "dublinCoreLabel1";
            this.dublinCoreLabel1.Size = new System.Drawing.Size(515, 14);
            this.dublinCoreLabel1.TabIndex = 9;
            this.dublinCoreLabel1.Text = "Dublin Core supports very simple description of (generally) digital objects.  All" +
                " the information";
            // 
            // modsRadioButton
            // 
            this.modsRadioButton.AutoSize = true;
            this.modsRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsRadioButton.Location = new System.Drawing.Point(60, 230);
            this.modsRadioButton.Name = "modsRadioButton";
            this.modsRadioButton.Size = new System.Drawing.Size(62, 18);
            this.modsRadioButton.TabIndex = 8;
            this.modsRadioButton.Text = "MODS";
            this.modsRadioButton.UseVisualStyleBackColor = true;
            // 
            // marcXmlRadioButton
            // 
            this.marcXmlRadioButton.AutoSize = true;
            this.marcXmlRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcXmlRadioButton.Location = new System.Drawing.Point(60, 146);
            this.marcXmlRadioButton.Name = "marcXmlRadioButton";
            this.marcXmlRadioButton.Size = new System.Drawing.Size(80, 18);
            this.marcXmlRadioButton.TabIndex = 7;
            this.marcXmlRadioButton.Text = "MarcXML";
            this.marcXmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // dublinCoreRadioButton
            // 
            this.dublinCoreRadioButton.AutoSize = true;
            this.dublinCoreRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dublinCoreRadioButton.Location = new System.Drawing.Point(60, 60);
            this.dublinCoreRadioButton.Name = "dublinCoreRadioButton";
            this.dublinCoreRadioButton.Size = new System.Drawing.Size(96, 18);
            this.dublinCoreRadioButton.TabIndex = 6;
            this.dublinCoreRadioButton.Text = "Dublin Core";
            this.dublinCoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the primary scheme to use when saving the bibliographic information about " +
                "a resource:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(677, 42);
            this.label2.TabIndex = 8;
            this.label2.Text = "Initialization: Primary Bibliographic Metadata Scheme";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // First_Launch_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(701, 431);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "First_Launch_Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: Primary Bibliographic Metadata Scheme";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton modsRadioButton;
        private System.Windows.Forms.RadioButton marcXmlRadioButton;
        private System.Windows.Forms.RadioButton dublinCoreRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label modsLabel1;
        private System.Windows.Forms.Label marcXmlLabel1;
        private System.Windows.Forms.Label dublinCoreLabel1;
        private System.Windows.Forms.Label modsLabel2;
        private System.Windows.Forms.Label marcXmlLabel2;
        private System.Windows.Forms.Label dublinCoreLabel2;
        private System.Windows.Forms.Label label2;
    }
}