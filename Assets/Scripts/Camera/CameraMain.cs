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

    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float limitXR = 6;
    [SerializeField] private float limitYU = 6.5f;
    [SerializeField] private float limitXL = -6;
    [SerializeField] private float limitYD = -6.5f;
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

    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))&& transform.position.x > limitXL)
        { transform.Translate(Vector3.left * speed); }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < limitXR)
        { transform.Translate(Vector3.right * speed); }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && transform.position.y < limitYU)
        { transform.Translate(Vector3.up * speed); }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position.y > limitYD)
        { transform.Translate(Vector3.down * speed); }


    }

    void CheckBorders ()
    {

    }
}
