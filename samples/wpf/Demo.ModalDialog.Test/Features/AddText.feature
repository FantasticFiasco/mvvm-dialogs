@Manual
Feature: Add text

Scenario: Enter text and accept using dialog type locator
	Given dialog is shown using the dialog type locator
	When I enter the text Added text
		And accept
	Then the list of texts should contain Added text

Scenario: Enter text and abort using dialog type locator
	Given dialog is shown using the dialog type locator
	When I enter the text Added text
		And abort
	Then the list of texts should be empty

Scenario: Enter text and accept when specifying dialog type
	Given dialog is shown by specifying dialog type
	When I enter the text Added text
		And accept
	Then the list of texts should contain Added text

Scenario: Enter text and abort when specifying dialog type
	Given dialog is shown by specifying dialog type
	When I enter the text Added text
		And abort
	Then the list of texts should be empty