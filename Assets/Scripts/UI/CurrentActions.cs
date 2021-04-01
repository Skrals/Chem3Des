using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CurrentActions : MonoBehaviour
{
    public Text action;
    public Text actionType;
    public Text currentElement;
    public Text connectionType;
    public Text isConnectionMode;
    private string none = "-----";
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
                action.text = $"Нажата клавиша: {key}";
                ThisKeyCombinationAction(key.ToString());
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
        string s = "Действие: ";
        if (isConnectionMode.text != "Режим построения связей")
        {
            switch (key)
            {
                case "D":
                    actionType.text = $"{s}Удаление";
                    break;
                case "LeftShift":
                    actionType.text = $"{s}Расположить выбранный элемент";
                    break;
                case "Tab":
                    actionType.text = $"{s}Перемещение элемента";
                    break;
                case "T":
                    actionType.text = $"{s}Изменение типа связи";
                    break;
            }
        }
        switch (key)
        {
            case "Escape":
                actionType.text = $"{s}Сброс";
                break;
            case "LeftControl":
                actionType.text = $"{s}Переместить камеру";
                break;
            case "-----":
                actionType.text = $"{s}{none}";
                break;
        }
    }

    public void CurrentElement(string element)
    {
        if (element != null)
        {
            currentElement.text = $"Выбранный элемент: {element}";
        }
        else
        {
            currentElement.text = $"Выбранный элемент: {none}";
        }
    }
    public void CurrentConnection(int value)
    {
        string s = "Выбранная связь: ";
        switch (value)
        {
            case 0:
                connectionType.text = $"{s}одинарная";
                break;
            case 1:
                connectionType.text = $"{s}двойная";
                break;
            case 2:
                connectionType.text = $"{s}тройная";
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
