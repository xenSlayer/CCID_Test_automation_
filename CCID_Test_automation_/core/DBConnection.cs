using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CCID_Test_automation_.core
{
    class DBConnection
    {
        public static string ExecuteQuery(string query)
        {
            string connectionString = @"Initial Catalog=kiran; Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string data = (string)reader.GetValue(reader.GetOrdinal("Action"));

                connection.Close();

                TestContext.Progress.WriteLine(data);

                return data;

            }
            else
            {
                TestContext.WriteLine("Unable to fetch any data");
                return "";
            }
        }
    }
}
