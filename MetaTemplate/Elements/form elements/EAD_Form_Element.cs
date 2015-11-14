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
    /// to edit the EAD for the bibliographic package.</summary>
    public class EAD_Form_Element : simpleTextBox_Element
    {
        private string ead_name;
        private string ead_url;

        /// <summary> Constructor for a new EAD_Form_Element, used in the metadata
        /// template to display and allow the user to edit the EAD for  
        /// bibliographic package. </summary>
        public EAD_Form_Element()
            : base("EAD")
        {
            // Set the type of this object
            base.type = Element_Type.EAD;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            ead_name = String.Empty;
            ead_url = String.Empty;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                EAD_Form showForm = new EAD_Form();
                showForm.Add_Data(ead_name, ead_url);
                showForm.Read_Only = read_only;
                showForm.ShowDialog();
                showForm.Save_Data(ref ead_name, ref ead_url);

                if (showForm.Changed)
                    OnDataChanged();

                show_ead_info();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            EAD_Form showForm = new EAD_Form();
            showForm.Add_Data(ead_name, ead_url);
            showForm.Read_Only = read_only;
            showForm.ShowDialog();
            showForm.Save_Data(ref ead_name, ref ead_url);

            if (showForm.Changed)
                OnDataChanged();

            show_ead_info();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "ead_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "EAD";
                    break;
                case Template_Language.Spanish:
                    base.title = "EAD";
                    break;
                case Template_Language.French:
                    base.title = "EAD";
                    break;
                default:
                    base.title = "EAD";
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
                    base.minimum_title_length = (int)(font_size * 6);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 6);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 6);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 6);
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
            Bib.Bib_Info.Location.EAD_Name = ead_name;
            Bib.Bib_Info.Location.EAD_URL = ead_url.Replace("\\", "/");
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            ead_name = Bib.Bib_Info.Location.EAD_Name;
            ead_url = Bib.Bib_Info.Location.EAD_URL;
            show_ead_info();

        }

        private void show_ead_info()
        {
            if (ead_url.Length == 0)
                thisBox.Clear();
            else
            {
                if (ead_name.Length > 0)
                {
                    thisBox.Text = ead_name + " ( " + ead_url + " )";
                }
                else
                {
                    thisBox.Text = ead_url;
                }
            }
        }
    }
}
