Feature: Test Post API

A short summary of the feature

Scenario: Create user
	Given the user wants to post the data to /api/users
	When I create user with the following details
	| name | job    |
	| Jem  | Tester |		
	Then validate user id is created with name Jem and job Tester

Scenario:Succesful Register user
	Given the user wants to post the data to /api/register
	When I input the following details
	| email	| password    |
	| eve.holt@reqres.in  | pistol |		
	Then I should validate that data is processed

Scenario: Unsuccesful Register user
	Given the user wants to post the data to /api/register
	When I input the following details
	| email |password |
	| sydney@fife ||		
	Then I should validate that data is not processed

Scenario: Login user
	Given the user wants to post the data to /api/login
	When I input the following details
	| email |password |
	| eve.holt@reqres.in|cityslicka|		
	Then I should validate that data is processed
