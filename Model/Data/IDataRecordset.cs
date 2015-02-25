using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// An interface representing a collection of records retrieved from
    /// a data source.  The implementation of this interface will likely
    /// be tightly coupled with the implementation of IDataIntegration,
    /// so an initiative to create once will likely necessitate a new
    /// implementation of the other.
    /// </summary>
    public interface IDataRecordset
    {
        /*
         * This interface needs to support DataSet objects, which are a collection
         * of DataTables, which contain a collection of DataRows, each with a set
         * of fields.  The methods exposed by this interface, should also support
         * other types of record sources, such as flat files, NoSql databases,
         * and workbooks.
         * 
         * This interface is intended as a wrapper for some other data implementation
         * and as such will take the target object as a constructor argument.  The
         * challenge is to provide methods that expose the stored data such that
         * they make sense for all expected data sources.  That means it needs to
         * support multiple tables with multiple records.
         * 
         * The exposed methods must not rely on any specific implementation.  That 
         * means they must deal exclusively in primitive types both for method 
         * parameters and return values.
         */
    }
}
