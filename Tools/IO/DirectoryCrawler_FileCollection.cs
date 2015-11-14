using System;
using System.Collections;

namespace DLC.Tools.IO
{
	/// <summary> DirectoryCrawler_FileCollection is a collection of <see cref="DirectoryCrawler_File"/> objects which 
	/// store all the files which were found while iterating through a directory with a <see cref="DirectoryCrawler"/> class.
	///  <br /><br /> </summary>
	/// <remarks> This class extends the <see cref="CollectionBase"/> abstract class and implements the 
	/// <see cref="IEnumerable"/> interface. <br /> <br /> 
	/// This class is instantiated by calling the <see cref="DirectoryCrawler.Files"/> method from a
	/// <see cref="DirectoryCrawler"/> object. The user should not directly instantiate this class. <br /> 
	/// <br />
	/// Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.  </remarks>
	/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
	public class DirectoryCrawler_FileCollection : CollectionBase, IEnumerable
	{
		/// <summary> Constructor for a new DirectoryCrawler_FileCollection object. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler_FileCollection() : base()
		{
			// Empty Constructor
		}		
		
		/// <summary> Address a single file from this Collection, by index. </summary>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public DirectoryCrawler_File this[int Index]
		{
			get	
			{	
				// Check that this index is in bound
				if ( Index >= List.Count  )
					return null;

				return ((DirectoryCrawler_File) (List[Index]));	
			}
			set	{	List[Index] = value;	}
		}

		/// <summary> Add a new file to this collection. </summary>
		/// <param name="NewFile"> <see cref="DirectoryCrawler_File"/> object for this new file </param>
		/// <returns> The index for this new included File </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public int Add( DirectoryCrawler_File NewFile )
		{
			// Add this file to the collection's list
			int returnVal = List.Add( NewFile );

			// Return the index which was retrieved when this file was added
			return returnVal;
		}

		/// <summary> Add a new file to this collection. </summary>
		/// <param name="Name"> Name of the file (minus extension and path) </param>
		/// <param name="Extension"> Extension for this file </param>
		/// <param name="Directory"> Directory for this file </param>
		/// <param name="Size"> Size of this file in KB </param>
		/// <param name="DateCreated"> Date and time this file was originally created </param>
		/// <param name="DateModified"> Date and time this file was last modified </param>
		/// <param name="UserDefined"> User defined value, to indicate which search was used to find this file </param>
		/// <returns> The index for this new Included File </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		/// <remarks> Since to UserObject is included here, it is set to null </remarks>
		public int Add( string Name, string Extension, string Directory, double Size, DateTime DateCreated, DateTime DateModified, string UserDefined )
		{
			// Create the new DirectoryCrawler_File and add it to the collection's list
			return Add( new DirectoryCrawler_File( Name, Extension, Directory, Size, DateCreated, DateModified, UserDefined ) );
		}

		/// <summary> Add a new file to this collection. </summary>
		/// <param name="Name"> Name of the file (minus extension and path) </param>
		/// <param name="Extension"> Extension for this file </param>
		/// <param name="Directory"> Directory for this file </param>
		/// <param name="Size"> Size of this file in KB </param>
		/// <param name="DateCreated"> Date and time this file was originally created </param>
		/// <param name="DateModified"> Date and time this file was last modified </param>
		/// <param name="UserDefined"> User defined value, to indicate which search was used to find this file </param>
		/// <param name="UserObject"> Object included by the user before iterating through the directory this was found in </param>
		/// <returns> The index for this new Included File </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public int Add( string Name, string Extension, string Directory, double Size, DateTime DateCreated, DateTime DateModified, string UserDefined, object UserObject )
		{
			// Create the new DirectoryCrawler_File and add it to the collection's list
			return Add( new DirectoryCrawler_File( Name, Extension, Directory, Size, DateCreated, DateModified, UserDefined, UserObject ) );
		}

