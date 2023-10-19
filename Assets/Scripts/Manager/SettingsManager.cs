using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (!PlayerPrefs.HasKey("MusicLevel") || !PlayerPrefs.HasKey("AudioLevel"))
            {
                Reset();
            }
            Load();
        }
    }

    void Load()
    {
        MusicLevel = PlayerPrefs.GetFloat("MusicLevel");
        AudioLevel = PlayerPrefs.GetFloat("AudioLevel");
    }

    public void Reset()
    {
        MusicLevel = 100;
        AudioLevel = 100;

        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicLevel", MusicLevel);
        PlayerPrefs.SetFloat("AudioLevel", AudioLevel);
        PlayerPrefs.Save();
    }

    public float MusicLevel { get; set; }
    public float AudioLevel { get; set; }
}
