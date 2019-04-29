using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderAction : MonoBehaviour
{
    public GameObject prefabButton;
    public List<string> actions;
    private GameObject panelWithActions;
    // Start is called before the first frame update
    private void Start()
    {
        panelWithActions = GameObject.Find("PanelWithActions");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetUpList()
    {
        print(actions.Count);
        print(panelWithActions.name);
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
