using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    private GameObject menu;
    private RenderAction menuScript;
    private bool isMenuActive;
    // Start is called before the first frame update
    private void Start()
    {

        menuScript = GameObject.Find("ActionMenu").GetComponent<RenderAction>();
        menu = GameObject.Find("ActionMenu");

        isMenuActive = false;
        menu.SetActive(isMenuActive);
    }

    private void OnMouseDown()
    {
        print("click");
        if (!isMenuActive)
        {
            print("double click");
            DisplayMenu();
            menuScript.SetUpList(name);
            isMenuActive = true;
        }

    }

    private void DisplayMenu()
    {
        if (!isMenuActive)
        {
            isMenuActive = true;
            menu.SetActive(isMenuActive);
        }

    }
}
