#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for Title_Panel_Element.
	/// </summary>
	public class Title_Panel_Element : abstract_Element, iElement
    {
        #region Series_Title_Element definition ( previously a public class, now private )

        /// <summary> Object used in the metadata template to display and allow the user 
	    /// to edit the series title of a bibliographic package.</summary>
	    /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	    /// Written by Mark Sullivan ( 2006 ).</remarks>
        private class Series_Title_Element : simpleTextBox_Element
        {
            /// <summary> Constructor for a new Series_Title_Element, used in the metadata
            /// template to display and allow the user to edit the series title of a 
            /// bibliographic package. </summary>
            public Series_Title_Element()
                : base("Series Title")
            {
                // Set the type of this object
                base.type = Element_Type.Title_Other;

                // Set some immutable characteristics
                always_single = true;
                always_mandatory = false;
            }

            /// <summary> Returns the HTML URL Stub </summary>
            /// <returns></returns>
            public override string Help_URL()
            {
                return "title_panel";
            }

            /// <summary> Sets the language to use for the user interface on this element. </summary>
            /// <remarks> Sets the text for the label according to language </remarks>
            protected override void Inner_Set_Language(Template_Language newLanguage)
            {
                switch (newLanguage)
                {
                    case Template_Language.English:
                        base.title = "Series Title";
                        break;
                    case Template_Language.Spanish:
                        base.title = "T�tulo De la Serie";
                        break;
                    case Template_Language.French:
                        base.title = "Titre De S�rie";
                        break;
                    default:
                        base.title = "Series Title - unknown";
                        break;
                }
            }

            /// <summary> Set the minimum title length specific to the 
            /// implementation of abstract_Element.  </summary>
            /// <param name="size"> Height of the font </param>
            protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
            {
                // Get the size of the font
                float font_size = 10.0F;

                font_size = Font.SizeInPoints;

                // Set the title lengths;
                switch (current_language)
                {
                    case Template_Language.English:
                        base.minimum_title_length = (int)(font_size * 9);
                        break;
                    case Template_Language.Spanish:
                        base.minimum_title_length = (int)(font_size * 12);
                        break;
                    case Template_Language.French:
                        base.minimum_title_length = (int)(font_size * 11);
                        break;
                    default:
                        base.minimum_title_length = (int)(font_size * 10);
                        break;
                }
            }

            /// <summary> Prepares the bib object for the save, by clearing the 
            /// existing data in this element's related field. </summary>
            /// <param name="Bib"> Existing Bib object </param>
            public override void Prepare_For_Save(SobekCM_Item Bib)
            {
                // Do nothing
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object into which to save this element's data </param>
            public override void Save_To_Bib(SobekCM_Item Bib)
            {
                Bib.Bib_Info.SeriesTitle.Title = base.thisBox.Text.Trim();
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object to populate this element from </param>
            public override void Populate_From_Bib(SobekCM_Item Bib)
            {
                base.thisBox.Text = Bib.Bib_Info.SeriesTitle.Title;
            }
        }

        #endregion

        #region Translated_Title_Element definition ( previously a public class, now private )

        /// <summary> Object used in the metadata template to display and allow the user 
        /// to edit a translated title of a bibliographic package.</summary>
        /// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
        /// Written by Mark Sullivan ( 2006 ).</remarks>
        private class Translated_Title_Element : keywordScheme_Element
        {
            /// <summary> Constructor for a new Translated_Title_Element, used in the metadata
            /// template to display and allow the user to edit a translated title of a 
            /// bibliographic package. </summary>
            public Translated_Title_Element()
                : base("Alternate Title")
            {
                // Set the type of this object
                base.type = Element_Type.Title_Other;
                base.display_subtype = "complex";

                // Set some immutable characteristics
                always_single = false;
                always_mandatory = false;
                base.thisSchemeBox.Width = 100;

                // Add the schemes
                base.Scheme_Length = 60;
                base.scheme = "Language";
                base.thisSchemeBox.Items.Add("English");
                base.thisSchemeBox.Items.Add("French");
                base.thisSchemeBox.Items.Add("Spanish");
            }

            public override string Help_URL()
            {
                return "title_panel";
            }

            /// <summary> Sets the language to use for the user interface on this element. </summary>
            /// <remarks> Sets the text for the label according to language </remarks>
            protected override void Inner_Set_Language(Template_Language newLanguage)
            {
                switch (newLanguage)
                {
                    case Template_Language.English:
                        base.title = "Alternate Title";
                        base.scheme = "Language";
                        break;
                    case Template_Language.Spanish:
                        base.title = "T�tulo Alterno";
                        base.scheme = "Idioma";
                        break;
                    case Template_Language.French:
                        base.title = "Titre Alternatif";
                        base.scheme = "Langue";
                        break;
                    default:
                        base.title = "Alternate Title - unknown";
                        base.scheme = "Language";
                        break;
                }
            }

            /// <summary> Set the minimum title length specific to the 
            /// implementation of abstract_Element.  </summary>
            /// <param name="size"> Height of the font </param>
            protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
            {
                // Get the size of the font
                float font_size = 10.0F;

                font_size = Font.SizeInPoints;

                // Set the title length
                switch (current_language)
                {
                    case Template_Language.English:
                        base.minimum_title_length = (int)(font_size * 11);
                        break;
                    case Template_Language.Spanish:
                        base.minimum_title_length = (int)(font_size * 10);
                        break;
                    case Template_Language.French:
                        base.minimum_title_length = (int)(font_size * 11);
                        break;
                    default:
                        base.minimum_title_length = (int)(font_size * 10);
                        break;
                }
            }

            /// <summary> Prepares the bib object for the save, by clearing the 
            /// existing data in this element's related field. </summary>
            /// <param name="Bib"> Existing Bib object </param>
            public override void Prepare_For_Save(SobekCM_Item Bib)
            {
                List<Title_Info> clears = new List<Title_Info>();
                foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
                {
                    if ((thisTitle.Title_Type == Title_Type_Enum.alternative) || (thisTitle.Title_Type == Title_Type_Enum.translated))
                    {
                        clears.Add(thisTitle);
                    }
                }
                foreach (Title_Info clearTitle in clears)
                {
                    Bib.Bib_Info.Remove_Other_Title(clearTitle);
                }
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object into which to save this element's data </param>
            public override void Save_To_Bib(SobekCM_Item Bib)
            {
                if (base.thisKeywordBox.Text.Trim().Length > 0)
                {
                    if (base.thisSchemeBox.Text.Trim().Length > 0)
                    {
                        Bib.Bib_Info.Add_Other_Title(base.thisKeywordBox.Text, Title_Type_Enum.translated).Language = base.thisSchemeBox.Text.Trim();
                    }
                    else
                    {
                        Bib.Bib_Info.Add_Other_Title(base.thisKeywordBox.Text, Title_Type_Enum.alternative);
                    }
                }
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object to populate this element from </param>
            public override void Populate_From_Bib(SobekCM_Item Bib)
            {
                int title_index = -1;
                for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
                {
                    if ((Bib.Bib_Info.Other_Titles[i].Title_Type == Title_Type_Enum.alternative) || (Bib.Bib_Info.Other_Titles[i].Title_Type == Title_Type_Enum.translated))
                    {
                        title_index++;
                        if (title_index == base.index)
                        {
                            base.thisKeywordBox.Text = Bib.Bib_Info.Other_Titles[i].ToString();
                            base.thisSchemeBox.Text = Bib.Bib_Info.Other_Titles[i].Language;
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region Uniform_Title_Element definition ( previously a public class, now private )

        /// <summary> Object used in the metadata template to display and allow the user 
        /// to edit the uniform title of a bibliographic package.</summary>
        /// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
        /// Written by Mark Sullivan ( 2006 ).</remarks>
        private class Uniform_Title_Element : simpleTextBox_Element
        {
            /// <summary> Constructor for a new Uniform_Title_Element, used in the metadata
            /// template to display and allow the user to edit the uniform title of a 
            /// bibliographic package. </summary>
            public Uniform_Title_Element()
                : base("Uniform Title")
            {
                // Set the type of this object
                base.type = Element_Type.Title_Other;

                // Set some immutable characteristics
                always_single = true;
                always_mandatory = false;
            }


            /// <summary> Returns the HTML URL Stub </summary>
            /// <returns></returns>
            public override string Help_URL()
            {
                return "title_panel";
            }

            /// <summary> Sets the language to use for the user interface on this element. </summary>
            /// <remarks> Sets the text for the label according to language </remarks>
            protected override void Inner_Set_Language(Template_Language newLanguage)
            {
                switch (newLanguage)
                {
                    case Template_Language.English:
                        base.title = "Uniform Title";
                        break;
                    case Template_Language.Spanish:
                        base.title = "T�tulo Uniforme";
                        break;
                    case Template_Language.French:
                        base.title = "Titre Uniforme";
                        break;
                    default:
                        base.title = "Series Title - unknown";
                        break;
                }
            }

            /// <summary> Set the minimum title length specific to the 
            /// implementation of abstract_Element.  </summary>
            /// <param name="size"> Height of the font </param>
            protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
            {
                // Get the size of the font
                float font_size = 10.0F;

                font_size = Font.SizeInPoints;

                // Set the title lengths;
                switch (current_language)
                {
                    case Template_Language.English:
                        base.minimum_title_length = (int)(font_size * 10);
                        break;
                    case Template_Language.Spanish:
                        base.minimum_title_length = (int)(font_size * 11);
                        break;
                    case Template_Language.French:
                        base.minimum_title_length = (int)(font_size * 11);
                        break;
                    default:
                        base.minimum_title_length = (int)(font_size * 10);
                        break;
                }
            }

            /// <summary> Prepares the bib object for the save, by clearing the 
            /// existing data in this element's related field. </summary>
            /// <param name="Bib"> Existing Bib object </param>
            public override void Prepare_For_Save(SobekCM_Item Bib)
            {
                List<Title_Info> clears = new List<Title_Info>();
                foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
                {
                    if (thisTitle.Title_Type == Title_Type_Enum.uniform)
                    {
                        clears.Add(thisTitle);
                    }
                }
                foreach (Title_Info clearTitle in clears)
                {
                    Bib.Bib_Info.Remove_Other_Title(clearTitle);
                }
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object into which to save this element's data </param>
            public override void Save_To_Bib(SobekCM_Item Bib)
            {
                if (base.thisBox.Text.Trim().Length > 0)
                {
                    Bib.Bib_Info.Add_Other_Title(base.thisBox.Text, Title_Type_Enum.uniform);
                }
            }

            /// <summary> Saves the data stored in this instance of the 
            /// element to the provided bibliographic object </summary>
            /// <param name="Bib"> Object to populate this element from </param>
            public override void Populate_From_Bib(SobekCM_Item Bib)
            {
                foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
                {
                    if (thisTitle.Title_Type == Title_Type_Enum.uniform)
                    {
                        base.thisBox.Text = thisTitle.ToString();
                    }
                }
            }
        }

        #endregion

        private Element_Collection alternateTitles;
		private Title_Element titleElement;
		private Uniform_Title_Element uniformElement;
		private Series_Title_Element seriesElement;

		private string add_alternate = "Add Alternate Title";
		private string add_uniform = "Add Uniform Title";
		private string add_series = "Add Series Title";

		private bool first_link_active;
		private bool second_link_active;
		private bool third_link_active;

		public Title_Panel_Element()
		{
			alternateTitles = new Element_Collection();

			// Set the type of this object
			base.type = Element_Type.Title;
			base.display_subtype = "panel";

			// Set some immutable characteristics
			always_single = true;
			always_mandatory = false;

			// Create the title element
			titleElement = new Title_Element();
			titleElement.Location = new Point( 0, 0 );
			titleElement.Set_Font( Font );
			titleElement.Help_Requested +=subElement_Help_Requested;
            titleElement.Data_Changed += titleElement_Data_Changed;
			Controls.Add( titleElement );

			title = "Titles";
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "title_panel";
        }

        void titleElement_Data_Changed(abstract_Element thisElement)
        {
            base.OnDataChanged();
        }

		protected override void OnFontChanged(EventArgs e)
		{
			titleElement.Set_Font( Font );
			if ( uniformElement != null )
				uniformElement.Set_Font( Font );
			if ( seriesElement != null )
				seriesElement.Set_Font( Font );
			foreach( abstract_Element thisElement in alternateTitles )
				thisElement.Set_Font( Font );
		}


        protected override void OnPaint(PaintEventArgs e)
        {

            // Add the text for adding new types
            Font smallerFont = new Font(Font.FontFamily, Font.SizeInPoints - 1);
            Brush non_active_brush = new SolidBrush(Color.Black);
            if (read_only)
            {
                non_active_brush = new SolidBrush(SystemColors.InactiveCaptionText);
            }

            int x_location = 130;

            // Draw the alternate text
            if (first_link_active)
            {
                e.Graphics.DrawString(add_alternate, new Font(smallerFont, FontStyle.Underline), new SolidBrush(Color.Blue), x_location, Height - 25);
            }
            else
            {
                e.Graphics.DrawString(add_alternate, smallerFont, non_active_brush, x_location, Height - 25);
            }

            // Add the series title text
            if (seriesElement == null)
            {
                x_location += 130;
                if (second_link_active)
                {
                    e.Graphics.DrawString(add_series, new Font(smallerFont, FontStyle.Underline), new SolidBrush(Color.Blue), x_location, Height - 25);
                }
                else
                {
                    e.Graphics.DrawString(add_series, smallerFont, non_active_brush, x_location, Height - 25);
                }
            }

            // Add the uniform title text
            if (uniformElement == null)
            {
                x_location += 130;
                if (((seriesElement != null) && (second_link_active)) ||
                    ((seriesElement == null) && (third_link_active)))
                {
                    e.Graphics.DrawString(add_uniform, new Font(smallerFont, FontStyle.Underline), new SolidBrush(Color.Blue), x_location, Height - 25);
                }
                else
                {
                    e.Graphics.DrawString(add_uniform, smallerFont, non_active_brush, x_location, Height - 25);
                }
            }
            // Call the base onpaint
            base.OnPaint(e);
        }





		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReader )
		{

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
			int total_height = 30 + titleElement.Height;
			
			if ( uniformElement != null )
			{
				total_height += 5 + uniformElement.Height;
			}

			if ( seriesElement != null )
			{
				total_height += 5 + seriesElement.Height;
			}

			foreach( abstract_Element thisElement in alternateTitles )
			{
				total_height += 5 + thisElement.Height;
			}

			Height = total_height;
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
			Width = new_width;
			titleElement.Set_Width( new_width );
			if ( uniformElement != null )
				uniformElement.Set_Width( new_width );
			if ( seriesElement != null )
				seriesElement.Set_Width( new_width );
			foreach( abstract_Element thisElement in alternateTitles )
				thisElement.Set_Width( new_width );
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				titleElement.Read_Only = true;
				if ( uniformElement != null )
					uniformElement.Read_Only = true;
				if ( seriesElement != null )
					seriesElement.Read_Only = true;
				foreach( abstract_Element thisElement in alternateTitles )
					thisElement.Read_Only = true;
			}
			else
			{
				titleElement.Read_Only = false;
				if ( uniformElement != null )
					uniformElement.Read_Only = false;
				if ( seriesElement != null )
					seriesElement.Read_Only = false;
				foreach( abstract_Element thisElement in alternateTitles )
					thisElement.Read_Only = false;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			return null;
		}

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			// Change the text on the links to add new types of titles
			switch( newLanguage )
			{
				case Template_Language.English:
					add_alternate = "Add Alternate Title";
					add_uniform = "Add Uniform Title";
					add_series = "Add Series Title";
					title = "Title";
					break;

				case Template_Language.Spanish:
					add_alternate = "Agregar T�tulo Alterno";
					add_uniform = "Agregar T�tulo Uniforme";
					add_series = "Agregar T�tulo De la Serie";
					title = "T�tulo";
					break;

				case Template_Language.French:
					add_alternate = "Ajouter Titre Alternatif";
					add_uniform = "Ajouter Titre Uniforme";
					add_series = "Ajouter Titre De S�rie";
					title = "Titre";
					break;

				default:
					add_alternate = "Add Alternate Title";
					add_uniform = "Add Uniform Title";
					add_series = "Add Series Title";
					title = "Title";
					break;
			}


			// Set the languages for all the child elements
			titleElement.Language = newLanguage;
			if ( uniformElement != null )
				uniformElement.Language = newLanguage;
			if ( seriesElement != null )
				seriesElement.Language = newLanguage;
			foreach( abstract_Element thisElement in alternateTitles )
				thisElement.Language = newLanguage;
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			base.minimum_title_length = 0;
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
            Bib.Bib_Info.Clear_Other_Titles();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			titleElement.Save_To_Bib( Bib );
			if ( uniformElement != null )
				uniformElement.Save_To_Bib( Bib );
			if ( seriesElement != null )
				seriesElement.Save_To_Bib( Bib );
			foreach( abstract_Element thisElement in alternateTitles )
				thisElement.Save_To_Bib( Bib );
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			// Make sure the right number of title elements are showing for each type.
            foreach (Title_Info thisTitle in Bib.Bib_Info.Other_Titles)
            {
                if (thisTitle.Title_Type == Title_Type_Enum.uniform)
                {
                    add_uniform_title();
                }
                if ((thisTitle.Title_Type == Title_Type_Enum.alternative) || (thisTitle.Title_Type == Title_Type_Enum.translated))
                {
                    add_alternate_title();
                }
            }
			if (( Bib.Bib_Info.SeriesTitle.Title.Trim().Length > 0 ) && ( seriesElement == null ))
			{
				add_series_title();
			}

			// Populate all the title information
			titleElement.Populate_From_Bib( Bib );
			if ( uniformElement != null )
				uniformElement.Populate_From_Bib( Bib );
			if ( seriesElement != null )
				seriesElement.Populate_From_Bib( Bib );
			foreach( abstract_Element thisElement in alternateTitles )
				thisElement.Populate_From_Bib( Bib );
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				return titleElement.hasValue;
			}
		}

		#endregion

		private void add_alternate_title()
		{
			// Add an alternate title to the alternate collection
			int line = 1;
			if ( seriesElement != null )
				line++;
			if ( uniformElement != null )
				line++;

			// Now, add the next alternate title
			Translated_Title_Element newTitle = new Translated_Title_Element();
            newTitle.Data_Changed += titleElement_Data_Changed;
			newTitle.Set_Font( Font );
			newTitle.Set_Width( Width );
			newTitle.Repeatable = false;
			newTitle.Language = Language;
			newTitle.Help_Requested +=subElement_Help_Requested;
            newTitle.Index = alternateTitles.Count;
            newTitle.Read_Only = Read_Only;
			line = line + alternateTitles.Count;
			newTitle.Location = new Point( 0, ( titleElement.Height + 5 ) * line );
			alternateTitles.Add( newTitle );
			Controls.Add( newTitle );
			Inner_Set_Height( Font.Height );
			base.OnRedrawRequested();
			Invalidate();
		}

		private void add_series_title()
		{
			// Add a series title
			int line = 1;
			seriesElement = new Series_Title_Element();
			seriesElement.Set_Font( Font );
			seriesElement.Set_Width( Width );
			seriesElement.Location = new Point( 0, titleElement.Height + 5 );
			seriesElement.Language = Language;
			seriesElement.Help_Requested +=subElement_Help_Requested;
            seriesElement.Data_Changed += titleElement_Data_Changed;
            seriesElement.Read_Only = Read_Only;
			Controls.Add( seriesElement );

			// Reposition the uniform title
			if ( uniformElement != null )
			{
				uniformElement.Location = new Point( 0, ( titleElement.Height + 5 ) * 2 );
				line = 2;
			}

			// Reposition all alternate titles
			foreach( Translated_Title_Element thisElement in alternateTitles )
			{
				line++;
				thisElement.Location = new Point( 0, ( titleElement.Height + 5 ) * line );
			}
			Inner_Set_Height( Font.Height );
			base.OnRedrawRequested();
			Invalidate();
		}

		private void add_uniform_title()
		{
			int line = 2;
			if ( seriesElement == null )
				line = 1;
			
			// Add a uniform title
			uniformElement = new Uniform_Title_Element();
			uniformElement.Set_Font( Font );
			uniformElement.Set_Width( Width );
			uniformElement.Location = new Point( 0, ( titleElement.Height + 5 ) * line );
			uniformElement.Help_Requested +=subElement_Help_Requested;
			uniformElement.Language = Language;
            uniformElement.Data_Changed += titleElement_Data_Changed;
            uniformElement.Read_Only = Read_Only;
			Controls.Add( uniformElement );

			// Reposition all alternate titles
			foreach( Translated_Title_Element thisElement in alternateTitles )
			{
				line++;
				thisElement.Location = new Point( 0, ( titleElement.Height + 5 ) * line );
			}
			
			Inner_Set_Height( Font.Height );
			base.OnRedrawRequested();
			Invalidate();
		}


		#region Mouse Listener Methods

		protected override void OnMouseDown(MouseEventArgs e)
		{
            if (!read_only)
            {
                // Was this potentially over the links
                if ((e.Y > Height - 25) && (e.Y < Height - 5))
                {
                    // Which area is this over?
                    if ((e.X > 130) && (e.X < 230))
                    {
                        add_alternate_title();
                    }
                    if ((e.X >= 260) && (e.X < 360))
                    {
                        if (seriesElement == null)
                        {
                            add_series_title();
                        }
                        else
                        {
                            add_uniform_title();
                        }
                    }
                    if ((e.X >= 390) && (e.X < 490))
                    {
                        add_uniform_title();
                    }
                }
            }

			// Call the base method
			base.OnMouseDown (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
            if (!read_only)
            {
                // Was this potentially over the links
                bool linkfound = false;
                if ((e.Y > Height - 25) && (e.Y < Height - 5))
                {
                    // Which area is this over?
                    if ((e.X > 130) && (e.X < 230))
                    {
                        linkfound = true;
                        if (!first_link_active)
                        {
                            second_link_active = false;
                            third_link_active = false;
                            first_link_active = true;
                            Invalidate();
                        }
                    }
                    if ((e.X >= 260) && (e.X < 360))
                    {
                        linkfound = true;
                        if (!second_link_active)
                        {
                            second_link_active = true;
                            third_link_active = false;
                            first_link_active = false;
                            Invalidate();
                        }
                    }
                    if ((e.X >= 390) && (e.X < 490))
                    {
                        linkfound = true;
                        if (!third_link_active)
                        {
                            second_link_active = false;
                            third_link_active = true;
                            first_link_active = false;
                            Invalidate();
                        }
                    }
                }

                if ((!linkfound) && ((first_link_active) || (second_link_active) || (third_link_active)))
                {
                    first_link_active = false;
                    second_link_active = false;
                    third_link_active = false;
                    Invalidate();
                }
            }

			// Call the base method
			base.OnMouseMove (e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			Cursor = Cursors.Arrow;

			if (( first_link_active ) || ( second_link_active ) || ( third_link_active ))
			{
				first_link_active = false;
				second_link_active = false;
				third_link_active = false;
				Invalidate();
			}

			// Call the base method
			base.OnMouseLeave (e);
		}

		#endregion

		private void subElement_Help_Requested(abstract_Element thisElement)
		{
			base.OnHelpRequested( thisElement );
		}
	}
}
