@logged_user
@numberOfLetters_tests
Feature: SpecFlowTestCreatingNumberOfLetters

Scenario Outline: Verify right click delete
	Given The '<number>' of letters created
	When I open draft emails folder
	And I perform right click on the letter in '<sequence>'
	And I delete the letter
	Then I see the '<number>' of emails has descresed by one

	Examples:
		| number | sequence |
		| 11     | 5        |
		| 5      | 1        |
		| 8      | 8        |

Scenario Outline: Verify MoveUp button
	Given The '<number>' of letters created
	When I open draft emails folder
	And I perform Scroll by '<pixels>'
	Then I see the MoveUp button

	Examples:
		| number | pixels |
		| 5      | 200    |
		| 8      | 300    |