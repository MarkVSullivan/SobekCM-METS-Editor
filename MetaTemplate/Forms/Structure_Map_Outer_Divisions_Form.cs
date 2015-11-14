#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.Resource_Object.Divisions;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Structure_Map_Outer_Divisions_Form : Form
    {
        private Division_Info BibDivInfo;

        public Structure_Map_Outer_Divisions_Form(Division_Info BibDivInfo)
        {
            InitializeComponent();

            DialogResult = DialogResult.No;
            this.BibDivInfo = BibDivInfo;

            // DIsplay any existing outer divisions
            ReadOnlyCollection<Outer_Division_Info> outerDivs = BibDivInfo.Outer_Divisions;
            if (outerDivs.Count > 0)
            {
                type1TextBox.Text = outerDivs[0].Type;
                label1TextBox.Text = outerDivs[0].Label;
                order1TextBox.Text = outerDivs[0].OrderLabel.ToString();
            }
            if (outerDivs.Count > 1)
            {
                type2TextBox.Text = outerDivs[1].Type;
                label2TextBox.Text = outerDivs[1].Label;
                order2TextBox.Text = outerDivs[1].OrderLabel.ToString();
            }
            if (outerDivs.Count > 2)
            {
                type3TextBox.Text = outerDivs[2].Type;
                label3TextBox.Text = outerDivs[2].Label;
                order3TextBox.Text = outerDivs[2].OrderLabel.ToString();
            }
            if (outerDivs.Count > 3)
            {
                type4TextBox.Text = outerDivs[3].Type;
                label4TextBox.Text = outerDivs[3].Label;
                order4TextBox.Text = outerDivs[3].OrderLabel.ToString();
            }
            if (outerDivs.Count > 4)
            {
                type5TextBox.Text = outerDivs[4].Type;
                label5TextBox.Text = outerDivs[4].Label;
                order5TextBox.Text = outerDivs[4].OrderLabel.ToString();
            }
        }

        public Structure_Map_Outer_Divisions_Form()
        {
            InitializeComponent();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            BibDivInfo.Clear_Outer_Divisions();


            if ((type1TextBox.Text.Trim().Length > 0) && ((label1TextBox.Text.Trim().Length > 0) && (order1TextBox.Text.Trim().Length > 0)))
            {
                string type1 = type1TextBox.Text.Trim();
                string label1 = label1TextBox.Text.Trim();
                int order1 = 0;
                Int32.TryParse(order1TextBox.Text, out order1);
                BibDivInfo.Add_Outer_Division(label1, order1, type1);
            }

            if ((type2TextBox.Text.Trim().Length > 0) && ((label2TextBox.Text.Trim().Length > 0) && (order2TextBox.Text.Trim().Length > 0)))
            {
                string type2 = type2TextBox.Text.Trim();
                string label2 = label2TextBox.Text.Trim();
                int order2 = 0;
                Int32.TryParse(order2TextBox.Text, out order2);
                BibDivInfo.Add_Outer_Division(label2, order2, type2);
            }

            if ((type3TextBox.Text.Trim().Length > 0) && ((label3TextBox.Text.Trim().Length > 0) && (order3TextBox.Text.Trim().Length > 0)))
            {
                string type3 = type3TextBox.Text.Trim();
                string label3 = label3TextBox.Text.Trim();
                int order3 = 0;
                Int32.TryParse(order3TextBox.Text, out order3);
                BibDivInfo.Add_Outer_Division(label3, order3, type3);
            }

            if ((type4TextBox.Text.Trim().Length > 0) && ((label4TextBox.Text.Trim().Length > 0) && (order4TextBox.Text.Trim().Length > 0)))
            {
                string type4 = type4TextBox.Text.Trim();
                string label4 = label4TextBox.Text.Trim();
                int order4 = 0;
                Int32.TryParse(order4TextBox.Text, out order4);
                BibDivInfo.Add_Outer_Division(label4, order4, type4);
            }

            if ((type5TextBox.Text.Trim().Length > 0) && ((label5TextBox.Text.Trim().Length > 0) && (order5TextBox.Text.Trim().Length > 0)))
            {
                string type5 = type5TextBox.Text.Trim();
                string label5 = label5TextBox.Text.Trim();
                int order5 = 0;
                Int32.TryParse(order5TextBox.Text, out order5);
                BibDivInfo.Add_Outer_Division(label5, order5, type5);
            }

            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
