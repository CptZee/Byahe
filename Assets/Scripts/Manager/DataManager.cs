
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
        Time = PlayerPrefs.GetFloat("Time");
        Knowledge = PlayerPrefs.GetFloat("Knowledge");
        MabiniShop1 = PlayerPrefs.GetInt("MabiniShop1") == 1;
        MabiniShop2 = PlayerPrefs.GetInt("MabiniShop2") == 1;
        MalvarShop1 = PlayerPrefs.GetInt("MalvarShop1") == 1;
        MalvarShop2 = PlayerPrefs.GetInt("MalvarShop2") == 1;
        BauanShop1 = PlayerPrefs.GetInt("BauanShop1") == 1;
        BauanShop2 = PlayerPrefs.GetInt("BauanShop2") == 1;
        SanJoseShop1 = PlayerPrefs.GetInt("SanJoseShop1") == 1;
        SanJoseShop2 = PlayerPrefs.GetInt("SanJoseShop2") == 1;
        LoboShop1 = PlayerPrefs.GetInt("LoboShop1") == 1;
        LoboShop2 = PlayerPrefs.GetInt("LoboShop2") == 1;
        BalayanShop1 = PlayerPrefs.GetInt("BalayanShop1") == 1;
        BalayanShop2 = PlayerPrefs.GetInt("BalayanShop2") == 1;

    }

    public void Reset()
    {
        TravelActor = "Jeepney";
        TourActor = "Kalesa";
        HasTricycle = false;
        HasMulticab = false;
        CurrentScene = "TravelLevel";
        Destination = "Lipa";
        Gas = 100;
        Money = 100;
        Time = 0;
        Income = 0;
        Knowledge = 0;
        MabiniShop1 = false;
        MabiniShop2 = false;
        MalvarShop1 = false;
        MalvarShop2 = false;
        BauanShop1 = false;
        BauanShop2 = false;
        SanJoseShop1 = false;
        SanJoseShop2 = false;
        LoboShop1 = false; 
        LoboShop2 = false; 
        BalayanShop1 = false; 
        BalayanShop2 = false; 

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
        PlayerPrefs.SetFloat("Time", Time);
        PlayerPrefs.SetFloat("Knowledge", Knowledge);
        PlayerPrefs.SetInt("MabiniShop1", MabiniShop1 ? 1 : 0);
        PlayerPrefs.SetInt("MabiniShop2", MabiniShop2 ? 1 : 0);
        PlayerPrefs.SetInt("MalvarShop1", MalvarShop1 ? 1 : 0);
        PlayerPrefs.SetInt("MalvarShop2", MalvarShop2 ? 1 : 0);
        PlayerPrefs.SetInt("BauanShop1", BauanShop1 ? 1 : 0);
        PlayerPrefs.SetInt("BauanShop2", BauanShop2 ? 1 : 0);
        PlayerPrefs.SetInt("SanJoseShop1", SanJoseShop1 ? 1 : 0);
        PlayerPrefs.SetInt("SanJoseShop2", SanJoseShop2 ? 1 : 0);
        PlayerPrefs.SetInt("LoboShop1", LoboShop1 ? 1 : 0);
        PlayerPrefs.SetInt("LoboShop2", LoboShop2 ? 1 : 0);
        PlayerPrefs.SetInt("BalayanShop1", BalayanShop1 ? 1 : 0);
        PlayerPrefs.SetInt("BalayanShop2", BalayanShop2 ? 1 : 0);
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
    public float Time { get; set; }
    public float Knowledge { get; set; }
    public bool MabiniShop1 { get; set; }
    public bool MabiniShop2 { get; set; }
    public bool MalvarShop1 { get; set; }
    public bool MalvarShop2 { get; set; }
    public bool BauanShop1 { get; set; }
    public bool BauanShop2 { get; set; }
    public bool SanJoseShop1 { get; set; }
    public bool SanJoseShop2 { get; set; }
    public bool LoboShop1 { get; set; }
    public bool LoboShop2 { get; set; }
    public bool BalayanShop1 { get; set; }
    public bool BalayanShop2 { get; set; }
}