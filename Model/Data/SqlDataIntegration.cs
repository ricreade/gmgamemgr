using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// Class to represent a collection of record source data for a
    /// specific application object.  This class is intended as an
    /// abstraction of data provided from some record source.
    /// </summary>
    public class SqlDataIntegration : IDataIntegration
    {
        string _connstr;

        /// <summary>
        /// Creates a new sql data integration object.  The connection string
        /// must be set before this object can be used.
        /// </summary>
        public SqlDataIntegration()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new sql data integration object, sets the connection string, and
        /// attempts to connect to the sql database.  If the connection is successful,
        /// the connection is immediately closed to conserve resources.  If the connection
        /// fails, an exception is thrown.
        /// Throws:
        ///     InvalidOperationException - malformed connection string, or the connection is already open.
        ///     SqlException - the connection attempt failed.
        ///     ConfigurationException - there is a duplicate database instance.
        /// </summary>
        /// <param name="ConnectionString">The connection string</param>
        public SqlDataIntegration(string ConnectionString)
        {
            Initialize();
            SetConnectionString(ConnectionString);
        }

        /// <summary>
        /// Returns a SqlCommand object configured with the specified procedure name
        /// and parameters.  Once returned, the command object is ready to use to send
        /// requests to the sql database.
        /// </summary>
        /// <param name="Connection">The database connection upon which to base this
        /// command.</param>
        /// <param name="ProcedureName">The stored procedure this command object will
        /// invoke.</param>
        /// <param name="Args">The parameter list for this command.</param>
        /// <returns>A command object ready to invoke.  If the Connection argument is
        /// null, this method returns null.</returns>
        private SqlCommand ConfigureCommand(SqlConnection Connection, string ProcedureName, IDataParameter[] Args)
        {
            if (Connection == null)
                return null;

            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = ProcedureName;
            comm.CommandType = CommandType.StoredProcedure;
            if (Args != null)
            {
                for (int i = 0; i < Args.Length; i++)
                {
                    comm.Parameters.Add(Args[i].GetArgument());
                }
            }
            return comm;
        }

        /// <summary>
        /// Initializes (or resets) the object fields to their starting values.  Calling
        /// this method on an initialized object will prevent it from functioning until
        /// the SetConnectionString method is called again.
        /// </summary>
        public void Initialize()
        {
            _connstr = "";
        }

        /// <summary>
        /// Sends an action (delete, insert, or update) query request to the sql database using
        /// the specified command string and the parameter list.  Returns a boolean indicating
        /// whether the attempt succeeded (i.e. whether any rows were affected by the request).
        /// If the attempt fails, an exception is thrown.
        /// </summary>
        /// <param name="Command">The name of the sql database stored procedure to call.</param>
        /// <param name="Args">The array of parameter arguments to pass to the procedure.</param>
        /// <returns>True if the request affected any records, otherwise false.</returns>
        public bool SendActionRequest(string Command, IDataParameter[] Args)
        {
            using (SqlConnection conn = new SqlConnection(_connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = ConfigureCommand(conn, Command, Args);
                    return comm.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sends a retrieve (select) query request to the sql database using the specified 
        /// command string and the parameter list.  Returns a dataset containing the retrieved
        /// values (even if no values were returned).  If the attempt fails, an exception is
        /// thrown.
        /// </summary>
        /// <param name="Command">The name of the sql database stored procedure to call.</param>
        /// <param name="Args">The array of parameter arguments to pass to the procedure.</param>
        /// <returns>A dataset containing the retrieved records.</returns>
        public IDataRecordset SendDataRequest(string Command, IDataParameter[] Args)
        {
            DataSet dataset;
            string[] tablenames = new string[] { "AttributeSchemas", "Attributes" };
            using (SqlConnection conn = new SqlConnection(_connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = ConfigureCommand(conn, Command, Args);
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    dataset = new DataSet();
                    adapter.Fill(dataset);

                    // For some unfathomable reason, the tables written to the dataset
                    // from the procedure are named 'Table', 'Table1', 'Table2', etc,
                    // rather than using the table names as given in the procedure.
                    for (int i = 0; i < dataset.Tables.Count && i < tablenames.Length; i++)
                    {
                        dataset.Tables[i].TableName = tablenames[i];
                    }

                    return new SqlDataRecordset(dataset);
                }
                catch (Exception ex){
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Sets the connection string for this sql data connection.  This method
        /// verifies the connection string by attempting to open a connection to the
        /// specified sql data source.  If the connection succeeds, it is immediately
        /// closed and this method returns true.  If the connection fails, an Exception
        /// is thrown.
        /// </summary>
        /// <param name="ConnectionString">The connection string specifying the sql
        /// data source.</param>
        /// <returns>True if the connection succeeded.  If the connection fails, an
        /// exception is thrown.</returns>
        public bool SetConnectionString(string ConnectionString)
        {
            _connstr = ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    // connection is already open or the connection string is malformed.
                    throw;
                }
                catch (SqlException ex)
                {
                    // connection attempt failed.
                    throw;
                }
                catch (ConfigurationException ex)
                {
                    // there is a duplicate database instance.
                    throw;
                }
            }
        }
    }
}
