using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicsource, sfxsource;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Talk_Intro()
    {
        playSFX("AudioClip_1_Intro1");

    }

    public void Talk_Game1()
    {
        playSFX("AudioClip_2_Doctor");

    }

    public void Plaster_off()
    {
        playSFX("AudioClip_3_PlasterOff");

    }

    public void Find_elastik()
    {
        playSFX("AudioClip_4_ElastikFind");

    }

    public void Click_elastik()
    {
        playSFX("AudioClip_5_Elastik_found");

    }



    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicsource.clip = s.clip;
            musicsource.Play();
        }

    }

    public void playSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxsource.PlayOneShot(s.clip);
        }
    }
}
