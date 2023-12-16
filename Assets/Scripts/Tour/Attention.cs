using UnityEngine;
using System.Collections.Generic;

public class Attention : MonoBehaviour
{
    public Transform playerSprite;
    public List<GameObject> interactables;
    public float minDistance = 3.0f;

    public float amplitude = 0.1f;
    public float frequency = 6f;
    private float timeCounter = 0f;
    void Update()
    {
        if (playerSprite != null && transform != null)
        {
            float yOffset = amplitude * Mathf.Sin(frequency * timeCounter);
            Vector3 targetPosition = new Vector3(playerSprite.position.x, playerSprite.position.y + 1.25f + yOffset, playerSprite.position.z);

            transform.position = targetPosition;

            timeCounter += Time.deltaTime;
        }

        if (interactables != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (GameObject interactable in interactables)
            {
                float distance = Vector3.Distance(playerSprite.position, interactable.transform.position);
                if (distance < minDistance)
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
