using TechTalk.SpecFlow;

namespace CCID_Test_automation_.steps
{
    [Binding]
    public class UserAddressSteps
    {
        [Given(@"insert user address to database")]
        public void GivenTheInsertUserAddressToDatabase()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"insert to the database is successful")]
        public void WhenInsertToTheDatabaseIsSuccessful()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"should get the inserted data from the database")]
        public void ThenShouldGetTheInsertedDataFromTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"should insert ""(.*)"" to database")]
        public void ThenShouldInsertToDatabase(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
