#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using SobekCM.Resource_Object.Configuration;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    public static class Metadata_Profile_Configurer
    {
        public static void Configure_Metadata_From_UserSettings()
        {
            string config_dir = Application.StartupPath + "\\config";
            string config_file = config_dir + "\\sobekcm_metadata.config";
            if ((Directory.Exists(config_dir)) && (File.Exists(config_file)))
            {
                Metadata_Configuration.Read_Metadata_Configuration(config_dir);
            }

            // Get the default METS profile
            METS_Writing_Profile metsProfile = Metadata_Configuration.Default_METS_Writing_Profile;

            
            // If this is null, create a new one and add to the configuration
            if (metsProfile == null)
            {
                metsProfile = new METS_Writing_Profile();
            }

            // Clear all profiles, to just leave the default
            Metadata_Configuration.Clear_METS_Writing_Profiles();

            // Add the default (possibly back)
            metsProfile.Profile_Name = "Default";
            metsProfile.Default_Profile = true;
            Metadata_Configuration.Add_METS_Writing_Profile(metsProfile);

            // Clear all the writing information here
            metsProfile.Clear();

            // Get the dictionary of all the metsSectionConfigs
            ReadOnlyCollection<METS_Section_ReaderWriter_Config> metsSectionConfigs = Metadata_Configuration.METS_Section_File_ReaderWriter_Configs;
            Dictionary<string, METS_Section_ReaderWriter_Config> metsSectionLookup = new Dictionary<string, METS_Section_ReaderWriter_Config>();
            foreach (METS_Section_ReaderWriter_Config config in metsSectionConfigs)
            {
                metsSectionLookup[config.ID] = config;
            }

            // Determine which sections should be written in the METS, based on the users settings
            List<string> addOns = MetaTemplate_UserSettings.AddOns_Enabled;

            switch (MetaTemplate_UserSettings.Bibliographic_Metadata)
            {
                case Bibliographic_Metadata_Enum.DublinCore:
                    metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["DC"]);
                    break;

                case Bibliographic_Metadata_Enum.MODS:
                    metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["MODS"]);
                    break;

                case Bibliographic_Metadata_Enum.MarcXML:
                    metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["MARCXML"]);
                    break;
            }

            metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["GML"]);


            // Always add these
            if (addOns.Contains("FCLA"))
            {
                metsProfile.Add_Package_Level_AmdSec_Writer_Config(metsSectionLookup["DAITSS"]);
            }

            if (addOns.Contains("VRACORE"))
            {
                metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["VRACORE"]);
            }

            if (addOns.Contains("DARWINCORE"))
            {
                metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["DARWIN"]);
            }

            if (addOns.Contains("ETD"))
            {
                metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["ETD"]);
            }

            if (addOns.Contains("SOBEKCM"))
            {
                metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["SOBEK1"]);
                metsProfile.Add_Package_Level_DmdSec_Writer_Config(metsSectionLookup["SOBEK2"]);
            }
            if (MetaTemplate_UserSettings.Include_SobekCM_File_Section)
                metsProfile.Add_File_Level_AmdSec_Writer_Config(metsSectionLookup["SOBEK3"]);



        }
    }
}
