using Newtonsoft.Json;
using NUnit.Framework;
using SmartHouse_API.Models;
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
        private List<TypeActions> _result;

        [When(@"Client sent get request in order to get available actions of single type smart device")]
        public void WhenClientSentGetRequestInOrderToGetAvailableActionsOfSingleTypeSmartDevice()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetTypesOfSmartDevicesWithAvailableActions").Result;
            _result = JsonConvert.DeserializeObject<List<TypeActions>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty list")]
        public void ThenTheClientShouldNotGetEmptyList()
        {
            Assert.That(_result, Is.Not.Empty);
        }

        [Then(@"The client should get list of actions of type")]
        public void ThenTheClientShouldGetListOfActionsOfType()
        {
            Assert.That(_result, Is.TypeOf<List<TypeActions>>());
        }


    }
}
