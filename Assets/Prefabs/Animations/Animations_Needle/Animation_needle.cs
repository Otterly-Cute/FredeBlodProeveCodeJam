using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_needle : MonoBehaviour
{
    public Animator animator;
    SoundManager soundManager_get;

    void Start()
    {
        soundManager_get = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(Delay());
        //soundManager_get.playSFX("AudioClip_1_Intro1");
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.5f);
        Shifter();
    }

    private void Shifter()
    {
        animator.Play("Scene_1needle");
        StartCoroutine(Delay_2());
    }

    private IEnumerator Delay_2()
    {
        yield return new WaitForSeconds(7.5f);
        Shifter_2();
    }

    private void Shifter_2()
    {
        animator.Play("Scene_2needle");
    }
}
