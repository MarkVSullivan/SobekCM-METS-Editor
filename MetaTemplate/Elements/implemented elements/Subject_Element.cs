#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

// THIS FILE CONTAINS BOTH CLASSES FOR SUBJBECT KEYWORDS:
//		Subject_Simple_Element : simpleTextBox_Element
//		Subject_Complex_Element : keywordScheme_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a subject (but not scheme) of a bibliographic package.</summary>
    /// <param name="Dublin_Core"> Flag indicates if this is being used in a dublin core template which generally only affects the label displayed </param>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan and his muse is Catherine ( 2006 ).</remarks>
	public class Subject_Simple_Element : simpleTextBox_Element
	{
        private bool dublinCore;
        private bool seperateSpatialExists;

		/// <summary> Constructor for a new Subject_Simple_Element, used in the metadata
		/// template to display and allow the user to edit a subject (but not scheme) of a 
		/// bibliographic package. </summary>
		public Subject_Simple_Element( bool Dublin_Core ) : base( "Subject Keyword" )
		{
            // Save the parameter
            dublinCore = Dublin_Core;

			// Set the type of this object
			base.type = Element_Type.Subject;
			base.display_subtype = "simple";
            if (Dublin_Core)
                base.display_subtype = "dublincore";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

			base.maximum_input_length = 475;
            seperateSpatialExists = false;
		}

        public bool Seperate_Dublin_Core_Spatial_Exists
        {
            get { return seperateSpatialExists; }
            set { seperateSpatialExists = value; }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Subject_Simple_Element newElement = (Subject_Simple_Element)Element_Factory.getElement(Type, Display_SubType);
            newElement.Location = Location;
            newElement.Language = Language;
            newElement.Title_Length = Title_Length;
            newElement.Lines = Lines;
            newElement.Height = Height;
            newElement.Font = Font;
            newElement.Set_Width(Width);
            newElement.Index = Index + 1;
            newElement.Inner_Set_Height(Font.SizeInPoints);
            newElement.Seperate_Dublin_Core_Spatial_Exists = Seperate_Dublin_Core_Spatial_Exists;
            return newElement;
        }


        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "subject_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
                    if (!dublinCore)
                        base.title = "Subject Keyword";
                    else
                        base.title = "Subject";
					break;
				case Template_Language.Spanish:
					base.title = "Tema";
					break;
				case Template_Language.French:
					base.title = "Sujet";
					break;
				default:
					base.title = "Subject Keyword - unknown";
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
                    if ( !dublinCore )
    					base.minimum_title_length = (int) (font_size * 12);
                    else
                        base.minimum_title_length = (int)(font_size * 7);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 5);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 5);
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
            List<Subject_Info_Standard> clears = new List<Subject_Info_Standard>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Standard) 
                {
                    clears.Add((Subject_Info_Standard)thisSubject);
                }
            }
            foreach (Subject_Info_Standard clearSubject in clears)
            {
                Bib.Bib_Info.Remove_Subject(clearSubject);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisBox.Text.Trim().Length > 0 )
			{
				Bib.Bib_Info.Add_Subject( base.thisBox.Text, String.Empty );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            int subject_index = -1;
            if (!seperateSpatialExists)
            {
                for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
                {
                    if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Standard)
                    {
                        subject_index++;
                        if (subject_index == base.index)
                        {
                            Subject_Info_Standard standSubject = (Subject_Info_Standard)Bib.Bib_Info.Subjects[i];
                            base.thisBox.Text = standSubject.ToString();
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
                {
                    if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Standard)
                    {
                        Subject_Info_Standard standSubject = (Subject_Info_Standard)Bib.Bib_Info.Subjects[i];
                        if ((standSubject.Topics_Count > 0) || (standSubject.Occupations_Count > 0) || (standSubject.Genres_Count > 0))
                        {
                            subject_index++;
                            if (subject_index == base.index)
                            {
                                base.thisBox.Text = standSubject.ToString();
                                break;
                            }
                        }
                    }
                }
            }
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a subject and scheme of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Subject_Complex_Element : keywordScheme_Element
	{
		/// <summary> Constructor for a new Subject_Comples_Element, used in the metadata
		/// template to display and allow the user to edit a subject and subject scheme of a 
		/// bibliographic package. </summary>
		public Subject_Complex_Element( ) : base( "Subject Keyword" )
		{
			// Set the type of this object
			base.type = Element_Type.Subject;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			base.thisSchemeBox.Width = 110;
			base.maximum_input_length = 475;

			// Add the schemes
            base.thisSchemeBox.Items.Add("aat");
            base.thisSchemeBox.Items.Add("fast");
			base.thisSchemeBox.Items.Add("lcsh");
            base.thisSchemeBox.Items.Add("lctgm");
            base.thisSchemeBox.Items.Add("nmc");
			base.thisSchemeBox.Items.Add("");
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "subject_scheme";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Subject Keyword";
					base.scheme = "Scheme";
					base.Scheme_Length = 50;
					break;
				case Template_Language.Spanish:
					base.title = "Tema";
                    base.scheme = "Vocabulario";
					base.Scheme_Length = 60;
					break;
				case Template_Language.French:
					base.title = "Sujet";
                    base.scheme = "Vocabulaire";
                    base.Scheme_Length = 85;
					break;
				default:
					base.title = "Subject Keyword - unknown";
					base.scheme = "Scheme";
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
					base.minimum_title_length = (int) (font_size * 5);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 5);
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
            List<Subject_Info_Standard> clears = new List<Subject_Info_Standard>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Standard)
                {
                    clears.Add((Subject_Info_Standard)thisSubject);
                }
            }
            foreach (Subject_Info_Standard clearSubject in clears)
            {
                Bib.Bib_Info.Remove_Subject(clearSubject);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if ( base.thisKeywordBox.Text.Trim().Length > 0 )
			{
				if (( base.thisSchemeBox.Text.Trim().Length > 0 ) && ( base.thisSchemeBox.Text.ToUpper().Trim() != "NONE" ))
				{
                    Bib.Bib_Info.Add_Subject(base.thisKeywordBox.Text.Trim(), base.thisSchemeBox.Text.ToLower());
				}
				else
				{
                    Bib.Bib_Info.Add_Subject(base.thisKeywordBox.Text.Trim(), String.Empty);
				}
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            int subject_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
            {
                if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Standard)
                {
                    subject_index++;
                    if (subject_index == base.index)
                    {
                        Subject_Info_Standard standSubject = (Subject_Info_Standard)Bib.Bib_Info.Subjects[i];
                        base.thisKeywordBox.Text = standSubject.ToString();
                        base.thisSchemeBox.Text = standSubject.Authority.ToLower();
                        break;
                    }
                }
            }
		}
	}
}