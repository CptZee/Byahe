using UnityEngine;
using TMPro;
using System.Collections;

public class DialogScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] lines;
    public float textSpeed;

    private int index;
    
    void Start()
    {
        textDisplay.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textDisplay.text == lines[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                textDisplay.text = lines[index];
            }
        }

        if (Input.touchCount > 0)
        {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            if (textDisplay.text == lines[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                textDisplay.text = lines[index];
            }   
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
