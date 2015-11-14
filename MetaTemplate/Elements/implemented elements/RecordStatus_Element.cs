#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the record status for a METS file</summary>
    /// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2006 ).</remarks>
    public class RecordStatus_Element : comboBox_Element
    {
        /// <summary> Constructor for a new Type_Element, used in the metadata
        /// template to display and allow the user to edit the type of a 
        /// bibliographic package. </summary>
        public RecordStatus_Element()
            : base("Record Status")
        {
            // Set the type of this object
            base.type = Element_Type.RecordStatus;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = true;
            base.maximum_input_length = 225;
            Restrict_Values = true;

            // Add the types to this box
            if (MetaTemplate_UserSettings.METS_RecordStatus_List.Count == 0)
            {
                base.thisBox.Items.Add("COMPLETE");
                base.thisBox.Items.Add("METADATA UPDATE");
                base.thisBox.Items.Add("PARTIAL");
            }
            else
            {
                foreach (string status in MetaTemplate_UserSettings.METS_RecordStatus_List)
                {
                    base.thisBox.Items.Add(status);
                }
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "recordstatus";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Record Status";
                    break;
                case Template_Language.Spanish:
                    base.title = "Registro de Estado";
                    break;
                case Template_Language.French:
                    base.title = "Statut";
                    break;
                default:
                    base.title = "Record Status - unknown";
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
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 13);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 9);
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
            // Do nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.METS_Header.RecordStatus = thisBox.Text.Replace(" ", "_");
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (!thisBox.Items.Contains(Bib.METS_Header.RecordStatus.Replace("_", " ")))
            {
                thisBox.Items.Add(Bib.METS_Header.RecordStatus.Replace("_", " "));
            }
            base.thisBox.Text = Bib.METS_Header.RecordStatus;
        }
    }
}