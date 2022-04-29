﻿using CCID_Test_automation_.core;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;


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
    }
}
