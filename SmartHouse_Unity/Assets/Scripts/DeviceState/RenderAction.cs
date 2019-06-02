using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderAction : MonoBehaviour
{
    [HideInInspector]
    public GameObject ButtonWithAction;

    [HideInInspector]
    public bool IsActive = false;

    public Button CloseButton;
    private List<string> actions;
    private GameObject panelWithActions;
    private DeviceState deviceState;
    private ApiConnection api;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(IsActive);
        CloseButton.onClick.AddListener(CloseMenu);
    }


    public void SetUpList(string deviceName)
    {
        IsActive = true;
        gameObject.SetActive(IsActive);
        deviceState = GameObject.Find(deviceName).GetComponent<DeviceState>();
        panelWithActions = GameObject.Find("PanelWithActions");
        api = new ApiConnection();
        actions = api.GetDeviceActions(deviceState.DeviceType);

        for (int i = 0; i < actions.Count; i++)
        {
            GameObject goButton = (GameObject)Instantiate(ButtonWithAction);
            goButton.transform.SetParent(panelWithActions.transform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            goButton.GetComponentInChildren<Text>().text = actions[i];
            Button tempButton = goButton.GetComponent<Button>();
            string action = actions[i];
            tempButton.onClick.AddListener(() => DeviceAction(action, deviceName));
        }
    }


    public void CloseMenu()
    {
        IsActive = false;
        gameObject.SetActive(IsActive);
        foreach (Transform child in panelWithActions.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void DeviceAction(string actionName, string deviceName)
    {

        deviceState.ChangeDeviceStateOnDemand(actionName);
    }

}
