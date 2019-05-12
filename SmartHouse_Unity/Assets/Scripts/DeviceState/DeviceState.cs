using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeviceState : MonoBehaviour
{

    public string DeviceId;

    [HideInInspector]
    public string CurrentState = "Enabled";
    [HideInInspector]
    public string DeviceType;



    public List<GameObject> StateIcons;

    private Transform ActiveDeviceState;
    private GameObject newState;


    private ApiConnection api = new ApiConnection();

    private float deviceStatePositionY;
    private void Start()
    {
        DeviceType = api.GetDeviceTypeById(DeviceId);

        ActiveDeviceState = transform.Find("DeviceState");

        SetDeviceState();

        InvokeRepeating("UpdateDeviceState", 0f, 5f);  //1s delay, repeat every 1s
    }


    public void ChangeDeviceStateOnDemand(string state)
    {
        print("Update from button");
        CurrentState = state;
        api.ChangeDeviceState(DeviceId, state);
        ChangeDeviceState();
    }

    private void UpdateDeviceState()
    {
        print("Update from database");
        CurrentState = api.GetDeviceState(DeviceType);
        print(name + " " + CurrentState);
        ChangeDeviceState();

    }

    private void ChangeDeviceState()
    {

        DestroyAllChildObjects();

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
        newObject.transform.parent = ActiveDeviceState;

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
            newObject.transform.parent = ActiveDeviceState;
        }
    }

    private void DestroyAllChildObjects()
    {
        foreach (Transform child in ActiveDeviceState.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

}
