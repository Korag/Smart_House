using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5f;
    public float borderDistance = 10;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderDistance)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderDistance)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderDistance)
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderDistance)
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
