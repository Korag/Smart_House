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

        #region SingleDevice

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

        [HttpGet]
        [Route("api/GetSingleSmartDevice")]
        public SmartDevice GetSingleSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd;
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

        [HttpPost]
        [Route("api/SetSpecificPropertyOfSingleSmartDevice")]
        public void SetSpecificPropertyOfSingleSmartDevice(string id, string propertyName, string propertyValue)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);

            _context.SetPropertyOfSingleSmartDevice(sd, propertyName, propertyValue);
        }

        #endregion

        #region CollectionOfSmartDevices

        [HttpGet]
        [Route("api/GetAllSmartDevices")]
        public List<SmartDevice> GetAllSmartDevices(string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetSmartDevicesCollection(propertyName).ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWhichAreDisabled")]
        public List<SmartDevice> GetAllSmartDevicesWhichAreDisabled(string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWhichAreDisabled(propertyName).ToList();
            return SmartDevicesList;
        }

        #endregion

        #region DepreciatedGetteresOfCollection

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

        #endregion

        #region DepreciatedPostSettersOfSingleProperty

        [HttpPost]
        [Route("api/SetStateOfSingleSmartDevice")]
        public void SetStateOfSingleSmartDevice(string id, string state)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            _context.SetStateOfSingleSmartDevice(sd, state);
        }

        [HttpPost]
        [Route("api/SetLocalizationOfSingleSmartDevice")]
        public void SetLocalizationOfSingleSmartDevice(string id, string localization)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            _context.SetLocalizationOfSingleSmartDevice(sd, localization);
        }


        [HttpPost]
        [Route("api/SetTypeOfSingleSmartDevice")]
        public void SetTypeOfSingleSmartDevice(string id, string type)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            _context.SetTypeOfSingleSmartDevice(sd, type);
        }

        [HttpPost]
        [Route("api/SetNameOfSingleSmartDevice")]
        public void SetNameOfSingleSmartDevice(string id, string name)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            _context.SetNameOfSingleSmartDevice(sd, name);
        }

        #endregion
    }
}