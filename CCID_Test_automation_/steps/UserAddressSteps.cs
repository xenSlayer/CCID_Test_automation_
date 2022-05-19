using CCID_Test_automation_.core;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;


namespace CCID_Test_automation_.steps
{
    [Binding]
    public class UserAddressSteps
    {
        readonly DBConnection dBconnection = new DBConnection();

        [Given(@"Database connection is established")]
        public void GivenDatabaseConnectionIsEstablished()
        {
            dBconnection.LoadConnection();
        }

        [When(@"user inserts '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' user address to the table '(.*)' is successful")]
        public void WhenUserInsertsUserAddressToTheTableIsSuccessful(string p0, int p1, int p2, string p3, string p4, string p5, string p6, string p7, int p8, string p9, string p10)
        {
            string query = "INSERT INTO " + p10 + " (Action, CustomerId, AddressId, AddressType, AddressLine1, City, StateCode, AddressCountryCode, AddresspostalCode, LastModifiedBy) VALUES('" + p0 + "', '" + p1 + "', '" + p2 + "', '" + p3 + "', '" + p4 + "', '" + p5 + "', '" + p6 + "', '" + p7 + "', '" + p8 + "', '" + p9 + "'); ";
            dBconnection.ExecuteQuery(query);
        }


        [Then(@"User should select inserted data from the table '(.*)' where customerId = '(.*)'")]
        public void ThenUserShouldSelectInsertedDataFromTheTableWhereCustomerId(string p0, int p1)
        {
            string query = "SELECT * FROM " + p0 + " WHERE customerId = " + p1.ToString();

            dBconnection.SelectQuery(query);
        }


        [Then(@"validate the data is inserted successfully")]
        public void ThenValidateTheDataIsInsertedSuccessfully(Table table)
        {

            Dictionary<string, string> featureFileData = new Dictionary<string, string>();

            foreach (TableRow row in table.Rows)
            {
                featureFileData.Add(row["Columns"], row["Values"]);
            }

            Assert.IsTrue(dBconnection.ValidatingInsertedData(featureFileData));
        }

        // Verify data is inserted in Raw FileControlTable

        [When(@"User inserts into Raw FileControlTable '(.*)' '(.*)' '(.*)' '(.*)' data to sql table '(.*)'")]
        public void WhenUserInsertsIntoRawFileControlTableDataToSqlTable(string p0, string p1, string p2, string p3, string p4)
        {
            string query = "INSERT INTO " + p4 + " (FileName, PodName, IsFileBeingProcessing, IsFileProcessingCompleted) VALUES('" + p0 + "', '" + p1 + "', '" + p2 + "', '" + p3 + "'); ";
            dBconnection.ExecuteQuery(query);
        }


        [Then(@"User should select inserted data from the table '(.*)' where FileName '(.*)'")]
        public void ThenUserShouldSelectInsertedDataFromTheTableWhereFileName(string p0, string p1)
        {
            string query = "SELECT * FROM " + p0 + " WHERE FileName = " + p1.ToString();
            dBconnection.SelectQuery(query);
        }



        [Then(@"Validate the data is inserted successfully to the table")]
        public void ThenValidateTheDataIsInsertedSuccessfullyToTheTable(Table table)
        {
            Dictionary<string, string> featureFileData = new Dictionary<string, string>();

            foreach (TableRow row in table.Rows)
            {
                featureFileData.Add(row["Columns"], row["Values"]);
            }

            Assert.IsTrue(dBconnection.ValidatingInsertedData(featureFileData));
        }

        // @RawMasterAndSubAccountRecord
        [When(@"User inserts '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' data to sql table '(.*)'")]
        public void WhenUserInsertsDataToSqlTable(string recordId, string action, string subAccountId, string associationCode, string masterAccountId, string accountState, string version, string isvalid, string sysErrorCode, string isProcessed, string lastModifiedBy, string sqlTable)
        {
            string dateTime = DateTime.Now.ToString("yyy-MM-dd");
            string query = $"INSERT INTO {sqlTable} (RecordId, Action, ActionDate, SubAccountId, AccountOpenDate, AssociationCodeDate, AssociationCode, MasterAccountId, AccountState, AccountStateDate, Version, Isvalid, SysErrorCode, IsProcessed, LastModifiedDateTime, LastModifiedBy) VALUES('{recordId}', '{action}', '{dateTime}', '{subAccountId}', '{dateTime}', '{dateTime}', '{associationCode}', '{masterAccountId}', '{accountState}', '{dateTime}', '{version}', '{isvalid}', '{sysErrorCode}', '{isProcessed}', '{dateTime}', '{lastModifiedBy}')";
            dBconnection.ExecuteQuery(query);
        }

        [Then(@"User should select inserted data from the table '(.*)' where RecordId is '(.*)'")]
        public void ThenUserShouldSelectInsertedDataFromTheTableWhereRecordIdIs(string tableName, string recordId)
        {
            string query = $"SELECT * FROM {tableName} WHERE RecordId={recordId}";
            dBconnection.SelectQuery(query);
        }

        [Then(@"Validate the data is inserted successfully to the table RawMasterAndSubAccountRecord")]
        public void ThenValidateTheDataIsInsertedSuccessfullyToTheTableRawMasterAndSubAccountRecord(Table table)
        {
            Dictionary<string, string> featureFileData = new Dictionary<string, string>();

            foreach (TableRow row in table.Rows)
            {
                featureFileData.Add(row["Columns"], row["Values"]);
            }

            Assert.IsTrue(dBconnection.ValidatingInsertedData(featureFileData));
        }

        // @RawMasterSubTest
        [When(@"User inserts '(.*)','(.*)','(.*)','(.*)' to table '(.*)'")]
        public void WhenUserInsertsToTable(string action, string accountID, string associationCode, string masterAccountID, string sqlTable)
        {
            string dateTime = DateTime.Now.ToString("yyy-MM-dd");
            string query = $"INSERT INTO {sqlTable} (Action, ActionDate, AccountID, AssociationCode, MasterAccountID) VALUES('{action}', '{dateTime}', '{accountID}', '{associationCode}', '{masterAccountID}');";
            dBconnection.ExecuteQuery(query);
        }

        [Then(@"User should select inserted data from the table '(.*)' where AccountID is '(.*)'")]
        public void ThenUserShouldSelectInsertedDataFromTheTableWhereAccountIDIs(string tableName, int accountID)
        {
            string query = $"SELECT * FROM {tableName} WHERE AccountID={accountID}";
            dBconnection.SelectQuery(query);
        }

        [Then(@"Validate the data is inserted successfully to the table RawMasterAndSubTest")]
        public void ThenValidateTheDataIsInsertedSuccessfullyToTheTableRawMasterAndSubTest(Table table)
        {
            Dictionary<string, string> featureFileData = new Dictionary<string, string>();

            foreach (TableRow row in table.Rows)
            {
                featureFileData.Add(row["Columns"], row["Values"]);
            }

            Assert.IsTrue(dBconnection.ValidatingInsertedData(featureFileData));
        }
    }
}
