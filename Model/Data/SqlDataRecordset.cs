using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    class SqlDataRecordset : IDataRecordset
    {
        private DataSet _dataset = null;

        public SqlDataRecordset(DataSet Data)
        {
            _dataset = Data;
        }

        /*
         * Need to expose methods here that suit the interface.  I.e., they
         * provide sufficient information for a sql data connection (namely
         * a DataSet object, but do not tie the interface to a sql implemenation.
         */
    }
}
