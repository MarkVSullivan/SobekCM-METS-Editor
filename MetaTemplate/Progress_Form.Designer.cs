namespace SobekCM.METS_Editor
{
    partial class Progress_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress_Form));
            this.staticTextLabel = new System.Windows.Forms.Label();
            this.staticProgressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.currentTaskLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // staticTextLabel
            // 
            this.staticTextLabel.AutoSize = true;
            this.staticTextLabel.Location = new System.Drawing.Point(12, 21);
            this.staticTextLabel.Name = "staticTextLabel";
            this.staticTextLabel.Size = new System.Drawing.Size(36, 14);
            this.staticTextLabel.TabIndex = 0;
            this.staticTextLabel.Text = "Task:";
            // 
            // staticProgressLabel
            // 
            this.staticProgressLabel.AutoSize = true;
            this.staticProgressLabel.Location = new System.Drawing.Point(12, 55);
            this.staticProgressLabel.Name = "staticProgressLabel";
            this.staticProgressLabel.Size = new System.Drawing.Size(57, 14);
            this.staticProgressLabel.TabIndex = 1;
            this.staticProgressLabel.Text = "Progress:";
            this.staticProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(88, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(352, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // currentTaskLabel
            // 
            this.currentTaskLabel.AutoSize = true;
            this.currentTaskLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTaskLabel.Location = new System.Drawing.Point(88, 21);
            this.currentTaskLabel.Name = "currentTaskLabel";
            this.currentTaskLabel.Size = new System.Drawing.Size(100, 14);
            this.currentTaskLabel.TabIndex = 4;
            this.currentTaskLabel.Text = "currentTaskLabel";
            // 
            // Progress_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 94);
            this.ControlBox = false;
            this.Controls.Add(this.currentTaskLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.staticProgressLabel);
            this.Controls.Add(this.staticTextLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Progress_Form";
            this.Text = "Title";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label staticTextLabel;
        private System.Windows.Forms.Label staticProgressLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label currentTaskLabel;
    }
}