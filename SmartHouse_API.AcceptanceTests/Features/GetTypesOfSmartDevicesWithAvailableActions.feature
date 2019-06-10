Feature: GetTypesOfSmartDevicesWithAvailableActions
	In order to get types of smart devices with available actions
	Client should send get request to web API
	As a result of this web request client gets all types of smart devices with available actions

@GetTypesOfSmartDevicesWithAvailableActions
Scenario: Get types of smart devices with available actions
	When Client sent get request in order to get types of smart devices with available actions
	Then The client should not get empty list
	Then The client should get list of types with actions
