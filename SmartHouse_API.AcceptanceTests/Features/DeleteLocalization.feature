Feature: DeleteLocalization
	In order to delete localization
	Client should send post request with localization name
	As a result of this request in database should not be lozalization with entered name

@DeleteLocalization
Scenario: Delete localization
	Given Client entered localization name
	When Client sent post request
	Then In database should not be localization with entered
