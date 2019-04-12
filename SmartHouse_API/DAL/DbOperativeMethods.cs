using MongoDB.Bson;
using MongoDB.Driver;
using SmartHouse_API.Models;
using System.Collections.Generic;
using System.Linq;

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

        private IMongoCollection<SmartDevice> GetSmartDevicesMongoCollection()
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            return _smartDevices;
        }

        #region SingleDevice

        public void AddSmartDeviceToCollection(SmartDevice device)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            _smartDevices.InsertOne(device);
        }

        public void ChangeSmartDeviceState(SmartDevice device, string state)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();

            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, device.Id);
            device.State = state;
            _smartDevices.ReplaceOne(filter, device);
        }

        public SmartDevice GetSingleSmartDeviceFromCollection(ObjectId id)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, id);
            SmartDevice sd = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).FirstOrDefault();
            return sd;
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

        public void SetPropertyOfSingleSmartDevice(SmartDevice sd, string propertyName, string propertyValue)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);

            System.Reflection.PropertyInfo prop = typeof(SmartDevice).GetProperty(propertyName);
            prop.SetValue(sd, propertyValue);

            _smartDevices.ReplaceOne(filter, sd);
        }

        #endregion

        #region CollectionOfDevices

        public IEnumerable<SmartDevice> GetSmartDevicesCollection()
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            return _smartDevices.AsQueryable<SmartDevice>().ToList();
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

        public IEnumerable<SmartDevice> OrderSmartDevices(string propertyName)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            System.Reflection.PropertyInfo prop = typeof(SmartDevice).GetProperty(propertyName);

            return _smartDevices.AsQueryable().ToList().OrderBy(x => prop.GetValue(x));
        }

        #endregion


        #region DepreciatedSetters
        public void SetStateOfSingleSmartDevice(SmartDevice sd, string state)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.State = state;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetLocalizationOfSingleSmartDevice(SmartDevice sd, string localization)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Localization = localization;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetTypeOfSingleSmartDevice(SmartDevice sd, string type)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Type = type;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetNameOfSingleSmartDevice(SmartDevice sd, string name)
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Name = name;
            _smartDevices.ReplaceOne(filter, sd);
        }
        #endregion

    }
}