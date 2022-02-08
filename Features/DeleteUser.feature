Feature: Test Delete API

Test API for delete user 

 Scenario: Verify user is deleted
	When  the user wants to delete the data from /api/users/2
	Then I should validate that data is deleted
