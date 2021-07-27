@logged_user
@send_tests
Feature: SpecFlowTestSendEmail

Background:
	Given I create a draft letter

Scenario: Send email and verify draft folder
	When I open draft emails folder
	And I open created draft email
	And I click 'Send' button
	And I open draft emails folder
	Then I don't see the letter in the draft folder

Scenario: Send email and verify sent folder
	When I open draft emails folder
	And I open created draft email
	And I click 'Send' button
	And I open sent emails folder
	Then I see the letter in the sent folder
