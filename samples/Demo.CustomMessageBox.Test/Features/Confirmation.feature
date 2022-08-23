@Manual
Feature: Confirmation

Scenario: Confirmation with text
	Given confirmation with text is shown
	When I confirm
	Then the confirmation should be acted on

# -------------------------------------------------------------------------------------------------
Scenario: Confirmation with text and caption
	Given confirmation with text and caption is shown
	When I confirm
	Then the confirmation should be acted on

# -------------------------------------------------------------------------------------------------
Scenario: Confirmation with text and caption with option to cancel
	Given confirmation with text, caption and option to cancel is shown
	When I confirm
	Then the confirmation should be acted on

Scenario: Cancellation with text and caption with option to confirm
	Given confirmation with text, caption and option to cancel is shown
	When I cancel
	Then the cancellation should be respected

# -------------------------------------------------------------------------------------------------
Scenario: Confirmation with text, caption and icon with option to cancel
	Given confirmation with text, caption, icon and option to cancel is shown
	When I confirm
	Then the confirmation should be acted on

Scenario: Cancellation with text, caption and icon with option to confirm
	Given confirmation with text, caption, icon and option to cancel is shown
	When I cancel
	Then the cancellation should be respected

# -------------------------------------------------------------------------------------------------
Scenario: Confirmation with text, caption, icon and default choice with option to cancel
	Given confirmation with text, caption, icon, default choice and option to cancel is shown
	When I confirm
	Then the confirmation should be acted on

Scenario: Cancellation with text, caption, icon and default choice with option to confirm
	Given confirmation with text, caption, icon, default choice and option to cancel is shown
	When I cancel
	Then the cancellation should be respected
