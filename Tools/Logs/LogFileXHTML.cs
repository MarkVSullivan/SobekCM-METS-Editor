using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Web.Mail;
using System.Diagnostics;

namespace DLC.Tools.Logs
{
	/// <summary>
	/// This class establishes a rich XHTML log file.  Then, lines can be added in three
	/// flavors ( error, nonerror, and complete). <br /> <br /> </summary>
	/// <remarks> There are two modes that can be used for this log file.  You can 
	/// specify <see cref="LogFileXHTML.Open"/> and <see cref="LogFileXHTML.Close"/>, which will leave the file stream (and associated 
	/// resources) open during the period between the two calls. Alternatively, 
	/// you can just call the Write routines directly.  It will open the stream
	/// before the write and close right after writing and modifying the header information. <br /> <br />
	/// Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.   </remarks>
	/// <example> The example below demonstrates using this object in the basic format, without adding new styles.
	/// <code>
	/// <SPAN class="lang">[C#]</SPAN> 
	/// using System;
	/// using System.IO;
	/// using GeneralTools.Logs;
	///
	/// namespace DLC.Tools
	/// {
	///		public class LogFileXHTML_Example_1
	///		{
	///			static void Main() 
	///			{
	///				// Create a new XHTML Log File, setting the title and application at the same time
	///				LogFileXHTML myLogger = new LogFileXHTML( "c:\\example.log.html", "Log File XHTML Example", "Class Library Example" );
	///
	///				// Make sure this is a fresh log file
	///				myLogger.New();
	///
	///				// Open the file explicitly.  This will leave a connection open for 
	///				// the next few lines of processing until Close() is called.
	///				myLogger.Open();
	///
	///				// Go through and add each diretory name to this log file
	///				int files = -1, folderNumber = 1;
	///				foreach ( string thisDir in Directory.GetDirectories("C:\\") )
	///				{
	///					// Perform this in a try catch, as there may be a rights issue in system folders
	///					try
	///					{
	///						files =  Directory.GetFiles(thisDir).Length;
	///					}
	///					catch
	///					{
	///						// Set the number of files in this directoty to a default of -1
	///						files = -1;
	///					}
	///
	///					// If it could not detect the number of files, add the error
	///					if ( files == -1 )
	///						myLogger.AddError( "ERROR! Unable to determine the number of files in folder " + thisDir );
	///					else	
	///						myLogger.AddNonError( "Folder " + thisDir + " is the " + folderNumber + "th folder found had " + Directory.GetFiles(thisDir).Length + " files." );
	///		
	///					// Increment the folder number
	///					folderNumber++;
	///				}	
	///
	///				// Add a final line
	///				myLogger.AddComplete( folderNumber + " Total Folders Found and " + myLogger.ErrorCount + " Errors Found!" );
	///		
	///				// Now, close the log file connection
	///				myLogger.Close();
	///
	///				// Email the log file
	///				myLogger.MailSMTP( "Example", "marsull@mail.uflib.ufl.edu" );
	///			}
	///		}
	///	}
	/// </code> <br />
	/// Below is what the output file's text looks like.  To see it in HTML, click <a href="example.log.html">here</a>.
	/// <code>
	///	&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
	///	&lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Strict//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd&quot;&gt;
	///	&lt;html lang=&quot;en&quot; xml:lang=&quot;en&quot; xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
	///
	///	&lt;! Log file produced automatically by C# program LogFileXHTML.cs &gt;
	///	&lt;! Developed by Mark V Sullivan, November 2002 &gt;
	///
	///	&lt;head&gt;
	///	&lt;title&gt; Log File XHTML Example &lt;/title&gt;   
	///
	///	&lt;! Values used by LogFileXHTML &gt;
	///	&lt;META NAME=&quot;Next_Position&quot; CONTENT=&quot;3245&quot;&gt;       
	///	&lt;META NAME=&quot;Date_Created&quot; CONTENT=&quot;11/12/2003 8:43:45 PM-&quot;&gt;
	///	&lt;META NAME=&quot;Row_Header&quot; CONTENT=&quot;&quot;&gt;                    
	///	&lt;META NAME=&quot;Date_Stamping&quot; CONTENT=&quot;True&quot;&gt; 
	///	&lt;META NAME=&quot;Error_Count&quot; CONTENT=&quot;1&quot;&gt;   
	///	&lt;META NAME=&quot;Application&quot; CONTENT=&quot;Class Library Example&quot;&gt;         
	///
	///	&lt;! Style Sheet Definitions &gt;
	///	&lt;style type=&quot;text/css&quot;&gt;
	///		.logFileName { font-size: &quot;x-large&quot;; text-align: &quot;center&quot;; font-weight: &quot;bold&quot;; font-family: &quot;Arial&quot; }
	///		.logEntry { color: &quot;black&quot;; font-family: &quot;Arial&quot;; font-size: &quot;15&quot;; }
	///		.errorLogEntry { color: &quot;red&quot;; font-family: &quot;Arial&quot;; font-size: &quot;15&quot;; &lt;!strong&gt; }
	///		.completedLogEntry { color: &quot;blue&quot;; font-family: &quot;Arial&quot;; font-size: &quot;15&quot;; &lt;!strong&gt; }
	///	&lt;/style&gt;
	///	&lt;/head&gt;
	///
	///	&lt;body&gt;
	///
	///	&lt;div class=&quot;logFileName&quot;&gt;Log File XHTML Example&lt;/div&gt;
	///
	///	&lt;br /&gt;&lt;hr /&gt;&lt;br /&gt;
	///
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\adaptec is the 1th folder found had 1 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\ADOBEAPP is the 2th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Aerials is the 3th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\comcheck is the 4th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Content SDK is the 5th folder found had 5 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\dell is the 6th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Documents and Settings is the 7th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Inetpub is the 8th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\My Music is the 9th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\OfficeScan NT is the 10th folder found had 95 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Perl is the 11th folder found had 2 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Processing is the 12th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\Program Files is the 13th folder found had 2 files.&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\RECYCLER is the 14th folder found had 0 files.&lt;/div&gt;
	///	&lt;div class=&quot;errorLogEntry&quot;&gt; 11/12/2003 8:43:49 PM - &lt;strong&gt;ERROR! Unable to determine the number of files in folder C:\System Volume Information&lt;/strong&gt;&lt;/div&gt;
	///	&lt;div class=&quot;logEntry&quot;&gt; 11/12/2003 8:43:49 PM - Folder C:\WINNT is the 16th folder found had 159 files.&lt;/div&gt;
	///	&lt;div class=&quot;completedLogEntry&quot;&gt; 11/12/2003 8:43:49 PM - &lt;strong&gt;17 Total Folders Found and 1 Errors Found!&lt;/strong&gt;&lt;/div&gt;
	/// 
	/// &lt;br /&gt;&lt;hr /&gt;&lt;br /&gt;
	///
	/// &lt;/body&gt;
	///
	///	&lt;/html&gt;
	/// </code></example>
	public class LogFileXHTML
    {
        #region Private Class Memberd

