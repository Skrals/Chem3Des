
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image image;
    [SerializeField] private string name;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool showed = false;
    private Vector2 sizeOffset;
    private RectTransform rectTransform;

    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        sizeOffset = rectTransform.sizeDelta;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        name = eventData.pointerEnter.name;
        if (name == "Builder" && sceneIndex == 0) SceneManager.LoadScene(1);
        else if (name == "Main" && sceneIndex == 1) SceneManager.LoadScene(0);
        else if (name == "Settings") { }
        else if (name == "Exit") Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tag == "Panel_button")
        {
            image = GetComponent<Image>();
            image.color = Color.blue;
            showed = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tag == "Panel_button")
        {
            image = GetComponent<Image>();
            image.color = Color.white;
            showed = false;
        }
    }

    void Update()
    {
        if(showed)
        {
            Showed();
        }
        else
        {
            Hide();
        }
        if( sceneIndex == 0)
        {
            GameObject.Find("Main").GetComponent<Image>().color = Color.red;
        }
        else if( sceneIndex == 1)
        {
            GameObject.Find("Builder").GetComponent<Image>().color = Color.red;

        }
    }
    private void Showed()
    {
        if (tag == "Panel_button")
        {
            Vector2 pos = rectTransform.anchoredPosition;
            if (pos.y > -24)
            {
                float move = Time.deltaTime * 100;
                rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - move);
            }
        }
    }
    private void Hide()
    {
        if (tag == "Panel_button")
        {
            Vector2 pos = rectTransform.anchoredPosition;
            if (pos.y > -sizeOffset.y && pos.y < 15)
            {
                float move = Time.deltaTime * 100;
                rectTransform.anchoredPosition = new Vector3(pos.x, pos.y + move);
            }
        }
    }
}
