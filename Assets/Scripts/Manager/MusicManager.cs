using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;
    public AudioClip musicClip;
    void Start(){
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;
        PlayMusic();
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
