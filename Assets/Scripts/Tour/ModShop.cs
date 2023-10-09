using UnityEngine;

public class ModShop : MonoBehaviour
{
    public GameObject ModShopMenu;
    public AudioSource audioSource;
    public AudioClip successAudio;
    public AudioClip failedAudio;
    public void BuyTricycle()
    {
        if (DataManager.instance.Money < 75)
        {
            Debug.Log("Not enough money");
            audioSource.clip = failedAudio;
            audioSource.Play();
        }
        else
        {
            DataManager.instance.HasTricycle = true;
            DataManager.instance.Money -= 75;
            DataManager.instance.Save();
            audioSource.clip = successAudio;
            audioSource.Play();
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
            return;
        }
        else
        {
            DataManager.instance.HasMulticab = true;
            DataManager.instance.Money -= 50;
            DataManager.instance.Save();
            audioSource.clip = successAudio;
            audioSource.Play();
        }
        Close();
    }

    void Close(){
        ModShopMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
