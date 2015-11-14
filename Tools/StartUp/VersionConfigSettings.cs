using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;

namespace DLC.Tools.StartUp
{
	/// <summary> Reads the VersionConfiguration section of the .exe.config file <br /> <br /> </summary>
	/// <remarks>  This static class is part of the general <see cref="VersionChecker"/> solution.  This keeps
	/// local installatins of an application current, by checking a network XML versioning database upon
	/// startup to determine if the application needs to be updated. <br /> <br />
	/// To use this class, a custom versioning section (shown below) must exist in the Application Config file.  An example
	/// file is <a href="example.exe.config.html">here</a>, and below are just the sections needed.  This section must include 
	/// information on where the XML versioning database sits, as well as the application name and current version.
	/// <code>
	///	&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
	///	&lt;configuration&gt;
	///
	///		&lt;!-- Define a custom section for VersionChecking                            --&gt;
	///		&lt;configSections&gt;
	///			&lt;section name=&quot;VersionChecker&quot;  type=&quot;System.Configuration.NameValueSectionHandler&quot; /&gt;
	///		&lt;/configSections&gt;
	///   
	///		&lt;!-- Below is information to allow for VersionChecking prior to execution.  --&gt;
	///		&lt;!-- XML_Directory holds all the centralized version information and then   --&gt;
	///		&lt;!-- the AppName and Version allow for checking this particular app.        --&gt;
	///		&lt;VersionChecker&gt;
	///			&lt;add key=&quot;XML_Directory&quot; value=&quot;\\Smathersnt12\DLCdocs\ScanQC\People\Mark\Applications\Versioning&quot; /&gt;
	///			&lt;add key=&quot;AppName&quot; value=&quot;Aerial Image Collector&quot; /&gt;
	///			&lt;add key=&quot;Version&quot; value=&quot;2.1.0&quot; /&gt;
	///		&lt;/VersionChecker&gt;
	///   
	///	&lt;/configuration&gt; 
	/// </code>
	/// <br /> Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center. </remarks>
	public class VersionConfigSettings
	{

		/// <summary> Emptry constructor for this class.  </summary>
		static VersionConfigSettings()		{	}
		
		/// <summary> Gets the local file source from the Version Config Setting portion of the Application
		/// settings file. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="VersionChecker"/> class
		/// as well as the main <see cref="VersionConfigSettings"/> class. </example>
		public static string localFileSource
		{
			get {return ConfigurationSettings.AppSettings["LocalFileSourceString"]; }
		}

		/// <summary> Gets the directory where the XML file holding all of the versioning
		/// information is located. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="VersionChecker"/> class
		/// as well as the main <see cref="VersionConfigSettings"/> class. </example>
		public static string VersionCheckingXML
		{
			get	
			{
				NameValueCollection sampleTable = (NameValueCollection) ConfigurationSettings.GetConfig("VersionChecker");
				return (string)sampleTable["XML_Directory"];
			}
		}

		/// <summary> Gets the name of the application to look for in the XML Versioning database. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="VersionChecker"/> class
		/// as well as the main <see cref="VersionConfigSettings"/> class. </example>
		public static string AppName
		{
			get	
			{
				NameValueCollection sampleTable = (NameValueCollection) ConfigurationSettings.GetConfig("VersionChecker");
				return (string)sampleTable["AppName"];
			}
		}

		/// <summary> Gets the version number of this application to look for in the XML Versioning database. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="VersionChecker"/> class
		/// as well as the main <see cref="VersionConfigSettings"/> class. </example>
		public static string AppVersion
		{
			get	
			{
				NameValueCollection sampleTable = (NameValueCollection) ConfigurationSettings.GetConfig("VersionChecker");
				return (string)sampleTable["Version"];
			}
		}
	}
}
