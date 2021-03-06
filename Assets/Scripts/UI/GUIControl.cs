using UnityEngine;

public class GUIControl : MonoBehaviour
{
    [SerializeField] private GUIControlInfo control;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && control.enabled)
        {
            control.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.H) && !control.enabled)
        {
            control.enabled = true;
        }
    }
}
