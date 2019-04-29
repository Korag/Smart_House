using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 3f;
    public float rotationSpeed = 5f;
    public float borderDistance = 10;
    public float scrollSpeed = 20f;
    public float speedH = 2.0f;
    private float yRotation;
    private float xRotation;
    private void start()
    {
        yRotation = transform.eulerAngles.y;
        xRotation = transform.eulerAngles.x;

    }
    private void Update()
    {
        Vector3 pos = transform.position;
        //camera movement using keyes
        if (Input.GetKey("w"))
        {
            pos += transform.forward * (speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            pos -= transform.forward * (speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            pos -= transform.right * (speed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            pos += transform.right * (speed * 10 * Time.deltaTime);
        }


        //camera movement using mpuse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pos -= transform.right * (speed * Input.GetAxis("Mouse X"));
            pos -= transform.forward * (speed * Input.GetAxis("Mouse Y"));
        }

        //camera rotation by X axis
        if (Input.GetKey(KeyCode.Mouse1))
        {
            yRotation = transform.eulerAngles.y + speedH * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }

        transform.position = pos;
    }
}
