#region Using directives

using System;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the account information of a bibliographic package for the Florida Dark Archive.</summary>
    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2006 ).</remarks>
    public class FDA_Account_Element : simpleTextBox_Element
    {
        /// <summary> Constructor for a new FDA_Account_Element, used in the metadata
        /// template to display and allow the user to edit the account information for a 
        /// bibliographic package for the Florida Dark Archive. </summary>
        public FDA_Account_Element()
            : base("FDA Account")
        {
            // Set the type of this object
            base.type = Element_Type.FDA_Account;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            // Set some formatting characteristics
            maximum_input_length = 140;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "fdaaccount";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "FDA Account";
                    break;
                case Template_Language.Spanish:
                    base.title = "Cuenta la FDA";
                    break;
                case Template_Language.French:
                    base.title = "Compte pour la FDA";
                    break;
                default:
                    base.title = "FDA Account";
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
                    base.minimum_title_length = (int)(font_size * 11);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 16);
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
            DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
            if (daitssInfo != null)
                daitssInfo.Account = String.Empty;
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (thisBox.Text.Trim().Length > 0)
            {
                DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                if (daitssInfo == null)
                {
                    daitssInfo = new DAITSS_Info();
                    Bib.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
                }
                daitssInfo.Account = thisBox.Text.Trim();
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
            if (daitssInfo != null)
                base.thisBox.Text = daitssInfo.Account;
        }
    }
}
