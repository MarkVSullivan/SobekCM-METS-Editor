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
    /// to edit the title of a bibliographic package.</summary>
    public class Main_Title_Form_Element : simpleTextBox_Element
    {
        private Title_Info titleObject;
        private Note_Info statementNote;

        /// <summary> Constructor for a new Main_Title_Form_Element,  used in the metadata
        /// template to display and allow the user to edit the title of a 
        /// bibliographic package. </summary>
        public Main_Title_Form_Element() : base("Title")
        {
            // Set the type of this object
            base.type = Element_Type.Title;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = true;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            titleObject = new Title_Info();
            titleObject.User_Submitted = true;

            statementNote = new Note_Info();
            statementNote.Note_Type = Note_Type_Enum.statement_of_responsibility;
            statementNote.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Title_Info_Form showTitleForm = new Title_Info_Form();
                showTitleForm.SetTitle(titleObject, statementNote, true, false, false);
                showTitleForm.Read_Only = read_only;
                showTitleForm.ShowDialog();

                if (showTitleForm.Changed)
                    OnDataChanged();

                show_title_info();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Title_Info_Form showTitleForm = new Title_Info_Form();
            showTitleForm.SetTitle(titleObject, statementNote, true, false, false);
            showTitleForm.Read_Only = read_only;
            showTitleForm.ShowDialog();

            if (showTitleForm.Changed)
                OnDataChanged();

            show_title_info();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "title_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Title";
                    break;
                case Template_Language.Spanish:
                    base.title = "Titulo";
                    break;
                case Template_Language.French:
                    base.title = "Titre";
                    break;
                default:
                    base.title = "Title - unknown";
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
                    base.minimum_title_length = (int)(font_size * 5);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 5);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 5);
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
            // Get rid of note 
            List<Note_Info> statementNotes = new List<Note_Info>();
            foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
            {
                if (thisNote.Note_Type == Note_Type_Enum.statement_of_responsibility)
                    statementNotes.Add(thisNote);
            }
            foreach (Note_Info deleteNote in statementNotes)
            {
                Bib.Bib_Info.Remove_Note(deleteNote);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.Bib_Info.Main_Title = titleObject;

            // Add the statement of responsibility note
            if (statementNote.Note.Length > 0)
                Bib.Bib_Info.Add_Note(statementNote);
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (Bib.Bib_Info.Main_Title.Title.Length > 0)
            {
                titleObject = Bib.Bib_Info.Main_Title;
            }

            // Look for the statement of responsibility note
            foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
            {
                if (thisNote.Note_Type == Note_Type_Enum.statement_of_responsibility)
                {
                    statementNote = thisNote;
                }
            }

            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project)
            {
                thisBox.Enabled = false;
            }

            show_title_info();
        }

        private void show_title_info()
        {
            if (titleObject.Subtitle.Length > 0)
            {
                if (statementNote.Note.Length > 0)
                {
                    base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"") + " : " + titleObject.Subtitle.Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"") + " / " + statementNote.Note;
                }
                else
                {
                    base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"") + " : " + titleObject.Subtitle.Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
                }
            }
            else
            {
                if (statementNote.Note.Length > 0)
                {
                    base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"") + " / " + statementNote.Note;
                }
                else
                {
                    base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
                }
            }
        }
    }
}
