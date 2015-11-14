using System;
using System.Data;
using System.IO;

namespace DLC.Tools.IO
{
	/// <summary> Class is used to search for valid volume folders <br /> <br /> </summary>
	/// <remarks> Written by Mark Sullivan (2005) </remarks>
	public class Volume_Folders
	{

		private Volume_Folder_Info_Collection valids;
		private Volume_Folder_Info_Collection errors;
		private object userDefinable;
		private DataTable bib_vid_list = null;

		/// <summary> Constructor is used for a new instance of this class </summary>
		public Volume_Folders()
		{
			// Declare new collections
			valids = new Volume_Folder_Info_Collection();
			errors = new Volume_Folder_Info_Collection();

			// Set default
			userDefinable = String.Empty;
		}

		public DataTable Bib_VID_List
		{
			set
			{
				bib_vid_list = value;
			}
		}

		/// <summary> Gets the collection of folders which were valid </summary>
		public Volume_Folder_Info_Collection Valid_Folders
		{
			get	{	return valids;	}
		}

		/// <summary> Gets the collection of folders which were NOT valid </summary>
		public Volume_Folder_Info_Collection Invalid_Folders
		{
			get	{	return errors;	}
		}

		/// <summary> Clears the collection of folder information </summary>
		public void Clear()
		{
			valids.Clear();
			errors.Clear();
		}

        /// <summary> Checks for subfolders under the provided directory </summary>
		/// <param name="source_directory"> Directory to look under </param>
        public void Check(string source_directory)
        {
            Check(true, source_directory);
        }

		/// <summary> Checks for subfolders under the provided directory </summary>
		/// <param name="source_directory"> Directory to look under </param>
		public void Check( bool Unflatten_Folder, string source_directory )
		{
			// Return with no work if this is not a valid directory
			if ( !Directory.Exists( source_directory ) )
				return;

			// Get the collection of folders under this directory
			try
			{
				if (( source_directory[ source_directory.Length - 1 ] != '\\' ) && ( source_directory[ source_directory.Length - 1 ] != '/' ))
				{
					source_directory = source_directory + "\\";
				}

				string[] subdirs = Directory.GetDirectories( source_directory );

				// Step through each sub directory
				foreach( string thisDir in subdirs )
				{
					// Create the directory information object
					Check_Bib_Folder( Unflatten_Folder, thisDir );
				}
			}
			catch ( Exception ee )
			{
				Tools.Forms.ErrorMessageBox.Show("Error while stepping into directory " + source_directory, "Volume_Folders Module Error", ee );
			}
		}

		/// <summary> Checks for subfolders under the provided directory </summary>
		/// <param name="source_directory"> Directory to look under </param>
		/// <param name="user_definable"> User definable field </param>
		public void Check( string source_directory, object user_definable )
		{
			this.userDefinable = user_definable;

			// Peform all the checking work
			Check( source_directory );

			this.userDefinable = null;
		}

        public void Check_Bib_Folder(string thisDir)
        {
            Check_Bib_Folder(  true, thisDir);
        }

		public void Check_Bib_Folder( bool Unflatten_Folders, string thisDir )
		{
			// Get the name of the directory
			string dirName = ( new DirectoryInfo( thisDir )).Name;
            string parentDir = ( new DirectoryInfo( thisDir )).Parent.FullName;
            string bibid = dirName;

			Volume_Folder_Info returnVal;

			// Test to see if this even looks like a bib id
            if (!isBibIdFormat(dirName.ToUpper()))
			{
				returnVal = new Volume_Folder_Info( thisDir, string.Empty );
                returnVal.Error = "This folder is not in proper bib id format."; 
				returnVal.User_Definable_Field = userDefinable;
				errors.Add( returnVal );
				return;
			}

            // If this is 16 digits, then it is flattened... need to unflatten it
            if (dirName.Length == 16)
            {
                string bib_folder = dirName.Substring(0, 10);
                string vid_folder = dirName.Substring(11, 5);
                bibid = bib_folder;

                // Move the folder if you can
                if (Unflatten_Folders)
                {
                    if (Directory.Exists(parentDir + "\\" + bib_folder + "\\" + vid_folder))
                    {
                        returnVal = new Volume_Folder_Info(thisDir, String.Empty );
                        returnVal.Error = "This folder in flattened form 'UF12345678_12345', but the non-flattened form also exists.";
                        returnVal.User_Definable_Field = userDefinable;
                        errors.Add(returnVal);
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (!Directory.Exists(parentDir + "\\" + bib_folder))
                            {
                                Directory.CreateDirectory(parentDir + "\\" + bib_folder);
                            }
                            Directory.Move(thisDir, parentDir + "\\" + bib_folder + "\\" + vid_folder);
                            thisDir = parentDir + "\\" + bib_folder;
                            dirName = bib_folder;
                        }
                        catch
                        {
                            returnVal = new Volume_Folder_Info(thisDir, string.Empty );
                            returnVal.Error = "Attempt to unflatten folder failed.";
                            returnVal.User_Definable_Field = userDefinable;
                            errors.Add(returnVal);
                            return;
                        }
                    }
                }
            }

