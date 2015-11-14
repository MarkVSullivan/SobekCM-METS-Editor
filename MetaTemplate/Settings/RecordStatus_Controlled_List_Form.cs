#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public partial class RecordStatus_Controlled_List_Form : Form
    {
        public RecordStatus_Controlled_List_Form()
        {
            InitializeComponent();

            List<string> recordStatuses = MetaTemplate_UserSettings.METS_RecordStatus_List;
            foreach (string thisStatus in recordStatuses)
            {
                listView1.Items.Add(new ListViewItem(thisStatus));
            }
        }

        private void newButton_Button_Pressed(object sender, EventArgs e)
        {
            RecordStatus_Form newForm = new RecordStatus_Form();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                if (newForm.Status.Length > 0)
                {
                    listView1.Items.Add(new ListViewItem(newForm.Status));
                }
            }
        }

        private void editButton_Button_Pressed(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                RecordStatus_Form newForm = new RecordStatus_Form(listView1.SelectedItems[0].Text);
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (newForm.Status.Length > 0)
                    {
                        listView1.SelectedItems[0].Text = newForm.Status;
                    }
                    else
                    {
                        listView1.Items.Remove(listView1.SelectedItems[0]);
                    }
                }
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

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            // Collect the record statuses
            List<string> statuses = new List<string>();
            foreach (ListViewItem thisItem in listView1.Items)
            {
                statuses.Add(thisItem.Text);
            }
            MetaTemplate_UserSettings.METS_RecordStatus_List = statuses;

            // Close this form
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
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
    }
}
