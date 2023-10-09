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
        dataManager.Reset();
    }

    public void CloseNewGameUI(){
        newGamePanel.SetActive(false);
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

    public void ExitGame()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
