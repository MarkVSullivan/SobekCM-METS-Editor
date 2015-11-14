#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Object used in the metadata template to display and allow the user 
	/// to edit the type of a bibliographic package.</summary>
	/// <remarks>This class extends the <see cref="comboBox_Element"/> object.<br /><br />
	/// Written by Mark Sullivan ( 2006 ).</remarks>
	public class Type_Element : comboBox_Element
	{
        private bool collection;
	    private bool isProject = false;

		/// <summary> Constructor for a new Type_Element, used in the metadata
		/// template to display and allow the user to edit the type of a 
		/// bibliographic package. </summary>
		public Type_Element( bool Restrict_Values ) : base( "Resource Type" )
		{
			// Set the type of this object
			base.type = Element_Type.Type;
            base.display_subtype = "simple";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = true;
			base.maximum_input_length = 250;
            base.Restrict_Values = Restrict_Values;

			// Add the types to this box
            if (MetaTemplate_UserSettings.Material_Types_List.Count == 0)
            {
                base.thisBox.Items.Add("text");
                base.thisBox.Items.Add("cartographix");
                base.thisBox.Items.Add("notated music");
                base.thisBox.Items.Add("sound recording");
                base.thisBox.Items.Add("sound recording-musical");
                base.thisBox.Items.Add("sound recording-nonmusical");
                base.thisBox.Items.Add("still image");
                base.thisBox.Items.Add("moving image");
                base.thisBox.Items.Add("three dimensional object");
                base.thisBox.Items.Add("software, multimedia");
                base.thisBox.Items.Add("mixed material");
            }
            else
            {
                foreach (Material_Type_Setting thisMaterialType in MetaTemplate_UserSettings.Material_Types_List)
                {
                    base.thisBox.Items.Add(thisMaterialType.Display_Name);
                }
            }

            // Set default collection value
            collection = false;
		}

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "type";
        }

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					base.title = "Resource Type";
					break;
				case Template_Language.Spanish:
					base.title = "Tipo de Recurso";
					break;
				case Template_Language.French:
					base.title = "Type De Ressource";
					break;
				default:
					base.title = "Resource Type- unknown";
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
					base.minimum_title_length = (int) (font_size * 10);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 12);
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
			// Clear all uncontrolled types
            Bib.Bib_Info.Type.Clear_Uncontrolled_Types();

            // Clear any sobekcm genres
            List<Genre_Info> sobekcmGenres = new List<Genre_Info>();
            foreach (Genre_Info thisGenre in Bib.Bib_Info.Genres)
            {
                if (String.Compare(thisGenre.Authority, "sobekcm", true) == 0)
                {
                    sobekcmGenres.Add(thisGenre);
                }
            }
            foreach (Genre_Info thisGenre in sobekcmGenres)
            {
                Bib.Bib_Info.Remove_Genre(thisGenre);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
            if (base.index == 0)
            {
                string input_type = base.thisBox.Text;
                string mods_type = String.Empty;
                string sobekcm_genre = String.Empty;

                // Step through each material type setting here
                foreach (Material_Type_Setting thisSetting in MetaTemplate_UserSettings.Material_Types_List)
                {
                    if (String.Compare(thisSetting.Display_Name, input_type, true) == 0)
                    {
                        mods_type = thisSetting.MODS_Type;
                        sobekcm_genre = thisSetting.SobekCM_Genre;
                        break;
                    }
                }

                // Special code if this is a PROJECT
                if (isProject)
                {
                    // Find the existing default type note
                    Note_Info defaultTypeNote = null;
                    foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
                    {
                        if (thisNote.Note_Type == Note_Type_Enum.default_type)
                        {
                            defaultTypeNote = thisNote;
                            break;
                        }
                    }
                    if (defaultTypeNote == null)
                    {
                        defaultTypeNote = new Note_Info(input_type, Note_Type_Enum.default_type );
                        Bib.Bib_Info.Add_Note(defaultTypeNote);
                    }
                    else
                    {
                        defaultTypeNote.Note = input_type;
                    }

                    mods_type = "PROJECT";
                    sobekcm_genre = "PROJECT";
                }

                // Was anything found?
                if (mods_type.Length > 0)
                {
                    Bib.Bib_Info.Type.Add_Uncontrolled_Type(mods_type);
                    if (sobekcm_genre.Length > 0)
                    {
                        Bib.Bib_Info.Add_Genre(sobekcm_genre, "sobekcm");
                    }
                }
                else
                {
                    Bib.Bib_Info.Type.Add_Uncontrolled_Type(input_type);
                }

                Bib.Bib_Info.Type.Collection = collection;
            }
            else
            {
                Bib.Bib_Info.Type.Add_Uncontrolled_Type(base.thisBox.Text);
            }
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
            collection = Bib.Bib_Info.Type.Collection;

            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project )
            {
                isProject = true;

                // Is there a value for this in the notes?
                string type = String.Empty;
                foreach (Note_Info thisNote in Bib.Bib_Info.Notes)
                {
                    if (thisNote.Note_Type == Note_Type_Enum.default_type)
                    {
                        type = thisNote.Note;
                        break;
                    }
                }
                if (!thisBox.Items.Contains(type))
                    thisBox.Items.Add(type);
                base.thisBox.Text = type;
            }
            else
            {
                if (base.index == 0)
                {
                    // Look for the sobekcm genre
                    string sobekcm_genre = String.Empty;
                    foreach (Genre_Info thisGenre in Bib.Bib_Info.Genres)
                    {
                        if (String.Compare(thisGenre.Authority, "sobekcm", true) == 0)
                        {
                            sobekcm_genre = thisGenre.Genre_Term;
                            break;
                        }
                    }

                    // Get the mods type (as string)
                    string mods_type = Bib.Bib_Info.Type.MODS_Type_String;

                    // Step through each material type setting here
                    string template_type = String.Empty;
                    foreach (Material_Type_Setting thisSetting in MetaTemplate_UserSettings.Material_Types_List)
                    {
                        if ((String.Compare(thisSetting.MODS_Type, mods_type, true) == 0) && (String.Compare(thisSetting.SobekCM_Genre, sobekcm_genre) == 0))
                        {
                            template_type = thisSetting.Display_Name;
                            break;
                        }
                    }

                    // Show some type
                    if (template_type.Length > 0)
                    {
                        thisBox.Text = template_type;
                    }
                    else
                    {
                        if (!thisBox.Items.Contains(mods_type))
                        {
                            thisBox.Items.Add(mods_type);
                        }
                        base.thisBox.Text = mods_type;
                    }
                }
            }
		}
	}
}