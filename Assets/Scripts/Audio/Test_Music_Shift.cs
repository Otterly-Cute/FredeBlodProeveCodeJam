using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_Music_Shift : MonoBehaviour
{
    public void front()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(10);
    }
}
