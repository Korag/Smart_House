Feature: GetAvailableTypes
	In order to get available smart devices types
	Client should send get request
	As a result of this request client gets all available smart devices types

@GetAvailableTypes
Scenario: Get available types
	When Client sent get request in order to get available smart devices types
	Then The client should not get empty list
