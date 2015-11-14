using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DLC.Tools.Forms
{
    public partial class ErrorMessageBox_Internal : Form
    {
        private Exception inner_exception;
        private int line_y;

        public ErrorMessageBox_Internal( string message, string title, Exception ee )
        {
            // Save the exception 
            inner_exception = ee;

            // Set the default
            line_y = -1;

            // Initialize this form
            InitializeComponent();

            // Set the main label information
            mainLabel.Text = message; 

            // Set the title
            this.Text = title;

            // Configure the form now
            configure_all();

            // With only one button, the dialog result is obviously OK
            DialogResult = DialogResult.OK;
        }

        private void configure_all()
        {
            // Get the size of the label
            int label_width = mainLabel.Width;
            int label_height = mainLabel.Height;

            // Set the form size
            if (line_y > 0)
            {
                this.Width = Math.Max(Math.Max(mainLabel.Width, exceptionLabel.Width) + 94, 400 );
                this.Height = line_y + 80 + exceptionLabel.Height;
            }
            else
            {
                this.Height = label_height + 94;
                this.Width = Math.Max(label_width + 80, 250);
            }

            // Set the button location
            okButton.Location = new Point((this.Width - okButton.Width) / 2, this.Height - 65);

            // Configure the view details button
            if (inner_exception == null)
            {
                detailsLabel.Hide();
            }
            else
            {
                detailsLabel.Location = new Point(this.Width - 75, this.Height - 53);
                clipboardLabel.Location = new Point(this.Width - 138, this.Height - 53);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detailsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Save the location for the line
            line_y = Math.Max(mainLabel.Location.Y + mainLabel.Height + 8, 60);
           // mainLabel.Hide();

            // Hide the label
            detailsLabel.Hide();
            clipboardLabel.Show();

            // Show the exception
            exceptionLabel.Text = inner_exception.ToString();
            exceptionLabel.Location = new Point(12, Math.Max(70, mainLabel.Location.Y + mainLabel.Height + 15));
            exceptionLabel.Show();

            // Configure the form
            configure_all();

            // Invalidate
            this.Invalidate();
        }

        private void clipboardLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Clipboard.SetText("TITLE: " + this.Text + "\n----------------------\n\n" + mainLabel.Text.Trim() + "\n\n----------------------\n\nEXCEPTION DETAILS:\n" + exceptionLabel.Text + "\n\n----------------------");
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the line, if necessary
            if (line_y > 0)
            {
                e.Graphics.DrawLine(Pens.DarkGray, 0, line_y, this.Width, line_y);
                e.Graphics.DrawLine(Pens.White, 0, line_y + 1, this.Width, line_y + 1);
            }

            // Call base onpaoint
            base.OnPaint(e);
        }
    }
}