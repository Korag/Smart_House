using MongoDB.Bson;
using NUnit.Framework;
using SmartHouse_API.Controllers;
using SmartHouse_API.DAL;
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

        private ObjectId _existingDeviceId = ObjectId.Parse("5cab1c91147378a8581099cf");

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

    }
}
