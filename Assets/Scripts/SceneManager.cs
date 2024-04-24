using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    // PREFACE: scriptet assumer at den første scene er den med index 0 (main menu formentligt) -
    // hvis det er ikke, så skal vi lige ændre nogle ting.
    private int _currentSceneIndex = 0;
    private int _nextSceneIndex = 0;
    
    public UnityEngine.UI.Text loadingText;

    // dont mind de lange parametrer, det er basically bare en måde at få fat i scenenavnet fra indexen.
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // når den her bliver called så skifter den til næste scene baseret på den nuværende scenes index.
    // virker også når vi er i mini games, da de bliver called seperat fra main scenes.
    public void LoadNextMainScene() 
    {
        _nextSceneIndex = (_currentSceneIndex + 1) % UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

        if (_nextSceneIndex == 0) {
            Debug.LogWarning("No more scenes to load.");;
            return;
        }
        
        _currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LoadScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(_nextSceneIndex).name);
    }

    // det der faktisk ændrer scenen - en af dem her skal vi call med mini game navnene når vi når dertil.
    public void LoadScene(string sceneName) => StartCoroutine(LoadSceneAsync(sceneName));

    public void LoadScene(int sceneIndex) => StartCoroutine(LoadSceneAsync(sceneIndex));

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        LoadLoadingScene();
        yield return null;

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress:" + asyncLoad.progress);
            loadingText.text = "Loading progress: " + (asyncLoad.progress * 100).ToString("0.00") + "%";
            yield return null;
        }

        UnityEngine.SceneManagement.Scene LoadedScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName);
        UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(this.gameObject, LoadedScene);
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        LoadLoadingScene();
        yield return null;

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress:" + asyncLoad.progress);
            loadingText.text = "Loading progress: " + (asyncLoad.progress * 100).ToString("0.00") + "%";
            yield return null;
        }

        UnityEngine.SceneManagement.Scene LoadedScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(sceneIndex);
        UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(this.gameObject, LoadedScene);
    }

    private void LoadLoadingScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
        StartCoroutine(FindLoadingText());
    }

    private IEnumerator FindLoadingText()
    {
        yield return null; // Wait for one frame to ensure the loading scene is loaded

        loadingText = GameObject.Find("LoadingText").GetComponent<UnityEngine.UI.Text>();
    }
}