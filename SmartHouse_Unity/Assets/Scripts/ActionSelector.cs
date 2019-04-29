using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform != null)
                {
                    DisplayListOfActions(hit.transform.gameObject);

                }

            }
        }
    }

    private void DisplayListOfActions(GameObject device)
    {
        print(device.name);
    }
}
