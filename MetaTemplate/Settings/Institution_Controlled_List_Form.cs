#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SobekCM.Resource_Object.Behaviors;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class Institution_Controlled_List_Form : Form
    {
        public Institution_Controlled_List_Form()
        {
            InitializeComponent();

            // Add each institution
            foreach (Aggregation_Info thisInstitution in MetaTemplate_UserSettings.Institutions_List)
            {
                listView1.Items.Add(new ListViewItem(new string[2] { thisInstitution.Code, thisInstitution.Name }));
            }
        }

        private void deleteButton_Button_Pressed(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                deleteButton.Button_Enabled = false;
                editButton.Button_Enabled = false;
            }
        }

        private void editButton_Button_Pressed(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Institution_Form showForm = new Institution_Form( listView1.SelectedItems[0].SubItems[0].Text,  listView1.SelectedItems[0].SubItems[1].Text );
                if (showForm.ShowDialog() == DialogResult.OK)
                {
                    if ((showForm.Code.Length > 0) && (showForm.Institution_Name.Length > 0))
                    {
                        listView1.SelectedItems[0].SubItems[0].Text = showForm.Code;
                        listView1.SelectedItems[0].SubItems[1].Text = showForm.Institution_Name;
                    }
                    else
                    {
                        MessageBox.Show("Institutions require both a code/abbreviation and an institutional name", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void newButton_Button_Pressed(object sender, EventArgs e)
        {
            Institution_Form showForm = new Institution_Form();
            if (showForm.ShowDialog() == DialogResult.OK)
            {
                if ((showForm.Code.Length > 0) && (showForm.Institution_Name.Length > 0))
                {
                    listView1.Items.Add(new ListViewItem(new string[2] { showForm.Code, showForm.Institution_Name }));
                }
                else
                {
                    MessageBox.Show("Institutions require both a code/abbreviation and an institutional name", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Collect the institutions
            List<Aggregation_Info> institutions = new List<Aggregation_Info>();
            foreach (ListViewItem thisItem in listView1.Items)
            {
                institutions.Add(new Aggregation_Info(thisItem.SubItems[0].Text, thisItem.SubItems[1].Text));
            }
            MetaTemplate_UserSettings.Institutions_List = institutions;

            Close();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                deleteButton.Button_Enabled = true;
                editButton.Button_Enabled = true;
            }
            else
            {
                deleteButton.Button_Enabled = false;
                editButton.Button_Enabled = false;
            }
        }

        private void fclaMenuItem_Click(object sender, EventArgs e)
        {
            // Add the Florida institutions by default
            List<Aggregation_Info> institutions = new List<Aggregation_Info>();
            institutions.Add(new Aggregation_Info("UF", "University of Florida"));
            institutions.Add(new Aggregation_Info("FAMU", "Florida Agricultural & Mechanical University"));
            institutions.Add(new Aggregation_Info("FSU", "Florida State University"));
            institutions.Add(new Aggregation_Info("UWF", "University of West Florida"));
            institutions.Add(new Aggregation_Info("UNF", "University of North Florida"));
            institutions.Add(new Aggregation_Info("UCF", "University of Central Florida"));
            institutions.Add(new Aggregation_Info("USF", "University of South Florida"));
            institutions.Add(new Aggregation_Info("FIU", "Florida International University"));
            institutions.Add(new Aggregation_Info("FAU", "Florida Atlantic University"));
            institutions.Add(new Aggregation_Info("FGCU", "Florida Gulf Coast University"));
            institutions.Add(new Aggregation_Info("FCLA", "Florida Center for Library Automation"));
            MetaTemplate_UserSettings.Institutions_List = institutions;


            // Add each institution
            listView1.Items.Clear();
            foreach (Aggregation_Info thisInstitution in MetaTemplate_UserSettings.Institutions_List)
            {
                listView1.Items.Add(new ListViewItem(new string[2] { thisInstitution.Code, thisInstitution.Name }));
            }
        }

    }
}
