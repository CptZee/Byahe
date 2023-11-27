using UnityEngine;
using TMPro;
using System.Collections;
public class DialogWithNextSceneScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] lines;
    public float textSpeed;
    public string nextScene;
    public LoadingManager loadingManager;
    private int index;

    void Start()
    {
        Time.timeScale = 1;
        textDisplay.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(index == lines.Length - 1 && textDisplay.text == lines[index])
            {
                Debug.Log("Loading next scene...");
                textDisplay.gameObject.transform.parent.gameObject.SetActive(false);
                loadingManager.LoadScene(nextScene);
            }
            if (textDisplay.text == lines[index])
            {
                Debug.Log("Continuing to the next line...");
                NextLine();
            }
            else
            {
                Debug.Log("Skipping the animation...");
                StopAllCoroutines();
                textDisplay.text = lines[index];
            }
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textDisplay.gameObject.SetActive(false);
        }
    }
}
