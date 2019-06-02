using UnityEngine;

public class HideObject : MonoBehaviour
{
    public new Transform camera;
    public float HideDistance = 50f;
    private Color color;
    // Start is called before the first frame update
    private void Start()
    {
        color = this.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        
        float dist = Vector3.Distance(camera.position, transform.position);
        if (dist <= HideDistance)
        {
            color.a = 0.1f;
            GetComponent<MeshRenderer>().materials[0].color = color;
            GetComponent<MeshRenderer>().materials[1].color = color;
            print(color);
        }
        else
        {
            color.a = 1f;
            GetComponent<MeshRenderer>().materials[0].color = color;
            GetComponent<MeshRenderer>().materials[1].color = color;
            print(color);

        }

    }
}
