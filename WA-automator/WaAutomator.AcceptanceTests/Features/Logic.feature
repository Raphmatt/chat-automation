Feature: Logic

Scenario: Send messages
	Given Type message
	And Build mock for message
	When Sending message
	Then Function should be called

Scenario: Send empty messages
	Given Arrange Mock
	When Sending Empty message
	Then Function should call Exception

Scenario: Authentication
	Given Arrange Mock
	When  User Starts Program
	Then Function Authenticate should be called 



Scenario: Log Out
	Given Arrange Mock
	When User Logs Out
	Then Log Out Function should be called
