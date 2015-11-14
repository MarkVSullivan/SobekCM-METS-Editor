using System;
using System.IO;
using System.Collections;

namespace DLC.Tools
{
	/// <summary> TiffInfo is an object which reads an existing TIFF
	/// image and can then be queried for the header information.  <br /><br />
	/// </summary>
	/// <remarks>  Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.  </remarks>
	/// <example> Below is a simple example to print the information from the TIFF header of any file from a Console application. <code>
	/// <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using System.IO;
	///	using GeneralTools.Images;
	///
	///	namespace DLC.Tools.Example
	///	{
	///		public class TiffInfo_Example
	///		{
	///			static void Main() 
	///			{
	///				// Read the name of the file to read the TIFF header for
	///				Console.Write("Enter the name of the file: ");
	///				string file = Console.ReadLine();
	///
	///				// Make sure the file exists, before continuing
	///				if ( File.Exists( file ) )
	///				{
	///					// Create a new TiffInfo object and read the header of the file
	///					TiffInfo tiffReader = new TiffInfo( file );
	///
	///					// See if this was a valid TIFF
	///					if ( tiffReader.ValidTIFF )
	///					{
	///						// Print out several values for this TIFF
	///						Console.WriteLine("\nByte Order: \t" + tiffReader.ByteOrder );
	///						Console.WriteLine("Compression: \t" + tiffReader.Compression );
	///						Console.WriteLine("Resolution: \t" + tiffReader.XResolution + " pixels per " + tiffReader.ResolutionUnit );
	///						Console.WriteLine("Height: \t" + tiffReader.ImageHeight + " pixels");
	///						Console.WriteLine("Width: \t\t" + tiffReader.ImageWidth + " pixels" );
	///					}
	///					else
	///					{
	///						// Not a valid TIFF
	///						Console.WriteLine("\nThis indicated file was not a valid TIFF");
	///					}
	///				}
	///				else
	///				{
	///					// File did not exist
	///					Console.WriteLine("\nThe indicated file does not exist.");
	///				}
	///
	///				// Wait for the user to hit enter
	///				Console.WriteLine("\nHit Enter to Continue");
	///				Console.ReadLine();
	///			}
	///		}
	///	}
	/// </code>
	/// <br /> This example will write the following to the Console Window:
	/// <code>
	///	Enter the name of the file: E:\UF00015509.tif
	///
	///	Byte Order:     INTEL
	///	Compression:    Uncompressed
	///	Resolution:     300 pixels per inch
	///	Height:         7884 pixels
	///	Width:          5100 pixels
	///
	///	Hit Enter to Continue
	///	</code> </example>
	public class TiffInfo
	{

/*==========================================================================
 *				PRIVATE DATA MEMBERS of the TiffInfo class 
 *=========================================================================*/

		/// <summary> String which holds the current file whose
		/// header has been read. </summary>
		private string fileName;

		/// <summary> Boolean flag set by parseImageFileHeader method to indicate 
		/// if the current file is a valid TIFF. </summary>
		private bool invalidTIFF;
	
		/// <summary> Boolean flag set by parseImageFileHeader method to indicate 
		/// if the current file is in INTEL byte order. </summary>
		private bool intelTIFF;

		/// <summary> Offset to the next Image File Directory in the TIFF header.
		/// This is set by the parseImageFileHeader initially, and then by the
		/// parseImageFileDirectory for any consecutive IFD's. </summary>
		private long nextIFD_Offset;

		/// <summary> Hashtable which holds the names and tags
		/// of all the valid TIFF headers of interest. </summary>
		private static Hashtable validTags;

		/// <summary> Hashtable used to look up a directory entry
		/// from a specified tag number. </summary>
		private Hashtable directoryEntriesTable;

		/// <summary> ArrayList which holds all the valid
		/// directoryEntries found in the currentTIFF file. </summary>
		private ArrayList directoryEntries;

/*==========================================================================
 *				CONSTRUCTORS for the TiffInfo Class
 *=========================================================================*/

