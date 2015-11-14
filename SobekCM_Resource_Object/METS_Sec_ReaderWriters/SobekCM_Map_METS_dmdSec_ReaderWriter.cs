﻿#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.Maps;

#endregion

namespace SobekCM.Resource_Object.METS_Sec_ReaderWriters
{
    public class SobekCM_Map_METS_dmdSec_ReaderWriter : XML_Writing_Base_Type, iPackage_dmdSec_ReaderWriter
    {
        #region iPackage_dmdSec_ReaderWriter Members

        /// <summary> Flag indicates if this active reader/writer will write a dmdSec </summary>
        /// <param name="METS_Item"> Package with all the metadata to save</param>
        /// <param name="Options"> Dictionary of any options which this METS section writer may utilize</param>
        /// <returns> TRUE if the package has data to be written, otherwise fALSE </returns>
        public bool Include_dmdSec(SobekCM_Item METS_Item, Dictionary<string, object> Options)
        {
            // Ensure this metadata module extension exists and has data
            Map_Info mapInfo = METS_Item.Get_Metadata_Module(GlobalVar.SOBEKCM_MAPS_METADATA_MODULE_KEY) as Map_Info;
            if ((mapInfo == null) || (!mapInfo.hasData))
                return false;
            return true;
        }

        /// <summary> Writes the dmdSec for the entire package to the text writer </summary>
        /// <param name="Output_Stream">Stream to which the formatted text is written </param>
        /// <param name="METS_Item">Package with all the metadata to save</param>
        /// <param name="Options"> Dictionary of any options which this METS section writer may utilize</param>
        /// <returns>TRUE if successful, otherwise FALSE </returns>
        public bool Write_dmdSec(TextWriter Output_Stream, SobekCM_Item METS_Item, Dictionary<string, object> Options)
        {
            // Ensure this metadata module extension exists and has data
            Map_Info mapInfo = METS_Item.Get_Metadata_Module(GlobalVar.SOBEKCM_MAPS_METADATA_MODULE_KEY) as Map_Info;
            if ((mapInfo == null) || (!mapInfo.hasData))
                return true;

            // Now, collect the data to include here
            string map_data = mapInfo.ToXML("map:", false);
            Output_Stream.Write(map_data);
            return true;
        }

        /// <summary> Flag indicates if this active reader/writer needs to append schema reference information
        /// to the METS XML header by analyzing the contents of the digital resource item </summary>
        /// <param name="METS_Item"> Package with all the metadata to save</param>
        /// <returns> TRUE if the schema should be attached, otherwise fALSE </returns>
        public bool Schema_Reference_Required_Package(SobekCM_Item METS_Item)
        {
            Map_Info mapInfo = METS_Item.Get_Metadata_Module(GlobalVar.SOBEKCM_MAPS_METADATA_MODULE_KEY) as Map_Info;
            if (mapInfo == null)
                return false;

            return mapInfo.hasData;
        }

        /// <summary> Returns the schema namespace (xmlns) information to be written in the XML/METS Header</summary>
        /// <param name="METS_Item"> Package with all the metadata to save</param>
        /// <returns> Formatted schema namespace info for the METS header</returns>
        public string[] Schema_Namespace(SobekCM_Item METS_Item)
        {
            return new string[] {"map=\"http://digital.uflib.ufl.edu/metadata/ufdc_map/\""};
        }

        /// <summary> Returns the schema location information to be written in the XML/METS Header</summary>
        /// <param name="METS_Item"> Package with all the metadata to save</param>
        /// <returns> Formatted schema location for the METS header</returns>
        public string[] Schema_Location(SobekCM_Item METS_Item)
        {
            return new string[] {"    http://digital.uflib.ufl.edu/metadata/ufdc_map/\r\n    http://digital.uflib.ufl.edu/metadata/ufdc_map/ufdc_map.xsd"};
        }

        #endregion

        #region Methods to read the map (features/streets/person/corporation authority information

