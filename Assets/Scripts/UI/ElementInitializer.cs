using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementInitializer : MonoBehaviour, IPointerClickHandler
{
    public GameObject element;
    public Transform spawnPosition;

    [SerializeField] private string name;
    public void OnPointerClick(PointerEventData eventData)
    {
        name = eventData.pointerEnter.name;
        if(element != null)
        {
            Initializer();
        }
    }

    private void Initializer ()
    {
        Instantiate(element,  (new Vector3(0f,0f,0f)), Quaternion.identity);
    }
   
}