		/// <summary> Constructor of the TiffInfo class which accepts
		/// the name of a TIF file as a parameter.  This constructor then reads
		/// the header of the TIFF file. </summary>
		/// <param name="fileName"> Name of the file to check </param>
		/// <remarks> This reads the TIFF header during construction </remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public TiffInfo( string fileName )
		{
			// Populate the validTags HashTable with every valid tag
			// of interest.
			populateValidTags();

			// Store the current fileName and read the header
			this.fileName = fileName;
			readHeader( fileName );
		}

		/// <summary> Constructor of the TiffInfo class </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public TiffInfo(  )
		{
			// Populate the validTags HashTable with every valid tag
			// of interest.
			populateValidTags();

			// Store a blacnk in fileName
			fileName = "";
		}

/*==========================================================================
 *				PUBLIC PROPERTIES of the TiffInfo Class
 *=========================================================================*/

		/// <summary> Returns TRUE if this is a valid TIFF file. </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public bool ValidTIFF	{	get	{	return !invalidTIFF;	}	}
		
		/// <summary> Returns a string which indicates whether this is INTEL, MOTOROLA,
		/// or INVALID byte order. </summary>
		/// <remarks> Returns one of the following:  <ul>
		/// <li type="circle" /> INVALID
		/// <li type="circle" /> INTEL
		/// <li type="circle" /> MOTOROLA
		/// </ul></remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string ByteOrder
		{
			get
			{
				// If an invalid TIFF, return "INVALID"
				if ( invalidTIFF )
					return "INVALID";

				// Return the byte order for this valid TIFF
				if ( intelTIFF )
					return "INTEL";
				else
					return "MOTOROLA";
			}
		}

		/// <summary> Returns TRUE if this image is compressed, otherwise FALSE  </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public bool Compressed
		{	
			get
			{
				// Check to see if this image is compressed
				if ( getLongTagValue( 259 ) == 1 ) return false;
				else return true;
			}
		}

		/// <summary> Gets the type of compression as a string </summary>
		/// <remarks> Returns one of the following:  <ul>
		/// <li type="circle" /> Uncompressed
		/// <li type="circle" /> CCITT ID
		/// <li type="circle" /> Group 3 Fax
		/// <li type="circle" /> Group 4 Fax
		/// <li type="circle" /> LZW
		/// <li type="circle" /> JPEG
		/// <li type="circle" /> PackBits
		/// <li type="circle" /> NOT PRESENT
		/// <li type="circle" /> Unknown Compression
		/// </ul></remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string Compression
		{
			get
			{
				switch ( getLongTagValue( 259 ) )
				{
					case 1:		return "Uncompressed";
					case 2:		return "CCITT ID";
					case 3:		return "Group 3 Fax";
					case 4:		return "Group 4 Fax";
					case 5:		return "LZW";
					case 6:		return "JPEG";
					case 32773:	return	"PackBits";
					case -1:	return "NOT PRESENT";
					default:	return "Unknown Compression";
				}
			}
		}

		/// <summary> Gets the type of photometric interpretation </summary>
		/// <remarks> Returns one of the following:  <ul>
		/// <li type="circle" /> WhiteIsZero
		/// <li type="circle" /> BlackIsZero
		/// <li type="circle" /> RGB
		/// <li type="circle" /> RGB Palette
		/// <li type="circle" /> Transparency mask
		/// <li type="circle" /> CMYK
		/// <li type="circle" /> YCbCr
		/// <li type="circle" /> CIELab
		/// <li type="circle" /> NOT PRESENT
		/// <li type="circle" /> Unknown Interpretation
		/// </ul></remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string PhotometricInterpretation
		{
			get
			{
				switch ( getLongTagValue( 262 ) )
				{
					case 0:		return "WhiteIsZero";
					case 1:		return "BlackIsZero";
					case 2:		return "RGB";
					case 3:		return "RGB Palette";
                    case 4:		return "Transparency mask";
					case 5:		return "CMYK";
					case 6:		return "YCbCr";
					case 7:		return "CIELab";
					case -1:	return "NOT PRESENT";
					default:	return "Unknown Interpretation";
				}
			}
		}

