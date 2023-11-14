
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (!PlayerPrefs.HasKey("CurrentScene"))
                return;
            Load();
        }
    }

    public void Load()
    {
        TravelActor = PlayerPrefs.GetString("TravelActor");
        TourActor = PlayerPrefs.GetString("TourActor");
        HasTricycle = PlayerPrefs.GetInt("HasTricycle") == 1;
        HasMulticab = PlayerPrefs.GetInt("HasMulticab") == 1;
        CurrentScene = PlayerPrefs.GetString("CurrentScene");
        Destination = PlayerPrefs.GetString("Destination");
        Gas = PlayerPrefs.GetFloat("Gas");
        Money = PlayerPrefs.GetFloat("Money");
        Income = PlayerPrefs.GetFloat("Income");
        Knowledge = PlayerPrefs.GetFloat("Knowledge");
        MabiniShop1 = PlayerPrefs.GetInt("MabiniShop1") == 1;
        MabiniShop2 = PlayerPrefs.GetInt("MabiniShop2") == 1;
    }

    public void Reset()
    {
        TravelActor = "Jeepney";
        TourActor = "Kalesa";
        HasTricycle = false;
        HasMulticab = false;
        CurrentScene = "TravelLevel";
        Destination = "Mabini";
        Gas = 100;
        Money = 50;
        Income = 0;
        Knowledge = 0;
        MabiniShop1 = false;
        MabiniShop2 = false;

        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString("TravelActor", TravelActor);
        PlayerPrefs.SetString("TourActor", TourActor);
        PlayerPrefs.SetInt("HasTricycle", HasTricycle ? 1 : 0);
        PlayerPrefs.SetInt("HasMulticab", HasMulticab ? 1 : 0);
        PlayerPrefs.SetString("CurrentScene", CurrentScene);
        PlayerPrefs.SetString("Destination", Destination);
        PlayerPrefs.SetFloat("Gas", Gas);
        PlayerPrefs.SetFloat("Money", Money);
        PlayerPrefs.SetFloat("Income", Income);
        PlayerPrefs.SetFloat("Knowledge", Knowledge);
        PlayerPrefs.SetInt("MabiniShop1", MabiniShop1 ? 1 : 0);
        PlayerPrefs.SetInt("MabiniShop2", MabiniShop2 ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public string TravelActor { get; set; }
    public string TourActor { get; set; }
    public bool HasTricycle { get; set; }
    public bool HasMulticab { get; set; }
    public string CurrentScene { get; set; }
    public string Destination { get; set; }
    public float Gas { get; set; }
    public float Money { get; set; }
    public float Income { get; set; }
    public float Knowledge { get; set; }
    public bool MabiniShop1 { get; set; }
    public bool MabiniShop2 { get; set; }
}