using UnityEngine;
using System.Collections;

public class Ray : MonoBehaviour
{
    public bool zooming;
    public float zoomSpeed;
    public Camera camera;
    internal Vector3 direction;
    internal Vector3 origin;

    void Update()
    {
        if (zooming)
        {
            UnityEngine.Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            camera.transform.Translate(ray.direction * zoomDistance, Space.World);
        }
    }
}