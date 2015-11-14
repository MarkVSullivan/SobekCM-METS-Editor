#region Using directives

using System.Collections.Generic;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the scale of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Scale_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Scale_Element, used in the metadata
		/// template to display and allow the user to edit the scale of a 
		/// bibliographic package. </summary>
		public Scale_Element( ) : base( "Scale" )
		{
			// Set the type of this object
			base.type = Element_Type.Scale;

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "scale";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Scale";
					break;
				case Template_Language.Spanish:
					base.title = "Escala";
					break;
				case Template_Language.French:
					base.title = "Scale";
					break;
				default:
					base.title = "Scale - unknown";
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
					base.minimum_title_length = (int) (font_size * 10);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 10);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 10);
					break;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			// Clear out the cartographics
            List<Subject_Info_Cartographics> clears = new List<Subject_Info_Cartographics>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Cartographics)
                {
                    clears.Add((Subject_Info_Cartographics)thisSubject);
                }
            }

            foreach (Subject_Info_Cartographics clearSubject in clears)
            {
                Bib.Bib_Info.Remove_Subject(clearSubject);
            }            
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            // Clear out the cartographics
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Cartographics)
                {
                    (( Subject_Info_Cartographics) thisSubject ).Scale = base.thisBox.Text.Trim();
                    break;
                }
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            // Clear out the cartographics
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Cartographics)
                {
                    base.thisBox.Text = ((Subject_Info_Cartographics)thisSubject).Scale;
                    break;
                }
            }
		}
	}
}