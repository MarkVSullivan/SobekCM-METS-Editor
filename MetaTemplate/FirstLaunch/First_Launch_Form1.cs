#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.Behaviors;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_Form1 : Form
    {
        public First_Launch_Form1()
        {
            InitializeComponent();
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            if ((!sobekRadioButton.Checked) && (!fclaRadioButton.Checked) && (!standaloneRadioButton.Checked))
            {
                MessageBox.Show("Please select the option which most closely applies to your use of this application.\n\nThis will set some default values, which you will be able to change later.", "Select Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MetaTemplate_UserSettings.Show_Metadata_PostSave = false;


            if (fclaRadioButton.Checked)
            {
                MetaTemplate_UserSettings.Include_SobekCM_File_Section = false;
                MetaTemplate_UserSettings.Include_Checksums = true;
                MetaTemplate_UserSettings.Default_Template = "DUBLINCORE";
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.DublinCore;
                MetaTemplate_UserSettings.AddOns_Enabled = new List<string> { "FCLA" };

                // Set the record status to just COMPLETE for now
                List<string> recordStatus = new List<string>();
                recordStatus.Add("COMPLETE");
                MetaTemplate_UserSettings.METS_RecordStatus_List = recordStatus;

                // Add the Florida institutions by default
                List<Aggregation_Info> institutions = new List<Aggregation_Info>();
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("UF", "UF"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FAMU", "FAMU"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FSU", "FSU"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("UWF", "UWF"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("UNF", "UNF"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("UCF", "UCF"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("USF", "USF"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FIU", "FIU"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FAU", "FAU"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FGCU", "FGCU"));
                //institutions.Add(new SobekCM.Resource_Object.Behaviors.Aggregation_Info("FCLA", "FCLA"));



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
            }
            
            if ( sobekRadioButton.Checked )
            {
                MetaTemplate_UserSettings.Include_SobekCM_File_Section = true;
                MetaTemplate_UserSettings.Include_Checksums = false;
                MetaTemplate_UserSettings.Default_Template = "COMPLETE";
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.MODS;
                MetaTemplate_UserSettings.AddOns_Enabled = new List<string> { "SOBEKCM" };

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
            }

            if (standaloneRadioButton.Checked)
            {
                MetaTemplate_UserSettings.Include_SobekCM_File_Section = false;
                MetaTemplate_UserSettings.Include_Checksums = false;
                MetaTemplate_UserSettings.Default_Template = "COMPLETE";
                MetaTemplate_UserSettings.Bibliographic_Metadata = Bibliographic_Metadata_Enum.UNKNOWN;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void round_Button1_Button_Pressed(object sender, EventArgs e)
        {

        }
    }
}
