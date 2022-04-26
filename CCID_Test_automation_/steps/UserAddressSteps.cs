using CCID_Test_automation_.core;
using TechTalk.SpecFlow;

namespace CCID_Test_automation_.steps
{
    [Binding]
    public class UserAddressSteps
    {

        [Given(@"insert operation to the database is successful")]
        public void GivenInsertOperationToTheDatabaseIsSuccessful(Table table)
        {
            string query = "INSERT INTO DB";
            // Here the insert opeartion to the database is done
            DBConnection.ExecuteQuery(DBOperation.Insert, query);
        }

        [Then(@"validate the data is inserted successfully")]
        public void ThenValidateTheDataIsInsertedSuccessfully(Table table)
        {
            string query = "Select * FROM ";
            // Here the select opeartion to the database is done
            DBConnection.ExecuteQuery(DBOperation.Insert, query);
        }
    }
}
