using UnityEngine;

public class GUIControl : MonoBehaviour
{
    [SerializeField] private GUIControlInfo control;
    [SerializeField] private GameObject currentActionsInfo;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && control.enabled)
        {
            control.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && !control.enabled)
        {
            control.enabled = true;
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
