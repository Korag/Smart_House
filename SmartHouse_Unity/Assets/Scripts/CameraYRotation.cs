using UnityEngine;

public class CameraYRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }
    public float speedV = 2.0f;

    //camera rotation by Y axis
    private void Update()
    {
        var yRotation = transform.eulerAngles.y;
        var XRotation = transform.eulerAngles.x;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            XRotation = transform.eulerAngles.x + speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(XRotation, yRotation, 0.0f);
        }
    }
}
