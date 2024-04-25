using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=YMj2qPq9CP8

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true); // vi kan bruge samme koncept her til en transitionary skærm

        // vi skal nok også sætte noget op som deaktiverer den, men det burde være ret lige til når det er

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f); // .9 er fordi at unity loader kun
            // til 90%, de sidste 10% er for at slette alt i forrig scene - de kan vi ikke vise.

            slider.value = progress; // behøves ikke medmindre vi vil have en progress bar

            yield return null;
        }
    }
}
