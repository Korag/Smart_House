﻿using MongoDB.Bson;
using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartHouse_API.Controllers
{

    /// <summary>
    /// SmartDevicesController provides an actions to add/modify/check MongoDB documents such as Localization/TypeActions/SmartDevice.
    /// </summary>
    public class SmartDevicesController : ApiController
    {
        private IDbOperative _context;

        /// <summary>
        /// Standard Constructor which initializes instance of DbContext class.
        /// </summary>
        public SmartDevicesController(IDbOperative context)
        {
            _context = context;
        }

        #region SingleDevice

        /// <summary>
        /// This function returns bool "Disabled" property of SmartDevice which id was passed as an argument. 
        /// </summary>
        [System.Web.Mvc.Authorize]
        [HttpGet]
        [Route("api/CheckIfSingleSmartDeviceIsDisabled")]
        public bool CheckIfSingleSmartDeviceIsDisabled(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd.Disabled;
        }

        /// <summary>
        /// This function returns string "State" property of SmartDevice which id was passed as an argument.
        /// </summary>
        [HttpGet]
        [Route("api/GetStateOfSingleSmartDevice")]
        public string GetStateOfSingleSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd.State;
        }

        /// <summary>
        /// This function finds out if instance of SmartDevice which id was passed as an argument has value true on property "Disabled".
        /// If conditions have been fulfilled this property would have given property "Disabled" value false.
        /// </summary>
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

        /// <summary>
        /// This function finds out if instance of SmartDevice which id was passed as an argument has value true on property "Disabled".
        /// If conditions have been fulfilled this property would have given property "Disabled" value false.
        /// </summary>
        [HttpGet]
        [Route("api/GetAvailableLocalizations")]
        public ICollection<Localization> GetAvailableLocalizations()
        {
            var Localizations = _context.GetLocalizations();
            return Localizations;
        }

        /// <summary>
        /// This function adds new Localization to DictionaryCollection called Localizations which stores available places in house to locate SmartDevice.
        /// </summary>
        [HttpPost]
        [Route("api/AddNewLocalization")]
        public void AddNewLocalization(string name, string icon)
        {
            _context.AddNewLocalization(name, icon);
        }

        /// <summary>
        /// This function gives opportunity to delete Localization from DictionaryCollection called Localizations.
        /// </summary>
        [HttpPost]
        [Route("api/DeleteLocalization")]
        public void DeleteLocalization(string name)
        {
            _context.DeleteLocalization(name);
        }

        /// <summary>
        /// This function gets Key-Value pairs of "Types" of SmartDevices with "AvailableActions" which they can perform.
        /// </summary>
        [HttpGet]
        [Route("api/GetTypesOfSmartDevicesWithAvailableActions")]
        public ICollection<TypeActions> GetTypesOfSmartDevicesWithAvailableActions()
        {
            var TypesOfSmartDevicesWithActions = _context.GetTypesOfSmartDevicesWithAvailableActions();
            return TypesOfSmartDevicesWithActions;
        }

        /// <summary>
        /// This function gets Key-Value pair of "Type" of SmartDevice with "AvailableActions" but only for one "Type" passed as an argument.
        /// </summary>
        [HttpGet]
        [Route("api/GetAvailableActionsOfSingleTypeSmartDevice")]
        public ICollection<string> GetAvailableActionsOfSingleTypeSmartDevice(string type)
        {
            var AvailableActions = _context.GetAvailableActionsOfSingleTypeSmartDevice(type);
            return AvailableActions;
        }


        /// <summary>
        /// This function gets "Types" of SmartDevices which are stored in database.
        /// </summary>
        [HttpGet]
        [Route("api/GetAvailableTypes")]
        public ICollection<string> GetAvailableTypes()
        {
            var Type = _context.GetTypes();
            return Type;
        }

        /// <summary>
        /// This function deletes "Type" property value passed as an argument with linked array of "AvailableActions".
        /// </summary>
        [HttpPost]
        [Route("api/DeletePairTypeAvailableActions")]
        public void DeletePairTypeAvailableActions(string type)
        {
            _context.DeletePairTypeAvailableActions(type);
        }

        /// <summary>
        /// This function adds "Type" property with linked array of "AvailableActions".
        /// </summary>
        [HttpPost]
        [Route("api/AddNewPairTypeAvailableActions")]
        public void AddNewPairTypeAvailableActions(string type, [FromUri]ICollection<string> availableActions)
        {
            _context.AddNewPairTypeAvailableActions(type, availableActions);
        }


        /// <summary>
        /// This function adds "Type" property with linked array of "AvailableActions".
        /// </summary>
        [HttpGet]
        [Route("api/GetSingleSmartDevice")]
        public SmartDevice GetSingleSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
            return sd;
        }

        /// <summary>
        /// This function adds new SmartDevice object to database with propety values defined in arguments.
        /// </summary>
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

        /// <summary>
        /// This function remove concrete instance of SmartDevice from database by "Id" property value passed as an argument.  
        /// </summary>
        [HttpPost]
        [Route("api/DeleteSmartDeviceFromCollection")]
        public void DeleteSmartDevice(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            _context.DeleteSmartDeviceFromCollection(_id);
        }

        /// <summary>
        /// This function removes concrete instance of SmartDevice from database by "Id" property value passed as an argument.  
        /// </summary>
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

        /// <summary>
        /// This function returns list of all SmartDevices stored in database. Passed argument is used as property by which the result list will be ordered.
        /// </summary>
        [HttpGet]
        [Route("api/GetAllSmartDevices")]
        public List<SmartDevice> GetAllSmartDevices(string propertyName = "Type")
        {
            List<SmartDevice> SmartDevicesList = _context.GetSmartDevicesCollection(propertyName).ToList();
            return SmartDevicesList;
        }

        /// <summary>
        /// This function returns list of all SmartDevices stored in database which currently have value true in boolean property "Disabled". Passed argument is used as property by which the result list will be ordered.
        /// </summary>
        [HttpGet]
        [Route("api/GetAllSmartDevicesWhichAreDisabled")]
        public List<SmartDevice> GetAllSmartDevicesWhichAreDisabled(string propertyName)
        {
            List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWhichAreDisabled(propertyName).ToList();
            return SmartDevicesList;
        }

        /// <summary>
        /// This function returns list of all SmartDevices stored in database. List will contain only devices which currently have the same value of given property passed as an argument (propertyName) and (propertyValue). The last passed argument is used as property by which the result list will be ordered.
        /// </summary>
        [HttpGet]
        [Route("api/GetCollectionOfSmartDevicesWithSameProperty")]
        public List<SmartDevice> GetCollectionOfSingleSmartDevicesWithSameProperty(string propertyName, string propertyValue, string propertyOrder)
        {
            List<SmartDevice> SmartDevicesList = _context.GetCollectionOfSmartDevicesWithSameProperty(propertyName, propertyValue, propertyOrder).ToList();
            return SmartDevicesList;
        }

        #endregion

        #region DepreciatedGetteresOfCollection

        //[HttpGet]
        //[Route("api/GetAllSmartDevicesWithSameName")]
        //public List<SmartDevice> GetAllSmartDevicesWithSameName(string name, string propertyName)
        //{
        //    List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameName(name, propertyName).ToList();
        //    return SmartDevicesList;
        //}

        //[HttpGet]
        //[Route("api/GetAllSmartDevicesWithSameType")]
        //public List<SmartDevice> GetAllSmartDevicesWithSameType(string type, string propertyName)
        //{
        //    List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameType(type, propertyName).ToList();
        //    return SmartDevicesList;
        //}

        //[HttpGet]
        //[Route("api/GetAllSmartDevicesWithSameLocalization")]
        //public List<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization, string propertyName)
        //{
        //    List<SmartDevice> SmartDevicesList = _context.GetAllSmartDevicesWithSameLocalization(localization, propertyName).ToList();
        //    return SmartDevicesList;
        //}

        #endregion

        #region DepreciatedPostSettersOfSingleProperty

        //[HttpPost]
        //[Route("api/SetStateOfSingleSmartDevice")]
        //public void SetStateOfSingleSmartDevice(string id, string state)
        //{
        //    ObjectId _id = ObjectId.Parse(id);
        //    SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
        //    _context.SetStateOfSingleSmartDevice(sd, state);
        //}

        //[HttpPost]
        //[Route("api/SetLocalizationOfSingleSmartDevice")]
        //public void SetLocalizationOfSingleSmartDevice(string id, string localization)
        //{
        //    ObjectId _id = ObjectId.Parse(id);
        //    SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
        //    _context.SetLocalizationOfSingleSmartDevice(sd, localization);
        //}


        //[HttpPost]
        //[Route("api/SetTypeOfSingleSmartDevice")]
        //public void SetTypeOfSingleSmartDevice(string id, string type)
        //{
        //    ObjectId _id = ObjectId.Parse(id);
        //    SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
        //    _context.SetTypeOfSingleSmartDevice(sd, type);
        //}

        //[HttpPost]
        //[Route("api/SetNameOfSingleSmartDevice")]
        //public void SetNameOfSingleSmartDevice(string id, string name)
        //{
        //    ObjectId _id = ObjectId.Parse(id);
        //    SmartDevice sd = _context.GetSingleSmartDeviceFromCollection(_id);
        //    _context.SetNameOfSingleSmartDevice(sd, name);
        //}

        #endregion
    }
}