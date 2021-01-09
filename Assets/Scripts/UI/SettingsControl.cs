using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsControl : MonoBehaviour
{
    public GameObject cameraSettings;
    public GameObject MaxVal;
    public GameObject SpeedVal;
    public GameObject SenseVal;

    [SerializeField] private float zoomMaxSet;
    [SerializeField] private float speedSet;
    [SerializeField] private float senseSet;


    void Update()
    {
        zoomMaxSet = cameraSettings.GetComponent<CameraBuilder>().zoomMax;
        speedSet = cameraSettings.GetComponent<CameraBuilder>().zoom;
        senseSet = cameraSettings.GetComponent<CameraBuilder>().MouseSense;

        MaxVal.GetComponent<Text>().text = Convert.ToString(zoomMaxSet);
        SpeedVal.GetComponent<Text>().text = Convert.ToString(speedSet);
        SenseVal.GetComponent<Text>().text = Convert.ToString(senseSet);
    }
}
