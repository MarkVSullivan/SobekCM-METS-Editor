namespace SobekCM.METS_Editor.Messages
{
	/// <summary>
	/// Summary description for FrenchMessageProvider.
	/// </summary>
	public class FrenchMessageProvider : iMessageProvider
	{
	    #region iMessageProvider Members

		public string Database_Error_Caught
		{
			get
			{
				return "Erreur en ex�cutant le proc�d� gard� '{0}'.       ";
			}
		}

		public string Database_Error
		{
			get
			{
				return "Erreur de Base de Donn�es";
			}
		}

		public string METS_File_As_XML 
		{ 
			get	{ return "Fichier METS comme XML";	}
		}

		public string Close
		{
			get	{	return "Fermer";	}
		}

		public string Unable_to_Update_Metadata_Date 
		{ 
			get	{	return "La date de m�tadonn�es ne peut pas �tre actualis�e dans la Base de Donn�es.";	}
		}

		/// <summary> Gets the <i>Optional Update is Available</i> message </summary>
		public string Optional_Update_Available_Message 
		{ 
			get	{	return "Une plus nouvelle version de ce logiciel est disponible.\n\n     Voudriez-vous am�liorer votre logiciel maintenant?        ";  }	
		}

		/// <summary> Gets the <i>Optional Update is Available</i> title </summary>
		public string Optional_Update_Available_Title 
		{ 
			get	{	return "Nouvelle version disponible";	}	
		}

		/// <summary> Gets the <i>Mandatory Update is Available</i> message </summary>
		public string Mandatory_Update_Available_Message 
		{ 
			get	{	return "Il y a une nouvelle version de cette application qui doit �tre install�e.     \n\nAttendez s'il vous pla�t comme le logiciel d'installation est lanc�.      "; }	
		}

		/// <summary> Gets the <i>Mandatory Update is Available</i> title </summary>
		public string Mandatory_Update_Available_Title 
		{ 
			get	{	return "Nouvelle Version N�cessaire"; }	
		}

		/// <summary> Gets the <i>Unable to Check Version</i> message </summary>
		public string Unable_to_Check_Version_Message 
		{ 
			get	{	return "On a rencontr� une erreur en ex�cutant le ch�que de version de logiciel.     \n\nVotre logiciel peut ne pas �tre la version le plus r�cente."; }	
		}

		/// <summary> Gets the <i>Unable to Check Version</i> title </summary>
		public string Unable_to_Check_Version_Title 
		{ 
			get	{	return "Erreur de Ch�que de Version"; }	
		}

		public string METS_File_Saved_Message 
		{ 
			get	{	return "Fichier de METS a gard� comme"; }	
		}

		public string Error_Saving_METS_File_Message  
		{ 
			get	{	return "ERREUR EN GARDANT LE FICHIER DE METS!"; }	
		}

		public string Error_Saving_METS_File_Title  
		{ 
			get	{	return "Erreur "; }	
		}

		public string Error_Validating_METS_File_Message  
		{ 
			get	{	return "ERREUR  VALIDANT L'ENTR�E."; }	
		}

		public string Error_Validating_METS_File_Title  
		{ 
			get	{	return "Entr�e inadmissible "; }	
		}

		public string METS_Viewer 
		{ 
			get	{	return "Visionneuse de METS";	}
		}

		public string View_Mode
		{ 
			get	{	return "Mode de Vue"; }	
		}

		public string Edit_Mode
		{ 
			get	{	return "Mode de �diter"; }
		}

		public string Mode
		{ 
			get	{	return "Mode"; }
		}

		public string Cancel
		{
			get	{	return "Annuler";	}
		}

		public string Exit
		{ 
			get	{	return "Sortez"; }
		}

		public string Save
		{ 
			get	{	return "Garder"; }
		}

		public string[] Menu_Items
		{ 
			get	
			{
				return new string[44] { "Action", 
										  "Nouveau",  
										  "Ouvrir",  
										  "R�cent",  
										  "Garder",  
										  "Sortez", 
										  "Options", 
										  "Langue", 
										  "Anglais", 
										  "Fran�ais", 
										  "Espagnol", 
										  "Police de Caract�res",  
										  "Taille de Police",  
										  "petite",  
										  "moyenne",  
										  "grande",  
										  "plus-grande",  
										  "Aide",  
										  "Au sujet de dLOC",
									      "Vue",
										  "Fichier METS",
                                          "Dossier d'Web",
                                          "Projet",
                                          "Importer � partir...",
                                          "Fichier CSV ou Excel",
                                          "Fichier Dublin Core",
                                          "Fichier EAD",
                                          "MARC Record",
                                          "Fichier MarcXML",
                                          "Fichier de donn�es Marc21",
                                          "Fichier MODS",
                                          "Fichier MXF",
                                          "Garder Comme...",
                                          "Calibre",
                                          "(none)",
                                          "Pr�f�rences M�tadonn�es",
                                          "Num�rotation Automatique",
                                          "Pas de Num�rotation Automatique",
                                          "Dans la M�me Division",
                                          "Document Entier",
                                          "Aide en Ligne",
                                          "Source d'aide de M�tadonn�es",
                                          "Pages d'aide SobekCM",
                                          "Aucune Aide" };
			}
		}

		public string Is_a_Mandatory_Field
		{
			get	{	return " est un champ obligatoire.";		}
		}

        /// <summary> Get the <i>Division Name</i> message </summary>
        public string Division_Name
        {
            get
            {
                return "Nom de division";
            }
        }

        /// <summary> Get the <i>Type</i> message </summary>
        public string Type
        {
            get
            {
                return "Type";
            }
        }
        /// <summary> Get the <i>Name</i> message </summary>
        public string Name
        {
            get
            {
                return "Nom";
            }
        }

        public string Apply
        {
            get { return "Appliquer"; }
        }

		#endregion
	}
}