        /// <summary> stores the name of the log file </summary>
		private string fileName;			
 
		/// <summary> stores the name of the creating application  </summary>
		private string appName;				

		/// <summary> stores the title of the log file. </summary>
		private string title;				

		/// <summary> store a string to be written after the date on each line </summary>
		private string eachRowHeader;		

		/// <summary> Stores the current number of errors in the log </summary>
		private int errorCount;				

		/// <summary> Stores the current position in the log file  </summary>
		private int currentPosition;		

		/// <summary> Flag to determine if the log stays open between writes
		/// or whether it should be closed each time. </summary>
		private bool leaveOpen;				

		/// <summary> Flag to determine if the date is stamped on every line. </summary>
		private bool dateStamping;			

		/// <summary> Date the file was created  </summary>
		private DateTime dateCreated;		

		/// <summary> FileStream object used to read and write to the 
		/// log file.  </summary>
		private FileStream logFileStream;

		/// <summary> flag indicates whether exceptions should be suppressed </summary>
		private bool suppressExceptions;

        #endregion

        #region Constants used for new XHTML log files

        /// <summary> Constant string of tags and text used to create a new header
		/// for a new log file. </summary>
		private const string CompleteNewHeader =
			"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
			"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\r\n" +
			"<html lang=\"en\" xml:lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">\r\n\r\n" +
			"<! Log file produced automatically by C# program LogFileXHTML.cs >\r\n" +
			"<! Developed by Mark V Sullivan, November 2002 >\r\n\r\n" +
            "<head>\r\n" +
			"<title>  </title>                         \r\n\r\n" +
			"<! Values used by LogFileXHTML >\r\n" +
			"<META NAME=\"Next_Position\" CONTENT=\"00\">         \r\n" +
			"<META NAME=\"Date_Created\" CONTENT=\"--/--/---- --:--:-- --\">\r\n" +
			"<META NAME=\"Row_Header\" CONTENT=\"\">                    \r\n" +
			"<META NAME=\"Date_Stamping\" CONTENT=\"TRUE\"> \r\n" +
			"<META NAME=\"Error_Count\" CONTENT=\"0\">   \r\n" +
			"<META NAME=\"Application\" CONTENT=\"\">                              \r\n\r\n" +
			"<! Style Sheet Definitions >\r\n" +
			"<style type=\"text/css\">\r\n" +
			"     .logFileName { font-size:x-large; text-align:center; font-weight:bold; font-family:Arial }\r\n" +
			"     .logEntry { color:black; font-family:Arial; font-size:15px; }\r\n" +
			"     .errorLogEntry { color:red; font-family:Arial; font-size:15px; <!strong> }\r\n" +
			"     .completedLogEntry { color:blue; font-family:Arial; font-size:15px; <!strong> }\r\n" +
			"</style>\r\n" +
			"</head>\r\n";

