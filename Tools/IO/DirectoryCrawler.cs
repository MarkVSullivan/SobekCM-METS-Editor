using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DLC.Tools.Logs;

namespace DLC.Tools.IO
{
	/// <summary> DirectoryCrawler is a class which will check a directory, and every subdirectory,
	/// and compile a list of all the files. <br /> <br /> </summary>
	/// <remarks> Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center. </remarks>
	/// <example> EXAMPLE 1: The example below generates the following output files: <ul>
	/// <li type="circle" /> <a href="DirCrawlerExample.html"> XHTML Output File </a>
	/// <li type="circle" /> <a href="DirCrawlerExample.txt"> Text Output File </a>
	/// <li type="circle" /> <a href="DirCrawlerExample.xml"> XML Output File </a> and associated <a href="DirCrawlerExample.xsd"> XSD File </a>
	/// </ul>
	/// <code>
	/// <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using CustomTools.IO;
	///	using CustomTools.Forms;
	///
	///	namespace CustomTools
	///	{
	///		public class DirectoryCrawler_Example
	///		{
	///			static void Main() 
	///			{
	///				// Create a new DirectoryCrawler object to iterate through directories
	///				DirectoryCrawler searcher = new DirectoryCrawler();
	///
	///				// Set the first starting directory, and then the user defined field
	///				searcher.StartingDirectory = "F:\\";
	///				searcher.UserDefinedField = "DVD Drive";
	///
	///				// Tell the searcher to iterate through the just set information
	///				searcher.Iterate();
	///
	///				// Now, iterate through another drive/directory
	///				searcher.Iterate( "G:\\", "CD Rom" );
	///
	///				// Display this data set
	///				ShowDataTable shower = new ShowDataTable( searcher.DataSet );
	///				shower.ShowDialog();
	///
	///				// Output to HTML, Text, and XML
	///				searcher.CreateHTML( "C:\\DirCrawlerExample" );
	///				searcher.CreateText( "C:\\DirCrawlerExample" );
	///				searcher.CreateXML( "C:\\DirCrawlerExample" );
	///				
	///				// Print out the name of each file to the Console window by iterating through the File Collection
	///				foreach ( DirectoryCrawler_File thisFile in searcher.Files )
	///					Console.WriteLine( thisFile.Name + "." + thisFile.Extension + " from the user defined search '" + thisFile.UserDefined + "'" );
	///			}
	///		}
	///	} 
	/// </code> <br /> <br />
	/// Below is what is printed to the Console when the application above is executed:
	/// <code>
	///	43.TIF from the user defined search 'DVD Drive'
	///	44.TIF from the user defined search 'DVD Drive'
	///	45.TIF from the user defined search 'DVD Drive'
	///	46.TIF from the user defined search 'DVD Drive'
	///	47.TIF from the user defined search 'DVD Drive'
	///	48.TIF from the user defined search 'DVD Drive'
	///	49.TIF from the user defined search 'DVD Drive'
	///	50.TIF from the user defined search 'DVD Drive'
	///	51.TIF from the user defined search 'DVD Drive'
	///	52.TIF from the user defined search 'DVD Drive'
	///	53.TIF from the user defined search 'DVD Drive'
	///	54.TIF from the user defined search 'DVD Drive'
	///	55.TIF from the user defined search 'DVD Drive'
	///	56.TIF from the user defined search 'DVD Drive'
	///	12057_1938_INDEX_19.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_19.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_19.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_2.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_2.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_19_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_20.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_20.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_2.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_21.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_21.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_2_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_21_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_23_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_23.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_21.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_24.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_22.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_23.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_22.SID from the user defined search 'CD Rom'
	///	12057_1938_INDEX_20.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_24.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_22.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_23.JPG from the user defined search 'CD Rom'
	///	12057_1938_INDEX_20_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_22_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_24_prcss.TIF from the user defined search 'CD Rom'
	///	12057_1938_INDEX_24.JPG from the user defined search 'CD Rom' 
	/// </code> </example>
	public class DirectoryCrawler
	{
		/// <summary> Private integer value which holds the format type. 0-HTML, 1-Text, 2-XML, 3-Access, 4-Display </summary>
		private int formatIdentifier;

