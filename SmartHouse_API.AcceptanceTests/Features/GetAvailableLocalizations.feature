Feature: GetAvailableLocalization
	In order to get available localizations from database
	Client should send get request to web API
	As a result of this web request client gets all available localizations from database

@mytag
Scenario: Get available localization
	When Client sent get request in order to get available localization
	Then The client should not get empty list
	Then The client should get list of available localization 
