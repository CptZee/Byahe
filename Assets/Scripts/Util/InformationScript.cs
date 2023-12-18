using System.Collections.Generic;
using UnityEngine;

public class InformationScript : MonoBehaviour
{
    public List<GameObject> informations;
    public GameObject informationPanel;
    public GameObject controls;
    private int currentInformationIndex = 0;

    public void NextInformation()
    {
        if (currentInformationIndex < informations.Count - 1)
            currentInformationIndex++;
        else
            currentInformationIndex = 0;
        foreach (GameObject information in informations)
            information.SetActive(false);
        informations[currentInformationIndex].SetActive(true);
    }

    public void PreviousInformation()
    {
        if (currentInformationIndex > 0)
            currentInformationIndex--;
        else
            currentInformationIndex = informations.Count - 1;
        foreach (GameObject information in informations)
            information.SetActive(false);
        informations[currentInformationIndex].SetActive(true);
    }

    public void CloseInformation()
    {
        informationPanel.SetActive(false);
        Time.timeScale = 1;
        if (controls != null)
            controls.SetActive(true);
    }
}
