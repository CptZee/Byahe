using System.Collections.Generic;
using UnityEngine;

public class TourTutorial : MonoBehaviour
{
    public List<GameObject> tutorialUIs;
    public List<GameObject> introUIs;
    public GameObject fadePanel;
    private Attention attentionScript;
    private TutorialManager tutorialManager;
    private Transform playerSprite;
    private List<GameObject> interactables;
    private float minDistance;
    private int introIndex = 0;
    public void Start()
    {
        attentionScript = GetComponent<Attention>();
        tutorialManager = TutorialManager.instance;
        playerSprite = attentionScript.playerSprite;
        interactables = attentionScript.interactables;
        minDistance = attentionScript.minDistance;

        //DEBUG CODE
        ShowUI(0);
        //DEBUG CODE

        if (!tutorialManager.tutorialStartFinished)
        {
            tutorialManager.tutorialStartFinished = true;
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
                            if (!tutorialManager.landmarkFinished)
                            {
                                //tutorialManager.landmarkFinished = true;
                                ShowUI(1);
                                tutorialManager.Save();
                            }
                            break;
                        case 1: //Shop 1

                            break;
                        case 2: //Sign 1

                            break;
                        case 3: //Shop 2

                            break;
                        case 4: //Sign 2

                            break;
                        case 5: //Gas Station

                            break;
                        case 6: //Terminal

                            break;
                    }
                }
            }
        }
    }

    public void ShowUI(int index)
    {
        tutorialUIs[index].SetActive(true);
        fadePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUIs()
    {
        fadePanel.SetActive(false);
        foreach (GameObject ui in tutorialUIs)
        {
            ui.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void IntroContinue()
    {
        introIndex += 1;
        if (introIndex == introUIs.Count)
            CloseUIs();
        for (int i = 0; i < introUIs.Count; i++)
        {
            if (introIndex == i)
                introUIs[i].SetActive(true);
            else
                introUIs[i].SetActive(false);
        }
    }
}