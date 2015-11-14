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
				return "Erreur en exécutant le procédé gardé '{0}'.       ";
			}
		}

		public string Database_Error
		{
			get
			{
				return "Erreur de Base de Données";
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
			get	{	return "La date de métadonnées ne peut pas être actualisée dans la Base de Données.";	}
		}

		/// <summary> Gets the <i>Optional Update is Available</i> message </summary>
		public string Optional_Update_Available_Message 
		{ 
			get	{	return "Une plus nouvelle version de ce logiciel est disponible.\n\n     Voudriez-vous améliorer votre logiciel maintenant?        ";  }	
		}

		/// <summary> Gets the <i>Optional Update is Available</i> title </summary>
		public string Optional_Update_Available_Title 
		{ 
			get	{	return "Nouvelle version disponible";	}	
		}

		/// <summary> Gets the <i>Mandatory Update is Available</i> message </summary>
		public string Mandatory_Update_Available_Message 
		{ 
			get	{	return "Il y a une nouvelle version de cette application qui doit être installée.     \n\nAttendez s'il vous plaît comme le logiciel d'installation est lancé.      "; }	
		}

		/// <summary> Gets the <i>Mandatory Update is Available</i> title </summary>
		public string Mandatory_Update_Available_Title 
		{ 
			get	{	return "Nouvelle Version Nécessaire"; }	
		}

		/// <summary> Gets the <i>Unable to Check Version</i> message </summary>
		public string Unable_to_Check_Version_Message 
		{ 
			get	{	return "On a rencontré une erreur en exécutant le chèque de version de logiciel.     \n\nVotre logiciel peut ne pas être la version le plus récente."; }	
		}

		/// <summary> Gets the <i>Unable to Check Version</i> title </summary>
		public string Unable_to_Check_Version_Title 
		{ 
			get	{	return "Erreur de Chèque de Version"; }	
		}

		public string METS_File_Saved_Message 
		{ 
			get	{	return "Fichier de METS a gardé comme"; }	
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
			get	{	return "ERREUR  VALIDANT L'ENTRÉE."; }	
		}

		public string Error_Validating_METS_File_Title  
		{ 
			get	{	return "Entrée inadmissible "; }	
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
			get	{	return "Mode de Éditer"; }
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
										  "Récent",  
										  "Garder",  
										  "Sortez", 
										  "Options", 
										  "Langue", 
										  "Anglais", 
										  "Français", 
										  "Espagnol", 
										  "Police de Caractères",  
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
                                          "Importer à partir...",
                                          "Fichier CSV ou Excel",
                                          "Fichier Dublin Core",
                                          "Fichier EAD",
                                          "MARC Record",
                                          "Fichier MarcXML",
                                          "Fichier de données Marc21",
                                          "Fichier MODS",
                                          "Fichier MXF",
                                          "Garder Comme...",
                                          "Calibre",
                                          "(none)",
                                          "Préférences Métadonnées",
                                          "Numérotation Automatique",
                                          "Pas de Numérotation Automatique",
                                          "Dans la Même Division",
                                          "Document Entier",
                                          "Aide en Ligne",
                                          "Source d'aide de Métadonnées",
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
