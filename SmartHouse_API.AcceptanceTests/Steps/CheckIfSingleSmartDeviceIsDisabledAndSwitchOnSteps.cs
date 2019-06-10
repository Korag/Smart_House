using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "CheckIfSingleSmartDeviceIsDisabledAndSwitchOn")]
    public class CheckIfSingleSmartDeviceIsDisabledAndSwitchOnSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private bool _result;
        private string _deviceId;

        [Given(@"Client entered id of smart device")]
        public void GivenClientEnteredIdOfSmartDevice()
        {
            _deviceId = "5cc76761dd8c634d442bc77a";
        }

        [When(@"Client sent get request")]
        public void WhenClientSentGetRequest()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/CheckIfSingleSmartDeviceIsDisabledAndSwitchOn/?id={_deviceId}").Result;
        }

        [Then(@"Client should switch on smart device")]
        public void ThenClientShouldSwitchOnSmartDevice()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/CheckIfSingleSmartDeviceIsDisabled/?id={_deviceId}").Result;
            _result = JsonConvert.DeserializeObject<bool>(_responseContent.Content.ReadAsStringAsync().Result);
            Assert.That(_result, Is.EqualTo(false));
        }

    }
}
