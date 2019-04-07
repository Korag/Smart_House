using SmartHouse_API.DAL;
using SmartHouse_API.Models;
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


    }
}