#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the bib id of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class BibId_Element : simpleTextBox_Element
	{
        private bool isProject;

		/// <summary> Constructor for a new BibID_Element, used in the metadata
		/// template to display and allow the user to edit the bib id of a 
		/// bibliographic package. </summary>
		public BibId_Element( ) : base( "Bibliographic Identifier" )
		{
			// Set the type of this object
			base.type = Element_Type.BibID;

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = true;

			// Set some formatting characteristics
			maximum_input_length = 150;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "bibid";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
            if (isProject)
            {
                base.title = "Project Code";
            }
            else
            {
                switch (newLanguage)
                {
                    case Template_Language.English:
                        base.title = "Bibliographic Identifier";
                        break;
                    case Template_Language.Spanish:
                        base.title = "Identificación Bibliográfica";
                        break;
                    case Template_Language.French:
                        base.title = "Marque Bibliographique";
                        break;
                    default:
                        base.title = "Bib ID - unknown";
                        break;
                }
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
					base.minimum_title_length = (int) (font_size * 15);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 18);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 16);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 10);
					break;
			}
		}

		/// <summary> Checks the data in this element for validity. </summary>
		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			if ( thisBox.Text.Trim().Length != 10 )
			{
				invalid_string = "BibID must be 10 digits long";
				return false;
			}
			else
				return true;
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			// Do nothing here necessarily
		}


		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			Bib.BibID = base.thisBox.Text.Trim();

            Bib.METS_Header.ObjectID = Bib.BibID;
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                isProject = true;
                base.title = "Project Code";
                thisBox.Enabled = false;
            }
            else
            {
                isProject = false;
            }

            base.thisBox.Text = Bib.BibID;

            // If there bibid is empty, try to check the ObjectID of the METS
            if ((Bib.BibID.Length == 0) && (Bib.METS_Header.ObjectID.Length >= 10))
            {
                if (Bib.METS_Header.ObjectID.Length == 10)
                    base.thisBox.Text = Bib.METS_Header.ObjectID;
                else
                {
                    if (Bib.METS_Header.ObjectID[10] == '_')
                        base.thisBox.Text = Bib.METS_Header.ObjectID.Substring(0, 10);
                }
            }
		}
	}
}