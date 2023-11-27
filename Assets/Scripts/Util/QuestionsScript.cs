using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : MonoBehaviour
{
    public List<GameObject> questions;
    public List<GameObject> stations;
    public GameObject maxUpgradePanel;
    public GameObject succcessPanel;
    public GameObject failedPanel;
    public AudioSource audioSource;
    public AudioClip failedAudio;
    public AudioClip successAudio;
    public GameObject controls;

    private int randomIndex;
    public void UpgradeQuestion()
    {
        foreach (GameObject ignored in stations)
            gameObject.SetActive(false);
        if (questions.Count > 0)
        {
            randomIndex = Random.Range(0, questions.Count);
            GameObject randomGameObject = questions[randomIndex];
            randomGameObject.SetActive(true);
        }
        else
        {
            maxUpgradePanel.SetActive(true);
        }
    }

    public void CloseQuestions()
    {
        controls.SetActive(true);
        failedPanel.SetActive(false);
        if (succcessPanel.activeSelf)
        {
            RemoveQuestion();
        }
        foreach (GameObject gameObject in questions)
        {
            gameObject.SetActive(false);
        }
        succcessPanel.SetActive(false);
        if (questions[randomIndex].activeSelf)
            questions[randomIndex].SetActive(false);
        Time.timeScale = 1;
    }

    public void CorrectAnswer()
    {
        audioSource.clip = successAudio;
        audioSource.Play();
        DataManager.instance.Money += 5; //TODO: Tweak this later yeah?
        DataManager.instance.Income += 0.1f; //TODO: Tweak this later yeah?
        DataManager.instance.Knowledge += 1;
        PlayerPrefs.SetFloat("Income", DataManager.instance.Income);
        PlayerPrefs.SetFloat("Knowledge", DataManager.instance.Knowledge);
        PlayerPrefs.Save();
        succcessPanel.SetActive(true);
    }

    public void WrongAnswer()
    {
        audioSource.clip = failedAudio;
        audioSource.Play();
        failedPanel.SetActive(true);
    }

    public void RemoveQuestion()
    {
        GameObject obj = questions[randomIndex];
        if (obj.activeSelf)
        {
            questions.RemoveAt(randomIndex);
            obj.SetActive(false);
        }
    }

    public void CloseMaxPanel()
    {
        maxUpgradePanel.SetActive(false);
        Time.timeScale = 1;
        controls.SetActive(true);
    }
}
