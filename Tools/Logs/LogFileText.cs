using System;
using System.IO;
using System.Text;

namespace DLC.Tools.Logs
{
	/// <summary> A log file IO control object which writes to a text-based log file. <br /><br /></summary>
	/// <remarks> This class establishes a text log file and writes to it.  There are two modes that can
	/// be used for this log file.  You can specify <see cref="LogFileText.Open"/> and <see cref="LogFileText.Close"/>, which will leave
	/// the file stream (and associated resources) open during the period between the two calls.
	/// Alternatively, you can just call the <see cref="LogFileText.Write"/> routine directly.  It will open the stream
	/// before the write and close right after writing and modifying the header information. <br /> <br /> 
	/// This log file will wrap around after the number of lines specified in the constructor
	/// or in <see cref="LogFileText.MaxLinesAllowed"/>.  <br /> <br />
	/// Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.   </remarks>
	/// <example> Below is the first example of how to use this class.<code>
	/// <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using System.IO;
	///	using GeneralTools.Logs;
	///
	///	namespace DLC.Tools
	///	{
	///		public class LogFileText_Example_1
	///		{
	///			static void Main() 
	///			{
	///				// Create a new Text Log File
	///				LogFileText myLogger = new LogFileText("c:\\example1.log");
	///
	///				// Set some of the values [these could have been set in the constructor]
	///				myLogger.DateStampingEnabled = true;	
	///				myLogger.enableRowHeaders("Example 1");
	///				myLogger.MaxLinesAllowed = 15;
	///
	///				// Make sure this is a fresh log file
	///				myLogger.New();
	///
	///				// Open the file explicitly.  This will leave a connection open for 
	///				// the next few lines of processing until Close() is called.
	///				myLogger.Open();
	///
	///				// Go through and add each diretory name to this log file
	///				int folderNumber = 1;
	///				foreach ( string thisDir in Directory.GetDirectories("C:\\") )
	///				{
	///					myLogger.Write( "Folder " + thisDir + " is the " + folderNumber + "th folder found." );
	///					folderNumber++;
	///				}
	///
	///				// Add a final line
	///				myLogger.Write( folderNumber + " TOTAL FOLDERS FOUND!" );
	///			
	///				// Now, close the log file connection
	///				myLogger.Close();
	///			}
	///		}
	///	}
	/// </code> <br />
	/// The first example below results in the following in the log file 'example1.log'.  This demonstrates
	/// how the log file will loop back around to the top after the maximum number of lines are found:
	/// <code>
	///	Log File c:\example1.log.  Created: 11/10/2003 1:18:48 PM                                                                   
	///	[7/15/128]                                                                                                   
	///                                                                                                                             
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\RECYCLER is the 14th folder found.                                             
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\System Volume Information is the 15th folder found.                            
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\WINNT is the 16th folder found.                                                
	///	11/10/2003 1:18:48 PM - Example 1 - 17 TOTAL FOLDERS FOUND!                                                                  
	///                                                                                                                             
	///	_____________________________________________________________________________________________________________________________
	///                                                                                                                             
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\Inetpub is the 8th folder found.                                               
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\My Music is the 9th folder found.                                              
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\OfficeScan NT is the 10th folder found.                                        
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\Perl is the 11th folder found.                                                 
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\Processing is the 12th folder found.                                           
	///	11/10/2003 1:18:48 PM - Example 1 - Folder C:\Program Files is the 13th folder found.                                        
	/// </code> <br /> <br /> <br />
	/// This second example shows how to use this object to make a simple text file which can easily
	/// be imported into a database or spreadsheet, by using minimal information at the beginning of
	/// each row, and programmatically deliminating each field.<code>
	/// <SPAN class="lang">[C#]</SPAN> 
	/// using System;
	///	using System.IO;
	///	using GeneralTools.Logs;
	///
	///	namespace DLC.Tools
	///	{
	///		public class LogFileText_Example_2
	///		{
	///			static void Main() 
	///			{
	///				// Create a new Text Log File
	///				LogFileText myLogger = new LogFileText("c:\\example2.log");
	///				myLogger.New();
	///
	///				// Set some of the values [these could have been set in the constructor]
	///				myLogger.DateStampingEnabled = false;	
	///				myLogger.disableRowHeaders();
	///				myLogger.MaxLinesAllowed = 1000;
	///
	///				// Write an explanation first line
	///				myLogger.Write("Directory Name|Last Write Time|File Count");
	///
	///				// Go through and add each diretory name to this log file
	///				foreach ( string thisDir in Directory.GetDirectories("C:\\") )
	///				{
	///					// May not have access to some of this information, so perform in try/catch
	///					try
	///					{
	///						// Write the folder name and further information
	///						myLogger.Write( thisDir + "|" + ( new DirectoryInfo(thisDir).LastWriteTime.ToShortDateString() ) + "|" + Directory.GetFiles(thisDir).Length);
	///					}
	///					catch
	///					{
	///					}
	///				}
	///			}
	///		}
	///	}
	///	</code> <br />
	/// This second example results in the following in the log file 'example2.log':
	/// <code>
	///	Log File c:\example2.log.  Created: 11/10/2003 3:26:18 PM                                                                   
	///	[19/1000/128]                                                                                                
	///                                                                                                                             
	///	Directory Name|Last Write Time|File Count                                                                                   
	///	C:\adaptec|3/10/2003|1                                                                                                       
	///	C:\ADOBEAPP|6/10/2002|0                                                                                                      
	///	C:\Aerials|11/7/2003|0                                                                                                       
	///	C:\comcheck|9/16/2002|0                                                                                                      
	///	C:\Content SDK|10/10/2002|5                                                                                                  
	///	C:\dell|6/4/2002|0                                                                                                           
	///	C:\Documents and Settings|10/13/2003|0                                                                                       
	///	C:\Inetpub|6/29/2002|0                                                                                                       
	///	C:\My Music|10/26/2003|0                                                                                                     
	///	C:\OfficeScan NT|11/7/2003|95                                                                                                
	///	C:\Perl|6/25/2002|2                                                                                                          
	///	C:\Processing|11/7/2003|0                                                                                                    
	///	C:\Program Files|10/15/2003|2                                                                                                
	///	C:\RECYCLER|2/17/2003|0                                                                                                      
	///	C:\WINNT|11/10/2003|158                                                                                                           
	///                                                                                                                             
	///	_____________________________________________________________________________________________________________________________
	///	
	///	</code>
	///</example>
	public class LogFileText
	{
		private const int DEFAULT_LINES_ALLOWED = 5000;
		private const int DEFAULT_LINE_LENGTH = 128;
		private string fileName;			// stores the name of the log file
		private string eachRowHeader;		// store a string to be written after the date
		private int linesAllowed;			// the number of lines allowed in current log file
		private int lineLength;				// length of the line for current log file
		private int currentLine;			// current position in the log file
		private bool leaveOpen;				// flag to determine if the log stays open or not
		private bool dateStamping;			// flag for date stamping before each line
		private bool suppressExceptions;	// flag indicates whether exceptions should be suppressed
		private DateTime dateCreated;		// date the file was created
		private FileStream logFileStream;

	
		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Lines Allowed - 5000 lines before wrap around occurs
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileText.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileText(string newFileName)
		{
			setupLogFile(newFileName, "", DEFAULT_LINES_ALLOWED, DEFAULT_LINE_LENGTH, false );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="rowHeader"> Information to place at the beginning of each row </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Lines Allowed - 5000 lines before wrap around occurs
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileText.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileText(string newFileName, string rowHeader)
		{
			setupLogFile(newFileName, rowHeader, DEFAULT_LINES_ALLOWED, DEFAULT_LINE_LENGTH, false );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileText.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileText(string newFileName, int linesAllowed)
		{
			setupLogFile(newFileName, "", linesAllowed, DEFAULT_LINE_LENGTH, false );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="lineLength"> Maximum line length allowed </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileText.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileText(string newFileName, int linesAllowed, int lineLength )
		{
			setupLogFile(newFileName, "", linesAllowed, lineLength, false );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="rowHeader"> Information to place at the beginning of each row </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="lineLength"> Maximum line length allowed </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileText.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileText(string newFileName, string rowHeader, int linesAllowed, int lineLength)
		{
			setupLogFile(newFileName, rowHeader, linesAllowed, lineLength, false );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Lines Allowed - 5000 lines before wrap around occurs
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileText(string newFileName, bool suppressExceptions )
		{
			setupLogFile(newFileName, "", DEFAULT_LINES_ALLOWED, DEFAULT_LINE_LENGTH, suppressExceptions );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="rowHeader"> Information to place at the beginning of each row </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Lines Allowed - 5000 lines before wrap around occurs
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileText(string newFileName, string rowHeader, bool suppressExceptions )
		{
			setupLogFile(newFileName, rowHeader, DEFAULT_LINES_ALLOWED, DEFAULT_LINE_LENGTH, suppressExceptions );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Line Length - 128 character line length
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileText(string newFileName, int linesAllowed, bool suppressExceptions )
		{
			setupLogFile(newFileName, "", linesAllowed, DEFAULT_LINE_LENGTH, suppressExceptions );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="lineLength"> Maximum line length allowed </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileText.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileText(string newFileName, int linesAllowed, int lineLength, bool suppressExceptions )
		{
			setupLogFile(newFileName, "", linesAllowed, lineLength, suppressExceptions );
		}

		/// <summary> Create a new text-based log file object.  </summary>
		/// <param name="newFileName">Name of the log file </param>
		/// <param name="rowHeader"> Information to place at the beginning of each row </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="lineLength"> Maximum line length allowed </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileText.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileText(string newFileName, string rowHeader, int linesAllowed, int lineLength, bool suppressExceptions )
		{
			setupLogFile(newFileName, rowHeader, linesAllowed, lineLength, suppressExceptions );
		}

		/// <summary> Helper method which does a good portion of the work necessary when constructing
		/// a new instance of this class. </summary>
		/// <param name="fileName">Name of the log file </param>
		/// <param name="rowHeader"> Information to place at the beginning of each row </param>
		/// <param name="linesAllowed"> Number of lines allowed before wrapping occurs </param>
		/// <param name="lineLength"> Maximum line length allowed </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		private void setupLogFile(string fileName, string rowHeader, int linesAllowed, int lineLength, bool suppressExceptions)
		{
			// Save all of the values
			this.suppressExceptions = suppressExceptions;
			this.fileName = fileName;
			this.linesAllowed = linesAllowed;
			this.lineLength = lineLength;
			if (this.lineLength < 64)
				this.lineLength = 64;
			if (this.lineLength > 256)
				this.lineLength = 256;
			if (this.linesAllowed > 99999)
				this.linesAllowed = 99999;
			if (rowHeader != "")
				rowHeader += " - ";
			this.eachRowHeader = rowHeader;
			this.DateStampingEnabled = true;

			// If the directory for this file does not exist, create it
			try
			{
				if ( !Directory.Exists( new FileInfo(fileName).DirectoryName ) )
					Directory.CreateDirectory( new FileInfo(fileName).DirectoryName );
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to create the directory [" + new FileInfo(fileName).DirectoryName + "] in a LogFileText object.");
			}
		}

		/// <summary> Gets and Sets the flag which indicates if all <see cref="LogFile_Exception"/>s should be
		/// suppressed or not.  </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public bool SuppressExceptions
		{
			get	{	return suppressExceptions;	}
			set	{	suppressExceptions = value;	}
		}

		/// <summary> Gets and Sets the number of lines allowed in this log
		/// file before it begins wrapping back to the top. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// during processing, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public int MaxLinesAllowed
		{
			get	{	return linesAllowed; }
			set	
			{	
				// Open the connection to the log file to read in the log file info
				// from the header in the log file
				if (!leaveOpen)
					openConnection();

				// Set the lines allowed to the value, unless it it too large, or too small.
				if ((value > 10) && (value < 99999))
				{
					linesAllowed = value;
				}
				else
				{
					if (value < 11)
						linesAllowed = 10;
					else 
						linesAllowed = 99999;
				}

				// Close the connection to the log file and write the new header information
				if (!leaveOpen)
					closeConnection();
			}
		}

		/// <summary> Returns true if the log file is currently open. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public bool isOpen
		{
			get	{	return leaveOpen;	}
		}


		/// <summary> Deletes the current log file, closing first if necessary. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// during processing, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public bool New()
		{
			if (leaveOpen)
				closeConnection();
			File.Delete(fileName);
			this.currentLine = 0;
			if (leaveOpen)
				return (openConnection());
			else
				return false;
		}

		/// <summary> Returns true if the log file currently exists. </summary>
		/// <returns> TRUE if the log file exists, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public bool Exists()
		{
			return File.Exists(fileName);
		}

		/// <summary> Opens or creates a log file. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <remarks>  This also specifies that the connection to the file will 
		/// remain open until <see cref="Close"/> is called. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// opening the connection, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public bool Open()
		{
			leaveOpen = true;
			return openConnection();
		}

		/// <summary> Writes a string to the log file.  </summary>
		/// <param name="msg"> String to write as a new line in the log file. </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// during processing, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public bool Write(string msg)
		{
			bool noError = true;
			if ( !leaveOpen )
				noError = openConnection();
			if ( noError)
				noError = configureText(msg);
			if ( !leaveOpen && noError )
				noError = closeConnection();
			return noError;
		}

		/// <summary> Writes an Exception to a log file, formatting correctly. </summary>
		/// <param name="toWrite"> <see cref="Exception"/> to write as new lines in the log file. </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// opening the connection, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public void WriteException ( Exception toWrite )
		{
			string[] exceptList = toWrite.ToString().Split("\n\r".ToCharArray());
			for ( int i = 0 ; i < exceptList.Length ; i++ )
			{
				Write( exceptList[i++] );
			}
		}

		/// <summary> Saves and closes the log file. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// closing the connection, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		public bool Close()
		{
			leaveOpen = false;
			return closeConnection();
		}

		/// <summary> Gets and sets the flag which indicates if each line receives a date stamp. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public bool DateStampingEnabled
		{
			get	{	return dateStamping;	}
			set	{	dateStamping = value;	}
		}

		/// <summary> Disable the additional information between the time/date and the log entry. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public void disableRowHeaders()
		{
			eachRowHeader = "";
		}

		/// <summary> Enables the additional information between the time/date and
		/// the log entry and sets this information to the string which is passed in. </summary>
		/// <param name="textForEachLine"> Text to be used as the Row Headers on each row </param>
		/// <returns> TRUE if the requested row header is accepted, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public bool enableRowHeaders(string textForEachLine)
		{
			if (textForEachLine.Length < ((lineLength / 2) - 30))
			{
				eachRowHeader = textForEachLine;
				return true;
			}
			else
				return false;
		}

		/// <summary> Gets the date and time the current log file was created. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileText"/> class. </example>
		public DateTime DateCreated
		{
			get	{	return dateCreated;	}
		}


		// *****  PRIVATE METHODS  ***** //

		/// <summary> Private method which opens the connection and returns true
		/// or false.  Called by public method Open().   </summary>
		/// <returns> False is returned if the header in the log file is corrupted, otherwise TRUE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// opening the connection, unless the <see cref="LogFileText.SuppressExceptions"/> flag is set to true. </exception>
		private bool openConnection()
		{
			try
			{	// try to open an existing file
				logFileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
				return readCurrentFileInfo();
			}
			catch
			{
				try
				{	// try to create a new file since it was unable to open the existing
					logFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
					createHeader();
					dateCreated = DateTime.Now;
					return true;
				}
				catch
				{	// unable to either open or create the log file
					if ( !suppressExceptions )
						throw new LogFile_Exception("Unable to create or open log file " + fileName + " in LogFileText object.");
					return false;
				}
			}
		}

		/// <summary> Creates the header for a new log file </summary>
		private void createHeader()
		{	
			string headerBuilder = " Log File "+fileName+".  Created: " + DateTime.Now.ToString();
			writeLine(toProperLength(headerBuilder));
			writeCurrentFileInfo();
			currentLine = 2;
			writeLine(toProperLength(" "));
		}

		/// <summary> Writes the specifics of the log file, such as the length, and line length, etc..  </summary>
		private void writeCurrentFileInfo()
		{	
			int tempCurrLineStorage = currentLine;
			currentLine = 1;
			string headerBuilder = "                [" + tempCurrLineStorage.ToString()
                + "/" + linesAllowed.ToString() + "/" + lineLength.ToString() + "]  ";
			writeLine(toProperLength(headerBuilder));
			currentLine = tempCurrLineStorage;
		}

		/// <summary> Reads the information from a preexisting log file.  </summary>
		/// <returns> TRUE if successful, FALSE if the information is corrupted. </returns>
		private bool readCurrentFileInfo()
		{
			try
			{
				StringBuilder tempRead = new StringBuilder("", lineLength);
				char nextByte = ' ';
				char[] deliminators = { '/',']' };

				// Get the date the file was created
				logFileStream.Position = 15;
				while (nextByte != ':')
					nextByte = System.Convert.ToChar(logFileStream.ReadByte());
				nextByte = System.Convert.ToChar(logFileStream.ReadByte());
				nextByte = System.Convert.ToChar(logFileStream.ReadByte());
				while (nextByte != '\r')
				{
					tempRead.Append(nextByte);
					nextByte = System.Convert.ToChar(logFileStream.ReadByte());
				}
				try
				{
					dateCreated = System.Convert.ToDateTime(tempRead.ToString());
				}
				catch
				{
					if ( !suppressExceptions )
						throw new LogFile_Exception("Unable to read the date created in the logfile " + this.fileName );
					return false;
				}

				// Get file information from second row
				tempRead = new StringBuilder("");
				while (nextByte != '[')
					nextByte = System.Convert.ToChar(logFileStream.ReadByte());
				while ((nextByte != ']') && (tempRead.Length < 20))
				{
					nextByte = System.Convert.ToChar(logFileStream.ReadByte());
					tempRead.Append(nextByte);
				}
				if (tempRead.Length > 16)
				{
					if ( !suppressExceptions )
						throw new LogFile_Exception("Unable to read the header completely in the logfile " + this.fileName );
					return false;
				}
				else
				{
					string[] argList = tempRead.ToString().Split(deliminators);
					currentLine = System.Convert.ToInt32(argList[0]);
					linesAllowed = System.Convert.ToInt32(argList[1]);
					lineLength = System.Convert.ToInt32(argList[2]);
					return true;
				}
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to read the header in the logfile " + this.fileName );
				return false;
			}
		}

		/// <summary> take a basic line to go into the log and append the date or rowHeader as necessary.  
		/// Also, breaks up the message if it exceeds the line length for the log file. </summary>
		/// <param name="origMsg"> Message to be configured </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		private bool configureText(string origMsg)
		{
			StringBuilder lineBuilder = new StringBuilder(origMsg, lineLength+2);
			int iLoop, currentLineSave;
			bool saveWriteResult;
			if ( eachRowHeader.Length > 0 )
				lineBuilder.Insert(0, eachRowHeader + " - ");
			if (dateStamping)
				lineBuilder.Insert(0, DateTime.Now.ToString() + " - ");
			int length = (lineBuilder.Length+2);
			int dateLength = DateTime.Now.ToString().Length;
			string msg = lineBuilder.ToString();

			// For multiple line entries
			while ( length > lineLength )
			{
				// print the next line
				writeLine(msg.Substring(0,lineLength-3));
				msg = msg.Substring(lineLength-3);
				if (dateStamping)
				{
					msg = "  - " + msg;
					for ( iLoop = 1 ; iLoop < dateLength ; iLoop++)
						msg = " " + msg;
				}
				length = (msg.Length+2);
			}
			saveWriteResult = writeLine(toProperLength(msg));
			currentLineSave = currentLine;
			// This code prints the line which shows where the log file ends.
			writeLine(toProperLength("",' '));
			writeLine(toProperLength("",'_'));
			writeLine(toProperLength("",' '));
			currentLine = currentLineSave;
			return saveWriteResult;
		}

		/// <summary> takes a string less than the full line length, and appends spaces until
		/// it fills the record length  </summary>
		/// <param name="msg"> Message to be increased to the proper length </param>
		/// <returns> The string of proper length </returns>
		private string toProperLength(string msg)
		{
			return toProperLength(new StringBuilder(msg, lineLength+2) , ' ');
		}

		/// <summary> takes a string less than the full line length, and appends spaces until
		/// it fills the record length  </summary>
		/// <param name="msg"> Message to be increased to the proper length </param>
		/// <param name="filler"> Filler character to use (if not a space ) </param>
		/// <returns> The string of proper length </returns>
		private string toProperLength(string msg, char filler)
		{
			return toProperLength(new StringBuilder(msg, lineLength+2), filler);
		}

		/// <summary> takes a StringBuilder less than the full line length, and appends spaces until
		/// it fills the record length  </summary>
		/// <param name="msg"> Message to be increased to the proper length </param>
		/// <returns> The string of proper length </returns>
		private string toProperLength(StringBuilder msg)
		{
			return toProperLength(msg, ' ');
		}

		/// <summary> takes a StringBuilder less than the full line length, and appends spaces until
		/// it fills the record length  </summary>
		/// <param name="msg"> Message to be increased to the proper length </param>
		/// <param name="filler"> Filler character to use (if not a space ) </param>
		/// <returns> The string of proper length </returns>
		private string toProperLength(StringBuilder msg, char filler)
		{
			int length = (msg.Length+2);
			for ( int iLoop = 1 ; iLoop < (lineLength - length) ; iLoop++ )
				msg.Append(filler); 
			return msg.ToString();
		}

		/// <summary> writes a fully configured and correct length line into 
		/// the file and inserts the carriage return and linefeed. </summary>
		/// <param name="msg"> Message to write to the text-based log file </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		private bool writeLine(string msg)
		{
			int character;
			try
			{
				logFileStream.Position = (currentLine * (lineLength-1));
				for ( character = 0 ; character < (lineLength-3) ; ++character )
					logFileStream.WriteByte(System.Convert.ToByte(msg[character]));
				logFileStream.WriteByte(System.Convert.ToByte('\r'));
				logFileStream.WriteByte(System.Convert.ToByte('\n'));

				currentLine++;
				if (currentLine > linesAllowed)
					currentLine = 3;
				return true;
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to write to the logfile " + this.fileName );
				return false;
			}
		}

		/// <summary> Saves and closes the log file </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		private bool closeConnection()
		{
			try
			{
				writeCurrentFileInfo();
				logFileStream.Close();
				return true;
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to close the connection to the logfile " + this.fileName );
				return false;
			}
		}

	}
}
