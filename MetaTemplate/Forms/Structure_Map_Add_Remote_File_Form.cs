#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    /// <summary> Form takes up to five references to external files which should be linked
    /// to in the current METS, but will not be actually copied into the digital resource folder  </summary>
    public partial class Structure_Map_Add_Remote_File_Form : Form
    {
        /// <summary> Constructor for a new instance of this form </summary>
        public Structure_Map_Add_Remote_File_Form()
        {
            InitializeComponent();

            Files_To_Add = new List<string>();
        }

        /// <summary> Gets the list of remote files the user entered </summary>
        public List<string> Files_To_Add { get; private set; }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Files_To_Add.Clear();
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            Files_To_Add.Clear();
            if (textBox1.Text.Trim().Length > 0)
            {
                Files_To_Add.Add(textBox1.Text.Trim());
            }
            if (textBox2.Text.Trim().Length > 0)
            {
                string text2 = textBox2.Text.Trim();
                if (!Files_To_Add.Contains(text2))
                    Files_To_Add.Add(text2);
            }
            if (textBox3.Text.Trim().Length > 0)
            {
                string text3 = textBox3.Text.Trim();
                if (!Files_To_Add.Contains(text3))
                    Files_To_Add.Add(text3);
            }
            if (textBox4.Text.Trim().Length > 0)
            {
                string text4 = textBox4.Text.Trim();
                if (!Files_To_Add.Contains(text4))
                    Files_To_Add.Add(text4);
            }
            if (textBox5.Text.Trim().Length > 0)
            {
                string text5 = textBox5.Text.Trim();
                if (!Files_To_Add.Contains(text5))
                    Files_To_Add.Add(text5);
            }

            Close();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
