using MongoDB.Bson;
using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartHouse_API.Controllers
{
    public class SmartDevicesController : ApiController
    {
        private IDbOperative _context;

        public SmartDevicesController()
        {
            _context = new DbOperativeMethods();
        }

        [HttpGet]
        [Route("api/GetAllSmartDevices")]
        public List<SmartDevice> GetAllSmartDevices()
        {
            List<SmartDevice> SmartDevicesList = _context.GetSmartDevicesCollection().ToList();
            return SmartDevicesList;
        }

        [HttpGet]
        [Route("api/GetAllSmartDevices/{id}")]
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
    }
}