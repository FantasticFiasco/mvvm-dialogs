@Manual
Feature: Browse folder

Scenario: Successfully browse folder
	Given I have browsed a folder
	When I press confirm
	Then the folder should be opened

Scenario: Canceling when browsing folder
	Given I have browsed a folder
	When I cancel
	Then the folder should not be opened
