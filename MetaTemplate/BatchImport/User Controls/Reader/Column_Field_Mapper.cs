#region Using directives

using System.Collections;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
	/// <summary>
	/// Summary description for Column_Field_Mapper.
	/// </summary>
	public class Column_Field_Mapper
	{
		private Hashtable Columns_To_Field_Hash;

		public Column_Field_Mapper()
		{
			Columns_To_Field_Hash = new Hashtable();
		}

		public bool isMapped( int Column_Index )
		{
			return Columns_To_Field_Hash.Contains( Column_Index );
		}

		public void Add( int Column_Index, Mapped_Fields Field )
		{
			Columns_To_Field_Hash[ Column_Index ] = new Column_Field_Map( Column_Index, Field );
		}

		public Column_Field_Map Get_Field( int Column_Index )
		{
			return ( Column_Field_Map ) Columns_To_Field_Hash[ Column_Index ];
		}
	}
}
