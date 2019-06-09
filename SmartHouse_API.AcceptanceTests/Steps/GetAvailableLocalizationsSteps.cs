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
    [Binding, Scope(Tag = "mytag2")]
    public class GetAvailableLocalizationsSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private List<Localization> _result;


        [When(@"Client sent get request in order to get available localization")]
        public void WhenClientSentGetRequestInOrderToGetAvailableLocalization()
        {
            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetAvailableLocalizations").Result;
            _result = JsonConvert.DeserializeObject<List<Localization>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty list")]
        public void ThenTheClientShouldNotGetEmptyList()
        {
            Assert.That(_result, Is.Not.Empty);

        }

        [Then(@"The client should get list of available localization")]
        public void ThenTheClientShouldGetListOfAvailableLocalization()
        {
            Assert.That(_result, Is.TypeOf<List<Localization>>());
        }

    }
}
