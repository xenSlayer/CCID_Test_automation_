# for validating user address data insert operation to the databases 'kiran' --commit
Feature: UserAddress
	Validate user address insert operation in the database

@UserAddress
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

@fileControlTable
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

@RawMasterAndSubAccountRecord
Scenario: Verify data is inserted in RawMasterAndSubAccountRecord table
	Given Database connection is established
	When User inserts '<RecordId>' '<Action>' '<SubAccountId>' '<AssociationCode>' '<MasterAccountId>' '<AccountState>' '<Version>' '<IsValid>' '<SysErrorCode>' '<IsProcessed>' '<LastModifiedBy>' data to sql table '[Dbo].[RawMasterAndSubAccountRecord]'
	Then User should select inserted data from the table '[Dbo].[RawMasterAndSubAccountRecord]' where RecordId is '8JK39D9S-943J-9D8V-93JF-390F80FOEJW'
	Then Validate the data is inserted successfully to the table RawMasterAndSubAccountRecord
		| Columns         | Values                              |
		| RecordId        | 8JK39D9S-943J-9D8V-93JF-390F80FOEJW |
		| Action          | 1                                   |
		| SubAccountId    | 18805980                            |
		| AssociationCode | FA                                  |
		| MasterAccountId | 09209309                            |
		| AccountState    | O                                   |
		| Version         | 0                                   |
		| IsValid         | 1                                   |
		| SysErrorCode    | 0                                   |
		| IsProcessed     | 1                                   |
		| LastModifiedBy  | System                              |

	Examples:
		| Columns         | Values                              |
		| RecordId        | 8JK39D9S-943J-9D8V-93JF-390F80FOEJW |
		| Action          | 1                                   |
		| SubAccountId    | 18805980                            |
		| AssociationCode | FA                                  |
		| MasterAccountId | 09209309                            |
		| AccountState    | O                                   |
		| Version         | 0                                   |
		| IsValid         | 1                                   |
		| SysErrorCode    | 0                                   |
		| IsProcessed     | 1                                   |
		| LastModifiedBy  | System                              |