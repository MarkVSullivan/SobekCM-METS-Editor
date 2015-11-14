#region Using directives

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DLC.Tools;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Messages;
using SobekCM.METS_Editor.Tools;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary>
	/// Summary description for Division_Name_Form.
	/// </summary>
	public class Division_Name_Form : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private Label typeLabel;
		private CheckBox multipleCheckBox;
        private TextBox nameTextBox;
		private bool multiple;
		private ComboBox divisionComboBox;
		private string div_name;
		private Label nameLabel;
		private TextBox divisionTextBox;
        private int divTypeId;
        private Button hiddenCancelButton;
        private Round_Button saveButton;
		private Division_Types_Errors_Table.Division_TypeDataTable divType;

		public Division_Name_Form( bool imageClass, Division_Types_Errors_Table.Division_TypeDataTable Divisions_Table )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            multipleCheckBox.Hide();

			// Set default
			div_name = String.Empty;

			// Get the correct table
            divType = Divisions_Table;

			// Add all the name choices
			if ( divType.Count > 1 )
			{
				divisionTextBox.Hide();
				divisionComboBox.Sorted = true;
				foreach(  Division_Types_Errors_Table.Division_TypeRow thisDivision in divType )
				{
					divisionComboBox.Items.Add( thisDivision.TypeName );
				}
			}
			else
			{
				divisionComboBox.Hide();
				divisionTextBox.Text = divType[0].TypeName;
				divTypeId = divType[0].DivisionTypeID;
			}


			nameLabel.Text = MessageProvider_Gateway.Name + ":";
            typeLabel.Text = MessageProvider_Gateway.Type + ":";
            Text = MessageProvider_Gateway.Division_Name;

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                multipleCheckBox.FlatStyle = FlatStyle.Flat;
            }
		}

		public int Division_Type_ID
		{
			get	{	return divTypeId;		}
			set	{	divTypeId = value;		}
		}

		public string Division_Name
		{
			get	{	return div_name;			}
			set	
			{	
				// If this is section, start the text box with 'Section'
				if ((( divisionTextBox.Text == "Section" ) || ( divisionTextBox.Text == "Sección" )) && ( value.Length == 0 ))
				{
					nameTextBox.Text = divisionTextBox.Text + " ";
				}
				else
				{
					nameTextBox.Text = value;		
				}
			}
		}

		public string Division_Type
		{
			set	
			{	
				divisionComboBox.Text = value;	
				divisionTextBox.Text = value;

				// If this is section, start the text box with 'Section'
				if ((( value == "Section" ) || ( value == "Sección" )) && ( nameTextBox.Text.Trim().Length == 0 ))
				{
					nameTextBox.Text = value + " ";
				}
			}
			get	
			{	
				if ( divisionTextBox.Visible )
					return divisionTextBox.Text;
				else
                    return divisionComboBox.Text;	

			}
		}

		public bool Multiple_Divisions
		{
			get	{	return multiple;						}
			set	
			{
				multiple = value;		
				multipleCheckBox.Checked = value;	}
		}


		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Division_Name_Form));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.multipleCheckBox = new System.Windows.Forms.CheckBox();
            this.divisionComboBox = new System.Windows.Forms.ComboBox();
            this.divisionTextBox = new System.Windows.Forms.TextBox();
            this.hiddenCancelButton = new System.Windows.Forms.Button();
            this.saveButton = new SobekCM.METS_Editor.Forms.Round_Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Location = new System.Drawing.Point(72, 56);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(352, 22);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(16, 56);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 23);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // typeLabel
            // 
            this.typeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(16, 16);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(56, 23);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Type:";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // multipleCheckBox
            // 
            this.multipleCheckBox.Location = new System.Drawing.Point(88, 96);
            this.multipleCheckBox.Name = "multipleCheckBox";
            this.multipleCheckBox.Size = new System.Drawing.Size(248, 24);
            this.multipleCheckBox.TabIndex = 4;
            this.multipleCheckBox.Text = "Multiple Divisions on Page";
            this.multipleCheckBox.UseVisualStyleBackColor = true;
            this.multipleCheckBox.CheckedChanged += new System.EventHandler(this.multipleCheckBox_CheckedChanged);
            // 
            // divisionComboBox
            // 
            this.divisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.divisionComboBox.Location = new System.Drawing.Point(72, 16);
            this.divisionComboBox.Name = "divisionComboBox";
            this.divisionComboBox.Size = new System.Drawing.Size(216, 22);
            this.divisionComboBox.TabIndex = 6;
            this.divisionComboBox.SelectedIndexChanged += new System.EventHandler(this.divisionComboBox_SelectedIndexChanged);
            // 
            // divisionTextBox
            // 
            this.divisionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.divisionTextBox.Location = new System.Drawing.Point(72, 16);
            this.divisionTextBox.Name = "divisionTextBox";
            this.divisionTextBox.Size = new System.Drawing.Size(216, 22);
            this.divisionTextBox.TabIndex = 7;
            // 
            // hiddenCancelButton
            // 
            this.hiddenCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hiddenCancelButton.Location = new System.Drawing.Point(253, 155);
            this.hiddenCancelButton.Name = "hiddenCancelButton";
            this.hiddenCancelButton.Size = new System.Drawing.Size(22, 23);
            this.hiddenCancelButton.TabIndex = 12;
            this.hiddenCancelButton.TabStop = false;
            this.hiddenCancelButton.UseVisualStyleBackColor = true;
            this.hiddenCancelButton.Click += new System.EventHandler(this.hiddenCancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Button_Enabled = true;
            this.saveButton.Button_Text = "OK";
            this.saveButton.Button_Type = SobekCM.METS_Editor.Forms.Round_Button.Button_Type_Enum.Standard;
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(330, 94);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 26);
            this.saveButton.TabIndex = 13;
            this.saveButton.Button_Pressed += new System.EventHandler(this.okButton_Click);
            // 
            // Division_Name_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelButton = this.hiddenCancelButton;
            this.ClientSize = new System.Drawing.Size(440, 135);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.hiddenCancelButton);
            this.Controls.Add(this.divisionTextBox);
            this.Controls.Add(this.divisionComboBox);
            this.Controls.Add(this.multipleCheckBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Division_Name_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Division Name";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void multipleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			multiple = multipleCheckBox.Checked;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			multiple = multipleCheckBox.Checked;
			div_name = nameTextBox.Text;
            DialogResult = DialogResult.OK;
			Close();
		}

		private void nameTextBox_TextChanged(object sender, EventArgs e)
		{
			div_name = nameTextBox.Text;
		}

		private void divisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Check to see if this is named
			string thisDiv = divisionComboBox.Text;
			
			DataRow[] selected = divType.Select( "TypeName = '" + thisDiv + "'" );
			if ( selected.Length > 0 )
			{
				// Save this ID
				divTypeId = Convert.ToInt32( selected[0]["DivisionTypeID"] );

				// Set the enable status of the name box
				if ( Convert.ToBoolean( selected[0]["NamedDivision"]) )
				{
					nameTextBox.Enabled = true;
				}
				else
				{
					nameTextBox.Clear();
					nameTextBox.Enabled = false;
				}
			}
		}

        private void hiddenCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}
