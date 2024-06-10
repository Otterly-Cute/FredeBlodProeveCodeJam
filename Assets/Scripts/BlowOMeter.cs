using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowOMeter : MonoBehaviour
{
    private Slider slider;
    private MicrophoneSensor microphoneScript;
    [SerializeField] GameObject button;
    private SoundManager soundManager;

    private int countUp = 0;
    private float minimumDecibel = 0.5f;
    private int maxValue = 100;
    private int duration = 4;

    /// <summary>
    /// gets components on awake
    /// </summary>
    public void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        slider = GetComponent<Slider>();
        microphoneScript = GetComponent<MicrophoneSensor>();
    }

    /// <summary>
    /// plays audio and then waits for it to be over
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        //make sure the slider values are set correct on start
        slider.value = countUp;
        slider.maxValue = maxValue;

        soundManager.playSFX("puste");
        yield return StartCoroutine(WaitForSound()); //makes sure our audioclip is done playing before starting to use the microphone
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
        Debug.Log("Finished Audio");
    }
}