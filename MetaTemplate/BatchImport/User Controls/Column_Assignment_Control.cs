#region Using directives

using System;
using System.Windows.Forms;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public partial class Column_Assignment_Control : UserControl
    {
        private bool empty;

        protected static string[] mappable_fields;

        static Column_Assignment_Control()
        {
            Array enumValues = Enum.GetValues(typeof(Mapped_Fields));
            mappable_fields = new string[enumValues.Length];
            for (int i = 0; i < enumValues.Length; i++)
            {
                mappable_fields[i] = Bibliographic_Mapping.Mapped_Field_To_String((Mapped_Fields)enumValues.GetValue(i));
            }
        }

        public Column_Assignment_Control()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(mappable_fields);
                      
            empty = false;
        }

        public bool Empty
        {
            get
            {
                return empty;
            }
            set
            {
                empty = value;
                if (empty)
                {
                    textBox1.ReadOnly = false;
                    textBox1.Text = "{Empty}";
                }
                else
                {
                    textBox1.ReadOnly = true;
                }
            }
        }

        public string Column_Name
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Mapped_Name
        {
            get { return comboBox1.Text; }
        }

        public bool hasItemInList( string item )
        {
            return comboBox1.Items.Contains( item );
        }

        public void Select_List_Item(string columnName)
        {                      
                Mapped_Fields mappedField = Bibliographic_Mapping.String_To_Mapped_Field(columnName);
                string listValue = Bibliographic_Mapping.Mapped_Field_To_String(mappedField);
                comboBox1.SelectedIndex = comboBox1.FindStringExact(listValue);           
        }

        public Mapped_Fields Mapped_Field
        {
            get
            {
                return Bibliographic_Mapping.String_To_Mapped_Field(comboBox1.Text);
            }
        }
    }
}
