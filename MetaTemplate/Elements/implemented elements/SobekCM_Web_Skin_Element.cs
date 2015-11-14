#region Using directives

using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the web skin information of a bibliographic package.</summary>
    /// <remarks>This class extends the <see cref="multiple_textBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
    public class SobekCM_Web_Skin_Element : multiple_textBox_Element
	{
        /// <summary> Constructor for a new SobekCM_Web_Skin_Element, used in the metadata
		/// template to display and allow the user to edit the interface information of a 
		/// bibliographic package. </summary>
        public SobekCM_Web_Skin_Element()
            : base("Web Skin")
		{
			// Set the type of this object
			base.type = Element_Type.Web_Skin;

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

			// Set some formatting characteristics
            base.maximum_input_length = 1200;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "interface";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Web Skin";
					break;
				case Template_Language.Spanish:
					base.title = "Interfaz";
					break;
				case Template_Language.French:
					base.title = "Interface";
					break;
				default:
					base.title = "Interface - unknown";
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
					base.minimum_title_length = (int) (font_size * 8);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 8);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 8);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 8);
					break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			Bib.Behaviors.Clear_Web_Skins();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            foreach (TextBox thisBox in textBoxes)
            {
                Bib.Behaviors.Add_Web_Skin(thisBox.Text.Trim());
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            // How many interface codes?
            for (int i = 0; (i < Max_Box_Count) && (i < Bib.Behaviors.Web_Skin_Count); i++)
            {
                // Add a new box, if necessary
                if (i >= textBoxes.Count)
                    add_new_box();

                // Assign the appropriate value here
                ((TextBox)textBoxes[i]).Text = Bib.Behaviors.Web_Skins[i];
            }
		}
	}
}