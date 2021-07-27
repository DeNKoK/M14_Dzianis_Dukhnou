@logged_user
@inbox_tests
Feature: SpecFlowTestRightClick
	As a yandex user
	In order to move letters to different folders
	I want to be able to move the letter through the right click menu

Background:
	Given I create a draft letter

Scenario: Move letter from Draft to Inbox verify Draft Folder
	When I open draft emails folder
	And I perform right click on the letter
	And I move the letter to the Inbox folder
	Then I don't see the letter in the draft folder

Scenario: Move letter from Draft to Inbox verify Inbox Folder
	When I open draft emails folder
	And I perform right click on the letter
	And I move the letter to the Inbox folder
	And I open the Inbox folder
	Then I see the letter in the Inbox folder