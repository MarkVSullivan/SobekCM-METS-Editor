#region Using directives

using System;
using System.Collections;
using System.Drawing;
using System.Text;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary> Template_Panel_Collection is a collection of <see cref="Template_Panel"/> objects </summary>
	/// <remarks> This class extends the <see cref="CollectionBase"/> abstract class and implements the 
	/// <see cref="IEnumerable"/> interface. <br /> <br /> 
	/// Object created by Mark V Sullivan (2005).  </remarks>
	public class Template_Panel_Collection : CollectionBase, IEnumerable
	{
	    #region Constructor

	    #endregion

	    #region Standard Collection Public Properties and Methods

	    /// <summary> Address a single panel from this collection, by index. </summary>
	    /// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if there is 
	    /// an index out of bounds error. </exception>
	    public Template_Panel this[int Index]
	    {
	        get	
	        {	
	            // Check that this is a valid index
	            if ( Index >= List.Count )
	                throw new ApplicationException("Index out of bounds while requesting Panel #" + Index + " from a Template_Panel_Collection.");

	            // Return the reqeuested, valid item
	            return ((Template_Panel) (List[Index]));	
	        }
	        set	{	List[Index] = value;	}
	    }

	    /// <summary> Return an enumerator to step through this collection of downloads. </summary>
	    /// <returns> A IEnumerator object to step through this collection of downloads. </returns>
	    /// <remarks> Explicit interface implementation to support interoperability with other common 
	    /// language runtime-compatible langueages. </remarks>
	    IEnumerator IEnumerable.GetEnumerator()
	    {	
	        return new Template_Panel_Collection_Enumerator(this);
	    }

	    /// <summary> Add a new panel to this collection. </summary>
	    /// <param name="Panel"> Template_Panel object for this new panel </param>
	    /// <returns> The index for this new panel </returns>
	    public int Add( Template_Panel Panel )
	    {
	        // Add the panel to the list and keep the index
	        int returnVal = List.Add( Panel );

	        // Return the index
	        return returnVal;
	    }

	    /// <summary> Remove an existing panel from this collection. </summary>
	    /// <param name="Panel"> Panel to remove from this collection. </param>
	    /// <exception cref="ApplicationException"> Throws a <see cref="ApplicationException"/> if the specified
	    /// <see cref="Template_Panel"/> object to remove is not in this collection. </exception>
	    public void Remove( Template_Panel Panel )
	    {
	        // Check to see if this panel exists in this collection
	        if ( !Contains(Panel) )
	            throw new ApplicationException("The specified panel does not exist in this collection.");

	        // Remove the panel which does exist
	        List.Remove( Panel );
	    }

	    /// <summary> Check to see if a panel currently exists in this collection.  </summary>
	    /// <param name="Panel"> Panel to check for existence in this collection. </param>
	    /// <returns>TRUE if the provided panel is already part of this Collection </returns>
	    public bool Contains( Template_Panel Panel )
	    {
	        return List.Contains( Panel );
	    }

	    /// <summary> Return an enumerator to step through this collection of downloads. </summary>
	    /// <returns> A Type-Safe Template_Panel_Collection_Enumerator</returns>
	    /// <remarks> This version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
	    public new Template_Panel_Collection_Enumerator GetEnumerator()
	    {
	        return new Template_Panel_Collection_Enumerator(this);
	    }

	    #endregion

        /// <summary> Allows the font to be set for each panel within this collection  </summary>
	    public Font Current_Font
		{
			set
			{
				foreach( Template_Panel thisPanel in this )
				{
					thisPanel.Current_Font = value;
				}
			}
		}

	    #region Template_Panel_Collection_Enumerator Class Declaration

	    /// <summary> Inner class implements the <see cref="IEnumerator"/> interface and iterates through 
	    /// the <see cref="Template_Panel_Collection"/> in this data grid. <br /> <br /> </summary>
	    /// <remarks> Inclusion of this strongly-typed iterator allows the use of the foreach .. in structure to 
	    /// iterate through all of the <see cref="Template_Panel"/> objects in the 
	    /// <see cref="Template_Panel_Collection"/> object.  </remarks>
	    public class Template_Panel_Collection_Enumerator : IEnumerator
	    {
	        /// <summary> Reference to the <see cref="Template_Panel_Collection"/> to iterate through. </summary>
	        private readonly Template_Panel_Collection panels;

	        /// <summary> Stores the current position within the <see cref="Template_Panel_Collection"/>. </summary>
	        private int position = -1;

	        /// <summary> Constructore creates a new Template_Panel_Collection_Enumerator to iterate through
	        /// the <see cref="Template_Panel_Collection"/>. </summary>
	        /// <param name="panelCollection"> <see cref="Template_Panel_Collection"/> to iterate through </param>
	        public Template_Panel_Collection_Enumerator( Template_Panel_Collection panelCollection )
	        {
	            panels = panelCollection;
	        }

	        /// <summary> Return the current <see cref="Template_Panel"/> from the <see cref="Template_Panel_Collection"/>. </summary>
	        /// <remarks> This type-safe version is used in the C# Compiler to detect type conflicts at compilation. </remarks>
	        public Template_Panel Current
	        {
	            get
	            {
	                return panels[position];
	            }
	        }

	        #region IEnumerator Members

	        /// <summary> Move to the next <see cref="Template_Panel"/> in this <see cref="Template_Panel_Collection"/>. </summary>
	        /// <returns> TRUE if successful, otherwise FALSE </returns>
	        /// <remarks> Method is required by the IEnumerator interface. </remarks>
	        public bool MoveNext()
	        {
	            if ( position < ( panels.Count - 1 ))
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

	        /// <summary> Return the current object from the <see cref="Template_Panel_Collection"/>. </summary>
	        /// <remarks> Explicit interface implementation to support interoperability with other common 
	        /// language runtime-compatible langueages. </remarks>
	        object IEnumerator.Current
	        {
	            get
	            {	
	                return panels[position];
	            }
	        }

	        #endregion
	    }

	    #endregion

	    /// <summary> Returns the XML string to save this collection of 
	    /// panels to the template XML file </summary>
	    /// <returns>String for template XML file</returns>
	    public string To_Template_XML()
	    {
	        // Build results from all the panel in this collection
	        StringBuilder result = new StringBuilder();

	        // Step through each panel
	        foreach( Template_Panel thisPanel in this )
	        {
	            result.Append( thisPanel.To_Template_XML() );
	        }

	        // Return the collected results
	        return result.ToString();
	    }
	}
}
