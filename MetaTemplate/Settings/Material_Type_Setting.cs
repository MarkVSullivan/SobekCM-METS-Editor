#region Using directives

using System;

#endregion

namespace SobekCM.METS_Editor.Settings
{
    /// <summary> Information about a single possible material type, including mapping from the
    /// display name to the MODS type and a possible SobekCM genre </summary>
    public class Material_Type_Setting
    {
        /// <summary> Constructor for a new instance of the Material_Type_Setting class  </summary>
        public Material_Type_Setting()
        {
            Display_Name = String.Empty;
            MODS_Type = String.Empty;
            SobekCM_Genre = String.Empty;
        }

        /// <summary> Constructor for a new instance of the Material_Type_Setting class  </summary>
        /// <param name="Display_Name"> Material type which displays in the metadata template element </param>
        /// <param name="MODS_Type"> MODS resource type which maps to this display name </param>
        /// <param name="SobekCM_Genre"> Any possible genre (with authority='sobekcm') linked to this display name </param>
        public Material_Type_Setting( string Display_Name, string MODS_Type, string SobekCM_Genre )
        {
            this.Display_Name = Display_Name;
            this.MODS_Type = MODS_Type;
            this.SobekCM_Genre = SobekCM_Genre;
        }

        /// <summary> Material type which displays in the metadata template element </summary>
        public string Display_Name { get; set; }

        /// <summary>  MODS resource type which maps to this display name </summary>
        public string MODS_Type { get; set; }

        /// <summary>  Any possible genre (with authority='sobekcm') linked to this display name </summary>
        public string SobekCM_Genre { get; set; }
    }
}
