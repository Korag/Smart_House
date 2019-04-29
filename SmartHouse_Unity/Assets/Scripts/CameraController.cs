using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 5f;
    public float borderDistance = 10;
    public float scrollSpeed = 20f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private void Update()
    {

        Vector3 pos = transform.position;
        //camera movement
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderDistance)
        {
            pos += transform.forward * (speed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderDistance)
        {
            pos -= transform.forward * (speed * Time.deltaTime);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderDistance)
        {
            pos -= transform.right * (speed * Time.deltaTime);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderDistance)
        {
            pos += transform.right * (speed * Time.deltaTime);
        }

        //camera rotation
        if (Input.GetKey(KeyCode.Mouse1))
        {
            var yaw = transform.eulerAngles.y + speedH * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        }

        transform.position = pos;
    }
}
