
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    [SerializeField] private string name;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool showed = false;
    private Vector2 sizeOffset;
    private RectTransform rectTransform;

    void Start()
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
        else if (name == "Settings")
        {
            if (panel != null)
            {
                bool isActive = panel.activeSelf;
                panel.SetActive(!isActive);
            }
        }
        else if (name == "Exit") Application.Quit();
        else if (name == "Elements")
        {
            if (showed)
            {
                showed = false;
            }
            else
            {
                showed = true;
            }
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (tag == "Panel_button")
    //    {
    //        image = GetComponent<Image>();
    //        image.color = Color.blue;
    //        showed = true;
    //    }
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if (tag == "Panel_button")
    //    {
    //        image = GetComponent<Image>();
    //        image.color = Color.white;
    //        showed = false;
    //    }
    //}

    void Update()
    {
        if (showed)
        {
            Showed();
        }
        else
        {
            Hide();
        }
        //if (sceneIndex == 0)
        //{
        //    GameObject.Find("Main").GetComponent<Image>().color = Color.red;
        //}
        //else if (sceneIndex == 1)
        //{
        //    GameObject.Find("Builder").GetComponent<Image>().color = Color.red;
        //}
    }
    private void Showed()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        if (tag == "Elements_panel")
        {
            if (pos.x < 140)
            {
                float move = Time.deltaTime * 400;
                rectTransform.anchoredPosition = new Vector3(pos.x + move, pos.y);
            }
        }
    }
    private void Hide()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        if (tag == "Elements_panel")
        {
            if (pos.x > -120)
            {
                float move = Time.deltaTime * 400;
                rectTransform.anchoredPosition = new Vector3(pos.x - move, pos.y);
            }
        }
    }
}
