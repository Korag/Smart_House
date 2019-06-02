Feature: SmartDevicesController
	In order to get smart devices from database
	Client should send get request to web API
	As a result of this web request client gets all smart devices from database

@mytag
Scenario: Get all smart devices from database
	When Client sent get request in order to get all smart devices
	Then The client should not get empty list
	Then The client should get list of smart devices
