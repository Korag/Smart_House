using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    public GameObject menu;
    private RenderAction menuScript;
    private bool isMenuActive;
    // Start is called before the first frame update
    private void Start()
    {


    }

    private void OnMouseDown()
    {
        menu.SetActive(true);
        menuScript = GameObject.Find("ActionMenu").GetComponent<RenderAction>();
        isMenuActive = menuScript.IsActive;

        if (!isMenuActive)
        {
            menuScript.SetUpList(name);
        }
    }
}
