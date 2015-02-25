using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// An interface representing a collection of record source data for
    /// a specific application data object.  This interface is intended to
    /// support abstraction for varying data sources.  This interface uses two
    /// value types:
    ///     A - The argument type for the request.
    ///     R - The return type for data returned by the request.
    /// The implementation of this interface will likely
    /// be tightly coupled with the implementation of IDataRecordset,
    /// so an initiative to create once will likely necessitate a new
    /// implementation of the other.
    /// </summary>
    public interface IDataIntegration
    {
        /// <summary>
        /// Initializes (or resets) the data integration variables.  The
        /// implementation should call this method automatically in the
        /// constructor.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Sends an action request (delete, insert, or update) to the
        /// data source and returns a boolean indicating whether the
        /// request was successful.
        /// </summary>
        /// <param name="Command">A command string.  This be either
        /// a request instruction (such as a sql string) or a procedure
        /// name.  The implementation of this interface determines the
        /// meaning of this parameter.</param>
        /// <param name="Args">The parameter array.  The type of this
        /// array is determined by the implementation.</param>
        /// <returns>True if the request was successful.  Otherwise false.</returns>
        bool SendActionRequest(string Command, IDataArgument[] Args);

        /// <summary>
        /// Sends a retrieve request to the data source and returns the
        /// results of the request.
        /// </summary>
        /// <param name="Command">A command string.  This be either
        /// a request instruction (such as a sql string) or a procedure
        /// name.  The implementation of this interface determines the
        /// meaning of this parameter.</param>
        /// <param name="Args">The parameter array.  The type of this
        /// array is determined by the implementation.</param>
        /// <returns>If successful, the records retrieved by the retrieve 
        /// request.  Otherwise null.</returns>
        IDataRecordset SendDataRequest(string Command, IDataArgument[] Args);

        /// <summary>
        /// Sets the connection string for this integration.  This string
        /// defines the method the implementation should use to connect to the
        /// data source.  For a sql database implementation, this would be the
        /// database connection string.  For a flat file, this would be the
        /// location of the file.  The specific implementation determines
        /// the appropriate value and syntax for this string.
        /// </summary>
        /// <param name="ConnectionString">A string defining the connection
        /// to the data source.</param>
        /// <returns>True if a connection can be established.  Otherwise false.</returns>
        bool SetConnectionString(string ConnectionString);
    }
}
