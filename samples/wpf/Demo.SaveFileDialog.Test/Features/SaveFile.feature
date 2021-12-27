@Manual
Feature: Save file

Scenario: Successfully saving file
	Given I have selected to save a file
	When I press confirm
	Then the file should be saved

Scenario: Canceling when saving file
	Given I have selected to save a file
	When I cancel
	Then the file should not be saved
