﻿using MongoDB.Bson;
using NUnit.Framework;
using SmartHouse_API.Controllers;
using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_API.UnitTests
{
    [TestFixture]
    class SmartDevicesControllerIntegrationTests
    {
        private SmartDevicesController _controller;
        private DbContext _mongoConfig;
        private IDbOperative _context;

        private ObjectId _existingDeviceId = ObjectId.Parse("5caa623cdd8c6533985073bd");

        [SetUp]
        public void SetUp()
        {
            _mongoConfig = new DbContext();
            _context = new DbOperativeMethods(_mongoConfig);
            _controller = new SmartDevicesController(_context);
        }

        [Test]
        public void GetLocalizations_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _context.GetLocalizations());
        }

        [Test]
        public void AddNewLocalization_CheckIfLocalizationIsAddedToDatabase()
        {
            string name = "TEST";
            string icon = "ICON";

            _context.AddNewLocalization(name, icon);
            var result =  _context.GetLocalizations();

            Localization testLocalization = new Localization
            {
                Name = "TEST",
                Icon = "ICON"
            };

            Assert.That(() => result.Where(z=>z.Name==name && z.Icon == icon).Count() == 1);

            _context.DeleteLocalization(name);
        }

        [Test]
        public void GetTypesOfSmartDevicesWithAvailableActions_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _context.GetTypesOfSmartDevicesWithAvailableActions());
        }

        [Test]
        public void GetAvailableActionsOfSingleTypeSmartDevice_ResultIsEmptyWhenTypeIsEmptyString()
        {
            Assert.IsNull(_context.GetAvailableActionsOfSingleTypeSmartDevice(""));
        }

        [Test]
        public void GetAvailableActionsOfSingleTypeSmartDevice_WhenTypeArgumentDoesntExistInDatabase_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _context.GetAvailableActionsOfSingleTypeSmartDevice("TEST"));
        }

        [Test]
        public void AddNewPairTypeAvailableActions_WhenAvailableActionsArrayIsNull_CheckIfPairTypeAvailableActionsIsAddedToDatabase()
        {
            string type = "TEST";

            _context.AddNewPairTypeAvailableActions(type,null);
            var result = _context.GetTypes();

            Assert.That(() => result.Contains(type));

            _context.DeletePairTypeAvailableActions(type);
        }

        [Test]
        public void AddSmartDeviceToCollection_CheckIfSmartDeviceIsAddedToDatabase()
        {
            SmartDevice smartDevice = new SmartDevice
            {
                Id = ObjectId.Parse("5cab1c95187374a2581069cf"),
                Name = "TEST"
            };

            _context.AddSmartDeviceToCollection(smartDevice);
            var result = _context.GetSmartDevicesCollection("Name");
            var addedSmartDevice = result.Where(z => z.Id == smartDevice.Id).FirstOrDefault();

            Assert.That(() => addedSmartDevice != null);

            _context.DeleteSmartDeviceFromCollection(smartDevice.Id);
        }

        [Test]
        public void AddSmartDeviceToCollection_WhenDeviceWithSuchIdExistsInDatabase_ThrowsMongoDriverWriteException()
        {
            SmartDevice smartDevice = new SmartDevice
            {
                Id = _existingDeviceId,
                Name = "TEST"
            };

            
            var result = _context.GetSmartDevicesCollection("Name");
            var addedSmartDevice = result.Where(z => z.Id == smartDevice.Id).FirstOrDefault();

            Assert.That(() => _context.AddSmartDeviceToCollection(smartDevice),
              Throws.TypeOf<MongoDB.Driver.MongoWriteException>());
        }

        [Test]
        public void ChangeSmartDeviceState_WhenStateIsNull_ResultIsEqual()
        {
            ObjectId newId = ObjectId.Parse("5cab1c93187378a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
                State = null
            };


            _context.AddSmartDeviceToCollection(smartDevice);
            _context.ChangeSmartDeviceState(smartDevice, "TEST");

            var result = _context.GetSingleSmartDeviceFromCollection(newId);

            var resultState = result.State;
            Assert.AreEqual(resultState, "TEST");

            _context.DeleteSmartDeviceFromCollection(newId);
        }

        [Test]
        public void ChangeSmartDeviceState_WhenDuringOperationsSmartDeviceWasDeleted_ResultIsEqual()
        {
            ObjectId newId = ObjectId.Parse("5cab1c94187378a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
                State = null
            };


            _context.AddSmartDeviceToCollection(smartDevice);

            _context.DeleteSmartDeviceFromCollection(newId);

            Assert.DoesNotThrow(() => _context.ChangeSmartDeviceState(smartDevice, "TEST"));
        }

        [Test]
        public void GetSingleSmartDeviceFromCollection_WhenSmartDeviceDoestExists_DoesNotThrow()
        {
            ObjectId newId = ObjectId.Parse("5cab1c94187778a2581069cf");

            Assert.DoesNotThrow(() => _context.GetSingleSmartDeviceFromCollection(newId));
        }

        [Test]
        public void SmartDeviceSwitchOne_WhenDisabledPropertyIsNotDeclared_ResultIsExpected()
        {
            ObjectId newId = ObjectId.Parse("5aab1c94187378a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
            };

            _context.AddSmartDeviceToCollection(smartDevice);

            _context.SmartDeviceSwitchOne(smartDevice);

            Assert.AreEqual(smartDevice.Disabled, false);

            _context.DeleteSmartDeviceFromCollection(newId);
        }

        [Test]
        public void SmartDeviceSwitchOne_WhenDisabledPropertyIsTrue_ResultIsExpected()
        {
            ObjectId newId = ObjectId.Parse("5aab1c94187378a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
            };

            _context.AddSmartDeviceToCollection(smartDevice);

            _context.SmartDeviceSwitchOne(smartDevice);

            Assert.AreEqual(smartDevice.Disabled, false);

            _context.DeleteSmartDeviceFromCollection(newId);
        }

        [Test]
        public void DeleteSmartDeviceFromCollection_WhenToDeleteSmartDeviceDoesntExistInDatabase_DoesNotThrow()
        {
            ObjectId newId = ObjectId.Parse("5aab1c94187375a2581069cf");

            Assert.DoesNotThrow(() =>_context.DeleteSmartDeviceFromCollection(newId));
        }

        [Test]
        public void DeleteSmartDeviceFromCollection_WhenToDeleteSmartDeviceExistInDatabase_DoesNotThrow()
        {
            ObjectId newId = ObjectId.Parse("5cab1c94117778a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
            };

            _context.AddSmartDeviceToCollection(smartDevice);

            Assert.DoesNotThrow(() => _context.DeleteSmartDeviceFromCollection(newId));
        }


        [Test]
        public void SetSpecificPropertyOfSingleSmartDevice_WhenPropertIsUnset_ResultIsAsExpected()
        {
            ObjectId newId = ObjectId.Parse("5cab1c94117728a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
            };

            _context.AddSmartDeviceToCollection(smartDevice);

            _context.SetPropertyOfSingleSmartDevice(smartDevice, "Type", "TestType");

            string newType = _context.GetSingleSmartDeviceFromCollection(newId).Type;
            Assert.AreEqual(newType, "TestType");

            _context.DeleteSmartDeviceFromCollection(newId);
        }

        [Test]
        public void SetSpecificPropertyOfSingleSmartDevice_WhenPropertyIsNull_ResultIsAsExpected()
        {
            ObjectId newId = ObjectId.Parse("5cac1c94117728a2581069cf");

            SmartDevice smartDevice = new SmartDevice
            {
                Id = newId,
                Name = "TEST",
                Type = null
            };

            _context.AddSmartDeviceToCollection(smartDevice);

            _context.SetPropertyOfSingleSmartDevice(smartDevice, "Type", "TestType");

            string newType = _context.GetSingleSmartDeviceFromCollection(newId).Type;
            Assert.AreEqual(newType, "TestType");

            _context.DeleteSmartDeviceFromCollection(newId);
        }
    }
}
