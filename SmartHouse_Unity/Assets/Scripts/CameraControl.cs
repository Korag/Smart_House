using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5f;
    public float boarderDistance = 10;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - boarderDistance)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= boarderDistance)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= boarderDistance)
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - boarderDistance)
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
