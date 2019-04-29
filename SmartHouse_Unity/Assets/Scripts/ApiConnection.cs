
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class ApiConnection : MonoBehaviour
{
    private List<string> testList = new List<string> { "Test1", "Test2", "Test3" };
    public UnityEngine.UI.Dropdown devices;
    // Start is called before the first frame update
    private void Start()
    {
        devices.ClearOptions();
        StartCoroutine(GetDevices());
    }

    private IEnumerator GetDevices()
    {
        string getmartDevicesApiUrl = "http://localhost:61635/api/GetAllSmartDevices";
        using (UnityWebRequest www = UnityWebRequest.Get(getmartDevicesApiUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("error");
                devices.AddOptions(testList);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult =
                        System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    var devicesFromDatabase = JsonHelper.FromJson<DeviceModel>(jsonResult);
                    Debug.Log(jsonResult);

                    devices.AddOptions(
                        devicesFromDatabase.Select(x => x.Name).ToList()
                    );

                    devices.value = 0;
                }
            }
        }
    }

    public List<string> GetDeviceActions()
    {
        List<string> actions = new List<string>();

        string getmartDevicesApiUrl = "http://localhost:61635/api/GetAllSmartDevices";

        HttpWebRequest request =
          (HttpWebRequest)WebRequest.Create(getmartDevicesApiUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = "{\"Items\":" + reader.ReadToEnd() + "}";
        print(jsonResponse);
        var test = JsonHelper.FromJson<DeviceModel>(jsonResponse);
        print(test[0].Name);

        //using (UnityWebRequest www = UnityWebRequest.Get(getmartDevicesApiUrl))
        //{
        //    //www.chunkedTransfer = false;
        //    yield return www.SendWebRequest();
        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        Debug.Log(www.error);
        //        Debug.Log("error");
        //        devices.AddOptions(testList);
        //    }
        //    else
        //    {
        //        if (www.isDone)
        //        {
        //            string jsonResult =
        //                System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
        //            actions = JsonHelper.FromJson<DeviceModel>(jsonResult).Select(x => x.Name).ToList();
        //            Debug.Log(jsonResult);

        //        }
        //    }
        //}
        return actions;
    }

    private void Update()
    {

    }
}
