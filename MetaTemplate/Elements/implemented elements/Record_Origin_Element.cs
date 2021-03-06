﻿#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to view the record origin of a bibliographic package.</summary>
    public class Record_Origin_Element : simpleTextBox_Element
    {
        /// <summary> Constructor for a new Record_Origin_Element, used in the metadata
        /// template to display and allow the user to view the record origin of a 
        /// bibliographic package. </summary>
        public Record_Origin_Element()
            : base("Record Origin")
        {
            // Set the type of this object
            base.type = Element_Type.RecordOrigin;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            // Set some formatting characteristics
            maximum_input_length = 350;

            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "recordorigin";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Record Origin";
                    break;
                case Template_Language.Spanish:
                    base.title = "Registro de Origen";
                    break;
                case Template_Language.French:
                    base.title = "Record d'origine";
                    break;
                default:
                    base.title = "Record Origin";
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
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 13);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            // Do nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            // Never save (this is readonly)
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            base.thisBox.Text = Bib.Bib_Info.Record.Record_Origin;
        }
    }
}