using CCID_Test_automation_.core;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;
using System.Data.SqlClient;

namespace CCID_Test_automation_.steps
{
    [Binding]
    public class UserAddressSteps
    {
        [Given(@"insert operation to the database is successful")]
        public void GivenInsertOperationToTheDatabaseIsSuccessful(Table table)
        {

        }

        [Then(@"validate the data is inserted successfully")]
        public void ThenValidateTheDataIsInsertedSuccessfully(Table table)
        {
            string query = "SELECT * FROM [dbo].[Table] where Id = 2";

            string databaseData = DBConnection.ExecuteQuery(query);

            dynamic data = table.CreateDynamicInstance();

            Assert.That((string)data.Action == "ADD");
        }
    }
}
