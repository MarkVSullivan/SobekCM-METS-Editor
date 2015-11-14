#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the encoding level of a bibliographic resource.</summary>
    /// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2006 ).</remarks>
    public class Encoding_Level_Element : comboBox_Element
    {
        /// <summary> Constructor for a new Encoding_Level_Element, used in the metadata
        /// template to display and allow the user to edit the encoding level of a 
        /// bibliographic package. </summary>
        public Encoding_Level_Element()
            : base("Encoding Level")
        {
            // Set the type of this object
            base.type = Element_Type.EncodingLevel;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;
            base.maximum_input_length = 140;
            base.thisBox.Sorted = false;
            base.Set_Values(new[] { "(none)", "#", "3", "K", "I" });
            base.Restrict_Values = true;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "encoding_level";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Encoding Level";
                    break;
                case Template_Language.Spanish:
                    base.title = "Nivel de Codificación";
                    break;
                case Template_Language.French:
                    base.title = "Encodage Niveau";
                    break;
                default:
                    base.title = "Encoding Level";
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
                    base.minimum_title_length = (int)(font_size * 13);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 16);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 13);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 13);
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
            if (!read_only)
            {
                if (base.thisBox.SelectedIndex == 0)
                {
                    Bib.Bib_Info.EncodingLevel = string.Empty;
                }
                else
                {
                    Bib.Bib_Info.EncodingLevel = base.thisBox.Text;
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (Bib.Bib_Info.EncodingLevel.Length > 0)
            {
                if (!base.thisBox.Items.Contains(Bib.Bib_Info.EncodingLevel))
                {
                    base.thisBox.Items.Add(Bib.Bib_Info.EncodingLevel);
                }
                base.thisBox.Text = Bib.Bib_Info.EncodingLevel;
            }
            else
            {
                base.thisBox.SelectedIndex = 0;
            }
        }
    }
}