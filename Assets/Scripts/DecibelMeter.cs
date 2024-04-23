using UnityEngine;
using UnityEngine.Android;
using System.Collections;

public class DecibelMeter : MonoBehaviour
{
    private AudioClip recordedClip;
    private AudioSource audioSource;
    private bool isRecording = false;

    IEnumerator Start()
    {
        // Check if a microphone is available
        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("No microphone detected.");
            yield break;
        }

        // Request and check microphone permissions
        RequestMicrophonePermission();
        yield return StartCoroutine(WaitForMicrophonePermission());

        Debug.Log("Microphone access granted.");

        // Add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Wait for a short delay before proceeding
        yield return new WaitForSeconds(1);

        // Start recording
        StartRecording();
    }

    void RequestMicrophonePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    IEnumerator WaitForMicrophonePermission()
    {
        // Wait until the user grants or denies permission
        while (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            yield return null;
        }
    }

    // Start recording audio (changed to public)
    public void StartRecording()
    {
        if (Microphone.IsRecording(null))
        {
            Debug.LogWarning("Already recording.");
            return;
        }

        Debug.LogWarning("Recording Started");

        int frequency = 44100; // Sample rate
        int seconds = 10; // Maximum recording duration

        recordedClip = Microphone.Start(null, true, seconds, frequency);
        isRecording = true;
    }

    // Stop recording audio
    public void StopRecording()
    {
        if (Microphone.IsRecording(null))
        {
            Debug.LogWarning("Recording stopped");

            Microphone.End(null);
            isRecording = false;
        }
        else
        {
            Debug.LogWarning("Not currently recording.");
        }
    }

    public void PlayRecording()
    {
        // Play the recorded audio if it's not already playing
        if (!audioSource.isPlaying)
        {

            Debug.LogWarning("Recording Playing");

            audioSource.clip = recordedClip;
            audioSource.Play();
        }
    }


    // Get the current decibel level and play the recorded audio
    public float GetDecibelLevel()
    {
        if (isRecording && recordedClip != null)
        {
            float[] samples = new float[recordedClip.samples * recordedClip.channels];
            recordedClip.GetData(samples, 0);

            float sum = 0f;

            foreach (float sample in samples)
            {
                sum += Mathf.Abs(sample);
            }

            // Calculate average amplitude
            float averageAmplitude = sum / samples.Length;

            // Convert average amplitude to decibels
            float dbValue = 20 * Mathf.Log10(averageAmplitude + Mathf.Epsilon);  // Add epsilon to prevent log of zero

            // Play the recorded audio if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = recordedClip;
                audioSource.Play();
            }

            return dbValue;
        }

        return 0f; // Return 0 if not recording or no recorded audio
    }
}