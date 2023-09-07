using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Slider gasSlider;
    public Slider destinationSlider;
    public GameObject gameOverPanel;
    public float gasDecreaseSpeed = 0.25f;
    public float destinationIncreaseSpeed = 2.25f;
    public float collisionGasLoss = 2.5f;

    private float gasLevel = 100f;
    private float destinationProgress = 0f;
    private Renderer rend;
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public float blinkDuration = 1f;
    public float blinkSpeed = 0.2f;
    private bool isCollisionEnabled = false; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();

        gasSlider.value = gasLevel;
        destinationSlider.value = destinationProgress;

        StartCoroutine(EnableCollisionAfterWarmup(2f));
    }

    void Update()
    {

        // Decrease gas over time
        gasLevel -= gasDecreaseSpeed * Time.deltaTime;
        gasLevel = Mathf.Clamp(gasLevel, 0f, 100f);

        // Increase destination progress over time
        destinationProgress += destinationIncreaseSpeed * Time.deltaTime;
        destinationProgress = Mathf.Clamp(destinationProgress, 0f, 100f);

        // Update UI
        gasSlider.value = gasLevel;
        destinationSlider.value = destinationProgress;

        if (gasSlider.value <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollisionEnabled) return;
        if(other.gameObject.CompareTag("Obstacles"))
        {
            StartCoroutine(Blink());
            gasLevel -= collisionGasLoss;
            gasLevel = Mathf.Clamp(gasLevel, 0f, 100f);
        }

    }

    IEnumerator Blink()
    {
        float endTime = Time.time + blinkDuration;

        while (Time.time < endTime)
        {
            rend.enabled = !rend.enabled;  
            yield return new WaitForSeconds(blinkSpeed); 
        }

        rend.enabled = true; 
    }

    IEnumerator EnableCollisionAfterWarmup(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isCollisionEnabled = true;
    }
    
    public void MoveLeft()
    {
        float moveDirection = -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void MoveRight()
    {
        float moveDirection = 1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void StopMoving()
    {
        Debug.Log("Stopped Moving");
        rb.velocity = new Vector2(0, 0);
    }
}
