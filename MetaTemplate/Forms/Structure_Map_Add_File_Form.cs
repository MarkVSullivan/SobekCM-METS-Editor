#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    /// <summary> Enumeration for desired action from the Structure_Map_Add_File_Form dialog </summary>
    public enum Structure_Map_Add_File_Form_Action_Enum : byte
    {
        /// <summary> Add a local file </summary>
        ADD_LOCAL,

        /// <summary> Add a remote file </summary>
        ADD_REMOTE,

        /// <summary> No action requested </summary>
        CANCEL
    }

    /// <summary> Form is used from the structure map element do determine what 
    /// checksum subaction the user would like to perform.   </summary>
    public partial class Structure_Map_Add_File_Form : Form
    {
        /// <summary> Constructor for a new instance of this dialog form </summary>
        public Structure_Map_Add_File_Form()
        {
            InitializeComponent();

            // Set the default action
            Selected_Action = Structure_Map_Add_File_Form_Action_Enum.CANCEL;
        }

        /// <summary> User's selected subaction from this form </summary>
        public Structure_Map_Add_File_Form_Action_Enum Selected_Action { get; private set; }

        private void localFileButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Add_File_Form_Action_Enum.ADD_LOCAL;
            Close();
        }

        private void remoteFileButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Add_File_Form_Action_Enum.ADD_REMOTE;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Add_File_Form_Action_Enum.CANCEL;
            Close();
        }
    }
}
