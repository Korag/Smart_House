Feature: AddNewLocalization
	In order to add localization
	Client should send post request with localization name and icon
	As a result of this request in database should be new localization

@AddNewLocalization
Scenario: Check if smart device is disabled and switch on
	Given Client entered localization name and icon
	When Client sent post request
	Then In database should be new localization with entered name and icon
