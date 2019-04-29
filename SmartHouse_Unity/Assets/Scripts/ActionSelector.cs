using System.Collections.Generic;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    private GameObject menu;
    private RenderAction menuScript;
    private List<string> actions;
    private bool isMenuActive;
    // Start is called before the first frame update
    private void Start()
    {
        menuScript = GameObject.Find("ExtraMenu").GetComponent<RenderAction>();
        menu = GameObject.Find("ExtraMenu");
        isMenuActive = false;
        menu.SetActive(isMenuActive);
    }

    // Update is called once per frame
    private void Update()
    {

    }


    private void OnMouseDown()
    {
        DisplayListOfActions();
        print("click");

        if (isMenuActive)
        {
            SeedListWithActions();
            menuScript.SetUpList();



            print(transform.gameObject.name);
        }

    }


    private void SeedListWithActions()
    {
        ApiConnection api = new ApiConnection();
        menuScript.actions = api.GetDeviceActions();


    }

    private void DisplayListOfActions()
    {
        if (!isMenuActive)
        {
            isMenuActive = true;
            menu.SetActive(isMenuActive);
        }

    }
}
