using UnityEditor;
using UnityEngine;

public class NewBehaviourScript 
{
    [InitializeOnLoadMethod]
    static void PreviewComponentsIcons()
    {
        EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcons;
    }

    static void DrawHierarchyIcons(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = (GameObject)EditorUtility.InstanceIDToObject(instanceID);

        if (gameObject == null)
            return;

        Rect rect = new Rect(selectionRect);
        rect.width = 16;
        rect.height = 16;
#if UNITY_2019_1_OR_NEWER 
        rect.x = Screen.width - 48;
#else
        rect.x = Screen.width - 20;
#endif

        foreach (Component component in gameObject.GetComponents<Component>())
        {
            if (component is Transform)
                continue;

            GUI.Label(rect, AssetPreview.GetMiniThumbnail(component));
            rect.x -= 16;
        }
    }
}
