using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace CCID_Test_automation_.core
{
    class DBConnection
    {
        private readonly string connectionString;
        SqlConnection connection;
        SqlDataReader sqlDataReader;

        public DBConnection()
        {
            connectionString = @"Initial Catalog=kiran; Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            LoadConnection();
        }

        public ConnectionState LoadConnection()
        {
            ConnectionState status;

            connection = new SqlConnection(connectionString);

            connection.Open();

            status = connection.State;

            return status;
        }

        public void SelectQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);

            sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();

        }

        public void ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            System.Diagnostics.Debug.WriteLine("EXECUTING QUERY: " + query);
            int _ = command.ExecuteNonQuery();
        }

        public bool ValidatingInsertedData(Dictionary<string, string> accountData)
        {
            bool flag = false;

            foreach (KeyValuePair<string, string> entry in accountData)
            {
                if (sqlDataReader[entry.Key].ToString() == (entry.Value.ToString()))
                {
                    flag = true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error in: " + sqlDataReader[entry.Key].ToString());
                    System.Diagnostics.Debug.WriteLine("[ALERT]: " + sqlDataReader[entry.Key].ToString() + " value from DB is not equal to " + entry.Value.ToString() + " from feature file.");
                    flag = false;
                    break;
                }
            }

            connection.Close();

            return flag;
        }
    }
}
