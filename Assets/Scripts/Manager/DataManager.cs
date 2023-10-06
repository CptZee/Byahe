
using UnityEngine;

public class DataManager: MonoBehaviour
{
    public static DataManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if(!PlayerPrefs.HasKey("CurrentScene"))
                return;
            CurrentScene = PlayerPrefs.GetString("CurrentScene");
            Destination = PlayerPrefs.GetString("Destination");
            Gas = PlayerPrefs.GetFloat("Gas");
            Money = PlayerPrefs.GetFloat("Money");
            Income = PlayerPrefs.GetFloat("Money");
            MabiniShop1 = PlayerPrefs.GetInt("MabiniShop1") == 1;
            MabiniShop2 = PlayerPrefs.GetInt("MabiniShop2") == 1;
        }
    }

    public string CurrentScene { get; set; }
    public string Destination { get; set; }
    public float Gas { get; set; }
    public float Money { get; set; }
    public float Income {get; set; }
    public bool MabiniShop1 { get; set; }
    public bool MabiniShop2 { get; set; }
}