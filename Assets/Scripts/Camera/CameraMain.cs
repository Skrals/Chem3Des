using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public TransformCam cam = null;
    public Transform target;

    public Vector3 offset;
    public float zoom = 0.25f;
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение

    private float limitX;
    private float limitY;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.AddComponent<TransformCam>();
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && offset.z < -zoomMin)// приблизить
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
    }
}
