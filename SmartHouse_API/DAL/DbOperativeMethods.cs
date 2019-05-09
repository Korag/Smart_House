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
        private string _localizationsCollName = "Localizations";
        private string _typesActionsCollName = "ListOfTypesWithWithAvailableActions ";


        public DbOperativeMethods(DbContext context)
        {
            _context = context;
        }

        private IMongoCollection<SmartDevice> GetSmartDevicesMongoCollection()
        {
            IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            return _smartDevices;
        }

        public ICollection<string> GetLocalizations()
        {
            return _context.db.GetCollection<Localization>(_localizationsCollName).AsQueryable().Select(z=> z.Name).ToList();
        }

        public void AddNewLocalization(string name)
        {
            Localization localization = new Localization
            {
                Name = name
            };

            _context.db.GetCollection<Localization>(_localizationsCollName).InsertOne(localization);
        }

        ICollection<TypeActions> GetTypesOfSmartDevicesWithAvailableActions()
        {
            return _context.db.GetCollection<TypeActions>(_typesActionsCollName).AsQueryable().ToList();
        }

        ICollection<string> GetAvailableActionsOfSingleTypeSmartDevice(string type)
        {
            return _context.db.GetCollection<TypeActions>(_typesActionsCollName).AsQueryable().Where(z=> z.Type == type).Select(z => z.AvailableActions).FirstOrDefault();
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

        public void AddNewAvailableActionsToSmartDevice(string id, ICollection<string> newAvailableActions)
        {
            SmartDevice smartDevice = GetSingleSmartDeviceFromCollection(ObjectId.Parse(id));

            foreach (var availableAction in newAvailableActions)
            {
                smartDevice.AvailableActions.Add(availableAction);
            }

            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, smartDevice.Id);
            var update = Builders<SmartDevice>.Update.Set(x=> x.AvailableActions, smartDevice.AvailableActions);
            _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).UpdateOne(filter, update);
        }

        public void DeleteAvailableActionsFromSmartDevice(string id, ICollection<string> actionsToDelete)
        {
            SmartDevice smartDevice = GetSingleSmartDeviceFromCollection(ObjectId.Parse(id));

            foreach (var availableAction in actionsToDelete)
            {
                smartDevice.AvailableActions.Remove(availableAction);
            }

            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, smartDevice.Id);
            var update = Builders<SmartDevice>.Update.Set(x => x.AvailableActions, smartDevice.AvailableActions);
            _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).UpdateOne(filter, update);
        }

        #endregion

        #region CollectionOfDevices

        public IEnumerable<SmartDevice> GetSmartDevicesCollection(string propertyName = "Name")
        {
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(x => true).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyName);
            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWhichAreDisabled(string propertyName = "Name")
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Disabled, true);
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyName);
            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        public IEnumerable<SmartDevice> OrderSmartDevices(IEnumerable<SmartDevice> collection, string propertyName = "Name")
        {
            //IMongoCollection<SmartDevice> _smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName);
            System.Reflection.PropertyInfo prop = typeof(SmartDevice).GetProperty(propertyName);

            return collection.AsQueryable().ToList().OrderBy(x => prop.GetValue(x));
        }

        public IEnumerable<SmartDevice> GetCollectionOfSmartDevicesWithSameProperty(string propertyName, string propertyValue, string propertyOrder = "Name")
        {
            var filter = Builders<SmartDevice>.Filter.Eq(propertyName, propertyValue);
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyOrder);

            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        #endregion


        #region DepreciatedGetters

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameName(string name, string propertyName)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Name, name);
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyName);
            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameType(string type, string propertyName)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Type, type);
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyName);
            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }

        public IEnumerable<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization, string propertyName)
        {
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Localization, localization);
            IEnumerable<SmartDevice> smartDevices = _context.db.GetCollection<SmartDevice>(_smartDeviceCollName).Find<SmartDevice>(filter).ToList();
            smartDevices = OrderSmartDevices(smartDevices, propertyName);
            return smartDevices.AsQueryable<SmartDevice>().ToList();
        }
        #endregion

        #region DepreciatedSetters
        public void SetStateOfSingleSmartDevice(SmartDevice sd, string state)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.State = state;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetLocalizationOfSingleSmartDevice(SmartDevice sd, string localization)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Localization = localization;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetTypeOfSingleSmartDevice(SmartDevice sd, string type)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Type = type;
            _smartDevices.ReplaceOne(filter, sd);
        }

        public void SetNameOfSingleSmartDevice(SmartDevice sd, string name)
        {
            IMongoCollection<SmartDevice> _smartDevices = GetSmartDevicesMongoCollection();
            var filter = Builders<SmartDevice>.Filter.Eq(x => x.Id, sd.Id);
            sd.Name = name;
            _smartDevices.ReplaceOne(filter, sd);
        }
        #endregion

    }
}