Feature: Test Get API
Test api response to get api

@ListOfUsers
Scenario: Verify List of Users
	When  the user wants to get the data from /api/users?page=2
	Then  I should see that data is page 2, First Name is Michael and Last Name is Lawson

@SingleUser
Scenario: Verify Single User
	When  the user wants to get the data from /api/users/2
	Then  I should see that data contain First Name Janet

@SingleUserNotFound
Scenario: Verify Single User Not Found
	When  the user wants to get the data from /api/users/23
	Then  I should see that data is not found

@SingleResourceNotFound
Scenario: Verify Resource Not Found
	When  the user wants to get the data from /api/unknown/23
	Then  I should see that data is not found



