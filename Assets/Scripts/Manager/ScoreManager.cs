using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (!PlayerPrefs.HasKey("tutorialFinished"))
                return;
            Load();
        }
    }

    public void Load()
    {
        tutorialFinished = PlayerPrefs.GetInt("tutorialFinished") == 1;
        mabiniFinished = PlayerPrefs.GetInt("mabiniFinished") == 1;
        malvarFinished = PlayerPrefs.GetInt("malvarFinished") == 1;
        bauanFinished = PlayerPrefs.GetInt("bauanFinished") == 1;
        sanJoseFinished = PlayerPrefs.GetInt("sanJoseFinished") == 1;
        loboFinished = PlayerPrefs.GetInt("loboFinished") == 1;
        balayanFinished = PlayerPrefs.GetInt("balayanFinished") == 1;
        tutorialTime = PlayerPrefs.GetFloat("tutorialTime");
        mabiniTime = PlayerPrefs.GetFloat("mabiniTime");
        malvarTime = PlayerPrefs.GetFloat("malvarTime");
        bauanTime = PlayerPrefs.GetFloat("bauanTime");
        sanJoseTime = PlayerPrefs.GetFloat("sanJoseTime");
        loboTime = PlayerPrefs.GetFloat("loboTime");
        balayanTime = PlayerPrefs.GetFloat("balayanTime");
        highestMoney = PlayerPrefs.GetFloat("highestMoney");
        highestGas = PlayerPrefs.GetFloat("highestGas");
    }

    public void Save()
    {
        SetBool("tutorialFinished", tutorialFinished);
        SetBool("mabiniFinished", mabiniFinished);
        SetBool("malvarFinished", malvarFinished);
        SetBool("bauanFinished", bauanFinished);
        SetBool("sanJoseFinished", sanJoseFinished);
        SetBool("loboFinished", loboFinished);
        SetBool("balayanFinished", balayanFinished);
        SetFloat("tutorialTime", tutorialTime);
        SetFloat("mabiniTime", mabiniTime);
        SetFloat("malvarTime", malvarTime);
        SetFloat("bauanTime", bauanTime);
        SetFloat("sanJoseTime", sanJoseTime);
        SetFloat("loboTime", loboTime);
        SetFloat("balayanTime", balayanTime);
        SetFloat("highestMoney", highestMoney);
        SetFloat("highestGas", highestGas);
    }

    public void Reset()
    {
        tutorialFinished = false;
        mabiniFinished = false;
        malvarFinished = false;
        bauanFinished = false;
        sanJoseFinished = false;
        loboFinished = false;
        balayanFinished = false;
        tutorialTime = 0;
        mabiniTime = 0;
        malvarTime = 0;
        bauanTime = 0;
        sanJoseTime = 0;
        loboTime = 0;
        balayanTime = 0;
        highestMoney = 0;
        highestGas = 0;
        Save();
    }

    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool tutorialFinished { get; set; }
    public bool mabiniFinished { get; set; }
    public bool malvarFinished { get; set; }
    public bool bauanFinished { get; set; }
    public bool sanJoseFinished { get; set; }
    public bool loboFinished { get; set; }
    public bool balayanFinished { get; set; }
    public float tutorialTime { get; set; }
    public float mabiniTime { get; set; }
    public float malvarTime { get; set; }
    public float bauanTime { get; set; }
    public float sanJoseTime { get; set; }
    public float loboTime { get; set; }
    public float balayanTime { get; set; }
    public float highestMoney { get; set; }
    public float highestGas { get; set; }
}
