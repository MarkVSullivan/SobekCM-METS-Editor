#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Divisions;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary>
    /// Summary description for SobekCM_Viewer_Element.
    /// </summary>
    public class SobekCM_Viewer_Element : abstract_Element, iElement
    {
        protected TextBox thisAttributesBox, thisViewReadOnlyBox, thisLabelBox;
        protected ComboBox thisViewBox, thisAttributesComboBox;
        protected string viewText, attributes, label;
        private int viewText_length, attributes_length, label_length;
        private bool show_label_and_attributes;
        private bool isXP;

        public SobekCM_Viewer_Element()
        {
            show_label_and_attributes = false;

            // Configure the viewText year box
            thisViewBox = new ComboBox();
           // thisViewBox.FlatStyle = FlatStyle.Flat;
            thisViewBox.Width = 150;
            thisViewBox.Location = new Point(115, 2);
            thisViewBox.TextChanged += subElement_TextChanged;
            thisViewBox.SelectedIndexChanged += thisViewBox_SelectedIndexChanged;
            thisViewBox.DropDownStyle = ComboBoxStyle.DropDownList;
            thisViewBox.Items.Add("");
            thisViewBox.Items.Add("Page Image (JPEG)");
            thisViewBox.Items.Add("Zoomable (JPEG2000)");
            thisViewBox.Items.Add("Page Turner");
            thisViewBox.Items.Add("Text");
          //  thisViewBox.Items.Add("Thumbnails");


            thisViewBox.ForeColor = Color.MediumBlue;
            thisViewBox.Leave += comboBox_Leave;
            thisViewBox.Enter += comboBox_Enter;
            Controls.Add(thisViewBox);

            // Configure the viewText year box
            thisViewReadOnlyBox = new TextBox();
            thisViewReadOnlyBox.Width = 150;
            thisViewReadOnlyBox.Location = new Point(115, 2);
            thisViewReadOnlyBox.ReadOnly = true;
            thisViewReadOnlyBox.BackColor = Color.WhiteSmoke;
            thisViewReadOnlyBox.Hide();
            thisViewReadOnlyBox.ForeColor = Color.MediumBlue;
            Controls.Add(thisViewReadOnlyBox);

            // Configure the attributes name box
            thisAttributesBox = new TextBox();
            thisAttributesBox.Width = 120;
            thisAttributesBox.Location = new Point(115, 2);
            thisAttributesBox.BackColor = Color.White;
            thisAttributesBox.TextChanged += subElement_TextChanged;
            thisAttributesBox.Hide();
            thisAttributesBox.ForeColor = Color.MediumBlue;
            thisAttributesBox.Leave += textBox_Leave;
            thisAttributesBox.Enter += textBox_Enter;
            Controls.Add(thisAttributesBox);

            // Configure the attributes combo box
            thisAttributesComboBox = new ComboBox();
            thisAttributesComboBox.FlatStyle = FlatStyle.System;
            thisAttributesComboBox.Width = 120;
            thisAttributesComboBox.Location = new Point(115, 2);
            thisAttributesComboBox.BackColor = Color.White;
            thisAttributesComboBox.TextChanged += thisAttributesComboBox_TextChanged;
            thisAttributesComboBox.Hide();
            thisAttributesComboBox.ForeColor = Color.MediumBlue;
            thisAttributesComboBox.Leave += comboBox_Leave;
            thisAttributesComboBox.Enter += comboBox_Enter;
            Controls.Add(thisAttributesComboBox);

            // Configure the label year box
            thisLabelBox = new TextBox();
            thisLabelBox.Width = 160;
            thisLabelBox.Location = new Point(115, 2);
            thisLabelBox.BackColor = Color.White;
            thisLabelBox.TextChanged += subElement_TextChanged;
            thisLabelBox.ForeColor = Color.MediumBlue;
            thisLabelBox.Leave += textBox_Leave;
            thisLabelBox.Enter += textBox_Enter;
            thisLabelBox.Hide();
            Controls.Add(thisLabelBox);

            // Set default title to blank
            title = "Viewer";
            viewText = "";
            attributes = "Attribute";
            label = "Label";

            // Set default lengths
            viewText_length = 0;
            attributes_length = 61;
            label_length = 40;
            base.maximum_input_length = 650;

            // Set the type of this object
            base.type = Element_Type.Viewer;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                isXP = false;
                thisLabelBox.BorderStyle = BorderStyle.FixedSingle;
                thisAttributesBox.BorderStyle = BorderStyle.FixedSingle;
                thisViewReadOnlyBox.BorderStyle = BorderStyle.FixedSingle;
                thisViewBox.FlatStyle = FlatStyle.Flat;
                thisAttributesComboBox.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                isXP = true;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void comboBox_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.Khaki;
        }

        private void comboBox_Leave(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.White;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "view";
        }

        void thisAttributesComboBox_TextChanged(object sender, EventArgs e)
        {
            thisAttributesBox.Text = thisAttributesComboBox.Text;
        }

        void thisViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            thisViewReadOnlyBox.Text = thisViewBox.Text;
            if (thisViewBox.Text.IndexOf("HTML") == 0)
            {
                show_label_and_attributes = true;
                if (thisViewBox.Text == "HTML")
                {
                    if (read_only)
                    {
                        thisAttributesBox.Show();
                        thisAttributesComboBox.Hide();
                    }
                    else
                    {
                        thisAttributesComboBox.Show();
                        thisAttributesBox.Hide();
                    }
                }
                else
                {
                    thisAttributesBox.Show();
                    thisAttributesComboBox.Hide();
                }
                thisLabelBox.Show();
                Invalidate();
            }
            else
            {
                show_label_and_attributes = false;
                thisLabelBox.Hide();
                thisAttributesBox.Hide();
                thisAttributesComboBox.Hide();
                Invalidate();
            }
            base.OnDataChanged();
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

            // Draw the viewText year
            //e.Graphics.DrawString(viewText + ":", smallerFont, new SolidBrush(Color.Black), this.title_length + 5, 9);

            // Draw the attributes year
            if (show_label_and_attributes)
            {
                int end_spot = (int)((Font.SizeInPoints / 10.0) * (viewText_length));
                e.Graphics.DrawString(attributes + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + end_spot + thisViewReadOnlyBox.Width + 15, 6);

                // Draw the label
                int period_spot = (int)((Font.SizeInPoints / 10.0) * (attributes_length + viewText_length));
                e.Graphics.DrawString(label + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + period_spot + thisViewReadOnlyBox.Width + thisAttributesBox.Width + 30, 6);
            }

            // Determine the y-mid-point
            int midpoint = (int)(1.5 * Font.SizeInPoints);

            // If this is repeatable, show the '+' to add another after this one
            if (show_label_and_attributes)
            {
                base.Draw_Repeatable_Help_Icons(e.Graphics, Width - Help_Button_Width - 22, midpoint - 8);
            }
            else
            {
                base.Draw_Repeatable_Help_Icons(e.Graphics, thisViewBox.Location.X + thisViewBox.Width + 30 - Help_Button_Width, midpoint - 8);
            }

            // Call this for the base
            base.OnPaint(e);

            if ((!isXP) && (!read_only))
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), thisViewBox.Location.X - 1, thisViewBox.Location.Y - 1, thisViewBox.Width + 1, thisViewBox.Height + 1);

                if (thisAttributesComboBox.Visible)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Black), thisAttributesComboBox.Location.X - 1, thisAttributesComboBox.Location.Y - 1, thisAttributesComboBox.Width + 1, thisAttributesComboBox.Height + 1);
                }
            }
        }

        private void position_boxes()
        {
            // Set the spot for the viewText
            int viewText_spot = (int)((Font.SizeInPoints / 10.0) * (viewText_length));
            thisViewReadOnlyBox.Location = new Point(base.title_length + viewText_spot, thisViewReadOnlyBox.Location.Y);
            thisViewBox.Location = new Point(base.title_length + viewText_spot, thisViewBox.Location.Y);

            // Set the spot for the attributes box
            int end_spot = (int)((Font.SizeInPoints / 10.0) * (attributes_length + viewText_length));
            thisAttributesBox.Location = new Point(base.title_length + end_spot + thisViewReadOnlyBox.Width + 15, thisAttributesBox.Location.Y);
            thisAttributesComboBox.Location = new Point(base.title_length + end_spot + thisViewReadOnlyBox.Width + 15, thisAttributesBox.Location.Y);


            // Set the width of the text box and the location
            int period_spot = (int)((Font.SizeInPoints / 10.0) * (attributes_length + viewText_length + label_length));
            thisLabelBox.Width = Width - base.title_length - period_spot - 60 - thisViewReadOnlyBox.Width - thisAttributesBox.Width - Help_Button_Width;
            thisLabelBox.Location = new Point(base.title_length + period_spot + thisViewReadOnlyBox.Width + thisAttributesBox.Width + 30, thisLabelBox.Location.Y);
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
            Height = size_int + (size_int + 7) + 3;

            // Now, set the height of the text box
            //			thisBox.Height =  ( size_int + 7 ) + 4;
        }

        /// <summary> Perform any width setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Width(int new_width)
        {
            ////			// Set the spot for the viewText and attributes box
            ////			this.thisViewReadOnlyBox.Location = new Point( base.title_length + 80, thisViewReadOnlyBox.Location.Y );
            ////			this.thisLabelBox.Location = new Point( base.title_length + 215, thisLabelBox.Location.Y );
            ////
            ////			// Set the width of the text box
            ////			thisAttributesBox.Width = new_width - base.title_length - 390;
            ////			thisAttributesBox.Location = new Point( base.title_length + 340, thisAttributesBox.Location.Y );
            ///
            position_boxes();
        }

        /// <summary> Perform any readonly functions specific to the
        /// implementation of abstract_Element. </summary>
        protected override void Inner_Set_Read_Only()
        {
            if (base.read_only)
            {
                thisViewReadOnlyBox.Show();
                thisViewBox.Hide();
                thisLabelBox.ReadOnly = true;
                thisAttributesBox.ReadOnly = true;
                thisLabelBox.BackColor = Color.WhiteSmoke;
                thisAttributesBox.BackColor = Color.WhiteSmoke;

            }
            else
            {
                thisViewReadOnlyBox.Hide();
                thisViewBox.Show();
                thisLabelBox.ReadOnly = false;
                thisAttributesBox.ReadOnly = false;
                thisLabelBox.BackColor = Color.White;
                thisAttributesBox.BackColor = Color.White;
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            SobekCM_Viewer_Element newElement = (SobekCM_Viewer_Element)Element_Factory.getElement(Type, Display_SubType);
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
                    base.title = "Viewer";
                    viewText = "";
                    attributes = "Attributes";
                    label = "Label";
                    label_length = 40;
                    break;
                case Template_Language.Spanish:
                    base.title = "Espectador";
                    viewText = "";
                    attributes = "Cualidades";
                    label = "Etiqueta";
                    label_length = 60;
                    break;
                case Template_Language.French:
                    base.title = "Visionneuse";
                    viewText = "";
                    attributes = "Attributs";
                    label = "Étiquette";
                    label_length = 60;
                    break;
                default:
                    title = "Viewer - unknown";
                    viewText = "";
                    attributes = "Attributes";
                    label = "Label";
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
                    base.minimum_title_length = (int)(font_size * 8);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 14);
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
            Bib.Behaviors.Clear_Views();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (thisViewBox.Text.Trim().Length > 0)
            {
                switch (thisViewBox.Text)
                {
                    case "Page Image (JPEG)":
                        Bib.Behaviors.Add_View(View_Enum.JPEG);
                        break;

                    case "Zoomable (JPEG2000)":
                        Bib.Behaviors.Add_View(View_Enum.JPEG2000);
                        break;

                    case "HTML":
                        View_Object newView = new View_Object(View_Enum.HTML);
                        newView.Attributes = thisAttributesBox.Text.Trim();
                        newView.Label = thisLabelBox.Text.Trim();
                        Bib.Behaviors.Add_View(newView);
                        if (thisAttributesBox.Text.Trim().Length > 0)
                        {
                            SobekCM_File_Info newestFile = new SobekCM_File_Info(thisAttributesBox.Text.Trim());
                            Bib.Divisions.Physical_Tree.Add_File(newestFile);
                        }
                        break;

                    case "HTML_MAP":
                        View_Object newView2 = new View_Object(View_Enum.HTML_MAP);
                        newView2.Attributes = thisAttributesBox.Text.Trim();
                        newView2.Label = thisLabelBox.Text.Trim();
                        Bib.Behaviors.Add_View(newView2);
                        break;

                    case "Thumbnails":
                        Bib.Behaviors.Add_View(View_Enum.RELATED_IMAGES);
                        break;

                    case "Text":
                        Bib.Behaviors.Add_View(View_Enum.TEXT);
                        break;

                    case "Page Turner":
                        Bib.Behaviors.Add_View(View_Enum.PAGE_TURNER);
                        break;
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (Bib.Behaviors.Views.Count > base.index)
            {
                switch (Bib.Behaviors.Views[base.index].View_Type)
                {
                    case View_Enum.JPEG:
                        thisViewBox.Text = "Page Image (JPEG)";
                        thisViewReadOnlyBox.Text = "Page Image (JPEG)";
                        break;

                    case View_Enum.JPEG2000:
                        thisViewBox.Text = "Zoomable (JPEG2000)";
                        thisViewReadOnlyBox.Text = "Zoomable (JPEG2000)";
                        break;

                    case View_Enum.TEXT:
                        thisViewBox.Text = "Text";
                        thisViewReadOnlyBox.Text = "Text";
                        break;

                    case View_Enum.PAGE_TURNER:
                        thisViewBox.Text = "Page Turner";
                        thisViewReadOnlyBox.Text = "Page Turner";
                        break;

                    case View_Enum.RELATED_IMAGES:
                        thisViewBox.Text = "Thumbnails";
                        thisViewReadOnlyBox.Text = "Thumbnails";
                        break;

                    case View_Enum.HTML:
                        thisViewBox.Text = "HTML";
                        thisViewReadOnlyBox.Text = "HTML";
                        break;

                    case View_Enum.HTML_MAP:
                        thisViewBox.Text = "HTML_MAP";
                        thisViewReadOnlyBox.Text = "HTML_MAP";
                        break;

                    default:
                        thisViewBox.Text = "";
                        thisViewReadOnlyBox.Text = "";
                        break;
                }

                // Include attributes and labels
                thisAttributesBox.Text = Bib.Behaviors.Views[base.index].Attributes;
                thisAttributesComboBox.Text = Bib.Behaviors.Views[base.index].Attributes;
                thisLabelBox.Text = Bib.Behaviors.Views[base.index].Label;

                // Populate the combo box
                if ((Bib.Source_Directory.IndexOf("http:") < 0) && (Directory.Exists(Bib.Source_Directory)))
                {
                    string[] html_files = Directory.GetFiles(Bib.Source_Directory, "*.htm*");
                    foreach (string thisFile in html_files)
                    {
                        thisAttributesComboBox.Items.Add(((new FileInfo(thisFile)).Name));
                    }
                }
                List<SobekCM_File_Info> additionalFiles = Bib.Divisions.Download_Tree.All_Files;
                foreach (SobekCM_File_Info thisFile in additionalFiles)
                {
                    if ((thisFile.System_Name.IndexOf(".htm") > 0) && (!thisAttributesComboBox.Items.Contains(thisFile.System_Name)))
                    {
                        thisAttributesComboBox.Items.Add(thisFile.System_Name);
                    }
                }
            }
        }

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                if (thisViewBox.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        #region Mouse Listener Methods

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (standard_mouse_actions)
            {
                // Determine the y-mid-point
                int midpoint = (int)(1.5 * Font.SizeInPoints);

                // Was this over the '+'?
                if (show_label_and_attributes)
                {
                    if ((Repeatable) && (e.X > Width - 22) && (e.X < Width - 7) && (e.Y > midpoint - 8) && (e.Y < midpoint + 8))
                    {
                        OnNewElementRequested();
                    }
                }
                else
                {
                    int location = thisViewBox.Location.X + thisViewBox.Width + 15;
                    if ((Repeatable) && (e.X > location) && (e.X < location + 15) && (e.Y > midpoint - 8) && (e.Y < midpoint + 8))
                    {
                        OnNewElementRequested();
                    }
                }
            }

            // Call the base method
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (true)
            {
                // Determine the y-mid-point
                int midpoint = (int)(1.5 * Font.SizeInPoints);

                // Was this over the title
                bool overTitle = false;
                if ((index == 0) && (e.X < (title_length - 10)) && (e.Y > 8) && (e.Y < (13 + Font.SizeInPoints)))
                {
                    overTitle = true;
                }

                // Was this over the '+'?
                bool overPlus = false;
                if (show_label_and_attributes)
                {
                    if ((Repeatable) && (e.X > Width - 22) && (e.X < Width - 7) && (e.Y > midpoint - 8) && (e.Y < midpoint + 8))
                    {
                        overPlus = true;
                    }
                }
                else
                {
                    int location = thisViewBox.Location.X + thisViewBox.Width + 15;
                    if ((Repeatable) && (e.X > location) && (e.X < location + 15) && (e.Y > midpoint - 8) && (e.Y < midpoint + 8))
                    {
                        overPlus = true;
                    }
                }

                // Set the cursor correctly
                if ((overTitle) || (overPlus))
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                }

                // If over the title, do a bit more
                if (overTitle)
                {
                    if (!link_active)
                    {
                        link_active = true;
                        Invalidate();
                    }
                }
                else
                {
                    if (link_active)
                    {
                        link_active = false;
                        Invalidate();
                    }
                }
            }

            // Call the base method
          //  base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.Arrow;

            if (link_active)
            {
                link_active = false;
                Invalidate();
            }

            // Call the base method
            base.OnMouseLeave(e);
        }

        #endregion


    }
}

