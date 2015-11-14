#region Using directives

using System;
using System.Collections;
using System.Drawing;
using System.Text;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary> Element_Collection is a collection of <see cref="abstract_Element"/> objects </summary>
	/// <remarks> This class extends the <see cref="CollectionBase"/> abstract class and implements the 
	/// <see cref="IEnumerable"/> interface. <br /> <br /> 
	/// Object created by Mark V Sullivan (2005).  </remarks>
	public class Element_Collection : CollectionBase, IEnumerable
	{
		#region Constructor

	    #endregion

		#region Standard Collection Public Properties and Methods

		/// <summary> Address a single element from this collection, by index. </summary>
		/// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if there is 
		/// an index out of bounds error. </exception>
		public abstract_Element this[int Index]
		{
			get	
			{	
				// Check that this is a valid index
				if ( Index >= List.Count )
					throw new ApplicationException("Index out of bounds while requesting Element #" + Index + " from a Element_Collection.");

				// Return the reqeuested, valid item
				return ((abstract_Element) (List[Index]));	
			}
			set	{	List[Index] = value;	}
		}

		/// <summary> Add a new element to this collection. </summary>
		/// <param name="Element"> abstract_Element object for this new element </param>
		/// <returns> The index for this new element </returns>
		public int Add( abstract_Element Element )
		{
			if ( Element != null )
			{
				// Add the element to the list and keep the index
				int returnVal = List.Add( Element );

				// Return the index
				return returnVal;
			}
			else
			{
				return -1;
			}
		}

		/// <summary> Remove an existing element from this collection. </summary>
		/// <param name="Element"> Element to remove from this collection. </param>
		/// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if the specified
		/// <see cref="abstract_Element"/> object to remove is not in this collection. </exception>
		public void Remove( abstract_Element Element )
		{
			// Check to see if this element exists in this collection
			if ( !Contains(Element) )
				throw new ApplicationException("The specified element does not exist in this collection.");

			// Remove the element which does exist
			List.Remove( Element );
		}

		/// <summary> Check to see if a element currently exists in this collection.  </summary>
		/// <param name="Element"> Element to check for existence in this collection. </param>
		/// <returns>TRUE if the provided element is already part of this Collection </returns>
		public bool Contains( abstract_Element Element )
		{
			return List.Contains( Element );
		}

		public int IndexOf( abstract_Element Element )
		{
			return List.IndexOf( Element );
		}

		public void Insert( int index, abstract_Element Element )
		{
			List.Insert( index, Element );
		}

		/// <summary> Return an enumerator to step through this collection of downloads. </summary>
		/// <returns> A Type-Safe abstract_Element_Collection_Enumerator</returns>
		/// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
		public new abstract_Element_Collection_Enumerator GetEnumerator()
		{
			return new abstract_Element_Collection_Enumerator(this);
		}

		/// <summary> Return an enumerator to step through this collection of downloads. </summary>
		/// <returns> A IEnumerator object to step through this collection of downloads. </returns>
		/// <remarks> Explicit interface implementation to support interoperability with other common 
		/// language runtime-compatible langueages. </remarks>
		IEnumerator IEnumerable.GetEnumerator()
		{	
			return new abstract_Element_Collection_Enumerator(this);
		}

		#endregion

		/// <summary> Returns the XML string to save this collection of 
		/// pages to the template XML file </summary>
		/// <returns>String for template XML file</returns>
		public string To_Template_XML( string indent )
		{
			// Build results from all the pages in this collection
			StringBuilder result = new StringBuilder();

			// Step through each element
			foreach( abstract_Element thisElement in this )
			{
				result.Append( thisElement.To_Template_XML( indent ) );
			}

			// Return the collected results
			return result.ToString();
		}

		public Font Current_Font
		{
			set
			{
				foreach( abstract_Element thisElement in this )
				{
					thisElement.Set_Font( value );
				}
			}
		}

		#region abstract_Element_Collection_Enumerator Class Declaration

		/// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
		/// the <see cref="Element_Collection"/> in this data grid. <br /> <br /> </summary>
		/// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
		/// iterate through all of the <see cref="abstract_Element"/> objects in the 
		/// <see cref="Element_Collection"/> object.  </remarks>
		public class abstract_Element_Collection_Enumerator : IEnumerator
		{
			/// <summary> Stores the current position within the <see cref="Element_Collection"/>. </summary>
			private int position = -1;

			/// <summary> Reference to the <see cref="Element_Collection"/> to iterate through. </summary>
			private Element_Collection elements;

			/// <summary> Constructore creates a new abstract_Element_Collection_Enumerator to iterate through
			/// the <see cref="Element_Collection"/>. </summary>
			/// <param name="elementCollection"> <see cref="Element_Collection"/> to iterate through </param>
			public abstract_Element_Collection_Enumerator( Element_Collection elementCollection )
			{
				elements = elementCollection;
			}

			/// <summary> Move to the next <see cref="abstract_Element"/> in this <see cref="Element_Collection"/>. </summary>
			/// <returns> TRUE if successful, otherwise FALSE </returns>
			/// <remarks> Method is required by the IEnumerator interface. </remarks>
			public bool MoveNext()
			{
				if ( position < ( elements.Count - 1 ))
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

			/// <summary> Return the current <see cref="abstract_Element"/> from the <see cref="Element_Collection"/>. </summary>
			/// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
			public abstract_Element Current
			{
				get
				{
					return elements[position];
				}
			}

			/// <summary> Return the current object from the <see cref="Element_Collection"/>. </summary>
			/// <remarks> Explicit interface implementation to support interoperability with other common 
			/// language runtime-compatible langueages. </remarks>
			object IEnumerator.Current
			{
				get
				{	
					return elements[position];
				}
			}
		}

		#endregion

	}
}
