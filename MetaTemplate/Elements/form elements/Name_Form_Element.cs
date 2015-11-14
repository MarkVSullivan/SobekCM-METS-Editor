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
    public class Name_Form_Element : simpleTextBox_Element
    {
        private Name_Info nameObject;
        private Affiliation_Info affiliation;
        private bool main_entity;

        /// <summary> Constructor for a new Creator_Simple_Element, used in the metadata
        /// template to display and allow the user to edit the creator's name of a 
        /// bibliographic package. </summary>
        public Name_Form_Element()
            : base("Name")
        {
            // Set the type of this object
            base.type = Element_Type.Creator;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;


            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            nameObject = new Name_Info();
            nameObject.User_Submitted = true;
            main_entity = false;

            affiliation = new Affiliation_Info();

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && ( e.KeyCode != Keys.Down ))
            {
                Name_Info_Form showNameForm = new Name_Info_Form();
                showNameForm.SetName(nameObject, false, false, affiliation, main_entity);
                showNameForm.Read_Only = read_only;
                showNameForm.ShowDialog();

                if (showNameForm.Changed)
                    OnDataChanged();

                main_entity = showNameForm.Main_Entity;
                affiliation = showNameForm.Affiliation;
                show_name_info();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Name_Info_Form showNameForm = new Name_Info_Form();
            showNameForm.SetName(nameObject, false, false, affiliation, main_entity);
            showNameForm.Read_Only = read_only;
            showNameForm.ShowDialog();

            if (showNameForm.Changed)
                OnDataChanged();

            main_entity = showNameForm.Main_Entity;
            affiliation = showNameForm.Affiliation;

            show_name_info();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "creator_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Creator";
                    break;
                case Template_Language.Spanish:
                    base.title = "Autor o Creador";
                    break;
                case Template_Language.French:
                    base.title = "Créateur";
                    break;
                default:
                    base.title = "Creator - unknown";
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
                    base.minimum_title_length = (int)(font_size * 11);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 7);
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
            Bib.Bib_Info.Main_Entity_Name.Clear();
            Bib.Bib_Info.Clear_Names();
            Bib.Bib_Info.Clear_Affiliations();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            // You must always re-id the name and affiliations here
            int nameid = base.index + 1;
            nameObject.ID = "NAM" + nameid;
            affiliation.Name_Reference = nameObject.Actual_ID;

            if ((nameObject != null) && ((nameObject.Full_Name.Length > 0) || (nameObject.Family_Name.Length > 0) || (nameObject.Given_Name.Length > 0)))
            {
                if ((main_entity) && (Bib.Bib_Info.Main_Entity_Name.Full_Name.Length == 0))
                {
                    Bib.Bib_Info.Main_Entity_Name = nameObject;
                }
                else
                {
                    Bib.Bib_Info.Add_Named_Entity(nameObject);
                }
            }

            // Does the affiliation have data?  If so, add it
            if (affiliation.hasData)
            {
                Bib.Bib_Info.Add_Affiliation(affiliation);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            // Get the correct name object
            if ((Bib.Bib_Info.Main_Entity_Name.Full_Name.Length == 0) && ( Bib.Bib_Info.Main_Entity_Name.Family_Name.Length == 0 ) && ( Bib.Bib_Info.Main_Entity_Name.Given_Name.Length == 0 ))
            {
                if (base.index < Bib.Bib_Info.Names.Count)
                {
                    nameObject = Bib.Bib_Info.Names[base.index];
                    main_entity = false;
                }
            }
            else
            {
                if (base.index == 0)
                {
                    nameObject = Bib.Bib_Info.Main_Entity_Name;
                    main_entity = true;
                }
                else
                {
                    if (base.index <= Bib.Bib_Info.Names.Count)
                    {
                        nameObject = Bib.Bib_Info.Names[base.index - 1];
                        main_entity = false;
                    }
                }
            }

            // See if there is a matching affiliation
            if (nameObject.Actual_ID.Length > 0)
            {
                foreach (Affiliation_Info bibAffiliation in Bib.Bib_Info.Affiliations)
                {
                    if (bibAffiliation.Name_Reference == nameObject.Actual_ID)
                    {
                        affiliation = bibAffiliation;
                        break;
                    }
                }
            }

            show_name_info();
        }


        private void show_name_info()
        {
            if ((affiliation != null) && (affiliation.hasData))
            {
                string name_text = nameObject + " [ " + affiliation + " ]";
                base.thisBox.Text = name_text.Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            }
            else
            {
                string show_name_text = nameObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
                if (show_name_text.ToUpper() == "UNKNOWN")
                    base.thisBox.Text = String.Empty;
                else
                    base.thisBox.Text = show_name_text;
            }
        }
    }
}
