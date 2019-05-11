using MongoDB.Bson;
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

        private ObjectId _existingDeviceId = ObjectId.Parse("5caa43bcdd8c6315382e2836");

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

            _context.AddNewLocalization(name);
            var result =  _context.GetLocalizations();

            Assert.That(() => result.Contains(name));

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
    }
}
