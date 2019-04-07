using SmartHouse_API.DAL;
using SmartHouse_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SmartHouse_API.Controllers
{
    public class SmartDevicesController : Controller
    {
        private IDbOperative _context;

        public SmartDevicesController()
        {
            _context = new DbOperativeMethods();
        }

        [HttpGet]
        public List<SmartDevice> GetAllSmartDevices()
        {
            List<SmartDevice> SmartDevicesList = _context.GetSmartDevicesCollection().ToList();
            return SmartDevicesList;
        }

        [HttpPost]
        public void AddSmartDevice(string type, string name, string state, string localization, bool disabled)
        {
            SmartDevice sd = new SmartDevice
            {
                Type = (Models.Type)Enum.Parse(typeof(Models.Type), type),
                Name = name,
                State = (Models.State)Enum.Parse(typeof(Models.State), state),
                Localization = (Models.Localization)Enum.Parse(typeof(Models.Localization), localization),
                Disabled = disabled
            };

            _context.AddSmartDeviceToCollection(sd);
        }

    }
}