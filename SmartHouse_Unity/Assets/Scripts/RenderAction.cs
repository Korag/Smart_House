using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderAction : MonoBehaviour
{
    public GameObject prefabButton;

    private List<string> actions;
    private GameObject panelWithActions;
    private ApiConnection api;
    // Start is called before the first frame update
    private void Start()
    {
        panelWithActions = GameObject.Find("PanelWithActions");
        api = new ApiConnection();
        actions = new List<string>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetUpList(string deviceName)
    {
        actions = api.GetDeviceActions(deviceName);

        for (int i = 0; i < actions.Count; i++)
        {

            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(panelWithActions.transform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            goButton.GetComponentInChildren<Text>().text = actions[i];
            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;
            //tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }

}
