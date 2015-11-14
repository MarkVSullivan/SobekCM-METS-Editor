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
    /// to edit a name info object from the bibliographic package.</summary>
    public class Donor_Form_Element : simpleTextBox_Element
    {
        private Name_Info nameObject;

        /// <summary> Constructor for a new Creator_Simple_Element, used in the metadata
        /// template to display and allow the user to edit the creator's name of a 
        /// bibliographic package. </summary>
        public Donor_Form_Element()
            : base("Donor")
        {
            // Set the type of this object
            base.type = Element_Type.Donor;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            nameObject = new Name_Info();
            nameObject.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Name_Info_Form showNameForm = new Name_Info_Form();
                showNameForm.SetName(nameObject, false, true, null, false);
                showNameForm.Read_Only = read_only;
                showNameForm.ShowDialog();

                if (showNameForm.Changed)
                    OnDataChanged();

                string nameText = nameObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
                if (nameText == "unknown")
                    thisBox.Text = String.Empty;
                else
                    thisBox.Text = nameText;
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Name_Info_Form showNameForm = new Name_Info_Form();
            showNameForm.SetName(nameObject, false, true, null, false);
            showNameForm.Read_Only = read_only;
            showNameForm.ShowDialog();

            if (showNameForm.Changed)
                OnDataChanged();

            string nameText = nameObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            if (nameText == "unknown")
                thisBox.Text = String.Empty;
            else
                thisBox.Text = nameText;
        }


        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "donor_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Donor";
                    break;
                case Template_Language.Spanish:
                    base.title = "Donante";
                    break;
                case Template_Language.French:
                    base.title = "Donateur";
                    break;
                default:
                    base.title = "Donor - unknown";
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
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 10);
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
            // Do nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.Bib_Info.Donor = nameObject;
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if ((Bib.Bib_Info.Donor.Full_Name.Length > 0) || (Bib.Bib_Info.Donor.Family_Name.Length > 0) || (Bib.Bib_Info.Donor.Given_Name.Length > 0))
            {
                nameObject = Bib.Bib_Info.Donor;
            }
            string nameText = nameObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            if (nameText == "unknown")
                thisBox.Text = String.Empty;
            else
                thisBox.Text = nameText;
        }
    }
}