		/// <summary> Gets the unit for the resolution </summary>
		/// <remarks> Returns one of the following:  <ul>
		/// <li type="circle" /> none
		/// <li type="circle" /> inch
		/// <li type="circle" /> centimeter
		/// <li type="circle" /> NOT PRESENT
		/// <li type="circle" /> Unknown Resolution Unit
		/// </ul></remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string ResolutionUnit
		{
			get
			{
				switch ( getLongTagValue( 296 ) )
				{
					case 1:		return "none";
					case 2:		return "inch";
					case 3:		return "centimeter";
					case -1:	return "NOT PRESENT";
					default:	return "Unknown Resolution Unit";
				}
			}
		}

		/// <summary> Gets the type of planar configuration </summary>
		/// <remarks> Returns one of the following:  <ul>
		/// <li type="circle" /> chunky
		/// <li type="circle" /> planar
		/// <li type="circle" /> unknown
		/// <li type="circle" /> Unknown Planar Configuration
		/// </ul></remarks>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string PlanarConfiguration
		{
			get
			{
				switch ( getLongTagValue( 284 ) )
				{
					case 1:		return "chunky";
					case 2:		return "planar";
					case -1:	return "unknown";
					default:	return "Unknown Planar Configuration";
				}
			}
		}

		/// <summary> Gets the width of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int ImageWidth	
		{	get	{	return Convert.ToInt32(getLongTagValue( 256 ));	}	}

		/// <summary> Gets the height of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int ImageHeight	
		{	get	{	return Convert.ToInt32(getLongTagValue( 257 ));	}	}

		/// <summary> Gets the X resolution of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int XResolution	
		{	get	{	return Convert.ToInt32(getLongTagValue( 282 ));	}	}

		/// <summary> Gets the Y resolution of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int YResolution	
		{	get	{	return Convert.ToInt32(getLongTagValue( 283 ));	}	}

		/// <summary> Gets the bits per sample of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string BitsPerSample	
		{
			get	
			{	
				try 
				{ 
					// Save the value of the tag which gives bits per sample
					long val = getLongTagValue( 258 );

					// If this is 8,8,8, return that
					if ( val == 34360262664 )
						return "8,8,8";

					// Check for 16,16,16
					if ( val == 68720525328 )
						return "16,16,16";

					// Try to convert this to an integer and return that value
					return Convert.ToInt32(getLongTagValue( 258 )).ToString();
				}
				catch
				{
					int blackAndWhiteCheck = Convert.ToInt32(getLongTagValue( 262 ));

					// Return 16 if this is 2
					if ( blackAndWhiteCheck == 2 )
						return "16";
					
					// Return 8 if this is either 0 or 1
					if (( blackAndWhiteCheck == 0 ) || ( blackAndWhiteCheck == 1 ))
						return "8";
					
					// Default, return this
					return "8,8,8";
				}
			}
		}

		/// <summary> Gets the samples per pixel of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int SamplesPerPixel	
		{	get	{	return Convert.ToInt32(getLongTagValue( 277 ));	}	}

		/// <summary> Gets the strip offsets of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public long StripOffsets	
		{	get	{	return getLongTagValue( 273 );	}	}

		/// <summary> Gets the rows per strip of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public int RowsPerStrip
		{	get	{	return Convert.ToInt32(getLongTagValue( 278 ));	}	}

		/// <summary> Gets the strip byte count of the current image </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public long StripByteCounts
		{	get	{	return Convert.ToInt32(getLongTagValue( 279 ));	}	}

		/// <summary> Gets or sets the current TIFF file. </summary>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public string FileName
		{
			get	{	return fileName;	}
			set	{	NextFile( value );	}
		}


/*==========================================================================
 *				PUBLIC METHODS of the TiffInfo Class
 *=========================================================================*/

