#region Using directives

using System;
using System.Data;
using System.Windows.Forms;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public partial class Constant_Assignment_Control : UserControl
    {
        private string list_value;

        protected static string[] mappable_fields;

        static Constant_Assignment_Control()
        {
            Array enumValues = Enum.GetValues(typeof(Mapped_Fields));
            mappable_fields = new string[enumValues.Length + 1];
            for (int i = 0; i < enumValues.Length; i++)
            {
                mappable_fields[i] = Bibliographic_Mapping.Mapped_Field_To_String((Mapped_Fields)enumValues.GetValue(i));
            }
            mappable_fields[enumValues.Length] = "First BibID";
        }

        private static DataTable aggregationTable;
        public static void Set_Aggregation_Table(DataTable Aggregation_Table)
        {
            aggregationTable = Aggregation_Table;
        }
                      
        public Constant_Assignment_Control()
        {
            InitializeComponent();
            cboMappedField.Items.AddRange(mappable_fields);           
        }

        public string Mapped_Name
        {
            get { return cboMappedField.Text; }
            set { cboMappedField.Text = value; }
        }

        public string Mapped_Constant
        {
            get {

                try
                {

                    if ((Mapped_Field == Mapped_Fields.Source_Code) &&
                            (cboMappedConstant.Text.Length > 0))
                    {
                        list_value = cboMappedConstant.Text.Substring(0, cboMappedConstant.Text.IndexOf(' '));

                        return list_value;
                    }                    
                    else if ((Mapped_Field.ToString() == "None") &&
                       (cboMappedConstant.SelectedIndex == 0))
                    {                        
                        cboMappedConstant.SelectedIndex = -1;                       
                        return String.Empty;
                    }
                    else
                    {
                        return cboMappedConstant.Text;                        
                    }
                }
                catch (Exception)
                {
                    return String.Empty;
                }       
            }
            set
            {
                cboMappedConstant.Text = value;
            }
        }

        public bool hasItemInList( string item )
        {
            return cboMappedField.Items.Contains( item );
        }

        public Mapped_Fields Mapped_Field
        {
            get
            {
                return Bibliographic_Mapping.String_To_Mapped_Field( cboMappedField.Text);
            }
        }

        private void cboMappedField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMappedConstant.Items.Clear();
            cboMappedConstant.DropDownStyle = ComboBoxStyle.Simple;

            int index = 0;
            switch (cboMappedField.Text)
            {
                case "None":
                    cboMappedConstant.SelectedIndex = -1;
                    cboMappedConstant.Text = String.Empty;
                    cboMappedConstant.Enabled = false;
                    break;               

                case "Source Institution Code":
                    if (aggregationTable != null)
                    {
                        // Populate all the source institutions
                        foreach (DataRow thisRow in aggregationTable.Rows)
                        {
                            if (thisRow["Type"].ToString().ToUpper().IndexOf("INSTITUT") == 0)
                            {
                                cboMappedConstant.Items.Add(thisRow["UFDC"].ToString());
                            }
                        }

                        cboMappedConstant.DropDownStyle = ComboBoxStyle.DropDownList;
                        cboMappedConstant.Enabled = true;

                        // select default value
                        index = cboMappedConstant.FindString("UF");

                        if (index > 0)
                            cboMappedConstant.SelectedIndex = index;
                    }
                    break;   
      
                case "Holding Location Code":
                    if (aggregationTable != null)
                    {
                        // Populate all the holding institutions
                        foreach (DataRow thisRow in aggregationTable.Rows)
                        {
                            if (thisRow["Type"].ToString().ToUpper().IndexOf("INSTITUT") == 0)
                            {
                                cboMappedConstant.Items.Add(thisRow["UFDC"].ToString());
                            }
                        }

                        cboMappedConstant.DropDownStyle = ComboBoxStyle.DropDownList;
                        cboMappedConstant.Enabled = true;

                        // select default value
                        index = cboMappedConstant.FindString("UF");

                        if (index > 0)
                            cboMappedConstant.SelectedIndex = index;
                    }
                    break;                              

                case "Material Type":
                    cboMappedConstant.Items.Add("Aerial");
                    cboMappedConstant.Items.Add("Archival");
                    cboMappedConstant.Items.Add("Artifact");
                    cboMappedConstant.Items.Add("Audio");
                    cboMappedConstant.Items.Add("Book");
                    cboMappedConstant.Items.Add("Map");
                    cboMappedConstant.Items.Add("Newspaper");
                    cboMappedConstant.Items.Add("Photograph");
                    cboMappedConstant.Items.Add("Serial");
                    cboMappedConstant.Items.Add("Video");
                    cboMappedConstant.SelectedIndex = -1;

                    cboMappedConstant.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboMappedConstant.Enabled = true;                
                    break;

                case "Aggregation Code":
                    if (aggregationTable != null)
                    {
                        // Populate all the project codes
                        foreach (DataRow thisRow in aggregationTable.Rows)
                        {
                            if (thisRow["Type"].ToString().ToUpper().IndexOf("INSTITUT") < 0)
                            {
                                cboMappedConstant.Items.Add(thisRow["UFDC"].ToString());
                            }
                        }
                        cboMappedConstant.DropDownStyle = ComboBoxStyle.DropDownList;
                        cboMappedConstant.Enabled = true;
                    }
                    break;

                case "Visibility":
                    cboMappedConstant.Items.Add("DARK");
                    cboMappedConstant.Items.Add("PRIVATE");
                    cboMappedConstant.Items.Add("RESTRICTED");
                    cboMappedConstant.Items.Add("PUBLIC");
                    cboMappedConstant.SelectedIndex = 1;

                    cboMappedConstant.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboMappedConstant.Enabled = true;
                    break;
                
                default:
                    cboMappedConstant.Enabled = true;          
                    break;
            }

        }     
    }
}
