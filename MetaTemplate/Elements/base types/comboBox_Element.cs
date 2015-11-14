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
	/// Summary description for comboBox_Element.
	/// </summary>
	public abstract class comboBox_Element : abstract_Element, iElement
	{
//		protected DrawFlat.FlatComboBox thisBox;
        protected ComboBox thisBox;
		private TextBox readonlyBox;
		private bool restrict_values;
        private bool isXP;

		public comboBox_Element()
		{
			// Configure the text box
///			thisBox = new FlatComboBox();
            thisBox = new ComboBox();
			thisBox.Location = new Point( 115, 2 );
			thisBox.TextChanged +=thisBox_TextChanged;
            thisBox.SelectedIndexChanged += thisBox_SelectedIndexChanged;
            thisBox.BackColor = Color.White;
            thisBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisBox );

			// Configure the read-only box, but leave it hidden
			readonlyBox = new TextBox();
			readonlyBox.Location = new Point( 115, 2 );
			readonlyBox.Hide();
			readonlyBox.BackColor = Color.WhiteSmoke;
			readonlyBox.ReadOnly = true;
            readonlyBox.ForeColor = Color.MediumBlue;
			Controls.Add( readonlyBox );

			// Set default title to blank
			title = "no default";
			restrict_values = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisBox.FlatStyle = FlatStyle.Flat;
                readonlyBox.BorderStyle = BorderStyle.FixedSingle;
                isXP = false;
            }
            else
            {
                isXP = true;
            }
		}

		public comboBox_Element( string defaultTitle )
		{
			// Configure the text box
	///		thisBox = new FlatComboBox();
            thisBox = new ComboBox();
			thisBox.Location = new Point( 115, 2 );
			thisBox.TextChanged +=thisBox_TextChanged;
            thisBox.SelectedIndexChanged += thisBox_SelectedIndexChanged;
            thisBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisBox );

			// Configure the read-only box, but leave it hidden
			readonlyBox = new TextBox();
			readonlyBox.Location = new Point( 115, 2 );
            readonlyBox.Hide();
			readonlyBox.BackColor = Color.WhiteSmoke;
			readonlyBox.ReadOnly = true;
            readonlyBox.ForeColor = Color.MediumBlue;
			Controls.Add( readonlyBox );

			// Save the title
			title = defaultTitle;
			restrict_values = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisBox.FlatStyle = FlatStyle.Flat;
                readonlyBox.BorderStyle = BorderStyle.FixedSingle;
                isXP = false;
            }
            else
            {
                isXP = true;
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

       
		/// <summary> Gets and sets the flag indicating values are limited to
		/// those in the drop down list. </summary>
		protected bool Restrict_Values
		{
			get	{	return restrict_values;		}
			set	
			{
				restrict_values = value;

				if ( value )
				{
					thisBox.DropDownStyle = ComboBoxStyle.DropDownList;
				}
				else
				{
					thisBox.DropDownStyle = ComboBoxStyle.DropDown;
				}
			}
		}

        public void Set_Values(string[] values)
        {
            thisBox.Items.Clear();
            thisBox.Items.AddRange(values);
        }

		/// <summary> Add Items to this combo box </summary>
		/// <param name="newItem"></param>
		public void Add_Item( string newItem )
		{
			if ( !thisBox.Items.Contains( newItem ))
			{
				thisBox.Items.Add( newItem );
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
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22 - Help_Button_Width, midpoint - 7);

			// Call this for the base
			base.OnPaint (e);

            if ((!isXP) && (!read_only))
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), thisBox.Location.X - 1, thisBox.Location.Y - 1, thisBox.Width + 1, thisBox.Height + 1);
            }
		}

		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReader )
		{
			string default_value = String.Empty;
			while ( xmlReader.Read() )
			{
				if (( xmlReader.NodeType == XmlNodeType.Element ) && (( xmlReader.Name.ToLower() == "value" ) || ( xmlReader.Name.ToLower() == "options" ))) 
				{
					if ( xmlReader.Name.ToLower() == "value" )
					{
						xmlReader.Read();
						default_value = xmlReader.Value.Trim();
					}
					else
					{
						xmlReader.Read();
						string options = xmlReader.Value.Trim();
						thisBox.Items.Clear();
						if ( options.Length > 0 )
						{
							string[] options_parsed = options.Split(",".ToCharArray());
							foreach( string thisOption in options_parsed )
							{
                                if (!thisBox.Items.Contains(thisOption.Trim().ToUpper()))
								{
									thisBox.Items.Add( thisOption.Trim().ToUpper() );
								}
							}
						}
					}
				}
			}

			// Set the value if there was one
			if ( default_value.Length > 0 )
			{	
				thisBox.Text = default_value;
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
			// Set the width of the text box
            thisBox.Width = new_width - base.title_length - 30 - Help_Button_Width;
			thisBox.Location = new Point( base.title_length, thisBox.Location.Y );
			readonlyBox.Width = thisBox.Width;
			readonlyBox.Location = thisBox.Location;
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				thisBox.Enabled = false;
				readonlyBox.Show();
				thisBox.Hide();
			}
			else
			{
				thisBox.Enabled = true;
				readonlyBox.Hide();
				thisBox.Show();
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			// Get the new element
			comboBox_Element newElement = (comboBox_Element) Element_Factory.getElement( Type, Display_SubType );
			newElement.Location = Location;
			newElement.Language = Language;
			newElement.Title_Length = Title_Length;
			newElement.Height = Height;
			newElement.Font = Font;
			newElement.Set_Width( Width );
			newElement.Index = Index + 1;

			// Copy the combo box specific values
			newElement.Restrict_Values = Restrict_Values;
			foreach( string thisItem in thisBox.Items )
			{
				newElement.Add_Item( thisItem );
			}

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

		private void thisBox_TextChanged(object sender, EventArgs e)
		{
			readonlyBox.Text = thisBox.Text;
            base.OnDataChanged();
		}

        void thisBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            readonlyBox.Text = thisBox.Text;
            base.OnDataChanged();
        }
	}
}
