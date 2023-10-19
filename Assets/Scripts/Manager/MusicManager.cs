using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;
    public AudioClip musicClip;
    private SettingsManager settingsManager;
    void Start(){
        settingsManager = SettingsManager.instance;
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;
        PlayMusic();
    }

    void Update(){
        musicSource.volume = settingsManager.MusicLevel;
    }
    
    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
