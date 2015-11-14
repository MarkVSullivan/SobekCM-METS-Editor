#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the title of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Title_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Title_Element, used in the metadata
		/// template to display and allow the user to edit the title of a 
		/// bibliographic package. </summary>
		public Title_Element( ) : base( "Title" )
		{
			// Set the type of this object
			base.type = Element_Type.Title;

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = true;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "title_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Title";
					break;
				case Template_Language.Spanish:
					base.title = "Titulo";
					break;
				case Template_Language.French:
					base.title = "Titre";
					break;
				default:
					base.title = "Title - unknown";
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
					base.minimum_title_length = (int) (font_size * 5);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 5);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 5);
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
			// Do nothing
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            // Make the title itself read-only if this is a PROJECT
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                Bib.Bib_Info.Main_Title.Title = "'" + Bib.BibID + "' Project";
            }
            else
            {
                Bib.Bib_Info.Main_Title.Title = base.thisBox.Text.Trim();
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            // Make the title itself read-only if this is a PROJECT
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                base.thisBox.Text = "PROJECT METS FILE -- No Title Allowed";
                thisBox.Enabled = false;
                Read_Only = true;
            }
            else
            {
			    base.thisBox.Text = Bib.Bib_Info.Main_Title.Title;
            }
		}
	}
}