		/// <summary> Method which tells this TiffInfo object to read a 
		/// new TIFF file.  This will read all of the header information.</summary>
		/// <param name="fileName"> TRUE if a valid TIFF file, otherwise FALSE </param>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public bool NextFile( string fileName )
		{
			// Store the current fileName and read the header
			this.fileName = fileName;
			return readHeader( fileName );
		}

		/// <summary> Method returns -1 or the tag value if the tag was
		/// present in the current header. </summary>
		/// <param name="tagNumber"> Number for the tag in the TIFF specs </param>
		/// <returns> Value as a long </returns>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		public long TagValue( int tagNumber )
		{
			return getLongTagValue( tagNumber );
		}


/*==========================================================================
 *				PRIVATE METHODS of the TiffInfo Class
 *=========================================================================*/
		
		/// <summary> Private method which accepts the name of the TIFF file
		/// to check and reads all the header information. </summary>
		/// <param name="fileToRead"> Name of the file to check </param>
		/// <returns> TRUE if this is a valid TIFF file, otherwise FALSE </returns>
		/// <example> To see an example, look under the main <see cref="TiffInfo"/> class. </example>
		private bool readHeader( string fileToRead )
		{
			// Declare new objects for this file
			FileStream TiffFile;
			directoryEntries = new ArrayList();
			directoryEntriesTable = new Hashtable();

			try
			{
				// Open a fileStream to the specified file
				TiffFile = new FileStream( fileToRead, FileMode.Open, FileAccess.Read, FileShare.Read );
			}
			catch
			{
				return false;
			}

			// Declare a new 12 byte array to hold the Image File Header info
			byte[] ImageFileHeader = new byte[12];

			// Read in the first 12 bytes from the file
			TiffFile.Read( ImageFileHeader, 0, 12 );

			// Parse the Image File Header and continue if it is valid
			if ( parseImageFileHeader( ImageFileHeader ) )
			{
				// Define variables needed to read the ImageFileDirectories
				int directoryEntryCount, directoryLength;
				byte[] ImageFileDirectory;

				// Collect all of the Image File Directory information from this file
				while( nextIFD_Offset != -1 )
				{
					// Go to the next Image File Directory and read the
					// number of directory entries in this IFD
					TiffFile.Position = nextIFD_Offset;
					directoryEntryCount = TiffFile.ReadByte() + (TiffFile.ReadByte() * 256);
					directoryLength = ( directoryEntryCount * 12 ) + 4;

					// Now define the new byte buffer and read all the bytes in
					ImageFileDirectory = new byte[ directoryLength ];
					TiffFile.Read( ImageFileDirectory, 0, directoryLength );

					// Now, parse this ImageFileDirectory 
					parseImageFileDirectory( ImageFileDirectory, directoryEntryCount );
				}

				// Now, go through each directoryEntry object and obtain the
				// values from any offsets which existed, as well as place it into
				// the directoryEntryTable 
				DirectoryEntry thisEntry;
				for ( int i = 0 ; i < directoryEntries.Count ; i++ )
				{
					// Pull out this entry for changing
					thisEntry = ((DirectoryEntry) directoryEntries[i]);
					byte[] valueBytes;
					long computedValue;

					// See if this has a non-negative offset
					if ( thisEntry.Offset > 0 )
					{
						// Go to this position in the file and read the number
						// of bytes indicated
						TiffFile.Position = thisEntry.Offset;
						valueBytes = new byte[ thisEntry.Length ];
						TiffFile.Read( valueBytes, 0, Convert.ToInt32(thisEntry.Length ));

						// Now, determine this value
						computedValue = 0;

						// must treat the type 'Rational' different from all others
						if ( thisEntry.Type.Equals("RATIONAL") )
						{
							long numerator = byteArrayToLong( valueBytes, 0 );
							long denominator = byteArrayToLong( valueBytes, 4 );
							computedValue = ((long) numerator / denominator);
						}
						else
						{	// Not of type 'Rational'
							for ( int j = 1 ; j <= thisEntry.Length ; j++ )
								computedValue = ( computedValue * 256) + valueBytes[ thisEntry.Length - j ];
						}

						// Assign this value to the directoryEntry
						thisEntry.Value = computedValue;
					}

					// Next, add this directoryEntry to the HashTable
                    if (!directoryEntriesTable.ContainsKey(thisEntry.Tag))
                    {
                        directoryEntriesTable.Add(thisEntry.Tag, thisEntry);
                    }
				}
			}

			// Now, close the connection to the file and return true
			TiffFile.Close();
			return true;
		}

