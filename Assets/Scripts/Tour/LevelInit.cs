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
    void Update()
    {
        DataManager manager = DataManager.instance;
        gasText.text = manager.Gas.ToString("F0");
        moneyText.text = manager.Money.ToString("F0");
        tourIncomeText.text = manager.Income.ToString();
        souvenirIncomeText.text = manager.Income.ToString();
        
        if(manager.MabiniShop1){
            shop1.SetActive(true);
        }
        if(manager.MabiniShop2){
            shop2.SetActive(true);
        }
    }
}
