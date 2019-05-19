using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

public class ApiConnection
{
    private string _smartDeviceApiUrl;
    private WarningApiText apiWarning;

    public ApiConnection()
    {
        _smartDeviceApiUrl = "http://localhost:61635/api";
    }

    public List<string> GetDeviceActions(string deviceName)
    {
        apiWarning = GameObject.FindObjectOfType<WarningApiText>();
        List<string> deviceActions = new List<string>();

        try
        {
            apiWarning.HideWarning();

            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create($"{_smartDeviceApiUrl}/GetAvailableActionsOfSingleTypeSmartDevice/?type={deviceName}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
            deviceActions = JsonHelper.FromJson<string>(jsonResponse).ToList();
        }
        catch (System.Exception)
        {
            apiWarning.ShowWarning();
        }

        return deviceActions;
    }

    public string GetDeviceTypeById(string id)
    {
        apiWarning = GameObject.FindObjectOfType<WarningApiText>();
        string deviceType = string.Empty;

        try
        {
            apiWarning.HideWarning();

            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create($"{_smartDeviceApiUrl}/GetSingleSmartDevice/?id={id}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            deviceType = JsonUtility.FromJson<DeviceModel>(reader.ReadToEnd()).Type;
        }
        catch (System.Exception)
        {
            apiWarning.ShowWarning();
        }

        return deviceType;
    }

    public string GetDeviceState(string id)
    {
        apiWarning = GameObject.FindObjectOfType<WarningApiText>();
        string deviceState = string.Empty;
        try
        {
            apiWarning.HideWarning();

            HttpWebRequest request =
              (HttpWebRequest)WebRequest.Create($"{_smartDeviceApiUrl}/GetStateOfSingleSmartDevice/?id={id}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            deviceState = reader.ReadToEnd();
        }
        catch (System.Exception)
        {
            apiWarning.ShowWarning();
        }

        return deviceState.Replace("\"", "");
    }
    public void ChangeDeviceState(string id, string deviceState)
    {
        WebClient wc = new WebClient();

        wc.QueryString.Add("id", id);
        wc.QueryString.Add("propertyName", "State");
        wc.QueryString.Add("propertyValue", deviceState);

        var data = wc.UploadValues($"{_smartDeviceApiUrl}/SetSpecificPropertyOfSingleSmartDevice", "POST", wc.QueryString);
    }

}
