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
        if(sceneName.Equals(""))
        {
            targetScene = dataManager.Destination;
            Debug.Log("Set the destination to " + dataManager.Destination + " from " + dataManager.CurrentScene);
        }else{
            targetScene = sceneName;
        }
        StartCoroutine(LoadSceneRoutine());
    }

    void saveData()
    {
        string oldCurrentScene = dataManager.CurrentScene;
        if(oldCurrentScene.Equals(dataManager.Destination))
            return;
        
        dataManager.CurrentScene = targetScene;
        dataManager.Destination = oldCurrentScene;
        dataManager.Save();
        Debug.Log("Saved");
        Debug.Log("Current Scene: " + dataManager.CurrentScene);
        Debug.Log("Destination: " + dataManager.Destination);
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
