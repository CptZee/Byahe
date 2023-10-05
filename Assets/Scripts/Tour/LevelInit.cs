using TMPro;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    
    public TextMeshProUGUI gasText;
    public TextMeshProUGUI moneyText;
    public GameObject shop1;
    public GameObject shop2;
    void Start()
    {
        DataManager manager = DataManager.instance;
        gasText.text = manager.Gas.ToString("F0");
        moneyText.text = manager.Money.ToString("F0");
        if(manager.MabiniShop1){
            shop1.SetActive(true);
        }
        if(manager.MabiniShop2){
            shop2.SetActive(true);
        }

    }

    void Update()
    {
        
    }
}
