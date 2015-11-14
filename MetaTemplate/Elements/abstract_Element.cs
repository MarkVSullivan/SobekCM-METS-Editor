#region Using directives

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SobekCM.METS_Editor.Help;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	public delegate void abstract_Element_Delegate( abstract_Element thisElement );

	/// <summary>
	/// Summary description for displayableElement.
	/// </summary>
	public class abstract_Element : UserControl, iElement
	{
		protected bool repeatable, mandatory, always_single, always_mandatory, is_constant, read_only;
		protected int index, minimum_title_length, title_length, maximum_input_length;
		protected string invalid_string, display_subtype;
		protected Element_Type type;
		protected Template_Language language;
		protected bool link_active, standard_mouse_actions;
		protected string title;

		public event abstract_Element_Delegate New_Element_Requested;
		public event abstract_Element_Delegate Help_Requested;
		public event abstract_Element_Delegate Redraw_Requested;
        public event abstract_Element_Delegate Data_Changed;

        private static Image helpButton;
        private static Image repeatableButton;
        private static abstract_HelpProvider helpProvider;
        protected static int help_button_width = 0;

		/// <summary> Constructor for a new abstract element object </summary>
		public abstract_Element()
		{
			// Set a default location for this
			Location = new Point( 15, 15 );

			// Set other default values
			always_single = false;
			always_mandatory = false;
			repeatable = false;
			mandatory = false;
			is_constant = false;
			read_only = false;
			link_active = false;
			standard_mouse_actions = true;
			display_subtype = String.Empty;
			invalid_string = String.Empty;
			index = 0;
			title_length = 100;
			minimum_title_length = 50;
			maximum_input_length = -1;
			title = String.Empty;
        }

        #region Static methods

        public static void Set_Button_Images( Image Help_Button, Image Repeatable_Button )
        {
            helpButton = Help_Button;
            repeatableButton = Repeatable_Button;
        }

        public static abstract_HelpProvider Help_Provider
        {
            get
            {
                return helpProvider;
            }
            set
            {
                helpProvider = value;
                if (helpProvider == null)
                    help_button_width = 0;
                else
                    help_button_width = 25;
            }
        }

        public static int Help_Button_Width
        {
            get
            {
                return help_button_width;
            }
        }

        #endregion

        #region Unimplemented methods added when I was forced to make this class non-abstract

        protected virtual void Inner_Read_Data(XmlTextReader xmlReader)
        {
            throw new NotImplementedException();
        }

        protected virtual string Inner_Write_Data()
        {
            throw new NotImplementedException();
        }

        protected virtual void Inner_Set_Height(float size)
        {
            throw new NotImplementedException();
        }

        protected virtual void Inner_Set_Width(int new_width)
        {
            throw new NotImplementedException();
        }

        protected virtual void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
        {
            throw new NotImplementedException();
        }

        protected virtual void Inner_Set_Read_Only()
        {
            throw new NotImplementedException();
        }

        protected virtual void Inner_Set_Language(Template_Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public virtual abstract_Element Clone()
        {
            throw new NotImplementedException();
        }

        public virtual string Help_URL()
        {
            throw new NotImplementedException();
        }

        public virtual void Prepare_For_Save(SobekCM_Item Bib)
        {
            throw new NotImplementedException();
        }

        public virtual void Save_To_Bib(SobekCM_Item Bib)
        {
            throw new NotImplementedException();
        }

        public virtual void Populate_From_Bib(SobekCM_Item Bib)
        {
            throw new NotImplementedException();
        }

        public virtual bool isValid()
        {
            throw new NotImplementedException();
        }

        public virtual bool hasValue
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region Abstract Methods to be implemented by abstract_Element classes

        ///// <summary> Reads the inner data from the Template XML format </summary>
        //protected abstract void Inner_Read_Data( XmlTextReader xmlReader );

        ///// <summary> Writes the inner data into Template XML format </summary>
        //protected abstract string Inner_Write_Data( );

        ///// <summary> Perform any height setting calculations specific to the 
        ///// implementation of abstract_Element.  </summary>
        ///// <param name="size"> Height of the font </param>
        //protected abstract void Inner_Set_Height( float size );

        ///// <summary> Perform any width setting calculations specific to the 
        ///// implementation of abstract_Element.  </summary>
        ///// <param name="size"> Height of the font </param>
        //protected abstract void Inner_Set_Width( int new_width );

        ///// <summary> Set the minimum title length specific to the 
        ///// implementation of abstract_Element.  </summary>
        ///// <param name="size"> Height of the font </param>
        //protected abstract void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language );

        ///// <summary> Perform any readonly functions specific to the
        ///// implementation of abstract_Element. </summary>
        //protected abstract void Inner_Set_Read_Only();

        ///// <summary> Make any changes in text necessary based on the language </summary>
        ///// <param name="newLanguage"></param>
        //protected abstract void Inner_Set_Language( Template_Language newLanguage );

        ///// <summary> Clones this element, not copying the actual data
        ///// in the fields, but all other values. </summary>
        ///// <returns>Clone of this element</returns>
        //public abstract abstract_Element Clone();

        ///// <summary> Help URL stub </summary>
        ///// <returns></returns>
        //public abstract string Help_URL();

		#endregion

		/// <summary> Gets the current title of this element, in the
		/// current user interface language </summary>
		public string Title
		{
			get
			{
				return title;
			}
		}	

		/// <summary> Gets and sets the flag indicating this is in readonly format,
		/// and no changes are allowed </summary>
		public bool Read_Only
		{
			get	{	return read_only;		}
			set
			{
				read_only = value;
				Inner_Set_Read_Only();
			}
		}

		/// <summary> Sets the current language for the user inteface </summary>
		public Template_Language Language 
		{ 
			get
			{
				return language;
			}
			set
			{
				// Save the new language
				language = value;

				// Set the title and title length based on the language
				Inner_Set_Language( value );
				Inner_Set_Minimum_Title_Length( Font, value );
				title_length = minimum_title_length;
			}
		}

		/// <summary> Returns the minimum length (in pixels) of the title </summary>
		public int Minimum_Title_Length
		{
			get	{	return minimum_title_length; }
		}

		/// <summary> Gets and sets the length of the title for this element. </summary>
		/// <remarks> A check is made against the Minimum_Title_Length property.</remarks>
		public int Title_Length
		{
			get	{	return title_length;	}
			set	
			{	
				if ( value < minimum_title_length )
					title_length = minimum_title_length;
				else
					title_length = value;
			}
		}

		/// <summary> Gets the maxium width (in pixels) needed for the input portion
		/// of this element. </summary>
		public int Maximum_Input_Length
		{
			get	{	return maximum_input_length;	}
		}

		/// <summary> Gets and sets an index used when an element is repeatable
		/// ane more than one appear on a template. </summary>
		public int Index
		{
			get	{	return index;		}
			set	{	index = value;		}
		}

		/// <summary> Sets the current font to use for this element </summary>
		/// <param name="CurrentFont">Font to use for display </param>
		/// <remarks>This sets the height of this control as well as the length
		/// of the element title. </remarks>
		public void Set_Font( Font CurrentFont )
		{
			Font = CurrentFont;
			Inner_Set_Height( CurrentFont.SizeInPoints );
			Inner_Set_Minimum_Title_Length( CurrentFont, language );
		}

		public void Set_Width( int new_width )
		{
			// Set the width based on certain values
			int scaled_maximum_input_length = (int) (( Font.SizeInPoints / 10.0 ) * maximum_input_length);
			if (( new_width > ( title_length + scaled_maximum_input_length )) && ( scaled_maximum_input_length > 0 ))
				new_width = title_length + scaled_maximum_input_length;
			Width = new_width;

			// Call the inner property to make any additional changes, based on the new width
			Inner_Set_Width( new_width );
		}

		public void OnNewElementRequested()
		{
			if ( New_Element_Requested != null )
			{
				New_Element_Requested( this );
			}
		}

		protected void OnRedrawRequested()
		{
			if ( Redraw_Requested != null )
			{
				Redraw_Requested( this );
			}
		}

		protected void OnHelpRequested()
		{
			if ( Help_Requested != null )
			{
				Help_Requested( this );
			}
		}

		protected void OnHelpRequested( abstract_Element thisElement )
		{
			if ( Help_Requested != null )
			{
				Help_Requested( thisElement );
			}
		}

        protected void OnDataChanged()
        {
            if ((Data_Changed != null) && ( !read_only ))
            {
                Data_Changed(this);
            }
        }

		protected void Draw_Repeatable_Help_Icons( Graphics g, int x, int y )
		{
            if (Repeatable)
            {
                g.DrawImage(repeatableButton, x, y - 2);
                if (helpProvider != null)
                    g.DrawImage(helpButton, x + help_button_width, y - 2);
            }
            else
            {
                if ( helpProvider != null )
                    g.DrawImage(helpButton, x, y - 2);
            }
		}


		protected void Draw_Info_Icon( Graphics g, int x, int y )
		{
			// Show information circle
			g.FillEllipse( new SolidBrush( Color.DarkBlue ), x, y, 17, 17 );
			g.DrawEllipse( new Pen( Color.Black), x, y, 17, 17 );
			g.FillRectangle( new SolidBrush( Color.White ), x + 8, y + 8, 3, 7 );
			g.FillRectangle( new SolidBrush( Color.White ), x + 8, y + 3, 3, 3 );
		}

		protected void Draw_Title( Graphics g, string title )
		{
			if ( index == 0 )
			{
				// Draw the name
				if ( link_active )
				{
					g.DrawString( title + ":", new Font( Font, FontStyle.Underline ), new SolidBrush( Color.Blue), 5, 6 );
				}
				else
				{
					g.DrawString( title + ":", Font, new SolidBrush( Color.Black ), 5, 6 );
				}
			}
		}

		#region iElement Members

		/// <summary> Gets the type of this element </summary>
		public Element_Type Type
		{
			get	{	return type;	}
		}

		/// <summary> Gets the display subtype for this element </summary>
		public string Display_SubType
		{
			get	{	return display_subtype;		}
		}

		/// <summary> Flag indicates if this is being used as a constant field,
		/// or if data can be entered by the user </summary>
		public bool isConstant
		{
			get	{	return is_constant;		}
			set	{	is_constant = value;	}
		}
        
		/// <summary> Gets and sets the flag indicating this allows repeatability </summary>
		public bool Repeatable 
		{ 
			get 
			{	
				if ( always_single )
					return false;
				else
					return repeatable;	
			}
			set	
			{
				if ( !always_single )
					repeatable = value;	
			}
		}	

		/// <summary> Gets and sets the flag indicating this is mandatory </summary>
		public bool Mandatory 
		{ 
			get 
			{	
				if ( always_mandatory )
					return true;
				else
					return mandatory;	
			}
			set	
			{	
				if ( !always_mandatory )
					mandatory = value;	
			}
		}

		/// <summary> Gets the invalid string, if this element did not pass validity </summary>
		public string Invalid_String
		{
			get	{	return invalid_string;		}
		}

		/// <summary> Reads from the template XML format </summary>
		/// <param name="inner_xml_string">Inner XML for this element </param>
		public void Read_XML( XmlTextReader xmlReader )
		{
			Inner_Read_Data( xmlReader );
		}

		/// <summary> Returns the XML string to save this element and its data to the template XML file </summary>
		/// <param name="indent"> Indent to use for each line </param>
		/// <returns>String for template XML file</returns>
		public string To_Template_XML( string indent )
		{
			// Get the innner data
			string inner_data = Inner_Write_Data();

			// Build the result
			StringBuilder results = new StringBuilder();

			// Start out the elements line
			results.Append( indent + "<element type=\"" + Element_Type_Convertor.ToString( Type ) + "\"");

			// Add the subtype, if there is one.
			if ( display_subtype.Length > 0 )
			{
				results.Append( " subtype=\"" + Display_SubType + "\"" );
			}

			// If this element is just being used as a constant, x will be less than 0
			if ( !isConstant )
			{
				// Add location and dimension to this
				results.Append(" x=\"" + Location.X + "\"" );
				results.Append( " y=\"" + Location.Y + "\"" );
				results.Append( " width=\"" + Width + "\"" );
				results.Append( " height=\"" + Height + "\"" );

				// Add repeatable if it is
				if ( Repeatable )
					results.Append( " repeatable=\"true\"");
				
				// Add mandatory if it is
				if ( Mandatory )
					results.Append( " mandatory=\"true\"");
			}

			if ( inner_data.Length == 0 )
			{
				// Finish off the first line
				results.Append(" />\r\n");
			}
			else
			{
				results.Append(">\r\n");
				results.Append( indent + "\t<element_data>\r\n");
				results.Append( indent + "\t\t" + inner_data );
				results.Append( indent + "\t</element_data>\r\n");
				results.Append( indent + "</element>\r\n" );
			}
		
			// Return the string
			return results.ToString();
		}

		#region Abstract Methods and Properties

        ///// <summary> Prepares the bib object for the save, by clearing the 
        ///// existing data in this element's related field. </summary>
        ///// <param name="Bib"> Existing Bib object </param>
        //public abstract void Prepare_For_Save( SobekCM_Item Bib );

        ///// <summary> Saves the data stored in this instance of the 
        ///// element to the provided bibliographic object </summary>
        ///// <param name="Bib"> Object into which to save this element's data </param>
        //public abstract void Save_To_Bib( SobekCM_Item Bib );

        ///// <summary> Saves the data stored in this instance of the 
        ///// element to the provided bibliographic object </summary>
        ///// <param name="Bib"> Object to populate this element from </param>
        //public abstract void Populate_From_Bib( SobekCM_Item Bib );

        ///// <summary> Tests for validity of the input, or lack of input </summary>
        ///// <returns>TRUE if valid, otherwise FALSE</returns>
        ///// <remarks> This sets the <see cref="abstract_Element.Invalid_String"/> property.</remarks>
        //public abstract bool isValid( );

        ///// <summary> Gets the flag indicating this element has an entered value </summary>
        //public abstract bool hasValue { get; }

		#endregion

		#endregion

		#region Mouse Listener Methods

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ( standard_mouse_actions )
			{
				// Determine the y-mid-point
				int midpoint = (int) (1.5 * Font.SizeInPoints );

				// Was this over the title
				if ((index == 0 ) && ( e.X < ( title_length - 10 )) && ( e.Y > 8 ) && ( e.Y < ( 13 + Font.SizeInPoints )))
				{
					OnHelpRequested();
				}

                // Was this over the '+' or help buttons?
                if (Repeatable)
                {
                    if ((e.X > Width - 23 - Help_Button_Width) && (e.X < Width - 3 - Help_Button_Width) && (e.Y > midpoint - 101) && (e.Y < midpoint + 9))
                    {
                        OnNewElementRequested();
                    }
                    if ((e.X > Width - 23) && (e.X < Width - 3) && (e.Y > midpoint - 11) && (e.Y < midpoint + 9))
                    {
                        OnHelpRequested();
                    }
                }
                else
                {
                    if ((e.X > Width - 23 - Help_Button_Width) && (e.X < Width - 3 - Help_Button_Width) && (e.Y > midpoint - 11) && (e.Y < midpoint + 9))
                    {
                        OnHelpRequested();
                    }
                }
			}

			// Call the base method
			base.OnMouseDown (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ( standard_mouse_actions )
			{
				// Determine the y-mid-point
				int midpoint = (int) (1.5 * Font.SizeInPoints );

				// Was this over the title
				bool overTitle = false;
				if ((index == 0 ) && ( e.X < ( title_length - 10 )) && ( e.Y > 8 ) && ( e.Y < ( 13 + Font.SizeInPoints )))
				{
					overTitle = true;
				}

				// Was this over the '+' or help buttons?
				bool overPlus = false;
                bool overHelp = false;
                if (Repeatable)
                {
                    if ((e.X > Width - 23 - Help_Button_Width) && (e.X < Width - 3 - Help_Button_Width) && (e.Y > midpoint - 101) && (e.Y < midpoint + 9))
                    {
                        overPlus = true;
                    }
                    if ((e.X > Width - 23) && (e.X < Width - 3) && (e.Y > midpoint - 11) && (e.Y < midpoint + 9))
                    {
                        overHelp = true;
                    }
                }
                else
                {
                    if ((e.X > Width - 23 - Help_Button_Width) && (e.X < Width - 3 - Help_Button_Width) && (e.Y > midpoint - 11) && (e.Y < midpoint + 9))
                    {
                        overHelp = true;
                    }
                }

				// Set the cursor correctly
				if (( overTitle ) || ( overPlus ) || ( overHelp ))
				{
					Cursor = Cursors.Hand;
				}
				else
				{
					Cursor = Cursors.Arrow;
				}

				// If over the title, do a bit more
				if ( overTitle )
				{
					if ( !link_active )
					{
						link_active = true;
						Invalidate();
					}
				}
				else
				{
					if ( link_active )
					{
						link_active = false;
						Invalidate();
					}
				}
			}

			// Call the base method
			base.OnMouseMove (e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			Cursor = Cursors.Arrow;

			if ( link_active )
			{
				link_active = false;
				Invalidate();
			}

			// Call the base method
			base.OnMouseLeave (e);
		}

		#endregion

	}
}