			// Now, see if this is in fact a valid bib id
			int receivingid = -1;
			DataRow[] selected = null;
			if ( bib_vid_list != null )
			{
                selected = bib_vid_list.Select("BibID = '" + bibid + "'");
			}

            if (dirName.Length == 16)
            {
                check_subfolder(thisDir, thisDir, dirName.Substring(0,10), dirName.Substring(11, 5));
            }
            else
            {
                // Are there subfolders here?
                string[] subfolders = new string[0];
                try
                {
                    subfolders = Directory.GetDirectories(thisDir);
                }
                catch (Exception ee)
                {
                    Tools.Forms.ErrorMessageBox.Show("Error while stepping into directory " + thisDir, "Volume_Folders Module Error", ee);
                }

                if (subfolders.Length == 0)
                {
                    // If there was no subfolder, but there is only one volume anyway, 
                    // then this is no problem.
                    if (((selected != null) && (selected.Length == 1)) || (bib_vid_list == null))
                    {
                        returnVal = new Volume_Folder_Info(thisDir, thisDir);
                        returnVal.User_Definable_Field = userDefinable;
                        valids.Add(returnVal);
                        return;
                    }
                    else
                    {
                        // The volume is not specified
                        returnVal = new Volume_Folder_Info(thisDir, thisDir );
                        returnVal.Error = "Valid bib id, but ambiguous volume";
                        returnVal.User_Definable_Field = userDefinable;
                        errors.Add(returnVal);
                        return;
                    }
                }
                else
                {
                    // There were subfolders, so check each subfolder individually
                    foreach (string thisSub in subfolders)
                    {
                        check_subfolder(thisDir, thisSub, bibid, (new DirectoryInfo(thisSub)).Name);
                    }
                }
            }
		}

        /// <summary> Private helper method used to check if a folder name is in 
        /// Bib ID form. </summary>
        /// <param name="toTest"> String to test for Bib-Id-ness </param>
        /// <returns> TRUE if this could be a bib id, otherwise FALSE </returns>
        private bool isBibIdFormat(string toTest)
        {
            // Check to see that the folder name is 10 letters long
            if ((toTest.Length != 10) && (toTest.Length != 16))
                return false;

            string test = toTest;
            if (toTest.Length == 16)
            {
                if ((toTest[10] == '_') && (Char.IsNumber(toTest[11])) && (Char.IsNumber(toTest[12]))
                    && (Char.IsNumber(toTest[13])) && (Char.IsNumber(toTest[14])) && (Char.IsNumber(toTest[15])))
                {
                    test = toTest.Substring(0, 10);
                }
            }

            string reg_statement = "[A-Z]{2}[A-Z|0-9]{4}[0-9]{4}";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg_statement, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (regex.IsMatch(test))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> Private helper method used to check if a folder name is in 
        /// VID form. </summary>
        /// <param name="toTest"> String to test for Bib-Id-ness </param>
        /// <returns> TRUE if this could be a bib id, otherwise FALSE </returns>
        private bool isVidFormat(string toTest)
        {
            string test = toTest.Replace("VID", "");

            // Check to see that the folder name is 10 letters long
            if (test.Length != 5)
                return false;

            string reg_statement = "[0-9]{5}";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg_statement, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (regex.IsMatch(test))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void check_subfolder(string folder, string subfolder, string bibid, string vid )
		{
            // Get the name of the subdirectory
            Volume_Folder_Info returnVal;

            // First, see if this is even a valid format
            if (!isVidFormat(vid))
            {
                // The volume is not specified
                returnVal = new Volume_Folder_Info(folder, subfolder);
                returnVal.Error = "Invalid volume id folder format.";
                returnVal.User_Definable_Field = userDefinable;
                errors.Add(returnVal);
            }

            // Make sure no VID remains
            if (vid.IndexOf("VID") >= 0)
                vid = vid.Replace("VID", "");

			// Look for a matching volume
			DataRow[] selected = null;
            if ((bib_vid_list != null) && (bibid.Length > 0))
                selected = bib_vid_list.Select("BibID = '" + bibid + "' AND VID = '" + vid + "'");

			// Was there a match?
			if ( selected != null )
			{
                if (selected.Length == 0)
                {
                    // The volume is not specified
                    returnVal = new Volume_Folder_Info(folder, subfolder);
                    returnVal.Error = "Valid bib id, but an invalid volume was indicated.";
                    returnVal.User_Definable_Field = userDefinable;
                    errors.Add(returnVal);
                }
                else
                {
                        returnVal = new Volume_Folder_Info(folder, subfolder);
                        returnVal.User_Definable_Field = userDefinable;
                        valids.Add(returnVal);
                }
			}
			else
			{
                    returnVal = new Volume_Folder_Info(folder, subfolder );
                    returnVal.User_Definable_Field = userDefinable;
                    valids.Add(returnVal);
			}
		}
	}
}
