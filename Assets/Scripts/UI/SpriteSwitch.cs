using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpriteSwitch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //смена спрайта при наведении и нажатии
    public Sprite defoltSprite;
    public Sprite switchOnSprite;
    public Sprite usedSprite;
    [SerializeField] string name;//имя нажатой кнопки

    //для смены спрайта кнопки со сменой позиции
    public Sprite switchDefolt;
    public Sprite switchOnEneteredSprite;
    [SerializeField] bool switchState = false;
    [SerializeField] Sprite defoltTmp;//сохранение начального состояния
    [SerializeField] Sprite enteredTmp;
    void Start()
    {
        name = null;
        defoltTmp = defoltSprite;
        enteredTmp = switchOnSprite;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        switchOn(switchOnSprite);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (name != "Settings") { switchOn(defoltSprite); }
        else { switchOn(usedSprite); }
    }
    void switchOn(Sprite sp)
    {
        this.GetComponent<Image>().sprite = sp;
    }
    public void switchDefoltSprites()
    {
        if (!switchState)
        {
            switchState = true;
            defoltSprite = switchDefolt;
            switchOnSprite = switchOnEneteredSprite;
        }
        else
        {
            switchState = false;
            defoltSprite = defoltTmp;
            switchOnSprite = enteredTmp;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.gameObject.name == "Settings")
        {
            if (name == null) { name = this.gameObject.name; }
            else { name = null; }
            switchOn(usedSprite);
        }
    }
}