        /// <summary> Reads the dmdSec at the current position in the XmlTextReader and associates it with the 
        /// entire package  </summary>
        /// <param name="Input_XmlReader"> Open XmlReader from which to read the metadata </param>
        /// <param name="Return_Package"> Package into which to read the metadata</param>
        /// <param name="Options"> Dictionary of any options which this METS section reader may utilize</param>
        /// <returns> TRUE if successful, otherwise FALSE</returns>
        public bool Read_dmdSec(XmlReader Input_XmlReader, SobekCM_Item Return_Package, Dictionary<string, object> Options)
        {
            // Ensure this metadata module extension exists
            Map_Info mapInfo = Return_Package.Get_Metadata_Module(GlobalVar.SOBEKCM_MAPS_METADATA_MODULE_KEY) as Map_Info;
            if (mapInfo == null)
            {
                mapInfo = new Map_Info();
                Return_Package.Add_Metadata_Module(GlobalVar.SOBEKCM_MAPS_METADATA_MODULE_KEY, mapInfo);
            }

            // Try to get the attributes from here first
            if (Input_XmlReader.MoveToAttribute("id"))
                mapInfo.MapID = Input_XmlReader.Value;

            // Step through each field
            while (Input_XmlReader.Read())
            {
                if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:ufdc_map"))
                    return true;

                if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:indexes":
                            read_map_indexes(Input_XmlReader, mapInfo);
                            break;

                        case "map:entities":
                            read_map_entities(Input_XmlReader, mapInfo);
                            break;

                        case "map:sheets":
                            read_map_sheets(Input_XmlReader, mapInfo);
                            break;
                    }
                }
            }

