namespace SobekCM.METS_Editor.AddOns
{
    /// <summary> Basic information about a single add-on discovered and read during
    /// application start-up </summary>
    public class AddOn_Info
    {
        /// <summary> Simple description of the metadata functionality included in this add-on  </summary>
        public readonly string Basic_Description;

        /// <summary> Name of the source file for this add-on </summary>
        public readonly string FileName;

        /// <summary> Additional notes regarding the functionality of this add-on </summary>
        public readonly string Notes;

        /// <summary> Constructor for a new instance of the AddOn_Info class </summary>
        /// <param name="FileName">Name of the source file for this add-on</param>
        /// <param name="Basic_Description">Simple description of the metadata functionality included in this add-on</param>
        /// <param name="Notes">Additional notes regarding the functionality of this add-on </param>
        public AddOn_Info(string FileName, string Basic_Description, string Notes)
        {
            this.FileName = FileName;
            this.Basic_Description = Basic_Description;
            this.Notes = Notes;
        }
    }
}
