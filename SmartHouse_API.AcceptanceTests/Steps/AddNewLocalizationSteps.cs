﻿using Newtonsoft.Json;
using NUnit.Framework;
using SmartHouse_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace SmartHouse_API.AcceptanceTests.Steps
{
    [Binding, Scope(Tag = "AddNewLocalization")]
    public class AddNewLocalizationSteps
    {
        private HttpClient _client = new HttpClient();
        private HttpResponseMessage _responseContent;
        private List<Localization> _localizationsFromDb;
        private Localization _newLocalization;
        private string _localizationName;
        private string _localizationIcon;

        [Given(@"Client entered localization name and icon")]
        public void GivenClientEnteredLocalizationNameAndIcon()
        {
            _localizationName = "testName";
            _localizationIcon = "testIcon";
        }

        [When(@"Client sent post request")]
        public void WhenClientSentPostRequest()
        {
            _responseContent = _client.PostAsync
                ($"https://smarthouseapii.azurewebsites.net/api/AddNewLocalization/?name={_localizationName}&icon={_localizationIcon}",
                null).Result;

            _responseContent = _client.GetAsync($"https://smarthouseapii.azurewebsites.net/api/GetAvailableLocalizations").Result;
            _localizationsFromDb = JsonConvert.DeserializeObject<List<Localization>>(_responseContent.Content.ReadAsStringAsync().Result);
        }

        [Then(@"In database should be new localization with entered name and icon")]
        public void ThenInDatabaseShouldBeNewLocalizationWithEnteredNameAndIcon()
        {
            _newLocalization = _localizationsFromDb.FirstOrDefault(l => l.Name == _localizationName && l.Icon == _localizationIcon);
            Assert.That(_newLocalization, Is.Not.Null);

            Dispose();
        }

        private void Dispose()
        {
            _responseContent = _client.PostAsync
                ($"https://smarthouseapii.azurewebsites.net/api/DeleteLocalization/?name={_localizationName}",
                null).Result;
        }

    }
}
