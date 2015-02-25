using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    class SqlDataArgument : IDataArgument
    {
        private SqlParameter _param;

        public SqlDataArgument(string Name, object Value)
        {
            _param = new SqlParameter(Name, Value);
        }

        public SqlDataArgument(SqlParameter Parameter)
        {
            _param = Parameter;
        }

        public string GetName()
        {
            return _param.ParameterName;
        }

        public object GetValue()
        {
            return _param.Value;
        }


        public object GetArgument()
        {
            return _param;
        }
    }
}
