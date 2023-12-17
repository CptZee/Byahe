using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingPanel;
    private DataManager dataManager;
    public Slider progressSlider;
    public Image FadeImage;
    private string targetScene;
    public float FadeDuration;
    public float maxLoadingTime = 2f;

    private void Awake()
    {
        loadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
        dataManager = DataManager.instance;
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName.Equals(""))
        {
            targetScene = dataManager.Destination;
            Debug.Log("Set the destination to " + dataManager.Destination + " from " + dataManager.CurrentScene);
        }
        else
        {
            targetScene = sceneName;
        }
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0f);
        if (progressSlider != null)
            progressSlider.value = 0;

        while (!Fade(1f))
            yield return null;

        loadingPanel.SetActive(true);

        while (!Fade(0f))
            yield return null;

        AsyncOperation task = SceneManager.LoadSceneAsync(targetScene);
        if (progressSlider != null)
            task.allowSceneActivation = false;
        float progress = 0;
        float elapsedLoadTime = 0f;

        while (!task.isDone)
        {
            progress = Mathf.MoveTowards(progress, task.progress, Time.deltaTime);
            if (progressSlider != null)
                progressSlider.value = progress;

            elapsedLoadTime += Time.deltaTime;
            if (progressSlider != null && progress >= 0.9f)
            {
                progressSlider.value = 2;
                task.allowSceneActivation = true;
            }

            if (elapsedLoadTime >= maxLoadingTime)
            {
                Debug.LogWarning("Loading exceeded max loading time.");
                task.allowSceneActivation = true;
                break;
            }

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
