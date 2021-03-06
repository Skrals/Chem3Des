using UnityEngine;

public class Manipulator : MonoBehaviour
{
    [SerializeField] private Transform manipulatorTarget;
    [SerializeField] private Vector3 cursor;
    [SerializeField] private Vector3 startVector;

    [SerializeField] private float offsetPosition = 0.01f;

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        cursor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startVector = cursor;
        }
        if (Input.GetKey(KeyCode.Tab) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetTarget();
        }

        if (Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.Mouse0))
        {
            CalculateCurrentPosition();
        }
        else
        {
            DropTarget();
        }
    }

    void GetTarget()
    {
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            manipulatorTarget = hit.collider.gameObject.GetComponent<Transform>();
        }
    }

    void DropTarget()
    {
        manipulatorTarget = null;
    }

    void CalculateCurrentPosition()
    {
        var objectX = manipulatorTarget.position.x;
        var objectY = manipulatorTarget.position.y;
        var objectZ = manipulatorTarget.position.z;
        var bounds = manipulatorTarget.GetComponent<MeshFilter>().sharedMesh.bounds.size;

        if (startVector.x > cursor.x)
        {
            manipulatorTarget.X(objectX + (cursor.x - startVector.x) - offsetPosition);
        }
        if (startVector.x < cursor.x)
        {
            manipulatorTarget.X(objectX - (startVector.x - cursor.x) + offsetPosition);
        }
        if (startVector.y > cursor.y)
        {
            manipulatorTarget.Y(objectY + (cursor.y - startVector.y)- offsetPosition);
        }
        if (startVector.y < cursor.y)
        {
            manipulatorTarget.Y(objectY - (startVector.y - cursor.y) + offsetPosition);
        }
        if (startVector.z > cursor.z)
        {
            manipulatorTarget.Z(objectZ + (cursor.z - startVector.z) - offsetPosition);
        }
        if (startVector.z < cursor.z)
        {
            manipulatorTarget.Z(objectZ - (startVector.z - cursor.z) + offsetPosition);
        }
        startVector = cursor;
    }


}
