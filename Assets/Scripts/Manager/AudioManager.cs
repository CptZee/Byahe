using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    private SettingsManager settingsManager;
    void Start()
    {
        settingsManager = SettingsManager.instance;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = settingsManager.AudioLevel;
        audioSource.loop = false;
    }

    public void PlayAudio(int index)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
