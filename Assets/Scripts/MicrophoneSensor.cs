using UnityEngine;
using UnityEngine.Android;
using System.Collections;
using UnityEngine.UI;

public class MicrophoneSensor : MonoBehaviour
{
    //https://forum.unity.com/threads/microphone-input-not-working-on-android.1430533/
    private AudioSource audioSource;

    //https://www.youtube.com/watch?v=dzD0qP8viLw
    private AudioClip microphoneClip;
    public int sampleWindow = 64;

    /// <summary>
    /// Using IEnumerator because of coroutine
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {   
        if (Microphone.devices.Length == 0) // Check if a microphone is available
        {
            Debug.LogError("No microphone detected.");
            yield break;
        }

        RequestMicrophonePermission();// Request and check microphone permissions
        yield return StartCoroutine(WaitForMicrophonePermission()); //wait for permission

        Debug.Log("Microphone access granted.");

        audioSource = gameObject.AddComponent<AudioSource>();// Add an AudioSource component to this GameObject
        
        yield return new WaitForSeconds(1);// Wait for a short delay before proceeding

        MicrophoneToAudioClip(); // turns microphone clip into audioclip
    }

    /// <summary>
    /// https://www.youtube.com/watch?v=dzD0qP8viLw
    /// turns microphoneclip into audioclip
    /// </summary>
    public void MicrophoneToAudioClip()
    {
        int frequency = 44100; // Sample rate
        int seconds = 10; // Maximum recording duration

        microphoneClip = Microphone.Start(null, true, seconds, frequency);
    }

     /// <summary>
     /// using GetDecibelFromAudioClip and uses microphoneclip instead
     /// </summary>
     /// <returns></returns>
   public float GetDecibelFromMicrophone()
    {
        return GetDecibelFromAudioClip(Microphone.GetPosition(null), microphoneClip);
    }

    /// <summary>
    /// returns the decibel level from the audioclip
    /// </summary>
    /// <param name="clipPosition"></param>
    /// <param name="clip"></param>
    /// <returns></returns>
    public float GetDecibelFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0) //if startposition is negative we would get an error
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalDecibel = 0; //compute how loud it is

        for (int i = 0; i < sampleWindow; i++)  //calculating the mean value (can be done other ways than using the mean)
        {
            totalDecibel += Mathf.Abs(waveData[1]);
        }

        return totalDecibel / sampleWindow;
    }

    /// <summary>
    /// first time app is opened, microphone access is requested
    /// https://forum.unity.com/threads/microphone-input-not-working-on-android.1430533/
    /// </summary>
    void RequestMicrophonePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    /// <summary>
    /// Wait until the user grants or denies permission
    /// https://forum.unity.com/threads/microphone-input-not-working-on-android.1430533/
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForMicrophonePermission()
    {
        while (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            yield return null;
        }
    }
}