		/// <summary> Private string value holds the starting directory for iteration purposes. </summary>
		private string startingDirectory;

		/// <summary> Private string value holds the starting directories which were used for iteration purposes. </summary>
		private string startingDirectoryList;

		/// <summary> Private DataSet value which holds the list of all the files. </summary>
		private DataSet listOfFiles;

		/// <summary> Private DataTables provide direct access to the tables inside the DataSet. </summary>
		private DataTable dirTbl, fileTbl;

		/// <summary> Private integer variable holds the last directory key used. </summary>
		private int lastDirKey;

		/// <summary> Field which the user can control to differentiate between different sources. </summary>
		private object userControlledField;

		/// <summary> File Collection used when the Files property is called. </summary>
		private DirectoryCrawler_FileCollection allFiles;

		/// <summary> Collection of all the user defined fields used </summary>
		private DirectoryCrawler_UserDefinedCollection allFields;

		/// <summary> Flag indicates whether object references should be saved for a user specified
		/// custom object to link to each found file. </summary>
		private bool useObject;

		/// <summary> Stores the custom objects which are added to each file found. </summary>
		private ArrayList customObject;

		/// <summary> Constructor for the DirectoryCrawler class which iterates through a directory and
		/// creates an ouput with all the files. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler(  )
		{
			// Set the starting directory as an empty string
			this.startingDirectory = "";
			startingDirectoryList = "";
			userControlledField = "";

			// Setup the DataSet file
			createDataSet();

			// Set the initial value for the last directory key to 0
			lastDirKey = 0;

			// Set the File and Object collection to a new one
			allFiles = new DirectoryCrawler_FileCollection();
			allFields = new DirectoryCrawler_UserDefinedCollection();
			customObject = new ArrayList();
		}

		/// <summary> Constructor for the DirectoryCrawler class which iterates through a directory and
		/// creates an ouput with all the files. </summary>
		/// <param name="startingDirectory"> Starting point for directory iteration </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler( string startingDirectory )
		{
			// Save the parameter
			this.startingDirectory = startingDirectory;
			startingDirectoryList = "";
			userControlledField = "";

			// Setup the DataSet file
			createDataSet();

			// Set the initial value for the last directory key to 0
			lastDirKey = 0;
			
			// Set the File and Object collection to a new one
			allFiles = new DirectoryCrawler_FileCollection();
			allFields = new DirectoryCrawler_UserDefinedCollection();
			customObject = new ArrayList();
		}

		/// <summary> Constructor for the DirectoryCrawler class which iterates through a directory and
		/// creates an ouput with all the files. </summary>
		/// <param name="formatIdentifier"> Value which tells the format type. 0-HTML, 1-Text, 2-XML, 3-Access, 4-Display  </param>
		/// <param name="OutputFile"> File and path for the output file. (minus extension) </param>
		/// <param name="startingDirectory"> Starting point for directory iteration </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler( int formatIdentifier, string OutputFile, string startingDirectory )
		{
			// Save the parameters
			this.formatIdentifier = formatIdentifier;
			this.startingDirectory = startingDirectory;
			startingDirectoryList = "";

			// Setup the DataSet file
			createDataSet();

			// Set the initial value for the last directory key to 0 and user controlled field
			lastDirKey = 0;
			userControlledField = "";

			// Set the File and Object collection to a new one
			allFiles = new DirectoryCrawler_FileCollection();
			allFields = new DirectoryCrawler_UserDefinedCollection();
			customObject = new ArrayList();

			// Iterate through the source drive
			this.Iterate();

			// Depening on the requested output type, perform output
			if ( formatIdentifier == 0 )
				CreateHTML( OutputFile );
			if ( formatIdentifier == 1 )
				CreateText( OutputFile );
			if ( formatIdentifier == 2 )
				CreateXML( OutputFile );
			if ( formatIdentifier == 3 )
				CreateAccess( OutputFile );
		}

