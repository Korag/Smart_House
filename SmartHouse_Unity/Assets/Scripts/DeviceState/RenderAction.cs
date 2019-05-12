﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderAction : MonoBehaviour
{
    public GameObject ButtonWithAction;
    public bool IsActive = false;


    private List<string> actions;
    private GameObject panelWithActions;
    private DeviceState deviceState;
    private ApiConnection api;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(IsActive);
    }


    public void SetUpList(string deviceName)
    {
        IsActive = true;
        gameObject.SetActive(IsActive);
        deviceState = GameObject.Find(deviceName).GetComponent<DeviceState>();
        panelWithActions = GameObject.Find("PanelWithActions");
        api = new ApiConnection();
        actions = api.GetDeviceActions(deviceState.DeviceName);

        for (int i = 0; i < actions.Count; i++)
        {
            GameObject goButton = (GameObject)Instantiate(ButtonWithAction);
            print(panelWithActions);
            goButton.transform.SetParent(panelWithActions.transform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            goButton.GetComponentInChildren<Text>().text = actions[i];
            Button tempButton = goButton.GetComponent<Button>();
            string action = actions[i];
            tempButton.onClick.AddListener(() => DeviceAction(action, deviceName));
        }
    }

    private void DeviceAction(string actionName, string deviceName)
    {

        deviceState.ChangeDeviceStateOnDemand(actionName);
        print(actionName);
    }

}