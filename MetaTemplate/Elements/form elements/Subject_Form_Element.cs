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
    /// to edit a subject object from the bibliographic package.</summary>
    public class Subject_Form_Element : simpleTextBox_Element
    {
        private Subject_Info subjectObject;

        /// <summary> Constructor for a new Subject_Simple_Element, used in the metadata
        /// template to display and allow the user to edit a subject (but not scheme) of a 
        /// bibliographic package. </summary>
        public Subject_Form_Element()
            : base("Subject")
        {
            // Set the type of this object
            base.type = Element_Type.Subject;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            subjectObject = new Subject_Info_Standard();
            subjectObject.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Subject_Info_Form showSubject = new Subject_Info_Form();
                showSubject.SetSubject(subjectObject);
                showSubject.Read_Only = read_only;
                showSubject.ShowDialog();
                
                if (showSubject.Changed)
                    OnDataChanged();

                if (showSubject.Subject_Object != null)
                {
                    subjectObject = showSubject.Subject_Object;
                }
                show_subject_info();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Subject_Info_Form showSubject = new Subject_Info_Form();
            showSubject.SetSubject(subjectObject);
            showSubject.Read_Only = read_only;
            showSubject.ShowDialog();

            if (showSubject.Changed)
                OnDataChanged();

            if (showSubject.Subject_Object != null)
            {
                subjectObject = showSubject.Subject_Object;
            }
            show_subject_info();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "subject_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Subject Keyword";
                    break;
                case Template_Language.Spanish:
                    base.title = "Tema";
                    break;
                case Template_Language.French:
                    base.title = "Sujet";
                    break;
                default:
                    base.title = "Subject Keyword - unknown";
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
                    base.minimum_title_length = (int)(font_size * 12);
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
            // Clear all the subjects which are standard, name, or title
            List<Subject_Info> clears = new List<Subject_Info>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if ((thisSubject.Class_Type == Subject_Info_Type.Standard) || ( thisSubject.Class_Type == Subject_Info_Type.Name ) || ( thisSubject.Class_Type == Subject_Info_Type.TitleInfo ))
                {
                    clears.Add(thisSubject);
                }
            }
            foreach (Subject_Info clearSubject in clears)
            {
                Bib.Bib_Info.Remove_Subject(clearSubject);
            }

            // Clear all the genre which aren't marcgt
            List<Genre_Info> genres = new List<Genre_Info>();
            foreach (Genre_Info thisGenre in Bib.Bib_Info.Genres)
            {
                if (thisGenre.Authority != "marcgt")
                    genres.Add(thisGenre);
            }
            foreach (Genre_Info clearGenre in genres)
            {
                Bib.Bib_Info.Remove_Genre(clearGenre);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if ((base.thisBox.Text.Trim().Length > 0) && ( subjectObject != null ))
            {
                Bib.Bib_Info.Add_Subject(subjectObject);

                switch (subjectObject.Class_Type)
                {
                    case Subject_Info_Type.Name:
                        if (((Subject_Info_Name)subjectObject).Genres.Count > 0)
                        {
                            foreach (string genre in ((Subject_Info_Name)subjectObject).Genres)
                            {
                                Genre_Info newGenre = new Genre_Info(genre, subjectObject.Authority);
                                if (!Bib.Bib_Info.Genres.Contains(newGenre))
                                    Bib.Bib_Info.Add_Genre(newGenre);
                            }
                        }
                        break;

                    case Subject_Info_Type.TitleInfo:
                        if (((Subject_Info_TitleInfo)subjectObject).Genres.Count > 0)
                        {
                            foreach (string genre in ((Subject_Info_TitleInfo)subjectObject).Genres)
                            {
                                Genre_Info newGenre = new Genre_Info(genre, subjectObject.Authority);
                                if (!Bib.Bib_Info.Genres.Contains(newGenre))
                                    Bib.Bib_Info.Add_Genre(newGenre);
                            }
                        }
                        break;

                    case Subject_Info_Type.Standard:
                        if (((Subject_Info_Standard)subjectObject).Genres.Count > 0)
                        {
                            foreach (string genre in ((Subject_Info_Standard)subjectObject).Genres)
                            {
                                Genre_Info newGenre = new Genre_Info(genre, subjectObject.Authority);
                                if (!Bib.Bib_Info.Genres.Contains(newGenre))
                                    Bib.Bib_Info.Add_Genre(newGenre);
                            }
                        }
                        break;

                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int subject_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
            {
                Subject_Info thisSubject = Bib.Bib_Info.Subjects[i];
                if ((thisSubject.Class_Type == Subject_Info_Type.Standard) || (thisSubject.Class_Type == Subject_Info_Type.Name) || (thisSubject.Class_Type == Subject_Info_Type.TitleInfo))
                {
                    subject_index++;
                    if (subject_index == base.index)
                    {
                        subjectObject = thisSubject;
                        show_subject_info();
                        break;
                    }
                }
            }
        }

        private void show_subject_info()
        {
            base.thisBox.Text = subjectObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\""); ;
        }
    }
}
