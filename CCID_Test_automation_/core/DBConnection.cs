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
        // create a connection to the database
        public static void ExecuteQuery(DBOperation dbOperation, string query)
        {
            string connetionString;
            SqlConnection cnn;
            SqlCommand command;

            // your sql user ID, db name and password for connection
            connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";

            // create a connection to the sql server with 'connectionString' containing ID and password
            cnn = new SqlConnection(connetionString);

            // define sql command
            command = new SqlCommand(query, cnn);

            SqlDataAdapter adapter = new SqlDataAdapter();

            switch (dbOperation)
            {
                case DBOperation.Insert:
                    adapter.InsertCommand = new SqlCommand(command.CommandText, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();
                    break;
                case DBOperation.Select:
                    adapter.SelectCommand = new SqlCommand(command.CommandText, cnn);
                    adapter.SelectCommand.ExecuteNonQuery();
                    break;
                case DBOperation.Update:
                    adapter.UpdateCommand = new SqlCommand(command.CommandText, cnn);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    break;
                case DBOperation.Delete:
                    adapter.DeleteCommand = new SqlCommand(command.CommandText, cnn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }

            cnn.Open();
            cnn.Close();
        }
    }
}
