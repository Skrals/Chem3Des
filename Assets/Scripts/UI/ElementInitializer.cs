using UnityEngine;
using UnityEngine.EventSystems;

public class ElementInitializer : MonoBehaviour, IPointerClickHandler
{
    public GameObject element;
    public InitializerSwitch init;
  
    public void OnPointerClick(PointerEventData eventData)
    {
        name = eventData.pointerEnter.name;
        init.Initializer(element);
        Debug.Log(name);
    }
}
