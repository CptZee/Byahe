using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private float shakeDuration = 0.0f;
    private float shakeMagnitude = 0.1f;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void StartShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime;
        }
    }
}
