#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SobekCM.Resource_Object.OAI;

#endregion

namespace SobekCM.METS_Editor.OAI
{
    public partial class Repository_Details_Form : Form
    {
        public Repository_Details_Form( OAI_Repository_Information Repository )
        {
            InitializeComponent();

            nameLabel.Text = Repository.Name;
            idLabel.Text = Repository.Repository_Identifier;
            urlLabel.Text = Repository.Base_URL;
            protocolLabel.Text = Repository.Protocol_Version;
            granularityLabel.Text = Repository.Granularity;
            deleteRecordLabel.Text = Repository.Deleted_Record;
            delimiterLabel.Text = Repository.Delimiter;
            datestampLabel.Text = Repository.Earliest_Date_Stamp;
            emailLabel.Text = Repository.Admin_Email;
            sampleIdLabel.Text = Repository.Sample_Identifier;

            if (Repository.Metadata_Formats.Count > 0)
            {
                StringBuilder builder = new StringBuilder(Repository.Metadata_Formats[0]);
                for (int i = 1; i < Repository.Metadata_Formats.Count; i++)
                {
                    builder.Append( ", " + Repository.Metadata_Formats[i]);
                }
                metadataLabel.Text = builder.ToString();
            }
            else
            {
                metadataLabel.Text = "(none)";
            }

            foreach (KeyValuePair<string, string> thisSet in Repository.Sets)
            {
                listView1.Items.Add( new ListViewItem( new[] { thisSet.Key, thisSet.Value }));
            }

        }

        private void closeButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }




 
    }
}
