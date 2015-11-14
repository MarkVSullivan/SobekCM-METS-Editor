#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the degree level for an Electronic Thesis and Dissertation (ETD) material </summary>
    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.</remarks>
    public class ETD_DegreeLevel : comboBox_Element
    {
        /// <summary> Constructor for a new ETD_DegreeLevel, used in the metadata
        /// template to display and allow the user to edit the degree level for an 
        /// Electronic Thesis and Dissertation (ETD) material </summary>
        public ETD_DegreeLevel() : base("Degree Level")
        {
            // Set the type of this object
            base.type = Element_Type.ETD_DegreeLevel;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;
            base.maximum_input_length = 150;
            Restrict_Values = true;
            repeatable = true;

            // Add the types to this box
            base.thisBox.Items.Add("");
            base.thisBox.Items.Add("Masters");
            base.thisBox.Items.Add("Doctorate");
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "etd_degreelevel";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Degree Level";
                    break;
                case Template_Language.Spanish:
                    base.title = "Degree Level";
                    break;
                case Template_Language.French:
                    base.title = "Degree Level";
                    break;
                default:
                    base.title = "Degree Level - unknown";
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
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 12);
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
            string level = base.thisBox.Text.Trim();
            if (level.Length > 0)
            {
                Thesis_Dissertation_Info thesisInfo = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                if (thesisInfo == null)
                {
                    thesisInfo = new Thesis_Dissertation_Info();
                    Bib.Add_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY, thesisInfo);
                }

                switch (level)
                {
                    case "Masters":
                        thesisInfo.Degree_Level = Thesis_Dissertation_Info.Thesis_Degree_Level_Enum.Masters;
                        break;

                    case "Doctorate":
                        thesisInfo.Degree_Level = Thesis_Dissertation_Info.Thesis_Degree_Level_Enum.Doctorate;
                        break;
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            Thesis_Dissertation_Info thesisInfo = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
            if (thesisInfo != null)
            {
                switch (thesisInfo.Degree_Level)
                {
                    case Thesis_Dissertation_Info.Thesis_Degree_Level_Enum.Doctorate:
                        base.thisBox.Text = "Doctorate";
                        break;

                    case Thesis_Dissertation_Info.Thesis_Degree_Level_Enum.Masters:
                        base.thisBox.Text = "Masters";
                        break;
                }
            }
        }
    }
}
