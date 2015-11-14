#region Using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary> About is a form used to display the simple versioning and copyright information
	/// for an application. <br /> <br /> </summary>
	/// <remarks> This form appears and goes away when the user clicks the form anywhere.  This form
	/// is often used in concert with the <see cref="VersionChecker"/> and <see cref="VersionConfigSettings"/> objects,
	/// as shown in the second example below. 	
	/// <br /> <br />
	/// Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.  </remarks>
	/// <example> EXAMPLE 1: Shows how to use this form in a stand-alone application.
	/// <code> <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using CustomTools.Forms;
	///
	///	namespace CustomTools
	///	{
	///		public class AboutForm_Example_1
	///		{
	///			static void Main() 
	///			{
	///				// Create a new About Form
	///				About showAbout = new About( "Baldwin Record Importer", "1.1.0" );
	///				showAbout.ShowDialog();
	///			}
	///		}
	///	}
	///	</code> <br />
	///	Below is what this form will look like: <br /> <br />
	///	<img src="AboutForm.jpg" />
	/// <br /> <br /> <br />
	/// EXAMPLE 2: Using the About form in conjunction with the <see cref="VersionChecker"/> solution and <see cref="VersionConfigSettings"/> object.
	/// <code> <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using CustomTools;
	///	using CustomTools.Forms;
	///
	///	namespace CustomTools
	///	{
	///		public class AboutForm_Example_2
	///		{
	///			static void Main() 
	///			{
	///				// Create a new About Form
	///				About showAbout = new About( VersionConfigSettings.AppName, VersionConfigSettings.AppName );
	///				showAbout.ShowDialog();
	///			}
	///		}
	///	}
	///	</code>
	/// </example>
	public class About : Form
	{
		/// <summary> Private form-related Panel variable holds all the information in the white box </summary>
		private Panel UFimagePanel;

		/// <summary> Private form-related Label variable holds the textual boxes. </summary>
        private Label developedByLabel, versionLabel;

		/// <summary> Required designer variable. </summary>
		private Container components = null;

		/// <summary> Private string holds the version information. </summary>
		private string version;
		private PictureBox pictureBox1;
        private Label label1;
        private Label editorLabel;
        private Label viewerLabel;
        private Panel orangeBar;
        private Label metsLabel;

		/// <summary> Private string holds the name of this application. </summary>
		private string appName;

		/// <summary> Default constructor accepts the version number of this software. </summary>
		/// <param name="appName"> Name of the application </param>
		/// <param name="version"> Version number for the application </param>
		public About( string appName, string version )
		{
			// Save the parameters
			this.version = version;
			this.appName = appName;

			// Initialize this form
			InitializeComponent();

			// Now, modify the form correctly
			Text = "About " + appName + " ( Version " + version + " )";
			versionLabel.Text = "( Version " + version + " )";
			//this.AppNameLabel.Text = appName;
		}

        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Get rid of any current background image
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            if (ClientSize.Width > 0)
            {
                // Create the items needed to draw the background
                Bitmap image = new Bitmap(ClientSize.Width, ClientSize.Height);
                Graphics gr = Graphics.FromImage(image);
                Rectangle rect = new Rectangle(new Point(0, 0), ClientSize);

                // Create the brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, SystemColors.Control, ControlPaint.Dark(SystemColors.Control), LinearGradientMode.Vertical);
                brush.SetBlendTriangularShape(0.33F);

                // Create the image
                gr.FillRectangle(brush, rect);
                gr.Dispose();

                // Set this as the backgroundf
                BackgroundImage = image;
            }
        }

		/// <summary> Clean up any resources being used. </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.UFimagePanel = new System.Windows.Forms.Panel();
            this.editorLabel = new System.Windows.Forms.Label();
            this.viewerLabel = new System.Windows.Forms.Label();
            this.orangeBar = new System.Windows.Forms.Panel();
            this.metsLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.developedByLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UFimagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UFimagePanel
            // 
            this.UFimagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UFimagePanel.BackColor = System.Drawing.Color.White;
            this.UFimagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UFimagePanel.Controls.Add(this.editorLabel);
            this.UFimagePanel.Controls.Add(this.viewerLabel);
            this.UFimagePanel.Controls.Add(this.orangeBar);
            this.UFimagePanel.Controls.Add(this.metsLabel);
            this.UFimagePanel.Controls.Add(this.pictureBox1);
            this.UFimagePanel.Controls.Add(this.versionLabel);
            this.UFimagePanel.Controls.Add(this.developedByLabel);
            this.UFimagePanel.Location = new System.Drawing.Point(22, 36);
            this.UFimagePanel.Name = "UFimagePanel";
            this.UFimagePanel.Size = new System.Drawing.Size(528, 243);
            this.UFimagePanel.TabIndex = 0;
            this.UFimagePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UFimagePanel_MouseDown);
            // 
            // editorLabel
            // 
            this.editorLabel.AutoSize = true;
            this.editorLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.editorLabel.Location = new System.Drawing.Point(211, 54);
            this.editorLabel.Name = "editorLabel";
            this.editorLabel.Size = new System.Drawing.Size(79, 26);
            this.editorLabel.TabIndex = 8;
            this.editorLabel.Text = "Editor";
            // 
            // viewerLabel
            // 
            this.viewerLabel.AutoSize = true;
            this.viewerLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.viewerLabel.Location = new System.Drawing.Point(211, 28);
            this.viewerLabel.Name = "viewerLabel";
            this.viewerLabel.Size = new System.Drawing.Size(85, 26);
            this.viewerLabel.TabIndex = 7;
            this.viewerLabel.Text = "Viewer";
            // 
            // orangeBar
            // 
            this.orangeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(51)))));
            this.orangeBar.Location = new System.Drawing.Point(202, 20);
            this.orangeBar.Name = "orangeBar";
            this.orangeBar.Size = new System.Drawing.Size(3, 65);
            this.orangeBar.TabIndex = 6;
            // 
            // metsLabel
            // 
            this.metsLabel.AutoSize = true;
            this.metsLabel.Font = new System.Drawing.Font("Franklin Gothic Demi", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.metsLabel.Location = new System.Drawing.Point(14, 14);
            this.metsLabel.Name = "metsLabel";
            this.metsLabel.Size = new System.Drawing.Size(198, 81);
            this.metsLabel.TabIndex = 5;
            this.metsLabel.Text = "METS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 66);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(3, 152);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(232, 23);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // developedByLabel
            // 
            this.developedByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.developedByLabel.BackColor = System.Drawing.Color.Transparent;
            this.developedByLabel.Location = new System.Drawing.Point(4, 198);
            this.developedByLabel.Name = "developedByLabel";
            this.developedByLabel.Size = new System.Drawing.Size(256, 40);
            this.developedByLabel.TabIndex = 1;
            this.developedByLabel.Text = "Developed by Mark Sullivan for the Digital Library Center at the University of Fl" +
                "orida George A. Smathers Libraries";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(153, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Click anywhere on this form to close ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(574, 312);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UFimagePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(576, 314);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(576, 314);
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Click += new System.EventHandler(this.About_Click);
            this.UFimagePanel.ResumeLayout(false);
            this.UFimagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary> Private Event_Handler is called when the form is clicked.  
		/// This closes the form. </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void About_Click(object sender, EventArgs e)
		{
			Close();
		}

        private void UFimagePanel_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }


        /////// <summary> Method is called whenever this form is resized. </summary>
        /////// <param name="e"></param>
        /////// <remarks> This redraws the background of this form </remarks>
        ////protected override void OnResize(EventArgs e)
        ////{
        ////    base.OnResize(e);

        ////    // Get rid of any current background image
        ////    if ( this.BackgroundImage != null )
        ////    {
        ////        this.BackgroundImage.Dispose();
        ////        this.BackgroundImage = null;
        ////    }

        ////    // Create the items needed to draw the background
        ////    Bitmap image = new Bitmap( this.ClientSize.Width, this.ClientSize.Height );
        ////    Graphics gr = Graphics.FromImage( image );
        ////    Rectangle rect = new Rectangle( new Point(0,0), this.ClientSize );

        ////    // Create the brush
        ////    LinearGradientBrush brush = new LinearGradientBrush( rect, Color.AntiqueWhite, ControlPaint.LightLight(Color.AntiqueWhite), LinearGradientMode.Vertical);
        ////    brush.SetBlendTriangularShape(0.33F);
	
        ////    // Create the image
        ////    gr.FillRectangle( brush, rect );
        ////    gr.Dispose();

        ////    // Set this as the backgroundf
        ////    this.BackgroundImage = image;
        ////}
	}
}
