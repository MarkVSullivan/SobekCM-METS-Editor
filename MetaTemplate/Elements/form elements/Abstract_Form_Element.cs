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
    /// to edit abstracts about the bibliographic package.</summary>
    public class Abstract_Form_Element : simpleTextBox_Element
    {
        private Abstract_Info noteObject;

        /// <summary> Constructor for a new Abstract_Form_Element, used in the metadata
        /// template to display and allow the user to edit abstracts about a  
        /// bibliographic package. </summary>
        public Abstract_Form_Element()
            : base("Abstract")
        {
            // Set the type of this object
            base.type = Element_Type.Abstract;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            noteObject = new Abstract_Info();

            listenForChange = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            show_note_value();
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Abstract_Note_Form showNoteForm = new Abstract_Note_Form();
                showNoteForm.SetAbstract(noteObject);
                showNoteForm.Read_Only = read_only;
                showNoteForm.ShowDialog();

                if (showNoteForm.Changed)
                    OnDataChanged();

                show_note_value();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Abstract_Note_Form showNoteForm = new Abstract_Note_Form();
            showNoteForm.SetAbstract(noteObject);
            showNoteForm.Read_Only = read_only;
            showNoteForm.ShowDialog();

            if (showNoteForm.Changed)
                OnDataChanged();

            show_note_value();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "abstract_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Abstract";
                    break;
                case Template_Language.Spanish:
                    base.title = "Resumen";
                    break;
                case Template_Language.French:
                    base.title = "Résumé";
                    break;
                default:
                    base.title = "Abstract - unknown";
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
                    base.minimum_title_length = (int)(font_size * 7);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 8);
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
            Bib.Bib_Info.Clear_Abstracts();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Abstract(noteObject);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.Abstracts.Count)
            {
                noteObject = Bib.Bib_Info.Abstracts[base.index];

                show_note_value();
            }
        }

        private void show_note_value()
        {
            string totalNoteValue = noteObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"").Replace("<b>", "(").Replace("</b>", ") ");
            if (base.thisBox.Width > 12)
            {
                if (totalNoteValue.Length > (base.thisBox.Width / 6))
                {
                    base.thisBox.Text = totalNoteValue.Substring(0, (base.thisBox.Width / 6)) + "...";
                }
                else
                {
                    base.thisBox.Text = totalNoteValue;
                }
            }
        }
    }
}
