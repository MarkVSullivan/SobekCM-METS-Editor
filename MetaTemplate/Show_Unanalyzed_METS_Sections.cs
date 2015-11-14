#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor
{
    public partial class Show_Unanalyzed_METS_Sections : Form
    {
        public Show_Unanalyzed_METS_Sections( SobekCM_Item Item_To_Show )
        {
            InitializeComponent();

            bool first = true;
            if (Item_To_Show.Unanalyzed_DMDSEC_Count > 0)
            {
                foreach (Unanalyzed_METS_Section thisSection in Item_To_Show.Unanalyzed_DMDSECs)
                {
                    if (!first)
                        richTextBox1.AppendText("-------------------------------------------------------------\n\n");

                    richTextBox1.AppendText("<METS:dmdSec");
                    foreach (KeyValuePair<string, string> attribute in thisSection.Section_Attributes)
                    {
                        richTextBox1.AppendText(" " + attribute.Key + "=\"" + attribute.Value + "\"");
                    }
                    richTextBox1.AppendText(">\n");
                    richTextBox1.AppendText(thisSection.Inner_XML + "\n" );
                    richTextBox1.AppendText("</METS:dmdSec>\n\n");
                    first = false;
                }
            }

            if (Item_To_Show.Unanalyzed_AMDSEC_Count > 0)
            {
                foreach (Unanalyzed_METS_Section thisSection in Item_To_Show.Unanalyzed_AMDSECs)
                {
                    if (!first)
                        richTextBox1.AppendText("-------------------------------------------------------------\n\n");

                    richTextBox1.AppendText("<METS:amdSec");
                    foreach (KeyValuePair<string, string> attribute in thisSection.Section_Attributes)
                    {
                        richTextBox1.AppendText(" " + attribute.Key + "=\"" + attribute.Value + "\"");
                    }
                    richTextBox1.AppendText(">\n");
                    richTextBox1.AppendText(thisSection.Inner_XML );
                    richTextBox1.AppendText("</METS:amdSec>\n\n");
                    first = false;
                }
            }
        }

        private void closeRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
