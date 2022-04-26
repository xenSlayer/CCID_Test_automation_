# for validating user address data insert operation to the database

Feature: UserAddress
	Validate user address insert opeartion in the database

@mytag
Scenario: Perform user address insert operation in the database
	# steps for performing the tests
	# should reflect the steps in order and in plain english
	Given insert user address to database
	When insert to the database is successful
	Then should get the inserted data from the database
	Then should insert "12" to database

	Examples: 
	| name  | age |
	| kiran | 100 |
