Feature: Test API

@ListofUser
Scenario: Verify List of Users
	Given the user is connected to rest client
	When the user calls get api with parameter /api/users?page=2
	Then list is not empty

@SingleUser
Scenario: Verify Single User
	Given the user is connected to rest client
	When the user calls get api with parameter /api/users/2
	Then single user is displayed

@SingleUserNotFound
Scenario: Verify Single User is not found
	Given the user is connected to rest client
	When the user calls get api with parameter /api/users/23
	Then list is empty

@SingleResourceNotFound
Scenario: Verify Resource is not found
	Given the user is connected to rest client
	When the user calls get api with parameter /api/unknown/23
	Then list is empty

@CreateUser
Scenario: Create new user
    Given the user is connected to rest client
	When user create user with the following details
	| name | job    |
	| Jem  | Tester |
	Then user is created

#@CreateUser
#Scenario: Create new user
#	Given the user is connected to rest client
#	When the user calls post api 
#	Then user is created

@DeleteUser
Scenario: Verify succesfully deleted
	Given the user is connected to rest client
	When the user calls delete /api/users/2
	Then user is deleted

@SuccesfullyRegistered
Scenario: Verify succesfully registered
	Given the user is connected to rest client	
	When user register with the following details
	| email			 | password |
	| jem@gmail.com  | password |
	Then user is registered

@UnsuccesfullyRegistered
Scenario: Verify unsuccesfully registered
	Given the user is connected to rest client
	When user register with the following details
	| email			 | password |
	| jem@gmail.com  |          |
	Then user is not registered

@SuccessfulLogin
Scenario: Verify login succesfulyy
	Given the user is connected to rest client
	When the user login with the following details
	| email			 | password |
	| jem@gmail.com  | password |
	Then user login succesfully