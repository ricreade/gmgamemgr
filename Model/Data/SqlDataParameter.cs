using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// A Sql implemenation of the IDataArgument interface.  This class
    /// exposes methods to support parameterization for a Sql query.  
    /// The base object (for GetArgument) is a SqlParameter.  If the
    /// constructor did not throw an exception, this base object is
    /// guaranteed to be instantiated.
    /// </summary>
    public class SqlDataParameter : IDataParameter
    {
        private SqlParameter _param;

        /// <summary>
        /// Instantiates this argument with the parameter name and value.
        /// If either value is null or empty, the constructor throws an
        /// ArgumentException.
        /// </summary>
        /// <param name="Name">The name of the parameter.</param>
        /// <param name="Value">The value of the parameter.</param>
        public SqlDataParameter(string Name, object Value)
        {
            if (Name == null || Name.Length == 0 || Value == null)
                throw new ArgumentException();
            _param = new SqlParameter(Name, Value);
        }

        /// <summary>
        /// Instantiates this argument with a SqlParameter object.  If this
        /// argument is null, the constructor throws an ArgumentException.
        /// </summary>
        /// <param name="Parameter"></param>
        public SqlDataParameter(SqlParameter Parameter)
        {
            if (Parameter == null)
                throw new ArgumentException();
            _param = Parameter;
        }

        /// <summary>
        /// Returns the parameter name as stored in the internal SqlParameter
        /// object.
        /// </summary>
        /// <returns>The parameter name.</returns>
        public string GetName()
        {
            return _param.ParameterName;
        }

        /// <summary>
        /// Returns the parameter value as stored in the SqlParameter object.
        /// </summary>
        /// <returns>The parameter value.</returns>
        public object GetValue()
        {
            return _param.Value;
        }

        /// <summary>
        /// Returns the base SqlParameter object.
        /// </summary>
        /// <returns>The internal SqlParameter object.</returns>
        public object GetArgument()
        {
            return _param;
        }
    }
}