		/// <summary> Gets the DataSet which has the list of all files under this directory. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		/// <remarks>
		/// This returns two DataTables which containe has the following DataColumn elements: <br /> <br />
		/// Table Name: Directories <br />
		/// <table border="1">
		/// <tr>
		/// <th><font size="2">Column Index</font></th>
		/// <th><font size="2">Column Name</font></th>
		/// <th><font size="2">DataType</font></th>
		/// <th><font size="2">Description</font></th>
		/// </tr>
		/// <tr>
		/// <td><font size="2">0</font></td>
		/// <td><font size="2">Key</font></td>
		/// <td><font size="2"><see cref="int"/></font></td>
		/// <td><font size="2">Primary key to this directory (referenced in the next table)</font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">1</font></td>
		/// <td><font size="2">Reference</font></td>
		/// <td><font size="2"><see cref="string"/></font></td>
		/// <td><font size="2">Directory in string form </font></td>
		/// </tr>
		/// </table><br /> <br />
		/// Table Name: Files <br />
		/// <table border="1">
		/// <tr>
		/// <th><font size="2">Column Index</font></th>
		/// <th><font size="2">Column Name</font></th>
		/// <th><font size="2">DataType</font></th>
		/// <th><font size="2">Description</font></th>
		/// </tr>
		/// <tr>
		/// <td><font size="2">0</font></td>
		/// <td><font size="2">Name</font></td>
		/// <td><font size="2"><see cref="string"/></font></td>
		/// <td><font size="2">File Name (minus extension and path)</font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">1</font></td>
		/// <td><font size="2">Extension</font></td>
		/// <td><font size="2"><see cref="string"/></font></td>
		/// <td><font size="2">Extension for this file </font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">2</font></td>
		/// <td><font size="2">DirKey</font></td>
		/// <td><font size="2"><see cref="int"/></font></td>
		/// <td><font size="2">References the primary key in the Directories table</font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">3</font></td>
		/// <td><font size="2">Size</font></td>
		/// <td><font size="2"><see cref="long"/></font></td>
		/// <td><font size="2">Size of this file (in KB) </font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">4</font></td>
		/// <td><font size="2">Created</font></td>
		/// <td><font size="2"><see cref="DateTime"/></font></td>
		/// <td><font size="2">Date and Time this file was created</font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">5</font></td>
		/// <td><font size="2">Modified</font></td>
		/// <td><font size="2"><see cref="DateTime"/></font></td>
		/// <td><font size="2">Date and Time this file was last modified</font></td>
		/// </tr>
		/// <tr>
		/// <td><font size="2">6</font></td>
		/// <td><font size="2">UserDefined</font></td>
		/// <td><font size="2"><see cref="string"/></font></td>
		/// <td><font size="2">Value set by the user associated with this iteration</font></td>
		/// </tr>
		/// </table>
		/// </remarks>
		public DataSet DataSet
		{
			get	{	return listOfFiles;	}
		}

		/// <summary> Returns the collection of all user defined fields </summary>
		public DirectoryCrawler_UserDefinedCollection All_User_Defined_Fields
		{
			get	{	return this.allFields;		}
		}

		/// <summary> Gets and sets a field which is user defined in all of the outputs.  </summary>
		/// <remarks> This field is used to differentiate between different searches, or different
		/// source directories, when multiple searches are performed back-to-back. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public object UserDefinedField
		{
			get	{	return this.userControlledField;	}
			set	
			{	
				// Save this user controlled field if it has length and doesn't already exist
				if (( UserDefinedField != null ) && ( !allFields.Contains( UserDefinedField ) ))
					allFields.Add( UserDefinedField );

				// Save this as the current user controlled field
				userControlledField = value;		
			}
		}

		/// <summary> Gets and sets the directory to iterate through collecting file information.  </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public string StartingDirectory
		{
			get	{	return this.startingDirectory;	}
			set	{	startingDirectory = value;		}
		}

		/// <summary> Gets a collection of <see cref="DirectoryCrawler_File"/> objects for the files found. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		/// <remarks> This returns a <see cref="DirectoryCrawler_FileCollection"/> object which is used to iterate
		/// through all of the found <see cref="DirectoryCrawler_File"/> objects. </remarks>
		public DirectoryCrawler_FileCollection Files
		{
			get
			{
				return allFiles;
			}
		}

