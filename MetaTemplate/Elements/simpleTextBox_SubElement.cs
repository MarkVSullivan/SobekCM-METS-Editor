#region Using directives

using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit one subelement of a larger element.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public abstract class simpleTextBox_SubElement : simpleTextBox_Element
	{
		private int set_title_length;
		private string[] names;

		/// <summary> Constructor for a new BibID_Element, used in the metadata
		/// template to display and allow the user to edit the bib id of a 
		/// bibliographic package. </summary>
		public simpleTextBox_SubElement( string[] Language_Names, int Title_Length, int Input_Length ) : base( Language_Names[0] )
		{
			// Set the type of this object
			base.type = Element_Type.BibID;

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;

			// Save the parameters
			maximum_input_length = Input_Length;
			names = Language_Names;
			set_title_length = Title_Length;
		}

		public string Value
		{
			get	{	return base.thisBox.Text.Trim();		}
			set	{	base.thisBox.Text = value;				}
		}

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = names[0];
					break;
				case Template_Language.Spanish:
					base.title = names[1];
					break;
				case Template_Language.French:
					base.title = names[2];
					break;
				default:
					base.title = names[0] + " - Unknown";
					break;
			}
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			// DO NOTHING HERE		
		}

		/// <summary> Checks the data in this element for validity. </summary>
		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			return true;
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			// DO NOTHING HERE
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			// DO NOTHING HERE
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			// DO NOTHING HERE
		}
	}
}