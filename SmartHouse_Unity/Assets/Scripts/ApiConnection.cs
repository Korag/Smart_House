using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ApiConnection : MonoBehaviour
{
    public UnityEngine.UI.Dropdown devices;
    // Start is called before the first frame update
    private void Start()
    {
        devices = GetComponent<UnityEngine.UI.Dropdown>();
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
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult =
                        System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    var devicesFromDatabase = JsonHelper.getJsonArray<DeviceModel>(jsonResult);
                    Debug.Log(jsonResult);
                    devices.options.AddRange(
                        devicesFromDatabase.OrderBy(p => p.Name).Select(x =>
                                      new UnityEngine.UI.Dropdown.OptionData()
                                      {
                                          text = x.Name
                                      }).ToList());
                    devices.value = 0;
                }
                //ddlCountries.options.AddRange(entities.
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {

    }
}