		/// <summary> Gets and sets the user defined object which will be included in the <see cref="DirectoryCrawler_FileCollection"/>
		/// accessible through this class's <see cref="Files"/> method. </summary>
		/// <remarks> Set to null to disable the custom object.  </remarks>
		public object UserDefinedObject
		{
			get {	return	customObject[ customObject.Count - 1 ];	}
			set
			{
				// If this equals null, then disabled the object portion
				if ( value == null )
					this.useObject = false;
				else
				{
					this.useObject = true;
					customObject.Add( value );
				}
			}		
		}

		/// <summary> Gets the list of all files and directories as a string collection. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public StringCollection ToStringCollection
		{
			get
			{
				// Create the list of directories
				StringDictionary directories = new StringDictionary();
				string tempDir;
				for ( int j = 0 ; j < dirTbl.Rows.Count ; j++ )
				{
					tempDir = dirTbl.Rows[j][1].ToString();
					if ( tempDir[tempDir.Length - 1 ] != '\\' )
						tempDir = tempDir + "\\";
					directories.Add( dirTbl.Rows[j][0].ToString(), tempDir );
				}

				// Iterate through each row in the file table and add to the Sorted List
				StringCollection files = new StringCollection();
				for ( int i = 0 ; i < fileTbl.Rows.Count ; i++ )
					files.Add( directories[fileTbl.Rows[i][2].ToString()] + fileTbl.Rows[i][0].ToString() + "." + fileTbl.Rows[i][1].ToString() );

				// Now, return this String Collection
				return files;
			}
		}

		/// <summary> Gets a collection of file objects for the files which 
		/// have a certain user defined field </summary>
		/// <param name="UserDefinedField"> Field to return the collection of matching files for </param>
		/// <returns> Collection of files </returns>
		public DirectoryCrawler_FileCollection Get_Files( object UserDefinedField )
		{
			// Create the return collection
			DirectoryCrawler_FileCollection returnVal = new DirectoryCrawler_FileCollection();

			// Iterate through all the files and add only those that match
			foreach( DirectoryCrawler_File thisFile in allFiles )
			{
				// If this user defined field matches, add it to this collection
				if ( thisFile.UserDefined.Equals( UserDefinedField.ToString() ) )
					returnVal.Add( thisFile );
			}

			// Return the created collection
			return returnVal;
		}

		/// <summary> Starts the process of iterating through all of the directories and subfiles. </summary>
		/// <returns> TRUE if successful, or FALSE if an error occurred </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Iterate( )
		{
			return Iterate( startingDirectory, userControlledField, "*.*" );
  		}

		/// <summary> Starts the process of iterating through all of the directories and subfiles. </summary>
		/// <param name="StartingDirectory"> Directory to iterate through collecting file information </param>
		/// <returns> TRUE if successful, or FALSE if an error occurred </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Iterate( string StartingDirectory )
		{
			return Iterate( StartingDirectory, userControlledField, "*.*" );
		}

		/// <summary> Starts the process of iterating through all of the directories and subfiles. </summary>
		/// <param name="StartingDirectory"> Directory to iterate through collecting file information </param>
		/// <param name="UserDefinedField"> Field which is user defined in all of the outputs </param>
		/// <returns> TRUE if successful, or FALSE if an error occurred </returns>
		/// <remarks> The User Defined Field is used to differentiate between different searches, or different
		/// source directories, when multiple searches are performed back-to-back. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Iterate( string StartingDirectory, object UserDefinedField )
		{
			return Iterate( StartingDirectory, UserDefinedField, "*.*", String.Empty );
		}

        /// <summary> Starts the process of iterating through all of the directories and subfiles. </summary>
		/// <param name="StartingDirectory"> Directory to iterate through collecting file information </param>
		/// <param name="UserDefinedField"> Field which is user defined in all of the outputs </param>
		/// <param name="SearchString"> Search string to match against the names of files in the subdirectories </param>
		/// <returns> TRUE if successful, or FALSE if an error occurred </returns>
		/// <remarks> The User Defined Field is used to differentiate between different searches, or different
		/// source directories, when multiple searches are performed back-to-back. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Iterate( string StartingDirectory, object UserDefinedField, string SearchString )
        {
            return Iterate(StartingDirectory, UserDefinedField, SearchString, String.Empty);
        }

