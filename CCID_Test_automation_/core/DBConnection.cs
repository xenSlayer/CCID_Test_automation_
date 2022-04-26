using System.Data.SqlClient;
using System;

enum DBOperation
{
    Insert,
    Select,
    Update,
    Delete,
}

namespace CCID_Test_automation_.core
{
    class DBConnection
    {
        public static dynamic ExecuteQuery(DBOperation dbOperation, string query)
        {
            // connection string
            // ./core/Constants.cs for connection string and other constants
            string connetionString = Constants.ConnectionString();

            // create a connection to the sql server with 'connectionString' containing ID and password
            SqlConnection cnn = new SqlConnection(connetionString);

            SqlDataAdapter adapter = new SqlDataAdapter();

            cnn.Open();

            switch (dbOperation)
            {
                // [INSERT]
                case DBOperation.Insert:
                    adapter.InsertCommand = new SqlCommand(query, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();
                    cnn.Close();
                    return 0;

                // [SELECT]
                case DBOperation.Select:
                    adapter.SelectCommand = new SqlCommand(query, cnn);
                    adapter.SelectCommand.ExecuteNonQuery();
                    cnn.Close();
                    return 20;

                // [UPDATE]
                case DBOperation.Update:
                    adapter.UpdateCommand = new SqlCommand(query, cnn);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    cnn.Close();
                    return 20;

                // [DELETE]
                case DBOperation.Delete:
                    adapter.DeleteCommand = new SqlCommand(query, cnn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    cnn.Close();
                    return 20;

                default:
                    Console.WriteLine("Invalid operation");
                    cnn.Close();
                    return 20;
            }
        }
    }
}
