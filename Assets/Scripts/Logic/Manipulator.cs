using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public bool connectionModeIsOn = false;
    public GameObject connectionMenu;
    public GameObject currentConnectionModShow;
    public GameObject currentConnectionTypeShow;

    [SerializeField] private Transform startConnection = null;
    [SerializeField] private Transform finishConnection = null;
    [SerializeField] private Transform manipulatorTarget;

    [SerializeField] private GameObject line;
    [SerializeField] private GameObject currentViewConnection;
    [SerializeField] private GameObject[] connectionArray;

    [SerializeField] private Light targetLight;

    [SerializeField] private Vector3 cursor;
    [SerializeField] private Vector3 startVector;
    [SerializeField] private Vector3 vector1;
    [SerializeField] private Vector3 vector2;

    [SerializeField] private float offsetPosition = 0.01f;
    [SerializeField] private bool available;
    [SerializeField] private bool view;
    [SerializeField] private int connectionSwitch = 0;
    [SerializeField] private int listCounter = 0;

    [SerializeField] Color selectColor;
    [SerializeField] Color deletColor;
    [SerializeField] Color connectionColor;

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
        if (!connectionModeIsOn)
        {


            if (Input.GetKey(KeyCode.Tab) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetTarget();
            }

            if (Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.D))
            {
                CalculateCurrentPosition();
                Deselected();
            }
            else
            {
                DropTarget();
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Tab))
            {
                DeleteTarget();
            }
            if (Input.GetKey(KeyCode.Tab))
            {
                HiglightTarget(selectColor);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                available = true;
                HiglightTarget(deletColor);
            }
            else
            {
                Deselected();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (connectionModeIsOn)
            {
                connectionModeIsOn = false;
            }
            else
            {
                connectionModeIsOn = true;
            }
            currentConnectionModShow.GetComponent<CurrentActions>().IsConnectionMode(connectionModeIsOn);
        }
        if (connectionModeIsOn)
        {
            HiglightTarget(connectionColor);
            if (Input.GetKeyDown(KeyCode.Mouse0) && startConnection == null)
            {
                GetTarget();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && finishConnection == null)
            {
                GetTarget();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                connectionMenu.SetActive(true);
                connectionMenu.transform.position = Input.mousePosition;
            }
            Pointer();
        }

        if (startConnection != null && finishConnection != null)
        {
            MakeConnection();

        }
        if (Input.GetKey(KeyCode.T) && Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (!connectionMenu.active && !connectionModeIsOn)
            {

                if (currentViewConnection != null)
                {
                    connectionMenu.SetActive(true);
                    connectionMenu.transform.position = Input.mousePosition;
                }
                else
                {
                    GetConnection();
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            connectionMenu.SetActive(false);
            ClearConnection();
        }
        currentConnectionTypeShow.GetComponent<CurrentActions>().CurrentConnection(connectionSwitch);
    }

    public void InputMenu(int value)
    {

        switch (value)
        {
            case 0:
                connectionSwitch = 0;
                break;
            case 1:
                connectionSwitch = 1;
                break;
            case 2:
                connectionSwitch = 2;
                break;

        }

        ChangeConnection();
        connectionMenu.SetActive(false);
    }

    void MakeConnection()
    {
        vector1 = startConnection.position;
        vector2 = finishConnection.position;
        connectionArray[connectionSwitch].transform.localScale = new Vector3(0.3f, 0.3f, Vector3.Distance(vector1, vector2)); //меняем размер объекта по z 
        Vector3 middlePoint = new Vector3((vector1.x + vector2.x) / 2, (vector1.y + vector2.y) / 2, (vector1.z + vector2.z) / 2);// узнаем середину между 2мя объектами
        Quaternion ObjQuaternion = connectionArray[connectionSwitch].transform.rotation;
        ObjQuaternion = Quaternion.RotateTowards(Quaternion.LookRotation(vector1), Quaternion.LookRotation((vector1 - vector2)), 360f);// узнаем угол поворота между стартовой и конечной точкой - надо сделать его по модулю
        GameObject bufferGm = Instantiate(connectionArray[connectionSwitch], middlePoint, ObjQuaternion);// инициализируем объект в переменной
        bufferGm.GetComponent<ConnectionUpdate>().ConnectionUp(startConnection, finishConnection); //по ссылке на переменную объекта добавляем значения конкретному объекту
        ClearConnection();
    }
    void ClearConnection()
    {
        startConnection = null;
        finishConnection = null;
        currentViewConnection = null;
    }
    void GetTarget()
    {
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (!connectionModeIsOn && hit.collider.gameObject.tag != "Connection")
            {
                manipulatorTarget = hit.collider.gameObject.GetComponent<Transform>();
            }
            else
            {
                if (hit.collider.gameObject.tag != "Connection")
                {
                    if (startConnection == null)
                    {
                        startConnection = hit.collider.gameObject.GetComponent<Transform>();
                    }
                    else if (hit.collider.gameObject.GetComponent<Transform>() != startConnection)
                    {
                        finishConnection = hit.collider.gameObject.GetComponent<Transform>();
                    }
                }
            }
        }
    }
    //TODO: универсализировать метод получения объекта через raycast hit
    //TODO: сделать веса для связей и элементов - логику соединений
    void GetConnection()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Connection")
            {
                currentViewConnection = hit.collider.gameObject;
            }
        }
    }

    void ChangeConnection()
    {
        try
        {
            startConnection = currentViewConnection.GetComponent<ConnectionUpdate>().firstObj;
            finishConnection = currentViewConnection.GetComponent<ConnectionUpdate>().secontObj;
            Destroy(hit.collider.gameObject);
            MakeConnection();
        }
        catch
        {

        }

    }

    void DropTarget()
    {
        manipulatorTarget = null;
    }

    void DeleteTarget()
    {
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
            available = true;
            targetLight = null;
        }
    }
    void Selected()
    {
        targetLight.enabled = true;
        available = false;
    }

    void Deselected()
    {
        if (targetLight)
        {
            targetLight.enabled = false;
            available = true;
            targetLight = null;
        }
    }

    public void HiglightTarget(Color color)
    {

        if (Physics.Raycast(ray, out hit))
        {
            Light light = hit.collider.gameObject.GetComponent<Light>();
            if (light)
            {
                if (targetLight && targetLight != light)
                {
                    Deselected();
                }
                targetLight = light;
                targetLight.color = color;
                if (available)
                {
                    Selected();
                }
            }
            else
            {
                Deselected();
            }
        }
        else
        {
            Deselected();
        }
    }

    void CalculateCurrentPosition()
    {
        if (manipulatorTarget)
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
                manipulatorTarget.Y(objectY + (cursor.y - startVector.y) - offsetPosition);
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

    void Pointer()
    {
        try
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition); ;
            RaycastHit h;
            if (Physics.Raycast(r, out h) && h.collider.gameObject.tag != "Connection")
            {
                Vector3 pos = startConnection.position;
                line.GetComponent<LineRenderer>().SetPosition(0, pos);
                line.GetComponent<LineRenderer>().SetPosition(1, h.point);
            }
        }
        catch
        {
            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3(0,0,0));
            line.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 0));
        }
    }

}
