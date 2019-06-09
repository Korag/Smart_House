using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "GetAvailableTypes")]

    public class GetAvailableTypesSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private List<string> _result;

        [When(@"Client sent get request in order to get available smart devices types")]
        public void WhenClientSentGetRequestInOrderToGetAvailableSmartDevicesTypes()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetAvailableTypes").Result;
            _result = JsonConvert.DeserializeObject<List<string>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty list")]
        public void ThenTheClientShouldNotGetEmptyList()
        {
            Assert.That(_result, Is.Not.Empty);
        }

    }
}
