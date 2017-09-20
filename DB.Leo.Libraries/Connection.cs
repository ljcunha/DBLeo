namespace DB.Leo.Lib
{
    using DB.Leo.Libraries.Implementations.Factories;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class Connection
    {
        private static IList<SqlConnection> connections;
        private static SqlConnection sqlConnection;

        public Connection()
        {
            connections = new List<SqlConnection>();
        }

        /// <summary>
        /// Singleton for SqlConnection using multithreading
        /// </summary>
        /// <returns>Returns a SqlConnection instance</returns>
        public static SqlConnection GetInstance<TConnection>()
        {
            var connectionString = ConnectionFactory.Create<TConnection>().GetConnectionString();
            var connectionString2 = ConnectionFactory.CreateWithInjector<TConnection>().GetConnectionString();

            sqlConnection = connections.Single(x => x.ConnectionString.Equals(connectionString, StringComparison.OrdinalIgnoreCase));
            if (sqlConnection == null)
            {
                lock (sqlConnection)
                {
                    if (sqlConnection == null)
                    {
                        sqlConnection = new SqlConnection(connectionString);
                        connections.Add(sqlConnection);
                    }
                }
            }
            return sqlConnection;
        }
    }
}
