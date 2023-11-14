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

    void Start(){
        manager = DataManager.instance;
        manager.CurrentScene = manager.Destination;
        manager.Destination = "";
        manager.Save();
    }
    void Update()
    {
        gasText.text = manager.Gas.ToString("F0");
        moneyText.text = manager.Money.ToString("F0");
        tourIncomeText.text = "Establishment Passive Income (Coins/Second)" + manager.Income.ToString();
        souvenirIncomeText.text = "Establishment Passive Income (Coins/Second)" + manager.Income.ToString();
        
        if(manager.MabiniShop1){
            shop1.SetActive(true);
        }
        if(manager.MabiniShop2){
            shop2.SetActive(true);
        }
        if(manager.HasTricycle){
            tricycleText.text = "Tricycle (Owned)";
        }
        if(manager.HasMulticab){
            multicabText.text = "Multicab (Owned)";
        }
    }
}
