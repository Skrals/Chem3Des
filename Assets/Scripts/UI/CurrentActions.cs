using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CurrentActions : MonoBehaviour
{
    [Header("Action panel text")]
    public Text action;
    public Text actionType;
    public Text currentElement;
    public Text connectionType;
    public Text isConnectionMode;
    private string none = $"-----";

    [Header("Action panel sprites")]
    public Sprite [] sprites;
    public GameObject actionPanel;
 
    [Header ("HTML color tags")]
    string color = "";
    string colorTagStart;
    string colorTagEnd = "</color>";

    private void Start()
    {
        action.text = actionType.text = currentElement.text = connectionType.text = isConnectionMode.text = "";
        CurrentElement(null);
    }
    void Update()
    {
        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKey(key))
            {
                action.text = $"Нажата клавиша: <color=lime>{key}</color>";
                ThisKeyCombinationAction (key.ToString());
            }
        }
        if (!Input.anyKey)
        {
            action.text = none;
            ThisKeyCombinationAction(action.text);
        }
    }

    void ThisKeyCombinationAction(string key)
    {
        color = "orange";
        colorTagStart = "<color=" + color + ">";
        string s = $"Действие: ";
        if (isConnectionMode.text != "Режим построения связей")
        {
            switch (key)
            {
                case "D":
                    actionType.text = $"{s}{colorTagStart}Удаление{colorTagEnd}";
                    break;
                case "LeftShift":
                    actionType.text = $"{s}{colorTagStart}Расположить выбранный элемент{colorTagEnd}";
                    break;
                case "Tab":
                    actionType.text = $"{s}{colorTagStart}Перемещение элемента{colorTagEnd}";
                    break;
                case "T":
                    actionType.text = $"{s}{colorTagStart}Изменение типа связи{colorTagEnd}";
                    break;
            }
            actionPanel.GetComponent<Image>().sprite = sprites[0];
        }
        else
        {
            actionPanel.GetComponent<Image>().sprite = sprites[1];
        }
        switch (key)
        {
            case "Escape":
                actionType.text = $"{s}{colorTagStart}Сброс{colorTagEnd}";
                break;
            case "LeftControl":
                actionType.text = $"{s}{colorTagStart}Переместить камеру{colorTagEnd}";
                break;
            case "-----":
                actionType.text = $"{s}{none}";
                break;
                
        }
    }

    public void CurrentElement(string element)
    {
        
        switch (element)
        {
            case "H":
                color = "white";
                break;
            case "C":
                color = "black";
                break;
            case "O":
                color = "red";
                break;
            case "N":
                color = "lightblue";
                break;
            case "S":
                color = "yellow";
                break;
            case "F":
                color = "orange";
                break;
            case "CL":
                color = "lime";
                break;
            case "BR":
                color = "brown";
                break;

        }
        colorTagStart = "<color=" + color + ">";
        if (element != null)
        {
            currentElement.text = $"Выбранный элемент:{colorTagStart} {element} {colorTagEnd}";
        }
        else
        {
            currentElement.text = $"Выбранный элемент: {none}";
        }
    }
    public void CurrentConnection(int value)
    {
        string s = "Выбранная связь: ";
        color = "lightblue";
        colorTagStart = "<color=" + color + ">";
        switch (value)
        {
            case 0:
                connectionType.text = $"{s}{colorTagStart}одинарная{colorTagEnd}";
                break;
            case 1:
                connectionType.text = $"{s}{colorTagStart}двойная{colorTagEnd}";
                break;
            case 2:
                connectionType.text = $"{s}{colorTagStart}тройная{colorTagEnd}";
                break;

        }
    }

    public void IsConnectionMode(bool mode)
    {
        if (mode)
        {
            isConnectionMode.text = $"Режим построения связей";
        }
        else
        {
            isConnectionMode.text = $"";
        }
    }

}

