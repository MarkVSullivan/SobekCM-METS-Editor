#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the publisher's name of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Publisher_Simple_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Publisher_Simple_Element, used in the metadata
		/// template to display and allow the user to edit the publisher's name of a 
		/// bibliographic package. </summary>
		public Publisher_Simple_Element( ) : base( "Publisher" )
		{
			// Set the type of this object
			base.type = Element_Type.Publisher;
			base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "publisher_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Publisher";
					break;
				case Template_Language.Spanish:
					base.title = "Publicante";
					break;
				case Template_Language.French:
					base.title = "Editeur";
					break;
				default:
					base.title = "Publisher - unknown";
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
					base.minimum_title_length = (int) (font_size * 8);
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
            Bib.Bib_Info.Clear_Publishers();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
                Bib.Bib_Info.Add_Publisher(thisBox.Text.Trim());
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.Publishers_Count )
			{
                base.thisBox.Text = Bib.Bib_Info.Publishers[base.index].Name;
			}
		}
	}
}