		/// <summary> Private method which parses a Image File Directory and fills
		/// the DirectoryEntries ArrayList with the directories from this IFD.  ALso
		/// computes the value (or -1) of the next IFD in the file.</summary>
		/// <param name="IFD"> Variable length array of bytes read from the file </param>
		/// <param name="entries"> Number of entries in this IFD </param>
		private void parseImageFileDirectory( byte[] IFD, int entries )
		{
			// Define a new DirectoryEntry object
			DirectoryEntry newEntry;
			int pos = 0;

			// Now, collect all of the directory entries
			for ( int i = 0 ; i < entries ; i++ )
			{
				// Define the next directoryEntry object 
				newEntry = new DirectoryEntry( new byte[] {IFD[pos], IFD[pos+1], IFD[pos+2], IFD[pos+3], 
					IFD[pos+4], IFD[pos+5], IFD[pos+6], IFD[pos+7], IFD[pos+8], IFD[pos+9], IFD[pos+10], IFD[pos+11] } );

				// Add this to the ArrayList of directoryEntries
				directoryEntries.Add( newEntry );

				// Increment the position in the byte buffer to look at the next DirectoryEntry
				pos = pos + 12;
			}

			// All the directory entries have been collected, so collect the next 4
			// bytes which indicate if this points to another IFD, or if this is null
			long nextData = byteArrayToLong( IFD, pos );
			if ( nextData > 0 )
                nextIFD_Offset = nextData;
			else
				nextIFD_Offset = -1;
		}

		/// <summary> Private method which parses the 12 byte ImageFileHeader
		/// and checks for byte order, version, and gets the offset to the 
		/// first Image File Directory. </summary>
		/// <param name="IFH"> 12 byte ImageFileHeader from the TIFF </param>
		/// <returns> FALSE if there was a problem with the header, otherwise
		/// returns TRUE </returns>
		private bool parseImageFileHeader( byte[] IFH )
		{
			// Set the initial flags
			invalidTIFF = false;
			intelTIFF = true;
			nextIFD_Offset = -1;

			// Make sure file is valid TIFF by checking for valid Byte Order 
			// 73 = INTEL, 77 = MOTOROLA, also make sure the first two bytes
			// are the same
			if ((( IFH[0] != 73 ) && ( IFH[0] != 77 )) || ( IFH[0] != IFH[1] ))
			{
				// The first byte is invalid, so this is an invalid TIFF
				this.invalidTIFF = true;
				return false;
			}
			else
			{
				// The first byte indicates this is either an INTEL or MOTOROLA order
				if ( IFH[0] == 77 )
				{
					// This is MOTOROLA byte order
					intelTIFF = false;
					return false;
				}
			}

			// Now, check for the header version number.  This should be '42 0'
			if (( IFH[2] != 42 ) || ( IFH[3] != 0 ))
			{
				// The version number is not '42 0', so not a valid TIFF
				this.invalidTIFF = true;
				return false;
			}

			// Get the offset to the first ImageFileDirectory from the next 4 bytes
			nextIFD_Offset = byteArrayToLong( IFH, 4 );
            
			// No error was encountered, so this appears to be a valid Image File Header
			return true;
		}

		/// <summary> Private method which returns the long value (or -1)
		/// for a specified tag number. </summary>
		/// <param name="valueNumber"> Tag number </param>
		/// <returns> Tag value as a long </returns>
		private long getLongTagValue ( int valueNumber )
		{
			// If no file has been specified, or the file is invalid, return -1;
			if (( fileName.Equals("") ) || ( invalidTIFF ))
				return -1;

			// Valid TIFF, so make sure this directory entry exists
			if ( !directoryEntriesTable.ContainsKey( valueNumber ))
				return -1;

			// Valid TIFF and a directory entry exists
			return ((DirectoryEntry) directoryEntriesTable[ valueNumber ] ).Value;
		}

