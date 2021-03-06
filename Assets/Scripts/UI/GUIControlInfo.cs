using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControlInfo : MonoBehaviour
{
    [SerializeField] private float guiX;
    [SerializeField] private float guiOffsetX;
    [SerializeField] private float guiY;
    [SerializeField] private float guiBoxSize;
    [SerializeField] private int elementsAmount;
    [SerializeField] private int elementsInternalOffsetY;
    [SerializeField] private float layoutSizeH;
    private int [] offsetIteratorY;
    // [SerializeField] private float guiOffsetY;

    void Awake()
    {
        elementsAmount = 10;
        elementsInternalOffsetY = 40;
        guiBoxSize = 350;
        layoutSizeH = 100;
        offsetIteratorY = new int[elementsAmount];
        int internalOffset = 0;
        for (int i = 0; i < elementsAmount; i++)
        {
            internalOffset += elementsInternalOffsetY;
            offsetIteratorY[i] = internalOffset;
        }
    }
    private void OnGUI()
    {
        guiX = Screen.width - guiOffsetX;
        //guiY = Screen.height - guiOffsetY;
        GUI.Box(new Rect(guiX, guiY, guiBoxSize, guiBoxSize), "Справка по управлению - H");
        GUI.Label(new Rect(guiX + 10,guiY+offsetIteratorY[0], guiBoxSize-20, layoutSizeH), $"Удерживать Left Ctrl + LMB  перемещение камеры на указанный элемент");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[1], guiBoxSize - 20, layoutSizeH), "Удерживать Left Shift + LMB инициализация выбранного элемента");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[2], guiBoxSize - 20, layoutSizeH), "Удерживать Tab + LMB перемещение выбранного компонента");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[3], guiBoxSize - 20, layoutSizeH), "Удерживать RMB вращение камеры вокруг элемента");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[4], guiBoxSize - 20, layoutSizeH), "Scroll Up / Scroll Down приближение / отдаление");
    }
}
