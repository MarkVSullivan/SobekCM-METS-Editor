#region Using directives

using System.Drawing;
using System.Xml;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for iElement.
	/// </summary>
	interface iElement
	{
		/// <summary> Gets the element type for this </summary>
		Element_Type Type { get; }

		/// <summary> Gets the display subtype for this element </summary>
		string Display_SubType { get; }

		/// <summary> Flag indicates if this is being used as a constant field,
		/// or if data can be entered by the user </summary>
		bool isConstant { get; set; }

		/// <summary> Gets and sets the flag indicating this allows repeatability </summary>
		bool Repeatable { get; set; }

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		bool hasValue { get; }

		/// <summary> Gets and sets the flag indicating this is mandatory </summary>
		bool Mandatory { get; set; }

		/// <summary> Tests for validity of the input, or lack of input </summary>
		/// <returns>TRUE if valid, otherwise FALSE</returns>
		/// <remarks> This sets the <see cref="iElement.Invalid_String"/> property.</remarks>
		bool isValid ( );

		/// <summary> Gets the invalid string, if this element did not pass validity </summary>
		string Invalid_String { get; }

		/// <summary> Sets the font for the form  </summary>
		/// <param name="CurrentFont"></param>
		void Set_Font( Font CurrentFont );

		/// <summary> Reads from the template XML format </summary>
		/// <param name="inner_xml_string">Inner XML for this element </param>
		void Read_XML( XmlTextReader xmlReader );

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		void Prepare_For_Save( SobekCM_Item Bib );

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		void Save_To_Bib( SobekCM_Item Bib );

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		void Populate_From_Bib( SobekCM_Item Bib );

		/// <summary> Returns the XML string to save this element and its data to the template XML file </summary>
		/// <param name="indent"> Indent to use for each line </param>
		/// <returns>String for template XML file</returns>
		string To_Template_XML( string indent );

		/// <summary> Returns the title of this element in the current language </summary>
		string Title { get; }
	}
}
