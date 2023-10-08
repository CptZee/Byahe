using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenuScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource sfxSource;
    public AudioClip openClip;
    public GameObject newGamePanel;
    public DataManager dataManager;
    public GameObject tutorialPanel;
    void Start()
    {
        // Locate the GameObject with the AudioSource component
        GameObject musicPlayer = GameObject.Find("MainMusic");
        if (musicPlayer != null)
            audioSource = musicPlayer.GetComponent<AudioSource>();
        else
            Debug.LogError("MusicPlayer GameObject not found.");

        GameObject orientationManager = new GameObject("SceneOrientationManager");
        orientationManager.AddComponent<SceneOrientationManager>();
        DontDestroyOnLoad(orientationManager);
    }

    public void ShowTutorial(){
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

    public void NewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        dataManager.TravelActor = "Jeepney";
        dataManager.TourActor = "Kalesa";
        dataManager.CurrentScene = "TravelLevel";
        dataManager.Destination = "Mabini";
        dataManager.Gas = 100;
        dataManager.Money = 25;
        dataManager.Income = 0;
        dataManager.Knowledge = 0;
        dataManager.MabiniShop1 = false;
        dataManager.MabiniShop2 = false;
        SaveData();
    }

    public void CloseNewGameUI(){
        newGamePanel.SetActive(false);
    }

    public void ContinueGame()
    {
        Debug.Log("Continuing Game");
        LoadData();
        if (!PlayerPrefs.HasKey("CurrentScene"))
        {
            PlayGame();
            return;
        }
        StartCoroutine(LoadSceneRoutine());
    }
    private IEnumerator LoadSceneRoutine()
    {

        AsyncOperation task = SceneManager.LoadSceneAsync(dataManager.CurrentScene);
        float elapsedLoadTime = 0f;

        while (!task.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (elapsedLoadTime < 3)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetString("TravelActor", dataManager.TravelActor);
        PlayerPrefs.SetString("TourActor", dataManager.TourActor);
        PlayerPrefs.SetString("CurrentScene", dataManager.CurrentScene);
        PlayerPrefs.SetString("Destination", dataManager.Destination);
        PlayerPrefs.SetFloat("Gas", dataManager.Gas);
        PlayerPrefs.SetFloat("Money", dataManager.Money);
        PlayerPrefs.SetFloat("Income", dataManager.Income);
        PlayerPrefs.SetFloat("Knowledge", dataManager.Knowledge);
        PlayerPrefs.SetInt("MabiniShop1", dataManager.MabiniShop1 ? 1 : 0);
        PlayerPrefs.SetInt("MabiniShop2", dataManager.MabiniShop2 ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Money: " + PlayerPrefs.GetFloat("Money"));
        Debug.Log("Money: " + PlayerPrefs.GetInt("Money"));
    }

    void LoadData()
    {
        dataManager.CurrentScene = PlayerPrefs.GetString("CurrentScene");
        dataManager.Destination = PlayerPrefs.GetString("Destination");
        dataManager.Gas = PlayerPrefs.GetFloat("Gas");
        dataManager.Money = PlayerPrefs.GetFloat("Money");
        dataManager.MabiniShop1 = PlayerPrefs.GetInt("MabiniShop1") == 1 ? true : false;
        dataManager.MabiniShop2 = PlayerPrefs.GetInt("MabiniShop2") == 1 ? true : false;
    }

    public void ExitGame()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
