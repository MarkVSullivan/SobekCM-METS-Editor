#region Using directives

using System;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Types of elements which can (potentially) be displayed in the online metadata template </summary>
    public enum Element_Type : short
    {
        /// <summary> ERROR type occurs when mapping to the enumeration fails </summary>
        Error = 0,

        /// <summary> Abstract/summary element type maps to <see cref="Abstract_Summary_Element"/> or <see cref="Abstract_Complex_Element"/> </summary>
        Abstract = 1,

        /// <summary> This special note field maps to <see cref="Acquisition_Note_Element"/> and is generally reserved from editing by users </summary>
        Acquisition,

        /// <summary> Allows entry of affiliation information either for the digital resource in 
        /// general or for the just a single named entity </summary>
        Affiliation,

        /// <summary> List of aggregations (non-institutional) to which material is linked </summary>
        Aggregations,

        /// <summary> This special note field maps to <see cref="Attribution_Element"/> and is generally reserved from editing by users </summary>
        Attribution,

        /// <summary> Bibliographic identifier (BibID) element type maps to the <see cref="BibID_Element"/> </summary>
        BibID,

        /// <summary> Authority-established classification for this item which maps to <see cref="Classification_Element"/> </summary>
        Classification,

        /// <summary> Holds all the container (finding guide position) information for this item </summary>
        Container,

        /// <summary> Contributor element is used for dublin-core like entry and maps to <see cref="Contributor_Element"/> </summary>
        Contributor,

        /// <summary> Coordinate element type maps to <see cref="Coordinates_Point_Element"/> </summary>
        Coordinates,

        /// <summary> Creator element type maps to <see cref="Creator_Element"/>, <see cref="Creator_Complex_Element"/>, or <see cref="Name_Form_Element"/> </summary>
        Creator,

        /// <summary> Creator notes element type maps to <see cref="Creator_Notes_Element"/> </summary>
        CreatorNotes,

        /// <summary> Publication date element type maps to <see cref="Date_Element"/> </summary>
        Date,

        /// <summary> Copyright date element type maps to <see cref="Date_Copyrighted_Element"/> </summary>
        DateCopyrighted,

        /// <summary> Standard used for the encoding of this record </summary>
        DescriptionStandard,

        /// <summary> Donor element type maps to <see cref="Donor_Element"/> </summary>
        Donor,

        /// <summary> Download element type maps to <see cref="Downloads_Element"/> </summary>
        Download,

        /// <summary> Related EAD element type maps to <see cref="EAD_Form_Element"/> </summary>
        EAD,

        /// <summary> Edition element type maps to <see cref="Edition_Element"/> </summary>
        Edition,

        /// <summary> Encoding level element type maps to <see cref="Encoding_Level_Element"/> </summary>
        EncodingLevel,

        /// <summary> Electronic Thesis and Disseratation information - name of the committee chair, surname first </summary>
        ETD_CommitteeChair,

        /// <summary> Electronic Thesis and Disseratation information - name of the committee co-chair, surname first </summary>
        ETD_CommitteeCoChair,

        /// <summary> Electronic Thesis and Disseratation information - name of the committee members, surname first </summary>
        ETD_CommitteeMember,

        /// <summary> Electronic Thesis and Disseratation information - type of degree granted </summary>
        ETD_Degree,

        /// <summary> Electronic Thesis and Disseratation information - name of the college or department </summary>
        ETD_DegreeDiscipline,

        /// <summary> Electronic Thesis and Disseratation information - name of the institution in standard form </summary>
        ETD_DegreeGrantor,

        /// <summary> Electronic Thesis and Disseratation information - either 'Thesis' or 'Dissertation' </summary>
        ETD_DegreeLevel,

        /// <summary> Electronic Thesis and Disseratation information - student's graduation date </summary>
        ETD_GraduationDate,

        /// <summary> Frequency element type maps to <see cref="FAST_Subject_Element"/> </summary>
        FAST_Subject,

        /// <summary> Flags used to indicate if an item should load to PALMM or FDA for items 
        /// with a destination of FCLA ( Florida Center of Library Automation )   </summary>
        FCLA_Flags,

        /// <summary> FDA Account element type does not currently map to any element (FUTURE PLAN) </summary>
        FDA_Account,

        /// <summary> FDA Project element type does not currently map to any element (FUTURE PLAN)</summary>
        FDA_Project,

        /// <summary> FDA SubAccount element type does not currently map to any element (FUTURE PLAN)</summary>
        FDA_SubAccount,

        /// <summary> FDA Format is a simple entry element for physical description and maps to <see cref="Format_Element"/> </summary>
        Format,

        /// <summary> Frequency element type maps to <see cref="Frequency_Element"/> </summary>
        Frequency,

        /// <summary> Genre element type maps to <see cref="Genre_Element"/> </summary>
        Genre,

        /// <summary> Group title element type maps to <see cref="Group_Title_Element"/> </summary>
        Group_Title,

        /// <summary> Holding location element types maps to <see cref="Holding_Element"/> </summary>
        Holding,

        /// <summary> Identifier element type maps to <see cref="Identifier_Element"/> </summary>
        Identifier,

        /// <summary> Language element type maps to <see cref="Language_Element"/> </summary>
        Language,

        /// <summary> Main thumbnail element type maps to <see cref="Main_Thumbnail_Element"/> </summary>
        MainThumbnail,

        /// <summary> Manufacturer element type maps to <see cref="Manufacturer_Element"/> or <see cref="Manufacturer_Complex_Element"/> </summary>
        Manufacturer,

        /// <summary> Object ID for the METS file </summary>
        METS_ObjectID,

        /// <summary> Note element type maps to <see cref="Note_Element"/> or <see cref="Note_Complex_Element"/> </summary>
        Note,

        /// <summary> Other files element type does not currently map to any element (FUTURE PLAN) </summary>
        OtherFiles,

        /// <summary> Other URL element type maps to <see cref="Other_URL_Form_Element"/> or <see cref="Other_URL_Element" /> </summary>
        OtherURL,

        /// <summary> PALMM code element type does not currently map to any element (FUTURE PLAN) </summary>
        PALMM_Code,

        /// <summary> Publication place element type maps to <see cref="Publication_Place_Element"/> </summary>
        Publication_Place,

        /// <summary> Publication status element type maps to <see cref="Publication_Status_Element"/> </summary>
        Publication_Status,

        /// <summary> Publisher element type maps to <see cref="Publisher_Element"/> and <see cref="Publisher_Complex_Element"/>  </summary>
        Publisher,

        /// <summary> Record origin element type maps to <see cref="Record_Origin_Element"/> </summary>
        RecordOrigin,

        /// <summary> Record status element type maps to <see cref="RecordStatus_Element"/> </summary>
        RecordStatus,

        /// <summary> Related item element type maps to <see cref="Related_Item_Form_Element"/> </summary>
        RelatedItem,

        /// <summary> Rights element type maps to <see cref="Rights_Element"/> </summary>
        Rights,

        /// <summary> Scale element type maps to <see cref="Scale_Element"/> </summary>
        Scale,

        /// <summary> Serial hierarchy element type maps to <see cref="Serial_Hierarchy_Form_Element"/> </summary>
        SerialHierarchy,

        /// <summary> Source institution element type maps to a number of different elements </summary>
        Source_Institution,

        /// <summary> Note about the source of the data or files (as used within dublin core ) </summary>
        Source_Note,

        /// <summary> Spatial coverage element type maps to <see cref="Spatial_Coverage_Element"/> </summary>
        Spatial,

        /// <summary> Structure map element type does not currently map to any element (FUTURE PLAN)</summary>
        Structure_Map,

        /// <summary> Subject element type maps to <see cref="Subject_Element"/>, <see cref="Subject_Scheme_Element"/>, or <see cref="Subject_Keyword_Standard_Form_Element"/> </summary>
        Subject,

        /// <summary> Target audience element type maps to <see cref="Target_Audience_Element"/> </summary>
        TargetAudience,

        /// <summary> Temporal covage element type maps to <see cref="Temporal_Coverage_Element"/> or <see cref="Temporal_Complex_Element"/> </summary>
        Temporal,

        /// <summary> Text displayable flag does not currently map to any element (FUTURE PLAN) </summary>
        TextDisplayable,

        /// <summary> Text searchable flag does not currently map to any element (FUTURE PLAN)</summary>
        TextSearchable,

        /// <summary> Tickler field is used for internally searching for sets </summary>
        Tickler,

        /// <summary> Main title element type maps to <see cref="Title_Main_Element"/> or <see cref="Title_Main_Form_Element"/> </summary>
        Title,

        /// <summary> Other titles element type maps to <see cref="Other_Title_Element"/> or <see cref="Other_Title_Form_Element"/> </summary>
        Title_Other,

        /// <summary> Resource type element type maps to <see cref="Type_Element"/> or <see cref="Type_Format_Form_Element"/> </summary>
        Type,

        /// <summary> Volume identifier (VID) element type maps to <see cref="VID_Element"/> </summary>
        VID,

        /// <summary> Viewer element type maps to <see cref="Viewer_Element"/> </summary>
        Viewer,
        
        /// <summary> VRACore element for cultural context of the visual resource </summary>
        VRA_CulturalContext,

        /// <summary> VRACore element for inscriptions on the visual resource </summary>
        VRA_Inscription,

        /// <summary> VRACore element for material making up the visual resource </summary>
        VRA_Material,

        /// <summary> VRACore element for measurements related to the visual resource </summary>
        VRA_Measurement,

        /// <summary> VRACore element for state or edition of the visual resource </summary>
        VRA_StateEdition,

        /// <summary> VRACore element for the style or period represented by the visual resource </summary>
        VRA_StylePeriod,

        /// <summary> VRACore element for technique used for creation of the visual resource </summary>
        VRA_Technique,

        /// <summary> HTML SobekCM web skin element type maps to <see cref="Web_Skin_Element"/> </summary>
        Web_Skin,

        /// <summary> Wordmark/Icon element type maps to <see cref="Wordmark_Element"/> </summary>
        Wordmark,

        /// <summary> Zoological taxononic information - class classification </summary>
        ZT_Class,

        /// <summary> Zoological taxononic information - common or vernacular name </summary>
        ZT_CommonName,

        /// <summary> Zoological taxononic information - family classification </summary>
        ZT_Family,

        /// <summary> Zoological taxononic information - genus classification </summary>
        ZT_Genus,

        /// <summary> Zoological taxononic information - higher classification DarwinCore field </summary>
        ZT_HigherClassification,

        /// <summary> Zoological taxononic information - kingdom classification </summary>
        ZT_Kingdom,

        /// <summary> Zoological taxononic information - order classification </summary>
        ZT_Order,

        /// <summary> Zoological taxononic information - phylum classification </summary>
        ZT_Phylum,

        /// <summary> Zoological taxononic information - scientific name </summary>
        ZT_ScientificName,

        /// <summary> Zoological taxononic information - first or species epithet of the scientific name </summary>
        ZT_SpecificEpithet,

        /// <summary> Zoological taxononic information - taxonomic rank of the most specific name given </summary>
        ZT_TaxonRank
    }

    /// <summary> Static class performs conversions between <see cref="Element_Type"/> enumeration and strings </summary>
    public class Element_Type_Convertor
    {
        /// <summary> Static method converts from type string to the <see cref="Element_Type"/> enumeration </summary>
        /// <param name="Type"> Element type as a string </param>
        /// <returns> Element type as the enumerational value </returns>
        public static Element_Type ToType(string Type)
        {
            switch (Type.ToUpper().Replace(" ", "_"))
            {
                case "ABSTRACT":
                    return Element_Type.Abstract;

                case "ACQUISITION":
                    return Element_Type.Acquisition;

                case "AFFILIATION":
                    return Element_Type.Affiliation;

                case "AGGREGATIONS":
                case "COLLECTION":
                case "COLLECTION_PRIMARY":
                case "COLLECTION_ALTERNATE":
                    return Element_Type.Aggregations;

                case "ATTRIBUTION":
                    return Element_Type.Attribution;

                case "BIB":
                case "BIBID":
                    return Element_Type.BibID;

                case "CLASSIFICATION":
                    return Element_Type.Classification;

                case "CONTAINER":
                    return Element_Type.Container;

                case "CONTRIBUTOR":
                    return Element_Type.Contributor;

                case "COORDINATES":
                    return Element_Type.Coordinates;

                case "CREATOR":
                    return Element_Type.Creator;

                case "CREATORNOTES":
                    return Element_Type.CreatorNotes;

                case "DATE":
                    return Element_Type.Date;

                case "DATECOPYRIGHTED":
                    return Element_Type.DateCopyrighted;

                case "DESCRIPTIONSTANDARD":
                    return Element_Type.DescriptionStandard;

                case "DONOR":
                    return Element_Type.Donor;

                case "DOWNLOAD":
                    return Element_Type.Download;

                case "EAD":
                    return Element_Type.EAD;

                case "EDITION":
                    return Element_Type.Edition;

                case "ENCODINGLEVEL":
                    return Element_Type.EncodingLevel;

                case "ETD_COMMITTEECHAIR":
                    return Element_Type.ETD_CommitteeChair;

                case "ETD_COMMITTEECOCHAIR":
                    return Element_Type.ETD_CommitteeCoChair;

                case "ETD_COMMITTEEMEMBER":
                    return Element_Type.ETD_CommitteeMember;

                case "ETD_DEGREE":
                    return Element_Type.ETD_Degree;

                case "ETD_DEGREEDISCIPLINE":
                    return Element_Type.ETD_DegreeDiscipline;

                case "ETD_DEGREEGRANTOR":
                    return Element_Type.ETD_DegreeGrantor;

                case "ETD_DEGREELEVEL":
                    return Element_Type.ETD_DegreeLevel;

                case "ETD_GRADUATIONDATE":
                    return Element_Type.ETD_GraduationDate;

                case "FAST_SUBJECT":
                    return Element_Type.FAST_Subject;

                case "FCLA_FLAGS":
                    return Element_Type.FCLA_Flags;

                case "FDA_ACCOUNT":
                    return Element_Type.FDA_Account;

                case "FDA_PROJECT":
                    return Element_Type.FDA_Project;

                case "FDA_SUBACCOUNT":
                    return Element_Type.FDA_SubAccount;

                case "FORMAT":
                    return Element_Type.Format;

                case "FREQUENCY":
                    return Element_Type.Frequency;

                case "GENRE":
                    return Element_Type.Genre;

                case "GROUPTITLE":
                    return Element_Type.Group_Title;

                case "HOLDING":
                    return Element_Type.Holding;

                case "IDENTIFIER":
                    return Element_Type.Identifier;

                case "LANGUAGE":
                    return Element_Type.Language;

                case "MANUFACTURER":
                    return Element_Type.Manufacturer;

                case "METS_OBJECTID":
                case "OBJECTID":
                    return Element_Type.METS_ObjectID;

                case "NOTE":
                    return Element_Type.Note;

                case "OTHERFILES":
                    return Element_Type.OtherFiles;

                case "OTHERTITLE":
                    return Element_Type.Title_Other;

                case "OTHERURL":
                    return Element_Type.OtherURL;

                case "PALMM_CODE":
                    return Element_Type.PALMM_Code;

                case "PUBLICATIONPLACE":
                    return Element_Type.Publication_Place;

                case "PUBLICATIONSTATUS":
                    return Element_Type.Publication_Status;

                case "PUBLISHER":
                    return Element_Type.Publisher;

                case "RECORDORIGIN":
                    return Element_Type.RecordOrigin;

                case "RECORDSTATUS":
                    return Element_Type.RecordStatus;

                case "RELATEDITEM":
                    return Element_Type.RelatedItem;

                case "RIGHTS":
                    return Element_Type.Rights;

                case "SCALE":
                    return Element_Type.Scale;

                case "SERIALHIERARCHY":
                    return Element_Type.SerialHierarchy;

                case "SOURCE":
                    return Element_Type.Source_Institution;

                case "SOURCENOTE":
                    return Element_Type.Source_Note;

                case "SPATIAL":
                    return Element_Type.Spatial;

                case "STRUCTUREMAP":
                    return Element_Type.Structure_Map;

                case "SUBJECT":
                    return Element_Type.Subject;

                case "TARGETAUDIENCE":
                    return Element_Type.TargetAudience;

                case "TEMPORAL":
                    return Element_Type.Temporal;

                case "THUMBNAIL":
                    return Element_Type.MainThumbnail;

                case "TICKLER":
                    return Element_Type.Tickler;

                case "TITLE":
                    return Element_Type.Title;

                case "TYPE":
                    return Element_Type.Type;

                case "VID":
                    return Element_Type.VID;

                case "VIEWER":
                    return Element_Type.Viewer;

                case "VRA_CULTURALCONTEXT":
                case "CULTURALCONTEXT":
                    return Element_Type.VRA_CulturalContext;

                case "VRA_INSCRIPTION":
                case "INSCRIPTION":
                    return Element_Type.VRA_Inscription;

                case "VRA_MATERIAL":
                case "MATERIAL":
                case "VRA_MATERIALS":
                case "MATERIALS":
                    return Element_Type.VRA_Material;

                case "VRA_MEASUREMENT":
                case "MEASUREMENT":
                case "VRA_MEASUREMENTS":
                case "MEASUREMENTS":
                    return Element_Type.VRA_Measurement;

                case "VRA_STATEEDITION":
                case "STATEEDITION":
                    return Element_Type.VRA_StateEdition;

                case "VRA_STYLEPERIOD":
                case "STYLEPERIOD":
                    return Element_Type.VRA_StylePeriod;

                case "VRA_TECHNIQUE":
                case "TECHNIQUE":
                    return Element_Type.VRA_Technique;

                case "WEBSKIN":
                case "INTERFACE":
                    return Element_Type.Web_Skin;

                case "ICON":
                case "WORDMARK":
                    return Element_Type.Wordmark;

                case "ZT_CLASS":
                    return Element_Type.ZT_Class;

                case "ZT_COMMONNAME":
                    return Element_Type.ZT_CommonName;

                case "ZT_FAMILY":
                    return Element_Type.ZT_Family;

                case "ZT_GENUS":
                    return Element_Type.ZT_Genus;

                case "ZT_HIGHERCLASSIFICATION":
                    return Element_Type.ZT_HigherClassification;

                case "ZT_KINGDOM":
                    return Element_Type.ZT_Kingdom;

                case "ZT_ORDER":
                    return Element_Type.ZT_Order;

                case "ZT_PHYLUM":
                    return Element_Type.ZT_Phylum;

                case "ZT_SCIENTIFICNAME":
                    return Element_Type.ZT_ScientificName;

                case "ZT_SCIENTIFICEPITHET":
                    return Element_Type.ZT_SpecificEpithet;

                case "ZT_TAXONRANK":
                    return Element_Type.ZT_TaxonRank;

                case "TEXTDISPLAYABLE":
                    return Element_Type.TextDisplayable;

                case "TEXTSEARCHABLE":
                    return Element_Type.TextSearchable;


            }

            // Default of empty string
            return Element_Type.Error;
        }

        /// <summary> Static method converts from the <see cref="Element_Type"/> enumeration to a string </summary>
        /// <param name="Type"> Element type as the enumerational value </param>
        /// <returns> Element type as a string </returns>
        public static string ToString(Element_Type Type)
        {
            switch (Type)
            {
                case Element_Type.Abstract:
                    return "Abstract";

                case Element_Type.Acquisition:
                    return "Acquisition";

                case Element_Type.Affiliation:
                    return "Affiliation";

                case Element_Type.Aggregations:
                    return "Aggregations";

                case Element_Type.Attribution:
                    return "Attribution";

                case Element_Type.BibID:
                    return "BibID";

                case Element_Type.Classification:
                    return "Classification";

                case Element_Type.Container:
                    return "Container";

                case Element_Type.Contributor:
                    return "Contributor";

                case Element_Type.Coordinates:
                    return "Coordinates";

                case Element_Type.Creator:
                    return "Creator";

                case Element_Type.CreatorNotes:
                    return "CreatorNotes";

                case Element_Type.Date:
                    return "Date";

                case Element_Type.DateCopyrighted:
                    return "DateCopyrighted";

                case Element_Type.DescriptionStandard:
                    return "DescriptionStandard";

                case Element_Type.Donor:
                    return "Donor";

                case Element_Type.Download:
                    return "Download";

                case Element_Type.EAD:
                    return "EAD";

                case Element_Type.Edition:
                    return "Edition";

                case Element_Type.EncodingLevel:
                    return "EncodingLevel";

                case Element_Type.FAST_Subject:
                    return "FAST_Subject";

                case Element_Type.FCLA_Flags:
                    return "FCLA_Flags";

                case Element_Type.FDA_Account:
                    return "FDA_Account";

                case Element_Type.FDA_Project:
                    return "FDA_Project";

                case Element_Type.FDA_SubAccount:
                    return "FDA_SubAccount";

                case Element_Type.Format:
                    return "Format";

                case Element_Type.Frequency:
                    return "Frequency";

                case Element_Type.Genre:
                    return "Genre";

                case Element_Type.Group_Title:
                    return "GroupTitle";

                case Element_Type.Holding:
                    return "Holding";

                case Element_Type.Identifier:
                    return "Identifier";

                case Element_Type.Language:
                    return "Language";

                case Element_Type.Manufacturer:
                    return "Manufacturer";

                case Element_Type.METS_ObjectID:
                    return "METS_ObjectID";

                case Element_Type.Note:
                    return "Note";

                case Element_Type.OtherFiles:
                    return "OtherFiles";

                case Element_Type.Title_Other:
                    return "OtherTitle";

                case Element_Type.OtherURL:
                    return "OtherURL";

                case Element_Type.PALMM_Code:
                    return "PALMM_Code";

                case Element_Type.Publication_Place:
                    return "PublicationPlace";

                case Element_Type.Publication_Status:
                    return "PublicationStatus";

                case Element_Type.Publisher:
                    return "Publisher";

                case Element_Type.RecordOrigin:
                    return "RecordOrigin";

                case Element_Type.RecordStatus:
                    return "RecordStatus";

                case Element_Type.RelatedItem:
                    return "RelatedItem";

                case Element_Type.Rights:
                    return "Rights";

                case Element_Type.Scale:
                    return "Scale";

                case Element_Type.SerialHierarchy:
                    return "SerialHierarchy";

                case Element_Type.Source_Institution:
                    return "Source";

                case Element_Type.Source_Note:
                    return "SourceNote";

                case Element_Type.Spatial:
                    return "Spatial";

                case Element_Type.Structure_Map:
                    return "StructureMap";

                case Element_Type.Subject:
                    return "Subject";

                case Element_Type.TargetAudience:
                    return "TargetAudience";

                case Element_Type.Temporal:
                    return "Temporal";

                case Element_Type.MainThumbnail:
                    return "Thumbnail";

                case Element_Type.Tickler:
                    return "Tickler";

                case Element_Type.Title:
                    return "Title";

                case Element_Type.Type:
                    return "Type";

                case Element_Type.VID:
                    return "VID";

                case Element_Type.Viewer:
                    return "Viewer";

                case Element_Type.Web_Skin:
                    return "WebSkin";

                case Element_Type.Wordmark:
                    return "Wordmark";

                case Element_Type.TextDisplayable:
                    return "TextDisplayable";

                case Element_Type.TextSearchable:
                    return "TextSearchable";
            }

            // Default of empty string
            return String.Empty;
        }
    }
}