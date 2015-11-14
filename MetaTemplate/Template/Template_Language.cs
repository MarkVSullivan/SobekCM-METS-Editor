namespace SobekCM.METS_Editor.Template
{
	/// <summary> Enumeration defines the languages the template can display</summary>
	public enum Template_Language
	{
        /// <summary> UNKNOWN or default language </summary>
		Unknown = -1,

        /// <summary> English as the language for the template and all forms/messages </summary>
		English = 0,

        /// <summary> French as the language for the template and all forms/messages </summary>
		French,

        /// <summary> Spanish as the language for the template and all forms/messages </summary>
		Spanish
	}

	/// <summary> Class converts between <see cref="Template_Language"/> enum and ISO 639.2 three character
	/// language codes </summary>
	public class Template_Language_Convertor
	{
	    /// <summary> Convert from three character ISO 639.2 language code to <see cref="Template_Language"/> enum. </summary>
		/// <param name="Code"> Three character ISO 639.2 language code </param>
		/// <returns> Related Template_Language Enum </returns>
		public static Template_Language ToEnum( string Code )
		{
			switch ( Code.ToUpper() )
			{
				case "ENG":
					return Template_Language.English;

				case "SPA":
					return Template_Language.Spanish;
	
				case "FRE":
					return Template_Language.French;

				case "ESL":
					return Template_Language.Spanish;	
				
				case "FRA":
					return Template_Language.French;

				default:
					return Template_Language.Unknown;
			}
		}

		/// <summary> Convert from <see cref="Template_Language"/> enum to three character ISO 639.2 language code. </summary>
        /// <param name="Enum"> Related Template_Language Enum </param>
		/// <returns> Three character ISO 639.2 language code </returns>
		public static string ToCode( Template_Language Enum )
		{
			switch ( Enum )
			{
				case Template_Language.English:
					return "eng";

				case Template_Language.French:
					return "fre";

				case Template_Language.Spanish:
					return "spa";

				case Template_Language.Unknown:
					return "unk";

				default:
					return "unk";
			}
		}
	}
}
