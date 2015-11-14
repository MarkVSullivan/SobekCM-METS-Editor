using System;
using System.Data;
using System.Collections;

namespace DLC.Tools.IO
{
	/// <summary>  collection of <see cref="myDriveInfo"/> objects for a bib id. This is used to 
	/// iterate through, add, remove, and confirm the existence of drives within this collection. <br /> <br /></summary>
	/// <remarks> Written by Mark Sullivan (2005) </remarks>
	public class myDriveInfo_Collection : CollectionBase, IEnumerable
	{
		/// <summary> Constructor for the myDriveInfo_Collection object. </summary>
		public myDriveInfo_Collection() : base()
		{
			// Empty Constructor
		}

		/// <summary> Address a single drive from this Collection, by index. </summary>
		public myDriveInfo this[int Index]
		{
			get	
			{	
				// Check that this is a valid index
				if ( Index >= List.Count )
					throw new Exception("Index out of bounds while requesting myDriveInfo #" + Index + " from a myDriveInfo_Collection.");

				// Return the reqeuested, valid item
				return ((myDriveInfo) (List[Index]));	
			}
			set	{	List[Index] = value;	}
		}


		/// <summary> Add a new myDriveInfo to this collection. </summary>
		/// <param name="myDriveInfo"> myDriveInfo object for this new myDriveInfo </param>
		/// <returns> The index for this new Divsion </returns>
		public int Add( myDriveInfo myDriveInfo )
		{
			// Add hit myDriveInfo to the list and keep the index
			int returnVal = List.Add( myDriveInfo );

			// Return the index
			return returnVal;
		}

		/// <summary> Insert a new myDriveInfo into a specified index in this collection.  </summary>
		/// <param name="Index"> Index specifying location to insert new myDriveInfo </param>
		/// <param name="myDriveInfo"> myDriveInfo object for this new myDriveInfo </param>
		/// <exception cref="Exception"> Throws an <see cref="Exception"/> if there is 
		/// an index out of bounds error. </exception>
		internal void Insert( int Index, myDriveInfo myDriveInfo )
		{
			// Check that this is a valid index
			if ( Index >= List.Count )
				throw new Exception("Index out of bounds during insert of new myDriveInfo in a myDriveInfo_Collection.");

			// Complete the insert
			List.Insert( Index, myDriveInfo );
		}

		/// <summary> Remove an existing myDriveInfo from this collection. </summary>
		/// <param name="Index"> Index of the item to remove. </param>
		/// <exception cref="Exception"> Throws a <see cref="Exception"/> if there is 
		/// an index out of bounds error. </exception>
		internal new void RemoveAt( int Index )
		{
			// Check that this is a valid index
			if ( Index >= List.Count )
				throw new Exception("Index out of bounds during removal of myDriveInfo by index in a myDriveInfo_Collection.");

			// Complete the insert
			List.RemoveAt( Index );
		}

		/// <summary> Remove an existing myDriveInfo from this collection. </summary>
		/// <param name="myDriveInfo"> myDriveInfo to remove from this collection. </param>
		/// <exception cref="Exception"> Throws a <see cref="Exception"/> if the specified
		/// <see cref="myDriveInfo"/> object to remove is not in this collection. </exception>
		internal void Remove( myDriveInfo myDriveInfo )
		{
			// Check to see if this myDriveInfo exists in this collection
			if ( !Contains(myDriveInfo) )
				throw new Exception("The specified myDriveInfo does not exist in this collection.");

			// Remove the myDriveInfo which does exist
			List.Remove( myDriveInfo );
		}

		/// <summary> Check to see if a myDriveInfo currently exists in this collection.  </summary>
		/// <param name="myDriveInfo"> myDriveInfo to check for existence in this collection. </param>
		/// <returns>TRUE if the provided myDriveInfo is already part of this myDriveInfo Collection </returns>
		internal bool Contains( myDriveInfo myDriveInfo )
		{
			return List.Contains( myDriveInfo );
		}

		/// <summary> Return an enumerator to step through this collection of myDriveInfos. </summary>
		/// <returns> A Type-Safe myDriveInfoEnumerator</returns>
		/// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
		public new myDriveInfoEnumerator GetEnumerator()
		{
			return new myDriveInfoEnumerator(this);
		}

		/// <summary> Return an enumerator to step through this collection of myDriveInfos. </summary>
		/// <returns> A IEnumerator object to step through this collection of myDriveInfos. </returns>
		/// <remarks> Explicit interface implementation to support interoperability with other common 
		/// language runtime-compatible langueages. </remarks>
		IEnumerator IEnumerable.GetEnumerator()
		{	
			return (IEnumerator) new myDriveInfoEnumerator(this);
		}

		/// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
		/// the <see cref="myDriveInfo_Collection"/> in this collection. <br /> <br /> </summary>
		/// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
		/// iterate through all of the <see cref="myDriveInfo"/> objects in the 
		/// <see cref="myDriveInfo_Collection"/> object. </remarks>
		public class myDriveInfoEnumerator : IEnumerator
		{
			/// <summary> Stores the current position within the <see cref="myDriveInfo_Collection"/>. </summary>
			private int position = -1;

			/// <summary> Reference to the <see cref="myDriveInfo_Collection"/> to iterate through. </summary>
			private myDriveInfo_Collection myDriveInfos;

			/// <summary> Constructore creates a new myDriveInfoEnumerator to iterate through
			/// the <see cref="myDriveInfo_Collection"/>. </summary>
			/// <param name="myDriveInfo_Collection"> <see cref="myDriveInfo_Collection"/> to iterate through </param>
			public myDriveInfoEnumerator( myDriveInfo_Collection myDriveInfo_Collection )
			{
				myDriveInfos = myDriveInfo_Collection;
			}

			/// <summary> Move to the next <see cref="myDriveInfo"/> in this <see cref="myDriveInfo_Collection"/>. </summary>
			/// <returns> TRUE if successful, otherwise FALSE </returns>
			/// <remarks> Method is required by the IEnumerator interface. </remarks>
			public bool MoveNext()
			{
				if ( position < ( myDriveInfos.Count - 1 ))
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
			/// <remarks> Method is required by the IEnumerator interface. </remarks>
			public void Reset()
			{
				position = -1;
			}

			/// <summary> Return the current <see cref="myDriveInfo"/> from the <see cref="myDriveInfo_Collection"/>. </summary>
			/// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
			public myDriveInfo Current
			{
				get
				{
					return myDriveInfos[position];
				}
			}

			/// <summary> Return the current object from the <see cref="myDriveInfo_Collection"/>. </summary>
			/// <remarks> Explicit interface implementation to support interoperability with other common 
			/// language runtime-compatible langueages. </remarks>
			object IEnumerator.Current
			{
				get
				{	
					return myDriveInfos[position];
				}
			}
		}
	}
}
