using Certification_System.DAL;
using MongoDB.Driver;
using SmartHouse_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_API.DAL
{
    public class DbOperativeMethods : IDbOperative
    {
        private DbContext _context;
        private string _smartDeviceCollName = "SmartDevices";

        private IMongoCollection<SmartDevice> _smartDevices { get; set; }

        public DbOperativeMethods()
        {
            _context = new DbContext();
        }

        public void AddSmartDeviceToCollection(SmartDevice device)
        {
            List<SmartDevice> devices = GetSmartDevicesCollection().ToList();
            devices.Add(device);
        }

        public IEnumerable<SmartDevice> GetSmartDevicesCollection()
        {
            GetSmartDevicesMongoCollection();
            return _smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        private IMongoCollection<SmartDevice> GetSmartDevicesMongoCollection()
        {
            return _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
        }

        public void ChangeSmartDeviceState(SmartDevice device, State state)
        {
            GetSmartDevicesMongoCollection();

            var filter = Builders<SmartDevice>.Filter.Eq(x=> x.Id, device.Id);
            device.State = state;
            _smartDevices.ReplaceOne(filter, device);
        }
    }
}