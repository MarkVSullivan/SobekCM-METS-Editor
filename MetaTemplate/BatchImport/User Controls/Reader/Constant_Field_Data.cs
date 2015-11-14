#region Using directives

using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
	/// <summary>
	/// Summary description for Constant_Field_Data.
	/// </summary>
	public class Constant_Field_Data
	{
		public readonly Mapped_Fields Field;
		public readonly string Data;

		public Constant_Field_Data( Mapped_Fields Field, string Data )
		{
			// Save the parameters
			this.Data = Data;
			this.Field = Field;
		}
	}
}
