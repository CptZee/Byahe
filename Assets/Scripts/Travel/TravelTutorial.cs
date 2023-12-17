using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelTutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start()
    {
        if(TutorialManager.instance.travelFinished)
            tutorialPanel.SetActive(false);
    }
}
