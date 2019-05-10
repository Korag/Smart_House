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

        [System.Web.Mvc.Authorize]
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
        [Route("api/GetAvailableLocalizations")]
        public ICollection<string> GetAvailableLocalizations()
        {
            var Localizations = _context.GetLocalizations();
            return Localizations;
        }

        [HttpPost]
        [Route("api/AddNewLocalization")]
        public void AddNewLocalization(string name)
        {
            _context.AddNewLocalization(name);
        }

        [HttpGet]
        [Route("api/GetTypesOfSmartDevicesWithAvailableActions")]
        public ICollection<TypeActions> GetTypesOfSmartDevicesWithAvailableActions()
        {
            var TypesOfSmartDevicesWithActions = _context.GetTypesOfSmartDevicesWithAvailableActions();
            return TypesOfSmartDevicesWithActions;
        }

        [HttpGet]
        [Route("api/GetAvailableActionsOfSingleTypeSmartDevice")]
        public ICollection<string> GetAvailableActionsOfSingleTypeSmartDevice(string type)
        {
            var AvailableActions = _context.GetAvailableActionsOfSingleTypeSmartDevice(type);
            return AvailableActions;
        }

        [HttpPost]
        [Route("api/AddNewPairTypeAvailableActions")]
        public void AddNewPairTypeAvailableActions(string type, [FromUri]ICollection<string> availableActions)
        {
            _context.AddNewPairTypeAvailableActions(type, availableActions);
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
                Localization = localization,
                Disabled = disabled,

                State = state,
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
        public List<SmartDevice> GetAllSmartDevices(string propertyName = "Type")
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

        [HttpGet]
        [Route("api/GetCollectionOfSmartDevicesWithSameProperty")]
        public List<SmartDevice> GetCollectionOfSingleSmartDevicesWithSameProperty(string propertyName, string propertyValue, string propertyOrder)
        {
            List<SmartDevice> SmartDevicesList = _context.GetCollectionOfSmartDevicesWithSameProperty(propertyName, propertyValue, propertyOrder).ToList();
            return SmartDevicesList;
        }

        #endregion

        #region DepreciatedGetteresOfCollection

        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameName")]
        public List<SmartDevice> GetAllSmartDevicesWithSameName(string name, string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameName(name, propertyName).ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameType")]
        public List<SmartDevice> GetAllSmartDevicesWithSameType(string type, string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameType(type, propertyName).ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevicesWithSameLocalization")]
        public List<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization, string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameLocalization(localization, propertyName).ToList();
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