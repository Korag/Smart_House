using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minZoomDistance = 20f;
    public float maxZoomDistance = 120f;
    //public Vector2 cameraPositionLimit;
    public Transform ground;
    public float scrollSpeed = 20f;

    // Update is called once per frame
    private void Update()
    {
        var groundY = ground.transform.position.y;
        Vector3 pos = transform.position;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y += groundY - scroll * scrollSpeed * 100f * Time.deltaTime;

        if (pos.y > minZoomDistance)
        {

            pos += ground.forward * scroll * scrollSpeed * 100f * Time.deltaTime;

        }

        //pos.y = Mathf.Clamp(pos.y, minZoomDistance, maxZoomDistance);
        //pos.z = Mathf.Clamp(pos.z, -cameraPositionLimit.y, -cameraPositionLimit.y);
        pos.y = Mathf.Clamp(pos.y, minZoomDistance, maxZoomDistance);





        transform.position = pos;

    }
}
