using UnityEngine;
using UnityEngine.UI;

public class TravelPhaseInit : MonoBehaviour
{
    public Slider gasSlider;
    public GameObject tutorialScreen;
    private DataManager datamanager;
    private ScoreManager scoreManager;
    void Start()
    {
        datamanager = DataManager.instance;
        scoreManager = ScoreManager.instance;
        gasSlider.maxValue = datamanager.Gas;
        if (!scoreManager.prologueFinished)
        {
            Time.timeScale = 0;
            tutorialScreen.SetActive(true);
        }
        else
            tutorialScreen.SetActive(false);
    }

    public void CloseTutorialScreen()
    {
        scoreManager.SetBool("prologueFinished", true);
        TutorialManager.instance.travelFinished = true;
        TutorialManager.instance.Save();
        Time.timeScale = 1;
        tutorialScreen.SetActive(false);
    }
}
