Feature: Test Delete API

Test API for delete user 

@DeleteUser
Scenario: Verify user is deleted
	When  the user wants to delete the data from /api/users/2
	Then  I should see that data is deleted
