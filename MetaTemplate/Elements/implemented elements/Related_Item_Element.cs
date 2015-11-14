#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a subject (but not scheme) of a bibliographic package.</summary>
    /// <param name="Dublin_Core"> Flag indicates if this is being used in a dublin core template which generally only affects the label displayed </param>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan and his muse is Catherine ( 2006 ).</remarks>
    public class Related_Item_Element : simpleTextBox_Element
    {
        private bool dublinCore;

        /// <summary> Constructor for a new Subject_Simple_Element, used in the metadata
        /// template to display and allow the user to edit a subject (but not scheme) of a 
        /// bibliographic package. </summary>
        public Related_Item_Element(bool Dublin_Core)
            : base("Related Item")
        {
            // Save the parameter
            dublinCore = Dublin_Core;

            // Set the type of this object
            base.type = Element_Type.RelatedItem;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
        }


        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "relateditem_simple";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    if (!dublinCore)
                        base.title = "Related Item";
                    else
                        base.title = "Relation";
                    break;
                case Template_Language.Spanish:
                    if (!dublinCore)
                        base.title = "Recursos Relacionados";
                    else
                        base.title = "Relacionados";
                    break;
                case Template_Language.French:
                    if (!dublinCore)
                        base.title = "Connexes de Ressources";
                    else
                        base.title = "Relation";
                    break;
                default:
                    base.title = "Related Item - unknown";
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
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 10);
                    else
                        base.minimum_title_length = (int)(font_size * 8);
                    break;
                case Template_Language.Spanish:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 16);
                    else
                        base.minimum_title_length = (int)(font_size * 8);
                    break;
                case Template_Language.French:
                    if (!dublinCore)
                        base.minimum_title_length = (int)(font_size * 18);
                    else
                        base.minimum_title_length = (int)(font_size * 8);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            Bib.Bib_Info.Clear_Related_Items();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Related_Item_Info newRelatedItem = new Related_Item_Info();
                newRelatedItem.Main_Title.Title = base.thisBox.Text.Trim();
                Bib.Bib_Info.Add_Related_Item(newRelatedItem);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.RelatedItems_Count)
            {
                base.thisBox.Text = Bib.Bib_Info.RelatedItems[base.index].Main_Title.Title;
            }
        }
    }
}
