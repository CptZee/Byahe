using TMPro;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    
    
    public TextMeshProUGUI gasText;
    public TextMeshProUGUI moneyText;
    void Start()
    {
        DataManager.instance.Money = 0f;
        gasText.text = DataManager.instance.Gas.ToString();
        moneyText.text = DataManager.instance.Money.ToString();
    }

    void Update()
    {
        
    }
}
