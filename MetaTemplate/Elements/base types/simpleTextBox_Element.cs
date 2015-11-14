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
	/// Summary description for simpleTextBox_Element.
	/// </summary>
	public abstract class simpleTextBox_Element : abstract_Element, iElement
	{
		protected TextBox thisBox;
		private int lines = 1;
        protected bool listenForChange;

		public simpleTextBox_Element()
		{
			// Configure the text box
			thisBox = new TextBox();

			thisBox.Location = new Point( 115, 2 );
			thisBox.BackColor = Color.White;
            thisBox.ForeColor = Color.MediumBlue;
            thisBox.KeyDown += thisBox_KeyDown;
			Controls.Add( thisBox );

			// Set default title to blank
            listenForChange = true;
			title = "no default";

            // Add interest in the text box changing
            thisBox.TextChanged += thisBox_TextChanged;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisBox.BorderStyle = BorderStyle.FixedSingle;
            }
		}

		public simpleTextBox_Element( string defaultTitle )
		{
			// Configure the text box
			thisBox = new TextBox();
			thisBox.Location = new Point( 115, 2 );
			thisBox.BackColor = Color.White;
            thisBox.ForeColor = Color.MediumBlue;
            thisBox.KeyDown += thisBox_KeyDown;
			Controls.Add( thisBox );

			// Save the title
            listenForChange = true;
			title = defaultTitle;

            // Add interest in the text box changing
            thisBox.TextChanged += thisBox_TextChanged;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisBox.BorderStyle = BorderStyle.FixedSingle;
            }
		}

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && ( !base.always_single ) && ( !base.read_only ))
            {
                e.Handled = true;
                base.OnNewElementRequested();
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (!read_only)
            {
                thisBox.BackColor = Color.Khaki;
            }
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!read_only)
            {
                thisBox.BackColor = Color.White;
            }
            base.OnLeave(e);
        }

        void thisBox_TextChanged(object sender, EventArgs e)
        {
            if (listenForChange)
            {
                base.OnDataChanged();
            }
        }

		/// <summary> Gets and sets the number of lines for this text box </summary>
		protected int Lines
		{
			get
			{
				return lines;
			}
			set
			{
				lines = value;
				if ( lines > 1 )
				{
					thisBox.Multiline = true;
				}
				else
				{
					thisBox.Multiline = false;
				}
			}
		}

		/// <summary> Override the OnPaint method to draw the title before the text box </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the title
			base.Draw_Title( e.Graphics, title );

			// Determine the y-mid-point
			int midpoint = (int) (1.5 * Font.SizeInPoints );

			// If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22 - Help_Button_Width, midpoint - 8);

			// Call this for the base
			base.OnPaint (e);
		}

		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReader )
		{
			while ( xmlReader.Read() )
			{
				if (( xmlReader.NodeType == XmlNodeType.Element ) && ( xmlReader.Name.ToLower() == "value" ))
				{
					xmlReader.Read();
					thisBox.Text = xmlReader.Value.Trim();
					return;
				}
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
			Height = size_int + (( size_int + 8 )* lines );

			// Now, set the height of the text box
			if ( lines > 0 )
			{
				thisBox.Height =  ( size_int + 8 ) * lines + 4;
			}

            
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
			// Set the width of the text box
			thisBox.Width = new_width - base.title_length - 30 - Help_Button_Width;
			thisBox.Location = new Point( base.title_length, thisBox.Location.Y );
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				thisBox.ReadOnly = true;
				thisBox.BackColor = Color.WhiteSmoke;
			}
			else
			{
				thisBox.ReadOnly = false;
				thisBox.BackColor = Color.White;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			// Get the new element
			simpleTextBox_Element newElement = (simpleTextBox_Element) Element_Factory.getElement( Type, Display_SubType );
			newElement.Location = Location;
			newElement.Language = Language;
			newElement.Title_Length = Title_Length;
			newElement.Lines = Lines;
			newElement.Height = Height;
			newElement.Font = Font;
			newElement.Set_Width( Width );
			newElement.Index = Index + 1;
            newElement.Inner_Set_Height( Font.SizeInPoints );
			return newElement;
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				if ( thisBox.Text.Trim().Length > 0 )
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

	}
}
