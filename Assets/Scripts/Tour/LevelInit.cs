using TMPro;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    public TextMeshProUGUI gasText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI tourIncomeText;
    public TextMeshProUGUI souvenirIncomeText;
    public GameObject shop1;
    public GameObject shop2;
    public TextMeshProUGUI tricycleText;
    public TextMeshProUGUI multicabText;
    private DataManager manager;

    void Start()
    {
        manager = DataManager.instance;
        manager.CurrentScene = manager.Destination;
        manager.Destination = "";
        manager.Save();
    }
    void Update()
    {
        gasText.text = manager.Gas.ToString("F0");
        moneyText.text = manager.Money.ToString("F0");
        tourIncomeText.text = "Total Passive Income (Coins/Second)" + manager.Income.ToString();
        souvenirIncomeText.text = "Total Passive Income (Coins/Second)" + manager.Income.ToString();

        switch (manager.CurrentScene)
        {
            case "Mabini":
                if (manager.MabiniShop1)
                    shop1.SetActive(true);
                if (manager.MabiniShop2)
                    shop2.SetActive(true);
                break;
            case "Malvar":
                if (manager.MalvarShop1)
                    shop1.SetActive(true);
                if (manager.MalvarShop2)
                    shop2.SetActive(true);
                break;
            case "Bauan":
                if (manager.BauanShop1)
                    shop1.SetActive(true);
                if (manager.BauanShop2)
                    shop2.SetActive(true);
                break;
            case "SanJose":
                if (manager.SanJoseShop1)
                    shop1.SetActive(true);
                if (manager.SanJoseShop2)
                    shop2.SetActive(true);
                break;
            case "Lobo":
                if (manager.LoboShop1)
                    shop1.SetActive(true);
                if (manager.LoboShop2)
                    shop2.SetActive(true);
                break;
            case "Goco":
                if (manager.BalayanShop1)
                    shop1.SetActive(true);
                if (manager.BalayanShop2)
                    shop2.SetActive(true);
                break;
        }

        if (manager.HasTricycle)
        {
            tricycleText.text = "Tricycle (Owned)";
        }
        if (manager.HasMulticab)
        {
            multicabText.text = "Multicab (Owned)";
        }
    }
}
