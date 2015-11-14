using System;

namespace DLC.Tools.IO
{
	/// <summary> DirectoryCrawler_File is a read-only object which houses the basic information collected about
	/// each file from a <see cref="DirectoryCrawler"/> object.  <br /> <br /> </summary>
	/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
	public class DirectoryCrawler_File
	{
		/// <summary> Name of the file (minus extension and path) </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly string Name;

		/// <summary> Extension for this file  </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly string Extension;

		/// <summary> Directory for this file </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly string Directory;

		/// <summary> Size of this file in KB </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly double Size;

		/// <summary> Date and time this file was originally created </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly DateTime DateCreated;

		/// <summary> Name of the file (minus extension and path) </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly DateTime DateModified;

		/// <summary> User defined value, to indicate which search was used to find this file </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public readonly string UserDefined;

		/// <summary> User defined object which can be included while iterating through directories. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		/// <remarks> This will return null if no UserObject was added initially. </remarks>
		public readonly object UserObject;
		
		/// <summary> Constructor for a new DirectoryCrawler_File object defines all values </summary>
		/// <param name="Name"> Name of the file (minus extension and path) </param>
		/// <param name="Extension"> Extension for this file </param>
		/// <param name="Directory"> Directory for this file </param>
		/// <param name="Size"> Size of this file in KB </param>
		/// <param name="DateCreated"> Date and time this file was originally created </param>
		/// <param name="DateModified"> Date and time this file was last modified </param>
		/// <param name="UserDefined"> User defined value, to indicate which search was used to find this file </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		/// <remarks> Since to UserObject is included here, it is set to null </remarks>
		public DirectoryCrawler_File( string Name, string Extension, string Directory, double Size, DateTime DateCreated, DateTime DateModified, string UserDefined )
		{
			// Save all of the parameters
			this.Name = Name;
			this.Extension = Extension;
			this.Directory = Directory;
			this.DateCreated = DateCreated;
			this.DateModified = DateModified;
			this.Size = Size;
			this.UserDefined = UserDefined;

			// Since no user object was included, set it to null
			UserObject = null;
		}

		/// <summary> Constructor for a new DirectoryCrawler_File object defines all values </summary>
		/// <param name="Name"> Name of the file (minus extension and path) </param>
		/// <param name="Extension"> Extension for this file </param>
		/// <param name="Directory"> Directory for this file </param>
		/// <param name="Size"> Size of this file in KB </param>
		/// <param name="DateCreated"> Date and time this file was originally created </param>
		/// <param name="DateModified"> Date and time this file was last modified </param>
		/// <param name="UserDefined"> User defined value, to indicate which search was used to find this file </param>
		/// <param name="UserObject"> Object included by the user before iterating through the directory this was found in </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler_File( string Name, string Extension, string Directory, double Size, DateTime DateCreated, DateTime DateModified, string UserDefined, object UserObject )
		{
			// Save all of the parameters
			this.Name = Name;
			this.Extension = Extension;
			this.Directory = Directory;
			this.DateCreated = DateCreated;
			this.DateModified = DateModified;
			this.Size = Size;
			this.UserDefined = UserDefined;
			this.UserObject = UserObject;
		}

		/// <summary> Returns this object as a complete path and name string </summary>
		/// <returns> Complete path, name, and extension </returns>
		public override string ToString()
		{
			return Directory + "\\" + Name + "." + Extension;
		}
	}
}
