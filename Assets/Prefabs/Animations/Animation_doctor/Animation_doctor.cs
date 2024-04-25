using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_doctor : MonoBehaviour
{
    public Animator animator;
    Doctor_room Starter;

    void Start()
    {
        animator = GetComponent<Animator>();
        Starter = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Doctor_room>();
    }

    private void Update()
    {
        if (Starter.Starting == true)
        {
            StartCoroutine(Delay());
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        Shifter();
    }

    private void Shifter()
    {
        animator.Play("Scene1_Doctor");
        StartCoroutine(Delay_2());
    }

    private IEnumerator Delay_2()
    {
        yield return new WaitForSeconds(4f);
        Shifter_2();
    }

    private void Shifter_2()
    {
        animator.Play("Scene2_Doctor");
        StartCoroutine(Delay_3());
    }

    private IEnumerator Delay_3()
    {
        yield return new WaitForSeconds(6.4f);
        Shifter_3();
    }

    private void Shifter_3()
    {
        animator.Play("Scene3_Doctor");
        //StartCoroutine(Delay_3());
    }

}
