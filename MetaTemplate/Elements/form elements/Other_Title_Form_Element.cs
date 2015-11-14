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
    /// to edit the serial title of a bibliographic package.</summary>
    public class Other_Title_Form_Element : simpleTextBox_Element
    {
        private Title_Info titleObject;

        /// <summary> Constructor for a new Uniform_Title_Form_Element,  used in the metadata
        /// template to display and allow the user to edit the title of a 
        /// bibliographic package. </summary>
        public Other_Title_Form_Element()
            : base("Alternate Title")
        {
            // Set the type of this object
            base.type = Element_Type.Title_Other;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            titleObject = new Title_Info();
            titleObject.Title_Type = Title_Type_Enum.alternative;
            titleObject.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Title_Info_Form showTitleForm = new Title_Info_Form();
                showTitleForm.SetTitle(titleObject, null, false, false, false);
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
            showTitleForm.SetTitle(titleObject, null, false, false, false);
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
            return "othertitle_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Alternate Title";
                    break;
                case Template_Language.Spanish:
                    base.title = "Título Alterno";
                    break;
                case Template_Language.French:
                    base.title = "Titre Alternatif";
                    break;
                default:
                    base.title = "Alternate Title - unknown";
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
                    base.minimum_title_length = (int)(font_size * 11);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 11);
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
            List<Title_Info> clears = new List<Title_Info>();
            foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
            {
                if ((thisTitle.Title_Type == Title_Type_Enum.alternative) || ( thisTitle.Title_Type == Title_Type_Enum.abbreviated ) || ( thisTitle.Title_Type == Title_Type_Enum.translated ))
                {
                    clears.Add(thisTitle);
                }
            }
            foreach (Title_Info clearTitle in clears)
            {
                Bib.Bib_Info.Remove_Other_Title(clearTitle);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Other_Title(titleObject);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int title_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Other_Titles.Count; i++)
            {
                Title_Info thisTitle = Bib.Bib_Info.Other_Titles[i];
                if ((thisTitle.Title_Type == Title_Type_Enum.alternative) || (thisTitle.Title_Type == Title_Type_Enum.abbreviated) || (thisTitle.Title_Type == Title_Type_Enum.translated))
                {
                    title_index++;
                    if (title_index == base.index)
                    {
                        titleObject = thisTitle;
                        show_title_info();
                        break;
                    }
                }
            }
        }

        private void show_title_info()
        {
            if (titleObject.Subtitle.Length > 0)
            {
                base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"") + " : " + titleObject.Subtitle.Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            }
            else
            {
                base.thisBox.Text = titleObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            }
        }
    }
}
