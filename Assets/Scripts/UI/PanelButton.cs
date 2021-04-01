using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject initializingComponent;
    [SerializeField] private string name;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool panelActive = false;
    [SerializeField] private GameObject buttonForSwapPosition;
    [SerializeField] private float swapOffsetX = 250;

    void Start()
    {
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
        }
    }
}