            // Return false since this read all the way to the end of the steam
            return false;
        }

        private static void read_map_indexes(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            string title = String.Empty;
            string file = String.Empty;
            string html = String.Empty;
            string type = String.Empty;
            string id_string = String.Empty;

            while (Input_XmlReader.Read())
            {
                if (Input_XmlReader.NodeType == XmlNodeType.EndElement)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:indexes":
                            return;

                        case "map:image":
                            try
                            {
                                long id = Convert.ToInt64(id_string.ToUpper().Replace("INDE", "").Replace("X", ""));
                                mapInfo.New_Index(id, title, file, html, type);
                            }
                            catch
                            {
                            }

                            // Clear the variables
                            title = String.Empty;
                            file = String.Empty;
                            html = String.Empty;
                            type = String.Empty;
                            id_string = String.Empty;
                            break;
                    }
                }
                else if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:image":
                            if (Input_XmlReader.MoveToAttribute("type"))
                                type = Input_XmlReader.Value;
                            if (Input_XmlReader.MoveToAttribute("id"))
                                id_string = Input_XmlReader.Value;
                            break;

                        case "map:title":
                            Input_XmlReader.Read();
                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                title = Input_XmlReader.Value;
                            }
                            break;

                        case "map:file":
                            Input_XmlReader.Read();
                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                file = Input_XmlReader.Value;
                            }
                            break;

                        case "map:html":
                            Input_XmlReader.Read();
                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                html = Input_XmlReader.Value;
                            }
                            break;
                    }
                }
            }
        }

        private static void read_map_entities(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            while (Input_XmlReader.Read())
            {
                if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:entities"))
                {
                    return;
                }

                if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:street":
                            read_map_street(Input_XmlReader, mapInfo);
                            break;

                        case "map:feature":
                            read_map_feature(Input_XmlReader, mapInfo);
                            break;

                        case "map:person":
                            read_map_person(Input_XmlReader, mapInfo);
                            break;

                        case "map:corporation":
                            read_map_corporation(Input_XmlReader, mapInfo);
                            break;
                    }
                }
            }
        }

        private static void read_map_street(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            string id_string = String.Empty;
            string name = String.Empty;
            if (Input_XmlReader.MoveToAttribute("id"))
                id_string = Input_XmlReader.Value;
            if (Input_XmlReader.MoveToAttribute("name"))
                name = Input_XmlReader.Value;

            // Determine the street id
            long streetid = -1;
            try
            {
                streetid = Convert.ToInt64(id_string.Replace("STR", "").Replace("E", "").Replace("T", ""));
            }
            catch
            {
            }

            while (Input_XmlReader.Read())
            {
                if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:street"))
                    return;

                if ((Input_XmlReader.NodeType == XmlNodeType.Element) && (Input_XmlReader.Name == "map:segment"))
                {
                    long sheetid = -1;
                    long start = -1;
                    long end = -1;
                    string direction = String.Empty;
                    string side = String.Empty;
                    string desc = String.Empty;

                    for (int i = 0; i < Input_XmlReader.AttributeCount; i++)
                    {
                        Input_XmlReader.MoveToAttribute(i);
                        switch (Input_XmlReader.Name)
                        {
                            case "sheetid":
                                try
                                {
                                    sheetid = Convert.ToInt64(Input_XmlReader.Value.Replace("MS", "").Replace("SHEET", ""));
                                }
                                catch
                                {
                                }
                                break;

                            case "side":
                                side = Input_XmlReader.Value;
                                break;

                            case "direction":
                                direction = Input_XmlReader.Value;
                                break;

                            case "start":
                                try
                                {
                                    start = Convert.ToInt64(Input_XmlReader.Value.Trim());
                                }
                                catch
                                {
                                }
                                break;

                            case "end":
                                try
                                {
                                    start = Convert.ToInt64(Input_XmlReader.Value.Trim());
                                }
                                catch
                                {
                                }
                                break;
                        }
                    }

                    Input_XmlReader.MoveToElement();
                    if (!Input_XmlReader.IsEmptyElement)
                    {
                        Input_XmlReader.Read();
                        desc = Input_XmlReader.Value;
                    }

                    // Add this street segment information
                    if (sheetid > 0)
                    {
                        mapInfo.Add_Street(streetid, sheetid, name, desc, direction, start, end, side);
                    }
                }
            }
        }

        private static void read_map_feature(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            string id_string = String.Empty;
            string name = String.Empty;
            string type = String.Empty;
            if (Input_XmlReader.MoveToAttribute("id"))
                id_string = Input_XmlReader.Value;
            if (Input_XmlReader.MoveToAttribute("name"))
                name = Input_XmlReader.Value;
            if (Input_XmlReader.MoveToAttribute("type"))
                type = Input_XmlReader.Value;

            // Determine the feature id
            long featid = -1;
            try
            {
                featid = Convert.ToInt64(id_string.Replace("FEAT", "").Replace("U", "").Replace("R", "").Replace("E", ""));
            }
            catch
            {
            }

            // Add this feature
            Map_Info_Tables.FeatureRow thisFeature = mapInfo.Add_Feature(featid, name, type);

            while (Input_XmlReader.Read())
            {
                if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:feature"))
                    return;

                if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:desc":
                            thisFeature.Description = Input_XmlReader.Value;
                            break;

                        case "map:coordinates":
                            for (int i = 0; i < Input_XmlReader.AttributeCount; i++)
                            {
                                Input_XmlReader.MoveToAttribute(i);
                                switch (Input_XmlReader.Name)
                                {
                                    case "units":
                                        thisFeature.Units = Input_XmlReader.Value;
                                        break;

                                    case "latitude":
                                        thisFeature.Latitude = Input_XmlReader.Value;
                                        break;

                                    case "longitude":
                                        thisFeature.Longitude = Input_XmlReader.Value;
                                        break;
                                }
                            }
                            break;

                        case "map:sheetref":
                            long x = -1;
                            long y = -1;
                            long sheetid = -1;
                            for (int i = 0; i < Input_XmlReader.AttributeCount; i++)
                            {
                                Input_XmlReader.MoveToAttribute(i);
                                switch (Input_XmlReader.Name)
                                {
                                    case "x":
                                        try
                                        {
                                            x = Convert.ToInt64(Input_XmlReader.Value);
                                        }
                                        catch
                                        {
                                        }
                                        break;

                                    case "y":
                                        try
                                        {
                                            y = Convert.ToInt64(Input_XmlReader.Value);
                                        }
                                        catch
                                        {
                                        }
                                        break;

                                    case "sheetid":
                                        try
                                        {
                                            sheetid = Convert.ToInt64(Input_XmlReader.Value.Replace("MS", "").Replace("SHEET", ""));
                                        }
                                        catch
                                        {
                                        }
                                        break;
                                }
                            }

                            if (sheetid > 0)
                            {
                                mapInfo.Add_Feature_Sheet_Link(thisFeature.FeatureID, sheetid, x, y);
                            }
                            break;

                        case "map:corpref":
                            if (Input_XmlReader.MoveToAttribute("corpid"))
                            {
                                try
                                {
                                    long corpid = Convert.ToInt64(Input_XmlReader.Value.Replace("COR", "").Replace("P", ""));
                                    mapInfo.Add_Feature_Corp_Link(thisFeature.FeatureID, corpid);
                                }
                                catch
                                {
                                }
                            }
                            break;

                        case "map:persid":
                            string reftype = String.Empty;
                            if (Input_XmlReader.MoveToAttribute("reftype"))
                                reftype = Input_XmlReader.Value;
                            if (Input_XmlReader.MoveToAttribute("persid"))
                            {
                                try
                                {
                                    long persid = Convert.ToInt64(Input_XmlReader.Value.Replace("PER", "").Replace("S", "").Replace("O", "").Replace("N", ""));
                                    mapInfo.Add_Feature_Person_Link(thisFeature.FeatureID, persid, reftype);
                                }
                                catch
                                {
                                }
                            }
                            break;
                    }
                }
            }
        }

        private static void read_map_person(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            if (Input_XmlReader.MoveToAttribute("id"))
            {
                try
                {
                    long personid = Convert.ToInt64(Input_XmlReader.Value.Replace("PER", "").Replace("S", "").Replace("O", "").Replace("N", ""));

                    while (Input_XmlReader.Read())
                    {
                        if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:person"))
                            return;

                        if ((Input_XmlReader.NodeType == XmlNodeType.Element) && (Input_XmlReader.Name == "map:persname") && (!Input_XmlReader.IsEmptyElement))
                        {
                            Input_XmlReader.Read();
                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                mapInfo.New_Person(personid, Input_XmlReader.Value);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private static void read_map_corporation(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            if (Input_XmlReader.MoveToAttribute("id"))
            {
                try
                {
                    long corpid = Convert.ToInt64(Input_XmlReader.Value.Replace("COR", "").Replace("P", ""));

                    string type = String.Empty;
                    string primary_name = String.Empty;
                    List<string> alternate_names = new List<string>();

                    while (Input_XmlReader.Read())
                    {
                        if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && (Input_XmlReader.Name == "map:corporation"))
                        {
                            if ((corpid > 0) && (primary_name.Length > 0))
                            {
                                Map_Corporation thisCorp = mapInfo.New_Corporation(corpid, primary_name);
                                foreach (string altName in alternate_names)
                                    thisCorp.Add_Alt_Name(altName);
                            }
                            return;
                        }

                        if ((Input_XmlReader.NodeType == XmlNodeType.Element) && (Input_XmlReader.Name == "map:corpname") && (!Input_XmlReader.IsEmptyElement))
                        {
                            if (Input_XmlReader.MoveToAttribute("type"))
                                type = Input_XmlReader.Value;
                            else
                                type = String.Empty;

                            Input_XmlReader.Read();
                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                if ((type.Length == 0) || (type == "primary"))
                                    primary_name = Input_XmlReader.Value;
                                else
                                    alternate_names.Add(Input_XmlReader.Value);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private static void read_map_sheets(XmlReader Input_XmlReader, Map_Info mapInfo)
        {
            string id_string = String.Empty;
            string file = String.Empty;

            while (Input_XmlReader.Read())
            {
                if (Input_XmlReader.NodeType == XmlNodeType.EndElement)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:sheets":
                            return;

                        case "map:sheet":
                            try
                            {
                                long id = Convert.ToInt64(id_string.ToUpper().Replace("MS", ""));
                                mapInfo.New_Sheet(id, 0, file, String.Empty);
                            }
                            catch
                            {
                            }

                            // Clear the variables
                            id_string = String.Empty;
                            file = String.Empty;
                            break;
                    }
                }
                else if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (Input_XmlReader.Name)
                    {
                        case "map:sheet":
                            if (Input_XmlReader.MoveToAttribute("id"))
                                id_string = Input_XmlReader.Value;
                            break;

                        case "map:fileref":
                            if (Input_XmlReader.MoveToAttribute("fileid"))
                                file = Input_XmlReader.Value;
                            break;
                    }
                }
            }
        }

        #endregion
    }
}