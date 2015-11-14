#region Using directives

using System;
using System.Collections.Generic;
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
    /// to edit notes about the bibliographic package.</summary>
    public class Note_Form_Element : simpleTextBox_Element
    {
        private Note_Info noteObject;

        /// <summary> Constructor for a new Note_Form_Element, used in the metadata
        /// template to display and allow the user to edit notes about a  
        /// bibliographic package. </summary>
        public Note_Form_Element()
            : base("Note")
        {
            // Set the type of this object
            base.type = Element_Type.Note;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            noteObject = new Note_Info();
            noteObject.User_Submitted = true;

            listenForChange = false;
        }

        protected override void  OnResize(EventArgs e)
        {
             base.OnResize(e);

            show_note_value();
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Abstract_Note_Form showNoteForm = new Abstract_Note_Form();
                showNoteForm.SetNote(noteObject);
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
            showNoteForm.SetNote(noteObject);
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
            return "note_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Note";
                    break;
                case Template_Language.Spanish:
                    base.title = "Note";
                    break;
                case Template_Language.French:
                    base.title = "Note";
                    break;
                default:
                    base.title = "Note";
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
            List<Note_Info> clearNotes = new List<Note_Info>();
            foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
            {
                if ((thisNote.Note_Type != Note_Type_Enum.statement_of_responsibility) && ( thisNote.Note_Type != Note_Type_Enum.default_type ))
                    clearNotes.Add(thisNote);
            }
            foreach (Note_Info clearNote in clearNotes)
            {
                Bib.Bib_Info.Remove_Note(clearNote);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Note( noteObject );
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.Notes.Count)
            {
                int total_note_count = 0;
                int acceptable_note_count = 0;
                foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
                {
                    if ((thisNote.Note_Type == Note_Type_Enum.statement_of_responsibility) || ( thisNote.Note_Type == Note_Type_Enum.default_type ))
                    {
                        total_note_count++;
                    }
                    else
                    {
                        total_note_count++;
                        acceptable_note_count++;
                    }

                    if (acceptable_note_count == base.index + 1)
                    {
                        noteObject = Bib.Bib_Info.Notes[total_note_count - 1];
                        break;
                    }
                }

                show_note_value();
            }
        }

        private void show_note_value()
        {
            string totalNoteValue = noteObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"").Replace("<b>", "(").Replace("</b>", ") ").Replace("&lt;","<").Replace("&gt;",">");
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
