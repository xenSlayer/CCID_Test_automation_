# for validating user address data insert operation to the database

Feature: UserAddress
	Validate user address insert opeartion in the database

@mytag
Scenario: Verify user address created
	# steps for performing the tests
	# should reflect the steps in order and in plain english
	Given insert operation to the database is successful
		| name  | age |
		| kiran | 100 |

	Then validate the data is inserted successfully
		| name  | age |
		| kiran | 100 |

	Examples: 
	| name  | age |
	| kiran | 100 |