		/// <summary> Private helper method which returns the computed long
		/// value from the next four bytes after the indicated offset. </summary>
		/// <param name="byteArray"> Array of bytes </param>
		/// <param name="offset"> Initial offset in array </param>
		/// <returns> Value as a long </returns>
		private long byteArrayToLong( byte[] byteArray, int offset )
		{
			// Compute the long value from the next four bytes in the byte array
			long value = byteArray[offset] + ( byteArray[offset+1] * 256 );
			value += ( byteArray[offset+2] * 65536) + ( byteArray[offset+3] * 16777216 );

			// return the value
			return value;
		}

		/// <summary> Private method which populates the validTags HashTable with 
		/// all of the valid, common tags to read from the TIFF Header. </summary>
		private void populateValidTags( )
		{
			// Define the new HashTable
			validTags = new Hashtable();

			// Add all valid tags to the validTags HashTable
			validTags.Add(254, "NewSubfileType");
			validTags.Add(255,"SubfileType");
			validTags.Add(256,"ImageWidth");
			validTags.Add(257,"ImageLength");
			validTags.Add(258,"BitsPerSample");
			validTags.Add(259,"Compression");
			validTags.Add(262,"PhotometricInterpretation");
			validTags.Add(263,"Threshholding");
			validTags.Add(264,"CellWidth");
			validTags.Add(265,"CellLength");
			validTags.Add(266,"FillOrder");
			validTags.Add(269,"DocumentName");
			validTags.Add(270,"ImageDescription");
			validTags.Add(271,"Make");
			validTags.Add(272,"Model");
			validTags.Add(273,"StripOffsets");
			validTags.Add(274,"Orientation");
			validTags.Add(277,"SamplesPerPixel");
			validTags.Add(278,"RowsPerStrip");
			validTags.Add(279,"StripByteCounts");
			validTags.Add(280,"MinSampleValue");
			validTags.Add(281,"MaxSampleValue");
			validTags.Add(282,"XResolution");
			validTags.Add(283,"YResolution");
			validTags.Add(284,"PlanarConfiguration");
			validTags.Add(285,"PageName");
			validTags.Add(286,"XPosition");
			validTags.Add(287,"YPosition");
			validTags.Add(288,"FreeOffsets");
			validTags.Add(289,"FreeByteCounts");
			validTags.Add(290,"GrayResponseUnit");
			validTags.Add(291,"GrayResponseCurve");
			validTags.Add(292,"T4Options");
			validTags.Add(293,"T6Options");
			validTags.Add(296,"ResolutionUnit");
			validTags.Add(297,"PageNumber");
			validTags.Add(301,"TransferFunction");
			validTags.Add(305,"Software");
			validTags.Add(306,"DateTime");
			validTags.Add(315,"Artist");
			validTags.Add(316,"HostComputer");
			validTags.Add(317,"Predictor");
			validTags.Add(318,"WhitePoint");
			validTags.Add(319,"PrimaryChromaticities");
			validTags.Add(320,"ColorMap");
			validTags.Add(321,"HalftoneHints");
			validTags.Add(322,"TileWidth");
			validTags.Add(323,"TileLength");
			validTags.Add(324,"TileOffsets");
			validTags.Add(325,"TileByteCounts");
			validTags.Add(332,"InkSet");
			validTags.Add(333,"InkNames");
			validTags.Add(334,"NumberOfInks");
			validTags.Add(336,"DotRange");
			validTags.Add(337,"TargetPrinter");
			validTags.Add(338,"ExtraSamples");
			validTags.Add(339,"SampleFormat");
			validTags.Add(340,"SMinSampleValue");
			validTags.Add(341,"SMaxSampleValue");
			validTags.Add(342,"TransferRange");
			validTags.Add(512,"JPEGProc");
			validTags.Add(513,"JPEGInterchangeFormat");
			validTags.Add(514,"JPEGInterchangeFormatLength");
			validTags.Add(515,"JPEGRestartInterval");
			validTags.Add(517,"JPEGLosslessPredictors");
			validTags.Add(518,"JPEGPointTransforms");
			validTags.Add(519,"JPEGQTables");
			validTags.Add(520,"JPEGDCTables");
			validTags.Add(521,"JPEGACTables");
			validTags.Add(529,"YCbCrCoefficients");
			validTags.Add(530,"YCbCrSubSampling");
			validTags.Add(531,"YCbCrPositioning");
			validTags.Add(532,"ReferenceBlackWhite");
			validTags.Add(33432,"Copyright");
		}

/*=========================================================================================
 *  DirectoryEntry class definition
 *			Internal class used to hold the data for a single Directory Entry
 *========================================================================================*/

