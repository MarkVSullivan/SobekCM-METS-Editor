#region Using directives

using System;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

// THIS FILE CONTAINS BOTH CLASSES FOR SUBJBECT KEYWORDS:
//		Genre_Simple_Element : simpleTextBox_Element
//		Genre_Complex_Element : keywordScheme_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a genre (but not scheme) of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Genre_Simple_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Genre_Simple_Element, used in the metadata
		/// template to display and allow the user to edit a genre of a 
		/// bibliographic package. </summary>
		public Genre_Simple_Element( ) : base( "Genre" )
		{
			// Set the type of this object
			base.type = Element_Type.Genre;
			base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

			base.maximum_input_length = 475;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "genre_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Genre";
					break;
				case Template_Language.Spanish:
					base.title = "(Genre)";
					break;
				case Template_Language.French:
					base.title = "(Genre)";
					break;
				default:
					base.title = "Genre - unknown";
					break;
			}
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			// Get the size of the font
			float font_size = 10.0F;

				font_size = Font.SizeInPoints;

			// Set the title length
			switch( current_language )
			{
				case Template_Language.English:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 10);
					break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
            Bib.Bib_Info.Clear_Genres();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
				Bib.Bib_Info.Add_Genre( base.thisBox.Text, String.Empty );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (base.index < Bib.Bib_Info.Genres_Count)
			{
				base.thisBox.Text = Bib.Bib_Info.Genres[ base.index ].Genre_Term;
			}

		    if ((Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project) && (thisBox.Text.ToLower() == "project"))
		        thisBox.Enabled = false;
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a genre and scheme of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Genre_Complex_Element : keywordScheme_Element
	{
		/// <summary> Constructor for a new Subject_Comples_Element, used in the metadata
		/// template to display and allow the user to edit a subject and subject scheme of a 
		/// bibliographic package. </summary>
		public Genre_Complex_Element( ) : base( "Genre" )
		{
			// Set the type of this object
			base.type = Element_Type.Genre;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			base.thisSchemeBox.Width = 110;
			base.maximum_input_length = 475;

			// Add the schemes
			base.thisSchemeBox.Items.Add("LCSH");
			base.thisSchemeBox.Items.Add("None");
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "genre_scheme";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Genre";
					base.scheme = "Scheme";
					base.Scheme_Length = 50;
					break;
				case Template_Language.Spanish:
					base.title = "(Genre)";
					base.scheme = "(Scheme)";
					base.Scheme_Length = 60;
					break;
				case Template_Language.French:
					base.title = "(Genre)";
					base.scheme = "(Scheme)";
					base.Scheme_Length = 60;
					break;
				default:
					base.title = "Genre - unknown";
					base.scheme = "(Scheme)";
					break;
			}
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			// Get the size of the font
			float font_size = 10.0F;

			font_size = Font.SizeInPoints;

			// Set the title length
			switch( current_language )
			{
				case Template_Language.English:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 6);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 10);
					break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			Bib.Bib_Info.Clear_Genres();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisKeywordBox.Text.Trim().Length > 0 )
			{
				if ( base.thisSchemeBox.Text.Trim().Length > 0 )
				{
                    Bib.Bib_Info.Add_Genre(base.thisKeywordBox.Text.Trim(), base.thisSchemeBox.Text.ToLower());
				}
				else
				{
                    Bib.Bib_Info.Add_Genre(base.thisKeywordBox.Text, String.Empty);
				}
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.Genres_Count )
			{
                base.thisKeywordBox.Text = Bib.Bib_Info.Genres[base.index].Genre_Term;
                base.thisSchemeBox.Text = Bib.Bib_Info.Genres[base.index].Authority.ToLower();
			}

		    if ((Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project) && (thisKeywordBox.Text.ToLower() == "project") && (thisSchemeBox.Text.ToLower() == "sobekcm"))
		    {
                thisKeywordBox.Enabled = false;
                thisSchemeBox.Enabled = false;
		    }
		}
	}
}