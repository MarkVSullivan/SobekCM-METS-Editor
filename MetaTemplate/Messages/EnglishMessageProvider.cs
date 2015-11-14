namespace SobekCM.METS_Editor.Messages
{
	/// <summary>
	/// Summary description for EnglishMessageProvider.
	/// </summary>
	public class EnglishMessageProvider : iMessageProvider
	{
	    #region iMessageProvider Members

		public string Database_Error_Caught
		{
			get
			{
				return "Error while executing stored procedure '{0}'.       ";
			}
		}

		public string Database_Error
		{
			get
			{
				return "Database Error";
			}
		}

		public string METS_File_As_XML 
		{ 
			get	{ return "METS File as XML";	}
		}

		public string Close
		{
			get	{	return "Close";	}
		}

		public string Unable_to_Update_Metadata_Date 
		{ 
			get	{	return "Unable to update the metadata date in the database.";	}
		}

		public string Optional_Update_Available_Message 
		{ 
			get	{	return "A newer version of this software is available.            \n\nWould you like to upgrade now?";  }	
		}


		public string Optional_Update_Available_Title  
		{ 
			get	{	return "New Version Available";	}	
		}

		public string Mandatory_Update_Available_Message  
		{ 
			get	{	return "There is a new version of this application which must be installed.      \n\nPlease stand by as the installation software is launched.      "; }	
		}

		public string Mandatory_Update_Available_Title  
		{ 
			get	{	return "New Version Needed"; }	
		}

		public string Unable_to_Check_Version_Message  
		{ 
			get	{	return "An error was encountered while performing the routine Version check.              \n\nYour application may not be the most recent version."; }	
		}

		public string Unable_to_Check_Version_Title  
		{ 
			get	{	return "Version Check Error"; }	
		}

		public string METS_File_Saved_Message 
		{ 
			get	{	return "METS File successfully saved as"; }	
		}

		public string Error_Saving_METS_File_Message  
		{ 
			get	{	return "ERROR SAVING METS FILE!"; }	
		}

		public string Error_Saving_METS_File_Title  
		{ 
			get	{	return "Error"; }	
		}

		public string Error_Validating_METS_File_Message  
		{ 
			get	{	return "ERRORS VALIDATING INPUT."; }	
		}

		public string Error_Validating_METS_File_Title  
		{ 
			get	{	return "Invalid Input"; }	
		}

		public string METS_Viewer 
		{ 
			get	{	return "METS Viewer";	}
		}

		public string View_Mode
		{ 
			get	{	return "View Mode"; }	
		}

		public string Edit_Mode
		{ 
			get	{	return "Edit Mode"; }
		}

		public string Mode
		{ 
			get	{	return "Mode"; }
		}

		public string Cancel
		{ 
			get	{	return "Cancel"; }
		}

		public string Exit
		{ 
			get	{	return "Exit"; }
		}

		public string Save
		{ 
			get	{	return "Finish"; }
		}

		public string[] Menu_Items
		{ 
			get	
			{
				return new string[44] { "Action", 
										  "New",  
										  "Open",  
										  "Recent",  
										  "Save",  
										  "Exit", 
										  "Options", 
										  "Language", 
										  "English", 
										  "French", 
										  "Spanish", 
										  "Font Face",  
										  "Font Size",  
										  "small",  
										  "medium",  
										  "large",  
										  "x-large",  
										  "Help",  
										  "About",
										  "View",
				                          "METS File",
                                          "From the web",
                                          "Project",
                                          "Import From...",
                                          "CSV or Excel File",
                                          "Dublin Core File",
                                          "EAD File",
                                          "MARC Record",
                                          "MarcXML File",
                                          "Marc21 Data File",
                                          "MODS File",
                                          "MXF File",
                                          "Save As...",
                                          "Template",
                                          "(none)",
                                          "Metadata Preferences",
                                          "Automatic Numbering",
                                          "No Automatic Numbering",
                                          "Within Same Division",
                                          "Entire Document",
                                          "Online Help",
                                          "Metadata Help Source",
                                          "SobekCM Help Pages",
                                          "No Help"                };
			}
		}

		public string Is_a_Mandatory_Field
		{
			get	{	return " is a mandatory field.";		}
		}

        /// <summary> Get the <i>Division Name</i> message </summary>
        public string Division_Name
        {
            get
            {
                return "Division Name";
            }
        }

        public string Name
        {
            get { return "Name"; }
        }

        public string Type
        {
            get { return "Type"; }
        }

        public string Apply
        {
            get { return "Apply"; }
        }

		#endregion
	}
}
