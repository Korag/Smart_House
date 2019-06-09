Feature: GetAvailableActionsOfSingleTypeSmartDevice
	In order to get available actions of single type smart device
	Client should send get request with type name
	As a result of this request client gets all actions of entered smart device type

@GetAvailableActionsOfSingleTypeSmartDevice
Scenario: Get available actions of single type smart device
	Given Client entered smart device type
	When Client sent get request in order to get available actions of single type smart device
	Then The client should not get empty list
