using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingPanel;
    private DataManager dataManager;
    public Image FadeImage;
    private string targetScene;
    public float MinLoadingTime;
    public float FadeDuration;

    private void Awake()
    {
        loadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
        dataManager = DataManager.instance;
    }

    public void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
        saveData();
    }

    void saveData()
    {
        string oldCurrentScene = dataManager.CurrentScene;
        dataManager.SetString("CurrentScene", targetScene);
        dataManager.SetString("Destination", oldCurrentScene);
        dataManager.Save();
    }

    private IEnumerator LoadSceneRoutine()
    {
        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0f);

        while (!Fade(1f))
            yield return null;

        loadingPanel.SetActive(true);

        while (!Fade(0f))
            yield return null;

        AsyncOperation task = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while (!task.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (elapsedLoadTime < MinLoadingTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
    }

    private bool Fade(float traget)
    {
        FadeImage.CrossFadeAlpha(traget, FadeDuration, true);

        if (Mathf.Abs(FadeImage.canvasRenderer.GetAlpha() - traget) <= 0.05f)
        {
            FadeImage.canvasRenderer.SetAlpha(traget);
            return true;
        }

        return false;
    }
}
