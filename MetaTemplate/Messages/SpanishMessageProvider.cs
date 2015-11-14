namespace SobekCM.METS_Editor.Messages
{
	/// <summary>
	/// Summary description for SpanishMessageProvider.
	/// </summary>
	public class SpanishMessageProvider : iMessageProvider
	{
	    #region iMessageProvider Members

		public string Database_Error_Caught
		{
			get
			{
				return "Error ejecutando el procedimiento guardado '{0}'.       ";
			}
		}

		public string Database_Error
		{
			get
			{
				return "Error en Base de Datos";
			}
		}

		public string METS_File_As_XML 
		{ 
			get	{ return "Archivo de METS como XML";	}
		}

		public string Close
		{
			get	{	return "Cerrar";	}
		}

		public string Unable_to_Update_Metadata_Date 
		{ 
			get	{	return "La fecha de metadatos no se puede actualizar en la Base de Datos.";	}
		}

		public string Optional_Update_Available_Message 
		{ 
			get	{	return "Una versi�n nueva de este programa esta disponible.      \n\n�Quisiera Descargarla?";  }	
		}


		public string Optional_Update_Available_Title  
		{ 
			get	{	return "Necesita la Versi�n Nueva";	}	
		}

		public string Mandatory_Update_Available_Message  
		{ 
			get	{	return "Hay una versi�n nueva de esta aplicaci�n.       \n\nPor favor espere mientras que el software de instalaci�n abre.      "; }	
		}

		public string Mandatory_Update_Available_Title  
		{ 
			get	{	return "Necesita la Versi�n Nueva"; }	
		}

		public string Unable_to_Check_Version_Message  
		{ 
			get	{	return "Un error fue encontrado durante el reviso rutinario de versi�n.            \n\nEs posible que su programa no sea la ultima versi�n disponible."; }	
		}

		public string Unable_to_Check_Version_Title  
		{ 
			get	{	return "Error Revisando Versi�n"; }	
		}

		public string METS_File_Saved_Message 
		{ 
			get	{	return "Archivo de METS Guardo como "; }	
		}

		public string Error_Saving_METS_File_Message  
		{ 
			get	{	return "Error Guardando Archivo de METS!"; }	
		}

		public string Error_Saving_METS_File_Title  
		{ 
			get	{	return "Error"; }	
		}

		public string Error_Validating_METS_File_Message  
		{ 
			get	{	return "ERROR VALIDANDO ENTRADA"; }	
		}

		public string Error_Validating_METS_File_Title  
		{ 
			get	{	return "Entrada Invalida"; }	
		}

		public string METS_Viewer 
		{ 
			get	{	return "Visionador de METS";	}
		}

		public string View_Mode
		{ 
			get	{	return "Modo de Visionar"; }	
		}

		public string Edit_Mode
		{ 
			get	{	return "Modo de Editar"; }
		}

		public string Mode
		{ 
			get	{	return "Modo"; }
		}

		public string Cancel
		{ 
			get	{	return "Cancelar"; }
		}

		public string Exit
		{ 
			get	{	return "Salir"; }
		}

		public string Save
		{ 
			get	{	return "Guardar"; }
		}

		public string[] Menu_Items
		{ 
			get	
			{
				return new string[44] { "Acci�n", 
										  "Nuevo",  
										  "Abrir",  
										  "Reciente",  
										  "Guardar",  
										  "Salir", 
										  "Opciones", 
										  "Idioma", 
										  "Ingl�s", 
										  "Franc�s", 
										  "Espa�ol", 
										  "Tipo de Letra",  
										  "Tama�o de Letra",  
										  "peque�o",  
										  "mediano",  
										  "grande",  
										  "extra grande",  
										  "Ayuda",  
										  "Acerca de dLOC",
										  "Ver",
										  "Archivo METS",
                                          "Archivo de Web",
                                          "Proyecto",
                                          "Importar Desde...",
                                          "Archivo CSV o Excel",
                                          "Archivo Dublin Core",
                                          "Archivo EAD",
                                          "MARC Registro",
                                          "Archivo MarcXML",
                                          "Archivo de Datos Marc21",
                                          "Archivo MODS",
                                          "Archivo MXF",
                                          "Guardar Como...",
                                          "Plantilla",
                                          "(none)",
                                          "Preferencias de Metadatos",
                                          "Numeraci�n Autom�tica",
                                          "No Numeraci�n Autom�tica",
                                          "Dentro de la Divisi�n de la Misma",
                                          "Todo el Documento",
                                          "Ayuda en l�nea",
                                          "Fuente Ayuda Metadatos",
                                          "P�ginas SobekCM Ayuda",
                                          "No Ayuda" };
			}
		}

		public string Is_a_Mandatory_Field
		{
			get	{	return " es un campo obligatorio.";		}
		}

        /// <summary> Get the <i>Division Name</i> message </summary>
        public string Division_Name
        {
            get
            {
                return "Nombre de divisi�n";
            }
        }

        /// <summary> Get the <i>Type</i> message </summary>
        public string Type
        {
            get
            {
                return "Tipo";
            }
        }
        /// <summary> Get the <i>Name</i> message </summary>
        public string Name
        {
            get
            {
                return "Nombre";
            }
        }

        public string Apply
        {
            get { return "Aplicar"; }
        }

		#endregion
	}
}
