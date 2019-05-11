using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    public GameObject menu;
    private RenderAction menuScript;
    private bool isMenuActive;
    // Start is called before the first frame update
    private void Start()
    {

        //

    }

    private void OnMouseDown()
    {
        menu.SetActive(true);
        menuScript = GameObject.Find("ActionMenu").GetComponent<RenderAction>();
        isMenuActive = menuScript.IsActive;

        print("click");
        if (!isMenuActive)
        {
            print("double click");
            // DisplayMenu();
            menuScript.SetUpList(name);
        }

        //private void DisplayMenu()
        //{
        //    if (!isMenuActive)
        //    {
        //        isMenuActive = true;
        //        menu.SetActive(isMenuActive);
        //    }

        //}
    }
}