		/// <summary> Starts the process of iterating through all of the directories and subfiles. </summary>
		/// <param name="StartingDirectory"> Directory to iterate through collecting file information </param>
		/// <param name="UserDefinedField"> Field which is user defined in all of the outputs </param>
		/// <param name="SearchString"> Search string to match against the names of files in the subdirectories </param>
		/// <returns> TRUE if successful, or FALSE if an error occurred </returns>
		/// <remarks> The User Defined Field is used to differentiate between different searches, or different
		/// source directories, when multiple searches are performed back-to-back. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Iterate( string StartingDirectory, object UserDefinedField, string SearchString, string ExlusionString )
		{
			try
			{
				// Save the starting directory and user defined field
				this.startingDirectory = StartingDirectory;
				this.userControlledField = UserDefinedField;

				// Save this user controlled field if it has length and doesn't already exist
				if (( UserDefinedField != null ) && ( !allFields.Contains( UserDefinedField ) ))
					allFields.Add( UserDefinedField );

				// Save this as one starting directory which was used
				if ( startingDirectoryList.Length > 0 )
					startingDirectoryList = startingDirectoryList + ", " + StartingDirectory;
				else
					startingDirectoryList = StartingDirectory;

				// Iterate through each directory
                checkDir(startingDirectory, SearchString, ExlusionString);

				// Process complete, return true;
				return true;
			}
			catch	
			{	
				return false;			
			}
		}

		/// <summary> Creates a HTML output file of the current subdirectory and file information.  </summary>
		/// <param name="OutputFile"> Path and filename for the output HTML file  (minus extension) </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool CreateHTML( string OutputFile )
		{
			try
			{
				// Create the new HTML file
				LogFileXHTML htmlFile = new LogFileXHTML( OutputFile + ".html", "List of Files", "DirectoryIterator" );
				htmlFile.New();
				htmlFile.DateStampingEnabled = false;

				// Create the list of directories
				StringDictionary directories = new StringDictionary();
				string tempDir;
				for ( int j = 0 ; j < dirTbl.Rows.Count ; j++ )
				{
					tempDir = dirTbl.Rows[j][1].ToString();
					if ( tempDir[tempDir.Length - 1 ] != '\\' )
						tempDir = tempDir + "\\";
					directories.Add( dirTbl.Rows[j][0].ToString(), tempDir );
				}

				// Iterate through each row in the file table and add to the Sorted List
				SortedList files = new SortedList();
				for ( int i = 0 ; i < fileTbl.Rows.Count ; i++ )
					if ( !files.ContainsKey( fileTbl.Rows[i][0] ) )
						files.Add( fileTbl.Rows[i][0], directories[fileTbl.Rows[i][2].ToString()] + fileTbl.Rows[i][0].ToString() + "." + fileTbl.Rows[i][1].ToString() );

				// Add the process information
				htmlFile.AddError("RESULTS FROM DIRECTORY ITERATION STARTING AT: " + startingDirectoryList );
				htmlFile.AddError("PROCESS COMPLETED ON " + DateTime.Now.ToLongDateString().ToUpper() );
				htmlFile.AddNonError("<br />");

				// Now, add from the sorted list to the file
				for ( int i = 0 ; i < files.Count ; i++ )
					htmlFile.AddNonError( files.GetByIndex(i).ToString() );

				// Add a completion statement at the bottom
				htmlFile.AddComplete( files.Count + " FILES FOUND" );

				// Must be successful, so return true
				return true;
			}
			catch
			{
				// Error was detected
				return false;
			}
		}

