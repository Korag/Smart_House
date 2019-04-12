using MongoDB.Bson;
using SmartHouse_API.Models;
using System.Collections.Generic;

namespace SmartHouse_API.DAL
{
    public interface IDbOperative
    {
        IEnumerable<SmartDevice> GetSmartDevicesCollection(string propertyName);
        void AddSmartDeviceToCollection(SmartDevice device);
        void ChangeSmartDeviceState(SmartDevice device, string state);
        SmartDevice GetSingleSmartDeviceFromCollection(ObjectId id);
        void SmartDeviceSwitchOne(SmartDevice sd);
        void DeleteSmartDeviceFromCollection(ObjectId id);
        IEnumerable<SmartDevice> GetAllSmartDevicesWhichAreDisabled();
        #region DepreciatedGetters
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameType(string type);
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization);
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameName(string name);
        #endregion
        #region DepreciatedSetters
        void SetStateOfSingleSmartDevice(SmartDevice sd, string state);
        void SetLocalizationOfSingleSmartDevice(SmartDevice sd, string localization);
        void SetTypeOfSingleSmartDevice(SmartDevice sd, string type);
        void SetNameOfSingleSmartDevice(SmartDevice sd, string name);

        #endregion
        void SetPropertyOfSingleSmartDevice(SmartDevice sd, string propertyName, string propertyValue);
    }
}
