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
    private int maxValue = 20;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        source = soundManager.sfxsource;
    }

    public IEnumerator Start()
    {
        soundManager.playSFX("puste");
        yield return StartCoroutine(WaitForSound());
    }

   /* void Update()
    {
        if (microphoneScript.GetDecibelFromMicrophone() > minimumDecibel)
        {
            slider.value = countUp++;
        }

        //when value equals 20, arrow button and audio is played
        if (slider.value == 20 && button.activeSelf == false)
        {
            button.SetActive(true);
            soundManager.playSFX("puste2");
        }
    }*/

    /// <summary>
    /// https://gamedev.stackexchange.com/questions/134002/how-can-i-do-something-after-an-audio-has-finished
    /// </summary>
    /// <param name="Sound"></param>
    /// <returns></returns>
    public IEnumerator WaitForSound()
    {
        while (source.isPlaying == false)
        {
            yield return null;
        }

        CheckDecibel();
    }

    public void CheckDecibel()
    {
        while (slider.value < maxValue)
        {
            if (microphoneScript.GetDecibelFromMicrophone() > minimumDecibel)
            {
                slider.value = countUp++;
            }
        }

        button.SetActive(true);
        soundManager.playSFX("puste2");
    }


}
