using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowOMeter : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public MicrophoneSensor microphoneScript;

    public int countUp = 0;
    public float minimumDecibel = 1;


    void Start()
    {
        //FillUp();
    }


    void Update()
    {
        if (microphoneScript.GetDecibelFromMicrophone() > minimumDecibel)
        {
            //SetSlider(countUp++);
            slider.value = countUp++;
        }
    }

    /// <summary>
    /// https://www.w3schools.com/cs/cs_while_loop.php
    /// </summary>
    public void FillUp()
    {
        int i = 0;
        while (i < 100)
        {
            if (microphoneScript.GetDecibelFromMicrophone()>minimumDecibel) 
            {
                //SetSlider(countUp++);
                slider.value = countUp++;
                i++;
            }
        }
    }

    public void SetSlider(int tmp)
    { slider.value = tmp; }
}
