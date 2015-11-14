#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the publication date of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Date_Element : simpleTextBox_Element
	{
        private bool dublinCore;

		/// <summary> Constructor for a new Date_Element, used in the metadata
		/// template to display and allow the user to edit the publication date of a 
		/// bibliographic package. </summary>
        /// <param name="Dublin_Core"> Flag indicates if this is being used in a dublin core template which generally only affects the label displayed </param>
        public Date_Element(bool Dublin_Core)
            : base("Publication Date")
		{
            // Save the parameter
            dublinCore = Dublin_Core;

			// Set the type of this object
			base.type = Element_Type.Date;

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;

			// Set some formatting characteristics
			maximum_input_length = 250;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "pubdate";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
                    if (!dublinCore)
                        base.title = "Publication Date";
                    else
                        base.title = "Date";
					break;
				case Template_Language.Spanish:
                    if (!dublinCore)
                        base.title = "Fecha Publicada";
                    else
                        base.title = "Fecha";
					break;
				case Template_Language.French:
                    if (!dublinCore)
                        base.title = "Date Éditée";
                    else
                        base.title = "Date";
					break;
				default:
                    if (!dublinCore)
                        base.title = "Publication Date - unknown";
                    else
                        base.title = "Date - unknown";
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
                    if ( !dublinCore )
    					base.minimum_title_length = (int) (font_size * 12);
                    else
                        base.minimum_title_length = (int)(font_size * 6);
					break;
				case Template_Language.Spanish:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 12);
                    else
                        base.minimum_title_length = (int)(font_size * 7);
                    break;
				case Template_Language.French:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 10);
                    else
                        base.minimum_title_length = (int)(font_size * 6);
                    break;
				default:
					base.minimum_title_length = (int) (font_size * 12);
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
            Bib.Bib_Info.Origin_Info.Date_Issued = base.thisBox.Text.Trim();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (Bib.Bib_Info.Origin_Info.Date_Issued.Length > 0)
                base.thisBox.Text = Bib.Bib_Info.Origin_Info.Date_Issued;
            else
                base.thisBox.Text = Bib.Bib_Info.Origin_Info.MARC_DateIssued;
		}
	}
}