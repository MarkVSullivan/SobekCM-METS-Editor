using System;
using System.Data;
using System.IO;

namespace DLC.Tools.Language
{
	public enum Languages
	{
		English = 1,
		French,
		Spanish
	}

    ///// <summary>
    ///// Summary description for Preferred_Language.
    ///// </summary>
    //public class Preferred_Language
    //{
    //    private const string DEFAULT_USER="DEFAULT USER";
    //    private static string file;

    //    static Preferred_Language()
    //    {
    //        file = String.Empty;
    //    }


    //    public static Languages User_Language
    //    {
    //        get
    //        {
    //            Get_Language( user );
    //        }
    //        set
    //        {
    //            Set_Language(value);
    //        }
    //    }

    //    public static Languages Default_Language
    //    {
    //        get
    //        {
    //            return Preferred_Language.Get_Language_For_User( DEFAULT_USER );
    //        }
    //        set
    //        {
    //            Preferred_Language.Set_Language_For_User( DEFAULT_USER, value );
    //        }
    //    }

    //    public static Languages Language_From_Int( int LanguageInt )
    //    {
    //        if ( LanguageInt == 2 )
    //            return Languages.French;
    //        if ( LanguageInt == 3 )
    //            return Languages.Spanish;
    //        return Languages.English;
    //    }

    //    public static void Set_Language_For_User( string User, Languages NewLanguage )
    //    {
    //        // Read the dataset
    //        DataSet languageSet = new DataSet();
    //        if ( !System.IO.File.Exists( file ) )
    //        {
    //            if ( !Directory.Exists(( new FileInfo( file )).DirectoryName ))
    //            {
    //                Directory.CreateDirectory( ( new FileInfo( file )).DirectoryName );
    //            }

    //            Create_File( file, NewLanguage );
    //        }

    //        languageSet.ReadXml( file );
	
    //        // Is there a matching row for this user already?
    //        DataRow[] selected = languageSet.Tables[0].Select("User = '" + User + "'");
    //        if ( selected.Length > 0 )
    //        {
    //            selected[0][1] = (int) NewLanguage;
    //        }
    //        else
    //        {
    //            DataRow newRow = languageSet.Tables[0].NewRow();
    //            newRow[0] = User;
    //            newRow[1] = (int) NewLanguage;
    //            languageSet.Tables[0].Rows.Add( newRow );
    //        }

    //        // Save the dataset
    //        languageSet.WriteXml( file );
    //    }

    //    public static Languages Get_Language_For_User( string User )
    //    {
    //        // Read the dataset
    //        DataSet languageSet = new DataSet();
    //        languageSet.ReadXml( file );

    //        // Try to find the default language
    //        DataRow[] selected = languageSet.Tables[0].Select("User = '" + User + "'");
    //        if ( selected.Length == 0 )
    //        {
    //            if ( User == DEFAULT_USER )
    //            {
    //                Set_Language_For_User( DEFAULT_USER, Languages.English );
    //                return Languages.English;
    //            }
    //            else
    //            {
    //                Set_Language_For_User( User, Default_Language );
    //                return Default_Language;
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                int Language_As_Int = Convert.ToInt16(selected[0][1]);
    //                return Preferred_Language.Language_From_Int( Language_As_Int );
    //            }
    //            catch
    //            {
    //                return Languages.English;
    //            }
    //        }
    //    }
	//}
}
