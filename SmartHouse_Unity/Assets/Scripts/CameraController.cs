using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 5f;
    public float borderDistance = 10;
    public Vector2 panLimit;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Update is called once per frame
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
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderDistance)
        {
            pos.x += speed * Time.deltaTime;
        }

        //camera rotation
        if (Input.GetKey(KeyCode.Mouse1))
        {
            var yaw = transform.eulerAngles.y + speedH * Input.GetAxis("Mouse X");
            //pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        }



        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);


        transform.position = pos;
    }
}
