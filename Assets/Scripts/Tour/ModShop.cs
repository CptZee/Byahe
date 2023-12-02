using UnityEngine;

public class ModShop : MonoBehaviour
{
    public GameObject ModShopMenu;
    public AudioSource audioSource;
    public AudioClip successAudio;
    public AudioClip failedAudio;
    public LoadingManager loadingManager;
    public GameObject uiElements;
    public GameObject failedElement;
    public void BuyTricycle()
    {
        if (DataManager.instance.Money < 75)
        {
            Debug.Log("Not enough money");
            audioSource.clip = failedAudio;
            audioSource.Play();
            failedElement.SetActive(true);
        }
        else
        {
            DataManager.instance.HasTricycle = true;
            DataManager.instance.Money -= 75;
            DataManager.instance.TourActor = "Tricycle";
            DataManager.instance.Save();
            audioSource.clip = successAudio;
            audioSource.Play();
            loadingManager.LoadScene(DataManager.instance.CurrentScene);
        }
        Close();
    }

    public void BuyMulticab()
    {
        if (DataManager.instance.Money < 50)
        {
            Debug.Log("Not enough money");
            audioSource.clip = failedAudio;
            audioSource.Play();
            
            ModShopMenu.SetActive(false);
            uiElements.SetActive(true);
            Time.timeScale = 1f;
            failedElement.SetActive(true);
            return;
        }
        else
        {
            DataManager.instance.HasMulticab = true;
            DataManager.instance.Money -= 50;
            DataManager.instance.TravelActor = "Multicab";
            DataManager.instance.Save();
            audioSource.clip = successAudio;
            audioSource.Play();
            loadingManager.LoadScene(DataManager.instance.CurrentScene);
        }
        Close();
    }
    public void EquipMulticab(){
        Equip("Travel", "Multicab");
    }

    public void EquipJeepney(){
        Equip("Travel", "Jeepney");
    }

    public void EquipTricycle(){
        Equip("Travel", "Tricycle");
    }

    public void EquipKalesa(){
        Equip("Tour", "Kalesa");
    }

    void Equip(string phase, string vehicle)
    {
        if(phase.Equals("Tour"))
            DataManager.instance.TourActor = vehicle;

        if(phase.Equals("Travel"))
            DataManager.instance.TravelActor = vehicle;
        
        loadingManager.LoadScene(DataManager.instance.CurrentScene);
        Close();
    }

    void Close()
    {
        ModShopMenu.SetActive(false);
        uiElements.SetActive(true);
        Time.timeScale = 1f;
    }
}
