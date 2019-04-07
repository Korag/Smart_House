using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiConnection : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
    }

    private IEnumerator GetDevices()
    {
        string getmartDevicesApiUrl = "Api_url_here";
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
                    Debug.Log(jsonResult);

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
