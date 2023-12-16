using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (!PlayerPrefs.HasKey("tutorialStartFinished"))
                return;
            Load();
        }
    }

    public void Load()
    {
        tutorialStartFinished = PlayerPrefs.GetInt("tutorialStartFinished") == 1;
        landmarkFinished = PlayerPrefs.GetInt("landmarkFinished") == 1;
    }

    public void Save()
    {
        SetBool("tutorialStartFinished", tutorialStartFinished);
        SetBool("landmarkFinished", landmarkFinished);
    }

    public void Reset()
    {
        tutorialStartFinished = false;
        landmarkFinished = false;
        Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool tutorialStartFinished { get; set;}
    public bool landmarkFinished { get; set;}
}
