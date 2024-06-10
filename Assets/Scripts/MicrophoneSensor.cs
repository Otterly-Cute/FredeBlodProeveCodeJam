using UnityEngine;
using UnityEngine.Android;
using System.Collections;

public class MicrophoneSensor : MonoBehaviour
{
    AudioClip microphoneClip;
    public int sampleWindow = 64;
    const int frequency = 44100; // Sample rate
    const int seconds = 10; // Maximum recording duration

    /// <summary>
    /// Using IEnumerator because of coroutine
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        if (Microphone.devices.Length == 0) // Checks if a microphone is available
        {
            Debug.LogError("No microphone detected.");
            yield break;
        }

        //doesn't work as intended(if denied twice, no more requests will appear = you're stuck)
        while (!Permission.HasUserAuthorizedPermission(Permission.Microphone)) //check for microphone access
        {
            // https://forum.unity.com/threads/microphone-input-not-working-on-android.1430533/
            Permission.RequestUserPermission(Permission.Microphone); //requests microphone access
            yield return StartCoroutine(WaitForMicrophonePermission()); //wait for permission
        }

        Debug.Log("Microphone access granted.");

        MicrophoneToAudioClip(); // turns microphone clip into audioclip
    }

    /// <summary>
    /// https://www.youtube.com/watch?v=dzD0qP8viLw
    /// turns microphoneclip into audioclip
    /// </summary>
    public void MicrophoneToAudioClip()
    {
        microphoneClip = Microphone.Start(null, true, seconds, frequency);
    }

     /// <summary>
     /// using GetDecibelFromAudioClip to return decibel level from microphoneclip instead
     /// </summary>
     /// <returns></returns>
   public float GetDecibelFromMicrophone()
    {
        return GetDecibelFromAudioClip(Microphone.GetPosition(null), microphoneClip);
    }

    /// <summary>
    /// returns the decibel level from the audioclip
    /// https://www.youtube.com/watch?v=dzD0qP8viLw
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

        for (int i = 0; i < sampleWindow; i++)  //calculating the mean value
        {
            totalDecibel += Mathf.Abs(waveData[1]);
        }

        return totalDecibel / sampleWindow;
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