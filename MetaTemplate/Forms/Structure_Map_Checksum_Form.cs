#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Forms
{
    /// <summary> Enumeration for desired action from the Structure_Map_Checksum_Form dialog </summary>
    public enum Structure_Map_Checksum_Form_Action_Enum : byte
    {
        /// <summary> Clear all the checksums </summary>
        CLEAR_CHECKSUMS,

        /// <summary> Calculate checksums </summary>
        CALCULATE_CHECKSUMS,

        /// <summary> No action requested </summary>
        CANCEL
    }

    /// <summary> Form is used from the structure map element do determine what 
    /// checksum subaction the user would like to perform.   </summary>
    public partial class Structure_Map_Checksum_Form : Form
    {
        /// <summary> Constructor for a new instance of this dialog form </summary>
        public Structure_Map_Checksum_Form()
        {
            InitializeComponent();

            // Set the default action
            Selected_Action = Structure_Map_Checksum_Form_Action_Enum.CANCEL;
        }

        /// <summary> User's selected subaction from this form </summary>
        public Structure_Map_Checksum_Form_Action_Enum Selected_Action { get; private set; }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Checksum_Form_Action_Enum.CANCEL;
            Close();
        }

        private void calculateChecksumsButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Checksum_Form_Action_Enum.CALCULATE_CHECKSUMS;
            Close();
        }

        private void clearChecksumsButton_Button_Pressed(object sender, EventArgs e)
        {
            Selected_Action = Structure_Map_Checksum_Form_Action_Enum.CLEAR_CHECKSUMS;
            Close();
        }
    }
}