		/// <summary> Constant string values used to indicate necessary tags surrounding
		/// the body of the log file and the end of the log file. </summary>
		private const string NewStartBody1 = "\r\n<body>\r\n\r\n<div class=\"logFileName\">",
							 NewStartBody2 = "</div>\r\n\r\n<br /><hr /><br />\r\n\r\n",
							 NewEndTags = "\r\n<br /><hr /><br />\r\n\r\n</body>\r\n\r\n</html>";

		/// <summary> Constant position values used to place, or fetch, data into the 
		/// XHTML header of the log file. </summary>
		private const int titlePosition = 358, positionPosition = 466, createDatePosition = 516, rowHeaderPosition = 575,
            dateStampPosition = 635, errorPosition = 678, applicationPosition = 720;

        #endregion

        #region Constructors

        /// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Title - this is set to no title by default
		/// <li type="circle" /> Application Name - this is left blank by default
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileXHTML.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileXHTML(string newFileName)
		{
			setupLogFile(newFileName, newFileName, "", "", false);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Application Name - this is left blank by default
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileXHTML.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileXHTML(string newFileName, string title)
		{
			setupLogFile(newFileName, title, "", "", false);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="appName"> Name of the application </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileXHTML.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileXHTML(string newFileName, string title, string appName )
		{
			setupLogFile(newFileName, title, appName, "", false);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="appName"> Name of the application </param>
		/// <param name="rowHeader"> Header for each row </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// <li type="circle" /> Exceptions - Enabled ( can be changed by calling the <see cref="LogFileXHTML.SuppressExceptions"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created. </exception>
		public LogFileXHTML(string newFileName, string title, string appName, string rowHeader )
		{
			setupLogFile(newFileName, title, appName, rowHeader, false);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Title - this is set to no title by default
		/// <li type="circle" /> Application Name - this is left blank by default
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileXHTML(string newFileName, bool suppressExceptions )
		{
			setupLogFile(newFileName, newFileName, "", "", suppressExceptions);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Application Name - this is left blank by default
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileXHTML(string newFileName, string title, bool suppressExceptions )
		{
			setupLogFile(newFileName, title, "", "", suppressExceptions);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="appName"> Name of the application </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Row Header - Disabled ( can be enabled by calling the <see cref="LogFileXHTML.enableRowHeaders"/> method )
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileXHTML(string newFileName, string title, string appName, bool suppressExceptions )
		{
			setupLogFile(newFileName, title, appName, "", suppressExceptions);
		}

		/// <summary> Constructor which builds a new LogFileXHTML object </summary>
		/// <param name="newFileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="appName"> Name of the application </param>
		/// <param name="rowHeader"> Header for each row </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <remarks> This uses the following default values: <ul>
		/// <li type="circle" /> Date Stamping - Enabled ( can be changed by calling the <see cref="LogFileXHTML.DateStampingEnabled"/> property )
		/// </ul></remarks>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public LogFileXHTML(string newFileName, string title, string appName, string rowHeader, bool suppressExceptions )
		{
			setupLogFile(newFileName, title, appName, rowHeader, suppressExceptions);
		}


		/// <summary> Method called by the constructors to help initialize this object. </summary>
		/// <param name="fileName"> File Name and Path for this LogFileXHTML object </param>
		/// <param name="title"> Title for this log </param>
		/// <param name="appName"> Name of the application </param>
		/// <param name="rowHeader"> Header for each row </param>
		/// <param name="suppressExceptions"> Flag indicates whether to suppress exceptions </param>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown here if the directory for
		/// the log file does not exist, and can not be created, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private void setupLogFile(string fileName, string title, string appName, string rowHeader, bool suppressExceptions)
		{
			// Save the parameters
			this.suppressExceptions = suppressExceptions;
			this.fileName = fileName;
			this.title = title;
			leaveOpen = false;

			// If the app name is too long, truncate it
			if ( appName.Length > 30 )
				appName = appName.Substring(0, 30);
			this.appName = appName;

			// If there is a row header, add the " - "
			if (rowHeader != "")
				rowHeader += " - ";
			this.eachRowHeader = rowHeader;

			// If the directory for this file does not exist, create it
			try
			{
				if ( !Directory.Exists( new FileInfo(fileName).DirectoryName ) )
					Directory.CreateDirectory( new FileInfo(fileName).DirectoryName );
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to create the directory [" + new FileInfo(fileName).DirectoryName + "] in a LogFileXHTML object.");
			}

			this.DateStampingEnabled = true;
			currentPosition = 0;
        }

        #endregion

        #region Public Properties

		/// <summary> Gets and Sets the flag which indicates if all <see cref="LogFile_Exception"/>s should be
		/// suppressed or not.  </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool SuppressExceptions
		{
			get	{	return suppressExceptions;	}
			set	{	suppressExceptions = value;	}
		}

		/// <summary> Returns true if the log file is currently open. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool isOpen
		{
			get	{	return leaveOpen;	}
		}

		/// <summary> Gets and sets the flag which indicates if each line receives a date stamp. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool DateStampingEnabled
		{
			get	{	return dateStamping;	}
			set	{	dateStamping = value;	}
		}

		/// <summary> Gets the date and time the current log file was created. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public DateTime DateCreated
		{
			get	{	return dateCreated;	}
		}

		/// <summary> Gets the number of explicit calls to <see cref="LogFileXHTML.AddError"/> method were made. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public int ErrorCount
		{
			get	{	return errorCount;	}
        }

        #endregion

        #region Public Methods

        /// <summary>  Deletes the current log file, closing first if necessary. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// during processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public bool New()
		{
			currentPosition = 0;

			if (leaveOpen)
				closeConnection();

            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch { }

			dateCreated = DateTime.Now;
			errorCount = 0;

			if (leaveOpen)
				return(openConnection());
			else
				return true;
		}

		/// <summary> Returns true if the log file currently exists. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool Exists()
		{
			return File.Exists(fileName);
		}

		/// <summary> Opens or creates a log file. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <remarks>  This also specifies that the connection to the file will 
		/// remain open until <see cref="LogFileXHTML.Close"/> is called. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// opening the connection, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public bool Open()
		{
			// Set leave open and try to open the connection
			leaveOpen = true;
			return openConnection();
		}

		/// <summary> Saves and closes the log file. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// closing the connection, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public bool Close()
		{
			if ( leaveOpen )
			{
				leaveOpen = false;
				return closeConnection();
			}

			return false;
		}

		/// <summary> Disable the additional information between the time/date and the log entry. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public void disableRowHeaders()
		{
			eachRowHeader = "";
		}

		/// <summary> Enables the additional information between the time/date and
		/// the log entry and sets this information to the string which is passed in. </summary>
		/// <param name="textForEachLine"> Text to be used as the Row Headers on each row </param>
		/// <returns> TRUE if the requested row header is accepted, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool enableRowHeaders(string textForEachLine)
		{
			eachRowHeader = textForEachLine;
			return true;
		}

		/// <summary> Adds a non-error line to the current log file. </summary>
		/// <param name="msg"> Message to add </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <remarks> This uses the default style defined as 'logEntry' with the following attributes: <ul>
		/// <li type="circle" /> Color:		Black
		/// <li type="circle" /> Font-Size: 15
		/// <li type="circle" /> Bold:		false
		/// <li type="circle" /> Italics:	false
		/// </ul></remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool AddNonError(string msg)
		{
			return Write(msg, "logEntry", false);
		}

		/// <summary> Adds an error line to the current log file.  </summary>
		/// <param name="msg"> Message to add </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <remarks> This uses the default style defined as 'errorLogEntry' with the following attributes: <ul>
		/// <li type="circle" /> Color:		Red
		/// <li type="circle" /> Font-Size: 15
		/// <li type="circle" /> Bold:		true
		/// <li type="circle" /> Italics:	false
		/// </ul></remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool AddError(string msg)
		{
			Write(msg, "errorLogEntry", true);

			if (!leaveOpen)
				openConnection();

			errorCount++;
            
			if (!leaveOpen)
				closeConnection();

			return true;
		}

		/// <summary> Adds a line indicating completeness to the log file. </summary>
		/// <param name="msg"> Msg to add indicating completeness </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <remarks> This uses the default style defined as 'completedLogEntry' with the following attributes: <ul>
		/// <li type="circle" /> Color:		Blue
		/// <li type="circle" /> Font-Size: 15
		/// <li type="circle" /> Bold:		true
		/// <li type="circle" /> Italics:	false
		/// </ul></remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		public bool AddComplete(string msg)
		{
			return Write(msg, "completedLogEntry", true);
		}

		/// <summary> Send the log file via SMTP POP mail. </summary>
		/// <param name="processName"> Process name for the subject line of the email </param>
		/// <param name="emailTo"> Email addresses ( seperated by ';' ) </param>
		/// <returns>TRUE if successful, otherwise FALSE </returns>
		/// <remarks> For this email to be sent the local machine must be running the SMTP service
		/// under IIS. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while attempting to send the logfile as a SMTP email, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public bool MailSMTP( string processName, string emailTo )
		{
			// Close the other connection to this file
			if (leaveOpen)
				closeConnection();

			try
			{
				// Create the new mail message object
				MailMessage mail = new MailMessage();

				// Define who this email should be from and to
				mail.From = "AutomaticLogDelivery@mail.edu";
				mail.To = emailTo;

				// Set the subject line to reflect the process name and error count
				if ( errorCount > 0 )
					mail.Subject = processName + " completed with " + errorCount + " errors.";
				else
					mail.Subject = processName + " completed with no errors.";

				// Set the body of the email to be HTML and the body of the log file
				mail.BodyFormat = System.Web.Mail.MailFormat.Html;
				mail.Body = TextOfLogFile();

				// Define the SMTP server and send this email
				SmtpMail.SmtpServer = "mail.uflib.ufl.edu";
				SmtpMail.Send(mail);
			}
			catch (Exception ee)
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to email the log file " + this.fileName + " to " + emailTo + " due to SMTP error. \n\n" + ee.ToString());
				return false;
			}

			if ( leaveOpen )
				openConnection();
			
			// No error, so return true;
			return true;
		}

		/// <summary> Displays the XHTML log file in Internet Explorer. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="LogFileXHTML"/> class. </example>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while trying to display the log, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		public bool Display()
		{
			// Now, display the local log file copy with IEXPLORE.exe
			try
			{
				Process toRun = new Process();
				ProcessStartInfo psI = new ProcessStartInfo( "C:\\Program Files\\Internet Explorer\\IEXPLORE.exe" );
				psI.UseShellExecute = false;
				psI.Arguments = "\"" + fileName + "\"";
				psI.RedirectStandardInput = true;
				psI.RedirectStandardOutput = false;
				psI.RedirectStandardError = false;
				psI.CreateNoWindow = false;
				toRun.StartInfo = psI;
				toRun.Start();
				return true;
			}
			catch 
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to display the log file " + this.fileName + "." );
				return false;
			}
        }

        #endregion

        #region Private Methods

		/// <summary> Returns the text of this file as a string. </summary>
		/// <returns> Text of this file as a string </returns>
		private string TextOfLogFile()
		{
			//Read from file
			StreamReader sr = new StreamReader( fileName );

			//Single line from fileIO.txt 
			String strLine;

			// Object used to add each line
			StringBuilder entireFile = new StringBuilder();

			//Continues to output one line at a time until end of file(EOF) is reached
			while ( (strLine = sr.ReadLine()) != null)
				entireFile.Append( strLine + "\n" );

			//Cleanup
			sr.Close();

			// Return the stringBuilder as a string
			return entireFile.ToString();
		}

		/// <summary> Writes a string to the log file. </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool Write(string msg, string styleType, bool strong )
		{
			bool noError = true;

			if (!leaveOpen)
				noError = openConnection();

			try
			{
				if (noError)
				{
					string configuredMsg = configureText(msg, styleType, strong);
					writeToLog(configuredMsg);
					writeClosingTags();
				}
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to write to the log file " + this.fileName + "." );
				noError = false;
			}

			if (!leaveOpen && noError)
				noError = closeConnection();

			return noError;
		}

		/// <summary> Private method writes closing tags to the file. </summary>
		private void writeClosingTags()
		{
			writeAtPos(currentPosition, NewEndTags);
		}

		/// <summary> Opens the connection and returns true
		/// or false.  Called by public method Open().  False is returned
		/// if the header in the log file is corrupted.
		/// </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool openConnection()
		{
			try
			{	// try to open an existing file
				logFileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
				return readHeader();
			}
			catch
			{
				try
				{	// try to create a new file since it was unable to open the existing
					logFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    dateCreated = DateTime.Now;
					createHeader();
					writeClosingTags();
					return true;
				}
				catch
				{	// unable to either open or create the log file
					if ( !suppressExceptions )
						throw new LogFile_Exception("Unable to open the connection to the log file " + this.fileName + "." );
					return false;
				}
			}
		}

		/// <summary>  Creates the header for a new log file  </summary>
		/// <returns> TRUE if sucessful, otherwise FALSE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool createHeader()
		{	
			try
			{
				// Create the header with references, style sheet, etc...
				// Also, create the beginning of the body with the title to display
				writeToLog(CompleteNewHeader + NewStartBody1 + title +  NewStartBody2 );

				// Insert the title into the header
				if ( title.Length > 25 )
					writeAtPos( titlePosition, title.Substring(0,25) + " </title>");			
				else
					writeAtPos( titlePosition, title + " </title>");

				// Insert the other META data into the header
				writeAtPos( createDatePosition, dateCreated.ToString() );
				writeAtPos( rowHeaderPosition, eachRowHeader + "\">" );
				writeAtPos( dateStampPosition, dateStamping.ToString() + "\">" );
				writeAtPos( applicationPosition, appName + "\">" );

				// Write the current position into the header
				saveCurrentPosition( );

				return true;
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to create the XHTML header for the log file " + this.fileName + "." );
				return false;
			}
		}

		/// <summary> Saves the current position into the XHTML header </summary>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private void saveCurrentPosition( )
		{
			writeAtPos( positionPosition, currentPosition + "\">" );
		}

		/// <summary> Saves the number of current errors into the XHTML header </summary>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private void saveErrorCount( )
		{
			writeAtPos( errorPosition, errorCount + "\">" );
		}

		/// <summary>  Writes at a certain position in the log File </summary>
		/// <param name="newPosition"> Position to write at </param>
		/// <param name="msg"> Message to write </param>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private void writeAtPos( int newPosition, string msg )
		{
			int nextPosition = currentPosition;
			currentPosition = newPosition;
			writeToLog(msg);
			currentPosition = nextPosition;
		}
	
		/// <summary> Reads the header information </summary>
		/// <returns> FALSE if it was corrupted </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool readHeader()
		{
			try
			{
				StringBuilder tempRead = new StringBuilder("          ");

				// Input all of the information in the header
				while (! tempRead.ToString().Substring(tempRead.Length-8, 7).Equals("</head>"))
					tempRead.Append(System.Convert.ToChar(logFileStream.ReadByte()));

				// Remove spacer used at beginning of tempRead initially
				tempRead.Remove(0, 10);

				// Populate the variables with the provided information
				string tempReadString = tempRead.ToString();
				currentPosition = Convert.ToInt32(tempReadString.Substring(positionPosition, 11).Split('\"')[0]);
                string dateString = tempReadString.Substring(createDatePosition, 23);
                dateString = dateString.Split('\"')[0].Replace("-","").Trim();
                dateCreated = Convert.ToDateTime(dateString);
				eachRowHeader = tempReadString.Substring(rowHeaderPosition, 23).Split('\"')[0];
				dateStamping = Convert.ToBoolean(tempReadString.Substring(dateStampPosition, 6).Split('\"')[0]);
				errorCount = Convert.ToInt32(tempReadString.Substring(errorPosition, 8).Split('\"')[0]);
				return true;
			}
			catch (Exception ee)
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to read the XHTML header of the log file " + this.fileName + "." );
				return false;
			}
		}

		/// <summary>  Take a basic line to go into the log and append the date or rowHeader
		/// as necessary.  Also, breaks up the message if it exceeds the line length
		/// for the log file. </summary>
		/// <param name="origMsg"> Original message </param>
		/// <param name="styleType"> StyleType name to use </param>
		/// <param name="strong"> Tells whether this is strong or not </param>
		/// <returns> The configured line </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private string configureText(string origMsg, string styleType, bool strong )
		{
			// Declare the new stringBuilder and set to the original message
			StringBuilder lineBuilder = new StringBuilder(origMsg);

			// If this text should be strong add the strong tags
			if ( strong )
			{
				lineBuilder.Insert(0, "<strong>");
				lineBuilder.Append("</strong>");
			}

			// Insert any rowHeader and the date Stamping as applicable
			lineBuilder.Insert(0, eachRowHeader);
			if (dateStamping)
				lineBuilder.Insert(0, DateTime.Now.ToString() + " - ");

			// Finally, insert the <div> tags
			lineBuilder.Insert(0,"<div class=\"" + styleType + "\"> ");
			lineBuilder.Append("</div>\r\n");

			return lineBuilder.ToString();
		}

		/// <summary> Writes a fully configured and correct length line into the file
		/// and inserts the carriage return and linefeed. </summary>
		/// <param name="msg"> Message to write </param>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool writeToLog(string msg)
		{
			int character;
			try
			{
				logFileStream.Position = currentPosition;
				for ( character = 0 ; character < msg.Length ; ++character )
					logFileStream.WriteByte(System.Convert.ToByte(msg[character]));
				currentPosition += msg.Length;
				return true;
			}
			catch
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to write to the log file " + this.fileName + "." );
				return false;
			}
		}

		/// <summary>  Saves and closes the log file </summary>
		/// <returns> TRUE if successful, otherwise FALSE </returns>
		/// <exception cref="LogFile_Exception"> A <see cref="LogFile_Exception"/> will be thrown if there is an error
		/// while processing, unless the <see cref="LogFileXHTML.SuppressExceptions"/> flag is set to true. </exception>
		private bool closeConnection()
		{
			try
			{
				saveCurrentPosition();
				saveErrorCount();
				logFileStream.Close();
				return true;
			}
			catch ( Exception ee )
			{
				if ( !suppressExceptions )
					throw new LogFile_Exception("Unable to close the connection to the log file " + this.fileName + ". \n\n" + ee.ToString() );
				return false;
			}
        }

        #endregion
    }
}
