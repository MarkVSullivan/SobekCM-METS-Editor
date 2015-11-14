#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.GeoSpatial;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit notes about the bibliographic package.</summary>
    public class Coordinate_Form_Element : simpleTextBox_Element
    {
        private bool isMap;
        protected string latitude, longitude;
        private GeoSpatial_Information coordObject;

        /// <summary> Constructor for a new Coordinate_Form_Element, used in the metadata
        /// template to display and allow the user to edit notes about a  
        /// bibliographic package. </summary>
        public Coordinate_Form_Element()
            : base("Coordinates")
        {
            // Set the type of this object
            base.type = Element_Type.Coordinates;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;


            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            coordObject = new GeoSpatial_Information();

            listenForChange = false;
            isMap = false;
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            show_coord_value();
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Coordinates_Form showForm = new Coordinates_Form(isMap);
                showForm.Set_Coordinates(coordObject);
                showForm.Read_Only = read_only;
                showForm.ShowDialog();

                if (showForm.Changed)
                    OnDataChanged();

                show_coord_value();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Coordinates_Form showForm = new Coordinates_Form(isMap);
            showForm.Set_Coordinates(coordObject);
            showForm.Read_Only = read_only;
            showForm.ShowDialog();

            if (showForm.Changed)
                OnDataChanged();

            show_coord_value();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "coordinates_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    title = "Coordinates";
                    latitude = "Latitude";
                    longitude = "Longitude";
                    break;
                case Template_Language.Spanish:
                    title = "Coordenadas";
                    latitude = "Latitud";
                    longitude = "Longitud";
                    break;
                case Template_Language.French:
                    title = "Coordonnées";
                    latitude = "Latitude";
                    longitude = "Longitude";
                    break;
                default:
                    title = "Coordinates";
                    latitude = "Latitude";
                    longitude = "Longitude";
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
                    base.minimum_title_length = (int)(font_size * 12);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 16);
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
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            // Do nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.Add_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY, coordObject  );
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            // Just save this object
            coordObject = Bib.Get_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY) as GeoSpatial_Information;
            if (coordObject == null)
            {
                coordObject = new GeoSpatial_Information();
            }

            if (Bib.Bib_Info.Type.MODS_Type == TypeOfResource_MODS_Enum.Cartographic)
                isMap = true;
            else
                isMap = false;
        }

        private void show_coord_value()
        {
            if ((coordObject.Point_Count == 0) && (coordObject.Polygon_Count == 0) && ( coordObject.KML_Reference.Length == 0 ))
            {
                thisBox.Text = String.Empty;
                return;
            }

            if (coordObject.KML_Reference.Length > 0)
            {
                thisBox.Text = "KML Reference (" + coordObject.KML_Reference + ")";
                return;
            }

            if (coordObject.Polygon_Count >= 1)
            {
                if (coordObject.Get_Polygon(0).Label.Trim().Length > 0)
                {
                    thisBox.Text = "Polygon Included ( \"" + coordObject.Get_Polygon(0).Label.Trim() + "\" )";
                }
                else
                {
                    thisBox.Text = "Polygon Included";
                }

                return;
            }

            if (coordObject.Point_Count > 1)
            {
                thisBox.Text = "Multiple Points";
                return;
            }

            Coordinate_Point singlePoint = coordObject.Points[0];
            if (singlePoint.Label.Trim().Length > 0)
            {
                thisBox.Text = singlePoint.Latitude + " x " + singlePoint.Longitude + " ( \"" + singlePoint.Label + "\" )";
            }
            else
            {
                thisBox.Text = singlePoint.Latitude + " x " + singlePoint.Longitude;
            }
        }
    }
}
