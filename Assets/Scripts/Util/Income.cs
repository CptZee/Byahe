using UnityEngine;

public class Income : MonoBehaviour
{
    private DataManager dataManager;
    public float incomeInterval = 15f;
    private static Income instance;
    public static Income Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Income>();
                if (instance == null)
                {
                    Debug.LogError("Income instance is missing in the scene.");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("AddIncome", incomeInterval, incomeInterval);
    }

    private void AddIncome()
    {
        dataManager = DataManager.instance;
        if(dataManager.Income == 0)
            return;
        dataManager.Money += dataManager.Income;
        PlayerPrefs.SetFloat("Money", dataManager.Money);
        PlayerPrefs.Save();
        Debug.Log("Added income. Current money: " + dataManager.Money);
    }
}
