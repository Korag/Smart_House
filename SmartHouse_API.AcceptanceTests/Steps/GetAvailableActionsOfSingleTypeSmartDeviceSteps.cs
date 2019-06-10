using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "GetAvailableActionsOfSingleTypeSmartDevice")]
    public class GetAvailableActionsOfSingleTypeSmartDeviceSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private List<string> _result;
        private string _deviceType;

        [Given(@"Client entered smart device type")]
        public void GivenClientEnteredSmartDeviceType()
        {
            _deviceType = "Fridge";
        }

        [When(@"Client sent get request in order to get available actions of single type smart device")]
        public void WhenClientSentGetRequestInOrderToGetAvailableActionsOfSingleTypeSmartDevice()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetAvailableActionsOfSingleTypeSmartDevice/?type={_deviceType}").Result;
            _result = JsonConvert.DeserializeObject<List<string>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty list")]
        public void ThenTheClientShouldNotGetEmptyList()
        {
            Assert.That(_result, Is.Not.Empty);
        }

    }
}
