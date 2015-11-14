#region Using directives

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary>
	/// Summary description for About_dLOC.
	/// </summary>
	public class About_dLOC : Form
	{
		private Panel UFimagePanel;
		private Label aboutLabel;
		private Label licenseLabel;
		private Label label1;
		private LinkLabel linkLabel1;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public About_dLOC( string Version )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Text = "dLOC Metadata and Tracking Toolkit - Version " + Version;

			//this.label1.Text = Version;
			licenseLabel.Text = "The Digital Library of the Caribbean Metadata and Tracking Toolkit was written by Mark Sullivan at the University of Florida.\n" + 
				"Copyright (C) 2006 - Digital Library of the Caribbean and the University of Florida.\n\n" +
				"This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation version 2.\n\n" +
				"This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About_dLOC));
            this.UFimagePanel = new System.Windows.Forms.Panel();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UFimagePanel
            // 
            this.UFimagePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UFimagePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UFimagePanel.BackgroundImage")));
            this.UFimagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UFimagePanel.Location = new System.Drawing.Point(16, 16);
            this.UFimagePanel.Name = "UFimagePanel";
            this.UFimagePanel.Size = new System.Drawing.Size(640, 112);
            this.UFimagePanel.TabIndex = 1;
            this.UFimagePanel.Click += new System.EventHandler(this.About_dLOC_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(16, 144);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(640, 56);
            this.aboutLabel.TabIndex = 2;
            this.aboutLabel.Text = resources.GetString("aboutLabel.Text");
            this.aboutLabel.Click += new System.EventHandler(this.About_dLOC_Click);
            // 
            // licenseLabel
            // 
            this.licenseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.licenseLabel.BackColor = System.Drawing.Color.Transparent;
            this.licenseLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseLabel.Location = new System.Drawing.Point(16, 344);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(640, 128);
            this.licenseLabel.TabIndex = 3;
            this.licenseLabel.Text = "LICENSE_TEXT";
            this.licenseLabel.Click += new System.EventHandler(this.About_dLOC_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "For assistance with any part of this application, please see the Digital Library " +
                "of the Caribbean website for the current support staff.";
            this.label1.Click += new System.EventHandler(this.About_dLOC_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(136, 264);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(416, 23);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.dloc.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(640, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "-- Click anywhere to close this form --";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.About_dLOC_Click);
            // 
            // About_dLOC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(674, 519);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.licenseLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.UFimagePanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About_dLOC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About this project";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.About_dLOC_Click);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary> Method is called whenever this form is resized. </summary>
		/// <param name="e"></param>
		/// <remarks> This redraws the background of this form </remarks>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			// Get rid of any current background image
			if ( BackgroundImage != null )
			{
				BackgroundImage.Dispose();
				BackgroundImage = null;
			}

			// Create the items needed to draw the background
			Bitmap image = new Bitmap( ClientSize.Width, ClientSize.Height );
			Graphics gr = Graphics.FromImage( image );
			Rectangle rect = new Rectangle( new Point(0,0), ClientSize );

			// Create the brush
			LinearGradientBrush brush = new LinearGradientBrush( rect, Color.AntiqueWhite, ControlPaint.LightLight(Color.AntiqueWhite), LinearGradientMode.Vertical);
			brush.SetBlendTriangularShape(0.33F);
	
			// Create the image
			gr.FillRectangle( brush, rect );
			gr.Dispose();

			// Set this as the backgroundf
			BackgroundImage = image;
		}

		private void About_dLOC_Click(object sender, EventArgs e)
		{
				Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process showWebSite = new Process();
			showWebSite.StartInfo.FileName = "http://www.dloc.com/";
		}


	}
}
