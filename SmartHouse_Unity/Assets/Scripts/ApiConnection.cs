using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

public class ApiConnection
{
    private string _getmartDevicesApiUrl;

    public ApiConnection()
    {
        _getmartDevicesApiUrl = "http://localhost:61635/api";
    }

    public string GetAllDevicesJson()
    {

        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create($"{_getmartDevicesApiUrl}/GetAllSmartDevices");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
        //var resultFromDataBase = JsonHelper.FromJson<DeviceModel>(jsonResponse);
        //var devices = resultFromDataBase.ToList();

        return jsonResponse;
    }


    public List<string> GetDeviceActions(string deviceName)
    {
        //GetAvailableActionsOfSingleTypeSmartDevice
        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create($"{_getmartDevicesApiUrl}/GetAvailableActionsOfSingleTypeSmartDevice/?type={deviceName}");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
        var deviceActions = JsonHelper.FromJson<string>(jsonResponse);

        return deviceActions.ToList();
    }

    public string GetDeviceTypeById(string id)
    {

        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create($"{_getmartDevicesApiUrl}/GetSingleSmartDevice/?id={id}");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        var smartDevice = JsonUtility.FromJson<DeviceModel>(reader.ReadToEnd());

        return smartDevice.Type;
    }

    public string GetDeviceState(string deviceName)
    {

        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create($"{_getmartDevicesApiUrl}/GetAllSmartDevices");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
        var resultFromDataBase = JsonHelper.FromJson<DeviceModel>(jsonResponse);
        var device = resultFromDataBase.Where(x => x.Type == deviceName).First();

        return device.State;
    }
    public void ChangeDeviceState(string id, string deviceState)
    {
        WebClient wc = new WebClient();

        wc.QueryString.Add("id", id);
        wc.QueryString.Add("propertyName", "State");
        wc.QueryString.Add("propertyValue", deviceState);

        var data = wc.UploadValues($"{_getmartDevicesApiUrl}/SetSpecificPropertyOfSingleSmartDevice", "POST", wc.QueryString);

    }

}
