#region Using directives

using System;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit the frequency of a continuing resource.</summary>
    /// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2010 ).</remarks>
    public class Frequency_Element : comboBox_Element
    {
        /// <summary> Constructor for a new Frequency_Element, used in the metadata
        /// template to display and allow the user to edit the frequency of a continuing resource </summary>
        public Frequency_Element()
            : base("Frequency")
        {
            // Set the type of this object
            base.type = Element_Type.Frequency;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.maximum_input_length = 250;
            Restrict_Values = true;
            repeatable = true;

            // Add the types to this box
            base.thisBox.Items.Add("");
            base.thisBox.Items.Add("annual");
            base.thisBox.Items.Add("biennial");
            base.thisBox.Items.Add("bimonthly");
            base.thisBox.Items.Add("biweekly");
            base.thisBox.Items.Add("completely irregular");
            base.thisBox.Items.Add("continuously updated");
            base.thisBox.Items.Add("daily");
            base.thisBox.Items.Add("monthly");
            base.thisBox.Items.Add("normalized irregular");
            base.thisBox.Items.Add("other");
            base.thisBox.Items.Add("quarterly");
            base.thisBox.Items.Add("regular");
            base.thisBox.Items.Add("semiannual");
            base.thisBox.Items.Add("semimonthly");
            base.thisBox.Items.Add("semiweekly");
            base.thisBox.Items.Add("three times a month");
            base.thisBox.Items.Add("three times a week");
            base.thisBox.Items.Add("three times a year");
            base.thisBox.Items.Add("triennial");
            base.thisBox.Items.Add("weekly");
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "frequency";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Frequency";
                    break;
                case Template_Language.Spanish:
                    base.title = "Frequency";
                    break;
                case Template_Language.French:
                    base.title = "Frequency";
                    break;
                default:
                    base.title = "Frequency- unknown";
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
            Bib.Bib_Info.Origin_Info.Clear_Frequencies();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            string frequency = base.thisBox.Text.Trim();
            if (frequency.Length > 0)
            {
                string authority = String.Empty;
                if ((frequency == "annual") || (frequency == "biennial") || (frequency == "bimonthly") || (frequency == "biweekly") ||
                    (frequency == "continuously updated") || (frequency == "daily") || (frequency == "monthly") || (frequency == "other") ||
                    (frequency == "quarterly") || (frequency == "semiannual") || (frequency == "semimonthly") || (frequency == "semiweekly") ||
                    (frequency == "regular") || (frequency == "three times a month") || (frequency == "three times a week") || (frequency == "three times a year") ||
                    (frequency == "triennial") || (frequency == "weekly") || (frequency == "completely irregular") || (frequency == "normalized irregular"))
                {
                    authority = "marcfrequency";
                }

                Bib.Bib_Info.Origin_Info.Add_Frequency(frequency, authority);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (Bib.Bib_Info.Origin_Info.Frequencies_Count > base.index)
            {
                base.thisBox.Text = Bib.Bib_Info.Origin_Info.Frequencies[base.index].Term;
            }

        }
    }
}