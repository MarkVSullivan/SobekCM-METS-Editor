#region Using directives

using System.Collections.Generic;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the notes for a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Note_Element : simpleTextBox_Element
	{
        private bool dublinCore;

        /// <summary> Constructor for a new Note_Element used in the metadata
		/// template to display and allow the user to edit the descriptions for a 
		/// bibliographic package. </summary>
        /// <param name="Dublin_Core"> Flag indicates if this is being used in a dublin core template which generally only affects the label displayed 
        /// and also suppresses displaying any source note (since source note should be included in all dublin core templates  as 'source' )</param>
        public Note_Element( bool Dublin_Core )
            : base("Note")
		{
            // Save the parameter
            dublinCore = Dublin_Core;

			// Set the type of this object
			base.type = Element_Type.Note;
            base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			base.Lines = 3;
		}

        /// <summary> Sets the dublin core flag, which controls which note types to include/exclude  </summary>
        /// <remarks> This property is called explicitly when cloning this element </remarks>
        public bool Dublin_Core
        {
            set
            {
                dublinCore = value;
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "note";
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Note_Element newElement = (Note_Element)Element_Factory.getElement(Type, Display_SubType);
            newElement.Location = Location;
            newElement.Language = Language;
            newElement.Title_Length = Title_Length;
            newElement.Lines = Lines;
            newElement.Height = Height;
            newElement.Font = Font;
            newElement.Set_Width(Width);
            newElement.Index = Index + 1;
            newElement.Inner_Set_Height(Font.SizeInPoints);
            newElement.Dublin_Core = dublinCore;
            return newElement;
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
                    if (!dublinCore)
                        base.title = "Note";
                    else
                        base.title = "Description";
					break;
				case Template_Language.Spanish:
                    if (!dublinCore)
                        base.title = "Note";
                    else
                        base.title = "Description";
					break;
				case Template_Language.French:
                    if (!dublinCore)
                        base.title = "Note";
                    else
                        base.title = "Description";
                    break;
				default:
                    if (!dublinCore)
                        base.title = "Note";
                    else
                        base.title = "Description";
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
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 7);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
                    break;
				case Template_Language.Spanish:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 7);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
                    break;
				case Template_Language.French:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 7);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
                    break;
				default:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 7);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
                    break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
            // Clear all the notes which are NOT funding or statement of responsibility or preferred citation
            List<Note_Info> clears = new List<Note_Info>();
            foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
            {
                if ((thisNote.Note_Type != Note_Type_Enum.funding) && (thisNote.Note_Type != Note_Type_Enum.statement_of_responsibility) && ( thisNote.Note_Type != Note_Type_Enum.preferred_citation) && (( !dublinCore ) || ( thisNote.Note_Type != Note_Type_Enum.source )))
                {
                    clears.Add(thisNote);
                }
            }

            // Now clear them all
            foreach (Note_Info thisNote in clears)
                Bib.Bib_Info.Remove_Note(thisNote);
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
				Bib.Bib_Info.Add_Note( base.thisBox.Text.Trim() );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            int description_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Notes.Count; i++)
            {
                if (((Bib.Bib_Info.Notes[i].Note_Type != Note_Type_Enum.funding) || ( dublinCore )) && (Bib.Bib_Info.Notes[i].Note_Type != Note_Type_Enum.statement_of_responsibility) && (Bib.Bib_Info.Notes[i].Note_Type != Note_Type_Enum.preferred_citation) && (( !dublinCore ) || (Bib.Bib_Info.Notes[i].Note_Type != Note_Type_Enum.source )))
                {
                    description_index++;
                    if (description_index == base.index)
                    {
                        base.thisBox.Text = Bib.Bib_Info.Notes[i].Note;
                        break;
                    }
                }
            }
		}
	}
}
