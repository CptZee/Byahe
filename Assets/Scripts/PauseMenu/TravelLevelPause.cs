using UnityEngine;

public class TravelLevelPause : MonoBehaviour
{
    
    public GameObject pauseOverlay;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseOverlay.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseOverlay.gameObject.SetActive(false);
    }
}
