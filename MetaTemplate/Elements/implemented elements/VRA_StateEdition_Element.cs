#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.VRACore;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the cultural context related to an item and encoded in VRACore.</summary>
    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2011 ).</remarks>
    public class VRA_StateEdition_Element : simpleTextBox_Element
    {
        /// <summary> Constructor for a new instance of the VRA_StateEdition_Element class </summary>
        public VRA_StateEdition_Element()
            : base("State / Edition")
        {
            // Set the type of this object
            base.type = Element_Type.VRA_StateEdition;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.maximum_input_length = 375;
            base.repeatable = true;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "vra_stateedition";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "State / Edition";
                    break;
                case Template_Language.Spanish:
                    base.title = "State / Edition";
                    break;
                case Template_Language.French:
                    base.title = "State / Edition";
                    break;
                default:
                    base.title = "State / Edition - unknown";
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
                    base.minimum_title_length = (int)(font_size * 17);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
            if (vraInfo != null)
            {
                vraInfo.Clear_State_Editions();
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (thisBox.Text.Trim().Length > 0)
            {
                VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
                if (vraInfo == null)
                {
                    vraInfo = new VRACore_Info();
                    Bib.Add_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY, vraInfo);
                }

                vraInfo.Add_State_Edition(thisBox.Text.Trim());
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
            if ((vraInfo != null) && (base.index < vraInfo.State_Edition_Count))
            {
                base.thisBox.Text = vraInfo.State_Editions[base.index];
            }
        }
    }
}