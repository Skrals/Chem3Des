using UnityEngine;

public class GUIControlInfo : MonoBehaviour
{
    [SerializeField] private float guiX;
    [SerializeField] private float guiOffsetX;
    [SerializeField] private float guiY;
    [SerializeField] private float guiBoxSizeX;
    [SerializeField] private float guiBoxSizeY;
    [SerializeField] private int elementsAmount;
    [SerializeField] private int elementsInternalOffsetY;
    [SerializeField] private float layoutSizeH;
    private int [] offsetIteratorY;
    void Awake()
    {
        elementsAmount = 10;
        elementsInternalOffsetY = 40;
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
        GUI.Box(new Rect(guiX, guiY, guiBoxSizeX, guiBoxSizeY), "Справка по управлению - H");
        GUI.Label(new Rect(guiX + 10,guiY+offsetIteratorY[0], guiBoxSizeX-20, layoutSizeH), $"Удерживать Left Ctrl + LMB - перемещение камеры на указанный элемент");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[1], guiBoxSizeX - 20, layoutSizeH), "Удерживать Left Shift + LMB - инициализация выбранного элемента");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[2]-5, guiBoxSizeX - 20, layoutSizeH), "Удерживать Tab + LMB - перемещение выбранного компонента \n(нельзя использовать в режиме построения связей)");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[3]+10, guiBoxSizeX - 20, layoutSizeH), "Удерживать D + LMB - удаление элемента \n(нельзя использовать в режиме построения связей)");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[4]+10, guiBoxSizeX - 20, layoutSizeH), "Удерживать RMB - вращение камеры вокруг элемента");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[5], guiBoxSizeX - 20, layoutSizeH), "Scroll Up / Scroll Down - приближение / отдаление");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[6], guiBoxSizeX - 20, layoutSizeH), "С - переключение режима построения связей");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[7], guiBoxSizeX - 20, layoutSizeH), "Удерживать T + двойной клик LMB по связи между атомами - вызов меню изменения связей \n(в режиме построения связей нажатие клавиши T)");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[8]+15, guiBoxSizeX - 20, layoutSizeH), "Клавиша I - скрыть / показать информационную панель");
        GUI.Label(new Rect(guiX + 10, guiY + offsetIteratorY[9], guiBoxSizeX - 20, layoutSizeH), "Клавиша Esc - сброс начального элемента в режиме построения");
    }
}
