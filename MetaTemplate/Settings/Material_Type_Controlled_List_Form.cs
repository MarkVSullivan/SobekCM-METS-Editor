#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class Material_Type_Controlled_List_Form : Form
    {
        public Material_Type_Controlled_List_Form()
        {
            InitializeComponent();

            // Add each material type
            foreach (Material_Type_Setting thisType in MetaTemplate_UserSettings.Material_Types_List)
            {
                listView1.Items.Add(new ListViewItem(new string[3] { thisType.Display_Name, thisType.MODS_Type, thisType.SobekCM_Genre }));
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
                Material_Type_Form showForm = new Material_Type_Form(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text);
                if (showForm.ShowDialog() == DialogResult.OK)
                {
                    if ((showForm.Display_Name.Length > 0) && (showForm.MODS_Type.Length > 0))
                    {
                        listView1.SelectedItems[0].SubItems[0].Text = showForm.Display_Name;
                        listView1.SelectedItems[0].SubItems[1].Text = showForm.MODS_Type;
                        listView1.SelectedItems[0].SubItems[2].Text = showForm.SobekCM_Genre;
                    }
                    else
                    {
                        MessageBox.Show("Resource types require both a template value and MODS mapping.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void newButton_Button_Pressed(object sender, EventArgs e)
        {
            Material_Type_Form showForm = new Material_Type_Form();
            if (showForm.ShowDialog() == DialogResult.OK)
            {
                if ((showForm.Display_Name.Length > 0) && (showForm.MODS_Type.Length > 0))
                {
                    listView1.Items.Add(new ListViewItem(new string[3] { showForm.Display_Name, showForm.MODS_Type, showForm.SobekCM_Genre }));
                }
                else
                {
                    MessageBox.Show("Resource types require both a template value and MODS mapping.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Collect the material types
            List<Material_Type_Setting> materialTypes = new List<Material_Type_Setting>();
            foreach (ListViewItem thisItem in listView1.Items)
            {
                materialTypes.Add(new Material_Type_Setting(thisItem.SubItems[0].Text, thisItem.SubItems[1].Text, thisItem.SubItems[2].Text));
            }
            MetaTemplate_UserSettings.Material_Types_List = materialTypes;

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

        private void ModsMenuItem_Click(object sender, EventArgs e)
        {
            // Add the MODS types as default
            List<Material_Type_Setting> materialTypes = new List<Material_Type_Setting>();
            materialTypes.Add(new Material_Type_Setting("text", "text", ""));
            materialTypes.Add(new Material_Type_Setting("cartographic", "cartographic", ""));
            materialTypes.Add(new Material_Type_Setting("notated music", "notated music", ""));
            materialTypes.Add(new Material_Type_Setting("sound recording", "sound recording", ""));
            materialTypes.Add(new Material_Type_Setting("sound recording-musical", "sound recording-musical", ""));
            materialTypes.Add(new Material_Type_Setting("sound recording-nonmusical", "sound recording-nonmusical", ""));
            materialTypes.Add(new Material_Type_Setting("still image", "still image", ""));
            materialTypes.Add(new Material_Type_Setting("moving image", "moving image", ""));
            materialTypes.Add(new Material_Type_Setting("three dimensional object", "three dimensional object", ""));
            materialTypes.Add(new Material_Type_Setting("software, multimedia", "software, multimedia", ""));
            materialTypes.Add(new Material_Type_Setting("mixed material", "mixed material", ""));
            MetaTemplate_UserSettings.Material_Types_List = materialTypes;

            listView1.Items.Clear();
            foreach (Material_Type_Setting thisType in materialTypes)
            {
                listView1.Items.Add(new ListViewItem(new string[3] { thisType.Display_Name, thisType.MODS_Type, thisType.SobekCM_Genre }));
            }
            editButton.Button_Enabled = false;
            deleteButton.Button_Enabled = false;
        }

        private void sobekMenuItem_Click(object sender, EventArgs e)
        {
            // Add the SobekCM types as default
            List<Material_Type_Setting> materialTypes = new List<Material_Type_Setting>();
            materialTypes.Add(new Material_Type_Setting("Aerial", "still image", "aerial photography"));
            materialTypes.Add(new Material_Type_Setting("Archival", "mixed material", "archival materials"));
            materialTypes.Add(new Material_Type_Setting("Artifact", "three dimensional object", ""));
            materialTypes.Add(new Material_Type_Setting("Audio", "sound recording", ""));
            materialTypes.Add(new Material_Type_Setting("Book", "text", ""));
            materialTypes.Add(new Material_Type_Setting("Map", "cartographic", ""));
            materialTypes.Add(new Material_Type_Setting("Newspaper", "text", "newspaper"));
            materialTypes.Add(new Material_Type_Setting("Photograph", "still image", ""));
            materialTypes.Add(new Material_Type_Setting("Serial", "text", "serial"));
            materialTypes.Add(new Material_Type_Setting("Video", "moving image", ""));
            MetaTemplate_UserSettings.Material_Types_List = materialTypes;

            listView1.Items.Clear();
            foreach (Material_Type_Setting thisType in materialTypes)
            {
                listView1.Items.Add(new ListViewItem(new string[3] { thisType.Display_Name, thisType.MODS_Type, thisType.SobekCM_Genre }));
            }
            editButton.Button_Enabled = false;
            deleteButton.Button_Enabled = false;
        }
    }
}
