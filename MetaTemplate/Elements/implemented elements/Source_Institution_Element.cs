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

// THIS FILE CONTAINS BOTH CLASSES FOR SOURCE INSTITUTION:
//		Source_Simple_Element : simpleTextBox_Element
//		Source_Complex_Element : codeStatement_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the source institution statement of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Source_Simple_Element : simpleTextBox_Element
	{
		/// <summary> Constructor for a new Source_Simple_Element, used in the metadata
		/// template to display and allow the user to edit the source institution statement of a 
		/// bibliographic package. </summary>
		public Source_Simple_Element( ) : base( "Source Institution" )
		{
			// Set the type of this object
            base.type = Element_Type.Source_Institution;
			base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "source_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Source Institution";
					break;
				case Template_Language.Spanish:
					base.title = "Fuente";
					break;
				case Template_Language.French:
					base.title = "Établissement De Source";
					break;
				default:
					base.title = "Source Institution - unknown";
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
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 17);
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
			Bib.Bib_Info.Source.Statement = base.thisBox.Text.Trim();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			base.thisBox.Text = Bib.Bib_Info.Source.Statement;
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the source institution (both code and statement) of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="codeStatement_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Source_Complex_Element : codeStatement_Element
	{
        private bool isProject;
        private string last_code;

		/// <summary> Constructor for a new Source_Complex_Element, used in the metadata
		/// template to display and allow the user to edit the source institution (both code
		/// and statement) of a bibliographic package. </summary>
		public Source_Complex_Element( ) : base( "Source Institution" )
		{
			// Set the type of this object
            base.type = Element_Type.Source_Institution;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = true;
            last_code = String.Empty;

			// Add elements to the combo box
            foreach( Aggregation_Info thisInstitution in MetaTemplate_UserSettings.Institutions_List )
            {
                thisCodeBox.Items.Add(thisInstitution.Code);
            }

			// Set the code box to accept any value
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
            return "source_complex";
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
					base.title = "Source Institution";
					break;
				case Template_Language.Spanish:
					base.title = "Fuente";
					break;
				case Template_Language.French:
					base.title = "Établissement De Source";
					break;
				default:
					base.title = "Source Institution - unknown";
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
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 17);
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
                Bib.Bib_Info.Source.Statement = base.thisStatementBox.Text.Trim();
                Bib.Bib_Info.Source.Code = base.thisCodeBox.Text.Trim();
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
                isProject = true;
            }
            else
            {
                isProject = false;
            }

            base.thisStatementBox.Text = Bib.Bib_Info.Source.Statement;
			if ( Bib.Bib_Info.Source.Code.Length > 0 )
			{
                if (!base.thisCodeBox.Items.Contains(Bib.Bib_Info.Source.Code))
                {
                    base.thisCodeBox.Items.Add(Bib.Bib_Info.Source.Code);
                }
				base.thisCodeBox.Text = Bib.Bib_Info.Source.Code;
			}

            // Save the last code, for comparison purposes
            last_code = base.thisCodeBox.Text.ToUpper();
		}

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                if (isProject)
                    return true;

                if ((thisCodeBox.Text.Trim().Length > 0) || (thisStatementBox.Text.Trim().Length > 0))
                    return true;
                else
                    return false;
            }
        }

        /// <summary> Checks the data in this element for validity. </summary>
        /// <returns> TRUE if valid, otherwise FALSE </returns>
        /// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
        public override bool isValid()
        {
            return true;
        }
	}
}