@logged_user
@draft_tests
Feature: SpeacFlowTestDraftEmail
	As a yandex user
	In order to create a draft letter
	I want the draft letter to be created automatically after closing the letter form

Scenario: Verify draft email creation
	When I create new letter
	And I populate TO, subject, and body
	And I close the letter
	And I open draft emails folder
	Then I see the email in the draft folder

Scenario: Verify content of draft email
	When I create new letter
	And I populate TO, subject, and body
	And I close the letter
	And I open draft emails folder
	And I open created draft email
	Then I see appropriate TO, subject, and body of the letter
