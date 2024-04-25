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

    public GameObject button;

    public int countUp = 0;
    public float minimumDecibel = 0.5f;

    void Update()
    {
        if (microphoneScript.GetDecibelFromMicrophone() > minimumDecibel)
        {
            slider.value = countUp++;
        }

        if (slider.value == 20)
        {
            button.SetActive(true);
        }
    }
}
