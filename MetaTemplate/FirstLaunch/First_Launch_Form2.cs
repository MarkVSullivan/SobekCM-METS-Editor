#region Using directives

using System;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form2 : Form
    {
        public First_Launch_Form2()
        {
            InitializeComponent();

            switch (MetaTemplate_UserSettings.Bibliographic_Metadata)
            {
                case Bibliographic_Metadata_Enum.DublinCore:
                    dublinCoreRadioButton.Checked = true;
                    break;

                case Bibliographic_Metadata_Enum.MarcXML:
                    marcXmlRadioButton.Checked = true;
                    break;

                case Bibliographic_Metadata_Enum.MODS:
                    modsRadioButton.Checked = true;
                    break;
            }
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            if ((!dublinCoreRadioButton.Checked) && (!marcXmlRadioButton.Checked) && (!modsRadioButton.Checked))
            {
                MessageBox.Show("Please select the bibliograhpic schema to use when creating metadata for your resource.\n\nThis can always be changed later through the preferences menu.", "Select Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dublinCoreRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.DublinCore;

            if (modsRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.MODS;

            if (marcXmlRadioButton.Checked)
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.MarcXML;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }




    }
}
