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
        travelFinished = PlayerPrefs.GetInt("travelFinished") == 1;
        tutorialStartFinished = PlayerPrefs.GetInt("tutorialStartFinished") == 1;
        landmarkFinished = PlayerPrefs.GetInt("landmarkFinished") == 1;
        signFinished = PlayerPrefs.GetInt("signFinished") == 1;
        shopFinished = PlayerPrefs.GetInt("shopFinished") == 1;
        gasStationFinished = PlayerPrefs.GetInt("gasStationFinished") == 1;
        terminalFinished = PlayerPrefs.GetInt("terminalFinished") == 1;
    }

    public void Save()
    {
        SetBool("travelFinished", travelFinished);
        SetBool("tutorialStartFinished", tutorialStartFinished);
        SetBool("landmarkFinished", landmarkFinished);
        SetBool("signFinished", signFinished);
        SetBool("gasStationFinished", gasStationFinished);
        SetBool("terminalFinished", terminalFinished);
    }

    public void Reset()
    {
        tutorialStartFinished = false;
        travelFinished = false;
        landmarkFinished = false;
        signFinished = false;
        shopFinished = false;
        gasStationFinished = false;
        terminalFinished = false;
        Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }
    public bool travelFinished { get; set; }
    public bool tutorialStartFinished { get; set; }
    public bool landmarkFinished { get; set; }
    public bool signFinished { get; set; }
    public bool shopFinished { get; set; }
    public bool gasStationFinished { get; set; }
    public bool terminalFinished { get; set; }
}
