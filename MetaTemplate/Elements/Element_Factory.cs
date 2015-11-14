#region Using directives

using System;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Factory which generates each element object, depending on the 
	/// provided element type </summary>
	public class Element_Factory
	{
	    /// <summary> Gets the element object associated with the provided type </summary>
		/// <param name="Type">Element type</param>
		/// <returns>Correct element object</returns>
		public static abstract_Element getElement( string Type )
		{
			return getElement( Element_Type_Convertor.ToType( Type ), String.Empty );
		}

		/// <summary> Gets the element object associated with the provided type </summary>
		/// <param name="Type">Element type</param>
		/// <param name="SubType"> Subtype for this element</param>
		/// <returns>Correct element object</returns>
		public static abstract_Element getElement( string Type, string SubType )
		{
			return getElement( Element_Type_Convertor.ToType( Type ), SubType );
		}

		/// <summary> Gets the element object associated with the provided type </summary>
		/// <param name="Type">Element type</param>
		/// <returns>Correct element object</returns>
		public static abstract_Element getElement( Element_Type Type, string SubType )
		{
			switch( Type )
			{
				case Element_Type.Abstract:
                    switch (SubType.ToUpper())
                    {
                        case "COMPLEX":
                            return new Abstract_Complex_Element();

                        case "SIMPLE":
                            return new Abstract_Summary_Element();

                        default:
                            return new Abstract_Form_Element();
                    }

                case Element_Type.Aggregations:
                    return new SobekCM_Aggregations_Element();

                case Element_Type.Affiliation:
                    return new Affiliation_Form_Element();

				case Element_Type.Attribution:
					return new Attribution_Element();

                case Element_Type.BibID:
                    return new BibId_Element();

                case Element_Type.Classification:
                    return new Classification_Element();

                case Element_Type.Coordinates:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Coordinates_Element();

                        default:
                            return new Coordinate_Form_Element();
                    }

				case Element_Type.Creator:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Creator_Simple_Element();

                        default:
                            return new Name_Form_Element();
                    }

                case Element_Type.Contributor:
                    return new Contributor_Simple_Element();

                case Element_Type.CreatorNotes:
                    return new Creator_Notes_Element();

                case Element_Type.Date:
                    if (SubType.ToUpper() == "DUBLINCORE")
                        return new Date_Element(true);
                    else
                        return new Date_Element(false);

                case Element_Type.DateCopyrighted:
                    return new Date_Copyrighted_Element();

                case Element_Type.DescriptionStandard:
                    return new Description_Standard_Element();

				case Element_Type.Donor:
                    if (SubType.ToUpper() == "SIMPLE")
                    {
                        return new Donor_Simple_Element();
                    }
                    else
                    {
                        return new Donor_Form_Element();
                    }

                case Element_Type.Edition:
                    return new Edition_Element();

                case Element_Type.EAD:
                    return new EAD_Form_Element();

                case Element_Type.EncodingLevel:
                    return new Encoding_Level_Element();

                case Element_Type.ETD_CommitteeChair:
                    return new ETD_CommitteeChair();

                case Element_Type.ETD_CommitteeCoChair:
                    return new ETD_CommitteeCoChair();

                case Element_Type.ETD_CommitteeMember:
                    return new ETD_CommitteeMember();

                case Element_Type.ETD_Degree:
                    return new ETD_Degree();

                case Element_Type.ETD_DegreeDiscipline:
                    return new ETD_DegreeDiscipline();

                case Element_Type.ETD_DegreeGrantor:
                    return new ETD_DegreeGrantor();

                case Element_Type.ETD_DegreeLevel:
                    return new ETD_DegreeLevel();

                case Element_Type.ETD_GraduationDate:
                    return new ETD_GraduationDate();

                case Element_Type.FCLA_Flags:
                    return new FCLA_Flags_Element();

                case Element_Type.FDA_Account:
                    return new FDA_Account_Element();

                case Element_Type.FDA_SubAccount:
                    return new FDA_SubAccount_Element();

                case Element_Type.FDA_Project:
                    return new FDA_Project_Element();

                case Element_Type.Format:
                    if (SubType.ToUpper() == "DUBLINCORE")
                        return new Format_Element(true);
                    else
                        return new Format_Element(false);

                case Element_Type.Frequency:
                    return new Frequency_Element();

				case Element_Type.Genre:
					if ( SubType.ToUpper() == "COMPLEX" )
					{
						return new Genre_Complex_Element();
					}
					else
					{
						return new Genre_Simple_Element();
					}					

				case Element_Type.Holding:
					if ( SubType.ToUpper() == "SIMPLE" )
					{
						return new Holding_Simple_Element();
					}
					else
					{
						return new Holding_Complex_Element();
					}

                case Element_Type.Identifier:
                    if (SubType.ToUpper() == "SIMPLE")
                    {
                        return new Identifier_Simple_Element();
                    }
                    else
                    {
                        return new Identifier_Complex_Element();
                    }

				case Element_Type.Language:
					return new Language_Element();

                case Element_Type.MainThumbnail:
                    return new SobekCM_Main_Thumbnail_Element();

                case Element_Type.Manufacturer:
                    return new Manufacturer_Form_Element();

                case Element_Type.METS_ObjectID:
                    return new METS_ObjectID_Element();

                case Element_Type.Note:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Note_Element(false);

                        case "DUBLINCORE":
                            return new Note_Element(true);

                        case "COMPLEX":
                            return new Note_Complex_Element();

                        default:
                            return new Note_Form_Element();
                    }

                case Element_Type.OtherURL:
                    return new Other_URL_Form_Element();

                case Element_Type.PALMM_Code:
                    return new PALMM_Code_Element();

                case Element_Type.Publication_Place:
                    return new Publication_Place_Element();

                case Element_Type.Publication_Status:
                    return new Publication_Status_Element();

				case Element_Type.Publisher:
				    switch( SubType.ToUpper() )
				    {
					    case "SIMPLE":
						    return new Publisher_Simple_Element();
					    default:
                            return new Publisher_Form_Element();
				    }

                case Element_Type.RecordOrigin:
                    return new Record_Origin_Element();

                case Element_Type.RecordStatus:
                    return new RecordStatus_Element();

                case Element_Type.RelatedItem:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Related_Item_Element(false);

                        case "DUBLINCORE":
                            return new Related_Item_Element(true);

                        default:
                            return new Related_Item_Form_Element();
                    }


				case Element_Type.Rights:
					return new Rights_Element();

				case Element_Type.Scale:
					return new Scale_Element();

                case Element_Type.SerialHierarchy:
                    return new Serial_Hierarchy_Form_Element();

				case Element_Type.Source_Institution:
                    switch( SubType.ToUpper() )
                    {
                        case "SIMPLE":
						    return new Source_Simple_Element();
					
                        default:
						    return new Source_Complex_Element();
					}

                case Element_Type.Source_Note:
                    return new Source_Note_Element();

				case Element_Type.Spatial:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Spatial_Simple_Element(false);

                        case "DUBLINCORE":
                            return new Spatial_Simple_Element(true);

                        case "COMPLEX":
                            return new Spatial_Complex_Element();

                        default:
                            return new Hierarchical_Geography_Form_Element();
                    }

                case Element_Type.Structure_Map:
                    return new Structure_Map_Element();
                 

				case Element_Type.Subject:
                    switch (SubType.ToUpper())
                    {
                        case "COMPLEX":
                            return new Subject_Complex_Element();

                        case "SIMPLE":
                            return new Subject_Simple_Element(false);

                        case "DUBLINCORE":
                            return new Subject_Simple_Element(true);

                        default:
                            return new Subject_Form_Element();
                    }

                case Element_Type.TargetAudience:
                    return new Target_Audience_Element();

				case Element_Type.Temporal:
					if ( SubType.ToUpper() == "SIMPLE" )
					{
						return new Temporal_Simple_Element();
					}
					else
					{
						return new Temporal_Complex_Element();
					}

				case Element_Type.Title:
                    switch (SubType.ToUpper())
                    {
                        case "PANEL":
                            return new Title_Panel_Element();

                        case "ALL":
                            return new Title_Panel_Form_Element();

                        case "SIMPLE":
                            return new Title_Element();

                        default:
                            return new Main_Title_Form_Element();
                    }

                case Element_Type.Title_Other:
                    switch (SubType.ToUpper())
                    {
                        case "FORM":
                            return new Other_Title_Form_Element();

                        default:
                            return new Other_Title_Element();
                    }

				case Element_Type.Type:
                    switch (SubType.ToUpper())
                    {
                        case "SIMPLE":
                            return new Type_Element( true );

                        case "UNCONTROLLED":
                            return new Type_Element(false);

                        default:
                            return new Material_Type_Form_Element();
                    }

                case Element_Type.VID:
                    return new VID_Element();

                case Element_Type.Viewer:
                    return new SobekCM_Viewer_Element();

                case Element_Type.VRA_CulturalContext:
                    return new VRA_CulturalContext_Element();

                case Element_Type.VRA_Inscription:
                    return new VRA_Inscription_Element();

                case Element_Type.VRA_Material:
                    return new VRA_Materials_Element();

                case Element_Type.VRA_Measurement:
                    return new VRA_Measurement_Element();

                case Element_Type.VRA_StateEdition:
                    return new VRA_StateEdition_Element();

                case Element_Type.VRA_StylePeriod:
                    return new VRA_StylePeriod_Element();

                case Element_Type.VRA_Technique:
                    return new VRA_Technique_Element();

                case Element_Type.Web_Skin:
                    return new SobekCM_Web_Skin_Element();

                case Element_Type.Wordmark:
                    return new SobekCM_Wordmark_Element();

                case Element_Type.ZT_Class:
                    return new ZT_Class();

                case Element_Type.ZT_CommonName:
                    return new ZT_Common_Name();

                case Element_Type.ZT_Family:
                    return new ZT_Family();

                case Element_Type.ZT_Genus:
                    return new ZT_Genus();

                case Element_Type.ZT_HigherClassification:
                    return new ZT_Higher_Classification();

                case Element_Type.ZT_Kingdom:
                    return new ZT_Kingdom();

                case Element_Type.ZT_Order:
                    return new ZT_Order();

                case Element_Type.ZT_Phylum:
                    return new ZT_Phylum();

                case Element_Type.ZT_ScientificName:
                    return new ZT_Scientific_Name();

                case Element_Type.ZT_SpecificEpithet:
                    return new ZT_Species();

                case Element_Type.ZT_TaxonRank:
                    return new ZT_Taxonomic_Rank();

				default:
					return null;
			}
		}
	}
}
