#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Element allows entry of the FCLA processing flags (DL/FDA) </summary>
    public class FCLA_Flags_Element : abstract_Element, iElement
    {
        private CheckBox palmmFlagCheckBox, fdaFlagCheckBox;

        /// <summary> Constructor for a new instance of the FCLA_Flags_Element </summary>
        public FCLA_Flags_Element()
        {
            palmmFlagCheckBox = new CheckBox();
            palmmFlagCheckBox.Width = 80;
            palmmFlagCheckBox.Location = new Point(115, 2);
            palmmFlagCheckBox.Text = "PALMM";
            palmmFlagCheckBox.CheckedChanged += checkBox_CheckedChanged;
            Controls.Add(palmmFlagCheckBox);

            fdaFlagCheckBox = new CheckBox();
            fdaFlagCheckBox.Width = 50;
            fdaFlagCheckBox.Location = new Point(190, 2);
            fdaFlagCheckBox.Text = "FDA";
            fdaFlagCheckBox.CheckedChanged += checkBox_CheckedChanged;
            Controls.Add(fdaFlagCheckBox);

            // Set some values
            base.maximum_input_length = 550;

            // Set the type of this object
            base.type = Element_Type.FCLA_Flags;
            base.display_subtype = "simple";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;
            title = "FCLA Flags";

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                palmmFlagCheckBox.FlatStyle = FlatStyle.Flat;
                fdaFlagCheckBox.FlatStyle = FlatStyle.Flat;
            }
        }


        /// <summary> Override the OnPaint method to draw the title before the text box </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the title
            base.Draw_Title(e.Graphics, title);

            // Call this for the base
            base.OnPaint(e);

            // Determine the y-mid-point
            int midpoint = (int)(1.5 * Font.SizeInPoints);

            int width = Width;

            // If this is repeatable, show the '+' to add another after this one
            base.Draw_Repeatable_Help_Icons(e.Graphics, base.title_length + 155, midpoint - 8);

        }


        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "fclaFlags";
        }

        private void position_boxes()
        {
            palmmFlagCheckBox.Location = new Point(base.title_length, palmmFlagCheckBox.Location.Y);
            fdaFlagCheckBox.Location = new Point(base.title_length + 85, fdaFlagCheckBox.Location.Y);

        }

        #region Methods Implementing the Abstract Methods from abstract_Element class

        /// <summary> Reads the inner data from the Template XML format </summary>
        protected override void Inner_Read_Data(XmlTextReader xmlReadera)
        {
            // Nothing to read
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
            Height = size_int + (size_int + 7);

            // Now, set the height of the text box
            //			thisBox.Height =  ( size_int + 7 ) + 4;
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
                fdaFlagCheckBox.Enabled = false;
                palmmFlagCheckBox.Enabled = false;
            }
            else
            {
                fdaFlagCheckBox.Enabled = true;
                palmmFlagCheckBox.Enabled = true;
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // Never clones
            return null;
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    title = "FCLA Flags";
                    break;
                case Template_Language.Spanish:
                    title = "FCLA Banderas";
                    break;
                case Template_Language.French:
                    title = "Drapeaux FCLA";
                    break;
                default:
                    title = "FCLA Flags";
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
                    base.minimum_title_length = (int)(font_size * 12);
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
            // Do nothing( single valuees )
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            PALMM_Info palmmInfo = Bib.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
            if (palmmInfo == null)
            {
                palmmInfo = new PALMM_Info();
                Bib.Add_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY, palmmInfo);
            }
            palmmInfo.toPALMM = palmmFlagCheckBox.Checked;

            DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
            if (daitssInfo == null)
            {
                daitssInfo = new DAITSS_Info();
                Bib.Add_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY, daitssInfo);
            }
            daitssInfo.toArchive = fdaFlagCheckBox.Checked;
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            PALMM_Info palmmInfo = Bib.Get_Metadata_Module(GlobalVar.PALMM_METADATA_MODULE_KEY) as PALMM_Info;
            if ((palmmInfo != null) && ( palmmInfo.toPALMM))
                palmmFlagCheckBox.Checked = true;
            else
                palmmFlagCheckBox.Checked = false;

            DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
            if (( daitssInfo != null ) && ( daitssInfo.toArchive ))
                fdaFlagCheckBox.Checked = true;
            else
                fdaFlagCheckBox.Checked = false;
        }

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                return true;
            }
        }

        #endregion

    }
}
