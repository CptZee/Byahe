using UnityEngine;

public class Attention : MonoBehaviour
{
    public Transform attentionSprite;
    public Transform playerSprite;

    public float amplitude = 0.1f;
    public float frequency = 6f;
    private float timeCounter = 0f;

    void Update()
    {
        if (playerSprite != null && attentionSprite != null)
        {
            float yOffset = amplitude * Mathf.Sin(frequency * timeCounter);
            Vector3 targetPosition = new Vector3(playerSprite.position.x, playerSprite.position.y + 1.25f + yOffset, playerSprite.position.z);

            attentionSprite.position = targetPosition;

            timeCounter += Time.deltaTime;
        }
    }
}
