using System;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;

namespace DLC.Tools
{
	/// <summary> RemarkedDataSet extends the <see cref="DataSet"/> object and includes remarks for each 
	/// data element.  <br /> <br /> </summary>
	/// <remarks> This extends the <see cref="DataSet"/> object and contains internal collections 
	/// to maintain remarks for each DataTable in this DataSet.  Remarks are also maintained for the 
	/// entire DataSet.  To utilize these remarks, and output to remarked XML, use the <see cref="WriteRemarkedXml"/>
	/// method and add each table with the <see cref="AddTable"/> method.  The <see cref="AddRemarks"/> method adds
	/// remarks to a preexisting <see cref="DataTable"/> object in the collection. 
	/// <br /> <br /> Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center. </remarks>
	/// <example> EXAMPLE 1: Below is an example of using this class to create remarked XML for a DataSet:
	/// <code>
	/// <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using System.Data;
	///	using GeneralTools.Data;
	///
	///	namespace DLC.Tools
	///	{
	///		public class RemarkedDataSet_Example
	///		{
	///			static void Main() 
	///			{
	///				// Build the DataSet amd add the remarks
	///				RemarkedDataSet tester = new RemarkedDataSet("Test_DataSet");
	///				tester.Namespace = "DLC";
	///				tester.Remarks = "This is the very first test data set.  These remarks are being " +
	///					"made very long on purpose to test the wrapping ability of the remark formatter " +
	///					"private helper method function in the Remarked DataSet";
	///
	///				// Add the first table
	///				DataTable firstTable = new DataTable("Language");
	///				firstTable.Columns.Add( new DataColumn("Greeting") );
	///				firstTable.Columns.Add( new DataColumn("Opposite") );
	///				tester.AddTable( firstTable, "This is the very first test data table, which stores greetings and the opposite greetings.");
	///
	///				// Add the second table
	///				DataTable secondTable = new DataTable("People");
	///				secondTable.Columns.Add( new DataColumn("Name") );
	///				secondTable.Columns.Add( new DataColumn("Email") );
	///				tester.Tables.Add( secondTable )
	///				tester.AddRemarks( secondTable, "The 'People' table holds additional information which can be used while processing items.");
	///
	///				// Add two rows to the first table row
	///				DataRow newRow = firstTable.NewRow();
	///				newRow["Greeting"] = "Hello";
	///				newRow["Opposite"] = "Goodbye";
	///				firstTable.Rows.Add( newRow );
	///				newRow = firstTable.NewRow();
	///				newRow["Greeting"] = "Good Morning";
	///				newRow["Opposite"] = "Good Night";
	///				firstTable.Rows.Add( newRow );
	///
	///				// Add a row to the second table
	///				newRow = secondTable.NewRow();
	///				newRow["Name"] = "Mark Sullivan";
	///				newRow["Email"] = "MarkSull@bellsouth.net";
	///				secondTable.Rows.Add( newRow );
	///
	///				// Write to XML
	///				tester.WriteRemarkedXml( "test.xml" );
	///			}
	///		}
	///	}
	/// </code>
	/// <br />
	/// Below is what the output file's text looks like.  To see it in HTML, click <a href="test.xml">here</a>.
	/// <code>
	///	&lt;!-- This is the very first test data set.  These remarks are being made very   --&gt; 
	///	&lt;!-- long on purpose to test the wrapping ability of the remark formatter       --&gt; 
	///	&lt;!-- private helper method function in the Remarked DataSet                     --&gt; 
	///	&lt;Test_DataSet xmlns=&quot;DLC&quot;&gt;
	///
	///	&lt;!-- This is the very first test data table, which stores greetings and the     --&gt; 
	///	&lt;!-- opposite greetings.                                                        --&gt; 
	///	&lt;Language&gt;
	///	&lt;Greeting&gt;Hello&lt;/Greeting&gt;
	///	&lt;Opposite&gt;Goodbye&lt;/Opposite&gt;
	///	&lt;/Language&gt;
	///	&lt;Language&gt;
	///	&lt;Greeting&gt;Good Morning&lt;/Greeting&gt;
	///	&lt;Opposite&gt;Good Night&lt;/Opposite&gt;
	///	&lt;/Language&gt;
	///
	///	&lt;!-- The 'People' table holds additional information which can be used while    --&gt; 
	///	&lt;!-- processing items.                                                          --&gt; 
	///	&lt;People&gt;
	///	&lt;Name&gt;Mark Sullivan&lt;/Name&gt;
	///	&lt;Email&gt;MarkSull@bellsouth.net&lt;/Email&gt;
	///	&lt;/People&gt;
	///	&lt;/Test_DataSet&gt;
	/// </code> </example>
	public class RemarkedDataSet : DataSet
	{
		/// <summary> Stores the DataSet level remarks </summary>
		private string remarks;

