using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpriteSwitch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite defoltSprite;
    public Sprite switchOnSprite;
    public Sprite usedSprite;

    [SerializeField] string name;
    void Start()
    {
        name = null;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
         switchOn(switchOnSprite);
       
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (name != "Settings")
        {
            switchOn(defoltSprite);
        }
        else
        {
            switchOn(usedSprite);
        }
    }

    void switchOn( Sprite sp)
    {
          this.GetComponent<Image>().sprite = sp;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.gameObject.name == "Settings")
        {
            if (name == null)
            {
                name = this.gameObject.name;
            }
            else
            {
                name = null;
            }
           switchOn(usedSprite);
        }
    }
}
