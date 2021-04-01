using UnityEngine;

public class InitializerSwitch : MonoBehaviour
{
    public GameObject currentElementShow;
    [SerializeField] private GameObject element;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 mousePositionVector;
    
    public void Initializer(GameObject elem)
    {
        element = elem;
        try { currentElementShow.GetComponent<CurrentActions>().CurrentElement(elem.name); }
        catch { }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift) && element != null)
        {
            offset = -CameraBuilder.offset;
            mousePositionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset);
            Instantiate(element, (mousePositionVector), Quaternion.identity);
        }
    }
}
