using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// Interface for presenting an argument implementation.  This interface
    /// is intended to support different parameter techniques for different
    /// data sources.  For example, the parameter options for a sql database
    /// will differ from those of a flat file, or a test data source.  The
    /// implementation of this interface is expected to obtain its data via
    /// its contructor or via specialized mutators.  The interface thus
    /// makes the parameter read-only.
    /// </summary>
    public interface IDataParameter
    {
        /// <summary>
        /// Returns the parameter name.
        /// </summary>
        /// <returns>A string representing the parameter name.</returns>
        string GetName();

        /// <summary>
        /// Returns the parameter value.
        /// </summary>
        /// <returns>An object representing the parameter value.</returns>
        object GetValue();

        /// <summary>
        /// The object representation of this argument in the implementation.
        /// </summary>
        /// <returns>The object implementation if there is one.  Otherwise null.</returns>
        object GetArgument();
    }
}
