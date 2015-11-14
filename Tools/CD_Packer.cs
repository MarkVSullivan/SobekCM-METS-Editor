using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace DLC.Tools
{
    /// <summary> CD_Packer_Exception is a custom exception which is thrown if there is a run away process
    /// detected in the CD Packing object. <br /> <br /> </summary>
    /// <remarks> This is thrown from a <see cref="CD_Packer"/> class when more than 200 CD's are packed in one 
    /// session.  This prevents potentially hundreds of thousands of new CD folders from being created in one 
    /// session if there is an error.  <br /> <br />
    /// This class extends the <see cref="ApplicationException"/> class. </remarks>
    public class CD_Packer_Exception : ApplicationException
    {
        /// <summary> Constructor passes a message to the base objects constructor. </summary>
        /// <param name="message"> Custome message explaining the error which was detected. </param>
        public CD_Packer_Exception(string message)
            : base("Exception thrown by the CD_Packer object.\n\n" + message + "\n\n")
        {
            // All construction done in base class
        }
    }

    public delegate void New_CD_Created_Delegate(int CD_Number);

    /// <summary> The CD_Packer object is used to pack CD's from a provided directory, 
    /// or adds each file individually. <br /> <br /> </summary>
    /// <remarks> Object written in C# by Mark V Sullivan ( 7/3/2003 ) using DataObjectGenerator. </remarks> 
    public class CD_Packer
    {
        #region PRIVATE VARIABLE DECLARATIONS of the CD_Packer Class

        /// <summary> Private int variable stores the total possible capacity (in MB) for the CD's to be packed. </summary>
        private int cD_Capacity;

        /// <summary> Private int variable stores the CD number which is currently being packed. </summary>
        private int currentCD;

        /// <summary> Private string variable stores the directory in which to pack these CDs. </summary>
        private string directory;

        /// <summary> Private int variable stores the number for the first CD to pack. </summary>
        private int firstCD;

        /// <summary> Private int variable holds the NEXT number.  This is in the case that there is
        /// a half-completed CD already in the 'Burn' directory. </summary>
        private int nextCD;

        /// <summary> Private newCdObject object stores the object used to pack the current cd. </summary>
        private newCdObject thisCD;

        /// <summary> Private ArrayList holds the bib id's of all the textual material
        /// which was packed to CD. </summary>
        private StringCollection packedTextBibIds;

        /// <summary> Private ArrayList holds the bib id's of all the visual material
        /// which was packed to CD. </summary>
        private StringCollection packedImageBibIds;

        /// <summary> Private string array holds the collection of different institution codes used
        /// to identify if a foler name is in the Bib ID format. </summary>
        private string[] institutionCodes = new string[] { "AM", "CF", "FA", "FI", "FS", "GC", "HA",
															 "HB", "HM", "JU", "LL", "NF", "NH", "SA", "SF", "UF", "WF", "UM", "SW", "VI", "MM","CA" };

        /// <summary> Stores the number of new CD's which were created during the life of this object.
        /// If the number of CD's ever exceeds 500, abort the Thread. </summary>
        private int NewCdsPacked;

        private static string cd_prefix;

        #endregion

        /// <summary> Event is fired each time a new CD folder is created </summary>
        public event New_CD_Created_Delegate New_CD_Created;


        #region CONSTRUCTOR(S) of the CD_Packer Class

        static CD_Packer()
        {
            cd_prefix = "CD";
        }

        /// <summary> Constructor for the CD_Packer class </summary>
        /// <param name="directory"> The directory in which to pack these CDs. </param>
        /// <param name="firstCD"> The number for the first CD to pack. </param>
        /// <remarks> This uses the default DVD Capacity (4.4 GB) for CD's. </remarks>
        public CD_Packer(string directory, int firstCD, bool logActions)
        {
            // Save all the properties to the private variables
            this.directory = directory;
            this.firstCD = firstCD;

            // Set the default CD capacity
            cD_Capacity = 4400;

            // Make sure the provided directory exists, otherwise create it
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Check to see if there is an incomplete CD
            nextCD = incompleteCD();
            if (nextCD == -1)
                currentCD = firstCD;
            else
                currentCD = nextCD;

            // Create new lists to hold all the textual and visual items
            packedTextBibIds = new StringCollection();
            packedImageBibIds = new StringCollection();

            // Create the current newCdObject for the CD
            thisCD = new newCdObject(cD_Capacity, currentCD, directory);

            // Set the number of NewCdsPacked to zero initially
            NewCdsPacked = 0;
        }

        /// <summary> Constructor for the CD_Packer class. </summary>
        /// <param name="directory"> The directory in which to pack these CDs. </param>
        /// <param name="firstCD"> The number for the first CD to pack. </param>
        /// <param name="CD_Capacity"> Capacity for the media (in MB) </param>
        public CD_Packer(string directory, int firstCD, int CD_Capacity)
        {
            // Save all the properties to the private variables
            this.directory = directory;
            this.firstCD = firstCD;
            this.cD_Capacity = CD_Capacity;

            // Make sure the provided directory exists, otherwise create it
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Check to see if there is an incomplete CD
            nextCD = incompleteCD();
            if (nextCD == -1)
                currentCD = firstCD;
            else
                currentCD = nextCD;

            // Create new lists to hold all the textual and visual items
            packedTextBibIds = new StringCollection();
            packedImageBibIds = new StringCollection();

            // Create the current newCdObject for the CD
            thisCD = new newCdObject(cD_Capacity, currentCD, directory);

            // Set the number of NewCdsPacked to zero initially
            NewCdsPacked = 0;
        }

        #endregion

        #region PUBLIC PROPERTIES of the CD_Packer Class

        /// <summary> Gets and sets the total possible capacity (in MB) for the CD's to be packed. </summary>
        public int CD_Capacity
        {
            get { return cD_Capacity; }
            set
            {
                // Save the new value
                cD_Capacity = value;

                // Change the value in the current CD
                thisCD.Capacity = value;
            }
        }

        /// <summary> Gets and sets the CD number which is currently being packed. </summary>
        public int CurrentCD
        {
            get { return currentCD; }
            set
            {
                // Save the new value
                currentCD = value;

                // Declare a new CD object
                thisCD = new newCdObject(cD_Capacity, value, directory);
            }
        }

        /// <summary> Gets the size of the files in the current CD </summary>
        public int Current_CD_Size
        {
            get
            {
                if (thisCD.CdNumber == currentCD)
                    return thisCD.Size;
                else
                    return 0;
            }
        }

        /// <summary> Gets and sets the directory in which to pack these CDs. </summary>
        public string CD_Directory
        {
            get { return directory; }
            set
            {
                // Save the new value
                directory = value;

                // Change the current CD if the size is currently zero
                if (thisCD.Size == 0)
                    thisCD = new newCdObject(cD_Capacity, currentCD, directory);
            }
        }

        /// <summary> Gets the number for the first CD to pack. </summary>
        public int FirstCD
        {
            get { return firstCD; }
        }

        /// <summary> Gets the collection that holds the bib id's of all the
        /// textual material which was packed to CD. </summary>
        public StringCollection PackedTextBibIds
        {
            get { return packedTextBibIds; }
        }

        /// <summary> Gets the collection that holds the bib id's of all the
        /// visual material which was packed to CD. </summary>
        public StringCollection PackedImageBibIds
        {
            get { return packedImageBibIds; }
        }

        public static string CD_Prefix
        {
            get { return cd_prefix; }
            set { cd_prefix = value; }
        }

        #endregion

        #region PUBLIC METHODS of the CD_Packer Class

        /// <summary> Add all the folders under a certain root directory.  </summary>
        /// <param name="rootDirectory"> Directory from which to pack </param>
        /// <returns> The number of the last CD which was packed </returns>
        public int AddDirectory(string rootDirectory)
        {
            // If this directory is a valid Bib ID format, jump to packing logic
            string[] parser = rootDirectory.Split("\\".ToCharArray());
            if (isBibIdFormat(parser[parser.Length - 1]))
                addDirLogic(rootDirectory, parser[parser.Length - 1]);
            else	// Not a bib ID, so get root directories, and call self recursively
                foreach (string dir in Directory.GetDirectories(rootDirectory))
                    AddDirectory(dir);

            // Clean directories recursively
            try
            {
                if (Directory.Exists(rootDirectory))
                {
                    clean_directories_recursively(rootDirectory);
                }
            }
            catch (Exception ee)
            {
                DLC.Tools.Forms.ErrorMessageBox.Show("Error clearing empty folders after packing.", "Error", ee);
            }

            // Return the number of the last packed CD
            return thisCD.CdNumber;
        }

        private void clean_directories_recursively(string rootDir)
        {
            string[] clean_subdirs = Directory.GetDirectories(rootDir);
            foreach (string thisSubDir in clean_subdirs)
                clean_directories_recursively(thisSubDir);

            string[] subdir_check = Directory.GetDirectories(rootDir);
            if (subdir_check.Length == 0)
            {
                string[] files = Directory.GetFiles(rootDir);
                if (files.Length == 0)
                {
                    Directory.Delete(rootDir);
                }
            }
        }

        /// <summary> Add one file to the current CD </summary>
        /// <param name="pathFile"> Source path and filename for the file to add </param>
        /// <param name="CdSubDirectory"> Sub directory on the CD to move the file to </param>
        /// <returns> The CD number this file was placed upon </returns>
        public int Add(string pathFile, string CdSubDirectory)
        {
            // Try adding the file to the current CD first
            if (!thisCD.Add(pathFile, CdSubDirectory))
            {
                // Wasn't able to add to current CD, so make new CD
                thisCD.Finalize();
                incrementCD();
                createNextCD();

                // Now, try to add this file to this new CD
                if (!thisCD.Add(pathFile, CdSubDirectory))
                {
                    // STILL unable to add it, so file must be larger
                    // than the media capacity
                    MessageBox.Show("Error packing CD's.  File must be larger than the capacity of your media.    \n\nFile is " + pathFile,
                        "File to large for media", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            // Return the number of the last packed CD
            return thisCD.CdNumber;
        }

        /// <summary> Adds a group of files to the current CD into a subdirectory
        /// as specified.  The group is specified by path and search pattern </summary>
        /// <param name="path"> Source path for the search pattern </param>
        /// <param name="searchPattern"> Search pattern of files to add </param>
        /// <param name="CdSubDirectory"> Sub directory on the CD to move the file to </param>
        /// <returns> The CD number this file was placed upon, or -1 </returns>
        public int Add(string path, string searchPattern, string CdSubDirectory)
        {
            // Try to just call the method on the current CD to add all the files
            if (!thisCD.Add(path, searchPattern, CdSubDirectory))
            {
                // Failed to add all the files				
                // Get the list of files that match the search pattern
                string[] files = Directory.GetFiles(path, searchPattern);

                // Get the total current file size
                decimal totalSize = 0;
                for (int i = 0; i < files.Length; i++)
                    totalSize += (decimal) new FileInfo(files[i]).Length;

                // Loop to continue adding the matching files until done
                while (totalSize > 0)
                {
                    // The whole folder did not fit, see if the CD is mostly full
                    if (((float)thisCD.FreeSpace / (float)thisCD.Capacity) < .10)
                    {
                        // CD is over 90% packed, so just create a new one
                        thisCD.Finalize();
                        incrementCD();
                        createNextCD();

                        // This will loop again around the while loop and try to 
                        // add the files again
                        if (thisCD.Add(path, searchPattern, CdSubDirectory))
                            totalSize = 0;
                    }
                    else
                    {
                        // CD is still pretty empty, but file collection still can't be added
                        // Check that the collection of files isn't greater than media can hold
                        if (totalSize > (thisCD.Capacity * 1048576))
                        {
                            MessageBox.Show("Error packing CD's.  File collection must be larger than the capacity of your media.    \n\nFile is " + path + "\\" + searchPattern,
                                "File to large for media", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            // Really no other choice but to create a CD and then loop around
                            thisCD.Finalize();
                            incrementCD();
                            createNextCD();

                            // If you can add the files, set the total size to zero
                            if (thisCD.Add(path, searchPattern, CdSubDirectory))
                                totalSize = 0;
                        }
                    }
                }
            }

            // Return the number of the last packed CD
            return thisCD.CdNumber;
        }

        /// <summary> Clears the lists of all the text and images
        /// which have been packed since the last clearing. </summary>
        public void ClearPackedList()
        {
            packedTextBibIds.Clear();
            packedImageBibIds.Clear();
        }

        #endregion

        #region PRIVATE METHODS of the CD_Packer Class

        /// <summary> Helper method will make the folder for the next CD, etc.  Checks to make
        /// sure that no more than 500 CD's are ever packed in one session. </summary>
        /// <returns></returns>
        /// <exception cref="CD_Packer_Exception"> Throws a CD_Packer_Exception if more than 50 CD's were 
        /// packed in one session.   This prevents run away processes from creating thousands of new CD
        /// folders.  </exception>
        private void createNextCD()
        {
            if (NewCdsPacked > 50)
            {
                throw new CD_Packer_Exception("Attempted to pack more than 50 CD's in one session.");
            }
            else
            {
                thisCD = new newCdObject(cD_Capacity, currentCD, directory);

                // Trigger the event that a new CD was created
                if (this.New_CD_Created != null)
                    New_CD_Created(thisCD.CdNumber);

                // Increment the number of cd's which have been packed
                NewCdsPacked++;
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

            string reg_statement = "[A-Z]{2}[A-Z|0-9]{3}[0-9]{5}";
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

        /// <summary> Private helper method that actually adds a directory,
        /// subdirectory, and folders to CD's which are being packed. </summary>
        /// <param name="rootDirectory"></param>
        /// <param name="bibId"></param>
        /// <returns></returns>
        private bool addDirLogic(string rootDirectory, string bibId)
        {
            // Get the size of the directory here, to minimize the number
            // of times it must be checked
            decimal dirSize = getDirSize(rootDirectory, 0);
            string path;
            string[] subDirs, files, parser;
            int filesSent;
            bool newCD;

            // Loop here as long as the directory size is greater than zero
            while (dirSize > 0)
            {
                // Set the fact that no new CD has been created yet
                newCD = false;

                // Try to add the whole directory to the current CD
                if (!thisCD.AddFolder(rootDirectory, bibId, dirSize))
                {
                    // The whole folder did not fit, see if the CD is mostly full
                    if (((float)thisCD.Size / (float)thisCD.Capacity) > .80)
                    {
                        // CD is over 80% packed, so just create a new one
                        thisCD.Finalize();
                        incrementCD();
                        createNextCD();

                        // This will loop again around the while loop and try to 
                        // add the folder then (this allows it to still be broken up
                        // into seperate CD's if necessary
                    }
                    else
                    {
                        // CD is still pretty empty, so this folder must be
                        // very large.  It will need to be split into two or more.

                        // If there are subfolders under this folder, it is a natural
                        // to move these first. (Note: File Sort can't currently sort these
                        // types of CD's though.)
                        subDirs = Directory.GetDirectories(rootDirectory);
                        if (subDirs.Length > 0)
                        {
                            // Call this routine recursively, for each changing the BibID field
                            // to include the subfolder.
                            parser = subDirs[0].Split("\\".ToCharArray());
                            path = parser[parser.Length - 1];
                            decimal subdir_size = getDirSize(subDirs[0],0);
                            addDirLogic(subDirs[0], bibId + "\\" + path);
                            dirSize = dirSize - subdir_size;
                        }
                        else
                        {
                            // There were no sub folders, so try adding files
                            files = Directory.GetFiles(rootDirectory);
                            filesSent = 0;

                            // Iterate through all the files and try to pack as many as possible
                            for (int i = 0; i < files.Length; i++)
                            {
                                // Make sure this file still exists (not moved yet)
                                if (File.Exists(files[i]))
                                {
                                    // Now, parse to get the filename, as all will be moved
                                    // over at once that match that ( to get JPGs and SIDs on the
                                    // same CD as the TIFFs)
                                    parser = files[i].Split("\\.".ToCharArray());
                                    if (thisCD.Add(rootDirectory, parser[parser.Length - 2] + ".*", bibId))
                                        filesSent++;
                                    else
                                        break;
                                }
                            }

                            // If no files were added, then try adding each file seperately
                            if (filesSent == 0)
                                // Iterate through all of the files, trying to pack
                                for (int i = 0; i < files.Length; i++)
                                    // Make sure this file still exists (not moved yet)
                                    if (File.Exists(files[i]))
                                        // This time, send one file at a time, instead of a group
                                        if (thisCD.Add(files[i], bibId))
                                            filesSent++;

                            // If there were still no files added, create a new CD, unless this is empty
                            if ((filesSent == 0) && (thisCD.Size != 0))
                            {
                                thisCD.Finalize();
                                incrementCD();
                                createNextCD();
                                newCD = true;
                            }

                            // If this is an empty CD and no files were added, must be an error
                            if ((!newCD) && (filesSent == 0) && (thisCD.Size == 0))
                                MessageBox.Show("Error packing CD's.  File must be larger than the capacity of your media.    ",
                                    "File to large for media", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Now, determine how much space is left in this folder
                            dirSize = getDirSize(rootDirectory, 0);
                        }
                    }
                }
                else	// Managed to move whole folder, so done!
                    dirSize = 0;
            }
            // Successful, so return true
            return true;
        }

        /// <summary> Private helper method computes the total size of a directory, 
        /// including all files in sub directories </summary>
        /// <param name="directory"> Directory from which to check </param>
        /// <param name="size"> Size of the directory computed so far </param>
        /// <returns> Size of the folder </returns>
        private decimal getDirSize(string directory, decimal size)
        {
            // Calls itself recursively for any subdirectories
            foreach (string subdirectory in Directory.GetDirectories(directory))
                size += (decimal) getDirSize(subdirectory, size);

            // Add the size of each file in this directory to current size
            foreach (string file in Directory.GetFiles(directory))
                size += (decimal)(new FileInfo(file).Length);

            // Now, return the size
            return size;
        }

        /// <summary> Private helper method which checks to see if there is a incompletely
        /// packed CD already in this folder.  If there is, it returns this CD number. </summary>
        /// <returns> Either the incomplete CD number, or -1 </returns>
        private int incompleteCD()
        {
            // Get list of folders under this packing directory
            string[] CDs = Directory.GetDirectories(directory);

            // Iterate through each of these CD folders
            for (int i = 0; i < CDs.Length; i++)
                if (CDs[i].IndexOf("Incomplete") > 0)
                    return Convert.ToInt32(CDs[i].Substring(directory.Length + 4, 5));

            // Default, no incomplete CD found
            return -1;
        }

        /// <summary> Private helper method increments the CD number </summary>
        private void incrementCD()
        {
            // If the current CD was before the first CD, then this must be completing
            // a CD folder which was incomplete from last time.  So, go ahead and
            // set the NEXT cd to the 'first CD' argument.
            if (firstCD > currentCD)
                currentCD = firstCD;
            else
                currentCD++;

            // Now check to see if this needs to hop over the range of CD's used for 
            // Antique maps and some Aerials
            if (currentCD == 6500)
                currentCD = 6580;
            if (currentCD == 7000)
                currentCD = 9452;
        }

        #endregion

        #region PRIVATE newCdObject SUB-CLASS

        /// <summary>
        /// The newCdObject is a private object under the CD_Packer class.  
        /// This object holds all the information for a specific CD, such as 
        /// the CD number, directory, and size.  It is this object that actually packs 
        /// the CD's as well.<br />
        /// </summary>
        /// <remarks> Object written in C# by Mark V Sullivan ( 7/3/2003 ) using DataObjectGenerator. </remarks> 
        private class newCdObject
        {

            #region PRIVATE VARIABLE DECLARATIONS of the newCdObject Sub-Class

            /// <summary> Private int variable stores the total possible capacity of this CD. </summary>
            private int capacity;

            /// <summary> Private int variable stores the number for this CD. </summary>
            private int cdNumber;

            /// <summary> Private string variable stores the root directory 
            /// under which this CD will be packed. </summary>
            private string directory;

            /// <summary> Private boolean flag holds the value which indicates an error
            /// was encountered during a previous operation. </summary>
            private bool error;

            /// <summary> Private string variable stores the name of this directory while 
            /// it is in process. </summary>
            private string processDirectory;

            /// <summary> Private long variable stores the current size of files in this CD. </summary>
            private decimal size;

            #endregion

            #region CONSTRUCTOR(S) of the newCdObject Sub-Class

            /// <summary> Constructor for the newCdObject class. </summary>
            /// <param name="capacity"> The total possible capacity of this CD. </param>
            /// <param name="cdNumber"> The number for this CD. </param>
            /// <param name="directory"> The directory where this CD will be packed. </param>
            public newCdObject(int capacity, int cdNumber, string directory)
            {
                // Save all the properties to the private variables
                this.capacity = capacity;
                this.cdNumber = cdNumber;
                this.directory = directory;
                error = false;

                // Make sure the directory ends with a '\' character
                if (!directory[directory.Length - 1].Equals('\\'))
                    directory += "\\";

                // First, see if a folder already exists which indicates this CD 
                // is not in process, but is fully packed.
                if (Directory.Exists(directory + CD_Packer.CD_Prefix + " " + cdNumber))
                    size = capacity;
                else
                {
                    // Define the folder to be used during processing
                    processDirectory = directory + CD_Packer.CD_Prefix + " " + cdNumber + " - Incomplete";

                    // See if a folder for this CD already exists in process
                    if (Directory.Exists(processDirectory))
                    {
                        // Folder existed to get the size of the files in it
                        size = 0;
                        setCurrentSize(processDirectory);
                    }
                    else
                    {
                        // Create this folder
                        size = 0;
                        Directory.CreateDirectory(processDirectory);
                    }
                }
            }

            #endregion

            #region PUBLIC PROPERTIES of the newCdObject Sub-Class

            /// <summary> Gets the total possible capacity of this CD. </summary>
            public int Capacity
            {
                get { return capacity; }
                set
                {
                    // Only allow the capacity to change if this hasn't been finalized
                    if (size != (capacity * 1048576))
                        capacity = value;
                }
            }

            /// <summary> Gets the number for this CD. </summary>
            public int CdNumber
            {
                get { return cdNumber; }
            }

            /// <summary> Gets the error flag. </summary>
            public bool Error
            {
                get { return error; }
            }

            /// <summary> Property computes the amound of free space left on this CD. </summary>
            public int FreeSpace
            {
                get { return Convert.ToInt32(Capacity - Size); }
            }

            /// <summary> Gets the current size of all the files in this CD. </summary>
            public int Size
            {
                get { return Convert.ToInt32(size / 1048576); }
            }

            #endregion

            #region PUBLIC METHODS of the newCdObject Sub-Class

            /// <summary> Public method adds a single file to this CD into a subdirectory
            /// as specified. </summary>
            /// <param name="pathFile"> Source path and filename for the file to add </param>
            /// <param name="CdSubDirectory"> Sub directory on the CD to move the file to </param>
            /// <returns> TRUE if able to add this, otherwise FALSE </returns>
            public bool Add(string pathFile, string CdSubDirectory)
            {
                // Perform all this work in a try/catch
                try
                {
                    // First, verify the specified file exists
                    if (File.Exists(pathFile))
                    {
                        // Return false if this will not fit into the current CD
                        if ((size + new FileInfo(pathFile).Length) >= (capacity * 1048576))
                            return false;

                        // Make sure the directory for this exists, or else make it
                        if (!Directory.Exists(processDirectory + "\\" + CdSubDirectory))
                            Directory.CreateDirectory(processDirectory + "\\" + CdSubDirectory);

                        // Get the base name of this file by parsing the full path-file
                        string[] nameParser = pathFile.Split("\\".ToCharArray());
                        string fileName = nameParser[nameParser.Length - 1];

                        // Now, move the file into the appropriate directory
                        File.Move(pathFile, processDirectory + "\\" + CdSubDirectory + "\\" + fileName);

                        // Add the size of the moved file to the current cd size
                        size += (decimal) (new FileInfo(processDirectory + "\\" + CdSubDirectory + "\\" + fileName)).Length;

                        // Return true since this file was successfully moved
                        return true;
                    }

                    // In this case, the file must not have existed, return false.
                    // This should never be reached, as the calling method should 
                    // check for existence.
                    return false;
                }
                catch (Exception ee)
                {
                    // Display an error message
                    Tools.Forms.ErrorMessageBox.Show("Error Adding a file to the current CD in CD_Packer."
                        + "newCdObject.Add( string, string )\n\nFile: " + pathFile + "\nDirectory: " +
                        processDirectory + "\\" + CdSubDirectory, "Error in DLC.CustomTools.CD_Packer",
                        ee );
                    error = true;
                    return false;
                }
            }

            /// <summary> Public method adds a group of files to this CD into a subdirectory
            /// as specified.  The group is specified by path and search pattern </summary>
            /// <param name="path"> Source path for the search pattern </param>
            /// <param name="searchPattern"> Search pattern of files to add </param>
            /// <param name="CdSubDirectory"> Sub directory on the CD to move the file to </param>
            /// <returns> TRUE if able to add this, otherwise FALSE </returns>
            public bool Add(string path, string searchPattern, string CdSubDirectory)
            {
                // Perform all this work in a try/catch
                try
                {
                    // First, verify the specified path exists
                    if (Directory.Exists(path))
                    {
                        // Collect the names of all matching files
                        string[] files = Directory.GetFiles(path, searchPattern);

                        // Determine the size of all matching files
                        decimal totalSize = 0;
                        foreach (string thisFile in files)
                            totalSize += (decimal)(new FileInfo(thisFile).Length);

                        // Return false if this will not fit into the current CD
                        if (Convert.ToInt32((size + totalSize) / 1048576) >= capacity)
                            return false;

                        // Make sure the directory on the CD for this exists, or else make it
                        if (!Directory.Exists(processDirectory + "\\" + CdSubDirectory))
                            Directory.CreateDirectory(processDirectory + "\\" + CdSubDirectory);

                        // Iterate through each file moving and adding the size to the current
                        // size of this CD.
                        string[] nameParser;
                        string fileName;
                        foreach (string thisFile in files)
                        {
                            // Get the base name of this file by parsing the full path-file
                            nameParser = thisFile.Split("\\".ToCharArray());
                            fileName = nameParser[nameParser.Length - 1];

                            // Now, move the file into the appropriate directory
                            File.Move(thisFile, processDirectory + "\\" + CdSubDirectory + "\\" + fileName);

                            // Add the size of the moved file to the current cd size
                            size += new FileInfo(processDirectory + "\\" + CdSubDirectory + "\\" + fileName).Length;
                        }

                        // Return true since this file was successfully moved
                        return true;
                    }

                    // In this case, the file must not have existed, return false.
                    // This should never be reached, as the calling method should 
                    // check for existence.
                    return false;
                }
                catch (Exception ee)
                {
                    // Display an error message
                    Tools.Forms.ErrorMessageBox.Show("Error Adding a file to the current CD in CD_Packer."
                        + "newCdObject.Add( string, string, string  )\n\nSource Path: " + path + "\nSearch Pattern: "
                        + searchPattern + "\nDestination Directory: " + processDirectory + "\\" + CdSubDirectory,
                        "Error in DLC.CustomTools.CD_Packer", ee );
                    error = true;
                    return false;
                }
            }

            /// <summary> Public method which adds an entire folder and all 
            /// subfolders to this CD. </summary>
            /// <param name="path"> Root directory to move </param>
            /// <param name="bibId"> Bib ID for this material </param>
            /// <param name="dirSize"> Size of the directory </param>
            /// <returns> TRUE if it was added, otherwise FALSE </returns>
            public bool AddFolder(string path, string bibId, decimal dirSize)
            {
                // Check that this folder size will fit on this CD
                decimal result = size + dirSize;
                decimal cap = ((long)capacity) * 1048576;
                if (result > cap)
                    return false;

                // Move the whole folder over to the CD packing folder
                string destination = this.directory + "\\" + CD_Packer.CD_Prefix + " " + cdNumber + " - incomplete\\" + bibId;
                try
                {
                    if (!Directory.Exists((new DirectoryInfo(destination)).Parent.FullName))
                    {
                        Directory.CreateDirectory((new DirectoryInfo(destination)).Parent.FullName);
                    }

                    Directory.Move(path, destination);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("ERROR CAUGHT HERE!");
                }

                // Add this new size to the current CD size
                size += dirSize;

                // Return true
                return true;
            }

            /// <summary> Public method deletes the folder for this CD if there
            /// are no files packed into it. </summary>
            public void Delete()
            {
                // Perform in try/catch
                try
                {
                    // If this is empty, delete the directory
                    if (size == 0)
                        Directory.Delete(processDirectory);
                }
                catch
                {
                    error = true;
                }
            }

            /// <summary> Public method that finalizes this CD, by changing the folder
            /// name to remove the ' - incomplete' label, and sets this CD to accept
            /// no more items to pack. </summary>
            public void Finalize()
            {
                // Perform in a try/catch
                try
                {
                    // Rename this folder if the new name doesn't exist
                    if (!Directory.Exists(directory + CD_Packer.CD_Prefix + " " + cdNumber))
                        Directory.Move(processDirectory, directory + "\\" + CD_Packer.CD_Prefix + " " + cdNumber);

                    // Set the size to be identical to capacity
                    size = (capacity * 1048576);
                }
                catch
                {
                    // Rather trivial error, so don't display a message
                    error = true;
                }
            }

            #endregion

            #region PRIVATE METHODS of the newCdObject Sub-Class

            /// <summary> Private helper method determines the current size of the CD
            /// on the hard disk.  Used during construction if the CD already exists. This method
            /// calls itself recursively for any sub-directories which exist. </summary>
            private void setCurrentSize(string directory)
            {
                // Add the size of each file in this directory to current size
                foreach (string file in Directory.GetFiles(directory))
                    size += (decimal)(new FileInfo(file).Length);

                // Calls itself recursively for any subdirectories
                foreach (string subdirectory in Directory.GetDirectories(directory))
                    setCurrentSize(subdirectory);
            }

            #endregion
        }

        #endregion
    }
}