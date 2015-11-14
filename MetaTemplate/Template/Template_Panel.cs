#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SobekCM.METS_Editor.Elements;

#endregion

namespace SobekCM.METS_Editor.Template
{
    /// <summary> Stores the data about a single panel within a page in a template </summary>
	public class Template_Panel
	{
	    private Font currentFont;
        private int height, width;
	    private int y;

        private readonly Dictionary<Template_Language, string> allPanelTitles;
        private readonly Element_Collection elements;

	    /// <summary> Constructor for a new Template_Panel object </summary>
		public Template_Panel()
		{
			// Set some defaults
			Title = String.Empty;
            elements = new Element_Collection();
			allPanelTitles = new Dictionary<Template_Language, string>();
		}

		/// <summary> Constructor for a new Template_Panel object </summary>
		/// <param name="Title"> Default title for this panel </param>
		public Template_Panel( string Title )
		{
			// Set some defaults
			this.Title = Title;
			elements = new Element_Collection();
            allPanelTitles = new Dictionary<Template_Language, string> {{Template_Language.English, Title}};
		}

	    /// <summary> Gets the collection of elements displayed within this panel  </summary>
	    public Element_Collection Elements
		{
			get
			{
				return elements;
			}
		}

        /// <summary> Gets the current (language-specific) title for this panel </summary>
        public string Title { get; private set; }

        /// <summary> Gets or sets the horizontal location of this panel on the page within the template (in pixels) </summary>
        public int X { get; set; }

        /// <summary> Gets or sets the vertical location of this panel on the page within the template (in pixels) </summary>
		public int Y
		{
			get	{	return y;	}
			set	
			{	
				// Determine the change in Y
				int y_change = value - y;

				// Set the new y
				y = value;	

				// Move all elements by y_change
				foreach( abstract_Element thisElement in elements )
				{
					thisElement.Location = new Point( thisElement.Location.X, thisElement.Location.Y + y_change );
				}
			}
		}

		/// <summary> Gets or sets the width of this panel (in pixels) </summary>
		/// <remarks> When the width is set this way, the elements within this panel are alerted to the new width </remarks>
		public int Width
		{
			get	{	return width;	}
			set	
			{	
				// Save the new width
				width = value;

				// Set the width of all the child elements
				Compute_Widths();
			}
		}

		/// <summary> Gets or sets the height of this panel </summary>
		public int Height
		{
			get	{	return height;	}
			set	{	height = value;	}
		}

		/// <summary> Allows the current font to be set for this panel and all child elements  </summary>
		public Font Current_Font
		{
			set
			{
				// Save this font
				currentFont = value;

				// Also, set all the elements
				elements.Current_Font = value;

				// Compute heights
				Compute_Height_And_Locations();

				// Compute widths
				Compute_Widths();
			}
		}

	    /// <summary> Add a title in a particular language to this panel </summary>
	    /// <param name="Language"> Language of the title </param>
	    /// <param name="Language_Specific_Title"> Title to display </param>
        public void Set_Title(Template_Language Language, string Language_Specific_Title)
	    {
	        // If the title has no length, this is a request to REMOVE a title
            if ( String.IsNullOrEmpty(Language_Specific_Title))
	        {
	            if ( allPanelTitles.ContainsKey( Language ) )
	                allPanelTitles.Remove( Language );
	        }
	        else
	        {
	            // Add this new title to the collection
                allPanelTitles[Language] = Language_Specific_Title;
	        }
	    }

	    /// <summary> Set the current user interface language </summary>
	    /// <param name="Language">New language selected by the user </param>
	    /// <remarks>This also sets the language for all child elements </remarks>
	    public void Set_Language( Template_Language Language )
	    {
	        // Set the current page title by the language
	        if ( allPanelTitles.ContainsKey( Language ))
	            Title = allPanelTitles[ Language ];
	        else if ( allPanelTitles.ContainsKey( Template_Language.English ))
	            Title = allPanelTitles[ Template_Language.English ];
	        else
	            Title = String.Empty;

	        // Set the language for each element
	        foreach( abstract_Element thisElement in elements )
	        {
	            thisElement.Language = Language;
	        }

	        // Recompute widths and place elemens
	        Compute_Widths();
	    }

