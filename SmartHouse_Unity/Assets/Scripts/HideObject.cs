using UnityEngine;

public class HideObject : MonoBehaviour
{
    public new Transform camera;
    public float HideDistance = 50f;
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        float dist = Vector3.Distance(camera.position, transform.position);
        if (dist <= HideDistance)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;

        }

    }
}
