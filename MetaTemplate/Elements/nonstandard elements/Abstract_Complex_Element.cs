#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for Abstract_Complex_Element.
	/// </summary>
	public class Abstract_Complex_Element : abstract_Element, iElement
	{
		protected TextBox abstractBox;
//		protected DrawFlat.FlatComboBox languageBox;
        protected ComboBox languageBox;
		private TextBox readonlyLanguageBox;
		protected string language_text;
		private int language_length;

		public Abstract_Complex_Element()
		{
			// Set some basic values about this type
			base.type = Element_Type.Abstract;
			base.display_subtype = "complex";

			// Set some default titles
			title = "Abstract";
			language_text = "Language";

			// Configure the language box
	//		languageBox = new FlatComboBox();
            languageBox = new ComboBox();
			languageBox.Width = 100;
			languageBox.Location = new Point( 115, 5 );
			languageBox.TextChanged +=languageBox_TextChanged;
            languageBox.ForeColor = Color.MediumBlue;
            languageBox.Enter += comboBox_Enter;
            languageBox.Leave += comboBox_Leave;
			Controls.Add( languageBox );
			
			// Configure the code box, but leave it hidden
			readonlyLanguageBox = new TextBox();
			readonlyLanguageBox.Location = languageBox.Location;
			readonlyLanguageBox.Width = 100;
			readonlyLanguageBox.Hide();
			readonlyLanguageBox.BackColor = Color.WhiteSmoke;
			readonlyLanguageBox.ReadOnly = true;
            readonlyLanguageBox.ForeColor = Color.MediumBlue;
            readonlyLanguageBox.Enter += textBox_Enter;
            readonlyLanguageBox.Leave += textBox_Leave;
			Controls.Add( readonlyLanguageBox );

			// Configure the text box
			abstractBox = new TextBox();
			abstractBox.Multiline = true;
			abstractBox.Height =  80;
			abstractBox.Location = new Point( 115, 35 );
            abstractBox.TextChanged += abstractBox_TextChanged;
            abstractBox.ForeColor = Color.MediumBlue;
            abstractBox.Enter += textBox_Enter;
            abstractBox.Leave += textBox_Leave;
			Controls.Add( abstractBox );

			// Add the default languages to the language box
			languageBox.Items.Add( "English" );
			languageBox.Items.Add( "French" );
			languageBox.Items.Add( "Spanish" );

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                languageBox.FlatStyle = FlatStyle.Flat;
                abstractBox.BorderStyle = BorderStyle.FixedSingle;
                readonlyLanguageBox.BorderStyle = BorderStyle.FixedSingle;
            }
		}

        void comboBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.White;
            }
        }

        void comboBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.Khaki;
            }
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "abstract_language";
        }

		/// <summary> Override the OnPaint method to draw the title before the text box </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the title
			base.Draw_Title( e.Graphics, title );

			// Draw the smaller titles
			Font smallerFont = new Font( Font.FontFamily, Font.SizeInPoints - 1 );

			// Draw the languagse subtitle
			e.Graphics.DrawString( language_text + ":", smallerFont, new SolidBrush( Color.Black ), base.title_length + 5, 9 );

			// Determine the y-mid-point
			int midpoint = (int) (1.5 * Font.SizeInPoints );

			// If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22 - Help_Button_Width, midpoint - 6);

			// Call this for the base
			base.OnPaint (e);
		}

		private void position_boxes()
		{
			// Set the spot for the language box
			int language_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( language_length ));
			languageBox.Location = new Point( base.title_length + language_spot + 5, languageBox.Location.Y );
			readonlyLanguageBox.Location = languageBox.Location;

			// Set the spot for the abstract text box
			abstractBox.Width = Width - 30 - base.title_length - Help_Button_Width;
			abstractBox.Location = new Point( base.title_length, abstractBox.Location.Y );
		}

		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReader )
		{
			string default_value = String.Empty;
			while ( xmlReader.Read() )
			{
				if (( xmlReader.NodeType == XmlNodeType.Element ) && (( xmlReader.Name.ToLower() == "code" ) || ( xmlReader.Name.ToLower() == "options" ) || ( xmlReader.Name.ToLower() == "statement"))) 
				{
					if ( xmlReader.Name.ToLower() == "language" )
					{
						xmlReader.Read();
						default_value = xmlReader.Value.Trim();
					}

					if ( xmlReader.Name.ToLower() == "options" )
					{
						xmlReader.Read();
						string options = xmlReader.Value.Trim();
						languageBox.Items.Clear();
						if ( options.Length > 0 )
						{
							string[] options_parsed = options.Split(",".ToCharArray());
							foreach( string thisOption in options_parsed )
							{
								if ( !languageBox.Items.Contains( thisOption.Trim() ))
								{
									languageBox.Items.Add( thisOption.Trim() );
								}
							}
						}
					}
				}
			}

			// Set the value if there was one
			if ( default_value.Length > 0 )
			{	
				languageBox.Text = default_value;
			}
		}

		/// <summary> Writes the inner data into Template XML format </summary>
		protected override string Inner_Write_Data( )
		{
			return String.Empty;
		}

		/// <summary> Perform any height setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Height( float new_size )
		{
			// Set total height
			int size_int = (int) new_size;

			// Now, set the location for the second line text boxes
			abstractBox.Location = new Point( abstractBox.Location.X, 5 + size_int + 20 );

            Height = abstractBox.Height + abstractBox.Location.Y + 10;
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
			position_boxes();
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				abstractBox.ReadOnly = true;
				languageBox.Enabled = false;
				languageBox.Hide();
				readonlyLanguageBox.Show();
				languageBox.BackColor = Color.WhiteSmoke;
			}
			else
			{
				abstractBox.ReadOnly = false;
				languageBox.Enabled = true;
				languageBox.Show();
				readonlyLanguageBox.Hide();
				languageBox.BackColor = Color.White;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			// Get the new element
			Abstract_Complex_Element newElement = (Abstract_Complex_Element) Element_Factory.getElement( Type, Display_SubType );
			newElement.Location = Location;
			newElement.Language = Language;
			newElement.Title_Length = Title_Length;
			newElement.Font = Font;
			newElement.Set_Width( Width );
			newElement.Height = Height;
			newElement.Index = Index + 1;
			return newElement;
		}

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					title = "Abstract";
					language_text = "Language";
					language_length = 70;
					break;
				case Template_Language.Spanish:
					title = "Resumen";
					language_text = "Idioma";
					language_length = 50;
					break;
				case Template_Language.French:
					title = "Résumé";
					language_text = "Langue";
					language_length = 70;
					break;
				default:
					title = "Abstract - unknown";
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
					base.minimum_title_length = (int) (font_size * 7);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 8);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 7);
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
			return true;
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			Bib.Bib_Info.Clear_Abstracts();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( abstractBox.Text.Trim().Length > 0 )
			{
				Bib.Bib_Info.Add_Abstract(abstractBox.Text.Trim(), languageBox.Text.Trim() );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.Abstracts_Count )
			{
				abstractBox.Text = Bib.Bib_Info.Abstracts[ base.Index ].Abstract_Text;
				languageBox.Text = Bib.Bib_Info.Abstracts[ base.Index ].Language;
			}
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				if ( abstractBox.Text.Trim().Length > 0 )
					return true;
				else
					return false;
			}
		}

		#endregion

		private void languageBox_TextChanged(object sender, EventArgs e)
		{
			readonlyLanguageBox.Text = languageBox.Text;
            base.OnDataChanged();
		}

        private void abstractBox_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }
	}
}
