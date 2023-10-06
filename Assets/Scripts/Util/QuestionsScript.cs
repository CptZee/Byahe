using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : MonoBehaviour
{
    public List<GameObject> questions;
    public List<GameObject> stations;
    public GameObject maxUpgradePanel;
    public AudioSource audioSource;
    public AudioClip failedAudio;
    public AudioClip successAudio;
    public GameObject controls;

    private int randomIndex;
    public void UpgradeQuestion()
    {
        foreach (GameObject station in stations)
            gameObject.SetActive(false);
        if (questions.Count > 0)
        {
            randomIndex = Random.Range(0, questions.Count);
            GameObject randomGameObject = questions[randomIndex];
            randomGameObject.SetActive(true);
            Debug.Log("Randomly selected GameObject: " + randomGameObject.name);
        }
        else
        {
            Debug.LogWarning("Max upgrade reached");
            maxUpgradePanel.SetActive(true);
        }
    }

    public void CloseQuestions()
    {
        foreach (GameObject gameObject in questions)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
        controls.SetActive(true);
    }

    public void CorrectAnswer()
    {
        Debug.Log("Correct answer");
        audioSource.clip = successAudio;
        audioSource.Play();
        DataManager.instance.Money += 2; //TODO: Tweak this later yeah?
        DataManager.instance.Income += 0.1f; //TODO: Tweak this later yeah?
        DataManager.instance.Knowledge += 1;
        PlayerPrefs.SetFloat("Income", DataManager.instance.Income);
        PlayerPrefs.SetFloat("Knowledge", DataManager.instance.Knowledge);
        RemoveQuestion();
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong answer");
        audioSource.clip = failedAudio;
        audioSource.Play();
        CloseQuestions();
    }

    public void RemoveQuestion()
    {
        CloseQuestions();
        questions.RemoveAt(randomIndex);
    }

    public void CloseMaxPanel()
    {
        maxUpgradePanel.SetActive(false);
        Time.timeScale = 1;
        controls.SetActive(true);
    }
}
