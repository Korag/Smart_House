using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

public class ApiConnection
{
    public List<string> GetDeviceActions(string deviceName)
    {
        string getmartDevicesApiUrl = "http://localhost:61635/api/GetAllSmartDevices";

        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create(getmartDevicesApiUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
        var resultFromDataBase = JsonHelper.FromJson<DeviceModel>(jsonResponse);
        var device = resultFromDataBase.Where(x => x.Type == deviceName).First();

        return device.AvailableActions;
    }
}
