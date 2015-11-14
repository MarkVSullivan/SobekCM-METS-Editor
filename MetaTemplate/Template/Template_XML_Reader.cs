#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using SobekCM.METS_Editor.Elements;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.Template
{
	/// <summary>
	/// Summary description for Template_XML_Reader.
	/// </summary>
	public class Template_XML_Reader
	{
	    private List<string> addonsEnabled;

        private Creator_Simple_Element creatorSimpleElement;

	    private const Template_Language DEFAULT_LANGUAGE = Template_Language.English;

	    private Spatial_Simple_Element spatialSimpleElement;
	    private Subject_Simple_Element subjectSimpleElement;

	    /// <summary> Read the XML template and populate the template with all the appropriate pages, 
	    /// panels, and child metadata entry elements </summary>
	    /// <param name="XML_File"> Template XML file which conforms to the necessary XSD </param>
	    /// <param name="thisTemplate"> Template object to be populated </param>
	    /// <param name="exclude_divisions"> Flag indicates if any included structure map element should be exluded in the current usage </param>
	    public void Read_XML( string XML_File, Template thisTemplate, bool exclude_divisions )
		{
            try
            {
                // Get the list of addons
                addonsEnabled = MetaTemplate_UserSettings.AddOns_Enabled;

                // Load this MXF File
                XmlDocument templateXML = new XmlDocument();
                templateXML.Load(XML_File);

                // create the node reader
                XmlNodeReader nodeReader = new XmlNodeReader(templateXML);

                // Read through all main input template tag is found
                move_to_node(nodeReader, "input_template");

                // Process all of the header information for this template
                process_template_header(nodeReader, thisTemplate);

                // Process all of the input portion / hierarchy
                process_inputs(nodeReader, thisTemplate );

                // Process any constant sectoin
                process_constants(nodeReader, thisTemplate);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error while reading template file:\n\n" + XML_File + "\n\n" + ee.Message );
            }
		}

		private void process_template_header( XmlNodeReader nodeReader, Template thisTemplate )
		{
			// Read all the nodes
		    while ( nodeReader.Read() )
			{
				// Get the node name, trimmed and to upper
				string nodeName = nodeReader.Name.Trim().ToUpper();

				// If this is the inputs or constant start tag, return
				if (( nodeReader.NodeType == XmlNodeType.Element ) && 
					(( nodeName == "INPUTS" ) || ( nodeName == "CONSTANTS" )))
				{
					return;
				}

				// If this is the beginning tag for an element, assign the next values accordingly
				if ( nodeReader.NodeType == XmlNodeType.Element )
				{
					// switch the rest based on the tag name
					switch( nodeName )
					{
						case "NAME":

							// Determine the language and then add this name
							if ( nodeReader.HasAttributes )
							{
								nodeReader.MoveToFirstAttribute();
								thisTemplate.Set_Title( Template_Language_Convertor.ToEnum( nodeReader.Value ), read_text_node( nodeReader ) );
							}
							else
							{
								thisTemplate.Set_Title( DEFAULT_LANGUAGE, read_text_node( nodeReader ) );
							}
							break;

						case "NOTES":
							thisTemplate.Notes = (thisTemplate.Notes + "  " + read_text_node( nodeReader )).Trim();
							break;

						case "DATECREATED":
					        DateTime tempDate;
                            if ( DateTime.TryParse(read_text_node( nodeReader ), out tempDate ))
                                thisTemplate.DateCreated = tempDate;
							break;

						case "LASTMODIFIED":
                            DateTime tempDate2;
                            if ( DateTime.TryParse(read_text_node( nodeReader ), out tempDate2 ))
                                thisTemplate.LastModified = tempDate2;
							break;

						case "CREATOR":
							thisTemplate.Creator = read_text_node( nodeReader );
							break;
					}
				}
			}
		}

		private void process_inputs( XmlNodeReader nodeReader, Template thisTemplate )
		{
			// Keep track of the current pages and panels
			Template_Page currentPage = null;
			Template_Panel currentPanel = null;
		    bool inPanel = false;

			// Read all the nodes
		    while ( nodeReader.Read() )
			{
				// Get the node name, trimmed and to upper
				string nodeName = nodeReader.Name.Trim().ToUpper();

				// If this is the inputs or constant start tag, return
				if ((( nodeReader.NodeType == XmlNodeType.EndElement ) && ( nodeName == "INPUTS" )) ||
					(( nodeReader.NodeType == XmlNodeType.Element ) && ( nodeReader.Name == "CONSTANTS")))
				{
					return;
				}

				// If this is the beginning tag for an element, assign the next values accordingly
				if ( nodeReader.NodeType == XmlNodeType.Element )
				{
					// Does this start a new page?
					if ( nodeName == "PAGE" )
					{
						// Set the inPanel flag to false
						inPanel = false;

						// Create the new page and add to this template
						currentPage = new Template_Page();
						thisTemplate.InputPages.Add( currentPage );
					}

					// Does this start a new panel?
					if ( nodeName == "PANEL" )
					{
						// Set the inPanel flag to true
						inPanel = true;

						// Create the new panel and add to the current page
						currentPanel = new Template_Panel();
					    if (currentPage != null) currentPage.Panels.Add( currentPanel );
					}

					// Is this a name element?
					if ( nodeName == "NAME" )
					{
						// Determine the language
					    Template_Language language;
					    if ( nodeReader.HasAttributes )
						{
							nodeReader.MoveToFirstAttribute();
							language = Template_Language_Convertor.ToEnum( nodeReader.Value );
						}
						else
						{
							language = DEFAULT_LANGUAGE;
						}

						// Get the text
						string title = read_text_node( nodeReader );

						// Set the name for either the page or panel
						if ( inPanel )
						{
							currentPanel.Set_Title( language, title );
						}
						else
						{
						    if (currentPage != null) currentPage.Set_Title( language, title );
						}
					}

					// Is this a new element?
					if (( nodeName == "ELEMENT" ) && ( nodeReader.HasAttributes ))
					{
					    abstract_Element currentElement = process_element( nodeReader );
					    if (( currentElement != null ) && (currentPanel != null))
                            currentPanel.Elements.Add( currentElement );
					}
				}
			}
		}

		private abstract_Element process_element( XmlNodeReader nodeReader )
		{
			string type = String.Empty;
			string subtype = String.Empty;

		    // Step through all the attributes until the type is found
			nodeReader.MoveToFirstAttribute();
			do
			{
				// Get the type attribute
				if ( nodeReader.Name.ToUpper().Trim() == "TYPE" )
				{
					type = nodeReader.Value;
				}

				// Get the subtype attribute
				if ( nodeReader.Name.ToUpper().Trim() == "SUBTYPE" )
				{
					subtype = nodeReader.Value;
				}
			} while (nodeReader.MoveToNextAttribute() );

			// Make sure a type was specified
			if ( type == String.Empty )
				return null;

			// Build the element
			abstract_Element newElement = Element_Factory.getElement( type, subtype );

            // Some special code to make the creator element aware if there is a contributor element
            if ((newElement.Type == Element_Type.Creator) && (newElement.Display_SubType == "simple"))
                creatorSimpleElement = (Creator_Simple_Element) newElement;
            if ((newElement.Type == Element_Type.Contributor) && (creatorSimpleElement != null))
                creatorSimpleElement.Contributor_Exists = true;

            // Some special code to let the simple subject element know if there is a simple spatial element
            if ((newElement.Type == Element_Type.Subject) && ((newElement.Display_SubType == "simple") || (newElement.Display_SubType == "dublincore")))
            {
                if ( spatialSimpleElement != null )
                {
                    ((Subject_Simple_Element)newElement).Seperate_Dublin_Core_Spatial_Exists = true;
                }
                else
                {
                    subjectSimpleElement = (Subject_Simple_Element)newElement;
                }
            }
            if ((newElement.Type == Element_Type.Spatial) && (newElement.Display_SubType == "dublincore"))
            {
                if (subjectSimpleElement != null)
                {
                    subjectSimpleElement.Seperate_Dublin_Core_Spatial_Exists = true;
                }
                else
                {
                    spatialSimpleElement = (Spatial_Simple_Element)newElement;
                }
            }

			// Now, step through all the attributes again
			nodeReader.MoveToFirstAttribute();
			do
			{
				try
				{
					switch( nodeReader.Name.ToUpper().Trim() )
					{
						case "X":
							newElement.Location = new Point( Convert.ToInt16( nodeReader.Value ), newElement.Location.Y );
							break;
						case "Y":
							newElement.Location = new Point( newElement.Location.X, Convert.ToInt16( nodeReader.Value ));
							break;
						case "HEIGHT":
							newElement.Height = Convert.ToInt16( nodeReader.Value );
							break;
						case "WIDTH":
							newElement.Width = Convert.ToInt16( nodeReader.Value );
							break;
						case "REPEATABLE":
							newElement.Repeatable = Convert.ToBoolean( nodeReader.Value );
							break;
						case "MANDATORY":
							newElement.Mandatory = Convert.ToBoolean( nodeReader.Value );
							break;
					}
				}
				catch { }
			} while (nodeReader.MoveToNextAttribute() );

			// Move back to the element, if there were attributes (should be)
			nodeReader.MoveToElement();

			// Is there element_data?
			if ( !nodeReader.IsEmptyElement )
			{
				nodeReader.Read();
				if (( nodeReader.NodeType == XmlNodeType.Element ) && ( nodeReader.Name.ToLower() == "element_data" ))
				{
					// Create the new tree
					StringWriter sw = new StringWriter();
					XmlTextWriter tw = new XmlTextWriter( sw );
					tw.WriteNode( nodeReader, true );
					tw.Close();

					// Let the element process this inner data
					newElement.Read_XML( new XmlTextReader( new StringReader( sw.ToString() )));
				}
			}

            // If this is the METS ObjectID, suppress it if the SobekCM add-on is enabled
            if ((newElement.Type == Element_Type.METS_ObjectID) && (addonsEnabled.Contains("SOBEKCM")))
                return null;

			// Return this built element
			return newElement;
		}

		private void process_constants( XmlNodeReader nodeReader, Template thisTemplate )
		{
			// Read all the nodes
		    while ( nodeReader.Read() )
			{
				// Get the node name, trimmed and to upper
				string nodeName = nodeReader.Name.Trim().ToUpper();

				// If this is the inputs or constant start tag, return
				if (( nodeReader.NodeType == XmlNodeType.EndElement ) && ( nodeName == "CONSTANTS" ))
				{
					return;
				}

				// If this is the beginning tag for an element, assign the next values accordingly
				if (( nodeReader.NodeType == XmlNodeType.Element ) && ( nodeName == "ELEMENT" ) && ( nodeReader.HasAttributes ))
				{
					abstract_Element newConstant = process_element( nodeReader );
					newConstant.isConstant = true;
					thisTemplate.Constants.Add( newConstant );
				}
			}
		}

		private static void move_to_node( XmlNodeReader nodeReader, string nodeName )
		{
			while (( nodeReader.Read() ) && ( nodeReader.Name.Trim() != nodeName ))
			{
				// Do nothing here... 
			}
		}

		private static string read_text_node( XmlNodeReader nodeReader )
		{
		    if (( nodeReader.Read() ) && ( nodeReader.NodeType == XmlNodeType.Text ))
			{
				return nodeReader.Value.Trim();
			}
		    
            return String.Empty;
		}
	}
}
