using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector3 positionVector;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(this.name); 
    }

}
