@Manual
Feature: Open file

Scenario: Successfully opening file
	Given I have selected to open a file
	When I press confirm
	Then the file should be opened

Scenario: Canceling when opening file
	Given I have selected to open a file
	When I cancel
	Then the file should not be opened
