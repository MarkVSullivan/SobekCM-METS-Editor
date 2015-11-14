namespace SobekCM.METS_Editor.Forms
{
    partial class Serial_Hierarchy_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Serial_Hierarchy_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enumRadioButton = new System.Windows.Forms.RadioButton();
            this.partLabel = new System.Windows.Forms.Label();
            this.issueLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.partOrderTextBox = new System.Windows.Forms.TextBox();
            this.partDisplayTextBox = new System.Windows.Forms.TextBox();
            this.issueOrderTextBox = new System.Windows.Forms.TextBox();
            this.issueDisplayTextBox = new System.Windows.Forms.TextBox();
            this.volumeDisplayTextBox = new System.Windows.Forms.TextBox();
            this.volumeOrderTextBox = new System.Windows.Forms.TextBox();
            this.chronologicalGroupBox = new System.Windows.Forms.GroupBox();
            this.chronRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dayOrderTextBox = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.dayDisplayTextBox = new System.Windows.Forms.TextBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.monthOrderTextBox = new System.Windows.Forms.TextBox();
            this.dayLabel = new System.Windows.Forms.Label();
            this.monthDisplayTextBox = new System.Windows.Forms.TextBox();
            this.yearDisplayTextBox = new System.Windows.Forms.TextBox();
            this.yearOrderTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.hiddenSaveButton = new System.Windows.Forms.Button();
            this.hiddenCancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.chronologicalGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chronologicalGroupBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 345);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enumRadioButton);
            this.groupBox1.Controls.Add(this.partLabel);
            this.groupBox1.Controls.Add(this.issueLabel);
            this.groupBox1.Controls.Add(this.volumeLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.partOrderTextBox);
            this.groupBox1.Controls.Add(this.partDisplayTextBox);
            this.groupBox1.Controls.Add(this.issueOrderTextBox);
            this.groupBox1.Controls.Add(this.issueDisplayTextBox);
            this.groupBox1.Controls.Add(this.volumeDisplayTextBox);
            this.groupBox1.Controls.Add(this.volumeOrderTextBox);
            this.groupBox1.Location = new System.Drawing.Point(19, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enumeration Information";
            // 
            // enumRadioButton
            // 
            this.enumRadioButton.AutoSize = true;
            this.enumRadioButton.Location = new System.Drawing.Point(18, 22);
            this.enumRadioButton.Name = "enumRadioButton";
            this.enumRadioButton.Size = new System.Drawing.Size(64, 18);
            this.enumRadioButton.TabIndex = 37;
            this.enumRadioButton.TabStop = true;
            this.enumRadioButton.Text = "Primary";
            this.enumRadioButton.UseVisualStyleBackColor = true;
            this.enumRadioButton.Leave += new System.EventHandler(this.radioButton_Leave);
            this.enumRadioButton.Enter += new System.EventHandler(this.radioButton_Enter);
            this.enumRadioButton.CheckedChanged += new System.EventHandler(this.enumRadioButton_CheckedChanged);
            // 
            // partLabel
            // 
            this.partLabel.AutoSize = true;
            this.partLabel.Location = new System.Drawing.Point(62, 108);
            this.partLabel.Name = "partLabel";
            this.partLabel.Size = new System.Drawing.Size(43, 14);
            this.partLabel.TabIndex = 36;
            this.partLabel.Text = "(Part):";
            // 
            // issueLabel
            // 
            this.issueLabel.AutoSize = true;
            this.issueLabel.Location = new System.Drawing.Point(62, 78);
            this.issueLabel.Name = "issueLabel";
            this.issueLabel.Size = new System.Drawing.Size(49, 14);
            this.issueLabel.TabIndex = 35;
            this.issueLabel.Text = "(Issue):";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(62, 48);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(62, 14);
            this.volumeLabel.TabIndex = 34;
            this.volumeLabel.Text = "(Volume):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(387, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 33;
            this.label4.Text = "Display Order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(233, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 32;
            this.label5.Text = "Display Text";
            // 
            // partOrderTextBox
            // 
            this.partOrderTextBox.BackColor = System.Drawing.Color.White;
            this.partOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partOrderTextBox.Location = new System.Drawing.Point(377, 105);
            this.partOrderTextBox.Name = "partOrderTextBox";
            this.partOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.partOrderTextBox.TabIndex = 5;
            this.partOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // partDisplayTextBox
            // 
            this.partDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.partDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.partDisplayTextBox.Location = new System.Drawing.Point(180, 105);
            this.partDisplayTextBox.Name = "partDisplayTextBox";
            this.partDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.partDisplayTextBox.TabIndex = 4;
            this.partDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.partDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // issueOrderTextBox
            // 
            this.issueOrderTextBox.BackColor = System.Drawing.Color.White;
            this.issueOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.issueOrderTextBox.Location = new System.Drawing.Point(377, 75);
            this.issueOrderTextBox.Name = "issueOrderTextBox";
            this.issueOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.issueOrderTextBox.TabIndex = 3;
            this.issueOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.issueOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // issueDisplayTextBox
            // 
            this.issueDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.issueDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.issueDisplayTextBox.Location = new System.Drawing.Point(180, 75);
            this.issueDisplayTextBox.Name = "issueDisplayTextBox";
            this.issueDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.issueDisplayTextBox.TabIndex = 2;
            this.issueDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.issueDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // volumeDisplayTextBox
            // 
            this.volumeDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.volumeDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.volumeDisplayTextBox.Location = new System.Drawing.Point(180, 45);
            this.volumeDisplayTextBox.Name = "volumeDisplayTextBox";
            this.volumeDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.volumeDisplayTextBox.TabIndex = 0;
            this.volumeDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.volumeDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // volumeOrderTextBox
            // 
            this.volumeOrderTextBox.BackColor = System.Drawing.Color.White;
            this.volumeOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.volumeOrderTextBox.Location = new System.Drawing.Point(377, 45);
            this.volumeOrderTextBox.Name = "volumeOrderTextBox";
            this.volumeOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.volumeOrderTextBox.TabIndex = 1;
            this.volumeOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.volumeOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // chronologicalGroupBox
            // 
            this.chronologicalGroupBox.Controls.Add(this.chronRadioButton);
            this.chronologicalGroupBox.Controls.Add(this.label2);
            this.chronologicalGroupBox.Controls.Add(this.label3);
            this.chronologicalGroupBox.Controls.Add(this.dayOrderTextBox);
            this.chronologicalGroupBox.Controls.Add(this.yearLabel);
            this.chronologicalGroupBox.Controls.Add(this.dayDisplayTextBox);
            this.chronologicalGroupBox.Controls.Add(this.monthLabel);
            this.chronologicalGroupBox.Controls.Add(this.monthOrderTextBox);
            this.chronologicalGroupBox.Controls.Add(this.dayLabel);
            this.chronologicalGroupBox.Controls.Add(this.monthDisplayTextBox);
            this.chronologicalGroupBox.Controls.Add(this.yearDisplayTextBox);
            this.chronologicalGroupBox.Controls.Add(this.yearOrderTextBox);
            this.chronologicalGroupBox.Location = new System.Drawing.Point(19, 175);
            this.chronologicalGroupBox.Name = "chronologicalGroupBox";
            this.chronologicalGroupBox.Size = new System.Drawing.Size(528, 153);
            this.chronologicalGroupBox.TabIndex = 1;
            this.chronologicalGroupBox.TabStop = false;
            this.chronologicalGroupBox.Text = "Chronological Information";
            // 
            // chronRadioButton
            // 
            this.chronRadioButton.AutoSize = true;
            this.chronRadioButton.Location = new System.Drawing.Point(18, 21);
            this.chronRadioButton.Name = "chronRadioButton";
            this.chronRadioButton.Size = new System.Drawing.Size(64, 18);
            this.chronRadioButton.TabIndex = 38;
            this.chronRadioButton.TabStop = true;
            this.chronRadioButton.Text = "Primary";
            this.chronRadioButton.UseVisualStyleBackColor = true;
            this.chronRadioButton.Leave += new System.EventHandler(this.radioButton_Leave);
            this.chronRadioButton.Enter += new System.EventHandler(this.radioButton_Enter);
            this.chronRadioButton.CheckedChanged += new System.EventHandler(this.chronRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(387, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Display Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(233, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 32;
            this.label3.Text = "Display Text";
            // 
            // dayOrderTextBox
            // 
            this.dayOrderTextBox.BackColor = System.Drawing.Color.White;
            this.dayOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.dayOrderTextBox.Location = new System.Drawing.Point(377, 105);
            this.dayOrderTextBox.Name = "dayOrderTextBox";
            this.dayOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.dayOrderTextBox.TabIndex = 5;
            this.dayOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.dayOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(62, 48);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(36, 14);
            this.yearLabel.TabIndex = 17;
            this.yearLabel.Text = "Year:";
            // 
            // dayDisplayTextBox
            // 
            this.dayDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.dayDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.dayDisplayTextBox.Location = new System.Drawing.Point(180, 105);
            this.dayDisplayTextBox.Name = "dayDisplayTextBox";
            this.dayDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.dayDisplayTextBox.TabIndex = 4;
            this.dayDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.dayDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(62, 78);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(56, 14);
            this.monthLabel.TabIndex = 18;
            this.monthLabel.Text = "(Month):";
            // 
            // monthOrderTextBox
            // 
            this.monthOrderTextBox.BackColor = System.Drawing.Color.White;
            this.monthOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.monthOrderTextBox.Location = new System.Drawing.Point(377, 75);
            this.monthOrderTextBox.Name = "monthOrderTextBox";
            this.monthOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.monthOrderTextBox.TabIndex = 3;
            this.monthOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.monthOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(62, 108);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(41, 14);
            this.dayLabel.TabIndex = 19;
            this.dayLabel.Text = "(Day):";
            // 
            // monthDisplayTextBox
            // 
            this.monthDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.monthDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.monthDisplayTextBox.Location = new System.Drawing.Point(180, 75);
            this.monthDisplayTextBox.Name = "monthDisplayTextBox";
            this.monthDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.monthDisplayTextBox.TabIndex = 2;
            this.monthDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.monthDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // yearDisplayTextBox
            // 
            this.yearDisplayTextBox.BackColor = System.Drawing.Color.White;
            this.yearDisplayTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.yearDisplayTextBox.Location = new System.Drawing.Point(180, 45);
            this.yearDisplayTextBox.Name = "yearDisplayTextBox";
            this.yearDisplayTextBox.Size = new System.Drawing.Size(183, 22);
            this.yearDisplayTextBox.TabIndex = 0;
            this.yearDisplayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.yearDisplayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // yearOrderTextBox
            // 
            this.yearOrderTextBox.BackColor = System.Drawing.Color.White;
            this.yearOrderTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.yearOrderTextBox.Location = new System.Drawing.Point(377, 45);
            this.yearOrderTextBox.Name = "yearOrderTextBox";
            this.yearOrderTextBox.Size = new System.Drawing.Size(95, 22);
            this.yearOrderTextBox.TabIndex = 1;
            this.yearOrderTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.yearOrderTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Button_Enabled = true;
            this.cancelButton.Button_Text = "CANCEL";
            this.cancelButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(348, 367);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 26);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Button_Pressed += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "SAVE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(468, 367);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenSaveButton
            // 
            this.hiddenSaveButton.Location = new System.Drawing.Point(159, 464);
            this.hiddenSaveButton.Name = "hiddenSaveButton";
            this.hiddenSaveButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenSaveButton.TabIndex = 19;
            this.hiddenSaveButton.TabStop = false;
            this.hiddenSaveButton.UseVisualStyleBackColor = true;
            this.hiddenSaveButton.Click += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(128, 464);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 18;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.cancelButton_Button_Pressed);
            // 
            // Serial_Hierarchy_Form
            // 
            this.AcceptButton = this.hiddenSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(593, 401);
            this.Controls.Add(this.hiddenSaveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Serial_Hierarchy_Form";
            this.Text = "Edit Serial Hierarchy Information";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.chronologicalGroupBox.ResumeLayout(false);
            this.chronologicalGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SobekCM.METS_Editor.Forms.Round_Button cancelButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.GroupBox chronologicalGroupBox;
        private System.Windows.Forms.TextBox dayOrderTextBox;
        private System.Windows.Forms.TextBox dayDisplayTextBox;
        private System.Windows.Forms.TextBox monthOrderTextBox;
        private System.Windows.Forms.TextBox monthDisplayTextBox;
        private System.Windows.Forms.TextBox yearOrderTextBox;
        private System.Windows.Forms.TextBox yearDisplayTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label partLabel;
        private System.Windows.Forms.Label issueLabel;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox partOrderTextBox;
        private System.Windows.Forms.TextBox partDisplayTextBox;
        private System.Windows.Forms.TextBox issueOrderTextBox;
        private System.Windows.Forms.TextBox issueDisplayTextBox;
        private System.Windows.Forms.TextBox volumeDisplayTextBox;
        private System.Windows.Forms.TextBox volumeOrderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton enumRadioButton;
        private System.Windows.Forms.RadioButton chronRadioButton;
        private System.Windows.Forms.Button hiddenSaveButton;
        private System.Windows.Forms.Button hiddenCancelButton;
    }
}