using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DLC.Tools
{
	/// <summary> IS_UserSettings is an abstract, static class which uses Isolated Storage and XML to
	/// store and retrive the settings for an application's user.
	/// </summary>
	/// <remarks> Object created by Mark V Sullivan (2004) for University of Florida's Digital Library Center. </remarks>
	public abstract class IS_UserSettings
	{
		/// <summary> Holds the DataSet which has all of the settings for this user </summary>
		protected static DataSet dsSettings;

		/// <summary> DataRow which holds the specific values </summary>
		private static DataRow userSettings;

		/// <summary> Name of the file which stores these settings </summary>
		private static string fileName;

		/// <summary> Static constructor for the IS_UserSettings base class </summary>
		static IS_UserSettings()
		{
			// Create a new, empty dataset
			Create_DataSet();
		}

		/// <summary> Method creates a new DataSet to house the user information </summary>
		private static void Create_DataSet()
		{
			// Declare the data set new
			dsSettings = new DataSet( "Settings" );

			// Create a new table to store the row of user information
			DataTable dsTbl = new DataTable( "userSettings" );

			// Add this table to the data set
			dsSettings.Tables.Add( dsTbl );

			// Add a new row to the table
			userSettings = dsTbl.NewRow();
			dsTbl.Rows.Add( userSettings );
		}

		/// <summary> Reads the user settings from a XML file in Isolated Storage </summary>
		/// <returns> TRUE if the XML file already existed, otherwise FALSE </returns>
		/// <remarks> If the XML file does not exist, an empty DataSet is created </remarks>
		protected static bool Read_XML_File( )
		{
			// Create the isolated storage file to load the information from the disk
			IsolatedStorageFile userSettingFile;
			userSettingFile = IsolatedStorageFile.GetUserStoreForAssembly();

			// Look to see if the file exists
			string[] files = userSettingFile.GetFileNames( fileName + ".xml" );
			if ( files.Length > 0 )
			{
               // MessageBox.Show("About to read: " + )
				// Create a stream reader to get the data from the isolated storage for this user
				StreamReader stmReader = new StreamReader( new IsolatedStorageFileStream( fileName + ".xml", FileMode.Open, userSettingFile ) );

				// Read the xml file
				dsSettings = new DataSet();
				dsSettings.ReadXml( stmReader, XmlReadMode.ReadSchema );

				// Fetch the one line of data
				userSettings = dsSettings.Tables[0].Rows[0];

				// Close the stream
				stmReader.Close();

				// Close the connection to the isolated storage
				userSettingFile.Close();

				// Return true since the file already existed
				return true;
			}
			else
			{
				// The file did not exist yet, so create a data set locally
				Create_DataSet();

				// Close the connection to the isolated storage
				userSettingFile.Close();

				// Return false since the file did not already exist
				return false;
			}
		}

		/// <summary> Reads the user settings from a XML file in Isolated Storage </summary>
		/// <param name="fileName"> Name of the file </param>
		/// <returns> TRUE if the XML file already existed, otherwise FALSE </returns>
		/// <remarks> If the XML file does not exist, an empty DataSet is created </remarks>
		protected static bool Read_XML_File( string fileName )
		{
			// Save the file name
			FileName = fileName;

			// Call the 'base' method
			return Read_XML_File();
		}

		/// <summary> Writes the user settings to a XML file in Isolated Storage </summary>
		/// <returns> TRUE if the XML file is successfully written, otherwise FALSE </returns>
		protected static bool Write_XML_File( )
		{
			// Only write the XML file if there are columns to write
			if (( dsSettings.Tables.Count > 0 ) && ( dsSettings.Tables[0].Columns.Count > 0 ))
			{
				// Perform this work in a try/catch architecture
				try
				{
					// Create the isolated storage file to write the information to the disk
					IsolatedStorageFile userSettingFile;
					userSettingFile = IsolatedStorageFile.GetUserStoreForAssembly();

					// Create a stream writer to write to the file in isolated storage
					StreamWriter stmWriter = new StreamWriter( new IsolatedStorageFileStream( fileName + ".xml", FileMode.Create, userSettingFile ) );

					// Write the XML file
					dsSettings.WriteXml( stmWriter, XmlWriteMode.WriteSchema );

					// Close these objects
					stmWriter.Close();
					userSettingFile.Close();

					// Successful, so return true
					return true;
				}
				catch ( Exception ee )
				{
				    MessageBox.Show("ERROR CAUGHT IN WRITE_XML_FIle in IS_UserSettings: " + ee.Message);
					return false;
				}
			}
			else
			{
				// Since there were no settings to save, return true, but do nothing
				return true;
			}
		}


		/// <summary> Writes the user settings to a XML file in Isolated Storage </summary>
		/// <param name="fileName"> Name of the file </param>
		/// <returns> TRUE if the XML file is successfully written, otherwise FALSE </returns>
		protected static bool Write_XML_File( string fileName )
		{
			// Save the file name
			FileName = fileName;

			// Call the 'base' method
			return Write_XML_File();
		}

		/// <summary> Gets and sets the name of the file which stores the user settings </summary>
		protected static string FileName
		{
			get	{	return fileName;	}
			set	{	fileName = value.Replace(".xml","");	}
		}

		/// <summary> Set a value in the current user setting. </summary>
		/// <param name="SettingName"> Name of the setting </param>
		/// <param name="newValue"> New value for the setting </param>
		/// <remarks> If the setting name already exists, the value will be changed
		/// to match the new value. </remarks>
		protected static void Add_Setting( string SettingName, int newValue )
		{
			// Check to see if the setting already exists
			if ( !dsSettings.Tables[0].Columns.Contains( SettingName ) )
			{
				// Add this colume to the table
				dsSettings.Tables[0].Columns.Add( SettingName );
			}

			// Add this value to the only row in the table
			userSettings[ SettingName ] = newValue;
		}

		/// <summary> Set a value in the current user setting. </summary>
		/// <param name="SettingName"> Name of the setting </param>
		/// <param name="newValue"> New value for the setting </param>
		/// <remarks> If the setting name already exists, the value will be changed
		/// to match the new value. </remarks>
		protected static void Add_Setting( string SettingName, string newValue )
		{
			// Check to see if the setting already exists
			if ( !Contains( SettingName ) )
			{
				// Add this colume to the table
				dsSettings.Tables[0].Columns.Add( SettingName );
			}

			// Add this value to the only row in the table
			userSettings[ SettingName ] = newValue;
		}

        /// <summary> Set a value in the current user setting. </summary>
        /// <param name="SettingName"> Name of the setting </param>
        /// <param name="newValue"> New value for the setting </param>
        /// <remarks> If the setting name already exists, the value will be changed
        /// to match the new value. </remarks>
        protected static void Add_Setting(string SettingName, bool newValue)
        {
            // Check to see if the setting already exists
            if (!Contains(SettingName))
            {
                // Add this colume to the table
                dsSettings.Tables[0].Columns.Add(SettingName);
            }

            // Add this value to the only row in the table
            if (newValue)
                userSettings[SettingName] = "TRUE";
            else
                userSettings[SettingName] = "FALSE";
        }

        /// <summary> Set a value in the current user setting. </summary>
        /// <param name="SettingName"> Name of the setting </param>
        /// <param name="newValue"> New value for the setting </param>
        /// <remarks> If the setting name already exists, the value will be changed
        /// to match the new value. </remarks>
        protected static void Add_Setting(string SettingName, List<string> newValue)
        {
            // Check to see if the setting already exists
            if (!Contains(SettingName))
            {
                // Add this colume to the table
                dsSettings.Tables[0].Columns.Add(SettingName);
            }

            // Add this value to the only row in the table
            if (newValue.Count == 0)
            {
                Add_Setting(SettingName, String.Empty);
                return;
            }
            if (newValue.Count == 1)
            {
                Add_Setting(SettingName, newValue[0].Trim());
                return;
            }

            System.Text.StringBuilder joinedBuilder = new System.Text.StringBuilder();
            foreach (string thisAddOn in newValue)
            {
                if (joinedBuilder.Length > 0)
                    joinedBuilder.Append("|");
                joinedBuilder.Append(thisAddOn.Trim());
            }
            Add_Setting(SettingName, joinedBuilder.ToString());
        }

		/// <summary> Gets a pre-existing integer setting for this user  </summary>
		/// <param name="SettingName"> Name of the setting to fetch </param>
		/// <returns> Value of the integer setting, or -1 if the setting was not found </returns>
		protected static int Get_Int_Setting( string SettingName )
		{
            if (Contains(SettingName))
            {
                string string_value = userSettings[SettingName].ToString();
                return Convert.ToInt32(string_value);
            }
            else
                return -1;
		}

		/// <summary> Gets a pre-existing string setting for this user  </summary>
		/// <param name="SettingName"> Name of the setting to fetch </param>
		/// <returns> Value of the string setting, or an empty string if the setting was not found </returns>
		protected static string Get_String_Setting( string SettingName )
		{
			if ( Contains( SettingName ) )
				return userSettings[ SettingName ].ToString();
			else
				return "";
		}

        /// <summary> Gets a pre-existing collection of strings setting for this user  </summary>
        /// <param name="SettingName"> Name of the setting to fetch </param>
        /// <returns> Value of the collection of string setting, or NULL if the setting was not found </returns>
        protected static List<string> Get_String_Collection_Setting(string SettingName )
        {
            if (Contains(SettingName))
            {
                List<string> returnValue = new List<string>();
                string toSplit = Get_String_Setting(SettingName);
                if (toSplit.Trim().Length == 0)
                    return returnValue;
                if (toSplit.IndexOf("|") < 0)
                    returnValue.Add(toSplit.Trim());
                else
                {
                    string[] split = toSplit.Split("|".ToCharArray());
                    foreach (string thisSplit in split)
                    {
                        returnValue.Add(thisSplit.Trim());
                    }
                }
                return returnValue;
            }

            return new List<string>();
        }

        /// <summary> Gets a pre-existing boolean setting for this user  </summary>
        /// <param name="SettingName"> Name of the setting to fetch </param>
        /// <param name="Default_Value"> Default value to be used if the setting is absent </param>
        /// <returns> Value of the boolean setting, or the provided default if the setting was not found </returns>
        protected static bool Get_Boolean_Setting(string SettingName, bool Default_Value )
        {
            if (Contains(SettingName))
            {
                string value = userSettings[SettingName].ToString();
                switch(value)
                {
                    case "TRUE":
                    case "1":
                        return true;
                    case "FALSE":
                    case "0":
                        return false;
                    default: 
                        return Default_Value;
                }
            }

            return Default_Value;
        }

		/// <summary> Checks to see if a particular setting already exists for this user </summary>
		/// <param name="SettingName"> Name of the setting to look for </param>
		/// <returns> TRUE if the setting exists, otherwise FALSE </returns>
		protected static bool Contains( string SettingName )
		{
			return ( dsSettings.Tables[0].Columns.Contains( SettingName ) );
		}

        protected static DataSet Setting_DataSet
        {
            get
            {
                return dsSettings;
            }
        }
	}
}
