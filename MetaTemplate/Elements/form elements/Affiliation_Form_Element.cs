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
    public class Affiliation_Form_Element : simpleTextBox_Element
    {
        private string universityText = "University";
        private string campusText = "Campus";
        private string collegeText = "College";

        private Affiliation_Info affiliationObject;

        /// <summary> Constructor for a new Creator_Simple_Element, used in the metadata
        /// template to display and allow the user to edit the creator's name of a 
        /// bibliographic package. </summary>
        public Affiliation_Form_Element() : base("Affiliation")
        {
            // Set the type of this object
            base.type = Element_Type.Affiliation;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            affiliationObject = new Affiliation_Info();

            listenForChange = false;
        }



        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Affiliation_Form showAffiliation = new Affiliation_Form();
                showAffiliation.SetAffiliation(affiliationObject);
                showAffiliation.ShowDialog();

                base.thisBox.Text = affiliationObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Affiliation_Form showAffiliation = new Affiliation_Form();
            showAffiliation.SetAffiliation(affiliationObject);
            showAffiliation.ShowDialog();

            base.thisBox.Text = affiliationObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "affiliation_hier";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            // Change the text on the links to add new types of titles
            switch (newLanguage)
            {
                case Template_Language.English:
                    title = "Affiliation";
                    universityText = "University";
                    campusText = "Campus";
                    collegeText = "College";

                    break;

                case Template_Language.Spanish:
                    title = "Afiliación";
                    universityText = "Universidad";
                    campusText = "Campus";
                    collegeText = "Escuela";
                    //unitText = "Unidad";
                    //departmentText = "Departamento";
                    //instituteText = "Instituto";
                    //centerText = "Center";
                    //sectionText = "Sección";
                    //subsectionText = "Subdivisión";
                    break;

                case Template_Language.French:
                    title = "Affiliation";
                    universityText = "Université";
                    campusText = "Campus";
                    collegeText = "École";
                    //unitText = "Unité";
                    //departmentText = "Département";
                    //instituteText = "Institut";
                    //centerText = "Center";
                    //sectionText = "Section";
                    //subsectionText = "Sous-section";
                    break;

                default:
                    title = "Affiliation";
                    universityText = "University";
                    campusText = "Campus";
                    collegeText = "College";
                    //unitText = "Unit";
                    //departmentText = "Department";
                    //instituteText = "Institute";
                    //centerText = "Center";
                    //sectionText = "Section";
                    //subsectionText = "SubSection";
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
                    base.minimum_title_length = (int)(font_size * 9);
                    break;
                case Template_Language.French:
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
            Bib.Bib_Info.Clear_Affiliations();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Affiliation(affiliationObject);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.Affiliations.Count)
            {
                affiliationObject = Bib.Bib_Info.Affiliations[base.index];
                base.thisBox.Text = affiliationObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\""); ;
            }
        }
    }
}
