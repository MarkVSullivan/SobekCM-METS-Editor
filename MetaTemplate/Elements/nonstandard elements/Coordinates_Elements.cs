#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.GeoSpatial;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary>
    /// Summary description for Temporal_Complex_Element.
    /// </summary>
    public class Coordinates_Element : abstract_Element, iElement
    {
        protected TextBox thisLatitudeBox, thisLongitudeBox;
        protected string latitude, longitude;
        private int latitude_length, longitude_length;

        public Coordinates_Element()
        {
            // Configure the start year box
            thisLatitudeBox = new TextBox();
            thisLatitudeBox.Width = 120;
            thisLatitudeBox.Location = new Point(115, 5);
            thisLatitudeBox.BackColor = Color.White;
            thisLatitudeBox.TextChanged += subElement_TextChanged;
            thisLatitudeBox.Enter += textBox_Enter;
            thisLatitudeBox.Leave += textBox_Leave;
            thisLatitudeBox.ForeColor = Color.MediumBlue;
            Controls.Add(thisLatitudeBox);

            // Configure the end year box
            thisLongitudeBox = new TextBox();
            thisLongitudeBox.Width = 120;
            thisLongitudeBox.Location = new Point(115, 5);
            thisLongitudeBox.BackColor = Color.White;
            thisLongitudeBox.TextChanged += subElement_TextChanged;
            thisLongitudeBox.Enter += textBox_Enter;
            thisLongitudeBox.Leave += textBox_Leave;
            thisLongitudeBox.ForeColor = Color.MediumBlue;
            Controls.Add(thisLongitudeBox);

            // Set default title to blank
            title = "Coordinates";
            latitude = "Latitude";
            longitude = "Longitude";

            // Set default lengths
            latitude_length = 70;
            longitude_length = 75;
            base.maximum_input_length = 570;

            // Set the type of this object
            base.type = Element_Type.Coordinates;
            base.display_subtype = "point";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;


            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisLongitudeBox.BorderStyle = BorderStyle.FixedSingle;
                thisLatitudeBox.BorderStyle = BorderStyle.FixedSingle;
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
            return "coordinates";
        }

        private void subElement_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }

        /// <summary> Override the OnPaint method to draw the title before the text box </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the title
            base.Draw_Title(e.Graphics, title);

            // Draw the smaller titles
            Font smallerFont = new Font(Font.FontFamily, Font.SizeInPoints - 1);

            // Draw the start year
            e.Graphics.DrawString(latitude + ":", smallerFont, new SolidBrush(Color.DimGray), title_length, 6);

            // Draw the end year
            int latitude_spot = (int)((Font.SizeInPoints / 10.0) * (latitude_length));
            e.Graphics.DrawString(longitude + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + latitude_spot + thisLatitudeBox.Width + 35, 6);

            // Determine the y-mid-point
            int midpoint = (int)(1.5 * Font.SizeInPoints);

            // If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 24, midpoint - 6);

            // Call this for the base
            base.OnPaint(e);
        }

        private void position_boxes()
        {
            // Set the spot for the start
            int latitude_spot = (int)((Font.SizeInPoints / 10.0) * (latitude_length));
            thisLatitudeBox.Location = new Point(base.title_length + latitude_spot, thisLatitudeBox.Location.Y);

            // Set the spot for the end box
            int longitude_spot = (int)((Font.SizeInPoints / 10.0) * (longitude_length + latitude_length));
            thisLongitudeBox.Location = new Point(base.title_length + longitude_spot + thisLatitudeBox.Width + 35, thisLongitudeBox.Location.Y);
        }

        #region Methods Implementing the Abstract Methods from abstract_Element class

        /// <summary> Reads the inner data from the Template XML format </summary>
        protected override void Inner_Read_Data(XmlTextReader xmlReadera)
        {

        }

        /// <summary> Writes the inner data into Template XML format </summary>
        protected override string Inner_Write_Data()
        {
            return String.Empty;
        }

        /// <summary> Perform any height setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Height(float size)
        {
            // Set total height
            int size_int = (int)size;
            Height = size_int + (size_int + 7) + 2;

            // Now, set the height of the text box
            //			thisBox.Height =  ( size_int + 7 ) + 4;
        }

        /// <summary> Perform any width setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Width(int new_width)
        {
            ////			// Set the spot for the start and end box
            ////			this.thisStartBox.Location = new Point( base.title_length + 80, thisStartBox.Location.Y );
            ////			this.thisEndBox.Location = new Point( base.title_length + 215, thisEndBox.Location.Y );
            ////
            ////			// Set the width of the text box
            ////			thisPeriodBox.Width = new_width - base.title_length - 390;
            ////			thisPeriodBox.Location = new Point( base.title_length + 340, thisPeriodBox.Location.Y );
            ///
            position_boxes();
        }

        /// <summary> Perform any readonly functions specific to the
        /// implementation of abstract_Element. </summary>
        protected override void Inner_Set_Read_Only()
        {
            if (base.read_only)
            {
                thisLatitudeBox.ReadOnly = true;
                thisLongitudeBox.ReadOnly = true;
                thisLatitudeBox.BackColor = Color.WhiteSmoke;
                thisLongitudeBox.BackColor = Color.WhiteSmoke;
            }
            else
            {
                thisLatitudeBox.ReadOnly = false;
                thisLongitudeBox.ReadOnly = false;
                thisLatitudeBox.BackColor = Color.White;
                thisLongitudeBox.BackColor = Color.White;
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Coordinates_Element newElement = (Coordinates_Element)Element_Factory.getElement(Type, Display_SubType);
            newElement.Location = Location;
            newElement.Language = Language;
            newElement.Title_Length = Title_Length;
            newElement.Font = Font;
            newElement.Set_Width(Width);
            newElement.Height = Height;
            newElement.Index = Index + 1;

            return newElement;
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
            GeoSpatial_Information coordInfo = Bib.Get_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY) as GeoSpatial_Information;
            if (coordInfo != null)
            {
                coordInfo.Clear_Points();
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if ((thisLatitudeBox.Text.Trim().Length > 0) ||
                (thisLongitudeBox.Text.Trim().Length > 0))
            {
                GeoSpatial_Information coordInfo = Bib.Get_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY) as GeoSpatial_Information;
                if (coordInfo == null)
                {
                    coordInfo = new GeoSpatial_Information();
                    Bib.Add_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY, coordInfo );
                }

                try
                {
                    coordInfo.Add_Point(Convert.ToDouble(thisLatitudeBox.Text.Trim()), Convert.ToDouble(thisLongitudeBox.Text.Trim()), String.Empty);
                }
                catch
                {

                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            GeoSpatial_Information coordInfo = Bib.Get_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY) as GeoSpatial_Information;
            if ((coordInfo != null) && (base.index < coordInfo.Point_Count ))
            {
                thisLatitudeBox.Text = coordInfo.Points[base.index].Latitude.ToString();
                thisLongitudeBox.Text = coordInfo.Points[base.index].Longitude.ToString();
            }
        }

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                if ((thisLatitudeBox.Text.Trim().Length > 0) || (thisLongitudeBox.Text.Trim().Length > 0))
                    return true;
                else
                    return false;
            }
        }

        #endregion

    }
}
