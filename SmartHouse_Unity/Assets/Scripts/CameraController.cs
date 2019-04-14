using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 20f;
    public float borderPosMouse = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderPosMouse)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderPosMouse)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderPosMouse)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderPosMouse)
        {
            pos.x -= speed * Time.deltaTime;
        }

       float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100* Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