		/// <summary> Stores the DataTable level remarks </summary>
		private Hashtable tableRemarks;

		/// <summary> Constructor for a new RemarkedDataSet object </summary>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public RemarkedDataSet( ) : base ( )
		{
			// Declare remarks an empty string
			remarks = "";

			// Declare a new hastable to store the remarks for each table
			tableRemarks = new Hashtable();
		}

		/// <summary> Constructor for a new RemarkedDataSet object </summary>
		/// <param name="dataSet"> DataSet full of the data </param>
		/// <param name="oldTableRemarks"> Hashtable full of remarks for each table </param>
		/// <param name="remarks"> Volume level remarks </param>
		public RemarkedDataSet( DataSet dataSet, Hashtable oldTableRemarks, string remarks ) : base ( )
		{
			base.Namespace = dataSet.Namespace;

			// Copy over each table
			foreach( DataTable thisTable in dataSet.Tables )
				base.Tables.Add( thisTable.Copy() );

			// Copy all the remarks over
			this.tableRemarks = new Hashtable();
			foreach( object key in oldTableRemarks.Keys )
				this.tableRemarks.Add( key, oldTableRemarks[key] );

			this.remarks = remarks;
		}

		/// <summary> Constructor for a new RemarkedDataSet object </summary>
		/// <param name="dataSetName"> Name of the data set </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public RemarkedDataSet( string dataSetName ) : base ( dataSetName )
		{
			// Declare remarks an empty string
			remarks = "";
			
			// Declare a new hastable to store the remarks for each table
			tableRemarks = new Hashtable();
		}

		/// <summary> Constructor for a new RemarkedDataSet object </summary>
		/// <param name="dataSetName"> Name of the data set </param>
		/// <param name="dataSetRemarks"> Remarks associated with this data set </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public RemarkedDataSet( string dataSetName, string dataSetRemarks ) : base ( dataSetName )
		{
			// Save the remarks parameter
			remarks = dataSetRemarks;
			
			// Declare a new hastable to store the remarks for each table
			tableRemarks = new Hashtable();
		}

		/// <summary> Gets and sets the DataSet level remarks </summary>
		/// <value> Remarks which pertain to the entire DataSet </value>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public string Remarks
		{
			get	{	return remarks;		}
			set	{	remarks = value;	}
		}


		/// <summary> Adds a remarked <see cref="DataTable"/> object to the collection. </summary>
		/// <param name="table"> <see cref="DataTable"/> object to add </param>
		/// <param name="remarks"> Remarks to associate with this DataTable </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void AddTable( DataTable table, string remarks )
		{
			// Add this table to the base collection
			Tables.Add( table );

			// Save the remarks for this table
			tableRemarks.Add( table, remarks );
		}

		/// <summary> Gets a copy in structure, data, and remarks to this Remarked DataSet </summary>
		/// <returns> Copy </returns>
		public new RemarkedDataSet Copy()
		{
			// First, copy the underlying DataSet
			return new RemarkedDataSet( base.Copy(), this.tableRemarks, this.remarks );
		}

		/// <summary> Adds remarks to a pre-existing <see cref="DataTable"/> object in the collection. </summary>
		/// <param name="table"> <see cref="DataTable"/> object to attach the remarks to </param>
		/// <param name="remarks"> Remarks to associate with this DataTable </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void AddRemarks( DataTable table, string remarks )
		{
			// Save the remarks for this table
			tableRemarks.Add( table, remarks );
		}

		/// <summary> Adds remarks to a pre-existing <see cref="DataTable"/> object in the collection. </summary>
		/// <param name="tableName"> Name of the preexisting table in this data set </param>
		/// <param name="remarks"> Remarks to associate with this DataTable </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void AddRemarks( string tableName, string remarks )
		{
			// Save the remarks for this table
			if ( base.Tables.Contains( tableName ) )
				tableRemarks.Add( base.Tables[tableName], remarks );
		}

		/// <summary> Writes the current data to the specified file as remarked XML </summary>
		/// <param name="fileName"> The file name (including the path) to which to write </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void WriteRemarkedXml( string fileName )
		{
			WriteRemarkedXml( fileName, false );
		}

