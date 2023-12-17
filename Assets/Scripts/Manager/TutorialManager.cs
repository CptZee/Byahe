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
        signFinished = PlayerPrefs.GetInt("signFinished") == 1;
        shopFinished = PlayerPrefs.GetInt("shopFinished") == 1;
    }

    public void Save()
    {
        SetBool("tutorialStartFinished", tutorialStartFinished);
        SetBool("landmarkFinished", landmarkFinished);
        SetBool("signFinished", signFinished);
        SetBool("shopFinished", shopFinished);
    }

    public void Reset()
    {
        tutorialStartFinished = false;
        landmarkFinished = false;
        signFinished = false;
        shopFinished = false;
        Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool tutorialStartFinished { get; set;}
    public bool landmarkFinished { get; set;}
    public bool signFinished { get; set;}
    public bool shopFinished { get; set;}
}
