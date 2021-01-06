using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBuilder : MonoBehaviour
{
    public TransformCam cam = null;
    public Transform target;
    public Vector3 offset;

    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    public float MouseSense = 3; // чувствительность мышки
    private float X, Y;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.AddComponent<TransformCam>();
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            MouseInputR();
            cam.Transform(target,offset);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && offset.z < -zoomMin)// приблизить
        {
            offset.z += zoom;
            cam.MouseZoom(offset, zoomMax, zoomMin);
            cam.Transform(target, offset);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && offset.z > -zoomMax)// отдалить
        { 
            offset.z -= zoom;
            cam.MouseZoom(offset, zoomMax, zoomMin);
            cam.Transform(target, offset);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void MouseInputR()
    {
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MouseSense;
        Y += Input.GetAxis("Mouse Y") * MouseSense;
        Y = Mathf.Clamp(Y, -limit, limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

}