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
    /// to edit the publication status of a submitted resource</summary>
    /// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2010 ).</remarks>
    public class Publication_Status_Element : comboBox_Element
    {
        /// <summary> Constructor for a new Publication_Status_Element, used in the metadata
        /// template to display and allow the user to edit the publication status of a submitted resource </summary>
        public Publication_Status_Element()
            : base("Publication Status")
        {
            // Set the type of this object
            base.type = Element_Type.Publication_Status;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;
            base.maximum_input_length = 150;
            Restrict_Values = true;

            // Add the types to this box
            base.thisBox.Items.Add("In Press");
            base.thisBox.Items.Add("Published");
            base.thisBox.Items.Add("Unpublished");
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "pubstatus";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Publication Status";
                    break;
                case Template_Language.Spanish:
                    base.title = "Publication Status";
                    break;
                case Template_Language.French:
                    base.title = "Publication Status";
                    break;
                default:
                    base.title = "Publication Status - unknown";
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
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            if (Bib.Bib_Info.Notes_Count > 0)
            {
                List<Note_Info> deletes = new List<Note_Info>();
                foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
                {
                    if (thisNote.Note_Type == Note_Type_Enum.publication_status)
                    {
                        deletes.Add(thisNote);
                    }
                }
                foreach (Note_Info thisNote in deletes)
                {
                    Bib.Bib_Info.Remove_Note(thisNote);
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Length > 0)
                Bib.Bib_Info.Add_Note(base.thisBox.Text, Note_Type_Enum.publication_status);
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (Bib.Bib_Info.Notes_Count > 0)
            {
                foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
                {
                    if (thisNote.Note_Type == Note_Type_Enum.publication_status)
                    {
                        base.thisBox.Text = thisNote.Note;
                        break;
                    }
                }
            }          

        }
    }
}