using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    private float X, Y;
    public float MouseSense = 3; // чувствительность мышки

    // Start is called before the first frame update
    void Start()
    {
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
            Transform();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)// приблизить
        { 
            offset.z += zoom;
            MouseZoom();
            Transform();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)// отдалить
        { 
            offset.z -= zoom;
            MouseZoom();
            Transform();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Transform()
    {
        transform.position = transform.localRotation * offset + target.position;
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
    void MouseZoom()
    {
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));// значение между мин и макс
    }
}