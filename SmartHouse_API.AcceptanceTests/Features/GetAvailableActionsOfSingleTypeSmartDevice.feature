Feature: GetAvailableActionsOfSingleTypeSmartDevice
	In order to get available actions of single type smart device
	Client should send get request to web API
	As a result of this web request client gets all available actions of single type smart device

@GetAvailableActionsOfSingleTypeSmartDevice
Scenario: Get available actions of single type smart device
	When Client sent get request in order to get available actions of single type smart device
	Then The client should not get empty list
	Then The client should get list of actions of type
