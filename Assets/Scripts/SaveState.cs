static public class SaveState
{
    public static float cameraZoomMax;
    public static float cameraSpeed;
    public static float cameraSense;
    public static void GetCameraSettings (float zoom, float speed, float sense)
    {
        cameraZoomMax = zoom;
        cameraSpeed = speed;
        cameraSense = sense;
    }
}
