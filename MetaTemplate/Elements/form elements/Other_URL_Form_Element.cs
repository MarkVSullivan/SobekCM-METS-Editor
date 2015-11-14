#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit another url for the bibliographic package.</summary>
    public class Other_URL_Form_Element : simpleTextBox_Element
    {
        private string other_label;
        private string other_note;
        private string other_url;

        /// <summary> Constructor for a new Other_URL_Form_Element, used in the metadata
        /// template to display and allow the user to edit another URL for  
        /// bibliographic package. </summary>
        public Other_URL_Form_Element()
            : base("Related URL")
        {
            // Set the type of this object
            base.type = Element_Type.OtherURL;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            other_label = String.Empty;
            other_note = String.Empty;
            other_url = String.Empty;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen)  && ( e.KeyCode != Keys.Down ))
            {
                Other_URL_Form showForm = new Other_URL_Form();
                showForm.Add_Data(other_label, other_url, other_note);
                showForm.Read_Only = read_only;
                showForm.ShowDialog();
                showForm.Save_Data(ref other_label, ref other_url, ref other_note);

                if (showForm.Changed)
                    OnDataChanged();

                show_link_info();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Other_URL_Form showForm = new Other_URL_Form();
            showForm.Add_Data(other_label, other_url, other_note);
            showForm.Read_Only = read_only;
            showForm.ShowDialog();
            showForm.Save_Data(ref other_label, ref other_url, ref other_note);

            if (showForm.Changed)
                OnDataChanged();

            show_link_info();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "otherurl";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Related URL";
                    break;
                case Template_Language.Spanish:
                    base.title = "Relacionado Página Web";
                    break;
                case Template_Language.French:
                    base.title = "Page Web Connexes";
                    break;
                default:
                    base.title = "Related URL";
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
                    base.minimum_title_length = (int)(font_size * 9);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 18);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 9);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            // DO nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.Bib_Info.Location.Other_URL_Display_Label = other_label;
            Bib.Bib_Info.Location.Other_URL_Note = other_note;
            Bib.Bib_Info.Location.Other_URL = other_url.Replace("\\", "/");
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            other_label = Bib.Bib_Info.Location.Other_URL_Display_Label;
            other_note = Bib.Bib_Info.Location.Other_URL_Note;
            other_url = Bib.Bib_Info.Location.Other_URL;
            show_link_info();
        }

        private void show_link_info()
        {
            if ((other_note.Length == 0) && (other_url.Length == 0))
            {
                other_label = String.Empty;
                thisBox.Clear();
                return;
            }

            if (other_note.Length > 0)
            {
                if (other_label.Length > 0)
                {
                    thisBox.Text = other_label + ": " + other_note + " ( " + other_url + " )";
                }
                else
                {
                    thisBox.Text = "Related Link: " + other_note + " ( " + other_url + " )";
                }
            }
            else
            {
                if (other_label.Length > 0)
                {
                    thisBox.Text = other_label + ": " + other_url;
                }
                else
                {
                    thisBox.Text = "Related Link: " + other_url;
                }
            }
        }
    }
}
