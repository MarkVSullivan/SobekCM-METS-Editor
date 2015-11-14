#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using SobekCM.METS_Editor.Elements;
using SobekCM.METS_Editor.Messages;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Bib_Info;
using SobekCM.Resource_Object.Metadata_Modules;
using SobekCM.Resource_Object.Metadata_Modules.GeoSpatial;
using SobekCM.Resource_Object.Metadata_Modules.VRACore;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary>
	/// Summary description for Template.
	/// </summary>
	public class Template
	{
	    private bool readOnly;
	    private int width;

        private readonly Element_Collection constants;
        private readonly Dictionary<Template_Language, string> allTitles;
        private readonly Template_Page_Collection inputs;

	    #region Constructors

	    /// <summary> Constructor for a new Template object </summary>
	    public Template()
	    {
	        // Set some defaults
	        Notes = String.Empty;
	        Creator = String.Empty;
	        Title = String.Empty;
	        BibID = String.Empty;
	        VID = String.Empty;
	        readOnly = false;
	        allTitles = new Dictionary<Template_Language, string>();
	        DateCreated = DateTime.Now;
	        LastModified = new DateTime( 1, 1, 1);
	        inputs = new Template_Page_Collection();
	        constants = new Element_Collection();
	        isProject = false;
	    }

	    #endregion

	    #region Basic Properties

	    /// <summary> Flag indicates if the template is currently displaying a project  </summary>
	    public bool isProject { get; private set; }

	    /// <summary> BibID (Bibliographic Identifier) for the item currently being displayed </summary>
	    public string BibID { get; private set; }

	    /// <summary> VID ( Volume Identifier ) for the item currently being displayed  </summary>
	    public string VID { get; private set; }

	    /// <summary> Current title of this template </summary>
	    public string Title { get; private set; }

	    /// <summary> Gets and sets the notes about the creation and maintenance of this template </summary>
	    public string Notes { get; set; }

	    /// <summary> Gets and sets the name of the creator of this template </summary>
	    public string Creator { get; set; }

	    /// <summary> Gets and sets the date this template was created </summary>
	    public DateTime DateCreated { get; set; }

	    /// <summary> Gets and sets the date this template was last modified </summary>
	    public DateTime LastModified { get; set; }

	    /// <summary> Gets the collection of input pages for this template </summary>
	    public Template_Page_Collection InputPages
	    {
	        get	{	return inputs;		}
	    }

	    /// <summary> Gets the collection of constant elements for this template </summary>
	    public Element_Collection Constants
	    {
	        get	{	return constants;	}
	    }

	    /// <summary> Gets or sets the flag that indicates that the template is currently displaying in
        ///  read-only format</summary> 
        /// <remarks> This is not generally used anymore </remarks>
	    public bool ReadOnly
	    {
	        get	{	return readOnly;	}
	        set	
	        {	
	            // Save the value
	            readOnly = value;	

	            // If this is read only, set every element accordingly
	            if ( readOnly )
	            {			
	                // Now, step through each element
	                foreach( Template_Page thisPage in InputPages )
	                {
	                    foreach( Template_Panel thisPanel in thisPage.Panels )
	                    {
	                        foreach( abstract_Element thisElement in thisPanel.Elements )
	                        {
	                            thisElement.Read_Only = true;
	                            thisElement.Repeatable = false;
	                        }
	                    }
	                }
	            }
	        }
	    }

	    #endregion

	    /// <summary> Sets the current font and populates the current font for each page in this template  </summary>
	    public Font Current_Font
		{
			set
			{
			    // Set the font on all the pages as well
				InputPages.Current_Font = value;
			}
		}

	    /// <summary> Gets and sets the width (in pixels) for this template to be displayed  </summary>
	    public int Width
	    {
	        get
	        {
	            return width;
	        }
	        set
	        {
	            width = value;

	            foreach( Template_Page thisPage in InputPages )
	            {
	                thisPage.Width = value;
	            }
	        }
	    }

	    /// <summary> Gets any validity errors which are encountered while validating the data within entered
	    /// by the user in the template  </summary>
	    public string Validity_Errors { get; private set; }

	    #region Methods to read and write in the template XML format

        /// <summary> Reads a template-defining XML file to get the pages, panels, and element information and returns
        /// a fully-built template object  </summary>
        /// <param name="XmlFile"> Source XML file to be read </param>
	    /// <returns> Fully built template object from the source file </returns>
	    public static Template Read_XML_Template(string XmlFile)
	    {
	        return Read_XML_Template(XmlFile, false);
	    }

	    /// <summary> Reads a template-defining XML file to get the pages, panels, and element information and returns
	    /// a fully-built template object  </summary>
	    /// <param name="XmlFile"> Source XML file to be read </param>
        /// <param name="exclude_divisions"> Flag indicates if any included structure map element should be exluded in the current usage  </param>
        /// <returns> Fully built template object from the source file </returns>
	    public static Template Read_XML_Template( string XmlFile, bool exclude_divisions )
	    {
	        Template returnValue = new Template();
	        Template_XML_Reader reader = new Template_XML_Reader();
	        reader.Read_XML( XmlFile, returnValue, exclude_divisions );
	        return returnValue;
	    }

	    /// <summary> Save this template scheme to the Template XML file </summary>
	    /// <param name="FileName"> Name of Template XML file </param>
	    /// <returns> TRUE if successful, otherwise FALSE </returns>
	    public bool Save_Template_XML( string FileName )
	    {
	        try
	        {
	            StringBuilder resultBuilder = new StringBuilder();
			
	            // Add header and the start main tag
	            resultBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n");
	            resultBuilder.Append("\r\n");
	            resultBuilder.Append("<!-- Begin the XML for this input template -->\r\n");
	            resultBuilder.Append("<input_template>\r\n");
	            resultBuilder.Append("\r\n");

	            // Add the administrative information about this template
	            resultBuilder.Append("\t<!-- Define the information about this input template -->\r\n");

	            // Write each of the titles for this page
	            foreach( KeyValuePair<Template_Language, string> thisEntry in allTitles )
	            {
	                // If this language is known, write it
                    if (thisEntry.Key != Template_Language.Unknown)
	                {
                        resultBuilder.Append("\t<name language=\"" + Template_Language_Convertor.ToCode(thisEntry.Key) + "\">" + thisEntry.Value + "</name>\r\n");
	                }
	            }

	            // Finish out the administrative section
	            if ( Notes.Length > 0 )
	                resultBuilder.Append("\t<notes>" + Notes + "</notes>\r\n");
	            resultBuilder.Append("\t<dateCreated>" + DateCreated.ToLongDateString() + "</dateCreated>\r\n");
	            if ( LastModified.CompareTo( DateCreated ) > 0 )
	                resultBuilder.Append("\t<lastModified>" + LastModified.ToLongDateString() + "</lastModified>\r\n");
	            if ( Creator.Length > 0 )
	                resultBuilder.Append("\t<creator>" + Creator + "</creator>\r\n");
	            resultBuilder.Append("\r\n");

	            // Write the information which describes all the inputs
	            resultBuilder.Append("\t<!-- This defines the inputs which are available for the user -->\r\n");
	            resultBuilder.Append("\t<inputs>\r\n");
	            resultBuilder.Append( inputs.To_Template_XML() );
	            resultBuilder.Append("\t</inputs>\r\n");
	            resultBuilder.Append("\r\n");

	            // Add all the constant information
	            resultBuilder.Append("\t<!-- This defines the constants which can not be edited by the user -->\r\n");
	            resultBuilder.Append("\t<constants>\r\n");
	            resultBuilder.Append( constants.To_Template_XML( "\t\t" ));
	            resultBuilder.Append("\t</constants>\r\n");
	            resultBuilder.Append("\r\n");

	            // Close the main tag
	            resultBuilder.Append("</input_template>\r\n");
	            resultBuilder.Append("<!-- End of input template XML -->\r\n");

	            // Write this out to a file
	            StreamWriter writer = new StreamWriter( FileName, false, Encoding.UTF8 );
	            writer.Write( resultBuilder.ToString() );
	            writer.Flush();
	            writer.Close();

	            // Return true
	            return true;
	        }
	        catch
	        {
	            return false;
	        }
	    }

	    #endregion

	    #region Methods to save and read to/from a bib package

	    /// <summary> Prepares a pre-existing bib id for saving, by clearing all
	    /// the fields which were editable in the metadata template</summary>
	    /// <param name="Bib"> Existing Bib object </param>
	    public void Prepare_For_Save( SobekCM_Item Bib )
	    {
	        // Clear each constant
	        foreach( abstract_Element thisElement in Constants )
	        {
	            thisElement.Prepare_For_Save( Bib );
	        }

	        // Clear each element
	        foreach( Template_Page thisPage in InputPages )
	        {
	            foreach( Template_Panel thisPanel in thisPage.Panels )
	            {
	                foreach( abstract_Element thisElement in thisPanel.Elements )
	                {
	                    thisElement.Prepare_For_Save( Bib );
	                }
	            }
	        }
	    }

	    /// <summary> Saves the data stored in this instance of the 
	    /// element to the provided bibliographic object </summary>
	    /// <param name="Bib"> Object into which to save this element's data </param>
	    public void Save_To_Bib( SobekCM_Item Bib )
	    {
	        // Now, add each constant
	        foreach( abstract_Element thisElement in Constants )
	        {
	            thisElement.Save_To_Bib( Bib );
	        }

	        // Now, step through each element
	        foreach( Template_Page thisPage in InputPages )
	        {
	            foreach( Template_Panel thisPanel in thisPage.Panels )
	            {
	                foreach( abstract_Element thisElement in thisPanel.Elements )
	                {
	                    thisElement.Save_To_Bib( Bib );
	                }
	            }
	        }
	    }

	    /// <summary> Saves the data stored in this instance of the 
	    /// element to the provided bibliographic object </summary>
	    /// <param name="Bib"> Object to populate this element from </param>
	    public void Populate_From_Bib( SobekCM_Item Bib )
	    {
	        // Save the BibID and VID
	        BibID = Bib.BibID;
	        VID = Bib.VID;
	        isProject = Bib.Bib_Info.SobekCM_Type == TypeOfResource_SobekCM_Enum.Project;

	        // First, need to make sure there are enough of each element 
	        // to match the number of instances in the METS file
	        foreach( Template_Page thisPage in InputPages )
	        {
	            foreach( Template_Panel thisPanel in thisPage.Panels )
	            {
	                int i = 0;
	                while ( i < thisPanel.Elements.Count )
	                {
	                    abstract_Element thisElement = thisPanel.Elements[i];
	                    int bib_count = Get_Bib_Element_Count( thisElement, Bib );

	                    // Is this entire template read_only?
	                    abstract_Element newElement;
	                    if (( readOnly ) || ( thisElement.Type == Element_Type.Structure_Map ))
	                    {
	                        if ( bib_count <= 0 )
	                        {
	                            // Since this is readonly, no need to even display
	                            // this element on the form
	                            thisPanel.Elements.RemoveAt( i );
	                        }
	                        else
	                        {
	                            if ( bib_count > 1 )
	                            {
	                                for( int j = 1 ; j < bib_count ; j++ )
	                                {
	                                    i++;
	                                    newElement = thisElement.Clone();
	                                    newElement.Repeatable = thisElement.Repeatable;
	                                    thisElement.Repeatable = false;
	                                    thisElement = newElement;
	                                    thisElement.Read_Only = true;
	                                    thisPanel.Elements.Insert( i, newElement );
	                                }
	                            }
	                            i++;
	                        }
	                    }
	                    else	// Not readonly form
	                    {
	                        if ( bib_count > 1 )
	                        {
	                            for( int j = 1 ; j < bib_count ; j++ )
	                            {
	                                i++;
	                                newElement = thisElement.Clone();
	                                newElement.Repeatable = thisElement.Repeatable;
	                                thisElement.Repeatable = false;
	                                thisElement = newElement;
	                                thisPanel.Elements.Insert( i, newElement );
	                            }
	                        }

	                        // Go to the next element
	                        i++;
	                    }
	                }
	            }
	        }

	        // Remove any panels which have no elements
	        foreach( Template_Page thisPage in InputPages )
	        {
	            int panel_count = 0;
	            while ( panel_count < thisPage.Panels.Count )
	            {
	                if( thisPage.Panels[ panel_count ].Elements.Count == 0 )
	                {
	                    thisPage.Panels.RemoveAt( panel_count );
	                }
	                else
	                {
	                    // Recalculate the height of this panel
	                    thisPage.Panels[ panel_count ].Compute_Height_And_Locations();
	                    panel_count++;
	                }
	            }
	        }

	        // Remove any pages without elements
	        int page_count = 0;
	        while ( page_count < InputPages.Count )
	        {
	            if( InputPages[page_count].Panels.Count == 0 )
	            {
	                InputPages.RemoveAt( page_count );
	            }
	            else
	            {
	                page_count++;
	            }
	        }	


	        // Next, step through each element and add the data from the METS file
	        foreach( Template_Page thisPage in InputPages )
	        {
	            foreach( Template_Panel thisPanel in thisPage.Panels )
	            {
	                foreach( abstract_Element addData in thisPanel.Elements )
	                {
	                    addData.Populate_From_Bib( Bib );
	                }
	            }
	        }	
	    }

	    /// <summary>  </summary>
	    /// <param name="thisElement"></param>
	    /// <param name="Bib"></param>
	    /// <returns></returns>
	    private int Get_Bib_Element_Count( abstract_Element thisElement, SobekCM_Item Bib )
	    {
	        switch( thisElement.Type )
	        {
	            case Element_Type.Abstract:
	                return Bib.Bib_Info.Abstracts_Count;

	            case Element_Type.Affiliation:
	                return Bib.Bib_Info.Affiliations_Count;

	            case Element_Type.Aggregations:
	                return Bib.Behaviors.Aggregation_Count > 0 ? 1 : 0;

	            case Element_Type.Attribution:
	                return Bib.Bib_Info.Notes.Count(thisNote => thisNote.Note_Type == Note_Type_Enum.funding);

	            case Element_Type.BibID:
	                return 1;

	            case Element_Type.Classification:
	                return Bib.Bib_Info.Classifications_Count;

	            case Element_Type.Contributor:
	                int contributor_count = 0;
	                if ((Bib.Bib_Info.Main_Entity_Name.hasData) && (Bib.Bib_Info.Main_Entity_Name.Roles.Count > 0) && ((Bib.Bib_Info.Main_Entity_Name.Roles[0].Role.ToUpper() == "CONTRIBUTOR") || (Bib.Bib_Info.Main_Entity_Name.Roles[0].Role.ToUpper() == "CTB"))) 
	                    contributor_count++;
	                contributor_count += Bib.Bib_Info.Names.Count(thisName => (thisName.Roles.Count > 0) && ((thisName.Roles[0].Role.ToUpper() == "CONTRIBUTOR") || (thisName.Roles[0].Role.ToUpper() == "CTB")));
	                return contributor_count;

	            case Element_Type.Coordinates:
	                GeoSpatial_Information geoInfo = Bib.Get_Metadata_Module(GlobalVar.GEOSPATIAL_METADATA_MODULE_KEY) as GeoSpatial_Information;
                    if ( geoInfo == null ) return 0;
                    return (geoInfo.Point_Count > 0) || (geoInfo.Polygon_Count > 0) ? 1 : 0;

	            case Element_Type.Creator:
	                if ((thisElement.Display_SubType != "simple") || (((Creator_Simple_Element)thisElement).Contributor_Exists == false))
	                {
	                    return Bib.Bib_Info.Main_Entity_Name.hasData
	                               ? Bib.Bib_Info.Names.Count + 1
	                               : Bib.Bib_Info.Names.Count;
	                }

	                int non_contributor_count = 0;
	                if (( Bib.Bib_Info.Main_Entity_Name.hasData ) && (( Bib.Bib_Info.Main_Entity_Name.Roles.Count == 0 ) || (( Bib.Bib_Info.Main_Entity_Name.Roles[0].Role.ToUpper() != "CONTRIBUTOR" ) && ( Bib.Bib_Info.Main_Entity_Name.Roles[0].Role.ToUpper() != "CTB" ))))
	                    non_contributor_count++;
	                non_contributor_count += Bib.Bib_Info.Names.Count(thisName => (thisName.Roles.Count == 0) || ((thisName.Roles[0].Role.ToUpper() != "CONTRIBUTOR") && (thisName.Roles[0].Role.ToUpper() != "CTB")));
	                return non_contributor_count;

	            case Element_Type.CreatorNotes:
	                return Bib.METS_Header.Creator_Individual_Notes_Count > 0 ? 1 : 0;

	            case Element_Type.Date:
	                return Bib.Bib_Info.Origin_Info.Date_Issued.Length == 0 ? 0 : 1;

	            case Element_Type.DateCopyrighted:
	                return Bib.Bib_Info.Origin_Info.Date_Copyrighted.Length > 0 ? 1 : 0;

	            case Element_Type.DescriptionStandard:
	                return Bib.Bib_Info.Record.Description_Standard.Length > 0 ? 1 : 0;

	            case Element_Type.Donor:
	                return Bib.Bib_Info.Donor.Full_Name.Length > 0 ? 1 : 0;

	            case Element_Type.Edition:
	                return Bib.Bib_Info.Origin_Info.Edition.Length > 0 ? 1 : 0;

	            case Element_Type.EncodingLevel:
	                return Bib.Bib_Info.EncodingLevel.Length > 0 ? 1 : 0;

	            case Element_Type.EAD:
	                return (Bib.Bib_Info.Location.EAD_URL.Length > 0) || (Bib.Bib_Info.Location.EAD_Name.Length > 0) ? 1 : 0;

	            case Element_Type.Error:
	                return 0;

	            case Element_Type.ETD_CommitteeChair:
                    Thesis_Dissertation_Info thesisInfo = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo != null) && (thesisInfo.Committee_Chair.Length > 0) ? 1 : 0;

	            case Element_Type.ETD_CommitteeCoChair:
                    Thesis_Dissertation_Info thesisInfo2 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo2 != null) && (thesisInfo2.Committee_Co_Chair.Length > 0) ? 1 : 0;

	            case Element_Type.ETD_CommitteeMember:
                    Thesis_Dissertation_Info thesisInfo3 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo3 != null) ? thesisInfo3.Committee_Members_Count : 0;

	            case Element_Type.ETD_Degree:
                    Thesis_Dissertation_Info thesisInfo4 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo4 != null) && (thesisInfo4.Degree.Length > 0) ? 1 : 0;

	            case Element_Type.ETD_DegreeDiscipline:
                    Thesis_Dissertation_Info thesisInfo5 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo5 != null) && (thesisInfo5.Degree_Discipline.Length > 0) ? 1 : 0;

	            case Element_Type.ETD_DegreeGrantor:
                    Thesis_Dissertation_Info thesisInfo6 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo6 != null) && (thesisInfo6.Degree_Grantor.Length > 0) ? 1 : 0;

	            case Element_Type.ETD_DegreeLevel:
                    Thesis_Dissertation_Info thesisInfo7 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo7 != null) && (thesisInfo7.Degree_Level != Thesis_Dissertation_Info.Thesis_Degree_Level_Enum.Unknown ) ? 1 : 0;

	            case Element_Type.ETD_GraduationDate:
                    Thesis_Dissertation_Info thesisInfo8 = Bib.Get_Metadata_Module(GlobalVar.THESIS_METADATA_MODULE_KEY) as Thesis_Dissertation_Info;
                    return (thesisInfo8 != null) && (thesisInfo8.Graduation_Date.HasValue ) ? 1 : 0;

	            case Element_Type.FCLA_Flags:
	                return 1;

	            case Element_Type.FDA_Account:
                    DAITSS_Info daitssInfo = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
	                return daitssInfo != null && daitssInfo.Account.Trim().Length > 0 ? 1 : 0;

	            case Element_Type.FDA_SubAccount:
                    DAITSS_Info daitssInfo2 = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
                    return daitssInfo2 != null && daitssInfo2.SubAccount.Trim().Length > 0 ? 1 : 0;

	            case Element_Type.FDA_Project:
                    DAITSS_Info daitssInfo3 = Bib.Get_Metadata_Module(GlobalVar.DAITSS_METADATA_MODULE_KEY) as DAITSS_Info;
	                return daitssInfo3 != null && daitssInfo3.Project.Trim().Length > 0 ? 1 : 0;

	            case Element_Type.Format:
	                return Bib.Bib_Info.Original_Description.Extent.Length > 0 ? 1 : 0;

	            case Element_Type.Frequency:
	                return Bib.Bib_Info.Origin_Info.Frequencies_Count;

	            case Element_Type.Genre:
	                return Bib.Bib_Info.Genres_Count;

	            case Element_Type.Holding:
	                return 1;

	            case Element_Type.Wordmark:
	                return Bib.Behaviors.Wordmark_Count > 0 ? 1 : 0;

	            case Element_Type.Identifier:
	                return Bib.Bib_Info.Identifiers_Count;

	            case Element_Type.Language:
	                return Bib.Bib_Info.Languages.Count(thisLanguage => thisLanguage.Language_Text.Length > 0);

	            case Element_Type.MainThumbnail:
	                return Bib.Behaviors.Main_Thumbnail.Length > 0 ? 1 : 0;

	            case Element_Type.Manufacturer:
	                return Bib.Bib_Info.Manufacturers_Count;

	            case Element_Type.Note:
	                return Bib.Bib_Info.Notes.Count(thisNote => thisNote.Note_Type != Note_Type_Enum.statement_of_responsibility);

	            case Element_Type.OtherURL:
	                return (Bib.Bib_Info.Location.Other_URL.Length > 0) || (Bib.Bib_Info.Location.Other_URL_Note.Length > 0) ? 1 : 0;

	            case Element_Type.PALMM_Code:
	                return 1;

	            case Element_Type.Publisher:
	                return Bib.Bib_Info.Publishers_Count;

	            case Element_Type.Publication_Place:
	                if (Bib.Bib_Info.Publishers_Count > 0)
	                {
	                    if (Bib.Bib_Info.Publishers.SelectMany(thisName => thisName.Places).Any(thisPlace => thisPlace.Place_Text.Length > 0))
	                    {
	                        return 1;
	                    }
	                }
	                return 0;

	            case Element_Type.RecordOrigin:
	                return Bib.Bib_Info.Record.Record_Origin.Length > 0 ? 1 : 0;

	            case Element_Type.RecordStatus:
	                return 1;

	            case Element_Type.RelatedItem:
	                return Bib.Bib_Info.RelatedItems_Count;

	            case Element_Type.Rights:
	                return Bib.Bib_Info.Access_Condition.Text.Length > 0 ? 1 : 0;

	            case Element_Type.Scale:
	                if (Bib.Bib_Info.Subjects.Where(thisSubject => thisSubject.Class_Type == Subject_Info_Type.Cartographics).Any(thisSubject => ((Subject_Info_Cartographics)thisSubject).Scale.Length > 0))
	                {
	                    return 1;
	                }
	                return 0;

	            case Element_Type.SerialHierarchy:
	                return Bib.Behaviors.Serial_Info.Count > 0 ? 1 : 0;

	            case Element_Type.Source_Institution:
	                return 1;

	            case Element_Type.Source_Note:
	                return Bib.Bib_Info.Notes.Count(thisNote => thisNote.Note_Type == Note_Type_Enum.source);

	            case Element_Type.Spatial:
	                int hierSubjectCount = 0;
	                if (thisElement.Display_SubType == "dublincore")
	                {
	                    foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
	                    {
	                        if (thisSubject.Class_Type == Subject_Info_Type.Hierarchical_Spatial)
	                            hierSubjectCount++;
	                        else if (thisSubject.Class_Type == Subject_Info_Type.Standard)
	                        {
	                            Subject_Info_Standard standSubject = (Subject_Info_Standard)thisSubject;
	                            if ((standSubject.Genres_Count == 0) && (standSubject.Occupations_Count == 0) && (standSubject.Topics_Count == 0))
	                            {
	                                hierSubjectCount++;
	                            }
	                        }
	                    } 
	                }
	                else
	                {
	                    hierSubjectCount += Bib.Bib_Info.Subjects.Count(thisSubject => thisSubject.Class_Type == Subject_Info_Type.Hierarchical_Spatial);
	                }

	                return hierSubjectCount;

	            case Element_Type.Structure_Map:
	                return 1;

	            case Element_Type.Subject:
	                bool standard = true;
	                if ((thisElement.Display_SubType == "simple") || (thisElement.Display_SubType == "dublincore"))
	                {
	                    if (((Subject_Simple_Element)thisElement).Seperate_Dublin_Core_Spatial_Exists)
	                        standard = false;
	                }
	                int subjectCount = 0;
	                if (standard)
	                {
	                    subjectCount += Bib.Bib_Info.Subjects.Count(thisSubject => (thisSubject.Class_Type == Subject_Info_Type.Standard) || (thisSubject.Class_Type == Subject_Info_Type.TitleInfo) || (thisSubject.Class_Type == Subject_Info_Type.Name));
	                }
	                else
	                {
	                    foreach (Subject_Info thisSubject in Bib.Bib_Info.Subjects)
	                    {
	                        switch (thisSubject.Class_Type)
	                        {
	                            case Subject_Info_Type.TitleInfo:
	                                subjectCount++;
	                                break;

	                            case Subject_Info_Type.Name:
	                                subjectCount++;
	                                break;

	                            case Subject_Info_Type.Standard:
	                                Subject_Info_Standard standSubject = (Subject_Info_Standard)thisSubject;
	                                if ((standSubject.Topics_Count > 0) || (standSubject.Occupations_Count > 0) || (standSubject.Genres_Count > 0))
	                                    subjectCount++;
	                                break;
	                        }
	                    }
	                }
	                return subjectCount;

	            case Element_Type.TargetAudience:
	                return Bib.Bib_Info.Target_Audiences.Any(thisTarget => thisTarget.Authority != "marctarget") ? 1 : 0;

	            case Element_Type.Temporal:
	                return Bib.Bib_Info.TemporalSubjects_Count;

	            case Element_Type.Title:
	                return 1;

	            case Element_Type.Title_Other:
	                int title_count = 0;
	                if (Bib.Bib_Info.Main_Title.Subtitle.Length > 0)
	                {
	                    title_count++;
	                }

	                if ((Bib.Bib_Info.hasSeriesTitle) && (Bib.Bib_Info.SeriesTitle.Title.Length > 0))
	                {
	                    title_count++;
	                }

	                if (Bib.Bib_Info.Other_Titles_Count > 0)
	                {
	                    title_count += Bib.Bib_Info.Other_Titles.Count(thisTitle => thisTitle.Title.Length > 0);
	                }
	                return title_count;

	            case Element_Type.Type:
	                return 1;

	            case Element_Type.VID:
	                return 1;

	            case Element_Type.Viewer:
	                return Bib.Behaviors.Views_Count;

	            case Element_Type.VRA_CulturalContext:
	                VRACore_Info vraInfo = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo != null ? vraInfo.Cultural_Context_Count : 0;

	            case Element_Type.VRA_Inscription:
                    VRACore_Info vraInfo2 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo2 != null ? vraInfo2.Inscription_Count : 0;

	            case Element_Type.VRA_Material:
                    VRACore_Info vraInfo3 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo3 != null ? vraInfo3.Material_Count : 0;

	            case Element_Type.VRA_Measurement:
                    VRACore_Info vraInfo4 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo4 != null ? vraInfo4.Measurement_Count : 0;
	  
	            case Element_Type.VRA_StateEdition:
                    VRACore_Info vraInfo5 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo5 != null ? vraInfo5.State_Edition_Count : 0;

	            case Element_Type.VRA_StylePeriod:
                    VRACore_Info vraInfo6 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo6 != null ? vraInfo6.Style_Period_Count : 0;

	            case Element_Type.VRA_Technique:
                    VRACore_Info vraInfo7 = Bib.Get_Metadata_Module(GlobalVar.VRACORE_METADATA_MODULE_KEY) as VRACore_Info;
	                return vraInfo7 != null ? vraInfo7.Technique_Count : 0;

	            case Element_Type.Web_Skin:
	                return Bib.Behaviors.Web_Skin_Count > 0 ? 1 : 0;

	            case Element_Type.ZT_Class:
                    Zoological_Taxonomy_Info darwinCoreInfo = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo != null && darwinCoreInfo.Class.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_CommonName:
                    Zoological_Taxonomy_Info darwinCoreInfo2 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo2 != null && darwinCoreInfo2.Common_Name.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_Family:
                    Zoological_Taxonomy_Info darwinCoreInfo3 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo3 != null && darwinCoreInfo3.Family.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_Genus:
                    Zoological_Taxonomy_Info darwinCoreInfo4 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo4 != null && darwinCoreInfo4.Genus.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_HigherClassification:
                    Zoological_Taxonomy_Info darwinCoreInfo5 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo5 != null && darwinCoreInfo5.Higher_Classification.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_Kingdom:
                    Zoological_Taxonomy_Info darwinCoreInfo6 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo6 != null && darwinCoreInfo6.Kingdom.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_Order:
                    Zoological_Taxonomy_Info darwinCoreInfo7 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo7 != null && darwinCoreInfo7.Order.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_Phylum:
                    Zoological_Taxonomy_Info darwinCoreInfo8 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo8 != null && darwinCoreInfo8.Phylum.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_ScientificName:
                    Zoological_Taxonomy_Info darwinCoreInfo9 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo9 != null && darwinCoreInfo9.Scientific_Name.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_SpecificEpithet:
                    Zoological_Taxonomy_Info darwinCoreInfo10 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo10 != null && darwinCoreInfo10.Specific_Epithet.Length > 0  ? 1 : 0;

	            case Element_Type.ZT_TaxonRank:
                    Zoological_Taxonomy_Info darwinCoreInfo11 = Bib.Get_Metadata_Module(GlobalVar.ZOOLOGICAL_TAXONOMY_METADATA_MODULE_KEY) as Zoological_Taxonomy_Info;
	                return darwinCoreInfo11 != null && darwinCoreInfo11.Taxonomic_Rank.Length > 0  ? 1 : 0;

	            default:
	                return 0;
	        }
	    }

	    #endregion

	    /// <summary> Add a title in a particular language to this page </summary>
		/// <param name="Language"> Language of the title </param>
        /// <param name="Language_Specific_Title"> Title to display </param>
		public void Set_Title( Template_Language Language, string Language_Specific_Title )
		{
			// If the title has no length, this is a request to REMOVE a title
            if (String.IsNullOrEmpty(Language_Specific_Title))
			{
				if ( allTitles.ContainsKey( Language ) )
					allTitles.Remove( Language );
			}
			else
			{
				// Add this new title to the collection
                allTitles[Language] = Language_Specific_Title;
			}
		}

		/// <summary> Sets the language to use for this page </summary>
		/// <param name="Language"> Language to display </param>
		public void Set_Language( Template_Language Language )
		{
			// Set the current page title by the language
			if ( allTitles.ContainsKey( Language ))
				Title = allTitles[ Language ];
			else if ( allTitles.ContainsKey( Template_Language.English ))
				Title = allTitles[ Template_Language.English ];
			else
				Title = String.Empty;

			// Set this for each page
			foreach( Template_Page thisPage in inputs )
			{
				thisPage.Set_Language( Language );
			}
		}

	    /// <summary> Tests to see if the data the user has entered into all the elements is valid, according
	    /// to the requirements specified in the XML template file </summary>
	    /// <returns> TRUE if valid, otherwise FALSE </returns>
        /// <remarks>Any messages from the validation routine is saved in the <see cref="Validity_Errors"/>  parameter </remarks>
	    public bool isValid()
		{
			// Build errors as you go
			StringBuilder errors = new StringBuilder();
			bool valid = true;

	        // Step through each element in each panel of each page
			foreach( Template_Page thisPage in InputPages )
			{
				foreach( Template_Panel thisPanel in thisPage.Panels )
				{
					int element_count = 0;
					while ( element_count < thisPanel.Elements.Count )
					{
						// Is this a mandatory element?
						if ( thisPanel.Elements[ element_count ].Mandatory )
						{
							bool found = false;
							int mandatory_check_count = element_count;
							while (( mandatory_check_count < thisPanel.Elements.Count ) && ( thisPanel.Elements[ element_count ].Type == thisPanel.Elements[ mandatory_check_count ].Type ))
							{
								if ( thisPanel.Elements[ mandatory_check_count ].hasValue )
								{
									found = true;
									break;
								}
								mandatory_check_count++;
							}

							// Did it make it all the way through without finding a value?
							if ( !found )
							{
								errors.Append( "'" +  thisPanel.Elements[ element_count ].Title.Trim() + "'" + MessageProvider_Gateway.Is_a_Mandatory_Field + "\n" );
								valid = false;
							}

							// Set the element count to the last element checked
							element_count = mandatory_check_count;
						}
						else
						{						
							// Check for value on this element
							if ( thisPanel.Elements[ element_count ].hasValue )
							{
								if ( !thisPanel.Elements[ element_count ].isValid() )
								{
									errors.Append( thisPanel.Elements[ element_count ].Invalid_String + "\n");
									valid = false;
								}
							}
						}

						// Go to next element
						element_count++;
					}
				}
			}

			if ( valid )
				return true;

	        Validity_Errors = errors.ToString();
	        return false;
		}
	}
}
