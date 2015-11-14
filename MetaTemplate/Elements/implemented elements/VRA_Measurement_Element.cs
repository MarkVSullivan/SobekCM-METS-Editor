#region Using directives

using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.VRACore;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the measurements related to an item and encoded in VRACore.</summary>
    /// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2011 ).</remarks>
    public class VRA_Measurement_Element : keywordScheme_Element
    {
        // <summary> Constructor for a new instance of the VRA_Measurement_Element class </summary>
        public VRA_Measurement_Element()
            : base("Measurement")
        {
            // Set the type of this object
            base.type = Element_Type.VRA_Measurement;
            base.display_subtype = "Units";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.thisSchemeBox.Width = 110;
            base.thisSchemeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            base.maximum_input_length = 475;
            base.repeatable = true;

            // Add the schemes
            base.thisSchemeBox.Items.Add("in");
            base.thisSchemeBox.Items.Add("cm");
            base.thisSchemeBox.SelectedIndex = 0;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "vra_measurement";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Measurement";
                    base.scheme = "Units";
                    base.Scheme_Length = 50;
                    break;
                case Template_Language.Spanish:
                    base.title = "(Measurement)";
                    base.scheme = "(Units)";
                    base.Scheme_Length = 60;
                    break;
                case Template_Language.French:
                    base.title = "(Measurement)";
                    base.scheme = "(Units)";
                    base.Scheme_Length = 60;
                    break;
                default:
                    base.title = "Measurement - unknown";
                    base.scheme = "(Units)";
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
                    base.minimum_title_length = (int)(font_size * 11);
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
                vraInfo.Clear_Measurements();
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisKeywordBox.Text.Trim().Length > 0)
            {
                VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
                if (vraInfo == null)
                {
                    vraInfo = new VRACore_Info();
                    Bib.Add_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY, vraInfo);
                }

                if (base.thisSchemeBox.Text.Trim().Length > 0)
                {
                    vraInfo.Add_Measurement(base.thisKeywordBox.Text.Trim(), base.thisSchemeBox.Text.ToLower());
                }
                else
                {
                    vraInfo.Add_Measurement(base.thisKeywordBox.Text.Trim(), "in");
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
            if ((vraInfo != null) && (base.index < vraInfo.Measurement_Count))
            {
                base.thisKeywordBox.Text = vraInfo.Measurements[base.index].Measurements;
                base.thisSchemeBox.Text = vraInfo.Measurements[base.index].Units;
            }
            else
            {
                base.thisSchemeBox.Text = "in";
            }
        }
    }
}