#region Using directives

using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
	/// <summary>
	/// Summary description for Column_Field_Map.
	/// </summary>
	public class Column_Field_Map
	{
		public readonly int Column_Index;
		public readonly Mapped_Fields Field;

		public Column_Field_Map( int Column_Index, Mapped_Fields Field )
		{
			// Save these values
			this.Column_Index = Column_Index;
			this.Field = Field;
		}
	}
}
