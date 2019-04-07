using SmartHouse_API.Models;
using System.Collections.Generic;

namespace SmartHouse_API.DAL
{
    public interface IDbOperative
    {
        IEnumerable<SmartDevice> GetSmartDevicesCollection();
        void AddSmartDeviceToCollection(SmartDevice device);
        void ChangeSmartDeviceState(SmartDevice device, string state);

    }
}
