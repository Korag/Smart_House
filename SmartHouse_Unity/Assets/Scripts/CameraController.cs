using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float movementSpeed = 3f;
    public float scrollSpeed = 20f;
    public float horizontalRotationSpeed = 2.0f;
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
            pos += transform.forward * (movementSpeed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            pos -= transform.forward * (movementSpeed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            pos -= transform.right * (movementSpeed * 10 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            pos += transform.right * (movementSpeed * 10 * Time.deltaTime);
        }


        //camera movement using mpuse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pos -= transform.right * (movementSpeed * Input.GetAxis("Mouse X"));
            pos -= transform.forward * (movementSpeed * Input.GetAxis("Mouse Y"));
        }

        //camera rotation by X axis
        if (Input.GetKey(KeyCode.Mouse1))
        {
            yRotation = transform.eulerAngles.y + horizontalRotationSpeed * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }

        transform.position = pos;
    }
}
