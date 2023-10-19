using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
    public GameObject pauseOverlay;
    public LoadingManager loadingManager;
    public Slider musicSlider;
    public Slider audioSlider;
    private SettingsManager settingsManager;
    private DataManager sessionManager;
    public AudioSource musicPlayer;

    void Start()
    {
        settingsManager = SettingsManager.instance;
        sessionManager = DataManager.instance;
        musicSlider.value = settingsManager.MusicLevel;
        audioSlider.value = settingsManager.AudioLevel;
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        audioSlider.onValueChanged.AddListener(OnAudioSliderValueChanged);
    }
    void OnMusicSliderValueChanged(float value)
    {
        settingsManager.MusicLevel = value;
        Debug.Log("Music Slider Value: " + value);
    }
    
    void OnAudioSliderValueChanged(float value)
    {
        settingsManager.AudioLevel = value;
        Debug.Log("Audio Slider Value: " + value);
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseOverlay.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        settingsManager.AudioLevel = audioSlider.value;
        settingsManager.MusicLevel = musicSlider.value;
        settingsManager.Save();
        Time.timeScale = 1;
        pauseOverlay.gameObject.SetActive(false);
    }

    public void Quit(){

        settingsManager.Save();
        sessionManager.Save();
        //Quit Game
        Application.Quit();
    }
}
