namespace SobekCM.METS_Editor.FirstLaunch
{
    partial class First_Launch_Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Launch_Form3));
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.continueButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.otherComboBox = new System.Windows.Forms.ComboBox();
            this.otherRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.completeLabel2 = new System.Windows.Forms.Label();
            this.standardLabel3 = new System.Windows.Forms.Label();
            this.standardLabel2 = new System.Windows.Forms.Label();
            this.dublinCoreLabel2 = new System.Windows.Forms.Label();
            this.completeLabel1 = new System.Windows.Forms.Label();
            this.standardLabel1 = new System.Windows.Forms.Label();
            this.dublinCoreLabel1 = new System.Windows.Forms.Label();
            this.completeRadioButton = new System.Windows.Forms.RadioButton();
            this.standardRadioButton = new System.Windows.Forms.RadioButton();
            this.dublinCoreRadioButton = new System.Windows.Forms.RadioButton();
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
            this.cancelRoundButton.Location = new System.Drawing.Point(441, 439);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(113, 26);
            this.cancelRoundButton.TabIndex = 10;
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
            this.continueButton.Location = new System.Drawing.Point(574, 439);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(113, 26);
            this.continueButton.TabIndex = 9;
            this.continueButton.Button_Pressed += new System.EventHandler(this.continueButton_Button_Pressed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.otherComboBox);
            this.panel1.Controls.Add(this.otherRadioButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.completeLabel2);
            this.panel1.Controls.Add(this.standardLabel3);
            this.panel1.Controls.Add(this.standardLabel2);
            this.panel1.Controls.Add(this.dublinCoreLabel2);
            this.panel1.Controls.Add(this.completeLabel1);
            this.panel1.Controls.Add(this.standardLabel1);
            this.panel1.Controls.Add(this.dublinCoreLabel1);
            this.panel1.Controls.Add(this.completeRadioButton);
            this.panel1.Controls.Add(this.standardRadioButton);
            this.panel1.Controls.Add(this.dublinCoreRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 379);
            this.panel1.TabIndex = 8;
            // 
            // otherComboBox
            // 
            this.otherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otherComboBox.Enabled = false;
            this.otherComboBox.FormattingEnabled = true;
            this.otherComboBox.Location = new System.Drawing.Point(142, 331);
            this.otherComboBox.Name = "otherComboBox";
            this.otherComboBox.Size = new System.Drawing.Size(179, 22);
            this.otherComboBox.Sorted = true;
            this.otherComboBox.TabIndex = 20;
            // 
            // otherRadioButton
            // 
            this.otherRadioButton.AutoSize = true;
            this.otherRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherRadioButton.Location = new System.Drawing.Point(66, 332);
            this.otherRadioButton.Name = "otherRadioButton";
            this.otherRadioButton.Size = new System.Drawing.Size(60, 18);
            this.otherRadioButton.TabIndex = 19;
            this.otherRadioButton.Text = "Other";
            this.otherRadioButton.UseVisualStyleBackColor = true;
            this.otherRadioButton.CheckedChanged += new System.EventHandler(this.otherRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(508, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "difficult form for creating metadata from scratch.  This supports the most robust" +
                " metadata.";
            // 
            // completeLabel2
            // 
            this.completeLabel2.AutoSize = true;
            this.completeLabel2.Location = new System.Drawing.Point(97, 278);
            this.completeLabel2.Name = "completeLabel2";
            this.completeLabel2.Size = new System.Drawing.Size(510, 14);
            this.completeLabel2.TabIndex = 17;
            this.completeLabel2.Text = "Many metadata elements require a subform for entry of all subelements, making thi" +
                "s a more";
            // 
            // standardLabel3
            // 
            this.standardLabel3.AutoSize = true;
            this.standardLabel3.Location = new System.Drawing.Point(97, 199);
            this.standardLabel3.Name = "standardLabel3";
            this.standardLabel3.Size = new System.Drawing.Size(166, 14);
            this.standardLabel3.TabIndex = 16;
            this.standardLabel3.Text = "and metadata completeness.";
            // 
            // standardLabel2
            // 
            this.standardLabel2.AutoSize = true;
            this.standardLabel2.Location = new System.Drawing.Point(97, 179);
            this.standardLabel2.Name = "standardLabel2";
            this.standardLabel2.Size = new System.Drawing.Size(528, 14);
            this.standardLabel2.TabIndex = 15;
            this.standardLabel2.Text = "subelements will be available for editing.  This template is a good balance betwe" +
                "en ease-of-use";
            // 
            // dublinCoreLabel2
            // 
            this.dublinCoreLabel2.AutoSize = true;
            this.dublinCoreLabel2.Location = new System.Drawing.Point(97, 102);
            this.dublinCoreLabel2.Name = "dublinCoreLabel2";
            this.dublinCoreLabel2.Size = new System.Drawing.Size(167, 14);
            this.dublinCoreLabel2.TabIndex = 14;
            this.dublinCoreLabel2.Text = "interface for metadata entry.";
            // 
            // completeLabel1
            // 
            this.completeLabel1.AutoSize = true;
            this.completeLabel1.Location = new System.Drawing.Point(97, 258);
            this.completeLabel1.Name = "completeLabel1";
            this.completeLabel1.Size = new System.Drawing.Size(507, 14);
            this.completeLabel1.TabIndex = 11;
            this.completeLabel1.Text = "The complete template provides access to all supported MODS elements and subeleme" +
                "nts.";
            // 
            // standardLabel1
            // 
            this.standardLabel1.AutoSize = true;
            this.standardLabel1.Location = new System.Drawing.Point(97, 159);
            this.standardLabel1.Name = "standardLabel1";
            this.standardLabel1.Size = new System.Drawing.Size(494, 14);
            this.standardLabel1.TabIndex = 10;
            this.standardLabel1.Text = "The standard template provides access to nearly all the MODS elements, although n" +
                "ot all";
            // 
            // dublinCoreLabel1
            // 
            this.dublinCoreLabel1.AutoSize = true;
            this.dublinCoreLabel1.Location = new System.Drawing.Point(97, 82);
            this.dublinCoreLabel1.Name = "dublinCoreLabel1";
            this.dublinCoreLabel1.Size = new System.Drawing.Size(499, 14);
            this.dublinCoreLabel1.TabIndex = 9;
            this.dublinCoreLabel1.Text = "This entry template supports the primary Dublin Core elements and provides the si" +
                "mplest ";
            // 
            // completeRadioButton
            // 
            this.completeRadioButton.AutoSize = true;
            this.completeRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeRadioButton.Location = new System.Drawing.Point(67, 233);
            this.completeRadioButton.Name = "completeRadioButton";
            this.completeRadioButton.Size = new System.Drawing.Size(83, 18);
            this.completeRadioButton.TabIndex = 8;
            this.completeRadioButton.Text = "Complete";
            this.completeRadioButton.UseVisualStyleBackColor = true;
            // 
            // standardRadioButton
            // 
            this.standardRadioButton.AutoSize = true;
            this.standardRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.standardRadioButton.Location = new System.Drawing.Point(67, 134);
            this.standardRadioButton.Name = "standardRadioButton";
            this.standardRadioButton.Size = new System.Drawing.Size(82, 18);
            this.standardRadioButton.TabIndex = 7;
            this.standardRadioButton.Text = "Standard";
            this.standardRadioButton.UseVisualStyleBackColor = true;
            // 
            // dublinCoreRadioButton
            // 
            this.dublinCoreRadioButton.AutoSize = true;
            this.dublinCoreRadioButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dublinCoreRadioButton.Location = new System.Drawing.Point(67, 57);
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
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the primary template which defines the basic bibliographic entry form:";
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
            this.label3.Size = new System.Drawing.Size(677, 42);
            this.label3.TabIndex = 11;
            this.label3.Text = "Initialization: Primary Metadata Template";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // First_Launch_Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(701, 478);
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
            this.Name = "First_Launch_Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialization: Primary Metadata Template";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button continueButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dublinCoreLabel2;
        private System.Windows.Forms.Label completeLabel1;
        private System.Windows.Forms.Label standardLabel1;
        private System.Windows.Forms.Label dublinCoreLabel1;
        private System.Windows.Forms.RadioButton completeRadioButton;
        private System.Windows.Forms.RadioButton standardRadioButton;
        private System.Windows.Forms.RadioButton dublinCoreRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label standardLabel3;
        private System.Windows.Forms.Label standardLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label completeLabel2;
        private System.Windows.Forms.RadioButton otherRadioButton;
        private System.Windows.Forms.ComboBox otherComboBox;
        private System.Windows.Forms.Label label3;
    }
}