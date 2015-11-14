#region Using directives

using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit a translated title of a bibliographic package.</summary>
    /// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2006 ).</remarks>
    public class Other_Title_Element : keywordScheme_Element
    {
        /// <summary> Constructor for a new Other_Title_Element, used in the metadata
        /// template to display and allow the user to edit other titles associated with a 
        /// bibliographic package. </summary>
        public Other_Title_Element()
            : base("Other Title")
        {
            // Set the type of this object
            base.type = Element_Type.Title_Other;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.thisSchemeBox.Width = 120;
            base.thisSchemeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            repeatable = true;
            

            // Add the schemes
            base.Scheme_Length = 50;
            base.scheme = "Type";
            base.thisSchemeBox.Items.Add("Abbreviated Title");
            base.thisSchemeBox.Items.Add("Alternative Title");
            base.thisSchemeBox.Items.Add("Series Title");
            base.thisSchemeBox.Items.Add("Subtitle");
            base.thisSchemeBox.Items.Add("Translated Title");
            base.thisSchemeBox.Items.Add("Uniform Title");

           

        }

        public override string Help_URL()
        {
            return "othertitle";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Other Title(s)";
                    base.scheme = "Type";
                    break;
                case Template_Language.Spanish:
                    base.title = "Other Title(s)";
                    base.scheme = "Type";
                    break;
                case Template_Language.French:
                    base.title = "Other Titles(s)";
                    base.scheme = "Type";
                    break;
                default:
                    base.title = "Other Title(s) - unknown";
                    base.scheme = "Type";
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
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            // Clear the other titles
            if (Bib.Bib_Info.hasSeriesTitle)
                Bib.Bib_Info.SeriesTitle.Clear();
            Bib.Bib_Info.Clear_Other_Titles();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            string title_text = base.thisKeywordBox.Text.Trim();
            string title_type = base.thisSchemeBox.Text;

            if (title_text.Trim().Length > 0)
            {
                switch (title_type)
                {
                    case "Abbreviated Title":
                        Bib.Bib_Info.Add_Other_Title(title_text, Title_Type_Enum.abbreviated);
                        break;

                    case "Alternative Title":
                        Bib.Bib_Info.Add_Other_Title(title_text, Title_Type_Enum.alternative);
                        break;

                    case "Translated Title":
                        Bib.Bib_Info.Add_Other_Title(title_text, Title_Type_Enum.translated);
                        break;

                    case "Uniform Title":
                        Bib.Bib_Info.Add_Other_Title(title_text, Title_Type_Enum.uniform);
                        break;

                    case "Series Title":
                        Bib.Bib_Info.SeriesTitle.Title = title_text;
                        break;

                    case "Subtitle":
                        Bib.Bib_Info.Main_Title.Subtitle = title_text;
                        break;

                    default:
                        Bib.Bib_Info.Add_Other_Title(title_text, Title_Type_Enum.alternative);
                        break;
                }
            }
            else
            {
                // Accept an empty subtitle here
                if (title_type == "Subtitle")
                {
                    Bib.Bib_Info.Main_Title.Subtitle = string.Empty;
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int title_count = 0;
            if (Bib.Bib_Info.Main_Title.Subtitle.Length > 0)
            {
                if (base.index == title_count)
                {
                    base.thisKeywordBox.Text = Bib.Bib_Info.Main_Title.Subtitle;
                    base.thisSchemeBox.Text = "Subtitle";
                    return;
                }
                title_count++;
            }

            if ((Bib.Bib_Info.hasSeriesTitle) && (Bib.Bib_Info.SeriesTitle.Title.Length > 0))
            {
                if (base.index == title_count)
                {
                    base.thisKeywordBox.Text = Bib.Bib_Info.SeriesTitle.Title;
                    base.thisSchemeBox.Text = "Series Title";
                    return;
                }
                title_count++;
            }

            if (Bib.Bib_Info.Other_Titles_Count > 0)
            {
                foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
                {
                    if (thisTitle.Title.Length > 0)
                    {
                        if (base.index == title_count)
                        {
                            base.thisKeywordBox.Text = thisTitle.Title;
                            switch (thisTitle.Title_Type)
                            {
                                case Title_Type_Enum.abbreviated:
                                    base.thisSchemeBox.Text = "Abbreviated Title";
                                    break;

                                case Title_Type_Enum.alternative:
                                    base.thisSchemeBox.Text = "Alternative Title";
                                    break;

                                case Title_Type_Enum.translated:
                                    base.thisSchemeBox.Text = "Translated Title";
                                    break;

                                case Title_Type_Enum.uniform:
                                    base.thisSchemeBox.Text = "Uniform Title";
                                    break;
                            }

                            return;
                        }
                        title_count++;
                    }
                }
            }
        }
    }
}
