using System.Collections.Generic;
using UnityEngine;

public class TourTutorial : MonoBehaviour
{
    public List<GameObject> tutorialUIs;
    private Attention attentionScript;
    private TutorialManager tutorialManager;
    private Transform playerSprite;
    private List<GameObject> interactables;
    private float minDistance;
    public void Start()
    {
        attentionScript = GetComponent<Attention>();
        tutorialManager = TutorialManager.instance;
        playerSprite = attentionScript.playerSprite;
        interactables = attentionScript.interactables;
        minDistance = attentionScript.minDistance;

        if (!tutorialManager.tutorialStartFinished)
        {
            tutorialManager.tutorialStartFinished = true;
            tutorialManager.Save();
            tutorialUIs[0].SetActive(true);
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
                                tutorialManager.landmarkFinished = true;
                                tutorialUIs[1].SetActive(true);
                                Time.timeScale = 1;
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

    public void CloseUIs()
    {
        foreach (GameObject ui in tutorialUIs)
        {
            ui.SetActive(false);
        }
        Time.timeScale = 0;
    }
}