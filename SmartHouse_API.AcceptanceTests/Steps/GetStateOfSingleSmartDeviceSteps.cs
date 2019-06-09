using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding]
    public class GetStateOfSingleSmartDeviceSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private string _result;
        private string _deviceId;

        [Given(@"Client entered smart device id")]
        public void GivenClientEnteredSmartDeviceId()
        {
            _deviceId = "5cc76761dd8c634d442bc77a";

        }

        [When(@"Client sent get request in order to get state of single smart device")]
        public void WhenClientSentGetRequestInOrderToGetStateOfSingleSmartDevice()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetStateOfSingleSmartDevice?id={_deviceId}").Result;
            _result = JsonConvert.DeserializeObject<string>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty string")]
        public void ThenTheClientShouldNotGetEmptyString()
        {
            Assert.That(_result, Is.Not.EqualTo(""));
        }

    }
}
