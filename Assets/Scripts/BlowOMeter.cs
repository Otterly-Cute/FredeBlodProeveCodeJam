using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowOMeter : MonoBehaviour
{
    public Slider slider;
    public MicrophoneSensor microphoneScript;
    public GameObject button;
    private SoundManager soundManager;

    public int countUp = 0;
    public float minimumDecibel = 0.5f;
    private int maxValue = 20;
    private int duration = 4;

    /// <summary>
    /// gets component on awake
    /// </summary>
    public void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
    }

    /// <summary>
    /// plays audio and then waits for it to be over
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        soundManager.playSFX("puste");
        yield return StartCoroutine(WaitForSound());
    }

    public void Update()
    {

        //checks if the decibel level is above the minimum level, if true we will add one to the slider value
        if (microphoneScript.GetDecibelFromMicrophone() > minimumDecibel)
        {
            slider.value = countUp++;
        }

        //when slider value equal max value and the button is not active, button is activated and audio is played
        if (slider.value == maxValue && button.activeSelf == false)
        {
            button.SetActive(true);
            soundManager.playSFX("puste2");
        }
    }

    /// <summary>
    /// waits for sound to be over
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(duration);
        print("FinishAudio");
    }

}
