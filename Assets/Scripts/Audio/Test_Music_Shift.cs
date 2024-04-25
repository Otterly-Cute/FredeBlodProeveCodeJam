using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Music_Shift : MonoBehaviour
{
    SoundManager soundManager_get;
    public GameObject Appear_Button_puzzle;
    public GameObject Appear_Button_Bricks;
    public GameObject Appear_Button_Tower;
    public GameObject Button_start;
    public bool start = false;

    private void Start()
    {
        soundManager_get = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
    }

    public void Startbutton_Destroy()
    {
        start = true;
        StartCoroutine(storyDelay());
        soundManager_get.Talk_Intro();
        Destroy(Button_start);
    }

    private IEnumerator storyDelay()
    {
        yield return new WaitForSeconds(25);
        Appear_Button_puzzle.gameObject.SetActive(true);
        Appear_Button_Bricks.gameObject.SetActive(true);
        Appear_Button_Tower.gameObject.SetActive(true);
    }

    public void Puzzle_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Bricks_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Tower_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void Play_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void Doctor_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        soundManager_get.Talk_Game1();
    }

    public void Trylleplaster_off()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
        soundManager_get.Plaster_off();
    }

    public void Find_Object_Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
        soundManager_get.Find_elastik();
    }

    public void Elastik_found()
    {
        soundManager_get.Click_elastik();
        StartCoroutine(storyDelay_Arm());
    }

    private IEnumerator storyDelay_Arm()
    {
        yield return new WaitForSeconds(7);
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }
}
