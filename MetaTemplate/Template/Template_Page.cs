#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary> Stores the data about a single page in a template </summary>
	public class Template_Page
	{
	    private readonly Dictionary<Template_Language, string> allPageTitles;
        private readonly Template_Panel_Collection panels;

	    private Font currentFont;
	    private string currentPageTitle;
	    private int height;
        private string name;

	    /// <summary> Constructor for a new Template_Page object </summary>
		public Template_Page()
		{
			// Set some defaults
			currentPageTitle = String.Empty;
	        allPageTitles = new Dictionary<Template_Language, string>();
			panels = new Template_Panel_Collection();
			height = 50;
            name = String.Empty;
		}

		/// <summary> Constructor for a new Template_Page object </summary>
		/// <param name="Title"> Default title for this page </param>
		public Template_Page( string Title )
		{
			// Set some defaults
			currentPageTitle = Title;
			panels = new Template_Panel_Collection();
			height = 50;
            name = String.Empty;

            allPageTitles = new Dictionary<Template_Language, string> {{Template_Language.English, Title}};
		}

	    /// <summary> Allows the current font for this template page to be set </summary>
	    /// <remarks> This sets the font all child panels and recomputes the locations for each panel </remarks>
	    public Font Current_Font
		{
			set
			{
				// Save this font
				currentFont = value;

				// Set the font on the panels as well
				panels.Current_Font = value;

				// Now, determine location for each panel
				Compute_Locations();
			}
		}

	    /// <summary> Allows the width for the current page to be set  </summary>
	    /// <remarks> This sets the widths for all child panels and recomputes the locations for each panel </remarks>
	    public int Width
		{
			set
			{
                if (name != "TOC")
                {
                    // Set the width of each panel
                    foreach (Template_Panel thisPanel in panels)
                    {
                        thisPanel.Width = value - 20;
                        thisPanel.Compute_Height_And_Locations();
                    }

                    // Set all locations next
                    Compute_Locations();
                }
			}
		}


	    /// <summary> Returns the collection of child panels </summary>
	    public Template_Panel_Collection Panels
		{
			get
			{
				return panels;
			}
		}

        /// <summary> Returns the current (language-specific) page title </summary>
		public string Title
		{
			get
			{
				return currentPageTitle;
			}
		}

        /// <summary> Returns the current height of this page </summary>
		public int Height
		{
			get
			{
				// Return the height
				return height;
			}
		}

        /// <summary> Name (non-language-specific) of this page </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

	    /// <summary> Add a title in a particular language to this page </summary>
	    /// <param name="Language"> Language of the title </param>
        /// <param name="Language_Specific_Title"> Title to display </param>
	    public void Set_Title( Template_Language Language, string Language_Specific_Title )
	    {
	        // If the title has no length, this is a request to REMOVE a title
            if ( String.IsNullOrEmpty(Language_Specific_Title))
	        {
	            if ( allPageTitles.ContainsKey( Language ) )
	                allPageTitles.Remove( Language );
	        }
	        else
	        {
	            // Add this new title to the collection
                allPageTitles[Language] = Language_Specific_Title;
	        }
	    }

	    /// <summary> Sets the language to use for this page </summary>
	    /// <param name="Language"> Language to display </param>
	    public void Set_Language( Template_Language Language )
	    {
	        // Set the current page title by the language
	        if ( allPageTitles.ContainsKey( Language ))
	            currentPageTitle = allPageTitles[ Language ];
	        else if ( allPageTitles.ContainsKey( Template_Language.English ))
	            currentPageTitle = allPageTitles[ Template_Language.English ];
	        else
	            currentPageTitle = String.Empty;

	        // Set this for each panel
	        foreach( Template_Panel thisPanel in panels )
	        {
	            thisPanel.Set_Language( Language );
	        }
	    }

	    /// <summary> Returns the XML string to save this page to the template XML file </summary>
	    /// <returns>String for template XML file</returns>
	    public string To_Template_XML()
	    {
	        // Build the results for this page, and each panel in the page
	        StringBuilder results = new StringBuilder();

	        // Start this page
	        results.Append( "\t\t<page>\r\n");

	        // Write each of the titles for this page
	        foreach( KeyValuePair<Template_Language, string> thisEntry in allPageTitles )
	        {
	            // If this language is known, write it
                if (thisEntry.Key != Template_Language.Unknown)
	            {
                    results.Append("\t\t\t<name language=\"" + Template_Language_Convertor.ToCode(thisEntry.Key) + "\">" + thisEntry.Value + "</name>\r\n");
	            }
	        }

	        // Now, add the XML for the panels in this page
	        results.Append( panels.To_Template_XML() );			

	        // End this page
	        results.Append( "\t\t</page>\r\n");

	        // Return the built XML string
	        return results.ToString();
	    }

	    /// <summary> Recomputes the appropriate locations for all the child panels, based on the current font
	    /// and information about each child panel </summary>
	    public void Compute_Locations()
	    {
	        // Now, determine location for each panel
	        int space = 6;
	        if ( currentFont != null )
	        {
	            space = (int) ( currentFont.Size * 1.5F );
	        }
	        int eval_y = space;

	        // Set the location of each panel
	        foreach( Template_Panel thisPanel in panels )
	        {
	            // Set the location of this panel
	            thisPanel.Y = eval_y;
	            thisPanel.X = 5;

	            // Add this panel's height
	            eval_y += thisPanel.Height + space;
	        }

	        // Save the total height
	        height = eval_y;
	    }

	    /// <summary> Draw this page </summary>
	    /// <param name="g"></param>
	    public void Draw( Graphics g )
	    {
	        // Draw each panel
	        foreach( Template_Panel thisPanel in panels )
	        {
	            thisPanel.Draw( g );
	        }
	    }
	}
}
