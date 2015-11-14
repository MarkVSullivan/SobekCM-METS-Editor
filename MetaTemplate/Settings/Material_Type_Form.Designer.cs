namespace SobekCM.METS_Editor.Settings
{
    partial class Material_Type_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material_Type_Form));
            this.modsLabel = new System.Windows.Forms.Label();
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.displayLabel = new System.Windows.Forms.Label();
            this.modsComboBox = new System.Windows.Forms.ComboBox();
            this.sobekLabel = new System.Windows.Forms.Label();
            this.sobekTextBox = new System.Windows.Forms.TextBox();
            this.cancelRoundButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.SuspendLayout();
            // 
            // modsLabel
            // 
            this.modsLabel.AutoSize = true;
            this.modsLabel.Location = new System.Drawing.Point(19, 55);
            this.modsLabel.Name = "modsLabel";
            this.modsLabel.Size = new System.Drawing.Size(130, 14);
            this.modsLabel.TabIndex = 2;
            this.modsLabel.Text = "MODS Resource Type:";
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(157, 17);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.Size = new System.Drawing.Size(258, 22);
            this.displayTextBox.TabIndex = 1;
            this.displayTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.displayTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(19, 20);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(95, 14);
            this.displayLabel.TabIndex = 0;
            this.displayLabel.Text = "Template Type:";
            // 
            // modsComboBox
            // 
            this.modsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modsComboBox.FormattingEnabled = true;
            this.modsComboBox.Items.AddRange(new object[] {
            "text",
            "cartographic",
            "notated music",
            "sound recording",
            "sound recording - musical",
            "sound recording - nonmusical",
            "still image",
            "moving image",
            "three-dimensional object",
            "software, multimedia",
            "mixed materials"});
            this.modsComboBox.Location = new System.Drawing.Point(157, 52);
            this.modsComboBox.Name = "modsComboBox";
            this.modsComboBox.Size = new System.Drawing.Size(258, 22);
            this.modsComboBox.TabIndex = 3;
            // 
            // sobekLabel
            // 
            this.sobekLabel.AutoSize = true;
            this.sobekLabel.Location = new System.Drawing.Point(19, 96);
            this.sobekLabel.Name = "sobekLabel";
            this.sobekLabel.Size = new System.Drawing.Size(98, 14);
            this.sobekLabel.TabIndex = 4;
            this.sobekLabel.Text = "SobekCM Genre:";
            // 
            // sobekTextBox
            // 
            this.sobekTextBox.Location = new System.Drawing.Point(157, 93);
            this.sobekTextBox.Name = "sobekTextBox";
            this.sobekTextBox.Size = new System.Drawing.Size(258, 22);
            this.sobekTextBox.TabIndex = 5;
            this.sobekTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.sobekTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // cancelRoundButton
            // 
            this.cancelRoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRoundButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelRoundButton.Button_Enabled = true;
            this.cancelRoundButton.Button_Text = "CANCEL";
            this.cancelRoundButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Backward;
            this.cancelRoundButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRoundButton.Location = new System.Drawing.Point(215, 126);
            this.cancelRoundButton.Name = "cancelRoundButton";
            this.cancelRoundButton.Size = new System.Drawing.Size(94, 26);
            this.cancelRoundButton.TabIndex = 6;
            this.cancelRoundButton.Button_Pressed += new System.EventHandler(this.cancelRoundButton_Button_Pressed);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "SAVE";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Forward;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(325, 126);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 7;
            this.saveButton.Button_Pressed += new System.EventHandler(this.saveButton_Button_Pressed);
            // 
            // Material_Type_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(437, 168);
            this.Controls.Add(this.sobekTextBox);
            this.Controls.Add(this.sobekLabel);
            this.Controls.Add(this.modsComboBox);
            this.Controls.Add(this.modsLabel);
            this.Controls.Add(this.cancelRoundButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.displayLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Material_Type_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label modsLabel;
        private SobekCM.METS_Editor.Forms.Round_Button cancelRoundButton;
        private SobekCM.METS_Editor.Forms.Round_Button saveButton;
        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.ComboBox modsComboBox;
        private System.Windows.Forms.Label sobekLabel;
        private System.Windows.Forms.TextBox sobekTextBox;
    }
}