		/// <summary> Writes the current data to the specified file as remarked XML </summary>
		/// <param name="fileName"> The file name (including the path) to which to write </param>
		/// <param name="writeMode"> One of the System.XmlWriteMode values.  Use WriteSchema to write the schema </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void WriteRemarkedXml( string fileName, XmlWriteMode writeMode )
		{
			// See if schema should be included
			if ( writeMode.Equals( XmlWriteMode.WriteSchema ) )
				WriteRemarkedXml( fileName, true );
			else
				WriteRemarkedXml( fileName, false );
		}


		/// <summary> Writes the current data to the specified file as remarked XML </summary>
		/// <param name="fileName"> The file name (including the path) to which to write </param>
		/// <param name="includeSchema"> Flag indicates whether to include the schema or not </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		public void WriteRemarkedXml( string fileName, bool includeSchema )
		{
			// Create the string builder to hold the XML and add the data set remarks, if some exists
			StringBuilder XML = new StringBuilder();

			if ( remarks.Length > 0 )
				XML.Append( formatRemarks( remarks ) );

			// Cerate the StringWriter and get the XML written to the StringBuilder
			StringWriter getXML = new StringWriter( XML );

			// Get the XML, and include schema if that was requested
			if ( includeSchema )
				base.WriteXml( getXML, XmlWriteMode.WriteSchema );
			else
				base.WriteXml( getXML );

			// If schema is included, add schema remarks
			if ( includeSchema )
			{
				// Get location to place the schema remarks
				int schemaStart = XML.ToString().IndexOf("schema") - 4;

				// Make sure schema was found before continuing
				if ( schemaStart >= 0 )
					XML.Insert( schemaStart, "\r\n" + formatRemarks("Schema for this Remarked Data Set.  Data follows below."));
			}

			// Iterate through each table in this DataSet
			string tblName, tblRemarks;
			int tblStart;
			foreach( DataTable thisTable in base.Tables )
			{
				// Get the name of this table and the remarks from the tableRemarks hashtable
				tblName = thisTable.TableName;

				// Only continue if the remarks exist for this
				if ( tableRemarks.Contains( thisTable ) )
				{
					tblRemarks = tableRemarks[thisTable].ToString();

					// Find the index for this first table entry
					tblStart = XML.ToString().IndexOf( "<" + tblName + ">" );

					// If this table is present, add the remarks
					if ( tblStart >= 3 )
					{
						XML.Insert( tblStart-2, "\r\n" + formatRemarks( tblRemarks ) );
					}
				}
			}

			// Now, need to write this out to a text file
			StreamWriter writeXML = new StreamWriter( fileName, false );
			writeXML.Write( XML.ToString() );
			writeXML.Close();	
		}

		/// <summary> Formats the remarks into the proper format, dividing into strings
		/// and placing the proper encoding around it </summary>
		/// <param name="remarksToFormat"> String to format </param>
		/// <example> For a complete example, see the example under the main <see cref="RemarkedDataSet"/> class. </example>
		private string formatRemarks( string remarksToFormat )
		{
			StringBuilder inputVal = new StringBuilder( remarksToFormat );
			StringBuilder returnVal = new StringBuilder();

			// Keep going until the line runs out
			int lineLength;
			while ( inputVal.Length > 73 )
			{
				// Find the next space
				lineLength = 73;
				while ( (lineLength >= 0 ) && (inputVal[lineLength] != ' ' ) )
					lineLength--;

				// If the line length = zero, there was no space, so just cut it off
				if ( lineLength <= 0 )
					lineLength = 73;

				// Add this line
				returnVal.Append("<!-- ");
				returnVal.Append( inputVal.ToString(), 0, lineLength );
				inputVal.Remove( 0, lineLength );

				// If the line was not the complete right length, add enough spaces now
				while( lineLength <= 73 )
				{
					lineLength++;
					returnVal.Append(" ");
				}

				// Add the closer tag
				returnVal.Append(" --> \r\n");

				// Remove the space that was left (if it was )
				if ( inputVal[0] == ' ')
					inputVal.Remove(0,1);
			}

			// Add the last line
			returnVal.Append("<!-- ");
			returnVal.Append( inputVal.ToString() );
			lineLength = inputVal.Length;

			// If the line was not the complete right length, add enough spaces now
			while( lineLength <= 73 )
			{
				lineLength++;
				returnVal.Append(" ");
			}

			// Add the closer tag
			returnVal.Append(" --> \r\n");

			// Now, return the formatted string
			return returnVal.ToString();
		}
	}
}
