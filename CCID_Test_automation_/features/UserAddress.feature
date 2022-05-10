# for validating user address data insert operation to the database
Feature: UserAddress
	Validate user address insert operation in the database

@mytag
Scenario: Verify user address created
	# steps for performing the tests
	# should reflect the steps in order and in plain english
	Given Database connection is established
	When user inserts 'ADD' '20' '30' 'Q' 'austin' 'austin' 'CO' 'TX' '20' 'System' user address to the table '[dbo].[Table]' is successful
	Then User should select inserted data from the table '[dbo].[Table]' where customerId = '20'
	Then validate the data is inserted successfully
		| Columns            | Values |
		| Action             | ADD    |
		| CustomerId         | 20     |
		| AddressId          | 30     |
		| AddressType        | Q      |
		| AddressLine1       | austin |
		| City               | austin |
		| StateCode          | CO     |
		| AddressCountryCode | TX     |
		| AddresspostalCode  | 20     |
		| LastModifiedBy     | System |

	Examples:
		| Columns            | Values     |
		| Action             | ADD        |
		| ActionDate         | 2022-12-12 |
		| CustomerId         | 20         |
		| AddressId          | 30         |
		| AddressType        | Q          |
		| AddressLine1       | austin     |
		| City               | austin     |
		| StateCode          | CO         |
		| AddressCountryCode | TX         |
		| AddresspostalCode  | 20         |
		| CreatedDate Time   | 2022-12-25 |
		| LastModifiedBy     | System     |

@mytag
Scenario: Verify data is inserted in Raw FileControlTable
	Given Database connection is established
	When User inserts into Raw FileControlTable '<fileName>' '<podName>' '<isFileBeingProcessing>' '<isFileProcessingCompleted>' data to sql table '[DBO].[CDAS_RawFileControlTable]'
	Then User should select inserted data from the table '[DBO].[CDAS_RawFileControlTable]' where FileName 'Account_SnapShopt_20.TXT'
	Then Validate the data is inserted successfully to the table
		| Columns                   | Values                   |
		| FileName                  | Account_SnapShopt_20.TXT |
		| podName                   | System                   |
		| IsFileBeingProcessing     | True                     |
		| IsFileProcessingCompleted | True                     |

	Examples:
		| Columns                   | Values                   |
		| FileName                  | Account_SnapShopt_20.TXT |
		| podName                   | System                   |
		| IsFileBeingProcessing     | True                     |
		| IsFileProcessingCompleted | True                     |