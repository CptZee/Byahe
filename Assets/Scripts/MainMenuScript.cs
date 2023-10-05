using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource audioSource;
    public DataManager dataManager;
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

    public void PlayGame()
    {
        Debug.Log("Starting a new Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        dataManager.CurrentScene = "TravelLevel";
        dataManager.Destination = "Mabini";
        dataManager.Gas = 100;
        dataManager.Money = 25;
        saveData();
    }
    void saveData(){
        PlayerPrefs.SetString("CurrentScene", dataManager.CurrentScene);
        PlayerPrefs.SetString("Destination", dataManager.Destination);
        PlayerPrefs.SetFloat("Gas", dataManager.Gas);
        PlayerPrefs.SetFloat("Money", dataManager.Money);
        PlayerPrefs.SetInt("MabiniShop1", dataManager.MabiniShop1 ? 1 : 0);
        PlayerPrefs.SetInt("MabiniShop2", dataManager.MabiniShop2 ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ExitGame()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
