using System;
using System.Data;
using System.Management;

namespace DLC.Tools.IO
{
	/// <summary> Class allows access to all the drives connected to the local computer <br /> <br /> </summary>
	/// <remarks> Written for University of Florida Digital Library Center </remarks>
	public class Connected_Drives
	{
		private static myDriveInfo_Collection driveCollection;

		/// <summary> Static constructor for this class </summary>
		static Connected_Drives()
		{
			// Define the collection
			driveCollection = new myDriveInfo_Collection();

			// Populate the drives
			populate_drive_collection();
		}

		/// <summary> Refresh to populate the drive collection anew </summary>
		public static void Refresh()
		{
			// Populate the drives
			populate_drive_collection();
		}

		/// <summary> Gets the collection of drives attached to this </summary>
		public static myDriveInfo_Collection Drives
		{
			get	{	return driveCollection;		}
		}

		/// <summary> Gets the collection of CD drives connected to this machine </summary>
		public static myDriveInfo_Collection CD_Drives
		{
			get
			{
				// Create a return collection
				myDriveInfo_Collection returnVal = new myDriveInfo_Collection();

				// Step through each drive
				foreach( myDriveInfo thisDrive in driveCollection )
				{
					if ( thisDrive.Type == Drive_Type.Compact_Disk )
					{
						returnVal.Add( new myDriveInfo( thisDrive.Name, thisDrive.VolumeName, thisDrive.VolumeSerialNumber, thisDrive.Type ));
					}
				}

				// Return these
				return returnVal;
			}
		}

		/// <summary> Gets the collection of portable hard drives connected to this machine </summary>
		public static myDriveInfo_Collection Portable_Hard_Drives( DataTable AllPortables )
		{
			// Create a return collection
			myDriveInfo_Collection returnVal = new myDriveInfo_Collection();

			if ( AllPortables != null )
			{
				// Step through each drive
				DataRow[] selected;
				foreach( myDriveInfo thisDrive in driveCollection )
				{	
					// See if there is a match in the database (i.e., is this a portable)
					selected = AllPortables.Select("SerialNumber = '" + thisDrive.VolumeSerialNumber + "'" );
					if ( selected.Length > 0 )
					{
						returnVal.Add( new myDriveInfo( thisDrive.Name, thisDrive.VolumeName, thisDrive.VolumeSerialNumber, thisDrive.Type ));
					}
				}
			}

			// Return these
			return returnVal;
		}

		private static void populate_drive_collection()
		{
			// Clear the drive collection
			driveCollection.Clear();

			// Get collection of drives attached to this machine
			ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT Name, VolumeName, VolumeSerialNumber, DriveType From Win32_LogicalDisk"); 
			ManagementObjectCollection queryCollection = query.Get(); 

			// Step through each drive connected to this computer
			myDriveInfo localDrive;
			string name, drive, serial;
			foreach( ManagementObject mo in queryCollection ) 
			{
				// Get the volume name
				if (( mo["VolumeName"] == null ) || ( mo["VolumeName"].ToString().Length == 0 ))
					name = "UNLABELED";
				else
                    name = mo["VolumeName"].ToString();

				// Get the drive name
				drive = mo["Name"].ToString();

				// Get the serial number
				if (( mo["VolumeSerialNumber"] == null ) || ( mo["VolumeSerialNumber"].ToString().Length == 0 ))
					serial = "NO SERIAL";
				else
					serial = mo["VolumeSerialNumber"].ToString();

				// Add this as a new drive
				localDrive = new myDriveInfo( drive, name, serial, Convert.ToInt32( mo["DriveType"] ));
				driveCollection.Add( localDrive );
			}
		}
	}
}

