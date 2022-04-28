# for validating user address data insert operation to the database
Feature: UserAddress
	Validate user address insert operation in the database

@mytag
Scenario: Verify user address created
	# steps for performing the tests
	# should reflect the steps in order and in plain english
	Given insert operation to the database is successful
		| Action | CustomerId | AddressId | AddressType | AddressLine1 | City   | StateCode | AddressCountryCode | AddresspostalCode |
		| ADD    | 20         | 30        | Q           | austin       | austin | Co        | TX                 | 20                |

	Then validate the data is inserted successfully
		| Action | CustomerId | AddressId | AddressType | AddressLine1 | City   | StateCode | AddressCountryCode | AddresspostalCode |
		| ADD    | 20         | 30        | Q           | austin       | austin | Co        | TX                 | 20                |

	Examples: 
	| Action | CustomerId | AddressId | AddressType | AddressLine1 | City   | StateCode | AddressCountryCode | AddresspostalCode |
	| ADD    | 20         | 30        | Q           | austin       | austin | Co        | TX                 | 20                |
