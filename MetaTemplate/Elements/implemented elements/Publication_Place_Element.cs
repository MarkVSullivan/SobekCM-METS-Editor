#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit publication places</summary>
    /// <remarks>This class extends the <see cref="multiple_textBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2010 ).</remarks>
    public class Publication_Place_Element : multiple_textBox_Element
    {
        /// <summary> Constructor for a new Interface_Element, used in the metadata
        /// template to display and allow the user to edit the interface information of a 
        /// bibliographic package. </summary>
        public Publication_Place_Element() : base("Publication Place")
        {
            // Set the type of this object
            base.type = Element_Type.Publication_Place;

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.text_box_length = 120;

            // Set some formatting characteristics
            base.maximum_input_length = 1200;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "pubplace";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Publication Place";
                    break;
                case Template_Language.Spanish:
                    base.title = "Publication Place";
                    break;
                case Template_Language.French:
                    base.title = "Publication Place";
                    break;
                default:
                    base.title = "Publication Place - unknown";
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
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 14);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 14);
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
            // First collect all the places
            List<string> publication_places = new List<string>();
            foreach (TextBox thisBox in textBoxes)
            {
                if (thisBox.Text.Trim().Length > 0)
                {
                    publication_places.Add(thisBox.Text.Trim());
                }
            }

            // If no places, done
            if (publication_places.Count == 0)
                return;

            // Is there no publishers?
            if (Bib.Bib_Info.Publishers_Count == 0)
            {
                Bib.Bib_Info.Add_Publisher("s.n.");
            }

            // Is there just one publisher?
            if (Bib.Bib_Info.Publishers_Count == 1)
            {
                ReadOnlyCollection<Publisher_Info> publishers = Bib.Bib_Info.Publishers;
                foreach (string thisPubPlace in publication_places)
                {
                    bool found = false;
                    foreach (Origin_Info_Place thisPlace in publishers[0].Places)
                    {
                        if (thisPlace.Place_Text.ToUpper().Trim() == thisPubPlace.ToUpper().Trim())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        publishers[0].Add_Place(thisPubPlace);
                    }
                }
            }
            else
            {
                ReadOnlyCollection<Publisher_Info> publishers = Bib.Bib_Info.Publishers;
                for (int i = 0; i < publishers.Count && i < publication_places.Count; i++)
                {
                    publishers[i].Add_Place(publication_places[i]);
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int count = 0;
            if (Bib.Bib_Info.Publishers_Count > 0)
            {
                foreach (Publisher_Info thisName in Bib.Bib_Info.Publishers)
                {
                    foreach (Origin_Info_Place thisPlace in thisName.Places)
                    {
                        if (thisPlace.Place_Text.Length > 0)
                        {
                            // Add a new box, if necessary
                            if (count >= textBoxes.Count)
                            {
                                add_new_box();
                            }

                            // Assign the appropriate value here
                            ((TextBox)textBoxes[count]).Text = thisPlace.Place_Text;

                            count++;
                        }
                    }
                }
            }
        }
    }
}