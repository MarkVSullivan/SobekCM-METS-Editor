#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit related items for the bibliographic package.</summary>
    public class Related_Item_Form_Element : simpleTextBox_Element
    {
        private Related_Item_Info relatedItem;

        /// <summary> Constructor for a new Related_Item_Form_Element, used in the metadata
        /// template to display and allow the user to edit related items for  
        /// bibliographic package. </summary>
        public Related_Item_Form_Element()
            : base("Related Item")
        {
            // Set the type of this object
            base.type = Element_Type.RelatedItem;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            relatedItem = new Related_Item_Info();
            relatedItem.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Related_Item_Simple_Form showItemForm = new Related_Item_Simple_Form();
                showItemForm.Set_Related_Item(relatedItem);
                showItemForm.Read_Only = read_only;
                showItemForm.ShowDialog();

                if (showItemForm.Changed)
                    OnDataChanged();

                show_related_item();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Related_Item_Simple_Form showItemForm = new Related_Item_Simple_Form();
            showItemForm.Set_Related_Item(relatedItem);
            showItemForm.Read_Only = read_only;
            showItemForm.ShowDialog();

            if (showItemForm.Changed)
                OnDataChanged();

            show_related_item();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "relateditem";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Related Item";
                    break;
                case Template_Language.Spanish:
                    base.title = "Recursos Relacionados";
                    break;
                case Template_Language.French:
                    base.title = "Connexes de Ressources";
                    break;
                default:
                    base.title = "Related Item";
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
                    base.minimum_title_length = (int)(font_size * 16);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 18);
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
            if ((relatedItem != null) && ((relatedItem.Main_Title.Title.Length > 0) || (relatedItem.URL.Length > 0) || (relatedItem.SobekCM_ID.Length > 0)))
            {
                Bib.Bib_Info.Add_Related_Item(relatedItem);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.RelatedItems.Count)
            {
                relatedItem = Bib.Bib_Info.RelatedItems[base.index];
                show_related_item();
            }
        }

        private void show_related_item()
        {
            if ((relatedItem != null) && ((relatedItem.Main_Title.Title.Length > 0) || (relatedItem.URL.Length > 0) || (relatedItem.SobekCM_ID.Length > 0)))
            {
                if (relatedItem.URL_Display_Label.Length > 0)
                {
                    base.thisBox.Text = "(" + relatedItem.URL_Display_Label + ") " + relatedItem.Main_Title.Title;
                }
                else
                {
                    string relation = String.Empty;
                    switch (relatedItem.Relationship)
                    {
                        case Related_Item_Type_Enum.succeeding:
                            relation = "(Succeeded by) ";
                            break;

                        case Related_Item_Type_Enum.otherVersion:
                            relation = "(Other Version) ";
                            break;

                        case Related_Item_Type_Enum.otherFormat:
                            relation = "(Other Format) ";
                            break;

                        case Related_Item_Type_Enum.preceding:
                            relation = "(Preceded by) ";
                            break;

                        case Related_Item_Type_Enum.host:
                            relation = "(Host) ";
                            break;
                    }
                    base.thisBox.Text = relation + relatedItem.Main_Title.Title;
                }
            }
            else
            {
                base.thisBox.Clear();
            }
        }
    }
}
