﻿#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using SobekCM.Resource_Object.Bib_Info;
using SobekCM.Resource_Object.Metadata_Modules;

#endregion

namespace SobekCM.Resource_Object
{
    public class MetadataDescribableBase : iMetadataDescribable
    {
        protected Bibliographic_Info bibInfo;
        protected Dictionary<string, iMetadata_Module> metadataModules;
        protected List<Unanalyzed_METS_Section> unanalyzed_amdsecs;
        protected List<Unanalyzed_METS_Section> unanalyzed_dmdsecs;

        /// <summary> ID's of any descriptive metadata sections included while writing a METS file </summary>
        /// <remarks> This is not READ or used except during the METS writing process </remarks>
        internal string DMDID { get; set;  }

        /// <summary> ID's of any administrative metadata sections included while writing a METS file </summary>
        /// <remarks> This is not READ or used except during the METS writing process </remarks>
        internal string ADMID { get; set; }

        #region Code to cover metadata module extensions

        /// <summary> Gets the number of metadata module extensions included in this
        /// digital resource  </summary>
        /// <remarks> These methods allows extensibility since any metadata plug-in can implement
        /// the iMetadata_Module interface and be added here. </remarks>
        public int Metadata_Modules_Count
        {
            get
            {
                if (metadataModules == null)
                    return 0;
                else return metadataModules.Count;
            }
        }

        /// <summary> Gets the collection of all included metadata module extensions </summary>
        /// <remarks> These methods allows extensibility since any metadata plug-in can implement
        /// the iMetadata_Module interface and be added here. </remarks>
        public ReadOnlyCollection<iMetadata_Module> All_Metadata_Modules
        {
            get
            {
                List<iMetadata_Module> returnList = new List<iMetadata_Module>();
                if (metadataModules != null)
                {
                    returnList.AddRange(metadataModules.Values);
                }
                return new ReadOnlyCollection<iMetadata_Module>(returnList);
            }
        }

        /// <summary> Gets a metadata module extension by name from this digital resource </summary>
        /// <param name="Module_Name"> Name of the module to retrieve </param>
        /// <returns>Requested metadata module, or NULL if it doesn't exist </returns>
        /// <remarks>These methods allows extensibility since any metadata plug-in can implement
        /// the iMetadata_Module interface and be added here. </remarks>
        public iMetadata_Module Get_Metadata_Module(string Module_Name)
        {
            if ((metadataModules != null) && (metadataModules.ContainsKey(Module_Name)))
                return metadataModules[Module_Name];
            return null;
        }

        /// <summary> Adds a new metadata module extension to this digital resource </summary>
        /// <param name="Module_Name"> Name of this module </param>
        /// <param name="New_Module">New metadata module to add to this digital resource</param>
        /// <remarks> These methods allows extensibility since any metadata plug-in can implement
        /// the iMetadata_Module interface and be added here. </remarks>
        public void Add_Metadata_Module(string Module_Name, iMetadata_Module New_Module)
        {
            if (metadataModules == null)
                metadataModules = new Dictionary<string, iMetadata_Module>();
            metadataModules[Module_Name] = New_Module;
        }

        #endregion

        #region Code to cover any unanalyzed DMDSEC or AMDSEC portions of the original METS file

        /// <summary> Returns the number of unanalyzed DMDSECs (descriptive metadata sections) in the original METS file </summary>
        public int Unanalyzed_DMDSEC_Count
        {
            get
            {
                if (unanalyzed_dmdsecs == null)
                    return 0;
                else
                    return unanalyzed_dmdsecs.Count;
            }
        }

        /// <summary> Gets the collection of unanalyzed DMDSECs (descriptive metadata sections) in the original METS file </summary>
        public List<Unanalyzed_METS_Section> Unanalyzed_DMDSECs
        {
            get { return unanalyzed_dmdsecs; }
        }

