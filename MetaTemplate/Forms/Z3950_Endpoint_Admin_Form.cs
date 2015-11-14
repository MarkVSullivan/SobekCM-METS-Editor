#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.MARC;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    public partial class Z3950_Endpoint_Admin_Form : Form
    {
        public Z3950_Endpoint_Admin_Form()
        {
            InitializeComponent();

            refresh_endpoints();
        }

        private void refresh_endpoints()
        {
            listView1.Items.Clear();
            ReadOnlyCollection<string> endpoints = MetaTemplate_UserSettings.Z3950_Endpoint_Names;
            foreach (string thisEndpointName in endpoints)
            {
                Z3950_Endpoint thisEndpoint = MetaTemplate_UserSettings.Get_Endpoint_By_Name(thisEndpointName);
                ListViewItem newItem = new ListViewItem(new[] { thisEndpointName, thisEndpoint.URI, thisEndpoint.Port.ToString(), thisEndpoint.Database_Name });
                listView1.Items.Add(newItem);
            }

            deleteButton.Button_Enabled = false;
            editButton.Button_Enabled = false;
        }

        private void closeRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Button_Pressed(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string name = listView1.SelectedItems[0].SubItems[0].Text;
                MetaTemplate_UserSettings.Delete_Z3950_Endpoint(name);
                MetaTemplate_UserSettings.Save();
            }

            refresh_endpoints();
        }

        private void editButton_Button_Pressed(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string name = listView1.SelectedItems[0].SubItems[0].Text;
                Z3950_Endpoint endpoint = MetaTemplate_UserSettings.Get_Endpoint_By_Name(name);
                if (endpoint != null)
                {
                    Z3950_Endpoint_Form editForm = new Z3950_Endpoint_Form(endpoint, false );
                    Hide();
                    editForm.ShowDialog();
                    Show();
                    if (editForm.Endpoint != null)
                    {
                        MetaTemplate_UserSettings.Add_Z3950_Endpoint(editForm.Endpoint);
                        MetaTemplate_UserSettings.Save();
                    }
                }
            }

            refresh_endpoints();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
