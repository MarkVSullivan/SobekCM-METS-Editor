#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;
using SobekCM.Resource_Object.Metadata_Modules.GeoSpatial;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Coordinates_Form : Form
    {
        private GeoSpatial_Information coords;
        protected string latitude, longitude;
        private bool read_only;
        private bool saved;
        private bool changed;
        private bool isMap;

        public Coordinates_Form( bool isMap )
        {
            InitializeComponent();

            // Save the value indicating if this is a map
            this.isMap = isMap;

            // Set default title to blank
            latitude = "Latitude";
            longitude = "Longitude";

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                point1LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                kmlTextBox.BorderStyle = BorderStyle.FixedSingle;
                point1LabelTextBox.BorderStyle = BorderStyle.FixedSingle;
                point1LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point3LabelTextBox.BorderStyle = BorderStyle.FixedSingle;
                point3LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point3LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point2LabelTextBox.BorderStyle = BorderStyle.FixedSingle;
                point2LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point5LabelTextBox.BorderStyle = BorderStyle.FixedSingle;
                point5LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point5LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point4LabelTextBox.BorderStyle = BorderStyle.FixedSingle;
                point4LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point4LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point2LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                point2LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly5LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly5LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly4LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly4LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly3LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly3LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly2LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly2LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly1LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly1LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly6LongitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                poly6LatitudeTextBox.BorderStyle = BorderStyle.FixedSingle;
                polyLabelTextBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        public bool Read_Only
        {
            set
            {
                read_only = value;

                if (read_only)
                {
                    point1LatitudeTextBox.ReadOnly = true;
                    point1LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    point1LatitudeTextBox.TabStop = false;
                    kmlTextBox.ReadOnly = true;
                    kmlTextBox.BackColor = Color.WhiteSmoke;
                    kmlTextBox.TabStop = false;
                    point1LabelTextBox.ReadOnly = true;
                    point1LabelTextBox.BackColor = Color.WhiteSmoke;
                    point1LabelTextBox.TabStop = false;
                    point1LongitudeTextBox.ReadOnly = true;
                    point1LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    point1LongitudeTextBox.TabStop = false;
                    point3LabelTextBox.ReadOnly = true;
                    point3LabelTextBox.BackColor = Color.WhiteSmoke;
                    point3LabelTextBox.TabStop = false;
                    point3LongitudeTextBox.ReadOnly = true;
                    point3LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    point3LongitudeTextBox.TabStop = false;
                    point3LatitudeTextBox.ReadOnly = true;
                    point3LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    point3LatitudeTextBox.TabStop = false;
                    point2LabelTextBox.ReadOnly = true;
                    point2LabelTextBox.BackColor = Color.WhiteSmoke;
                    point2LabelTextBox.TabStop = false;
                    point5LabelTextBox.ReadOnly = true;
                    point5LabelTextBox.BackColor = Color.WhiteSmoke;
                    point5LabelTextBox.TabStop = false;

                    point5LongitudeTextBox.ReadOnly = true;
                    point5LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    point5LongitudeTextBox.TabStop = false;
                    point5LatitudeTextBox.ReadOnly = true;
                    point5LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    point5LatitudeTextBox.TabStop = false;
                    point4LabelTextBox.ReadOnly = true;
                    point4LabelTextBox.BackColor = Color.WhiteSmoke;
                    point4LabelTextBox.TabStop = false;
                    point4LongitudeTextBox.ReadOnly = true;
                    point4LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    point4LongitudeTextBox.TabStop = false;
                    point4LatitudeTextBox.ReadOnly = true;
                    point4LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    point4LatitudeTextBox.TabStop = false;
                    point2LatitudeTextBox.ReadOnly = true;
                    point2LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    point2LatitudeTextBox.TabStop = false;
                    point2LongitudeTextBox.ReadOnly = true;
                    point2LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    point2LongitudeTextBox.TabStop = false;
                    poly5LongitudeTextBox.ReadOnly = true;
                    poly5LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly5LongitudeTextBox.TabStop = false;
                    poly5LatitudeTextBox.ReadOnly = true;
                    poly5LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly5LatitudeTextBox.TabStop = false;
                    poly4LongitudeTextBox.ReadOnly = true;
                    poly4LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly4LongitudeTextBox.TabStop = false;

                    poly4LatitudeTextBox.ReadOnly = true;
                    poly4LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly4LatitudeTextBox.TabStop = false;
                    poly3LongitudeTextBox.ReadOnly = true;
                    poly3LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly3LongitudeTextBox.TabStop = false;
                    poly3LatitudeTextBox.ReadOnly = true;
                    poly3LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly3LatitudeTextBox.TabStop = false;
                    poly2LongitudeTextBox.ReadOnly = true;
                    poly2LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly2LongitudeTextBox.TabStop = false;
                    poly2LatitudeTextBox.ReadOnly = true;
                    poly2LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly2LatitudeTextBox.TabStop = false;
                    poly1LongitudeTextBox.ReadOnly = true;
                    poly1LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly1LongitudeTextBox.TabStop = false;
                    poly1LatitudeTextBox.ReadOnly = true;
                    poly1LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly1LatitudeTextBox.TabStop = false;
                    poly6LongitudeTextBox.ReadOnly = true;
                    poly6LongitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly6LongitudeTextBox.TabStop = false;
                    poly6LatitudeTextBox.ReadOnly = true;
                    poly6LatitudeTextBox.BackColor = Color.WhiteSmoke;
                    poly6LatitudeTextBox.TabStop = false;

                    polyLabelTextBox.ReadOnly = true;
                    polyLabelTextBox.BackColor = Color.WhiteSmoke;
                    polyLabelTextBox.TabStop = false;

                    cancelButton.Hide();
                    saveButton.Button_Text = "OK";
                    saveButton.TabIndex = 0;
                }
            }
        }

        public void Set_Coordinates(GeoSpatial_Information Coords)
        {
            coords = Coords;

            // Display the data
            kmlTextBox.Text = Coords.KML_Reference;

            if (Coords.Point_Count > 0)
            {
                point1LatitudeTextBox.Text = Coords.Points[0].Latitude.ToString();
                point1LongitudeTextBox.Text = Coords.Points[0].Longitude.ToString();
                point1LabelTextBox.Text = Coords.Points[0].Label;
            }

            if (Coords.Point_Count > 1)
            {
                point2LatitudeTextBox.Text = Coords.Points[1].Latitude.ToString();
                point2LongitudeTextBox.Text = Coords.Points[1].Longitude.ToString();
                point2LabelTextBox.Text = Coords.Points[1].Label;
            }

            if (Coords.Point_Count > 2)
            {
                point3LatitudeTextBox.Text = Coords.Points[2].Latitude.ToString();
                point3LongitudeTextBox.Text = Coords.Points[2].Longitude.ToString();
                point3LabelTextBox.Text = Coords.Points[2].Label;
            }

            if (Coords.Point_Count > 3)
            {
                point4LatitudeTextBox.Text = Coords.Points[3].Latitude.ToString();
                point4LongitudeTextBox.Text = Coords.Points[3].Longitude.ToString();
                point4LabelTextBox.Text = Coords.Points[3].Label;
            }

            if (Coords.Point_Count > 4)
            {
                point5LatitudeTextBox.Text = Coords.Points[4].Latitude.ToString();
                point5LongitudeTextBox.Text = Coords.Points[4].Longitude.ToString();
                point5LabelTextBox.Text = Coords.Points[4].Label;
            }

            if (Coords.Polygon_Count > 0)
            {
                Coordinate_Polygon polygon = Coords.Get_Polygon(0);
                polyLabelTextBox.Text = polygon.Label;
                if (polygon.Edge_Points_Count > 0)
                {
                    poly1LatitudeTextBox.Text = polygon.Edge_Points[0].Latitude.ToString();
                    poly1LongitudeTextBox.Text = polygon.Edge_Points[0].Longitude.ToString();
                }
                if (polygon.Edge_Points_Count > 1)
                {
                    poly2LatitudeTextBox.Text = polygon.Edge_Points[1].Latitude.ToString();
                    poly2LongitudeTextBox.Text = polygon.Edge_Points[1].Longitude.ToString();
                }
                if (polygon.Edge_Points_Count > 2)
                {
                    poly3LatitudeTextBox.Text = polygon.Edge_Points[2].Latitude.ToString();
                    poly3LongitudeTextBox.Text = polygon.Edge_Points[2].Longitude.ToString();
                }
                if (polygon.Edge_Points_Count > 3)
                {
                    poly4LatitudeTextBox.Text = polygon.Edge_Points[3].Latitude.ToString();
                    poly4LongitudeTextBox.Text = polygon.Edge_Points[3].Longitude.ToString();
                }
                if (polygon.Edge_Points_Count > 4)
                {
                    poly5LatitudeTextBox.Text = polygon.Edge_Points[4].Latitude.ToString();
                    poly5LongitudeTextBox.Text = polygon.Edge_Points[4].Longitude.ToString();
                }
                if (polygon.Edge_Points_Count > 5)
                {
                    poly6LatitudeTextBox.Text = polygon.Edge_Points[5].Latitude.ToString();
                    poly6LongitudeTextBox.Text = polygon.Edge_Points[5].Longitude.ToString();
                }
            }

            point1LatitudeTextBox.TextChanged += textChanged;
            kmlTextBox.TextChanged += textChanged;
            point1LabelTextBox.TextChanged += textChanged;
            point1LongitudeTextBox.TextChanged += textChanged;
            point3LabelTextBox.TextChanged += textChanged;
            point3LongitudeTextBox.TextChanged += textChanged;
            point3LatitudeTextBox.TextChanged += textChanged;
            point2LabelTextBox.TextChanged += textChanged;
            point2LongitudeTextBox.TextChanged += textChanged;
            point5LabelTextBox.TextChanged += textChanged;
            point5LongitudeTextBox.TextChanged += textChanged;
            point5LatitudeTextBox.TextChanged += textChanged;
            point4LabelTextBox.TextChanged += textChanged;
            point4LongitudeTextBox.TextChanged += textChanged;
            point4LatitudeTextBox.TextChanged += textChanged;
            point2LatitudeTextBox.TextChanged += textChanged;
            point2LongitudeTextBox.TextChanged += textChanged;
            poly5LongitudeTextBox.TextChanged += textChanged;
            poly5LatitudeTextBox.TextChanged += textChanged;
            poly4LongitudeTextBox.TextChanged += textChanged;
            poly4LatitudeTextBox.TextChanged += textChanged;
            poly3LongitudeTextBox.TextChanged += textChanged;
            poly3LatitudeTextBox.TextChanged += textChanged;
            poly2LongitudeTextBox.TextChanged += textChanged;
            poly2LatitudeTextBox.TextChanged += textChanged;
            poly1LongitudeTextBox.TextChanged += textChanged;
            poly1LatitudeTextBox.TextChanged += textChanged;
            poly6LongitudeTextBox.TextChanged += textChanged;
            poly6LatitudeTextBox.TextChanged += textChanged;
            polyLabelTextBox.TextChanged += textChanged;
        }


        #region Method to draw the form background

        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Get rid of any current background image
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            if (ClientSize.Width > 0)
            {
                // Create the items needed to draw the background
                Bitmap image = new Bitmap(ClientSize.Width, ClientSize.Height);
                Graphics gr = Graphics.FromImage(image);
                Rectangle rect = new Rectangle(new Point(0, 0), ClientSize);

                // Create the brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, SystemColors.Control, ControlPaint.Dark(SystemColors.Control), LinearGradientMode.Vertical);
                brush.SetBlendTriangularShape(0.33F);

                // Create the image
                gr.FillRectangle(brush, rect);
                gr.Dispose();

                // Set this as the backgroundf
                BackgroundImage = image;
            }
        }

        #endregion

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            if (!read_only)
            {
                saved = true;

                coords.KML_Reference = kmlTextBox.Text.Trim();

                coords.Clear_Points();

                try
                {
                    if ((point1LatitudeTextBox.Text.Trim().Length > 0) && (point1LongitudeTextBox.Text.Trim().Length > 0))
                        coords.Add_Point(Convert.ToDouble(point1LatitudeTextBox.Text.Trim()), Convert.ToDouble(point1LongitudeTextBox.Text.Trim()), point1LabelTextBox.Text.Trim());

                    if ((point2LatitudeTextBox.Text.Trim().Length > 0) && (point2LongitudeTextBox.Text.Trim().Length > 0))
                        coords.Add_Point(Convert.ToDouble(point2LatitudeTextBox.Text.Trim()), Convert.ToDouble(point2LongitudeTextBox.Text.Trim()), point2LabelTextBox.Text.Trim());

                    if ((point3LatitudeTextBox.Text.Trim().Length > 0) && (point3LongitudeTextBox.Text.Trim().Length > 0))
                        coords.Add_Point(Convert.ToDouble(point3LatitudeTextBox.Text.Trim()), Convert.ToDouble(point3LongitudeTextBox.Text.Trim()), point3LabelTextBox.Text.Trim());

                    if ((point4LatitudeTextBox.Text.Trim().Length > 0) && (point4LongitudeTextBox.Text.Trim().Length > 0))
                        coords.Add_Point(Convert.ToDouble(point4LatitudeTextBox.Text.Trim()), Convert.ToDouble(point4LongitudeTextBox.Text.Trim()), point4LabelTextBox.Text.Trim());

                    if ((point5LatitudeTextBox.Text.Trim().Length > 0) && (point5LongitudeTextBox.Text.Trim().Length > 0))
                        coords.Add_Point(Convert.ToDouble(point5LatitudeTextBox.Text.Trim()), Convert.ToDouble(point5LongitudeTextBox.Text.Trim()), point5LabelTextBox.Text.Trim());

                }
                catch
                {

                }

                Coordinate_Polygon polygon = new Coordinate_Polygon();
                bool added = false;
                bool hasPoints = false;
                if (coords.Polygon_Count > 0)
                {
                    added = true;
                    polygon = coords.Get_Polygon(0);
                }

                polygon.Clear_Edge_Points();

                // Check for semicolons and blank longitudes
                if ((poly1LatitudeTextBox.Text.IndexOf(";") > 0) && (poly1LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly1LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly1LatitudeTextBox.Text = split[0];
                        poly1LongitudeTextBox.Text = split[1];
                    }
                }
                if ((poly2LatitudeTextBox.Text.IndexOf(";") > 0) && (poly2LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly2LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly2LatitudeTextBox.Text = split[0];
                        poly2LongitudeTextBox.Text = split[1];
                    }
                }
                if ((poly3LatitudeTextBox.Text.IndexOf(";") > 0) && (poly3LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly3LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly3LatitudeTextBox.Text = split[0];
                        poly3LongitudeTextBox.Text = split[1];
                    }
                }
                if ((poly4LatitudeTextBox.Text.IndexOf(";") > 0) && (poly4LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly4LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly4LatitudeTextBox.Text = split[0];
                        poly4LongitudeTextBox.Text = split[1];
                    }
                }
                if ((poly5LatitudeTextBox.Text.IndexOf(";") > 0) && (poly5LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly5LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly5LatitudeTextBox.Text = split[0];
                        poly5LongitudeTextBox.Text = split[1];
                    }
                }
                if ((poly6LatitudeTextBox.Text.IndexOf(";") > 0) && (poly6LongitudeTextBox.Text.Trim().Length == 0))
                {
                    string[] split = poly6LatitudeTextBox.Text.Split(";".ToCharArray());
                    if (split.Length > 1)
                    {
                        poly6LatitudeTextBox.Text = split[0];
                        poly6LongitudeTextBox.Text = split[1];
                    }
                }

                try
                {

                    // Now assign any values that are present to the polygon
                    if ((poly1LatitudeTextBox.Text.Trim().Length > 0) && (poly1LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly1LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly1LongitudeTextBox.Text.Trim()), String.Empty);
                    }

                    if ((poly2LatitudeTextBox.Text.Trim().Length > 0) && (poly2LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly2LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly2LongitudeTextBox.Text.Trim()), String.Empty);
                    }

                    if ((poly3LatitudeTextBox.Text.Trim().Length > 0) && (poly3LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly3LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly3LongitudeTextBox.Text.Trim()), String.Empty);
                    }

                    if ((poly4LatitudeTextBox.Text.Trim().Length > 0) && (poly4LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly4LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly4LongitudeTextBox.Text.Trim()), String.Empty);
                    }

                    if ((poly5LatitudeTextBox.Text.Trim().Length > 0) && (poly5LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly5LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly5LongitudeTextBox.Text.Trim()), String.Empty);
                    }

                    if ((poly6LatitudeTextBox.Text.Trim().Length > 0) && (poly6LongitudeTextBox.Text.Trim().Length > 0))
                    {
                        hasPoints = true;
                        polygon.Add_Edge_Point(Convert.ToDouble(poly6LatitudeTextBox.Text.Trim()), Convert.ToDouble(poly6LongitudeTextBox.Text.Trim()), String.Empty);
                    }
                }
                catch
                {

                }

                polygon.Label = polyLabelTextBox.Text.Trim();
                if ((polygon.Label.Length == 0) && (isMap))
                    polygon.Label = "Map Coverage";

                // Are there just two points in this polygon?
                if (polygon.Edge_Points_Count == 2)
                {
                    Coordinate_Point first_point = polygon.Edge_Points[0];
                    Coordinate_Point second_point = polygon.Edge_Points[1];

                    polygon.Clear_Edge_Points();

                    polygon.Add_Edge_Point(first_point);
                    polygon.Add_Edge_Point(first_point.Latitude, second_point.Longitude);
                    polygon.Add_Edge_Point(second_point);
                    polygon.Add_Edge_Point(second_point.Latitude, first_point.Longitude);
                }
                
                // If this has not been added and has points, add it
                if ((!added) && ( hasPoints ))
                {
                    coords.Add_Polygon(polygon);
                }
            }

            Close();
        }

        private void cancelButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        #region Methods to change the background color of each control when focus changes

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        #endregion

        public bool Changed
        {
            get
            {
                return (changed) && (saved) && (!read_only);
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void coordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'c') || ( e.KeyChar == 'C' ))
            {
                e.Handled = true;

                Degrees_Minutes_Seconds_Form coordForm = new Degrees_Minutes_Seconds_Form();
                coordForm.ShowDialog();
                string result = coordForm.Result;
                if ( result.Length > 0 )
                    ((TextBox)sender).Text = coordForm.Result;
            }
        }



    }
}
