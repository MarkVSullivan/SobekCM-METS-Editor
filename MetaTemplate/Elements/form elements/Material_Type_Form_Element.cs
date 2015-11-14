#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit a name info object from the bibliographic package.</summary>
    public class Material_Type_Form_Element : codeStatement_Element
    {
        private bool collection;
        private string extent;
        private string marc_date_start;
        private string marc_date_end;
        private string place_code;
        private string language_code;
        private List<Origin_Info_Frequency> frequency_collection;
        private List<Genre_Info> genre_collection;
        private List<TargetAudience_Info> audience_collection;
        private List<Subject_Info_Cartographics> cartographics;

        private bool isProject = false;


        /// <summary> Constructor for a new Creator_Simple_Element, used in the metadata
        /// template to display and allow the user to edit the creator's name of a 
        /// bibliographic package. </summary>
        public Material_Type_Form_Element() : base("Resource Type")
        {
            // Set the type of this object
            base.type = Element_Type.Type;
            base.display_subtype = "form";
            base.thisCodeBox.Width = 160;

            // Set some immutable characteristics
            // Set the type of this object
            base.type = Element_Type.Type;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = true;
            Restrict_Values = true;

            // Add the types to this box
            if (MetaTemplate_UserSettings.Material_Types_List.Count == 0)
            {
                base.thisCodeBox.Items.Add("text");
                base.thisCodeBox.Items.Add("cartographix");
                base.thisCodeBox.Items.Add("notated music");
                base.thisCodeBox.Items.Add("sound recording");
                base.thisCodeBox.Items.Add("sound recording-musical");
                base.thisCodeBox.Items.Add("sound recording-nonmusical");
                base.thisCodeBox.Items.Add("still image");
                base.thisCodeBox.Items.Add("moving image");
                base.thisCodeBox.Items.Add("three dimensional object");
                base.thisCodeBox.Items.Add("software, multimedia");
                base.thisCodeBox.Items.Add("mixed material");
            }
            else
            {
                foreach (Material_Type_Setting thisMaterialType in MetaTemplate_UserSettings.Material_Types_List)
                {
                    base.thisCodeBox.Items.Add(thisMaterialType.Display_Name);
                }
            }

            base.thisStatementBox.DoubleClick += thisBox_Click;
            base.thisStatementBox.KeyDown += thisBox_KeyDown;
            base.thisStatementBox.ReadOnly = true;
            base.thisStatementBox.BackColor = Color.White;

            extent = String.Empty;
            marc_date_end = String.Empty;
            marc_date_start = String.Empty;
            place_code = String.Empty;
            language_code = String.Empty;
            frequency_collection = new List<Origin_Info_Frequency>();
            genre_collection = new List<Genre_Info>();
            audience_collection = new List<TargetAudience_Info>();
            cartographics = new List<Subject_Info_Cartographics>();
            collection = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                show_material_details_form();                
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            show_material_details_form();
        }

        private void show_material_details_form()
        {
            // Look for the MODS mapping of the current type
            string MODS_Mapping = base.thisCodeBox.Text.ToUpper();
            string current_select = base.thisCodeBox.Text.ToUpper();
            string sobekcm_genre = current_select;
            foreach (Material_Type_Setting materialType in MetaTemplate_UserSettings.Material_Types_List)
            {
                if (materialType.Display_Name.ToUpper() == current_select)
                {
                    MODS_Mapping = materialType.MODS_Type.ToUpper();
                    sobekcm_genre = materialType.SobekCM_Genre.ToUpper();
                    break;
                }
            }

            switch (MODS_Mapping)
            {
                case "IMAGE":
                case "AERIAL":
                case "ARTIFACT":
                case "PHOTOGRAPH":
                case "VIDEO":
                case "STILL IMAGE":
                case "MOVING IMAGE":
                case "THREE DIMENSIONAL OBJECT":
                    Material_Details_Visual_Material_Form showVisual = new Material_Details_Visual_Material_Form();
                    showVisual.Add_Data(extent, marc_date_start, marc_date_end, place_code, language_code, audience_collection, genre_collection);
                    showVisual.Read_Only = read_only;
                    showVisual.ShowDialog();
                    if (showVisual.Changed)
                        OnDataChanged();
                    showVisual.Save_Data(ref extent, ref marc_date_start, ref marc_date_end, ref place_code, ref language_code);
                    break;

                case "BOOK":
                case "SERIAL":
                case "NEWSPAPER":
                case "TEXT":
                    if ((current_select == "SERIAL") || (sobekcm_genre == "SERIAL") || (current_select == "NEWSPAPER") || (sobekcm_genre == "SERIAL"))
                    {
                        Material_Details_Continuing_Materials_Form showCR = new Material_Details_Continuing_Materials_Form();
                        showCR.Add_Data(extent, marc_date_start, marc_date_end, place_code, language_code, frequency_collection, genre_collection);
                        showCR.Read_Only = read_only;
                        showCR.ShowDialog();
                        if (showCR.Changed)
                            OnDataChanged();
                        showCR.Save_Data(ref extent, ref marc_date_start, ref marc_date_end, ref place_code, ref language_code);
                    }
                    else
                    {
                        Material_Details_Book_Form showBook = new Material_Details_Book_Form();
                        showBook.Add_Data(extent, marc_date_start, marc_date_end, place_code, language_code, audience_collection, genre_collection);
                        showBook.Read_Only = read_only;
                        showBook.ShowDialog();
                        if (showBook.Changed)
                            OnDataChanged();
                        showBook.Save_Data(ref extent, ref marc_date_start, ref marc_date_end, ref place_code, ref language_code);
                    }
                    break;

                case "MAP":
                case "CARTOGRAPHIC":
                    Material_Details_Maps_Form showMap = new Material_Details_Maps_Form();
                    showMap.Add_Data(extent, marc_date_start, marc_date_end, place_code, language_code, cartographics, genre_collection);
                    showMap.Read_Only = read_only;
                    showMap.ShowDialog();
                    if (showMap.Changed)
                        OnDataChanged();
                    showMap.Save_Data(ref extent, ref marc_date_start, ref marc_date_end, ref place_code, ref language_code);
                    break;


                default:
                    Material_Details_Other_Form showOther = new Material_Details_Other_Form();
                    showOther.Add_Data(extent, marc_date_start, marc_date_end, place_code, language_code);
                    showOther.Read_Only = read_only;
                    showOther.ShowDialog();
                    if (showOther.Changed)
                        OnDataChanged();
                    showOther.Save_Data(ref extent, ref marc_date_start, ref marc_date_end, ref place_code, ref language_code);
                    break;
            }

            show_material_type_details();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            show_material_type_details();
        }

        private void show_material_type_details()
        {
            StringBuilder builder = new StringBuilder();
            if (extent.Length > 0)
                builder.Append(extent + " -- ");
            if (place_code.Length > 0)
                builder.Append(place_code + " -- ");
            if (language_code.Length > 0)
                builder.Append(language_code + " -- ");
            foreach( Subject_Info_Cartographics carto in cartographics )
            {
                if ( carto.Scale.Length > 0 )
                {
                    if ( carto.Scale.ToUpper().IndexOf("SCALE") < 0 )
                    {
                        builder.Append( carto.Scale + " (scale) -- ");
                    }
                    else
                    {
                        builder.Append( carto.Scale + " -- ");
                    }
                    break;
                }
            }
            foreach (Genre_Info thisGenre in genre_collection)
                builder.Append(thisGenre.Genre_Term + " -- ");
            foreach (TargetAudience_Info thisAudience in audience_collection)
                builder.Append(thisAudience.Audience + " -- ");

            string result = builder.ToString().Replace(" -- -- ", " -- ");
            if (result.Length > 4)
            {
                result = result.Substring(0, result.Length - 3).Trim();
                if (base.thisStatementBox.Width > 12)
                {
                    if (result.Length > (base.thisStatementBox.Width / 6))
                    {
                        base.thisStatementBox.Text = result.Substring(0, (base.thisStatementBox.Width / 6)) + "...";
                    }
                    else
                    {
                        base.thisStatementBox.Text = result;
                    }
                }
            }
            else
            {
                thisStatementBox.Clear();
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "type_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
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
        protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
        {
            // Get the size of the font
            float font_size = 10.0F;

            font_size = Font.SizeInPoints;

            // Set the title length
            switch (current_language)
            {
                case Template_Language.English:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 14);
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
            Origin_Info_Place deletePlace = null;
            foreach (Origin_Info_Place thisPlace in Bib.Bib_Info.Origin_Info.Places)
            {
                if (thisPlace.Place_MarcCountry.Length > 0)
                {
                    deletePlace = thisPlace;
                    break;
                }
            }
            if ( deletePlace != null )
                Bib.Bib_Info.Origin_Info.Remove_Place( deletePlace );

            Language_Info deleteLanguage = null;
            foreach (Language_Info thisLanguage in Bib.Bib_Info.Languages)
            {
                if ( thisLanguage.Language_ISO_Code.Length > 0)
                {
                    deleteLanguage = thisLanguage;
                    break;
                }
            }
            if ( deleteLanguage != null )
                Bib.Bib_Info.Remove_Language( deleteLanguage );

            List<Origin_Info_Frequency> deleteFrequencies = new List<Origin_Info_Frequency>();
            foreach (Origin_Info_Frequency thisFrequency in Bib.Bib_Info.Origin_Info.Frequencies)
            {
                if (thisFrequency.Authority == "marcfrequency")
                    deleteFrequencies.Add(thisFrequency);
            }
            foreach( Origin_Info_Frequency deleteFrequency in deleteFrequencies )
            {
                Bib.Bib_Info.Origin_Info.Remove_Frequency( deleteFrequency );
            }

            List<Genre_Info> deleteGenres = new List<Genre_Info>();
            foreach (Genre_Info thisGenre in Bib.Bib_Info.Genres)
            {
                if ((thisGenre.Authority == "marcgt") || ( thisGenre.Authority == "sobekcm" ))
                    deleteGenres.Add(thisGenre);
            }
            foreach( Genre_Info deleteGenre in deleteGenres )
            {
                Bib.Bib_Info.Remove_Genre( deleteGenre );
            }

            List<TargetAudience_Info> deleteAudiences = new List<TargetAudience_Info>();
            foreach (TargetAudience_Info thisAudience in Bib.Bib_Info.Target_Audiences)
            {
                if (thisAudience.Authority == "marctarget")
                    deleteAudiences.Add(thisAudience);
            }
            foreach (TargetAudience_Info deleteAudience in deleteAudiences)
            {
                Bib.Bib_Info.Remove_Target_Audience(deleteAudience);
            }

            List<Subject_Info> deleteCartographics = new List<Subject_Info>();
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Cartographics)
                {
                    deleteCartographics.Add(thisSubject);
                }
            }
            foreach (Subject_Info deleteSubject in deleteCartographics)
            {
                Bib.Bib_Info.Remove_Subject(deleteSubject);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (!read_only)
            {
                string input_type = base.thisCodeBox.Text;
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
                        defaultTypeNote = new Note_Info(input_type, Note_Type_Enum.default_type);
                        Bib.Bib_Info.Add_Note(defaultTypeNote);
                    }
                    else
                    {
                        defaultTypeNote.Note = input_type;
                    }

                    Bib.Bib_Info.Add_Genre("project", "sobekcm");
                    Bib.Bib_Info.Type.Clear();
                    
                }
                else
                {
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
                }



                Bib.Bib_Info.Type.Collection = collection;
                Bib.Bib_Info.Original_Description.Extent = extent;
                Bib.Bib_Info.Origin_Info.MARC_DateIssued_End = marc_date_end;
                Bib.Bib_Info.Origin_Info.MARC_DateIssued_Start = marc_date_start;
                Bib.Bib_Info.Origin_Info.Add_Place(String.Empty, place_code, String.Empty);
                Bib.Bib_Info.Add_Language(String.Empty, language_code, String.Empty);

                foreach (Origin_Info_Frequency thisFrequency in frequency_collection)
                {
                    Bib.Bib_Info.Origin_Info.Add_Frequency(thisFrequency);
                }
                foreach (Genre_Info thisGenre in genre_collection)
                {
                    Bib.Bib_Info.Add_Genre(thisGenre);
                }
                foreach (TargetAudience_Info thisAudience in audience_collection)
                {
                    Bib.Bib_Info.Add_Target_Audience(thisAudience);
                }
                foreach (Subject_Info thisSubject in cartographics)
                {
                    Bib.Bib_Info.Add_Subject(thisSubject);
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            collection = Bib.Bib_Info.Type.Collection;

            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project)
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
                if (!thisCodeBox.Items.Contains(type))
                    thisCodeBox.Items.Add(type);
                base.thisCodeBox.Text = type;
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
                        thisCodeBox.Text = template_type;
                    }
                    else
                    {
                        if (!thisCodeBox.Items.Contains(mods_type))
                        {
                            thisCodeBox.Items.Add(mods_type);
                        }
                        base.thisCodeBox.Text = mods_type;
                    }
                }
            }

            extent = Bib.Bib_Info.Original_Description.Extent;
            marc_date_end = Bib.Bib_Info.Origin_Info.MARC_DateIssued_End;
            marc_date_start = Bib.Bib_Info.Origin_Info.MARC_DateIssued_Start;

            foreach (Origin_Info_Place thisPlace in Bib.Bib_Info.Origin_Info.Places)
            {
                if (thisPlace.Place_MarcCountry.Length > 0)
                {
                    place_code = thisPlace.Place_MarcCountry;
                    break;
                }
            }
            foreach (Language_Info thisLanguage in Bib.Bib_Info.Languages)
            {
                if ( thisLanguage.Language_ISO_Code.Length > 0)
                {
                    language_code = thisLanguage.Language_ISO_Code;
                    break;
                }
            }
            foreach (Origin_Info_Frequency thisFrequency in Bib.Bib_Info.Origin_Info.Frequencies)
            {
                if (thisFrequency.Authority == "marcfrequency")
                    frequency_collection.Add(thisFrequency);
            }
            foreach (Genre_Info thisGenre in Bib.Bib_Info.Genres)
            {
                if (thisGenre.Authority == "marcgt")
                    genre_collection.Add(thisGenre);
            }
            foreach (TargetAudience_Info thisAudience in Bib.Bib_Info.Target_Audiences)
            {
                if (thisAudience.Authority == "marctarget")
                    audience_collection.Add(thisAudience);
            }
            foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
            {
                if (thisSubject.Class_Type == Subject_Info_Type.Cartographics)
                {
                    cartographics.Add((Subject_Info_Cartographics)thisSubject);
                }
            }

            show_material_type_details();

            base.thisCodeBox.SelectedIndexChanged += thisCodeBox_TextChanged;
        }

        void thisCodeBox_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }
    }
}
