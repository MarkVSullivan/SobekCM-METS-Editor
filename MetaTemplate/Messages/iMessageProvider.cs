namespace SobekCM.METS_Editor.Messages
{
	/// <summary> Interface which each MessageProvider object
	/// must implement. </summary>
	interface iMessageProvider
	{
		string Database_Error_Caught { get; }

		string Database_Error { get; }

		string METS_File_As_XML { get; }

		string Close { get; }

		string Unable_to_Update_Metadata_Date { get; }

		string Optional_Update_Available_Message { get;	}

		string Optional_Update_Available_Title { get; }

		string Mandatory_Update_Available_Message { get; }

		string Mandatory_Update_Available_Title { get; }

		string Unable_to_Check_Version_Message { get; }

		string Unable_to_Check_Version_Title { get; }

		string METS_File_Saved_Message { get; }

		string Error_Saving_METS_File_Message { get; }

		string Error_Saving_METS_File_Title { get; }

		string Error_Validating_METS_File_Message { get; }

		string Error_Validating_METS_File_Title { get; }

		string METS_Viewer { get; }

		string View_Mode { get; }

		string Edit_Mode { get; }

		string Mode { get; }

		string Cancel { get; }

		string Exit { get; }

		string Save { get; }

		string[] Menu_Items { get; }

		string Is_a_Mandatory_Field { get; }

        string Division_Name { get; }

        string Name { get;  }

        string Type { get;  }

        string Apply { get; }
	}
}
