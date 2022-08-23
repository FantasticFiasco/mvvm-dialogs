@Manual
Feature: Show current time

Scenario: Show current time using dialog type locator
	When dialog is shown using the dialog type locator
	Then the current time should be displayed

Scenario: Show current time by specifying dialog type
	When dialog is shown by specifying dialog type
	Then the current time should be displayed
