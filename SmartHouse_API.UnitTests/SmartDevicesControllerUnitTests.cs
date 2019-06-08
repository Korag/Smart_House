using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using SmartHouse_API.Controllers;
using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System.Collections.Generic;

namespace SmartHouse_API.UnitTests
{

    [TestFixture]
    public class SmartDevicesControllerUnitTests
    {
        private SmartDevicesController _controller;
        private Mock<IDbOperative> _contextDbMock;
        private ObjectId _deviceId;
        private ObjectId _deviceOvenId;
        [SetUp]
        public void SetUp()
        {
            _contextDbMock = new Mock<IDbOperative>();
            _controller = new SmartDevicesController(_contextDbMock.Object);
            //5caa438add8c6316e4b491cc is random Id
            _deviceId = ObjectId.Parse("5caa438add8c6316e4b491cc");
            _deviceOvenId = ObjectId.Parse("5cd6e8bedd8c63152c42f683");
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsADisabledDevice_ReturnItsState()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", Disabled = true });

            var result = _controller.CheckIfSingleSmartDeviceIsDisabled(_deviceId.ToString());

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsADisabledDevice_ReturnItsState_Oven()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceOvenId))
                .Returns(new Models.SmartDevice { Id = _deviceOvenId, Name = "DeviceName", Disabled = true });

            var result = _controller.CheckIfSingleSmartDeviceIsDisabled(_deviceOvenId.ToString());

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsNotADisabledDevice_ReturnItsState()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", Disabled = false });

            var result = _controller.CheckIfSingleSmartDeviceIsDisabled(_deviceId.ToString());

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsNotADisabledDevice_ReturnItsState_Oven()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceOvenId))
                .Returns(new Models.SmartDevice { Id = _deviceOvenId, Name = "DeviceName", Disabled = false });

            var result = _controller.CheckIfSingleSmartDeviceIsDisabled(_deviceOvenId.ToString());

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenIdIsWrong_ThrowNullReferenceExceptionException()
        {
            string wrongId = "5dda438add8c6316e4b491cc";

            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", Disabled = true });

            Assert.That(() => _controller.CheckIfSingleSmartDeviceIsDisabled(wrongId),
                Throws.TypeOf<System.NullReferenceException>());
        }

        [Test]
        public void GetStateOfSingleSmartDevice_WhenStateIsNull_DoesNotThrowNullReferenceExceptionException()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", State=null });


            Assert.DoesNotThrow(() => _controller.GetStateOfSingleSmartDevice(_deviceId.ToString()));
        }

        [Test]
        public void GetStateOfSingleSmartDevice_WhenStateIsNotNull_ReturnItsState()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", State = "TEST" });

            var result = _controller.GetStateOfSingleSmartDevice(_deviceId.ToString());

            Assert.That(result, Is.EqualTo("TEST"));
        }

        [Test]
        public void GetStateOfSingleSmartDevice_WhenObjectWithSuchIdDoesNotExists_ThrowNullReferenceExceptionException()
        {
            string wrongId = "5dda438add8c6316e4b491cc";

            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName"});

            Assert.That(() => _controller.GetStateOfSingleSmartDevice(wrongId),
                           Throws.TypeOf<System.NullReferenceException>());
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabledAndSwitchOn_WhenDeviceIsDisabled_DoesNotThrowNullReferenceExceptionException()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", Disabled = true });

            Assert.DoesNotThrow(() => _controller.CheckIfSingleSmartDeviceIsDisabledAndSwitchOn(_deviceId.ToString()));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabledAndSwitchOn_WhenDisabledPropertyIsNull_DoesNotThrowNullReferenceExceptionException()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName"});

            Assert.DoesNotThrow(() => _controller.CheckIfSingleSmartDeviceIsDisabledAndSwitchOn(_deviceId.ToString()));
        }

        [Test]
        public void GetAvailableLocalizations_WhenDbContainsLocalizations_DoesNotThrowException()
        {
            _contextDbMock.Setup(x => x.GetLocalizations())
                .Returns(new List<Localization> {
                    new Localization{ Name="Localization1" },
                       new Localization{ Name="Localization2" },
                          new Localization{ Name="Localization3" }
                });

            Assert.DoesNotThrow(() => _controller.GetAvailableLocalizations());
        }

        [Test]
        public void GetAvailableLocalizations_WhenDbContainsLocalizations_ResultIsNotEmpty()
        {
            _contextDbMock.Setup(x => x.GetLocalizations())
                     .Returns(new List<Localization> {
                    new Localization{ Icon="Icon1" },
                       new Localization{ Icon="Icon2" },
                          new Localization{ Icon="Icon3" }
                     });

            Assert.IsNotEmpty(_controller.GetAvailableLocalizations());
        }


        [Test]
        public void GetAvailableLocalizations_WhenDbDoesntContainsLocalizations_ResultIsEmpty()
        {
            _contextDbMock.Setup(x => x.GetLocalizations())
                .Returns(new List<Localization> { });

            Assert.IsEmpty(_controller.GetAvailableLocalizations());
        }


        [Test]
        public void GetTypesOfSmartDevicesWithAvailableActions_WhenDbContainsTypesWithActions_ResultIsNotNull()
        {
            _contextDbMock.Setup(x => x.GetTypesOfSmartDevicesWithAvailableActions())
                .Returns(new List<TypeActions> { new TypeActions {Id= _deviceId, Type="TestType"} });

            Assert.IsNotNull(_controller.GetTypesOfSmartDevicesWithAvailableActions());
        }

        [Test]
        public void GetTypesOfSmartDevicesWithAvailableActions_WhenDbDoesntContainsLocalizations_ResultIsEmpty()
        {
            _contextDbMock.Setup(x => x.GetTypesOfSmartDevicesWithAvailableActions())
                .Returns(new List<TypeActions>());

            Assert.IsEmpty(_controller.GetTypesOfSmartDevicesWithAvailableActions());
        }
    }
}
