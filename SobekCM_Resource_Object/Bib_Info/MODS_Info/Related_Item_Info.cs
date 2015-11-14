﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using SobekCM.Resource_Object.MARC;

#endregion

namespace SobekCM.Resource_Object.Bib_Info
{
    /// <summary> Enumeration defines the relationship between this related item and the main described item </summary>
    public enum Related_Item_Type_Enum
    {
        /// <summary> Relationship between this related item and the described item is unknown </summary>
        UNKNOWN = -1,

        /// <summary> This related item preceeds the main described item </summary>
        preceding = 1,

        /// <summary> This related item succeeds the main described item </summary>
        succeeding,

        /// <summary> This related item is the host for the main described item </summary>
        host,

        /// <summary> This related item is a different version of the main described item </summary>
        otherVersion,

        /// <summary> This related item is a different format of the main described item </summary>
        otherFormat
    }

    /// <summary> Represents information about a related item </summary>
    [Serializable]
    public class Related_Item_Info : XML_Node_Base_Type
    {
        private string displayLabel;
        private string end_date;
        private List<Identifier_Info> identifiers;
        private List<Name_Info> names;
        private List<Note_Info> notes;
        private string publisher;
        private Related_Item_Type_Enum relationship;

        private string start_date;
        private Title_Info title;
        private string sobekcm_id;
        private string url;

        /// <summary> Constructor creates a new instance of the Related_Item_Info class  </summary>
        public Related_Item_Info()
        {
            relationship = Related_Item_Type_Enum.UNKNOWN;
        }

        /// <summary> Gets the number of identifiers associated with this related item  </summary>
        /// <remarks> This should be used rather than the Count property of the <see cref="Identifiers"/> property.  Even if 
        /// there are no identifiers, the Identifiers property creates a readonly collection to pass back out.</remarks>
        public int Identifiers_Count
        {
            get
            {
                if (identifiers == null)
                    return 0;
                else
                    return identifiers.Count;
            }
        }

        /// <summary> Gets the list of identifiers associated with related item </summary>
        /// <remarks> You should check the count of identifiers first using the <see cref="Identifiers_Count"/> property before using this property.
        /// Even if there are no identifiers, this property creates a readonly collection to pass back out.</remarks>
        public ReadOnlyCollection<Identifier_Info> Identifiers
        {
            get
            {
                if (identifiers == null)
                    return new ReadOnlyCollection<Identifier_Info>(new List<Identifier_Info>());
                else
                    return new ReadOnlyCollection<Identifier_Info>(identifiers);
            }
        }


        /// <summary> Gets the number of notes associated with this related item  </summary>
        /// <remarks> This should be used rather than the Count property of the <see cref="Notes"/> property.  Even if 
        /// there are no notes, the Notes property creates a readonly collection to pass back out.</remarks>
        public int Notes_Count
        {
            get
            {
                if (notes == null)
                    return 0;
                else
                    return notes.Count;
            }
        }

        /// <summary> Gets the list of notes associated with related item </summary>
        /// <remarks> You should check the count of notes first using the <see cref="Notes_Count"/> property before using this property.
        /// Even if there are no notes, this property creates a readonly collection to pass back out.</remarks>
        public ReadOnlyCollection<Note_Info> Notes
        {
            get
            {
                if (notes == null)
                    return new ReadOnlyCollection<Note_Info>(new List<Note_Info>());
                else
                    return new ReadOnlyCollection<Note_Info>(notes);
            }
        }

        /// <summary> Gets the number of names associated with this related item  </summary>
        /// <remarks> This should be used rather than the Count property of the <see cref="Names"/> property.  Even if 
        /// there are no names, the Names property creates a readonly collection to pass back out.</remarks>
        public int Names_Count
        {
            get
            {
                if (names == null)
                    return 0;
                else
                    return names.Count;
            }
        }

        /// <summary> Gets the list of names associated with related item </summary>
        /// <remarks> You should check the count of names first using the <see cref="Names_Count"/> property before using this property.
        /// Even if there are no names, this property creates a readonly collection to pass back out.</remarks>
        public ReadOnlyCollection<Name_Info> Names
        {
            get
            {
                if (names == null)
                    return new ReadOnlyCollection<Name_Info>(new List<Name_Info>());
                else
                    return new ReadOnlyCollection<Name_Info>(names);
            }
        }

        /// <summary> Flag indicates if this related item has a main title included </summary>
        public bool hasMainTitle
        {
            get
            {
                if ((title != null) && (title.Title.Length > 0))
                    return true;
                else
                    return false;
            }
        }

        /// <summary> Gets the main title for this related item </summary>
        public Title_Info Main_Title
        {
            get
            {
                if (title == null)
                    title = new Title_Info();

                return title;
            }
        }

