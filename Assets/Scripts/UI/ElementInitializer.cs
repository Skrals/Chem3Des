using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementInitializer : MonoBehaviour, IPointerClickHandler
{
    public GameObject element;
    public Transform spawnPosition;// удалить
    public GameObject initializer;// удалить

    [SerializeField] private Vector3 offset;//перенести
    [SerializeField] private Vector3 mousePositionVector;
    public static string name;// удалить
    public void OnPointerClick(PointerEventData eventData)// ??
    {
        name = eventData.pointerEnter.name;
        Debug.Log(name);
    }

    public void Initializer()//перенести в switch с параметром GameObject element
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift) && element != null)
        {
            offset = new Vector3(10f, 10f, 10f);
            mousePositionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset);
            Instantiate(element, (mousePositionVector), Quaternion.identity);
        }

    }

    void Start ()// удалить
    {
        initializer = GameObject.Find("ElementSwitcher");
    }

}
