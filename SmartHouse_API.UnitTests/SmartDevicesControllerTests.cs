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
        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsADisabledDevice_ReturnItsState()
        {
            var deviceId = ObjectId.Parse("5caa438add8c6316e4b491cc");

            var contextDbMock = new Mock<IDbOperative>();
            contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(deviceId))
                .Returns(new Models.SmartDevice { Id = deviceId, Name = "DeviceName", Disabled = true });

            SmartDevicesController controller = new SmartDevicesController(contextDbMock.Object);

            var result = controller.CheckIfSingleSmartDeviceIsDisabled(deviceId.ToString());

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenThereIsNotADisabledDevice_ReturnItsState()
        {
            var deviceId = ObjectId.Parse("5caa438add8c6316e4b491cc");

            var contextDbMock = new Mock<IDbOperative>();
            contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(deviceId))
                .Returns(new Models.SmartDevice { Id = deviceId, Name = "DeviceName", Disabled = false });

            SmartDevicesController controller = new SmartDevicesController(contextDbMock.Object);

            var result = controller.CheckIfSingleSmartDeviceIsDisabled(deviceId.ToString());

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckIfSingleSmartDeviceIsDisabled_WhenIdIsWrong_ThrowException()
        {
            var deviceId = ObjectId.Parse("5caa438add8c6316e4b491cd");

            var contextDbMock = new Mock<IDbOperative>();
            contextDbMock.Setup(x => x.GetSingleSmartDeviceFromCollection(new ObjectId("5dda438add8c6316e4b491cc")))
                .Returns(new Models.SmartDevice { Id = new ObjectId("5dda438add8c6316e4b491cc"), Name = "DeviceName", Disabled = true });

            SmartDevicesController controller = new SmartDevicesController(contextDbMock.Object);

            Assert.That(() => controller.CheckIfSingleSmartDeviceIsDisabled(deviceId.ToString()),
                Throws.TypeOf<System.NullReferenceException>());
        }
    }
}
