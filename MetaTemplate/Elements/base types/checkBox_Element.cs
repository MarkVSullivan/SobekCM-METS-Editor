#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for checkBox_Element.
	/// </summary>
	public abstract class checkBox_Element : abstract_Element, iElement
	{
		protected CheckBox thisBox;
		protected string title;

		public checkBox_Element()
		{
			// Configure the text box
			thisBox = new CheckBox();
			thisBox.FlatStyle = FlatStyle.Flat;
			thisBox.Location = new Point( 115, 5 );
			thisBox.Size = new Size( 20, 20);
            thisBox.CheckedChanged += thisBox_CheckedChanged;
			Controls.Add( thisBox );

			// Set default title to blank
			title = "no default";

			always_single = true;
			base.maximum_input_length = 68;
		}

		public checkBox_Element( string defaultTitle )
		{
			// Configure the text box
			thisBox = new CheckBox();
			thisBox.FlatStyle = FlatStyle.Flat;
			thisBox.Location = new Point( 115, 5 );
			thisBox.Size = new Size(20,20);
            thisBox.CheckedChanged += thisBox_CheckedChanged;
			Controls.Add( thisBox );

			// Save the title
			title = defaultTitle;

			always_single = true;
			base.maximum_input_length = 43;
		}

        void thisBox_CheckedChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
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
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22, midpoint - 6);

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
					string default_value = xmlReader.Value.Trim().ToUpper();
					if (( default_value == "TRUE" ) || ( default_value == "YES" ))
					{
						thisBox.Checked = true;
					}
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
			Height = size_int + ( size_int + 7 );
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
			// Set the width of the text box
			thisBox.Location = new Point( base.title_length, thisBox.Location.Y );
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				thisBox.Enabled = false;
			}
			else
			{
				thisBox.Enabled = true;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>NULL value... a boolean value has no business being cloned.</returns>
		public override abstract_Element Clone()
		{
			return null;
		}

		/// <summary> Checks the data in this element for validity. </summary>
		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			return true;
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				// Checkbox always has SOME value
				return true;
			}
		}


		#endregion

	}
}
