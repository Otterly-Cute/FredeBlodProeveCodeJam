using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Music_Shift : MonoBehaviour
{
    SoundManager soundManager_get;

    private void Start()
    {
        soundManager_get = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
    }
    public void front()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
        soundManager_get.Talk_2();
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        soundManager_get.Talk_1();
    }
}
