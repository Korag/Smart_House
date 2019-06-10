using Newtonsoft.Json;
using NUnit.Framework;
using SmartHouse_API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "GetAllSmartDevices")]
    public class GetAllSmartDevicesSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private List<SmartDevice> _result;


        [When(@"Client sent get request in order to get all smart devices")]
        public void WhenClientSentGetRequestInOrderToGetAllSmartDevices()
        {
            _responseContent = _client.GetAsync("https://smarthouseapii.azurewebsites.net/api/GetAllSmartDevices").Result;
            _result = JsonConvert.DeserializeObject<List<SmartDevice>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"The client should not get empty list")]
        public void ThenTheClientShouldNotGetEmptyList()
        {
            Assert.That(_result, Is.Not.Empty);

        }

        [Then(@"The client should get list of smart devices")]
        public void ThenTheClientShouldGetListOfSmartDevices()
        {
            Assert.That(_result, Is.TypeOf<List<SmartDevice>>());
        }


    }
}