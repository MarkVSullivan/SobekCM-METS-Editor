using System;
using System.Data;
using System.Collections;

namespace DLC.Tools.IO
{
	/// <summary>  collection of <see cref="Volume_Folder_Info"/> objects for a bib id. This is used to 
	/// iterate through, add, remove, and confirm the existence of drives within this collection. <br /> <br /></summary>
	/// <remarks> Written by Mark Sullivan (2005) </remarks>
	public class Volume_Folder_Info_Collection : CollectionBase, IEnumerable
	{
		/// <summary> Constructor for the Volume_Folder_Info_Collection object. </summary>
		public Volume_Folder_Info_Collection() : base()
		{
			// Empty Constructor
		}

		/// <summary> Address a single folder from this Collection, by index. </summary>
		public Volume_Folder_Info this[int Index]
		{
			get	
			{	
				// Check that this is a valid index
				if ( Index >= List.Count )
					throw new Exception("Index out of bounds while requesting Volume_Folder_Info #" + Index + " from a Volume_Folder_Info_Collection.");

				// Return the reqeuested, valid item
				return ((Volume_Folder_Info) (List[Index]));	
			}
			set	{	List[Index] = value;	}
		}


		/// <summary> Add a new Volume_Folder_Info to this collection. </summary>
		/// <param name="Volume_Folder_Info"> Volume_Folder_Info object for this new Volume_Folder_Info </param>
		/// <returns> The index for this new Divsion </returns>
		public int Add( Volume_Folder_Info Volume_Folder_Info )
		{
			// Add hit Volume_Folder_Info to the list and keep the index
			int returnVal = List.Add( Volume_Folder_Info );

			// Return the index
			return returnVal;
		}

		/// <summary> Insert a new Volume_Folder_Info into a specified index in this collection.  </summary>
		/// <param name="Index"> Index specifying location to insert new Volume_Folder_Info </param>
		/// <param name="Volume_Folder_Info"> Volume_Folder_Info object for this new Volume_Folder_Info </param>
		/// <exception cref="Exception"> Throws an <see cref="Exception"/> if there is 
		/// an index out of bounds error. </exception>
		internal void Insert( int Index, Volume_Folder_Info Volume_Folder_Info )
		{
			// Check that this is a valid index
			if ( Index >= List.Count )
				throw new Exception("Index out of bounds during insert of new Volume_Folder_Info in a Volume_Folder_Info_Collection.");

			// Complete the insert
			List.Insert( Index, Volume_Folder_Info );
		}

		/// <summary> Remove an existing Volume_Folder_Info from this collection. </summary>
		/// <param name="Index"> Index of the item to remove. </param>
		/// <exception cref="Exception"> Throws a <see cref="Exception"/> if there is 
		/// an index out of bounds error. </exception>
		internal new void RemoveAt( int Index )
		{
			// Check that this is a valid index
			if ( Index >= List.Count )
				throw new Exception("Index out of bounds during removal of Volume_Folder_Info by index in a Volume_Folder_Info_Collection.");

			// Complete the insert
			List.RemoveAt( Index );
		}

		/// <summary> Remove an existing Volume_Folder_Info from this collection. </summary>
		/// <param name="Volume_Folder_Info"> Volume_Folder_Info to remove from this collection. </param>
		/// <exception cref="Exception"> Throws a <see cref="Exception"/> if the specified
		/// <see cref="Volume_Folder_Info"/> object to remove is not in this collection. </exception>
		internal void Remove( Volume_Folder_Info Volume_Folder_Info )
		{
			// Check to see if this Volume_Folder_Info exists in this collection
			if ( !Contains(Volume_Folder_Info) )
				throw new Exception("The specified Volume_Folder_Info does not exist in this collection.");

			// Remove the Volume_Folder_Info which does exist
			List.Remove( Volume_Folder_Info );
		}

		/// <summary> Check to see if a Volume_Folder_Info currently exists in this collection.  </summary>
		/// <param name="Volume_Folder_Info"> Volume_Folder_Info to check for existence in this collection. </param>
		/// <returns>TRUE if the provided Volume_Folder_Info is already part of this Volume_Folder_Info Collection </returns>
		internal bool Contains( Volume_Folder_Info Volume_Folder_Info )
		{
			return List.Contains( Volume_Folder_Info );
		}

		/// <summary> Return an enumerator to step through this collection of Volume_Folder_Infos. </summary>
		/// <returns> A Type-Safe Volume_Folder_InfoEnumerator</returns>
		/// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
		public new Volume_Folder_InfoEnumerator GetEnumerator()
		{
			return new Volume_Folder_InfoEnumerator(this);
		}

		/// <summary> Return an enumerator to step through this collection of Volume_Folder_Infos. </summary>
		/// <returns> A IEnumerator object to step through this collection of Volume_Folder_Infos. </returns>
		/// <remarks> Explicit interface implementation to support interoperability with other common 
		/// language runtime-compatible langueages. </remarks>
		IEnumerator IEnumerable.GetEnumerator()
		{	
			return (IEnumerator) new Volume_Folder_InfoEnumerator(this);
		}

		/// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
		/// the <see cref="Volume_Folder_Info_Collection"/> in this collection. <br /> <br /> </summary>
		/// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
		/// iterate through all of the <see cref="Volume_Folder_Info"/> objects in the 
		/// <see cref="Volume_Folder_Info_Collection"/> object. </remarks>
		public class Volume_Folder_InfoEnumerator : IEnumerator
		{
			/// <summary> Stores the current position within the <see cref="Volume_Folder_Info_Collection"/>. </summary>
			private int position = -1;

			/// <summary> Reference to the <see cref="Volume_Folder_Info_Collection"/> to iterate through. </summary>
			private Volume_Folder_Info_Collection Volume_Folder_Infos;

			/// <summary> Constructore creates a new Volume_Folder_InfoEnumerator to iterate through
			/// the <see cref="Volume_Folder_Info_Collection"/>. </summary>
			/// <param name="Volume_Folder_Info_Collection"> <see cref="Volume_Folder_Info_Collection"/> to iterate through </param>
			public Volume_Folder_InfoEnumerator( Volume_Folder_Info_Collection Volume_Folder_Info_Collection )
			{
				Volume_Folder_Infos = Volume_Folder_Info_Collection;
			}

			/// <summary> Move to the next <see cref="Volume_Folder_Info"/> in this <see cref="Volume_Folder_Info_Collection"/>. </summary>
			/// <returns> TRUE if successful, otherwise FALSE </returns>
			/// <remarks> Method is required by the IEnumerator interface. </remarks>
			public bool MoveNext()
			{
				if ( position < ( Volume_Folder_Infos.Count - 1 ))
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

			/// <summary> Return the current <see cref="Volume_Folder_Info"/> from the <see cref="Volume_Folder_Info_Collection"/>. </summary>
			/// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
			public Volume_Folder_Info Current
			{
				get
				{
					return Volume_Folder_Infos[position];
				}
			}

			/// <summary> Return the current object from the <see cref="Volume_Folder_Info_Collection"/>. </summary>
			/// <remarks> Explicit interface implementation to support interoperability with other common 
			/// language runtime-compatible langueages. </remarks>
			object IEnumerator.Current
			{
				get
				{	
					return Volume_Folder_Infos[position];
				}
			}
		}
	}
}
