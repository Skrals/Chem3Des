using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsControl : MonoBehaviour
{
    [Header("Settings object")]
    public GameObject cameraSettings;// настраиваемый объект
    [Header("Output vals from sliders")]
    public GameObject MaxZoomVal;// объекты вывода 
    public GameObject SpeedVal;
    public GameObject SenseVal;
    [Header ("Input sliders")]
    public Slider sliderMax;// слайдеры ввода
    public Slider sliderSpeed;
    public Slider sliderSense;
    [Header("")]
    [SerializeField] private float zoomMaxSet;// вывод значений в интерфейс
    [SerializeField] private float speedSet;
    [SerializeField] private float senseSet;
    private float tmpMax;// буфер 
    private float tmpSpeed;
    private float tmpSense;
    private void Start()// получаем минимальные значения
    {
        var camS = cameraSettings.GetComponent<CameraBuilder>();
        tmpMax = camS.zoomMax;
        tmpSpeed = camS.zoom;
        tmpSense = camS.mouseSense;

        sliderMax.minValue = tmpMax;
        sliderSense.minValue = tmpSense;
        sliderSpeed.minValue = tmpSpeed;
    }
    void Update()
    {
        UpdateUIVals();
        Settings();
    }
    private void OnApplicationQuit()
    {
        
    }
    private void Settings()// настройки через слайдеры
    {
        var camS = cameraSettings.GetComponent<CameraBuilder>();
        camS.zoomMax = sliderMax.value;
        camS.zoom = sliderSpeed.value;
        camS.mouseSense = sliderSense.value;
    }
    private void UpdateUIVals()// обновление значений в интерфейсе
    {
        var camS = cameraSettings.GetComponent<CameraBuilder>();
        zoomMaxSet = camS.zoomMax;
        speedSet = camS.zoom;
        senseSet = camS.mouseSense;

        MaxZoomVal.GetComponent<Text>().text = Convert.ToString(zoomMaxSet);
        SpeedVal.GetComponent<Text>().text = Convert.ToString(speedSet);
        SenseVal.GetComponent<Text>().text = Convert.ToString(senseSet);
    }
}
