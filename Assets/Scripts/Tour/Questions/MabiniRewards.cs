using UnityEngine;

public class MabiniRewards : MonoBehaviour
{
    public QuestionsScript script;
    public AudioSource audioSource;
    public AudioClip successAudio;
    public void CorrectPreAnswer(){
        Debug.Log("Correct answer");
        audioSource.clip = successAudio;
        audioSource.Play();
        script.RemoveQuestion();
    }
}
