using System.Collections.Generic;
using UnityEngine;

public class TourTutorial : MonoBehaviour
{
    public List<GameObject> tutorialUIs;
    public List<GameObject> introUIs;
    public List<GameObject> landmarkUIs;
    public List<GameObject> signUIs;
    public List<GameObject> shopUIs;
    public List<GameObject> gasStationUIs;
    public List<GameObject> terminalUIs;
    public GameObject fadePanel;
    public LoadingManager loadingManager;
    private Attention attentionScript;
    private TutorialManager tutorialManager;
    private Transform playerSprite;
    private List<GameObject> interactables;
    private float minDistance;
    private int introIndex = 0;
    private int landmarkIndex = 0;
    private int signIndex = 0;
    private int shopIndex = 0;
    private int gasStationIndex = 0;
    private int terminalIndex = 0;
    private bool tutorialStartFinished;
    private bool landmarkFinished;
    private bool signFinished;
    private bool shopFinished;
    private bool gasStationFinished;
    private bool terminalFinished;
    public void Start()
    {
        attentionScript = GetComponent<Attention>();
        tutorialManager = TutorialManager.instance;
        playerSprite = attentionScript.playerSprite;
        interactables = attentionScript.interactables;
        minDistance = attentionScript.minDistance;

        SyncTutorialStatus();

        if (!tutorialStartFinished)
        {
            ShowUI(0);
            tutorialManager.Save();
        }
    }

    public void Update()
    {
        if (interactables != null)
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                float distance = Vector3.Distance(playerSprite.position, interactables[i].transform.position);
                if (distance < minDistance)
                {
                    switch (i)
                    {
                        case 0: //Landmark
                            if (!landmarkFinished)
                            {
                                landmarkFinished = true;
                                ShowUI(i + 1);
                                UpdateTutorialStatus();
                            }
                            break;
                        case 1: //Shop 1
                            if (!shopFinished)
                            {
                                Debug.Log("Shop 1");
                                shopFinished = true;
                                ShowUI(i);
                                UpdateTutorialStatus();
                            }
                            break;
                        case 2: //Sign 1
                            if (!signFinished)
                            {
                                Debug.Log("Sign 1");
                                signFinished = true;
                                ShowUI(i);
                                UpdateTutorialStatus();
                            }
                            break;
                        case 5: //Gas Station
                            if (!gasStationFinished)
                            {
                                gasStationFinished = true;
                                ShowUI(i + 1);
                                UpdateTutorialStatus();
                            }
                            break;
                        case 6: //Terminal
                            if (!terminalFinished)
                            {
                                terminalFinished = true;
                                ShowUI(i + 1);
                                UpdateTutorialStatus();
                            }
                            break;
                    }
                }
            }
        }
    }

    private void ShowUI(int index)
    {
        tutorialUIs[index].SetActive(true);
        fadePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void CloseUIs()
    {
        fadePanel.SetActive(false);
        foreach (GameObject ui in tutorialUIs)
        {
            ui.SetActive(false);
        }
        Time.timeScale = 1;
    }


    private void SyncTutorialStatus()
    {
        if (tutorialManager == null)
            return;
        tutorialStartFinished = tutorialManager.tutorialStartFinished;
        landmarkFinished = tutorialManager.landmarkFinished;
        signFinished = tutorialManager.signFinished;
        shopFinished = tutorialManager.shopFinished;
        gasStationFinished = tutorialManager.gasStationFinished;
        terminalFinished = tutorialManager.terminalFinished;
    }

    private void UpdateTutorialStatus()
    {
        if (tutorialManager == null)
            return;
        tutorialManager.tutorialStartFinished = tutorialStartFinished;
        tutorialManager.landmarkFinished = landmarkFinished;
        tutorialManager.signFinished = signFinished;
        tutorialManager.shopFinished = shopFinished;
        tutorialManager.gasStationFinished = gasStationFinished;
        tutorialManager.terminalFinished = terminalFinished;
    }

    public void IntroContinue()
    {
        introIndex += 1;
        if (introIndex == introUIs.Count)
        {
            CloseUIs();
            tutorialManager.tutorialStartFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < introUIs.Count; i++)
        {
            if (introIndex == i)
                introUIs[i].SetActive(true);
            else
                introUIs[i].SetActive(false);
        }
    }

    public void LandmarkContinue()
    {
        landmarkIndex += 1;
        if (landmarkIndex == landmarkUIs.Count)
        {
            CloseUIs();
            tutorialManager.landmarkFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < landmarkUIs.Count; i++)
        {
            if (landmarkIndex == i)
                landmarkUIs[i].SetActive(true);
            else
                landmarkUIs[i].SetActive(false);
        }
    }

    public void SignContinue()
    {
        signIndex += 1;
        if (signIndex == signUIs.Count)
        {
            CloseUIs();
            tutorialManager.signFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < signUIs.Count; i++)
        {
            if (signIndex == i)
                signUIs[i].SetActive(true);
            else
                signUIs[i].SetActive(false);
        }
    }

    public void ShopContinue()
    {
        shopIndex += 1;
        if (shopIndex == shopUIs.Count)
        {
            CloseUIs();
            tutorialManager.shopFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < shopUIs.Count; i++)
        {
            if (shopIndex == i)
                shopUIs[i].SetActive(true);
            else
                shopUIs[i].SetActive(false);
        }
    }

    public void GasStationContinue(){
        gasStationIndex += 1;
        if (gasStationIndex == gasStationUIs.Count)
        {
            CloseUIs();
            tutorialManager.gasStationFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < gasStationUIs.Count; i++)
        {
            if (gasStationIndex == i)
                gasStationUIs[i].SetActive(true);
            else
                gasStationUIs[i].SetActive(false);
        }
    }

    public void TerminalContinue()
    {
        terminalIndex += 1;
        if (terminalIndex == terminalUIs.Count)
        {
            CloseUIs();
            tutorialManager.terminalFinished = true;
            tutorialManager.Save();
        }
        for (int i = 0; i < terminalUIs.Count; i++)
        {
            if (terminalIndex == i)
                terminalUIs[i].SetActive(true);
            else
                terminalUIs[i].SetActive(false);
        }
    }

    public void GoToMainMenu()
    {
        CloseUIs();
        ScoreManager.instance.Reset();
        tutorialManager.Reset();
        tutorialManager.Save();
        loadingManager.LoadScene("Main Menu");
    }
}