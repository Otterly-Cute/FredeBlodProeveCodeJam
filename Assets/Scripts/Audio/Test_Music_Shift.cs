using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Music_Shift : MonoBehaviour
{
    SoundManager soundManager_get;
    public GameObject Appear_Button;
    public GameObject Button_start;
    private void Start()
    {
        soundManager_get = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
    }

    public void Startbutton_Destroy()
    {
        StartCoroutine(storyDelay());
        soundManager_get.Talk_Intro();
        Destroy(Button_start); 
    }

    private IEnumerator storyDelay()
    {
        yield return new WaitForSeconds(25);
        Appear_Button.gameObject.SetActive(true);
    }

    public void front()
    {
        soundManager_get.sfxsource.Stop();
        //UnityEngine.SceneManagement.SceneManager.LoadScene();
        //soundManager_get.Talk_2();

    }

    public void Back()
    {
        soundManager_get.sfxsource.Stop();
        //UnityEngine.SceneManagement.SceneManager.LoadScene();
        //soundManager_get.Talk_1();

    }

}
