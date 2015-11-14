namespace SobekCM.METS_Editor.Forms
{
    partial class Degrees_Minutes_Seconds_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Degrees_Minutes_Seconds_Form));
            this.degreesLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.degreesTextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // degreesLabel
            // 
            this.degreesLabel.AutoSize = true;
            this.degreesLabel.Location = new System.Drawing.Point(12, 20);
            this.degreesLabel.Name = "degreesLabel";
            this.degreesLabel.Size = new System.Drawing.Size(56, 14);
            this.degreesLabel.TabIndex = 0;
            this.degreesLabel.Text = "Degrees:";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(126, 20);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(53, 14);
            this.minutesLabel.TabIndex = 1;
            this.minutesLabel.Text = "Minutes:";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(237, 20);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(57, 14);
            this.secondsLabel.TabIndex = 2;
            this.secondsLabel.Text = "Seconds:";
            // 
            // degreesTextBox
            // 
            this.degreesTextBox.Location = new System.Drawing.Point(74, 17);
            this.degreesTextBox.Name = "degreesTextBox";
            this.degreesTextBox.Size = new System.Drawing.Size(46, 22);
            this.degreesTextBox.TabIndex = 3;
            this.degreesTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.degreesTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(185, 17);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(46, 22);
            this.minutesTextBox.TabIndex = 4;
            this.minutesTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.minutesTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.Location = new System.Drawing.Point(300, 17);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.Size = new System.Drawing.Size(46, 22);
            this.secondsTextBox.TabIndex = 5;
            this.secondsTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.secondsTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(370, 16);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(74, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Degrees_Minutes_Seconds_Form
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 56);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.secondsTextBox);
            this.Controls.Add(this.minutesTextBox);
            this.Controls.Add(this.degreesTextBox);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.degreesLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Degrees_Minutes_Seconds_Form";
            this.Text = "Coordinate Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label degreesLabel;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.TextBox degreesTextBox;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.TextBox secondsTextBox;
        private System.Windows.Forms.Button okButton;
    }
}