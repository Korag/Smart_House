Feature: CheckIfSingleSmartDeviceIsDisabledAndSwitchOn
	In order to check if smart device is disabled and switch on in case if it is disabled
	Client should send get request with device id
	As a result of this web request client switches on device if its disabled

@CheckIfSingleSmartDeviceIsDisabledAndSwitchOn
Scenario: Check if smart device is disabled and switch on
	Given Client entered id of smart device
	When Client sent get request
	Then Client should switch on smart device