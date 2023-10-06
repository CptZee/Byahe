using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<GameObject> stations;
    public GameObject maxUpgradePanel;
    public AudioSource audioSource;
    public AudioClip failedAudio;

    private int randomIndex;
    public void UpgradeQuestion()
    {
        if (gameObjects.Count > 0)
        {
            randomIndex = Random.Range(0, gameObjects.Count);
            GameObject randomGameObject = gameObjects[randomIndex];
            randomGameObject.SetActive(true);
            foreach (GameObject station in stations)
                gameObject.SetActive(false);
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
        foreach (GameObject gameObject in gameObjects)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
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
        gameObjects.RemoveAt(randomIndex);
    }

    public void CloseMaxPanel(){
        maxUpgradePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
