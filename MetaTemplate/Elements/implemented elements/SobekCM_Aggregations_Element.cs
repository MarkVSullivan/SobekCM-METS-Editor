#region Using directives

using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the aggregations of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="multiple_textBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class SobekCM_Aggregations_Element : multiple_textBox_Element
	{
        /// <summary> Constructor for a new SobekCM_Aggregations_Element, used in the metadata
		/// template to display and allow the user to edit the aggregations related to a 
		/// bibliographic package. </summary>
        public SobekCM_Aggregations_Element()
            : base("Aggregations")
		{
			// Set the type of this object
			base.type = Element_Type.Aggregations;

			// Set some immutable characteristics
			always_mandatory = false;
            Text_Box_Length = 80;
            Max_Box_Count = 5;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "collection";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Aggregations";
					break;
				case Template_Language.Spanish:
					base.title = "Colección";
					break;
				case Template_Language.French:
					base.title = "Collection";
					break;
				default:
					base.title = "Collection - unknown";
					break;
			}
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			// Get the size of the font
			float font_size = 10.0F;

				font_size = Font.SizeInPoints;

			// Set the title length
			switch( current_language )
			{
				case Template_Language.English:
					base.minimum_title_length = (int) (font_size * 10);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 9);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 9);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 14);
					break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
            Bib.Behaviors.Clear_Aggregations();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            // Build the collection of results
            foreach (TextBox thisBox in base.textBoxes)
            {
                if (thisBox.Text.Trim().Length > 0)
                {
                    Bib.Behaviors.Add_Aggregation(thisBox.Text.Trim());
                }
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            // How many alternate collection codes?
            for (int i = 0; (i < Max_Box_Count) && (i < Bib.Behaviors.Aggregation_Count); i++)
            {
                // Add a new box, if necessary
                if (i >= textBoxes.Count)
                    add_new_box();

                // Assign the appropriate value here
                ((TextBox)textBoxes[i]).Text = Bib.Behaviors.Aggregations[i].Code;
            }
		}
    }
}