        /// <summary> Gets or sets the type of relationship this item has to the described item  </summary>
        public Related_Item_Type_Enum Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        /// <summary> Gets or sets the SobekCM ID for the related item if hosted in the same library </summary>
        public string SobekCM_ID
        {
            get { return sobekcm_id ?? String.Empty; }
            set { sobekcm_id = value; }
        }

        /// <summary> Gets or sets the start date for the related item </summary>
        public string Start_Date
        {
            get { return start_date ?? String.Empty; }
            set { start_date = value; }
        }

        /// <summary> Gets or sets the end date for the related item </summary>
        public string End_Date
        {
            get { return end_date ?? String.Empty; }
            set { end_date = value; }
        }

        /// <summary> Gets or sets the URL for the related item </summary>
        public string URL
        {
            get { return url ?? String.Empty; }
            set { url = value; }
        }

        /// <summary> Gets or sets the display label for the URL for the related item </summary>
        public string URL_Display_Label
        {
            get { return displayLabel ?? String.Empty; }
            set { displayLabel = value; }
        }

        /// <summary> Gets or sets the name of the main publisher of this related item </summary>
        public string Publisher
        {
            get { return publisher ?? String.Empty; }
            set { publisher = value; }
        }

        /// <summary> Adds a new identifier to this related item </summary>
        /// <param name="Identifier">Identifier associated with this related item </param>
        /// <param name="Identifier_Type">Type of identifier (i.e., lccn, issn, oclc,..)</param>
        public void Add_Identifier(string Identifier, string Identifier_Type)
        {
            if (identifiers == null)
                identifiers = new List<Identifier_Info>();

            identifiers.Add(new Identifier_Info(Identifier, Identifier_Type));
        }

        /// <summary> Adds a new identifier to this related item </summary>
        /// <param name="Identifier">Identifier associated with this related item </param>
        public void Add_Identifier(Identifier_Info Identifier)
        {
            if (identifiers == null)
                identifiers = new List<Identifier_Info>();

            identifiers.Add(Identifier);
        }

        /// <summary> Adds a new note to this related item </summary>
        /// <param name="Note">Note associated with this related item </param>
        public void Add_Note(string Note)
        {
            if (notes == null)
                notes = new List<Note_Info>();

            notes.Add(new Note_Info(Note));
        }


        /// <summary> Adds a new note to this related item </summary>
        /// <param name="Note">Note associated with this related item </param>
        public void Add_Note(Note_Info Note)
        {
            if (notes == null)
                notes = new List<Note_Info>();

            notes.Add(Note);
        }

        /// <summary> Adds a name (creator) to this related item </summary>
        /// <param name="Name"> Name to associate with this related item </param>
        public void Add_Name(Name_Info Name)
        {
            if (names == null)
                names = new List<Name_Info>();

            names.Add(Name);
        }

        /// <summary> Directly sets the main title object during construction of the related item </summary>
        /// <param name="newTitle"> Main title for this related item </param>
        internal void Set_Main_Title(Title_Info newTitle)
        {
            title = newTitle;
        }

