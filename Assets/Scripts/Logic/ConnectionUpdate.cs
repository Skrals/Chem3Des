using UnityEngine;

public  class ConnectionUpdate : MonoBehaviour
{
    public  Transform firstObj;
    public  Transform secontObj;

    [SerializeField] private Vector3 v1;
    [SerializeField] private Vector3 v2;

    private float connectionSize;
    public  void ConnectionUp(Transform t1, Transform t2)// принимаем компоненты трансформа связи атомов
    {
        firstObj = t1;
        secontObj = t2;
    }


    private void Update()
    {
        WhichConnectionIs(gameObject.name);
        if (firstObj != null && secontObj != null)
        {
            v1 = firstObj.position;
            v2 = secontObj.position;
            this.transform.localScale = new Vector3(connectionSize,connectionSize, Vector3.Distance(v1, v2));
            this.transform.position = new Vector3((v1.x + v2.x) / 2, (v1.y + v2.y) / 2, (v1.z + v2.z) / 2);
            this.transform.rotation = Quaternion.RotateTowards(Quaternion.LookRotation(v1), Quaternion.LookRotation((v1 - v2)), 360f);
        }
        else
        { 
            DeleteConnection();
        }
    }

    private void DeleteConnection()
    {
         Destroy(gameObject);
    }
    private void WhichConnectionIs (string gameObject)
    {
       switch(gameObject)
        {
            case "Connect1(Clone)":
                connectionSize = 0.2f;
                break;
            case "Connect2(Clone)":
                connectionSize = 0.2f;
                break;
            case "Connect3(Clone)":
                connectionSize = 0.35f;
                break;
        }
    }
}
