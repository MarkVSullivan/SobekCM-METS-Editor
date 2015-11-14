#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DLC.Tools.Forms;
using DLC.Tools.StartUp;
using GemBox.Spreadsheet;
using SobekCM.METS_Editor.FirstLaunch;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Messages;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;

#endregion

namespace SobekCM.METS_Editor
{
	/// <summary> StartUp is the main entrance point into the Metadata Template Application </summary>
	class Startup
	{
		/// <summary> The main entry point for the application.  </summary>
		[STAThread]
		static void Main(string[] args)
		{
            // Set the Gembox spreadsheet license key
        //    SpreadsheetInfo.SetLicense("YOUR-CODE-HERE");

            // Currently set this flag to false
            Control.CheckForIllegalCrossThreadCalls = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set some colors
            // Set some defaults for round buttons
            Round_Button.Inactive_Border_Color = Color.DarkGray;
            Round_Button.Inactive_Text_Color = Color.White;
            Round_Button.Inactive_Fill_Color = Color.DarkGray;
            Round_Button.Mouse_Down_Border_Color = Color.Gray;
            Round_Button.Mouse_Down_Text_Color = Color.White;
            Round_Button.Mouse_Down_Fill_Color = Color.Gray;
            Round_Button.Active_Border_Color = Color.FromArgb(25, 68, 141);
            Round_Button.Active_Fill_Color = Color.FromArgb(25, 68, 141);
            Round_Button.Active_Text_Color = Color.White;

            // If this was the first launch, show that form
            if (MetaTemplate_UserSettings.First_Launch)
            {
                // Show the welcome screen first
                First_Launch_Welcome welcomeForm = new First_Launch_Welcome();
                if (welcomeForm.ShowDialog() == DialogResult.Cancel)
                    return;

                int step = 0;
                while (step < 6)
                {
                    switch (step)
                    {
                        case 0:
                            // Get general use first
                            First_Launch_Form1 firstForm = new First_Launch_Form1();
                            if (firstForm.ShowDialog() == DialogResult.Cancel)
                                return;
                            else
                                step++;
                            break;

                        case 1:
                            // Show options for the basic bibliographic metadata options
                            First_Launch_Form2 secondForm = new First_Launch_Form2();
                            if (secondForm.ShowDialog() == DialogResult.Cancel)
                                step--;
                            else
                                step++;
                            break;

                        case 2:
                            // Show the basic template choices
                            First_Launch_Form3 thirdForm = new First_Launch_Form3();
                            if (thirdForm.ShowDialog() == DialogResult.Cancel)
                                step--;
                            else
                                step++;
                            break;

                        case 3:
                            // Show options for any additional add-ons to the template
                            First_Launch_Form4 fourthForm = new First_Launch_Form4();
                            if (fourthForm.ShowDialog() == DialogResult.Cancel)
                                step--;
                            else
                            {
                                if (MetaTemplate_UserSettings.AddOns_Enabled.Contains("FCLA"))
                                {
                                    First_Launch_FDA_Constants fdaConstants = new First_Launch_FDA_Constants();
                                    if (fdaConstants.ShowDialog() == DialogResult.Cancel)
                                    {
                                        step--;
                                    }
                                }

                                if ((step == 3) && (MetaTemplate_UserSettings.AddOns_Enabled.Contains("SOBEKCM")))
                                {
                                    First_Launch_SobekCM_Constants fdaConstants = new First_Launch_SobekCM_Constants();
                                    if (fdaConstants.ShowDialog() == DialogResult.Cancel)
                                    {
                                        step--;
                                    }
                                }

                                step++;
                            }
                            break;



                        case 4:
                            // Show file options ( checksums, auto-include, etc.. )
                            First_Launch_Form5 fifthForm = new First_Launch_Form5();
                            if (fifthForm.ShowDialog() == DialogResult.Cancel)
                                step--;
                            else
                                step++;
                            break;

                        case 5:
                            // Show localization options
                            First_Launch_Form6 sixthForm = new First_Launch_Form6();
                            if (sixthForm.ShowDialog() == DialogResult.Cancel)
                                step--;
                            else
                            {
                                // Save the set values
                                MetaTemplate_UserSettings.Save();
                                step++;
                            }
                            break;
                    }
                }
            }
				
            // Check version			
			if (( Application.StartupPath.ToUpper().IndexOf("TOOLKIT") < 0 ) && (( !MetaTemplate_UserSettings.Perform_Version_Check_On_StartUp ) || ( Check_Version())))
			{
                // Delete anything remaining in the temporary folder from a previous run
                string documents_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string temp_folder = documents_folder + "\\METS Editor\\Temporary";

                // If there is a temporary folder, delete all items
                if (Directory.Exists(temp_folder))
                {
                    string[] files = Directory.GetFiles(temp_folder);
                    foreach (string thisFile in files)
                    {
                        try
                        {
                            File.Delete(thisFile);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }

                // Make sure the TEMPLATES subdirectory exists
                if (!Directory.Exists(Application.StartupPath + "\\Templates"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Templates");

                // Make sure the PROJECTS subdirectory exists
                if (!Directory.Exists(Application.StartupPath + "\\Projects"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Projects");

                // Configure the metadata
			    Metadata_Profile_Configurer.Configure_Metadata_From_UserSettings();

				// Get the template and METS file from the argument list
				string template_file = Application.StartupPath + "\\Templates\\" + MetaTemplate_UserSettings.Default_Template + ".xml";
				string mets_file = String.Empty;
				string save_directory = App_Config_Reader.METS_Save_Location;

				// Set the readonly attribute
				bool read_only = false;
                bool exclude_divisions = false;
				if (( args.Length > 0 ) && ( args[0].ToUpper() == "TRUE" ))
				{
					read_only = true;
				}

				// Get name of the template and METS file from the arguments
				foreach( string thisArgs in args )
				{
                    // For backward compatability
                    if (thisArgs == "TRUE")
                        read_only = true;
                    
                    // Check for readonly flag
                    if (thisArgs == "--readonly")
                        read_only = true;

                    // Check for no divisions
                    if (thisArgs == "--nodiv")
                        exclude_divisions = true;

                    // Check for template name
					if ( thisArgs.ToUpper().IndexOf( ".MMT" ) >= 0 )
					{
						template_file = thisArgs;
					}

                    // Check for METS file
					if (( thisArgs.ToUpper().IndexOf( ".METS" ) >= 0 ) || ( thisArgs.ToUpper().IndexOf(".PMETS") >= 0 ))
					{
						mets_file = thisArgs;
                        if (mets_file.IndexOf("http:") < 0)
                        {
                            save_directory = (new FileInfo(mets_file)).Directory.FullName;
                        }
                        else
                        {
                            save_directory = App_Config_Reader.METS_Save_Location;
                        }
					}
				}

                // If the template does not exist, throw a message
                if ((template_file.Length == 0) || (!File.Exists(template_file)))
                {
                    MessageBox.Show("ERROR!  No template file to load or template does not exist.   ", "Template Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Look for the user's default template
                    if (File.Exists(Application.StartupPath + "\\Templates\\" + MetaTemplate_UserSettings.Default_Template))
                    {
                        template_file = Application.StartupPath + "\\Templates\\" + MetaTemplate_UserSettings.Default_Template;
                    }
                    else
                    {
                        // Look for the default template
                        if (File.Exists(Application.StartupPath + "\\Templates\\default.mmt"))
                        {
                            template_file = Application.StartupPath + "\\Templates\\default.mmt";
                            MetaTemplate_UserSettings.Default_Template = (new FileInfo(template_file)).Name;
                            MetaTemplate_UserSettings.Save();
                        }
                        else
                        {
                            // Look for ANY template
                            string[] templates = Directory.GetFiles(Application.StartupPath + "\\Templates\\", "*.mmt");
                            if (templates.Length > 0)
                            {
                                template_file = templates[0];
                                MetaTemplate_UserSettings.Default_Template = (new FileInfo(template_file)).Name;
                                MetaTemplate_UserSettings.Save();
                            }
                            else
                            {
                                // Create the default template
                                Template_Creator.Create(Application.StartupPath + "\\Templates\\default.mmt");
                                template_file = Application.StartupPath + "\\Templates\\default.mmt";
                                MetaTemplate_UserSettings.Default_Template = (new FileInfo(template_file)).Name;
                                MetaTemplate_UserSettings.Save();
                            }
                        }
                    }
                }

				// If the template does not exist, throw a message
				if (( template_file.Length == 0 ) || ( !File.Exists( template_file )))
				{
					MessageBox.Show("ERROR!  No template file to load or template does not exist.   ","Template Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				}
				else
				{
                    try
                    {
                        // Create the template form to display this
                        Template_Form templateForm = new Template_Form( mets_file, save_directory, exclude_divisions);
                        templateForm.ShowDialog();
                    }
                    catch (Exception ee)
                    {
                        ErrorMessageBox.Show("An unexpected error occurred in the application.\n\nPlease report this issue to Mark Sullivan (MarSull@uflib.ufl.edu).", "Unexpected Error", ee);
                    }
				}
			}
		}


		private static bool Check_Version()
		{
			if ( File.Exists( Application.StartupPath + "\\noupdate.txt" ))
				return true;

			// Flag tells whether or not this is updating
			bool updating = false;

			// Create a version checker to see if this is the latest version
			VersionChecker versionChecker = new VersionChecker();
			if ( versionChecker.UpdateExists() )
			{
				// Later, we will determine if the update is mandatory or not here
				if ( versionChecker.UpdateMandatory() )
				{
					MessageBox.Show( MessageProvider_Gateway.Mandatory_Update_Available_Message, MessageProvider_Gateway.Mandatory_Update_Available_Title, 
						MessageBoxButtons.OK, MessageBoxIcon.Information);

					// Start the Setup files to update this application and then exit
					versionChecker.Update();
					updating = true;
				}
				else
				{
					// A non-mandatory update exists
					DialogResult update = MessageBox.Show( MessageProvider_Gateway.Optional_Update_Available_Message,
						MessageProvider_Gateway.Optional_Update_Available_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question );
					if ( update.Equals(DialogResult.Yes ) )
					{					
						// Start the Setup files to update this application and then exit
						versionChecker.Update();
						updating = true;
					}
				}
			}

			// Only continue if this application is not being updated
			if ( !updating )
			{
				// Now, if an error was encountered anywhere, show an error message
				if ( versionChecker.Error )
					MessageBox.Show( MessageProvider_Gateway.Unable_to_Check_Version_Message, MessageProvider_Gateway.Unable_to_Check_Version_Title, MessageBoxButtons.OK, 
						MessageBoxIcon.Warning  );
			}

			return !updating;
		}
	}
}	
