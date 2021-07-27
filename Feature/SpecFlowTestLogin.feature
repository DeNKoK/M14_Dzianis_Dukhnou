@notlogged_user
Feature: SpecFlowLoginTest
	As a yandex user
	In order to have my account secure
	I want to able to login only with own credentials

Scenario: Login to yandex email
	When I click login button
	And I login with credentials
	Then The Home page for the User Account should be opened
