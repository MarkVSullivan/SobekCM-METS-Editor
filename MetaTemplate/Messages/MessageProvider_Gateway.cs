#region Using directives

using SobekCM.METS_Editor.Template;

#endregion

namespace SobekCM.METS_Editor.Messages
{
	/// <summary> Gateway provides access to the appropriate
	/// MessageProvider object.  This provides the text for each GUI message
	/// in the user's preferred language.  </summary>
	public class MessageProvider_Gateway
	{
		private static iMessageProvider messages;
		
		static MessageProvider_Gateway()
		{
			messages = new EnglishMessageProvider();
		}

        public static void Set_Language( Template_Language GUI_Language)
		{
			switch( GUI_Language )
			{
                case Template_Language.English:
					messages = new EnglishMessageProvider();
					break;
                case Template_Language.French:
					messages = new FrenchMessageProvider();
					break;
                case Template_Language.Spanish:
					messages = new SpanishMessageProvider();
					break;
			}
		}

		public static string Database_Error_Caught 
		{ 
			get {	return messages.Database_Error_Caught;		}
		}

		public static string Database_Error 
		{ 
			get	{	return Database_Error;	 }
		}

		public static string METS_File_As_XML 
		{ 
			get	{ return messages.METS_File_As_XML;		}
		}

		public static string Close
		{
			get	{	return messages.Close;		}
		}

		public static string Unable_to_Update_Metadata_Date 
		{ 
			get { return messages.Unable_to_Update_Metadata_Date;	}
		}

		public static string Optional_Update_Available_Message 
		{
			get	{	return messages.Optional_Update_Available_Message; 	}
		}

		public static string Optional_Update_Available_Title  
		{
			get	{	return messages.Optional_Update_Available_Title; 	}
		}

		public static string Mandatory_Update_Available_Message 
		{
			get	{	return messages.Mandatory_Update_Available_Message; 	}
		}

		public static string Mandatory_Update_Available_Title 
		{
			get	{	return messages.Mandatory_Update_Available_Title; 	}
		}

		public static string Unable_to_Check_Version_Message 
		{
			get	{	return messages.Unable_to_Check_Version_Message; 	}
		}

		public static string Unable_to_Check_Version_Title 
		{
			get	{	return messages.Unable_to_Check_Version_Title; 	}
		}

		public static string METS_File_Saved_Message
		{
			get	{	return messages.METS_File_Saved_Message; 	}
		}

		public static string Error_Saving_METS_File_Message
		{
			get	{	return messages.Error_Saving_METS_File_Message; 	}
		}

		public static string Error_Saving_METS_File_Title
		{
			get	{	return messages.Error_Saving_METS_File_Title; 	}
		}

		public static string Error_Validating_METS_File_Message
		{
			get	{	return messages.Error_Validating_METS_File_Message; 	}
		}

		public static string Error_Validating_METS_File_Title
		{
			get	{	return messages.Error_Validating_METS_File_Title; 	}
		}

		public static string METS_Viewer
		{
			get	{	return messages.METS_Viewer; 	}
		}

		public static string View_Mode
		{
			get	{	return messages.View_Mode; 	}
		}

		public static string Edit_Mode
		{
			get	{	return messages.Edit_Mode; 	}
		}

		public static string Mode
		{
			get	{	return messages.Mode; 	}
		}

		public static string Cancel
		{
			get	{	return messages.Cancel; 	}
		}

		public static string Exit
		{
			get	{	return messages.Exit; 	}
		}

		public static string Save
		{
			get	{	return messages.Save; 	}
		}

		public static string[] Menu_Items
		{
			get	{	return messages.Menu_Items; 	}
		}

		public static string Is_a_Mandatory_Field
		{
			get	{	return messages.Is_a_Mandatory_Field;		}
		}

        public static string Division_Name
        {
            get { return messages.Division_Name; }
        }

        public static string Name 
        {
            get { return messages.Name; }
        }

        public static string Type
        {
            get { return messages.Type; }
        }

        public static string Apply
        {
            get { return messages.Apply; }
        }
	}
}