		/// <summary> Creates a text output file  of the current subdirectory and file information. </summary>
		/// <param name="OutputFile"> Path and filename for the output Text file  (minus extension)</param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool CreateText( string OutputFile )
		{
			try
			{
				// Create the new HTML file
				LogFileText textFile = new LogFileText( OutputFile + ".txt" );
				textFile.New();
				textFile.DateStampingEnabled = false;

				// Create the list of directories
				StringDictionary directories = new StringDictionary();
				string tempDir;
				for ( int j = 0 ; j < dirTbl.Rows.Count ; j++ )
				{
					tempDir = dirTbl.Rows[j][1].ToString();
					if ( tempDir[tempDir.Length - 1 ] != '\\' )
						tempDir = tempDir + "\\";
					directories.Add( dirTbl.Rows[j][0].ToString(), tempDir );
				}

				// Iterate through each row in the file table and add to the sorted list
				SortedList files = new SortedList();
				for ( int i = 0 ; i < fileTbl.Rows.Count ; i++ )
					if ( !files.ContainsKey( fileTbl.Rows[i][0] ) )
						files.Add( fileTbl.Rows[i][0], directories[fileTbl.Rows[i][2].ToString()] + fileTbl.Rows[i][0].ToString() + "." + fileTbl.Rows[i][1].ToString() );

				// Now, add from the sorted list to the file
				for ( int i = 0 ; i < files.Count ; i++ )
					textFile.Write( files.GetByIndex(i).ToString() );

				// Must be successful, so return true
				return true;
			}
			catch
			{
				// Error was detected
				return false;
			}
		}

		/// <summary> Creates a XML and XSD file output of the current subdirectory and file information. </summary>
		/// <param name="OutputFile"> Path and filename for the output XML and XSD files (minus extension) </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool CreateXML( string OutputFile )
		{
			try
			{
				// Create a StreamWriter to write out the XML, write it out, and close
				StreamWriter myXmlWriter = new StreamWriter( OutputFile + ".xml" );
				listOfFiles.WriteXml( myXmlWriter );
				myXmlWriter.Close();

				// Create a StreamWriter to write out the XML Schema, write it out, and close
				StreamWriter SchemaWriter = new StreamWriter( OutputFile + ".xsd");
				listOfFiles.WriteXmlSchema( SchemaWriter );
				SchemaWriter.Close();

				// Must be successful, so return true
				return true;
			}
			catch
			{
				// Error was detected
				return false;
			}
		}

		/// <summary> Creates an Access database of the current subdirectory and file information. </summary>
		/// <param name="OutputFile"> Path and filename for the output MDB file (minus extension) </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool CreateAccess( string OutputFile )
		{
			try
			{
				////			// Only continue if the blank access database can be found
				////			if ( File.Exists( blankDatabase ) )
				////			{
				////				// Copy the blank database to the output location
				////				File.Copy( blankDatabase, outputDirectory + "\\" + outputName + ".mdb", true );
				////
				////				// Create connection to the database
				////				string dbConnectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputDirectory + "\\" + outputName + ".mdb;";
				////				OleDatabaseWrapper myDB = new OleDatabaseWrapper( dbConnectString );
				////				myDB.Open();
				////
				////				// Add all the directories
				////				for ( int i = 0 ; i < dirTbl.Rows.Count ; i++ )
				////					myDB.ExecuteInsert("INSERT INTO [Directories] ([Key], [Reference]) VALUES ( " + dirTbl.Rows[i][0] + ", '" + dirTbl.Rows[i][1] + "' );");
				////
				////				// Add all the files
				////				DataRow thisRow;
				////				for ( int i = 0 ; i < fileTbl.Rows.Count ; i++ )
				////				{
				////					thisRow = fileTbl.Rows[i];
				////					myDB.ExecuteInsert("INSERT INTO [Files] ([Name], [Extension], [DirKey], [Size], [Created], [Modified]) VALUES ( '" + 
				////						thisRow[0] + "', '" + thisRow[1] + "', " + thisRow[2] + ", " + thisRow[3] + ", '" + thisRow[4] + "', '" + thisRow[5] + "' );");
				////				}
				////
				////				// Close the connection to the database
				////				myDB.Close();
				////			}

				// Must be successful, so return true
				return true;
			}
			catch
			{
				// Error was detected
				return false;
			}
		}