        internal void Add_MODS(TextWriter results)
        {
            if (((title != null) && (title.Title.Length > 0)) || ((identifiers != null) && (identifiers.Count > 0)) ||
                (!String.IsNullOrEmpty(sobekcm_id)) || (!String.IsNullOrEmpty(url)) ||
                (!String.IsNullOrEmpty(publisher)) || ((notes != null) && (notes.Count > 0)) ||
                ((names != null) && (names.Count > 0)))
            {
                // Start this related item
                results.Write("<mods:relatedItem");
                base.Add_ID(results);
                switch (relationship)
                {
                    case Related_Item_Type_Enum.host:
                        results.Write(" type=\"host\"");
                        break;

                    case Related_Item_Type_Enum.otherFormat:
                        results.Write(" type=\"otherFormat\"");
                        break;

                    case Related_Item_Type_Enum.otherVersion:
                        results.Write(" type=\"otherVersion\"");
                        break;

                    case Related_Item_Type_Enum.preceding:
                        results.Write(" type=\"preceding\"");
                        break;

                    case Related_Item_Type_Enum.succeeding:
                        results.Write(" type=\"succeeding\"");
                        break;
                }
                results.WriteLine(">");

                // Write all the identifiers
                if (identifiers != null)
                {
                    foreach (Identifier_Info thisIdentifier in identifiers)
                    {
                        thisIdentifier.Add_MODS(results);
                    }
                }

                // Add the location information
                if (!String.IsNullOrEmpty(url))
                {
                    results.Write("<mods:location>\r\n");
                    results.Write("<mods:url");
                    if (!String.IsNullOrEmpty(displayLabel))
                        results.Write(" displayLabel=\"" + base.Convert_String_To_XML_Safe(displayLabel) + "\"");
                    results.Write(">" + base.Convert_String_To_XML_Safe(url) + "</mods:url>\r\n");
                    results.Write("</mods:location>\r\n");
                }

                // Add the list of names
                if (names != null)
                {
                    foreach (Name_Info thisName in names)
                    {
                        thisName.Add_MODS(false, results);
                    }
                }

                // Add the list of notes
                if (notes != null)
                {
                    foreach (Note_Info thisNote in notes)
                    {
                        thisNote.Add_MODS(results);
                    }
                }

                // Add the publisher name, if that exists
                if ((!String.IsNullOrEmpty(publisher)) || (!String.IsNullOrEmpty(start_date)) || (!String.IsNullOrEmpty(end_date)))
                {
                    results.Write("<mods:Origin_Info>\r\n");
                    if (!String.IsNullOrEmpty(publisher))
                    {
                        results.Write("<mods:publisher>" + base.Convert_String_To_XML_Safe(publisher) + "</mods:publisher>\r\n");
                    }
                    if (!String.IsNullOrEmpty(start_date))
                    {
                        results.Write("<mods:dateIssued point=\"start\">" + base.Convert_String_To_XML_Safe(start_date) + "</mods:dateIssued>\r\n");
                    }
                    if (!String.IsNullOrEmpty(end_date))
                    {
                        results.Write("<mods:dateIssued point=\"end\">" + base.Convert_String_To_XML_Safe(end_date) + "</mods:dateIssued>\r\n");
                    }
                    results.Write("</mods:Origin_Info>\r\n");
                }

                // Add the UFDC ID, if it exists
                if (!String.IsNullOrEmpty(sobekcm_id))
                {
                    results.WriteLine("<mods:recordInfo>");
                    results.WriteLine("<mods:recordIdentifier source=\"ufdc\">" + sobekcm_id + "</mods:recordIdentifier>");
                    results.WriteLine("</mods:recordInfo>");
                }


                // Write the title
                if ((title != null) && (title.Title.Length > 0))
                {
                    title.Add_MODS(results);
                }

                // End this related item
                results.WriteLine("</mods:relatedItem>");
            }
        }

        internal MARC_Field to_MARC_HTML()
        {
            MARC_Field related_item_tag = new MARC_Field();
            related_item_tag.Indicators = "00";
            related_item_tag.Tag = 787;
            switch (Relationship)
            {
                case Related_Item_Type_Enum.host:
                    related_item_tag.Tag = 773;
                    related_item_tag.Indicators = "0 ";
                    break;

                case Related_Item_Type_Enum.otherFormat:
                    related_item_tag.Tag = 776;
                    related_item_tag.Indicators = "0 ";
                    break;

                case Related_Item_Type_Enum.otherVersion:
                    related_item_tag.Tag = 775;
                    related_item_tag.Indicators = "0 ";
                    break;

                case Related_Item_Type_Enum.preceding:
                    related_item_tag.Tag = 780;
                    break;

                case Related_Item_Type_Enum.succeeding:
                    related_item_tag.Tag = 785;
                    break;
            }

            StringBuilder relatedBuilder = new StringBuilder();
            string issn = String.Empty;
            string isbn = String.Empty;
            if (!String.IsNullOrEmpty(sobekcm_id))
            {
                relatedBuilder.Append("|o (UFDC)" + sobekcm_id + " ");
            }
            if ((title != null) && (title.Title.Length > 0))
            {
                relatedBuilder.Append("|t " + title.Title + " ");
            }
            if (identifiers != null)
            {
                foreach (Identifier_Info thisIdentifier in identifiers)
                {
                    switch (thisIdentifier.Type.ToUpper())
                    {
                        case "ISSN":
                            issn = thisIdentifier.Identifier;
                            break;

                        case "ISBN":
                            isbn = thisIdentifier.Identifier;
                            break;

                        case "OCLC":
                            relatedBuilder.Append("|w (OCoLC)" + thisIdentifier.Identifier + " ");
                            break;

                        case "LCCN":
                            relatedBuilder.Append("|w (DLC)sn" + thisIdentifier.Identifier + " ");
                            break;

                        default:
                            relatedBuilder.Append("|w " + thisIdentifier.Identifier + " ");
                            break;
                    }
                }
            }
            if (issn.Length > 0)
            {
                relatedBuilder.Append("|x " + issn + " ");
            }
            if (isbn.Length > 0)
            {
                relatedBuilder.Append("|z " + isbn + " ");
            }

            related_item_tag.Control_Field_Value = relatedBuilder.ToString();
            return related_item_tag;
        }
    }
}