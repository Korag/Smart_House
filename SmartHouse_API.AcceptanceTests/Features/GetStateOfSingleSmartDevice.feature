Feature: GetStateOfSingleSmartDevice
	In order to get state of single smart device
	Client should send get request to web API with id of selected smart device
	As a result of this web request client gets state of single smart device as string

@GetStateOfSingleSmartDevice
Scenario: Get state of single smart device
	Given Client entered smart device id
	When Client sent get request in order to get state of single smart device
	Then The client should not get empty string
