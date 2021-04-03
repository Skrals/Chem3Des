using UnityEngine;

public class GUIControl : MonoBehaviour
{
    [SerializeField] private GUIControlInfo control;
    [SerializeField] private GameObject currentActionsInfo;
    [SerializeField] private GameObject exitBt;
    // Start is called before the first frame update
    private void Start()
    {
        exitBt.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && control.enabled)
        {
            control.enabled = false;
            exitBt.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.H) && !control.enabled)
        {
            control.enabled = true;
            exitBt.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I) && !currentActionsInfo.activeSelf)
        {
            currentActionsInfo.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && currentActionsInfo.activeSelf)
        {
            currentActionsInfo.SetActive(false);
        }

    }
}