		/// <summary> Private helper method which calls itself recursively to run through
		/// this directory and all subdirectories. </summary>
		/// <param name="directory"> Directory name </param>
		/// <param name="searchString"> Search string to match against the names of files in the subdirectories </param>
		private void checkDir( string directory, string searchString, string exclusionString )
		{
			// Both processes are done in try/catch in case there is a permissions issue
			try
			{
                // Get the appropriate exclusion string
                string excluder = String.Empty;
                if (exclusionString.Length > 0)
                {
                    excluder = excluder.Replace("*", "").Trim().ToUpper();
                }

				// Get the list of files and see if any are present
				string[] fileList = Directory.GetFiles( directory, searchString );
				if ( fileList.Length > 0 )
				{
					// Add this row to the directory table
					DataRow dirRow = dirTbl.NewRow();
					dirRow[0] = ( ++lastDirKey );
					dirRow[1] = directory;
					dirTbl.Rows.Add( dirRow );
			
					// For any files in this directory, add information
					DataRow fileRow;
					FileInfo fi;
					foreach ( string file in fileList )
					{
						// Get the FileInfo for this file
						fi = new FileInfo( file );

                        // Only continue if this does not match an exclustion
                        if ((excluder.Length == 0) || (fi.Name.ToUpper().IndexOf(excluder) < 0))
                        {
                            // Add this file to the file table
                            fileRow = fileTbl.NewRow();
                            fileRow[0] = fi.Name.Split(".".ToCharArray())[0];
                            if ((fi.Extension.Length > 0) && (fi.Extension[0] == '.'))
                                fileRow[1] = fi.Extension.Substring(1).ToUpper();
                            else
                                fileRow[1] = fi.Extension.ToUpper();
                            fileRow[2] = lastDirKey;
                            fileRow[3] = fi.Length;
                            fileRow[4] = fi.CreationTime;
                            fileRow[5] = fi.LastWriteTime;
                            if (userControlledField == null)
                                fileRow[6] = DBNull.Value;
                            else
                                fileRow[6] = userControlledField.ToString();
                            fileTbl.Rows.Add(fileRow);

                            // Now, create a new DirectoryCrawler_File in the collection
                            if (useObject)
                                allFiles.Add(fileRow[0].ToString(), fileRow[1].ToString(), directory, fi.Length, fi.CreationTime, fi.LastWriteTime, userControlledField.ToString(), UserDefinedObject);
                            else
                                allFiles.Add(fileRow[0].ToString(), fileRow[1].ToString(), directory, fi.Length, fi.CreationTime, fi.LastWriteTime, userControlledField.ToString());
                        }
					}
				}
			}
            catch (Exception ee)
            {
                Tools.Forms.ErrorMessageBox.Show("Error while recursively checking folders", "Error", ee);
            }

			// Calls itself recursively for any subdirectories
			try
			{
				foreach ( string subdirectory in Directory.GetDirectories( directory ) )
					checkDir( subdirectory, searchString, exclusionString );
			}
			catch	{	}
		}

		/// <summary> Private helper method which creates the disconnected DataSet in
		/// memory which will house the names of all the files. </summary>
		private void createDataSet( )
		{
			// Declare a new DataSet
			listOfFiles = new DataSet( "DirectoryIterator" );

			// Create the table which holds the list of all directories
			dirTbl = new DataTable( "Directories" );
			dirTbl.Columns.Add( new DataColumn( "Key", Type.GetType( "System.Int32" ) ) );
			dirTbl.Columns.Add( new DataColumn( "Reference", Type.GetType( "System.String" ) ) );
			listOfFiles.Tables.Add( dirTbl );

			// Create the table to hold the list of all files
			fileTbl = new DataTable( "Files" );
			fileTbl.Columns.Add( new DataColumn( "Name", Type.GetType( "System.String" ) ) );
			fileTbl.Columns.Add( new DataColumn( "Extension", Type.GetType( "System.String" ) ) );
            fileTbl.Columns.Add(new DataColumn("DirKey", Type.GetType("System.Int32")));
            fileTbl.Columns.Add(new DataColumn("Size", Type.GetType("System.Int32")));
			fileTbl.Columns.Add( new DataColumn( "Created", Type.GetType( "System.DateTime" ) ) );
			fileTbl.Columns.Add( new DataColumn( "Modified", Type.GetType( "System.DateTime" ) ) );
			fileTbl.Columns.Add( new DataColumn( "UserDefined", Type.GetType( "System.String" ) ) );
			listOfFiles.Tables.Add( fileTbl );

			// Now, add the relationship between the two tables
			DataRelation dtRelation = new DataRelation( "DirFileRelation", dirTbl.Columns["Key"], fileTbl.Columns["DirKey"] );
			fileTbl.ParentRelations.Add( dtRelation );
		}
	}
}