		/// <summary> Internal class used to hold the data for a single Directory Entry from the TIFF header for the TiffInfo object. </summary>
		/// <remarks>  Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.  </remarks>
		private class DirectoryEntry
		{
			/// <summary> Private data members which hold the information from 
			/// this directory entry.</summary>
			private int tag, type;

			/// <summary> Private data members which hold the information from 
			/// this directory entry.</summary>
			private long length, dataValue, dataOffset;

			/// <summary> Constant object which holds the length information for
			/// each type of tag type. </summary>
			private static int[] typeLength = new int[13] { -1, 1, 1, 2, 4, 8, 1, 1, 2, 4, 8, 4, 8 };

			/// <summary> Constant array which holds the names of each type of tag </summary>
			private static string[] typeNames = new string[13] { "", "BYTE", "ASCII", "SHORT", "LONG", "RATIONAL", "SBYTE", "UNDEFINED", "SSHORT", "SLONG", "SRATIONAL", "FLOAT", "DOUBLE" };

			/// <summary> Constructor for the DirectoryEntry class </summary>
			/// <param name="bytes"> 12 byte Directory Entry from TIFF file </param>
			public DirectoryEntry ( byte[] bytes )
			{
				// First, assign the values for this tag, type, and length
				tag = bytes[0] + ( bytes[1] * 256 );
				type = bytes[2] + ( bytes[3] * 256 );
				length = bytes[4] + ( bytes[5] * 256 ) + ( bytes[6] * 65536 ) + ( bytes[7] * 16777216 );
				length = length * typeLength[type];

				// Assign default values to dataValue and dataOffset
				dataValue = -1;
				dataOffset = -1;

				// Now, determine if the next value is an offset or datavalue
				int nextData = bytes[8] + ( bytes[9] * 256 ) + ( bytes[10] * 65536 ) + ( bytes[11] * 16777216 );
				if ( length <= 4 )
					dataValue = nextData;
				else
					dataOffset = nextData;
			}

			/// <summary> Property returns the length of the data for this entry </summary>
			public long Length	{	get	{	return length; }		}

			/// <summary> Property returns the value from this entry </summary>
			public long Offset	{	get	{ return dataOffset; }		}

			/// <summary> Property returns the tag number for this entry </summary>
			public int Tag		{	get	{ return tag; }		}

			/// <summary> Property returns the name of the tag for this entry </summary>
			public string TagName 
			{
				get
				{
					// If this is a valid tag, return the name, otherwise "UNDEFINED";
					if ( ValidTag ) return validTags[ tag ].ToString();
					else return "UNDEFINED";
				}
			}

			/// <summary> Returns the name of this type </summary>
			public string Type	{	get	{	return typeNames[ type ];	}	}

			/// <summary> Property returns TRUE if the tag is valid, otherwise FALSE </summary>
			public bool ValidTag	{	get	{	return validTags.ContainsKey( tag );	}	}

			/// <summary> Gets or sets the value from this entry </summary>
			public long Value	{	get	{	return dataValue;	}		
				set {	dataValue = value;	}	
			}
		}
	}
}
