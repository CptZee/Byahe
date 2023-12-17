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
    public TextMeshProUGUI kalesaText;
    public TextMeshProUGUI tricycleText;
    public TextMeshProUGUI multicabText;
    public TextMeshProUGUI jeepneyText;
    public TextMeshProUGUI gasStationValuesText;
    public GameObject gameoverPanel;
    public GameObject fadePanel;
    private DataManager manager;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = ScoreManager.instance;
        manager = DataManager.instance;
        if (manager.Destination == "")
            return;
        manager.CurrentScene = manager.Destination;
        manager.Destination = "";
        manager.Save();
    }
    void Update()
    {
        UpdateTime();
        CheckGameOver();
        UpdateCurrencyScore();

        if (manager.TourActor.Equals("Kalesa") && jeepneyText != null)
            jeepneyText.SetText("JEEPNEY (EQUIPED)");
        if (manager.TourActor.Equals("Tricycle") && tricycleText != null)
            tricycleText.SetText("Tricycle (EQUIPED)");
        if (manager.TravelActor.Equals("Jeepney") && kalesaText != null)
            kalesaText.SetText("Kalesa (EQUIPED)");
        if (manager.TravelActor.Equals("Multicab") && multicabText != null)
            multicabText.SetText("Multicab (EQUIPED)");
        gasText.text = manager.Gas.ToString("F0");
        moneyText.text = manager.Money.ToString("F0");
        tourIncomeText.text = "Total Passive Income (Coins/Second): " + manager.Income.ToString();
        souvenirIncomeText.text = "Total Passive Income (Coins/Second): " + manager.Income.ToString();

        gasStationValuesText.text = $"Gas: {manager.Gas:F2}\n<size=80%>Gold: {manager.Money:F2}</size>";

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

    private void UpdateTime()
    {
        float deltaTimeMilliseconds = Time.deltaTime * 1000.0f;
        manager.Time += deltaTimeMilliseconds;
    }

    public void CheckGameOver()
    {
        if (gameoverPanel == null)
            return;
        if (manager.Money <= 9 && manager.Income == 0)
        {
            fadePanel.SetActive(true);
            gameoverPanel.SetActive(true);
        }
    }

    public void UpdateCurrencyScore()
    {
        if (manager.Money > scoreManager.highestMoney)
            scoreManager.highestMoney = manager.Money;
        if (manager.Gas > scoreManager.highestGas)
            scoreManager.highestGas = manager.Gas;
        scoreManager.Save();
    }
}
