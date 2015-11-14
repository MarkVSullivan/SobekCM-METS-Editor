#region Using directives

using System.Configuration;

#endregion

namespace SobekCM.METS_Editor
{
	/// <summary>
	/// Summary description for App_Config_Reader.
	/// </summary>
	public class App_Config_Reader
	{
		/// <summary> Location to save the final METS file </summary>
		public static readonly string METS_Save_Location;

		/// <summary> Static constructor for the App_Config_Reader object </summary>
		static App_Config_Reader()
		{
			// Get the flag which tracking database to use
			METS_Save_Location = ConfigurationSettings.AppSettings["METS Save Location"].ToUpper().Trim();
			if (( METS_Save_Location.Length > 0 ) && (( METS_Save_Location[ METS_Save_Location.Length - 1 ] != '\\' ) && ( METS_Save_Location[ METS_Save_Location.Length - 1 ] != '/' )))
			{
				METS_Save_Location = METS_Save_Location + "\\";
			}
		}
	}
}
