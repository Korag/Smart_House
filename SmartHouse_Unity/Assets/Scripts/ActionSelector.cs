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

    // Update is called once per frame
    private void Update()
    {

    }


    private void OnMouseDown()
    {
        DisplayMenu();
        menuScript.SetUpList(name);
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
