using UnityEngine;
using UnityEngine.UI;

public class TravelPhaseInit : MonoBehaviour
{
    public Slider gasSlider;
    private DataManager datamanager;
    void Start()
    {
        datamanager = DataManager.instance;
        gasSlider.maxValue = datamanager.Gas;
        Debug.Log("Max Gas: " + gasSlider.maxValue );
    }
}
