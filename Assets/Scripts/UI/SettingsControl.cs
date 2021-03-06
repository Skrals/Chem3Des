using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsControl : MonoBehaviour
{
    public GameObject cameraSettings;// настраиваемый объект
    public GameObject MaxZoomVal;// объекты вывода 
    public GameObject SpeedVal;
    public GameObject SenseVal;
    public Slider sliderMax;// слайдеры ввода
    public Slider sliderSpeed;
    public Slider sliderSense;

    [SerializeField] private float zoomMaxSet;// вывод значений в интерфейс
    [SerializeField] private float speedSet;
    [SerializeField] private float senseSet;
    private float tmpMax;// буфер минимальных значений
    private float tmpSpeed;
    private float tmpSense;
    private void Start()// получаем минимальные значения
    {
        tmpMax = cameraSettings.GetComponent<CameraBuilder>().zoomMax;
        tmpSpeed = cameraSettings.GetComponent<CameraBuilder>().zoom;
        tmpSense = cameraSettings.GetComponent<CameraBuilder>().MouseSense;

        sliderMax.minValue = tmpMax;
        sliderSense.minValue = tmpSense;
        sliderSpeed.minValue = tmpSpeed;

    }

    void Update()
    {
        UpdateUIVals();
        Settings();
    }


    private void Settings()// настройки через слайдеры
    {
        cameraSettings.GetComponent<CameraBuilder>().zoomMax = sliderMax.value;
        cameraSettings.GetComponent<CameraBuilder>().zoom = sliderSpeed.value;
        cameraSettings.GetComponent<CameraBuilder>().MouseSense = sliderSense.value;
    }

    private void UpdateUIVals()// обновление значений в интерфейсе
    {
        zoomMaxSet = cameraSettings.GetComponent<CameraBuilder>().zoomMax;
        speedSet = cameraSettings.GetComponent<CameraBuilder>().zoom;
        senseSet = cameraSettings.GetComponent<CameraBuilder>().MouseSense;

        MaxZoomVal.GetComponent<Text>().text = Convert.ToString(zoomMaxSet);
        SpeedVal.GetComponent<Text>().text = Convert.ToString(speedSet);
        SenseVal.GetComponent<Text>().text = Convert.ToString(senseSet);
    }
}
