using System.Collections.Generic;
using UnityEngine;

public class DeviceState : MonoBehaviour
{
    public string CurrentState = "Active";
    public List<GameObject> StateIcons;

    private GameObject ActiveDeviceState;
    private GameObject test;

    private float deviceStatePositionY;

    private void Start()
    {
        //deviceStatePositionY = transform.position.y + transform.lossyScale.y + 50f;
        //ActiveDeviceState = Instantiate(StateIcons[0],
        //    new Vector3(transform.position.x, deviceStatePositionY, transform.position.z),
        //    Quaternion.identity);
        InvokeRepeating("UpdateDeviceState", 1f, 1f);  //1s delay, repeat every 1s
    }

    private void UpdateDeviceState()
    {
        Debug.Log("Update");
    }

    // Update is called once per frame
    private void Update()
    {

    }



}
