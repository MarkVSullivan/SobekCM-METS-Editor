using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLC.Tools;

namespace SobekCM.METS_Editor.Template
{
    public partial class New_Project_Form : Form
    {
        public string Valid_Project_Code { get; private set; }

        public New_Project_Form()
        {
            InitializeComponent();

            Valid_Project_Code = String.Empty;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                textBox1.BorderStyle = BorderStyle.FixedSingle;
            }

            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void okButton_Button_Pressed(object sender, EventArgs e)
        {
            string possibleProjCode = textBox1.Text.Trim().Replace(".pmets", "");

            // Check that something was entered
            if (possibleProjCode.Length == 0)
            {
                MessageBox.Show("You must enter the name or project code for the new project.", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check that it is unique
            string proj_dir = Application.StartupPath + "\\Projects";
            string proj_file = proj_dir + "\\" + possibleProjCode + ".pmets";
            if (System.IO.File.Exists(proj_file))
            {
                MessageBox.Show("Project of that name already exists.\n\nYou must enter a unique name or project code for the new project.", "Project Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Valid!
            Valid_Project_Code = possibleProjCode;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Button_Pressed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