	    private void Compute_Widths()
	    {
	        // Recompute the widths for this panel, by first finding the minimum
	        // title length for this
	        int minimum_width = (from abstract_Element thisElement in elements select thisElement.Minimum_Title_Length).Concat(new[] {1}).Max();

	        // Set each of the elements title length in this element to the
	        // minimum width
	        foreach( abstract_Element thisElement in elements )
	        {
	            // Set the title length
	            thisElement.Title_Length = minimum_width;
	            //	thisElement.Title_Length = thisElement.Minimum_Title_Length;

	            // Set the width
	            thisElement.Set_Width( Width - 20 );
	        }
	    }

	    /// <summary> Returns the XML string to save this panel to the template XML file </summary>
	    /// <returns>String for template XML file</returns>
	    public string To_Template_XML()
	    {
	        // Build the results for this panel, and each element in the page
	        StringBuilder results = new StringBuilder();

	        // Start this panel
	        results.Append( "\t\t\t<panel>\r\n");

	        // Write each of the titles for this panel
	        foreach( KeyValuePair<Template_Language, string> thisEntry in allPanelTitles )
	        {
	            // If this language is known, write it
                if (thisEntry.Key != Template_Language.Unknown)
	            {
                    results.Append("\t\t\t\t<name language=\"" + Template_Language_Convertor.ToCode(thisEntry.Key) + "\">" + thisEntry.Value + "</name>\r\n");
	            }
	        }

	        // Now, add the XML for the elements in this panel
	        results.Append( elements.To_Template_XML( "\t\t\t\t" ) );			

	        // End this page
	        results.Append( "\t\t\t</panel>\r\n");

	        // Return the built XML string
	        return results.ToString();
	    }

	    /// <summary> Computes the height of this panel and locations of all the child elements based on font size  </summary>
	    public void Compute_Height_And_Locations()
		{
			// Determine the height of this panel from each 
			// element in this panel
			height = ((int) ( 1.5F * currentFont.SizeInPoints));
			int i = 0;
	        while( i < elements.Count )
			{
				// Get this element and start this line with it
				abstract_Element thisElement = elements[i];
				thisElement.Location = new Point( 15, y + height );

				// Is this item repeatable? or repeated? is there a next item?
				if (( !thisElement.Repeatable ) && ( thisElement.Index == 0 ) && ( i + 1 < elements.Count ))
				{
				    // Get the next element
				    abstract_Element nextElement = elements[i + 1];

				    // Is this a different element, also non-repeatable?
					if (( nextElement.Type != thisElement.Type ) && ( !nextElement.Repeatable ))
					{
						// Are the widths correct?
						if ((( thisElement.Width * 2 ) < ( Width - 20 ) ) && (( nextElement.Width * 2 ) < ( Width - 20 )))
						{
							// Place this at the half-point
							nextElement.Location = new Point( Width / 2, y + height );
							i++;
						}
					}
				}

			    // Add to the height and move to the next element
				height += thisElement.Height + ((int) (currentFont.SizeInPoints * 0.7)  );
				i++;
			}

			// Add a buffer at the very end
            height += ((int) (currentFont.SizeInPoints * 0.7 ));
		}

		/// <summary> Draw this panel </summary>
		/// <param name="g"></param>
		public void Draw( Graphics g )
		{
			// Draw the rectangle for this panel as a dark gray line
			if ( Title.Length == 0 )
			{
				g.DrawRectangle( new Pen( Color.DarkGray, 1 ), X, Y, Width, Height );
			}
			else
			{
				// Compute the width of the panel title
				int panel_title_width = (int) ( currentFont.SizeInPoints * Title.Length * 0.75F ) + 25;

                Pen grayPen = new Pen( Color.Silver, 1);
                const int radius = 8;
				g.DrawLine( grayPen, X + panel_title_width + 5 + radius, Y, X + Width - radius, Y );
				g.DrawLine( grayPen, X + Width, Y + radius, X + Width, Y + Height - radius );
				g.DrawLine( grayPen, X + radius, Y + Height, X + Width - radius, Y + Height );
				g.DrawLine( grayPen, X, Y + radius, X, Y + Height - radius );
				g.DrawLine( grayPen, X + radius, Y, X + 5 + radius , Y );

                g.DrawArc(grayPen, X, Y, radius * 2, radius * 2, 180, 90);
                g.DrawArc(grayPen, X + Width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                g.DrawArc(grayPen, X, Y + Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                g.DrawArc(grayPen, X + Width - ( radius * 2 ), Y + Height - (radius * 2), radius * 2, radius * 2, 0, 90); 

				g.DrawString( Title, currentFont, new SolidBrush( SystemColors.MenuHighlight ), X + 10 + radius, Y - ((int) ( currentFont.Size / 1.5F )));
			}	
		}
	}
}
