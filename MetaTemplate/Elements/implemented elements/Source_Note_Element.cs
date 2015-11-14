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
    /// to edit the source notes about a bibliographic item, generally used for dublin core templates.</summary>
    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2006 ).</remarks>
    public class Source_Note_Element : simpleTextBox_Element
    {
        private bool dublinCore;

        /// <summary> Constructor for a new Source_Note_Element used in the metadata
        /// template to display and allow the user to edit the source note for a 
        /// bibliographic package, generally used for dublin core templates.. </summary>
        public Source_Note_Element()  : base("Source")
        {
            // Set the type of this object
            base.type = Element_Type.Source_Note;
            base.display_subtype = "dublincore";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.Lines = 1;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "source_note";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                        base.title = "Source";
                    break;
                case Template_Language.Spanish:
                    base.title = "Source";
                    break;
                case Template_Language.French:
                    base.title = "Source";
                    break;
                default:
                    base.title = "Source";
                    break;
            }
        }

        /// <summary> Set the minimum title length specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
        {
            // Get the size of the font
            float font_size = 10.0F;

            font_size = Font.SizeInPoints;

            // Set the title length
            switch (current_language)
            {
                case Template_Language.English:
                    base.minimum_title_length = (int)(font_size * 8);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 8);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 8);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 8);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            // Clear all the notes which are SOURCE
            List<Note_Info> clears = new List<Note_Info>();
            foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
            {
                if (thisNote.Note_Type == Note_Type_Enum.source )
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
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Note(base.thisBox.Text.Trim(), Note_Type_Enum.source);
            }       
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int description_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Notes.Count; i++)
            {
                if (Bib.Bib_Info.Notes[i].Note_Type == Note_Type_Enum.source )
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
