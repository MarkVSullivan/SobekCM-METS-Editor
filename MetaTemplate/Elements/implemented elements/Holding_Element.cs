#region Using directives

using System;
using System.Drawing;
using System.Xml;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Bib_Info;

#endregion

// THIS FILE CONTAINS BOTH CLASSES FOR HOLDING LOCATION:
//		Holding_Simple_Element : simpleTextBox_Element
//		Holding_Complex_Element : codeStatement_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the holding location statement of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Holding_Simple_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Holding_Simple_Element, used in the metadata
		/// template to display and allow the user to edit the holding location statement of a 
		/// bibliographic package. </summary>
		public Holding_Simple_Element( ) : base( "Holding Location" )
		{
			// Set the type of this object
			base.type = Element_Type.Holding;
			base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "holding_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Holding Location";
					break;
				case Template_Language.Spanish:
					base.title = "Local de Almacén";
					break;
				case Template_Language.French:
					base.title = "Endroit de la Source";
					break;
				default:
					base.title = "Holding Location - unknown";
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
					base.minimum_title_length = (int) (font_size * 12);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 14);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 15);
					break;
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
			Bib.Bib_Info.Location.Holding_Name = base.thisBox.Text.Trim();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            base.thisBox.Text = Bib.Bib_Info.Location.Holding_Name;
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the holding location (both code and statement) of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="codeStatement_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Holding_Complex_Element : codeStatement_Element
	{
		private string html;
        private string last_code;

		/// <summary> Constructor for a new Holding_Complex_Element, used in the metadata
		/// template to display and allow the user to edit the holding location (both code
		/// and statement) of a bibliographic package. </summary>
		public Holding_Complex_Element( ) : base( "Holding Location" )
		{
			// Set the type of this object
			base.type = Element_Type.Holding;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;
            last_code = String.Empty;

            // Add elements to the combo box
            foreach (Aggregation_Info thisInstitution in MetaTemplate_UserSettings.Institutions_List)
            {
                thisCodeBox.Items.Add(thisInstitution.Code);
            }

			// Set the code box to only accept values in box
			base.Restrict_Values = false;

            // Add an event on the code box
            base.thisCodeBox.Leave += thisCodeBox_Leave;
		}

        void thisCodeBox_Leave(object sender, EventArgs e)
        {
            if (thisCodeBox.Text.Length > 0)
            {
                string new_code = thisCodeBox.Text.ToUpper();
                if (new_code != last_code)
                {
                    // Look for a statement to use
                    foreach (Aggregation_Info thisInstitution in MetaTemplate_UserSettings.Institutions_List)
                    {
                        if (String.Compare(new_code, thisInstitution.Code, true) == 0)
                        {
                            base.thisStatementBox.Text = thisInstitution.Name;
                            break;
                        }
                    }

                    last_code = new_code;
                }
            }
            else
            {
                last_code = String.Empty;
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "holding_complex";
        }

		protected override void Inner_Read_Data(XmlTextReader xmlReader)
		{
			string default_value = String.Empty;
			while ( xmlReader.Read() )
			{
				if (( xmlReader.NodeType == XmlNodeType.Element ) && (( xmlReader.Name.ToLower() == "code" ) || ( xmlReader.Name.ToLower() == "options" ) || ( xmlReader.Name.ToLower() == "statement"))) 
				{
					if ( xmlReader.Name.ToLower() == "code" )
					{
						xmlReader.Read();
						default_value = xmlReader.Value.Trim();
					}

					if ( xmlReader.Name.ToLower() == "statement" )
					{
						xmlReader.Read();
						thisStatementBox.Text = xmlReader.Value.Trim();
					}

					if ( xmlReader.Name.ToLower() == "options" )
					{
						xmlReader.Read();
						string options = xmlReader.Value.Trim();
						thisCodeBox.Items.Clear();
						if ( options.Length > 0 )
						{
							string[] options_parsed = options.Split(",".ToCharArray());
							foreach( string thisOption in options_parsed )
							{
								if ( !thisCodeBox.Items.Contains( thisOption.Trim() ))
								{
									thisCodeBox.Items.Add( thisOption.Trim() );
								}
							}
						}
					}

					if ( xmlReader.Name.ToLower() == "html" )
					{
						xmlReader.Read();
						html = xmlReader.Value.Trim();
					}
				}
			}

			// Set the value if there was one
			if ( default_value.Length > 0 )
			{	
				thisCodeBox.Text = default_value;
				readonlyCodeBox.Text = default_value;
			}
		}


		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Holding Location";
					break;
				case Template_Language.Spanish:
					base.title = "Local de Almacén";
					break;
				case Template_Language.French:
					base.title = "Endroit de la Source";
					break;
				default:
					base.title = "Holding Location - unknown";
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
					base.minimum_title_length = (int) (font_size * 12);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 14);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 15);
					break;
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
            if (base.thisCodeBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Location.Holding_Name = base.thisStatementBox.Text.Trim();
                Bib.Bib_Info.Location.Holding_Code = base.thisCodeBox.Text.Trim();
            }
            else
            {
                Bib.Bib_Info.Location.Holding_Name = String.Empty;
                Bib.Bib_Info.Location.Holding_Code = String.Empty;
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                if (!thisCodeBox.Items.Contains(""))
                {
                    base.thisCodeBox.Items.Insert(0, "");
                }
            }

            if (Bib.Bib_Info.Location.Holding_Code.Length > 0)
			{
                base.thisStatementBox.Text = Bib.Bib_Info.Location.Holding_Name;
                if (!base.thisCodeBox.Items.Contains(Bib.Bib_Info.Source.Code))
                {
                    base.thisCodeBox.Items.Add(Bib.Bib_Info.Source.Code);
                }
                base.thisCodeBox.Text = Bib.Bib_Info.Location.Holding_Code;
			}

            // Save the last code, for comparison purposes
            last_code = base.thisCodeBox.Text.ToUpper();
		}
	}
}