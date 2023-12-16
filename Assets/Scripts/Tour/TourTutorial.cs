using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourTutorial : MonoBehaviour
{
    private Attention attentionScript;
    public void Start(){
        attentionScript = GetComponent<Attention>();
    }
    public void Update(){
        if (attentionScript.interactables != null)
        {
            // Reference
            foreach (GameObject interactable in attentionScript.interactables)
            {
                
            }
        }
    }
}