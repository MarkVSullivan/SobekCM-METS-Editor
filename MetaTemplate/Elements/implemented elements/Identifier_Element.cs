#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

// THIS FILE CONTAINS BOTH CLASSES FOR IDENTIFIERS:
//		Identifier_Simple_Element : simpleTextBox_Element
//		Identifier_Complex_Element : keywordScheme_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit an identifier of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Identifier_Simple_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Identifier_Simple_Element, used in the metadata
		/// template to display and allow the user to edit an identifier of a 
		/// bibliographic package. </summary>
		public Identifier_Simple_Element( ) : base( "Identifier" )
		{
			// Set the type of this object
			base.type = Element_Type.Identifier;
			base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

			// Set some formatting characteristics
			maximum_input_length = 250;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "identifier_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Identifier";
					break;
				case Template_Language.Spanish:
					base.title = "Indentificador";
					break;
				case Template_Language.French:
					base.title = "Marque";
					break;
				default:
					base.title = "Identifier - unknown";
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
					base.minimum_title_length = (int) (font_size * 7);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 10);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 7);
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
			Bib.Bib_Info.Clear_Identifiers();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
				Bib.Bib_Info.Add_Identifier(  base.thisBox.Text );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.Identifiers.Count )
			{
				base.thisBox.Text = Bib.Bib_Info.Identifiers[ base.index ].Identifier;
			}
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit an identifier and identifier type of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Identifier_Complex_Element : keywordScheme_Element
	{
		/// <summary> Constructor for a new Identifier_Comples_Element, used in the metadata
		/// template to display and allow the user to edit an identifier and identifier type of a 
		/// bibliographic package. </summary>
		public Identifier_Complex_Element( ) : base( "Identifier" )
		{
			// Set the type of this object
			base.type = Element_Type.Identifier;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			maximum_input_length = 450;
			base.thisSchemeBox.Width = 145;
            base.thisKeywordBox.Width = 230;

			// Add the schemes
			base.Scheme_Length = 40;
			base.scheme = "Type";
			base.thisSchemeBox.Items.Add("aleph");
			base.thisSchemeBox.Items.Add("isbn");
			base.thisSchemeBox.Items.Add("issn");
			base.thisSchemeBox.Items.Add("lccn");
			base.thisSchemeBox.Items.Add("notis");
			base.thisSchemeBox.Items.Add("oclc");
			base.thisSchemeBox.Items.Add("sip");
            base.thisSchemeBox.Items.Add("");
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "identifier_scheme";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Identifier";
					base.scheme = "Type";
					break;
				case Template_Language.Spanish:
					base.title = "Indentificador";
					base.scheme = "Tipo";
					break;
				case Template_Language.French:
					base.title = "Marque";
					base.scheme = "Type";
					break;
				default:
					base.title = "Identifier - unknown";
					base.scheme = "Type";
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
					base.minimum_title_length = (int) (font_size * 7);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 10);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 7);
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
			Bib.Bib_Info.Clear_Identifiers();
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
					Bib.Bib_Info.Add_Identifier( base.thisKeywordBox.Text.Trim(), base.thisSchemeBox.Text.ToLower().Trim()  );
				}
				else
				{
					Bib.Bib_Info.Add_Identifier( base.thisKeywordBox.Text );
				}
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.Identifiers.Count )
			{
				base.thisKeywordBox.Text = Bib.Bib_Info.Identifiers[ base.index ].Identifier;
				base.thisSchemeBox.Text = Bib.Bib_Info.Identifiers[ base.index ].Type.ToLower();
			}
		}
	}
}