using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_needle : MonoBehaviour
{
    public Animator animator;
    Test_Music_Shift Starter;

    void Start()
    {
        animator = GetComponent<Animator>();
        Starter = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Test_Music_Shift>();
    }

    private void Update()
    {
        if (Starter.start == true)
        {
            StartCoroutine(Delay());
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(4.9f);
        Shifter();
    }

    private void Shifter()
    {
        animator.Play("Scene_1needle");
        StartCoroutine(Delay_2());
    }

    private IEnumerator Delay_2()
    {
        yield return new WaitForSeconds(6f);
        Shifter_2();
    }

    private void Shifter_2()
    {
        animator.Play("Scene_2needle");
    }
}
