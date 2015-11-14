#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for keywordScheme_Element.
	/// </summary>
	public abstract class keywordScheme_Element : abstract_Element, iElement
	{
//		protected DrawFlat.FlatComboBox thisSchemeBox;
        protected ComboBox thisSchemeBox;
		protected TextBox thisKeywordBox;
		private TextBox readonlySchemeBox;
		protected string scheme;
		private int scheme_length;
        private bool isXP;

		public keywordScheme_Element()
		{
			// Configure the keyword box
			thisKeywordBox = new TextBox();
			thisKeywordBox.Location = new Point( 115, 2 );
			thisKeywordBox.BackColor = Color.White;
            thisKeywordBox.TextChanged += thisKeywordBox_TextChanged;
            thisKeywordBox.Enter += textBox_Enter;
            thisKeywordBox.Leave += textBox_Leave;
            thisKeywordBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisKeywordBox );

			// Configure the scheme box
///			thisSchemeBox = new FlatComboBox();
            thisSchemeBox = new ComboBox();
			thisSchemeBox.Width = 110;
			thisSchemeBox.Location = new Point( Width - thisSchemeBox.Width - 50, 2 );
			thisSchemeBox.TextChanged +=thisSchemeBox_TextChanged;
            thisSchemeBox.Enter += thisSchemeBox_Enter;
            thisSchemeBox.Leave += thisSchemeBox_Leave;
            thisSchemeBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisSchemeBox );

			// Configure the scheme box, but leave it hidden
			readonlySchemeBox = new TextBox();
			readonlySchemeBox.Location = thisSchemeBox.Location;
			readonlySchemeBox.Width = 110;
			readonlySchemeBox.Hide();
			readonlySchemeBox.BackColor = Color.WhiteSmoke;
			readonlySchemeBox.ReadOnly = true;
            readonlySchemeBox.Enter += textBox_Enter;
            readonlySchemeBox.Leave += textBox_Leave;
            readonlySchemeBox.ForeColor = Color.MediumBlue;
			Controls.Add( readonlySchemeBox );

			// Set default title to blank
			title = "no default";
			scheme = "Scheme";
			scheme_length = 50;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisSchemeBox.FlatStyle = FlatStyle.Flat;
                thisKeywordBox.BorderStyle = BorderStyle.FixedSingle;
                readonlySchemeBox.BorderStyle = BorderStyle.FixedSingle;
                isXP = false;
            }
            else
            {
                isXP = true;
            }
		}

		public keywordScheme_Element( string defaultTitle )
		{
			
			// Configure the key word box
			thisKeywordBox = new TextBox();
			thisKeywordBox.Location = new Point( 115, 2 );
			thisKeywordBox.BackColor = Color.White;
            thisKeywordBox.TextChanged += thisKeywordBox_TextChanged;
            thisKeywordBox.Enter += textBox_Enter;
            thisKeywordBox.Leave += textBox_Leave;
            thisKeywordBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisKeywordBox );

			// Configure the scheme box
	//		thisSchemeBox = new FlatComboBox();
            thisSchemeBox = new ComboBox();
			thisSchemeBox.Width = 110;
			thisSchemeBox.Location = new Point( Width - thisSchemeBox.Width - 50, 2 );
			thisSchemeBox.TextChanged +=thisSchemeBox_TextChanged;
			thisSchemeBox.SizeChanged +=thisSchemeBox_SizeChanged;
            thisSchemeBox.Enter += thisSchemeBox_Enter;
            thisSchemeBox.Leave += thisSchemeBox_Leave;
            thisSchemeBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisSchemeBox );

			// Configure the scheme box, but leave it hidden
			readonlySchemeBox = new TextBox();
			readonlySchemeBox.Location = thisSchemeBox.Location;
			readonlySchemeBox.Width = 110;
			readonlySchemeBox.Hide();
			readonlySchemeBox.BackColor = Color.WhiteSmoke;
			readonlySchemeBox.ReadOnly = true;
            readonlySchemeBox.Enter += textBox_Enter;
            readonlySchemeBox.Leave += textBox_Leave;
            readonlySchemeBox.ForeColor = Color.MediumBlue;
			Controls.Add( readonlySchemeBox );

			// Save the title
			title = defaultTitle;
			scheme = "Scheme";
			scheme_length = 50;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisSchemeBox.FlatStyle = FlatStyle.Flat;
                thisKeywordBox.BorderStyle = BorderStyle.FixedSingle;
                readonlySchemeBox.BorderStyle = BorderStyle.FixedSingle;
                isXP = false;
            }
            else
            {
                isXP = true;
            }
		}

        void thisSchemeBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                thisSchemeBox.BackColor = Color.White;
            }
        }

        void thisSchemeBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                thisSchemeBox.BackColor = Color.Khaki;
            }
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

		/// <summary> Add a code to this combo box </summary>
		/// <param name="newItem"></param>
		public void Add_Scheme( string newItem )
		{
			if ( !thisSchemeBox.Items.Contains( newItem ))
			{
				thisSchemeBox.Items.Add( newItem );
			}
		}

		protected int Scheme_Length
		{
			set
			{
				scheme_length = value;
				position_boxes();
			}
		}

		/// <summary> Override the OnPaint method to draw the title before the text box </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the title
			base.Draw_Title( e.Graphics, title );

			// Draw the scheme
			int scheme_spot = (int) (( Font.SizeInPoints / 10.0 ) * scheme_length);
            e.Graphics.DrawString(scheme + ":", new Font(Font.FontFamily, Font.SizeInPoints - 1), new SolidBrush(Color.DimGray), Width - thisSchemeBox.Width - 35 - scheme_spot - Help_Button_Width, 6 );

			// Determine the y-mid-point
			int midpoint = (int) (1.5 * Font.SizeInPoints );

			// If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22 - Help_Button_Width, midpoint - 8);


			// Call this for the base
			base.OnPaint (e);
            
            if ((!isXP) && ( !read_only ))
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), thisSchemeBox.Location.X - 1, thisSchemeBox.Location.Y - 1, thisSchemeBox.Width + 1, thisSchemeBox.Height + 1);
            }
		}

		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReader )
		{
			string default_value = String.Empty;
			while ( xmlReader.Read() )
			{
				if (( xmlReader.NodeType == XmlNodeType.Element ) && (( xmlReader.Name.ToLower() == "scheme" ) || ( xmlReader.Name.ToLower() == "options" ) || ( xmlReader.Name.ToLower() == "keyword"))) 
				{
					if ( xmlReader.Name.ToLower() == "scheme" )
					{
						xmlReader.Read();
						default_value = xmlReader.Value.Trim();
					}

					if ( xmlReader.Name.ToLower() == "keyword" )
					{
						xmlReader.Read();
						thisKeywordBox.Text = xmlReader.Value.Trim();
					}

					if ( xmlReader.Name.ToLower() == "options" )
					{
						xmlReader.Read();
						string options = xmlReader.Value.Trim();
						thisSchemeBox.Items.Clear();
						if ( options.Length > 0 )
						{
							string[] options_parsed = options.Split(",".ToCharArray());
							foreach( string thisOption in options_parsed )
							{
								if ( !thisSchemeBox.Items.Contains( thisOption.Trim() ))
								{
									thisSchemeBox.Items.Add( thisOption.Trim() );
								}
							}
						}
					}
				}
			}

			// Set the value if there was one
			if ( default_value.Length > 0 )
			{	
				thisSchemeBox.Text = default_value;
			}
		}

		/// <summary> Writes the inner data into Template XML format </summary>
		protected override string Inner_Write_Data( )
		{
			return String.Empty;
		}

		/// <summary> Perform any height setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Height( float size )
		{
			// Set total height
			int size_int = (int) size;
			Height = size_int + ( size_int + 9 ) + 1;

			// Now, set the height of the text box
			//			thisBox.Height =  ( size_int + 7 ) + 4;
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
			position_boxes();
		}

		private void position_boxes( )
		{
			int scheme_by_font = (int) (( Font.SizeInPoints / 10.0 ) * scheme_length);

			// Set the width of the text box
            thisKeywordBox.Width = Width - base.title_length - thisSchemeBox.Width - 50 - scheme_by_font - Help_Button_Width;
			thisKeywordBox.Location = new Point( base.title_length, thisKeywordBox.Location.Y );

			// Set the location of the code box
            thisSchemeBox.Location = new Point(Width - thisSchemeBox.Width - 30 - Help_Button_Width, thisSchemeBox.Location.Y);
			readonlySchemeBox.Location = thisSchemeBox.Location;
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				thisSchemeBox.Enabled = false;
				thisSchemeBox.Hide();
				readonlySchemeBox.Show();
				thisKeywordBox.ReadOnly = true;
				thisKeywordBox.BackColor = Color.WhiteSmoke;
			}
			else
			{
				thisSchemeBox.Enabled = true;
				thisSchemeBox.Show();
				readonlySchemeBox.Hide();
				thisKeywordBox.ReadOnly = false;
				thisKeywordBox.BackColor = Color.White;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			// Get the new element
			keywordScheme_Element newElement = (keywordScheme_Element) Element_Factory.getElement( Type, Display_SubType );
			newElement.Location = Location;
			newElement.Language = Language;
			newElement.Title_Length = Title_Length;
			newElement.Height = Height;
			newElement.Font = Font;
			newElement.Set_Width( Width );
			newElement.Index = Index + 1;

			// Copy the combo box specific values
			foreach( string thisItem in thisSchemeBox.Items )
			{
				newElement.Add_Scheme( thisItem );
			}

			return newElement;
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				if ( thisKeywordBox.Text.Trim().Length > 0 )
					return true;
				else
					return false;
			}
		}

		/// <summary> Checks the data in this element for validity. </summary>
		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			return true;
		}

		#endregion

		private void thisSchemeBox_TextChanged(object sender, EventArgs e)
		{
			readonlySchemeBox.Text = thisSchemeBox.Text;
            base.OnDataChanged();
		}

        void thisKeywordBox_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }

		private void thisSchemeBox_SizeChanged(object sender, EventArgs e)
		{
			readonlySchemeBox.Width = thisSchemeBox.Width;
		}
	}
}
