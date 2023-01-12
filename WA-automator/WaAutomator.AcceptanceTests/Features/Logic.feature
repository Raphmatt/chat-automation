Feature: Logic

Scenario: Send messages
	Given Type message
	And Build mock for message
	When Sending message
	Then Function should be called

Scenario: Send empty messages
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Authentication
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	
Scenario: Send Message without tel. number
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	
Scenario: Valid tel. number
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	
Scenario: Invalid tel. number
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120