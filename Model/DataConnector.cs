using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Singleton class responsible for all database communications.  Stored procedures called
    /// with this class should make every effort to retrieve as much data as possible with each
    /// call.
    /// </summary>
    public static class DataConnector
    {
        private static string _connstr;
        static DataConnector()
        {
            Initialize();
        }

        public static void Initialize()
        {
            _connstr = "";
        }

        /// <summary>
        /// Retrieves database records using the specified stored procedure and
        /// passing the specified id as the procedure argument.
        /// </summary>
        /// <param name="Procedure">The name of the stored procedure to call.</param>
        /// <param name="Id">The integer id argument to pass to the stored procedure.</param>
        /// <returns>The results of the query.</returns>
        public static DataSet RetrieveDataRecords(string Procedure, DataArgumentList Args)
        {
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(_connstr);
            conn.BeginTransaction();

            SqlCommand comm = new SqlCommand(Procedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            foreach (DataArgumentList.DataArgument Argument in Args){
                comm.Parameters.Add(new SqlParameter(Argument.Key, Argument.Value));
            }

            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(dataset);

            conn.Close();

            return dataset;
        }
    }
}
