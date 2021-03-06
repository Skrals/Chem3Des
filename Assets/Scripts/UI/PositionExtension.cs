using UnityEngine;

public static class PositionExtension
{
    // Установка глобальных значений
    public static void X(this Transform tr, float newValue)
    {
        tr.position = new Vector3(newValue, tr.position.y, tr.position.z);
    }

    public static void Y(this Transform tr, float newValue)
    {
        tr.position = new Vector3(tr.position.x, newValue, tr.position.z);
    }

    public static void Z(this Transform tr, float newValue)
    {
        tr.position = new Vector3(tr.position.x, tr.position.y, newValue);
    }

    public static void X(this GameObject go, float newValue)
    {
        go.transform.position = new Vector3(newValue, go.transform.position.y, go.transform.position.z);
    }

    public static void Y(this GameObject go, float newValue)
    {
        go.transform.position = new Vector3(go.transform.position.x, newValue, go.transform.position.z);
    }

    public static void Z(this GameObject go, float newValue)
    {
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, newValue);
    }

    // Получение глобальных значений
    public static float X(this Transform tr)
    {
        return tr.position.x;
    }

    public static float Y(this Transform tr)
    {
        return tr.position.y;
    }

    public static float Z(this Transform tr)
    {
        return tr.position.z;
    }

    public static float X(this GameObject go)
    {
        return go.transform.position.x;
    }

    public static float Y(this GameObject go)
    {
        return go.transform.position.y;
    }

    public static float Z(this GameObject go)
    {
        return go.transform.position.z;
    }

    // Установка локальных значений
    public static void LocX(this Transform tr, float newValue)
    {
        tr.localPosition = new Vector3(newValue, tr.localPosition.y, tr.localPosition.z);
    }

    public static void LocY(this Transform tr, float newValue)
    {
        tr.localPosition = new Vector3(tr.localPosition.x, newValue, tr.localPosition.z);
    }

    public static void LocZ(this Transform tr, float newValue)
    {
        tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, newValue);
    }

    public static void LocX(this GameObject go, float newValue)
    {
        go.transform.localPosition = new Vector3(newValue, go.transform.localPosition.y, go.transform.localPosition.z);
    }

    public static void LocY(this GameObject go, float newValue)
    {
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, newValue, go.transform.localPosition.z);
    }

    public static void LocZ(this GameObject go, float newValue)
    {
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, newValue);
    }

    // Получение локальных значений
    public static float LocX(this Transform tr)
    {
        return tr.localPosition.x;
    }

    public static float LocY(this Transform tr)
    {
        return tr.localPosition.y;
    }

    public static float LocZ(this Transform tr)
    {
        return tr.localPosition.z;
    }

    public static float LocX(this GameObject go)
    {
        return go.transform.localPosition.x;
    }

    public static float LocY(this GameObject go)
    {
        return go.transform.localPosition.y;
    }

    public static float LocZ(this GameObject go)
    {
        return go.transform.localPosition.z;
    }
}