        /// <summary> Returns the number of unanalyzed AMDSECs (administrative metadata sections) in the original METS file </summary>
        public int Unanalyzed_AMDSEC_Count
        {
            get
            {
                if (unanalyzed_amdsecs == null)
                    return 0;
                else
                    return unanalyzed_amdsecs.Count;
            }
        }

        /// <summary> Gets the collection of unanalyzed AMDSECs (administrative metadata sections) in the original METS file </summary>
        public List<Unanalyzed_METS_Section> Unanalyzed_AMDSECs
        {
            get { return unanalyzed_amdsecs; }
        }

        /// <summary> Adds information about an unanalyzed DMDSEC (descriptive metadata section) in the METS file, to be preserved as is for later writing </summary>
        /// <param name="Section_Attributes"> List of attributes in the top-level definition of this section </param>
        /// <param name="ID"> ID for the top-level section (also included in the attribute list) </param>
        /// <param name="Inner_XML"> Complete XML include in this unanalyzed METS section </param>
        public void Add_Unanalyzed_DMDSEC(List<KeyValuePair<string, string>> Section_Attributes, string ID, string Inner_XML)
        {
            if (unanalyzed_dmdsecs == null)
                unanalyzed_dmdsecs = new List<Unanalyzed_METS_Section>();

            unanalyzed_dmdsecs.Add(new Unanalyzed_METS_Section(Section_Attributes, ID, Inner_XML));
        }

        /// <summary> Adds information about an unanalyzed DMDSEC (descriptive metadata section) in the METS file, to be preserved as is for later writing </summary>
        /// <param name="METS_Section"> Fully built unanalyzed section object </param>
        public void Add_Unanalyzed_DMDSEC(Unanalyzed_METS_Section METS_Section)
        {
            if (unanalyzed_dmdsecs == null)
                unanalyzed_dmdsecs = new List<Unanalyzed_METS_Section>();

            unanalyzed_dmdsecs.Add(METS_Section);
        }

        /// <summary> Adds information about an unanalyzed AMDSEC (administrative metadata section) in the METS file, to be preserved as is for later writing </summary>
        /// <param name="Section_Attributes"> List of attributes in the top-level definition of this section </param>
        /// <param name="ID"> ID for the top-level section (also included in the attribute list) </param>
        /// <param name="Inner_XML"> Complete XML include in this unanalyzed METS section </param>
        public void Add_Unanalyzed_AMDSEC(List<KeyValuePair<string, string>> Section_Attributes, string ID, string Inner_XML)
        {
            if (unanalyzed_amdsecs == null)
                unanalyzed_amdsecs = new List<Unanalyzed_METS_Section>();

            unanalyzed_amdsecs.Add(new Unanalyzed_METS_Section(Section_Attributes, ID, Inner_XML));
        }

        /// <summary> Adds information about an unanalyzed AMDSEC (administrative metadata section) in the METS file, to be preserved as is for later writing </summary>
        /// <param name="METS_Section"> Fully built unanalyzed section object </param>
        public void Add_Unanalyzed_AMDSEC(Unanalyzed_METS_Section METS_Section)
        {
            if (unanalyzed_amdsecs == null)
                unanalyzed_amdsecs = new List<Unanalyzed_METS_Section>();

            unanalyzed_amdsecs.Add(METS_Section);
        }

        #endregion

        #region Code to address bibliographic information associated with thie node

        /// <summary> Flag indicates if the bibliographic data object has been built here and contains data</summary>
        public bool hasBibliographicData
        {
            get { return ((bibInfo != null) && (bibInfo.hasData)); }
        }

        /// <summary> Gets the bibliographic information associated with this node  </summary>
        /// <remarks> NOTE!! Even if no bib info exists for this item, calling this method will
        /// create the object, which is fairly memory intensive.  You should always call the
        /// <see cref="hasBibliographicData" /> method first. </remarks>
        public Bibliographic_Info Bib_Info
        {
            get { return bibInfo ?? (bibInfo = new Bibliographic_Info()); }
        }

        #endregion
    }
}