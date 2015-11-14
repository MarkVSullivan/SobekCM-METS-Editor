#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
                //    case Template_Language.English:
                //    title = "Hierarchical Geographic";
                //    continentText = "Continent";
                //    countryText = "Country";
                //    provinceText = "Province";
                //    regionText = "Region";
                //    stateText = "State";
                //    territoryText = "Territory";
                //    countyText = "County";
                //    cityText = "City";
                //    islandText = "Island";
                //    areaText = "Area";
                //    break;

                //case Template_Language.Spanish:
                //    title = "Geografía Jerárquica";
                //    continentText = "Continente";
                //    countryText = "País";
                //    provinceText = "Provincia";
                //    regionText = "Región";
                //    stateText = "Estado";
                //    territoryText = "Territorio";
                //    countyText = "Condado";
                //    cityText = "Ciudad";
                //    islandText = "Isla";
                //    areaText = "Área";
                //    break;

                //case Template_Language.French:
                //    title = "Géographie Hiérarchique";
                //    continentText = "Continent";
                //    countryText = "Pays";
                //    provinceText = "Province";
                //    regionText = "Région";
                //    stateText = "État";
                //    territoryText = "Territoire";
                //    countyText = "Comté";
                //    cityText = "Ville";
                //    islandText = "Île";
                //    areaText = "Secteur";
				//	break;

    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit a name info object from the bibliographic package.</summary>
    public class Hierarchical_Geography_Form_Element : simpleTextBox_Element
    {
        private Subject_Info_HierarchicalGeographic geoObject;

        /// <summary> Constructor for a new Creator_Simple_Element, used in the metadata
        /// template to display and allow the user to edit the creator's name of a 
        /// bibliographic package. </summary>
        public Hierarchical_Geography_Form_Element() : base("Hierarchical Geographic")
        {
            // Set the type of this object
            base.type = Element_Type.Spatial;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            geoObject = new Subject_Info_HierarchicalGeographic();
            geoObject.User_Submitted = true;

            listenForChange = false;
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Hierarchical_Geographic_Form showGeoForm = new Hierarchical_Geographic_Form();
                showGeoForm.SetGeography(geoObject);
                showGeoForm.Read_Only = read_only;
                showGeoForm.ShowDialog();

                if (showGeoForm.Changed)
                    OnDataChanged();

                base.thisBox.Text = geoObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Hierarchical_Geographic_Form showGeoForm = new Hierarchical_Geographic_Form();
            showGeoForm.SetGeography(geoObject);
            showGeoForm.Read_Only = read_only;
            showGeoForm.ShowDialog();

            if (showGeoForm.Changed)
                OnDataChanged();

            base.thisBox.Text = geoObject.ToString().Replace("<i>", "").Replace("</i>", "").Replace("&amp;", "&").Replace("&quot;", "\"");
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "spatial_hier";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Hierarchical Geographic";
                    break;
                case Template_Language.Spanish:
                    base.title = "Geografía Jerárquica";
                    break;
                case Template_Language.French:
                    base.title = "Géographie Hiérarchique";
                    break;
                default:
                    base.title = "Hierarchical Geographic";
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
			switch( current_language )
			{
				case Template_Language.English:
					base.minimum_title_length = (int) (font_size * 17);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 15);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 17);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 17);
					break;
			}
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
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
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Subject(geoObject);
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            int hierarchical_index = -1;
            for (int i = 0; i < Bib.Bib_Info.Subjects.Count; i++)
            {
                if (Bib.Bib_Info.Subjects[i].Class_Type == Subject_Info_Type.Hierarchical_Spatial )
                {
                    hierarchical_index++;
                    if (hierarchical_index == base.index)
                    {
                        geoObject = (Subject_Info_HierarchicalGeographic)Bib.Bib_Info.Subjects[i];
                        base.thisBox.Text = geoObject.ToString();
                        break;
                    }
                }
            }
        }
    }
}
