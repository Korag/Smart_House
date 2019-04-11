using MongoDB.Bson;
using SmartHouse_API.Models;
using System.Collections.Generic;

namespace SmartHouse_API.DAL
{
    public interface IDbOperative
    {
        IEnumerable<SmartDevice> GetSmartDevicesCollection();
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameName(string name);
        void AddSmartDeviceToCollection(SmartDevice device);
        void ChangeSmartDeviceState(SmartDevice device, string state);
        SmartDevice GetSingleSmartDeviceFromCollection(ObjectId id);
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameType(string type);
        IEnumerable<SmartDevice> GetAllSmartDevicesWithSameLocalization(string localization);
        IEnumerable<SmartDevice> GetAllSmartDevicesWhichAreDisabled();
        void SmartDeviceSwitchOne(SmartDevice sd);
        void DeleteSmartDeviceFromCollection(ObjectId id);
        void SetStateOfSingleSmartDevice(SmartDevice sd, string state);
        void SetLocalizationOfSingleSmartDevice(SmartDevice sd, string localization);
    }
}
