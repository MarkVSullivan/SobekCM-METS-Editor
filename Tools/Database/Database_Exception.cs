using System;
using System.Collections.Generic;
using System.Text;

namespace DLC.Tools.Database
{
    /// <summary> Database_Exception is an exception which can be thrown when there
    /// is an error while accessing the database.  This extends the <see cref="ApplicationException"/>
    /// class.  </summary>
    public class Database_Exception : ApplicationException
    {
        /// <summary> Constructor for a new qc_Exception object </summary>
        /// <param name="exceptionText"> Text of the exception to be displayed </param>
        public Database_Exception(string exceptionText)
            : base(exceptionText)
        {
            // All work completed in the base class
        }
    }
}
