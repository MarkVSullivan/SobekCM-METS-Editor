using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace DLC.Tools.StartUp
{
	/// <summary> SingleProgramInstance is an object which is used to ensure that only one instance
	/// of this application is running at one time.  <br /> <br /> </summary> 
	/// <remarks> Upon construction of this object, a unique string identifier is passed to minimize the 
	/// impact of two DIFFERENT applications which happen to have the same name.<br /><br />
	/// This object works by using the C# object <see cref="Mutex"/>.  It attempts to gain ownership of the <see cref="Mutex"/>
	/// for the current application during the construction process. If <see cref="Mutex"/> becomes owned, then this
	/// is the only instance of this application running.  The <see cref="Mutex"/> will remain owned until this
	/// object is deconstructed.<br /> <br />
	/// This class implements the <see cref="IDisposable"/> interface.  <br /> <br />
	/// Object created by Mark V Sullivan (2003) for University of Florida's Digital Library Center.   </remarks>
	/// <example>
	/// The example below checks to make sure there are no other instances of itself running before proceeding.
	/// <code>
	/// <SPAN class="lang">[C#]</SPAN> 
	///	using System;
	///	using GeneralTools.Logs;
	///	using GeneralTools.StartUp;
	///
	///	namespace DLC.Tools
	///	{
	///		public class SingleProgrammingInstance_Example
	///		{
	///			static void Main() 
	///			{
	///				// Create the MUTEX object to ensure no collisions
	///				SingleProgramInstance myMutex = new SingleProgramInstance("l7$2sh");
	///
	///				// Ensure this is the only instance running.
	///				if ( myMutex.IsSingleInstance )
	///				{
	///					// This is the only instance of this application running
	///				
	///					// PERFORM NEEDED WORK HERE
	///
	///					// No need to release the mutex explicitly, since it will be Disposed (Implements IDisposable)
	///				}
	///				else
	///				{
	///					// This already has an instance running, so add an event in the Windows log and close
	///					EventLogger.FailureAudit("Attempted to launch this application, but couldn't get MUTEX", "Example Program");
	///				}
	///			}
	///		}
	///	} 
	/// </code> </example>
	public class SingleProgramInstance: IDisposable
	{
		/// <summary> <see cref="Mutex"/> object used to prevent multiple instances
		/// of the same application. </summary>
		private Mutex myMutex;

		/// <summary> Flag which indicates whether ownership of the MUTEX could be 
		/// gotten.  If so, this is the only instance, otherwise there is another instance
		/// of the same application running. </summary>
		private bool owned = false;

		/// <summary> Default constructor requires an additional string to identify the process.  </summary>
		/// <param name="identifier"> Random identifier which will be the same
		/// for all processes of the same program.  </param>
		/// <remarks> Each process is named, but some names may be common.  An additional random, 
		/// identifier will reduce the chance of concurrency issues. </remarks>
		public SingleProgramInstance( string identifier )
		{
			// Declare a new mutex with initial ownership
			myMutex = new Mutex( true, identifier, out owned);
		}

		/// <summary> Destructor releases the MUTEX, although this should have already
		/// happened in the Dispose method since this extends the IDisposable class. </summary>
		~SingleProgramInstance()
		{	
			// Release mutex.. (Should have happened in Dispose already)
			Release();
		}

		/// <summary> Returns whether this is the only instance of this process running at this time. </summary>
		public bool IsSingleInstance
		{
			get	{	return owned;	}
		}

		/// <summary> Private method used to release the Mutex once complete 
		/// with all the work. </summary>
		private void Release()
		{
			try
			{
				if ( owned )
				{
					myMutex.ReleaseMutex();
					owned = false;
				}
			}
			catch	{	}
		}

		/// <summary> Releases the MUTEX upon disposal. </summary>
		/// <remarks> Method needed to implement the <see cref="IDisposable"/> interface.   </remarks>
		public void Dispose()
		{
			// Release the Mutex
			Release();

			// Tell Garbace Collector to ignore the destructor
			GC.SuppressFinalize(this);
		}
	}
}
