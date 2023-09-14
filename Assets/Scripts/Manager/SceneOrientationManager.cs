using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrientationManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TravelLevel")
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
