#region Using directives

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// 
	/// Creates a Cursor from any bitmap. You can use the alpha-channel
	/// for transparency effects.
	/// 
	public class BitmapCursor : IDisposable
	{
		#region Win-API imports

		/// 
		/// API-Structure ICONINFO
		/// 
		/// 
		[StructLayout(LayoutKind.Sequential)]
			public struct ICONINFO
		{
			public bool fIcon;
			public uint xHotspot;
			public uint yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;
		}

		/// 
		/// API function CreateIconIndirect
		/// 
		[DllImport("USER32.DLL")]
		public static extern IntPtr CreateIconIndirect( ref ICONINFO iconinfo );
		/// 
		/// API function DestryIcon
		/// 
		[DllImport("USER32.DLL")]
		public static extern bool DestroyIcon( IntPtr hIcon );

		#endregion

		#region private

		private ICONINFO iconInfo;
		private Cursor cursor;
		private IntPtr handle = IntPtr.Zero;

		private void Create()
		{
			handle = CreateIconIndirect( ref iconInfo );
			cursor = new Cursor( handle );
		}


		#endregion

		#region constructors and destructor

		public BitmapCursor( Bitmap bmp, int HotSpotX, int HotSpotY )
		{
			iconInfo = new ICONINFO();
			iconInfo.fIcon = false;
			iconInfo.xHotspot = 0;
			iconInfo.yHotspot = 0;
			iconInfo.hbmMask = bmp.GetHbitmap();
			iconInfo.hbmColor = bmp.GetHbitmap();
			Create();
		}
		/// 
		/// Creates a cursor from a bitmap and combines it with another cursor.
		/// 
		public BitmapCursor( Bitmap bmp, Cursor Cursor )
		{
			iconInfo = new ICONINFO();
			iconInfo.fIcon = false;
			iconInfo.xHotspot = 0;
			iconInfo.yHotspot = 0;
			using( Bitmap bmpdup = bmp.Clone() as Bitmap )
			{
				using( Graphics g = Graphics.FromImage( bmpdup ) )
				{
					Cursor.Draw( g, new Rectangle( new Point( 0, 0 ), Cursor.Size ) );
				}
				iconInfo.hbmMask = bmpdup.GetHbitmap();
				iconInfo.hbmColor = bmpdup.GetHbitmap();
				Create();
			}
		}


		/// 
		/// destructor
		/// 
		~BitmapCursor()
		{
			Dispose( false );
		}

		#endregion

		#region virtual methods

		/// 
		/// clean up resources
		/// 
		protected virtual void Dispose( bool disposing )
		{
			try
			{
				if( handle != IntPtr.Zero )
					DestroyIcon( handle );
			}
			catch
			{
			}
		}


		#endregion

		#region public properties

		/// 
		/// The Cursor-Object you can use
		/// 
		public Cursor Cursor
		{
			get
			{
				return cursor;
			}
		}


		#endregion

		#region IDisposable Member

		/// 
		/// free the used handles
		/// 
		public void Dispose()
		{
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		#endregion
	}
}
