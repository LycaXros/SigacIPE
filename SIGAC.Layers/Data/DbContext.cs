using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace SIGAC.Layers.Data
{
    /// <summary>
    /// Class for manage data from database
    /// </summary>
    public sealed class DbContext
    {
        private static DbContext instance = null;
        private OracleConnection connection;        

        /// <summary>
        /// Constructor of the class
        /// </summary>
        private DbContext()
        {
            initialize();
        }

        /// <summary>
        /// Singleton Pattern of DbContext
        /// </summary>
        public static DbContext Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbContext();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initialize the database connection
        /// </summary>
        private void initialize()
        {
            connection = new OracleConnection
            {
                ConnectionString = GlobalVariables.OracleConnectionString
            };
        }

        /// <summary>
        /// Execute a query in the database
        /// </summary>
        /// <param name="query">Query that is wanted to be executed</param>
        public DataTable getData(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }                    
                }
            }
            catch (Exception error)
            {
                throw error;
            }

            return dataTable;
        }

        /// <summary>
        /// Execute a stored procedure that exist in the database
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="listParametros">List of parameters that need that stored procedure to be execute. Can be null.</param>
        public void executeStoredProcedure(string storedProcedureName, List<OracleParameter> listParametros = null)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (listParametros != null)
                    {
                        foreach (var parameter in listParametros)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Execute a stored procedure that exist in the database, that return a datatable.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="listParametros">List of parameters that need that stored procedure to be execute. Can be null.</param>
        /// <returns>Datatable</returns>
        public DataTable getDataFromStoredProcedure(string storedProcedureName, List<OracleParameter> listParametros = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (listParametros != null)
                    {
                        foreach (var parameter in listParametros)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }

            return dataTable;
        }
    }
}
