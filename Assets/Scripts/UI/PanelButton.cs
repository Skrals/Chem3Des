using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject initializingComponent;
    [SerializeField] private string name;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool panelActive = false;
    [SerializeField] private GameObject buttonForSwapPosition;
    [SerializeField] private float swapOffsetX = 250;

    //[SerializeField] private bool showed = false;
   // private Vector2 sizeOffset;
  //  private RectTransform rectTransform;

    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
        //sizeOffset = rectTransform.sizeDelta;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        name = eventData.pointerEnter.name;
        Debug.Log(name);
        if (name == "Builder" && sceneIndex == 0) SceneManager.LoadScene(1);
        else if (name == "Main" && sceneIndex == 1) SceneManager.LoadScene(0);
        else if (name == "Settings")
        {
            if (initializingComponent != null)
            {
                bool isActive = initializingComponent.activeSelf;
                initializingComponent.SetActive(!isActive);
            }
        }
        else if (name == "Exit") Application.Quit();
        else if (name == "Show_elements")
        {
            if (initializingComponent != null)
            {
                bool isActive = initializingComponent.activeSelf;
                initializingComponent.SetActive(!isActive);
                if(!panelActive)
                {
                    panelActive = true;
                    buttonForSwapPosition.GetComponent<RectTransform>().transform.localPosition = new Vector2(buttonForSwapPosition.transform.localPosition.x + swapOffsetX, buttonForSwapPosition.transform.localPosition.y);
                    buttonForSwapPosition.GetComponent<SpriteSwitch>().switchDefoltSprites();
                }
                else
                {
                    panelActive = false;
                    buttonForSwapPosition.GetComponent<RectTransform>().transform.localPosition = new Vector2(buttonForSwapPosition.transform.localPosition.x - swapOffsetX, buttonForSwapPosition.transform.localPosition.y);
                    buttonForSwapPosition.GetComponent<SpriteSwitch>().switchDefoltSprites();
                }
            }
            //if (showed)
            //{
            //    showed = false;
            //}
            //else
            //{
            //    showed = true;
            //}
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

    //void Update()
    //{
    //    if (showed)
    //    {
    //        Showed();
    //    }
    //    else
    //    {
    //        Hide();
    //    }
    //    //if (sceneIndex == 0)
    //    //{
    //    //    GameObject.Find("Main").GetComponent<Image>().color = Color.red;
    //    //}
    //    //else if (sceneIndex == 1)
    //    //{
    //    //    GameObject.Find("Builder").GetComponent<Image>().color = Color.red;
    //    //}
    //}
    //private void Showed()
    //{
    //    //Vector2 pos = rectTransform.anchoredPosition;
    //    if (tag == "Elements_panel")
    //    {
    //        panel.SetActive(true);
    //        //if (pos.x < 140)
    //        //{
    //        //    float move = Time.deltaTime * 400;
    //        //    rectTransform.anchoredPosition = new Vector3(pos.x + move, pos.y);
    //        //}
    //    }
    //}
    //private void Hide()
    //{
    //    //Vector2 pos = rectTransform.anchoredPosition;
    //    if (tag == "Elements_panel")
    //    {
    //        panel.SetActive(false);
    //        //if (pos.x > -120)
    //        //{
    //        //    float move = Time.deltaTime * 400;
    //        //    rectTransform.anchoredPosition = new Vector3(pos.x - move, pos.y);
    //        //}
    //    }
    //}
}
