#region Using directives

using System;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the volume id of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class VID_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new VID_Element, used in the metadata
		/// template to display and allow the user to edit the volume id of a 
		/// bibliographic package. </summary>
		public VID_Element( ) : base( "VID" )
		{
			// Set the type of this object
			base.type = Element_Type.VID;

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
            return "vid";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Volume Identifier";
					break;
				case Template_Language.Spanish:
					base.title = "Identificación Del Volumen";
					break;
				case Template_Language.French:
					base.title = "Identification De Volume";
					break;
				default:
					base.title = "VID - unknown";
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
					base.minimum_title_length = (int) (font_size * 12);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 18);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 17);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 15);
					break;
			}
		}

		/// <summary> Checks the data in this element for validity. </summary>
		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			if ( thisBox.Text.Trim().Length > 0 )
			{
				thisBox.Text = thisBox.Text.ToUpper().Replace("VID","").Trim();
				if ( thisBox.Text.Length != 5 )
				{
					base.invalid_string = "VID must be five digits long";
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			// Do nothing
		}


		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                Bib.VID = "00001";
            }
            else
            {
                Bib.VID = base.thisBox.Text.Trim();
            }

            if (Bib.BibID.Length > 0)
                Bib.METS_Header.ObjectID = Bib.BibID + "_" + Bib.VID;
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                base.thisBox.Text = String.Empty;
            }
            else
            {
                base.thisBox.Text = Bib.VID;

                // Default to '00001' though
                if (Bib.VID.Length == 0)
                    base.thisBox.Text = "00001";
            }
		}
	}
}