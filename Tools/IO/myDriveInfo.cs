using System;

namespace DLC.Tools.IO
{
	/// <summary> Enumeration tells the type of drive </summary>
	public enum Drive_Type
	{
		/// <summary> Unknown or unrecognized type </summary>
		Unknown = 0,

		/// <summary> No root directory found on this drive! </summary>
		No_Root_Directory,

		/// <summary> Removable disk </summary>
		/// <remarks> Removable hard drives do NOT appear as removable disks! </remarks>
		Removable_Disk,

		/// <summary> Local, fixed, disk drive </summary>
		Local_Disk,

		/// <summary> Network drive mapped to this machine </summary>
		Network_Drive,

		/// <summary> Compact Disk (or DVD) Drive </summary>
		Compact_Disk,

		/// <summary> RAM disk in memory </summary>
		RAM_Disk
	}

	/// <summary> Class holds all the information about a single drive <br /> <br /> </summary>
	/// <remarks> Written by Mark Sullivan (2005) </remarks>
	public class myDriveInfo
	{
		/// <summary> Name of the drive (i.e. 'A:', 'C:' ) </summary>
		public readonly string Name;

		/// <summary> Name of this volume </summary>
		public readonly string VolumeName;

		/// <summary> Serial number for this volume </summary>
		public readonly string VolumeSerialNumber;

		/// <summary> Type of drive </summary>
		public readonly Drive_Type Type;

		/// <summary> Constructor for a new instance of this class </summary>
		/// <param name="Name"> Name of this drive </param>
		/// <param name="VolumeName"> Name of the volume itself </param>
		/// <param name="VolumeSerialNumber"> Serial number for this volume </param>
		/// <param name="Type"> Type of this drive </param>
		public myDriveInfo( string Name, string VolumeName, string VolumeSerialNumber, int Type )
		{
			// Save the parameters
			this.Name = Name;
			this.VolumeName = VolumeName;
			this.VolumeSerialNumber = VolumeSerialNumber;
			this.Type = (Drive_Type) Type;
		}

		/// <summary> Constructor for a new instance of this class </summary>
		/// <param name="Name"> Name of this drive </param>
		/// <param name="VolumeName"> Name of the volume itself </param>
		/// <param name="VolumeSerialNumber"> Serial number for this volume </param>
		/// <param name="Type"> Type of this drive </param>
		public myDriveInfo( string Name, string VolumeName, string VolumeSerialNumber, Drive_Type Type )
		{
			// Save the parameters
			this.Name = Name;
			this.VolumeName = VolumeName;
			this.VolumeSerialNumber = VolumeSerialNumber;
			this.Type = Type;
		}
	}
}
