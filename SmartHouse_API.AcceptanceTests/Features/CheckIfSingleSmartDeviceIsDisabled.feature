Feature: CheckIfSingleSmartDeviceIsDisabled
	In order to check if smart device is disabled
	Client should send get request with device Id
	As a result of this web request client gets true if device is disabled or false if its not

@CheckIfSingleSmartDeviceIsDisabled
Scenario: Check if smart device is disabled
	Given Client entered id of smart device
	When Client sent get request
	Then Client should get true or false as response
