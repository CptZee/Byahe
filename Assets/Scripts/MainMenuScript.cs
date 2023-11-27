using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource sfxSource;
    public AudioClip openClip;
    public GameObject newGamePanel;
    public DataManager dataManager;
    public GameObject tutorialPanel;
    public GameObject settingsUI;
    public GameObject aboutUsPanel;
    public Slider musicSlider;
    public Slider audioSlider;
    private SettingsManager settingsManager;
    public AudioSource musicPlayer;
    public LoadingManager loadingManager;
    void Start()
    {
        settingsManager = SettingsManager.instance;
        musicSlider.value = settingsManager.MusicLevel;
        audioSlider.value = settingsManager.AudioLevel;
        if (musicPlayer != null)
            audioSource = musicPlayer.GetComponent<AudioSource>();
        else
            Debug.LogError("MusicPlayer GameObject not found.");

        GameObject orientationManager = new GameObject("SceneOrientationManager");
        orientationManager.AddComponent<SceneOrientationManager>();
        DontDestroyOnLoad(orientationManager);
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        audioSlider.onValueChanged.AddListener(OnAudioSliderValueChanged);
    }

    void Update(){
        musicPlayer.volume = settingsManager.MusicLevel;
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

    public void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void PlayGame()
    {
        Debug.Log("Starting a new Game");
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            newGamePanel.SetActive(true);
            sfxSource.clip = openClip;
            sfxSource.Play();
            return;
        }
        NewGame();
    }

    public void NewGame()
    {
        loadingManager.LoadScene("Prologue");
        dataManager.Reset();
    }

    public void ShowAboutUs()
    {
        aboutUsPanel.SetActive(true);
    }
    public void showSettingsUI()
    {
        settingsUI.SetActive(true);
    }

    public void CloseAboutUS()
    {
        aboutUsPanel.SetActive(false);
    }

    public void CloseNewGameUI()
    {
        newGamePanel.SetActive(false);
    }

    public void CloseSettingsUI()
    {
        settingsUI.SetActive(false);
    }

    public void ContinueGame()
    {
        Debug.Log("Continuing Game");
        dataManager.Load();
        if (!PlayerPrefs.HasKey("CurrentScene"))
        {
            PlayGame();
            return;
        }
        loadingManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }

    public void ExitGame()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
