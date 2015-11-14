#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the language of a bibliographic resource.</summary>
	/// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Language_Element : comboBox_Element
	{

        private DataSet language_data;

		/// <summary> Constructor for a new Language_Element, used in the metadata
		/// template to display and allow the user to edit the language of a 
		/// bibliographic package. </summary>
		public Language_Element( ) : base( "Language" )
		{
			// Set the type of this object
			base.type = Element_Type.Language;

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			base.maximum_input_length = 350;
            base.thisBox.Sorted = false;

			// Add the types to this box
            base.thisBox.Items.Add("");
			base.thisBox.Items.Add( "English" );
			base.thisBox.Items.Add( "French" );
			base.thisBox.Items.Add( "Spanish" );
            base.thisBox.DropDownStyle = ComboBoxStyle.DropDown;
            base.thisBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            base.thisBox.AutoCompleteSource = AutoCompleteSource.ListItems;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "language";
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Language_Element newElement = (Language_Element)Element_Factory.getElement(Type, Display_SubType);
            newElement.Location = Location;
            newElement.Language = Language;
            newElement.Title_Length = Title_Length;
            newElement.Height = Height;
            newElement.Font = Font;
            newElement.Set_Width(Width);
            newElement.Index = Index + 1;

            // Copy the combo box specific values
//            newElement.Restrict_Values = this.Restrict_Values;
            foreach (string thisItem in thisBox.Items)
            {
                newElement.Add_Item(thisItem);
            }

            return newElement;
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Language";
                    load_language_options(0);
					break;
				case Template_Language.Spanish:
					base.title = "Idioma";
                    load_language_options(1);
					break;
				case Template_Language.French:
					base.title = "Langue";
                    load_language_options(2);
					break;
				default:
					base.title = "Language - unknown";
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
					base.minimum_title_length = (int) (font_size * 6);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 6);
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
			Bib.Bib_Info.Clear_Languages();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
                string mets_language = thisBox.Text;
                if (language_data != null)
                {
                    DataRow[] languages = language_data.Tables[0].Select("English='" + mets_language + "' or Spanish='" + mets_language + "' or French='" + mets_language + "'");
                    if (languages.Length > 0)
                    {
                        mets_language = languages[0][0].ToString();
                    }
                }

                Bib.Bib_Info.Add_Language( mets_language );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( Bib.Bib_Info.Languages.Count > base.index )
			{
                string mets_language = String.Empty;
                int text_index = -1;
                for (int i = 0; i < Bib.Bib_Info.Languages.Count; i++)
                {
                    if (Bib.Bib_Info.Languages[i].Language_Text.Length > 0)
                    {
                        text_index++;
                        if (text_index == base.index)
                        {
                            mets_language = Bib.Bib_Info.Languages[i].Language_Text;
                            break;
                        }
                    }
                }

                if (language_data != null)
                {
                    DataRow[] languages = language_data.Tables[0].Select("English='" + mets_language + "' or Spanish='" + mets_language + "' or French='" + mets_language + "'");
                    if (languages.Length > 0)
                    {
                        if (base.language == Template_Language.English)
                            thisBox.Text = languages[0][0].ToString();
                        if (base.language == Template_Language.Spanish)
                            thisBox.Text = languages[0][1].ToString();
                        if (base.language == Template_Language.French)
                            thisBox.Text = languages[0][2].ToString();
                    }
                    else
                    {
                        if (!base.thisBox.Items.Contains(mets_language))
                            base.thisBox.Items.Add(mets_language);
                        base.thisBox.Text = mets_language;
                    }
                }
                else
                {
                    base.thisBox.Text = mets_language;
                }
			}
		}


        /// <summary> Reads the inner data from the Template XML format </summary>
        protected override void Inner_Read_Data(XmlTextReader xmlReader)
        {
            string default_value = String.Empty;
            string data_source_file = String.Empty;
            while (xmlReader.Read())
            {
                // Perform the standard VALUE and OPTION check
                if ((xmlReader.NodeType == XmlNodeType.Element) && ((xmlReader.Name.ToLower() == "value") || (xmlReader.Name.ToLower() == "options")))
                {
                    if (xmlReader.Name.ToLower() == "value")
                    {
                        xmlReader.Read();
                        default_value = xmlReader.Value.Trim();
                    }
                    else
                    {
                        xmlReader.Read();
                        string options = xmlReader.Value.Trim();
                        thisBox.Items.Clear();
                        base.thisBox.Items.Add("");
                        thisBox.Items.Add("English");
                        thisBox.Items.Add("French");
                        thisBox.Items.Add("Spanish");
                        if (options.Length > 0)
                        {
                            string[] options_parsed = options.Split(",".ToCharArray());
                            foreach (string thisOption in options_parsed)
                            {
                                if (!thisBox.Items.Contains(thisOption.Trim()))
                                {
                                    thisBox.Items.Add(thisOption.Trim());
                                }
                            }
                        }
                    }
                }

                // Also look for the SOURCE_XML tage
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name.ToLower() == "source_xml"))
                {
                    xmlReader.Read();
                    data_source_file = xmlReader.Value.Trim();
                }
            }

            // Set the value if there was one
            if (default_value.Length > 0)
            {
                thisBox.Text = default_value;
            }

            try
            {

                // Load the data source file
                if ((data_source_file.Length > 0) && (File.Exists(Application.StartupPath + "\\" + data_source_file)))
                {
                    try
                    {
                        language_data = new DataSet();
                        FileStream reader = new FileStream(Application.StartupPath + "\\" + data_source_file, FileMode.Open, FileAccess.Read);
                        language_data.ReadXml(reader);
                    }
                    catch (Exception ee)
                    {

                    }
                }
            }
            catch
            { }
        }

        private void load_language_options(int column)
        {
            // Save the previous language
            string currentLanguage = thisBox.Text;

            // Fill with the new possible values
            if (language_data != null)
            {
                thisBox.Items.Clear();
                base.thisBox.Items.Add("");
                thisBox.Items.Add("English");
                thisBox.Items.Add("French");
                thisBox.Items.Add("Spanish");
                foreach (DataRow thisRow in language_data.Tables[0].Rows)
                {
                    thisBox.Items.Add(thisRow[column].ToString());
                }

                // If there was a language before, show it now
                if (currentLanguage.Length > 0)
                {
                    DataRow[] languages = language_data.Tables[0].Select("English='" + currentLanguage + "' or Spanish='" + currentLanguage + "' or French='" + currentLanguage + "'");
                    if (languages.Length > 0)
                    {
                        thisBox.Text = languages[0][column].ToString();
                    }
                }
            }
        }
	}
}