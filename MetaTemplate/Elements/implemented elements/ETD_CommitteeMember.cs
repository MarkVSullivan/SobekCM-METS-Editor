#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the committee members for an Electronic Thesis and Dissertation (ETD) material </summary>
    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.</remarks>
    public class ETD_CommitteeMember : simpleTextBox_Element
    {
        /// <summary> Constructor for a new ETD_CommitteeMember, used in the metadata
        /// template to display and allow the user to edit the committee chair for an 
        /// Electronic Thesis and Dissertation (ETD) material </summary>
        public ETD_CommitteeMember()
            : base("Committee Members")
        {
            // Set the type of this object
            base.type = Element_Type.ETD_CommitteeMember;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            repeatable = true;
            base.maximum_input_length = 350;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "etd_committeemembers";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Committee Members";
                    break;
                case Template_Language.Spanish:
                    base.title = "Committee Members";
                    break;
                case Template_Language.French:
                    base.title = "Committee Members";
                    break;
                default:
                    base.title = "Committee Members - unknown";
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
                    base.minimum_title_length = (int)(font_size * 15);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 15);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 15);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 15);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            Thesis_Dissertation_Info thesisInfo = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
            if (thesisInfo != null)
            {
                thesisInfo.Clear_Committee_Members();
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Thesis_Dissertation_Info thesisInfo = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                if (thesisInfo == null)
                {
                    thesisInfo = new Thesis_Dissertation_Info();
                    Bib.Add_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY, thesisInfo);
                }

                thesisInfo.Add_Committee_Member(thisBox.Text.Trim());
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
                if ( base.index < thesisInfo.Committee_Members_Count )
                {
                    base.thisBox.Text = thesisInfo.Committee_Members[base.index];
                }
            }
        }
    }
}
