using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationHandler : MonoBehaviour
{
    public LoadingManager loadingManager;
    private DataManager manager;
    public void LoadDestination(string destination)
    {
        manager = DataManager.instance;
        SetNewHighscore(destination);
        manager.Destination = destination;
        manager.CurrentScene = "TravelLevel";
        loadingManager.LoadScene(manager.CurrentScene);
    }
    public void LoadDestinationForMabini(string destination)
    {
        manager = DataManager.instance;
        SetNewHighscore(destination);
        if (manager.Knowledge > 10)
        {
            LoadDestination(destination);
            return;
        }
        manager.Destination = destination;
        manager.CurrentScene = "TravelLevel";
        loadingManager.LoadScene("MabiniEpilogue");
    }

    private void SetNewHighscore(string destination)
    {
        ScoreManager scoreManager = ScoreManager.instance;
        switch (destination)
        {
            case "Mabini":
                if (scoreManager.mabiniTime < manager.Time)
                    scoreManager.mabiniTime = manager.Time;
                break;
            case "Malvar":
                if (scoreManager.malvarTime < manager.Time)
                    scoreManager.malvarTime = manager.Time;
                break;
            case "Bauan":
                if (scoreManager.bauanTime < manager.Time)
                    scoreManager.bauanTime = manager.Time;
                break;
            case "San Jose":
                if (scoreManager.sanJoseTime < manager.Time)
                    scoreManager.sanJoseTime = manager.Time;
                break;
            case "Lobo":
                if (scoreManager.loboTime < manager.Time)
                    scoreManager.loboTime = manager.Time;
                break;
            case "Balayan":
                if (scoreManager.balayanTime < manager.Time)
                    scoreManager.balayanTime = manager.Time;
                break;
        }

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (scoreManager.tutorialTime != float.MaxValue)
            scoreManager.tutorialTime = manager.Time;
        if (currentSceneName == "Lipa" && manager.Time < scoreManager.tutorialTime)
            scoreManager.tutorialTime = manager.Time;
        Debug.Log($"Tutorial Time: {scoreManager.tutorialTime}");
        scoreManager.Save();
    }
}
