#region Using directives

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Behaviors;
using SobekCM.Resource_Object.Bib_Info;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit notes about the bibliographic package.</summary>
    public class Serial_Hierarchy_Form_Element : simpleTextBox_Element
    {
        private Serial_Info serialInfo;
        private Part_Info serialHierarchyObject;
        private string orderText, displayText;
        private bool newspaper;

        /// <summary> Constructor for a new Serial_Hierarchy_Form_Element, used in the metadata
        /// template to display and allow the user to edit notes about a  
        /// bibliographic package. </summary>
        public Serial_Hierarchy_Form_Element() : base("SerialHierarchy")
        {
            // Set the type of this object
            base.type = Element_Type.SerialHierarchy;
            base.display_subtype = "form";

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            base.thisBox.DoubleClick += thisBox_Click;
            base.thisBox.KeyDown += thisBox_KeyDown;
            base.thisBox.ReadOnly = true;
            base.thisBox.BackColor = Color.White;

            serialHierarchyObject = new Part_Info();
            newspaper = false;

            listenForChange = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            show_hierarchy_value();
        }

        void thisBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Control) && (e.KeyCode != Keys.PrintScreen) && (e.KeyCode != Keys.Down))
            {
                Serial_Hierarchy_Form showForm = new Serial_Hierarchy_Form();
                showForm.Set_PartInfo(serialHierarchyObject, serialInfo, newspaper);
                showForm.Read_Only = read_only;
                showForm.ShowDialog();

                if (showForm.Changed)
                    OnDataChanged();

                show_hierarchy_value();
            }
        }

        void thisBox_Click(object sender, EventArgs e)
        {
            Serial_Hierarchy_Form showForm = new Serial_Hierarchy_Form();
            showForm.Set_PartInfo(serialHierarchyObject, serialInfo, newspaper);
            showForm.Read_Only = read_only;
            showForm.ShowDialog();

            if (showForm.Changed)
                OnDataChanged();

            show_hierarchy_value();
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "serial_form";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            // Change the text on the links to add new types of titles
            switch (newLanguage)
            {
                case Template_Language.English:
                    displayText = "Display";
                    orderText = "Order";
                    title = "Serial Hierarchy";
                    break;

                case Template_Language.Spanish:
                    displayText = "Enseñar";
                    orderText = "Orden";
                    title = "Jerarquía Serial";
                    break;

                case Template_Language.French:
                    displayText = "Display";
                    orderText = "Order";
                    title = "Hiérarchie Périodique";
                    break;

                default:
                    displayText = "Display";
                    orderText = "Order";
                    title = "Serial Hierarchy";
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
                    base.minimum_title_length = (int)(font_size * 15);
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
            // Do nothing
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            Bib.Set_Serial_Info( serialHierarchyObject, serialInfo);
            
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            // Just save this object
            serialHierarchyObject = Bib.Bib_Info.Series_Part_Info;
            serialInfo = Bib.Behaviors.Serial_Info;

            // Check the type for default
            if (Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Newspaper )
                newspaper = true;
        }

        private void show_hierarchy_value()
        {
            StringBuilder builder = new StringBuilder();
            if (( serialInfo != null ) && (serialInfo.Count > 0))
            {
                builder.Append(serialInfo[0].Display + " (" + serialInfo[0].Order + ")");
            }
            if ((serialInfo != null) && (serialInfo.Count > 1))
            {
                if (builder.Length > 0)
                    builder.Append(" -- ");
                builder.Append(serialInfo[1].Display + " (" + serialInfo[1].Order + ")");
            }
            if ((serialInfo != null) && (serialInfo.Count > 2))
            {
                if (builder.Length > 0)
                    builder.Append(" -- ");
                builder.Append(serialInfo[2].Display + " (" + serialInfo[2].Order + ")");
            }
            thisBox.Text = builder.ToString();
        }
    }
}
