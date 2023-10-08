
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
            TravelActor = PlayerPrefs.GetString("TravelActor");
            TourActor = PlayerPrefs.GetString("TourActor");
            CurrentScene = PlayerPrefs.GetString("CurrentScene");
            Destination = PlayerPrefs.GetString("Destination");
            Gas = PlayerPrefs.GetFloat("Gas");
            Money = PlayerPrefs.GetFloat("Money");
            Income = PlayerPrefs.GetFloat("Income");
            Knowledge = PlayerPrefs.GetFloat("Knowledge");
            MabiniShop1 = PlayerPrefs.GetInt("MabiniShop1") == 1;
            MabiniShop2 = PlayerPrefs.GetInt("MabiniShop2") == 1;
        }
    }
    public string TravelActor {get; set;}
    public string TourActor {get; set;}

    public string CurrentScene { get; set; }
    public string Destination { get; set; }
    public float Gas { get; set; }
    public float Money { get; set; }
    public float Income {get; set; }
    public float Knowledge {get; set;}
    public bool MabiniShop1 { get; set; }
    public bool MabiniShop2 { get; set; }
}