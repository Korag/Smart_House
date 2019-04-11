using MongoDB.Bson;
using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartHouse_API.Controllers
{
    public class SmartDevicesController : ApiController
    {
        private IDbOperative _context;

        public SmartDevicesController(IDbOperative context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevices")]
        public List<SmartDevice> GetAllSmartDevices()
        {
            List<SmartDevice> SmartDevicesList = _context.GetSmartDevicesCollection().ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetSingleSmartDevice")]
        public SmartDevice GetSingleSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameName")]
        public List<SmartDevice> GetAllSmartDevicesWithSameName(string name)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameName(name).ToList();
            return SmartDevicesList;
        }


        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameType")]
        public List<SmartDevice> GetAllSmartDevicesWithSameType(string type)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameType(type).ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameLocalization")]
        public List<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameLocalization(localization).ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWhichAreDisabled")]
        public List<SmartDevice> GetAllSmartDevicesWhichAreDisabled()
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWhichAreDisabled().ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/CheckIfSingleSmartDeviceIsDisabled")]
        public bool CheckIfSingleSmartDeviceIsDisabled(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd.Disabled;
        }

        [HttpGet]
        [Route("api/GetStateOfSingleSmartDevice")]
        public string GetStateOfSingleSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd.State;
        }

        [HttpGet]
        [Route("api/CheckIfSingleSmartDeviceIsDisabledAndSwitchOn")]
        public void CheckIfSingleSmartDeviceIsDisabledAndSwitchOn(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            if (sd.Disabled)
            {
                _context.SmartDeviceSwitchOne(sd);
            }
        }

        [HttpPost]
        [Route("api/AddSmartDevice")]
        public void AddSmartDevice(string type, string name, string state, string localization, bool disabled)
        {
            SmartDevice sd = new SmartDevice
            {
                Type = type,
                Name = name,
                State = state,
                Localization = localization,
                Disabled = disabled
            };
            _context.AddSmartDeviceToCollection(sd);
        }

        [HttpPost]
        [Route("api/DeleteSmartDeviceFromCollection")]
        public void DeleteSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            _context.DeleteSmartDeviceFromCollection(_id);
        }
    }
}