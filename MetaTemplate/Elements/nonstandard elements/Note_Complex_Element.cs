#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary>
    /// Summary description for Note_Complex_Element.
    /// </summary>
    public class Note_Complex_Element : abstract_Element, iElement
    {
        protected TextBox noteBox;
        protected ComboBox noteTypeBox;
        protected string note_type_text;

        private int note_type_length;
        private TextBox readonlyNoteTypeBox;

        public Note_Complex_Element()
        {
            // Set some basic values about this type
            base.type = Element_Type.Note;
            base.display_subtype = "complex";

            // Set some default titles
            title = "Note";
            note_type_text = "Type";

            // Configure the language box
            //		languageBox = new FlatComboBox();
            noteTypeBox = new ComboBox();
            noteTypeBox.Width = 200;
            noteTypeBox.Location = new Point(115, 5);
            noteTypeBox.TextChanged += languageBox_TextChanged;
            noteTypeBox.ForeColor = Color.MediumBlue;
            noteTypeBox.Enter += comboBox_Enter;
            noteTypeBox.Leave += comboBox_Leave;
            Controls.Add(noteTypeBox);

            // Configure the code box, but leave it hidden
            readonlyNoteTypeBox = new TextBox();
            readonlyNoteTypeBox.Location = noteTypeBox.Location;
            readonlyNoteTypeBox.Width = 100;
            readonlyNoteTypeBox.Hide();
            readonlyNoteTypeBox.BackColor = Color.WhiteSmoke;
            readonlyNoteTypeBox.ReadOnly = true;
            readonlyNoteTypeBox.ForeColor = Color.MediumBlue;
            readonlyNoteTypeBox.Enter += textBox_Enter;
            readonlyNoteTypeBox.Leave += textBox_Leave;
            Controls.Add(readonlyNoteTypeBox);

            // Configure the text box
            noteBox = new TextBox();
            noteBox.Multiline = true;
            noteBox.Height = 60;
            noteBox.Location = new Point(115, 35);
            noteBox.TextChanged += abstractBox_TextChanged;
            noteBox.ForeColor = Color.MediumBlue;
            noteBox.Enter += textBox_Enter;
            noteBox.Leave += textBox_Leave;
            Controls.Add(noteBox);

            // Add the default languages to the language box
            noteTypeBox.Items.Add("");
            noteTypeBox.Items.Add("Acquisition");
            noteTypeBox.Items.Add("Additional Physical Form");
            noteTypeBox.Items.Add("Bibliography");
            noteTypeBox.Items.Add("Biographical");
            noteTypeBox.Items.Add("Citation/Reference");
            noteTypeBox.Items.Add("Creation/Production Credits");
            noteTypeBox.Items.Add("Dates or Sequential Designation");
            noteTypeBox.Items.Add("Donation");
            noteTypeBox.Items.Add("Exhibitions");
            noteTypeBox.Items.Add("Funding");
            noteTypeBox.Items.Add("Internal Comments");
            noteTypeBox.Items.Add("Issuing Body");
            noteTypeBox.Items.Add("Language");
            noteTypeBox.Items.Add("Numbering Peculiarities");
            noteTypeBox.Items.Add("Original Location");
            noteTypeBox.Items.Add("Original Version");
            noteTypeBox.Items.Add("Ownership");
            noteTypeBox.Items.Add("Performers");
            noteTypeBox.Items.Add("Preferred Citation");
            noteTypeBox.Items.Add("Publications");
            noteTypeBox.Items.Add("Restriction");
            noteTypeBox.Items.Add("Statement of Responsibility");
            noteTypeBox.Items.Add("System Details");
            noteTypeBox.Items.Add("Thesis");
            noteTypeBox.Items.Add("Venue");
            noteTypeBox.Items.Add("Version Identification");

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                noteTypeBox.FlatStyle = FlatStyle.Flat;
                noteBox.BorderStyle = BorderStyle.FixedSingle;
                readonlyNoteTypeBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        void comboBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.White;
            }
        }

        void comboBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((ComboBox)sender).BackColor = Color.Khaki;
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
            return "note_complex";
        }

        /// <summary> Override the OnPaint method to draw the title before the text box </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the title
            base.Draw_Title(e.Graphics, title);

            // Draw the smaller titles
            Font smallerFont = new Font(Font.FontFamily, Font.SizeInPoints - 1);

            // Draw the languagse subtitle
            e.Graphics.DrawString(note_type_text + ":", smallerFont, new SolidBrush(Color.Black), base.title_length + 5, 9);

            // Determine the y-mid-point
            int midpoint = (int)(1.5 * Font.SizeInPoints);

            // If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, Width - 22 - Help_Button_Width, midpoint - 6);

            // Call this for the base
            base.OnPaint(e);
        }

        private void position_boxes()
        {
            // Set the spot for the note type box
            int note_type_spot = (int)((Font.SizeInPoints / 10.0) * (note_type_length));
            noteTypeBox.Location = new Point(base.title_length + note_type_spot + 5, noteTypeBox.Location.Y);
            readonlyNoteTypeBox.Location = noteTypeBox.Location;

            // Set the spot for the abstract text box
            noteBox.Width = Width - 30 - base.title_length - Help_Button_Width;
            noteBox.Location = new Point(base.title_length, noteBox.Location.Y);
        }

        #region Methods Implementing the Abstract Methods from abstract_Element class

        /// <summary> Reads the inner data from the Template XML format </summary>
        protected override void Inner_Read_Data(XmlTextReader xmlReader)
        {
            // Do nothing
        }

        /// <summary> Writes the inner data into Template XML format </summary>
        protected override string Inner_Write_Data()
        {
            return String.Empty;
        }

        /// <summary> Perform any height setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Height(float new_size)
        {
            // Set total height
            int size_int = (int)new_size;

            // Now, set the location for the second line text boxes
            noteBox.Location = new Point(noteBox.Location.X, 5 + size_int + 20);

            Height = noteBox.Height + noteBox.Location.Y + 10;
        }

        /// <summary> Perform any width setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Width(int new_width)
        {
            position_boxes();
        }

        /// <summary> Perform any readonly functions specific to the
        /// implementation of abstract_Element. </summary>
        protected override void Inner_Set_Read_Only()
        {
            if (base.read_only)
            {
                noteBox.ReadOnly = true;
                noteTypeBox.Enabled = false;
                noteTypeBox.Hide();
                readonlyNoteTypeBox.Show();
                readonlyNoteTypeBox.BackColor = Color.WhiteSmoke;
            }
            else
            {
                noteBox.ReadOnly = false;
                noteTypeBox.Enabled = true;
                noteTypeBox.Show();
                readonlyNoteTypeBox.Hide();
                readonlyNoteTypeBox.BackColor = Color.White;
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Get the new element
            Note_Complex_Element newElement = (Note_Complex_Element)Element_Factory.getElement(Type, Display_SubType);
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
                    title = "Note";
                    note_type_text = "Type";
                    note_type_length = 60;
                    break;
                case Template_Language.Spanish:
                    title = "Note";
                    note_type_text = "Type";
                    note_type_length = 60;
                    break;
                case Template_Language.French:
                    title = "Note";
                    note_type_text = "Type";
                    note_type_length = 60;
                    break;
                default:
                    title = "Note - unknown";
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
                    base.minimum_title_length = (int)(font_size * 7);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 7);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 7);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 10);
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
            Bib.Bib_Info.Clear_Notes();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (noteBox.Text.Trim().Length > 0)
            {
                Bib.Bib_Info.Add_Note(noteBox.Text.Trim(), noteTypeBox.Text.Trim());
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (base.index < Bib.Bib_Info.Notes_Count )
            {
                noteBox.Text = Bib.Bib_Info.Notes[base.Index].Note;
                noteTypeBox.Text = Bib.Bib_Info.Notes[base.Index].Note_Type_String;
            }
        }

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                if (noteBox.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        private void languageBox_TextChanged(object sender, EventArgs e)
        {
            readonlyNoteTypeBox.Text = noteTypeBox.Text;
            base.OnDataChanged();
        }

        private void abstractBox_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }
    }
}
