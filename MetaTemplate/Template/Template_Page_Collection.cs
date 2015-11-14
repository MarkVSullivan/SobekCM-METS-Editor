#region Using directives

using System;
using System.Collections;
using System.Drawing;
using System.Text;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary> Template_Page_Collection is a collection of <see cref="Template_Page"/> objects </summary>
	/// <remarks> This class extends the <see cref="CollectionBase"/> abstract class and implements the 
	/// <see cref="IEnumerable"/> interface. <br /> <br /> 
	/// Object created by Mark V Sullivan (2005).  </remarks>
	public class Template_Page_Collection : CollectionBase, IEnumerable
	{
	    #region Constructor

	    #endregion

	    #region Standard Collection Public Properties and Methods

	    /// <summary> Address a single page from this collection, by index. </summary>
	    /// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if there is 
	    /// an index out of bounds error. </exception>
	    public Template_Page this[int Index]
	    {
	        get	
	        {	
	            // Check that this is a valid index
	            if ( Index >= List.Count )
	                throw new ApplicationException("Index out of bounds while requesting Page #" + Index + " from a Template_Page_Collection.");

	            // Return the reqeuested, valid item
	            return ((Template_Page) (List[Index]));	
	        }
	        set	{	List[Index] = value;	}
	    }

	    /// <summary> Return an enumerator to step through this collection of downloads. </summary>
	    /// <returns> A IEnumerator object to step through this collection of downloads. </returns>
	    /// <remarks> Explicit interface implementation to support interoperability with other common 
	    /// language runtime-compatible langueages. </remarks>
	    IEnumerator IEnumerable.GetEnumerator()
	    {	
	        return new Template_Page_Collection_Enumerator(this);
	    }

	    /// <summary> Add a new page to this collection. </summary>
	    /// <param name="Page"> Template_Page object for this new page </param>
	    /// <returns> The index for this new page </returns>
	    public int Add( Template_Page Page )
	    {
	        // Add the page to the list and keep the index
	        int returnVal = List.Add( Page );

	        // Return the index
	        return returnVal;
	    }

	    /// <summary> Remove an existing page from this collection. </summary>
	    /// <param name="Page"> Page to remove from this collection. </param>
	    /// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if the specified
	    /// <see cref="Template_Page"/> object to remove is not in this collection. </exception>
	    public void Remove( Template_Page Page )
	    {
	        // Check to see if this page exists in this collection
	        if ( !Contains(Page) )
	            throw new ApplicationException("The specified page does not exist in this collection.");

	        // Remove the page which does exist
	        List.Remove( Page );
	    }

	    /// <summary> Check to see if a page currently exists in this collection.  </summary>
	    /// <param name="Page"> Page to check for existence in this collection. </param>
	    /// <returns>TRUE if the provided page is already part of this Collection </returns>
	    public bool Contains( Template_Page Page )
	    {
	        return List.Contains( Page );
	    }

	    /// <summary> Return an enumerator to step through this collection of downloads. </summary>
	    /// <returns> A Type-Safe Template_Page_Collection_Enumerator</returns>
	    /// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
	    public new Template_Page_Collection_Enumerator GetEnumerator()
	    {
	        return new Template_Page_Collection_Enumerator(this);
	    }

	    #endregion

	    /// <summary> Allows the current font to be set across all pages within this collection </summary>
	    public Font Current_Font
		{
			set
			{
				foreach( Template_Page thisPage in this )
				{
					thisPage.Current_Font = value;
				}
			}
		}

	    #region Template_Page_Collection_Enumerator Class Declaration

	    /// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
	    /// the <see cref="Template_Page_Collection"/> in this data grid. <br /> <br /> </summary>
	    /// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
	    /// iterate through all of the <see cref="Template_Page"/> objects in the 
	    /// <see cref="Template_Page_Collection"/> object.  </remarks>
	    public class Template_Page_Collection_Enumerator : IEnumerator
	    {
	        /// <summary> Reference to the <see cref="Template_Page_Collection"/> to iterate through. </summary>
	        private readonly Template_Page_Collection pages;

	        /// <summary> Stores the current position within the <see cref="Template_Page_Collection"/>. </summary>
	        private int position = -1;

	        /// <summary> Constructore creates a new Template_Page_Collection_Enumerator to iterate through
	        /// the <see cref="Template_Page_Collection"/>. </summary>
	        /// <param name="pageCollection"> <see cref="Template_Page_Collection"/> to iterate through </param>
	        public Template_Page_Collection_Enumerator( Template_Page_Collection pageCollection )
	        {
	            pages = pageCollection;
	        }

	        /// <summary> Return the current <see cref="Template_Page"/> from the <see cref="Template_Page_Collection"/>. </summary>
	        /// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
	        public Template_Page Current
	        {
	            get
	            {
	                return pages[position];
	            }
	        }

	        #region IEnumerator Members

	        /// <summary> Move to the next <see cref="Template_Page"/> in this <see cref="Template_Page_Collection"/>. </summary>
	        /// <returns> TRUE if successful, otherwise FALSE </returns>
	        /// <remarks> Method is required by the IEnumerator interface. </remarks>
	        public bool MoveNext()
	        {
	            if ( position < ( pages.Count - 1 ))
	            {
	                position++;
	                return true;
	            }
	            
                return false;
	        }

	        /// <summary> Reset to the position just before the first position.  
	        /// Ready for the MoveNext() method to be called. </summary>
	        /// <remarks> Method is required by the IEnumerator interface. </remarks>
	        public void Reset()
	        {
	            position = -1;
	        }

	        /// <summary> Return the current object from the <see cref="Template_Page_Collection"/>. </summary>
	        /// <remarks> Explicit interface implementation to support interoperability with other common 
	        /// language runtime-compatible langueages. </remarks>
	        object IEnumerator.Current
	        {
	            get
	            {	
	                return pages[position];
	            }
	        }

	        #endregion
	    }

	    #endregion

	    /// <summary> Returns the XML string to save this collection of 
	    /// pages to the template XML file </summary>
	    /// <returns>String for template XML file</returns>
	    public string To_Template_XML()
	    {
	        // Build results from all the pages in this collection
	        StringBuilder result = new StringBuilder();

	        // Step through each page
	        foreach( Template_Page thisPage in this )
	        {
	            result.Append( thisPage.To_Template_XML() );
	        }

	        // Return the collected results
	        return result.ToString();
	    }
	}
}
