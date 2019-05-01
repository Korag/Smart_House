using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using SmartHouse_API.Controllers;
using SmartHouse_API.DAL;

namespace SmartHouse_API.UnitTests
{


    [TestFixture]
    public class SmartDevicesControllerTests
    {
        private SmartDevicesController _controller;
        private Mock<IDbOperative> _contextDbMock;
        private ObjectId _deviceId;
        [SetUp]
        public void SetUp()
        {
            _contextDbMock = new Mock<IDbOperative>();
            _controller = new SmartDevicesController(_contextDbMock.Object);
            //5caa438add8c6316e4b491cc is random Id
            _deviceId = ObjectId.Parse("5caa438add8c6316e4b491cc");
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
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsNotADisabledDevice_ReturnItsState()
        {
            _contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(_deviceId))
                .Returns(new Models.SmartDevice { Id = _deviceId, Name = "DeviceName", Disabled = false });

            var result = _controller.CheckIfSingleSmartDeviceIsDisabled(_deviceId.ToString());

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
    }
}
