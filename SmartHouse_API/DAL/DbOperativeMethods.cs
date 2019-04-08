using Certification_System.DAL;
using MongoDB.Bson;
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
            _smartDevices = GetSmartDevicesMongoCollection();
            _smartDevices.InsertOne(device);
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

        public void ChangeSmartDeviceState(SmartDevice device, string state)
        {
            GetSmartDevicesMongoCollection();

            var filter = Builders<SmartDevice>.Filter.Eq(x=> x.Id, device.Id);
            device.State = state;
            _smartDevices.ReplaceOne(filter, device);
        }

        public SmartDevice GetSingleSmartDeviceFromCollection(ObjectId id)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, id);
            SmartDevice sd = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).FirstOrDefault();
            return sd;
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameName(string name)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Name, name);
            List<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            return smartDevices;
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameType(string type)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Type, type);
            List<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            return smartDevices;
        }
    }
}