using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeviceState : MonoBehaviour
{
    public string CurrentState = "On";
    public List<GameObject> StateIcons;

    private GameObject ActiveDeviceState;
    private GameObject newState;


    private ApiConnection api = new ApiConnection();

    private float deviceStatePositionY;
    private void Start()
    {
        ActiveDeviceState = GameObject.Find("DeviceState");

        SetDeviceState();

        InvokeRepeating("UpdateDeviceState", 0f, 5f);  //1s delay, repeat every 1s
        //InvokeRepeating("SetDeviceState", 1f, 1f);  //1s delay, repeat every 1s
    }

    private void UpdateDeviceState()
    {
        CurrentState = api.GetDeviceState(transform.name);
        ChangeDeviceState();
        Debug.Log("Update");
        Debug.Log(CurrentState);
    }

    private void ChangeDeviceState()
    {
        DestroyAllChildObjects();
        if (ActiveDeviceState.transform.childCount == 0)
        {
            var stateFromList = StateIcons.Where(x => x.name == CurrentState).FirstOrDefault();
            GameObject stateToRender;
            if (stateFromList != null)
            {
                stateToRender = stateFromList;
            }
            else
            {
                stateToRender = StateIcons[1];
            }
            var newObject = Instantiate(stateToRender);
            newObject.transform.parent = ActiveDeviceState.transform;
        }

    }

    private void SetDeviceState()
    {
        if (ActiveDeviceState.transform.childCount == 0)
        {
            var stateFromList = StateIcons.Where(x => x.name == CurrentState).FirstOrDefault();
            foreach (var item in StateIcons)
            {
                print(item.name);
            }
            GameObject stateToRender;
            if (stateFromList != null)
            {
                stateToRender = stateFromList;
            }
            else
            {
                stateToRender = StateIcons[1];
            }
            var newObject = Instantiate(stateToRender);
            newObject.transform.parent = ActiveDeviceState.transform;
        }
    }

    private void DestroyAllChildObjects()
    {
        foreach (Transform child in ActiveDeviceState.transform)
        {
            Destroy(child.gameObject);
        }
        print("Destroy");
    }

    // Update is called once per frame
    private void Update()
    {

    }

}
