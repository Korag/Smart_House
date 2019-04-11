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

        public DbOperativeMethods(DbContext context)
        {
            _context = context;
        }

        public void AddSmartDeviceToCollection(SmartDevice device)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            _smartDevices.InsertOne(device);
        }

        public IEnumerable<SmartDevice> GetSmartDevicesCollection()
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            return _smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        private IMongoCollection<SmartDevice> GetSmartDevicesMongoCollection()
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            return _smartDevices;
        }

        public void ChangeSmartDeviceState(SmartDevice device, string state)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();

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

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Localization, localization);
            List<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            return smartDevices;
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWhichAreDisabled()
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Disabled, true);
            List<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            return smartDevices;
        }

        public void SmartDeviceSwitchOne(SmartDevice sd)
        {
            sd.Disabled = false;
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();

            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void DeleteSmartDeviceFromCollection(ObjectId id)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            _smartDevices.DeleteOne<SmartDevice>(x => x.Id == id);
        }

        public void SetStateOfSingleSmartDevice(SmartDevice sd, string state)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.State = state;
            _smartDevices.ReplaceOne(filter, sd);
        }
    }
}