		/// <summary> Remove an existing file from this collection. </summary>
		/// <param name="FileToRemove"> Included File to remove from this collection. </param>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public void Remove( DirectoryCrawler_File FileToRemove )
		{
			// Check to see if this exists in the List
			if ( Contains( FileToRemove ) )
			{
				// It existed, so remove it.
				List.Remove( FileToRemove );
			}
		}

		/// <summary> Check to see if an included file object currently exists in this collection.  </summary>
		/// <param name="FileToCheck"> File to check for existence in this collection. </param>
		/// <returns>TRUE if the provided included file object is already part of this Collection </returns>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public bool Contains( DirectoryCrawler_File FileToCheck )
		{
			return List.Contains( FileToCheck );
		}

		/// <summary> Return an enumerator to step through this collection of files. </summary>
		/// <returns> A Type-Safe DirectoryCrawler_FileEnumerator</returns>
		/// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public new DirectoryCrawler_FileEnumerator GetEnumerator()
		{
			return new DirectoryCrawler_FileEnumerator(this);
		}

		/// <summary> Return an enumerator to step through this collection of included files. </summary>
		/// <returns> A IEnumerator object to step through this collection of included files. </returns>
		/// <remarks> Explicit interface implementation to support interoperability with other common 
		/// language runtime-compatible langueages. </remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		IEnumerator IEnumerable.GetEnumerator()
		{	
			return (IEnumerator) new DirectoryCrawler_FileEnumerator(this);
		}

		/// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
		/// the collection of included files in this <see cref="DirectoryCrawler_FileCollection"/>. <br /> <br /> </summary>
		/// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
		/// iterate through all of the <see cref="DirectoryCrawler_File"/> objects in the 
		/// <see cref="DirectoryCrawler_FileCollection"/> object. The example in the <see cref="DirectoryCrawler_FileCollection"/>
		/// demonstrates this use.</remarks>
		/// <example> To see examples, look at the examples listed under the main <see cref="DirectoryCrawler"/> class. </example>
		public class DirectoryCrawler_FileEnumerator : IEnumerator
		{
			/// <summary> Stores the current position within the collection. </summary>
			private int position = -1;

			/// <summary> Reference to the <see cref="DirectoryCrawler_FileCollection"/> to iterate through. </summary>
			private DirectoryCrawler_FileCollection includedFiles;

			/// <summary> Constructore creates a new DirectoryCrawler_FileEnumerator to iterate through
			/// the DirectoryCrawler_FileCollection. </summary>
			/// <param name="includedFileCollection"> <see cref="DirectoryCrawler_FileCollection"/> to iterate through </param>
			public DirectoryCrawler_FileEnumerator( DirectoryCrawler_FileCollection includedFileCollection )
			{
				includedFiles = includedFileCollection;
			}

			/// <summary> Move to the next included file in this collection. </summary>
			/// <returns> TRUE if successful, otherwise FALSE </returns>
			/// <remarks> Method is required by the <see cref="IEnumerator"/> interface. </remarks>
			public bool MoveNext()
			{
				if ( position < ( includedFiles.Count - 1 ))
				{
					position++;
					return true;
				}
				else
				{
					return false;
				}
			}

			/// <summary> Reset to the position just before the first position.  
			/// Ready for the MoveNext() method to be called. </summary>
			/// <remarks> Method is required by the <see cref="IEnumerator"/> interface. </remarks>
			public void Reset()
			{
				position = -1;
			}

			/// <summary> Return the current included File from the <see cref="DirectoryCrawler_FileCollection"/> </summary>
			/// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
			public DirectoryCrawler_File Current
			{
				get
				{
					return includedFiles[position];
				}
			}

			/// <summary> Return the current Included File from the <see cref="DirectoryCrawler_FileCollection"/> </summary>
			/// <remarks> Explicit interface implementation to support interoperability with other common 
			/// language runtime-compatible langueages. </remarks>
			object IEnumerator.Current
			{
				get
				{	
					return includedFiles[position];
				}
			}
		}
	}
}