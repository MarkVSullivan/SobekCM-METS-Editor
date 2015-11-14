using System;
using System.IO;

namespace DLC.Tools.IO
{
	/// <summary> Holds the data about a volume folder <br /> <br /> </summary>
	/// <remarks> Written by Mark Sullivan (2005) for UF Digital Library Center </remarks>
	public class Volume_Folder_Info
	{
		private string bibFolder;
		private string volumeFolder;
		private string errorstring;
		private string subfolder;
		private object userDefinable;
		private string bibid, vid;

		/// <summary> Constructor for a new instance of this class </summary>
		/// <param name="Bib_Folder"> Absolute directory for the bib id folder </param>
		/// <param name="Volume_Folder"> Absolute directory for the volume folder </param>
		public Volume_Folder_Info( string Bib_Folder, string Volume_Folder )
		{
			// Save these parameters
			this.bibFolder = Bib_Folder;
			this.volumeFolder = Volume_Folder;
			bibid = ( new DirectoryInfo( bibFolder )).Name;
            if (Volume_Folder.Length > 0)
            {
                vid = (new DirectoryInfo(volumeFolder)).Name.ToUpper().Replace("VID", "");
            }

			// Set the error string initially to empty
			this.errorstring = String.Empty;

			// Compute the subfolder variable
			compute_subfolder();
		}

		/// <summary> Constructor for a new instance of this class </summary>
		/// <param name="Bib_Folder"> Absolute directory for the bib id folder </param>
		/// <param name="Volume_Folder"> Absolute directory for the volume folder </param>
		/// <param name="ReceivingID"> Receiving ID for this bib id </param>
		/// <param name="Error"> Error encountered with this folder </param>
		/// <remarks> This constructor is used when the top folder is a valid bib id, but
		/// the volume indicated is not valid. </remarks>
		public Volume_Folder_Info( string Bib_Folder, string Volume_Folder, string Error )
		{
			// Save these parameters
			this.bibFolder = Bib_Folder;
			this.volumeFolder = Volume_Folder;
			this.errorstring = Error;
			bibid = ( new DirectoryInfo( bibFolder )).Name;
            if (Volume_Folder.Length > 0)
            {
                vid = (new DirectoryInfo(volumeFolder)).Name.ToUpper().Replace("VID", "");
            }

			// Compute the subfolder variable
			compute_subfolder();
		}

		/// <summary> Compute the name of the subfolder(s) </summary>
		private void compute_subfolder()
		{
			// Get the last folder from the bib, which should be the bib id
			string sub1 = (new DirectoryInfo( bibFolder )).Name;
			string sub2 = volumeFolder.Replace( bibFolder, "" );
			subfolder = sub1 + sub2;
		}

		/// <summary> Gets and sets the user definable field </summary>
		public object User_Definable_Field
		{
			get	{	return userDefinable;		}
			set	{	userDefinable = value;		}
		}

		/// <summary> Gets the subfolder(s) for this bib and volume </summary>
		public string Subfolder
		{
			get	{	return subfolder;	}
			set	{	subfolder = value;	}
		}

		/// <summary> Gets the Bib ID (or top-level) folder's absolute address </summary>
		public string Bib_Folder
		{
			get	{	return bibFolder;	}
			set	{	bibFolder = value;	}
		}

		/// <summary> Gets the Volume (or second-level) folder's absolute address </summary>
		public string Volume_Folder
		{
			get	{	return volumeFolder;	}
			set	{	volumeFolder = value;	}
		}

		/// <summary> Gets the error string, if one was encountered here </summary>
		public string Error
		{
			get	{	return errorstring;	}
            set { errorstring = value; }
		}

		/// <summary> Gets a flag indicating if an error was encountered with this folder </summary>
		public bool Error_Encountered
		{
			get	{	return ( errorstring.Length > 0 );		}
		}

		/// <summary> Gets the type of this resource </summary>
		public string Type
		{
			get	
			{
				return "Text";
			}
		}

		/// <summary> Gets the BIB ID for this volume folder </summary>
		public string BibID
		{
			get	{	return bibid;			}
		}

        /// <summary> Gets the VID for this volume folder </summary>
		public string VID
		{
			get	{	return vid;		}
            set { vid = value.ToUpper().Replace("VID", ""); }
		}

		public override bool Equals( object ObjectToCheck )
		{
			// If this is a string, just see if the volume id's match
			if ( ObjectToCheck is string )
			{
				if ( this.ToString().Equals( ObjectToCheck ) )
					return true;
			}

			// Must be same class at least
			if ( ObjectToCheck is Volume_Folder_Info )
			{
				Volume_Folder_Info check = (Volume_Folder_Info) ObjectToCheck;
				if (( check.BibID == this.BibID ) && ( check.VID == this.VID ))
				{
					return true;
				}
				else
				{
					if ( check.Volume_Folder == this.Volume_Folder )
					{
						return true;
					}
				}

				// Otherwise, return false
				return false;
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			return this.BibID + ":" + this.VID;
		}
	}
}
