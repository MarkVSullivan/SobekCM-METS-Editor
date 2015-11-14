#region Using directives

using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

// THIS FILE CONTAINS BOTH CLASSES FOR SPATIAL KEYWORDS
//		Spatial_Simple_Element : simpleTextBox_Element
//		Spatial_Complex_Element : keywordScheme_Element

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit a spatial subject (but not specify scheme) of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="simpleTextBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Spatial_Simple_Element : simpleTextBox_Element
	{
        private bool dublinCore;

		/// <summary> Constructor for a new Spatial_Simple_Element, used in the metadata
		/// template to display and allow the user to edit a spatial subject (but not 
		/// specify scheme) of a bibliographic package. </summary>
        /// <param name="Dublin_Core"> Flag indicates if this is being used in a dublin core template which generally only affects the label displayed </param>
        public Spatial_Simple_Element(bool Dublin_Core )
            : base("Spatial Subject")
		{
            // Save the parameter
            dublinCore = Dublin_Core;

			// Set the type of this object
			base.type = Element_Type.Spatial;
			base.display_subtype = "simple";
            if (Dublin_Core)
                base.display_subtype = "dublincore";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

			base.maximum_input_length = 475;
		}

        public bool Is_Dublin_Core
        {
            get
            {
                return dublinCore;
            }
            set
            {
                dublinCore = value;
                if (value)
                    base.display_subtype = "dublincore";
                else
                    base.display_subtype = "simple";
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Spatial_Simple_Element newElement = (Spatial_Simple_Element)Element_Factory.getElement(Type, Display_SubType);
            newElement.Location = Location;
            newElement.Language = Language;
            newElement.Title_Length = Title_Length;
            newElement.Lines = Lines;
            newElement.Height = Height;
            newElement.Font = Font;
            newElement.Set_Width(Width);
            newElement.Index = Index + 1;
            newElement.Inner_Set_Height(Font.SizeInPoints);
            newElement.Is_Dublin_Core = Is_Dublin_Core;
            return newElement;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "spatial_simple";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
                    if (!dublinCore)
                        base.title = "Geographic Coverage";
                    else
                        base.title = "Coverage";
					break;
				case Template_Language.Spanish:
                    if (!dublinCore)
                        base.title = "Sujeto Geográfico";
                    else
                        base.title = "Coverage";
                    break;
				case Template_Language.French:
                    if (!dublinCore)
                        base.title = "Sujet Géographique";
                    else
                        base.title = "Coverage";
                    break;
				default:
					base.title = "Geographic Coverage - unknown";
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
    					base.minimum_title_length = (int) (font_size * 15);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
					break;
				case Template_Language.Spanish:
                    if (!dublinCore)
					    base.minimum_title_length = (int) (font_size * 13);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
                    break;
				case Template_Language.French:
                    if (!dublinCore)
					    base.minimum_title_length = (int) (font_size * 14);
                    else
                        base.minimum_title_length = (int)(font_size * 9);
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
            List<Subject_Info_HierarchicalGeographic> clears = new List<Subject_Info_HierarchicalGeographic>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Hierarchical_Spatial)
                {
                    clears.Add((Subject_Info_HierarchicalGeographic)thisSubject);
                }
            }
            foreach (Subject_Info_HierarchicalGeographic clearSubject in clears)
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
                if (dublinCore)
                {
                    Subject_Info_Standard newStandard = new Subject_Info_Standard();
                    newStandard.Add_Geographic(base.thisBox.Text.Trim());
                    Bib.Bib_Info.Add_Subject(newStandard);
                }
                else
                {
                    Subject_Info_HierarchicalGeographic newSpatial = new Subject_Info_HierarchicalGeographic();
                    newSpatial.Area = base.thisBox.Text.Trim();
                    Bib.Bib_Info.Add_Subject(newSpatial);
                }
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            if (!dublinCore)
            {
                int hierarchical_index = -1;
                for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
                {
                    if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Hierarchical_Spatial)
                    {
                        hierarchical_index++;
                        if (hierarchical_index == base.index)
                        {
                            Subject_Info_HierarchicalGeographic hierSubject = (Subject_Info_HierarchicalGeographic)Bib.Bib_Info.Subjects[i];
                            base.thisBox.Text = hierSubject.Area;
                            break;
                        }
                    }
                }
            }
            else
            {
                int spatial_index = -1;
                for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
                {
                    if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Hierarchical_Spatial)
                    {
                        spatial_index++;
                        if (spatial_index == base.index)
                        {
                            Subject_Info_HierarchicalGeographic hierSubject = (Subject_Info_HierarchicalGeographic)Bib.Bib_Info.Subjects[i];
                            base.thisBox.Text = hierSubject.Area;
                            break;
                        }
                    }
                    else if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Standard)
                    {
                        Subject_Info_Standard standSubject = (Subject_Info_Standard)Bib.Bib_Info.Subjects[i];
                        if (( standSubject.Genres_Count == 0 ) && ( standSubject.Occupations_Count == 0 ) && ( standSubject.Topics_Count == 0 ))
                        {
                            spatial_index++;
                            if (spatial_index == base.index)
                            {
                                // Compute the result
                                StringBuilder builder = new StringBuilder();
                                if (standSubject.Geographics_Count > 0)
                                {
                                    foreach (string thisGeographic in standSubject.Geographics)
                                    {
                                        if (builder.Length > 0)
                                            builder.Append(" -- ");
                                        builder.Append(thisGeographic.Trim());
                                    }
                                }
                                if (standSubject.Temporals_Count > 0)
                                {
                                    foreach (string thisTemporal in standSubject.Temporals
                                        )
                                    {
                                        if (builder.Length > 0)
                                            builder.Append(" -- ");
                                        builder.Append(thisTemporal.Trim());
                                    }
                                }

                                base.thisBox.Text = builder.ToString();
                                break;
                            }
                        }
                    }
                }
            }
		}
	}

	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit spatial coverage and scheme of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Spatial_Complex_Element : keywordScheme_Element
	{
		/// <summary> Constructor for a new Spatial_Comples_Element, used in the metadata
		/// template to display and allow the user to edit spatial converage and scheme of a 
		/// bibliographic package. </summary>
		public Spatial_Complex_Element( ) : base( "Spatial Coverage" )
		{
			// Set the type of this object
			base.type = Element_Type.Spatial;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;
			base.thisSchemeBox.Width = 110;
			base.maximum_input_length = 475;
			base.scheme = "Scheme";

			// Add the schemes
			base.thisSchemeBox.Items.Add("FIPS");
			base.thisSchemeBox.Items.Add("GNIS");
			base.thisSchemeBox.Items.Add("LCSH");
			base.thisSchemeBox.Items.Add("None");
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "spatial_complex";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Geographic Coverage";
					base.scheme = "Scheme";
					base.Scheme_Length = 50;
					break;
				case Template_Language.Spanish:
					base.title = "Sujeto Geográfico";
					base.scheme = "(Scheme)";
					base.Scheme_Length = 60;
					break;
				case Template_Language.French:
					base.title = "Sujet Géographique";
					base.scheme = "(Scheme)";
					base.Scheme_Length = 60;
					break;
				default:
					base.title = "Spatial Subject - unknown";
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
					base.minimum_title_length = (int) (font_size * 15);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 13);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 14);
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
            List<Subject_Info_HierarchicalGeographic> clears = new List<Subject_Info_HierarchicalGeographic>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Hierarchical_Spatial)
                {
                    clears.Add((Subject_Info_HierarchicalGeographic)thisSubject);
                }
            }
            foreach (Subject_Info_HierarchicalGeographic clearSubject in clears)
            {
                Bib.Bib_Info.Remove_Subject(clearSubject);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            
            if (base.thisKeywordBox.Text.Trim().Length > 0)
            {
                Subject_Info_HierarchicalGeographic newSpatial = new Subject_Info_HierarchicalGeographic();
                newSpatial.Area = base.thisKeywordBox.Text.Trim();
                newSpatial.Authority = base.thisSchemeBox.Text.Trim();
                Bib.Bib_Info.Add_Subject(newSpatial);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            int hierarchical_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
            {
                if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Hierarchical_Spatial)
                {
                    hierarchical_index++;
                    if (hierarchical_index == base.index)
                    {
                        Subject_Info_HierarchicalGeographic hierSubject = (Subject_Info_HierarchicalGeographic)Bib.Bib_Info.Subjects[i];
                        base.thisKeywordBox.Text = hierSubject.Area;
                        base.thisSchemeBox.Text = hierSubject.Authority;
                        break;
                    }
                }
            }
		}
	}
}
