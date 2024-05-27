using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowOMeter : MonoBehaviour
{
    public Slider slider;
   // public AudioSource source;
    public MicrophoneSensor microphoneScript;

    public GameObject button;

    public int countUp;
    public float minimumDecibel = 0.5f;
    private int maxValue = 20;
    private int duration = 5;

    private SoundManager soundManager;

    public void Awake()
    {
       
       // source = soundManager.sfxsource;
    }

    IEnumerator Start()
    {

        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        countUp= 0;
        soundManager.playSFX("puste");
        yield return StartCoroutine(WaitForSound());
        CheckDecibel();
    }

  /* IEnumerator Update()
    {
        yield return StartCoroutine(WaitForSound());

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
   /* IEnumerator WaitForSound()
    {
        while (source.isPlaying == false)
        {
            yield return null;
        }

        CheckDecibel();
    }*/


    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(duration);
        print("FinishAudio");

        
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
