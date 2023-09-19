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
    public Animator animator;

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
        Time.timeScale = 1; //Resume the game if it is paused
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        // Adjust the Box Collider dimensions to match the Sprite dimensions
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();

        gasSlider.value = gasLevel;
        destinationSlider.value = destinationProgress;

        StartCoroutine(EnableCollisionAfterWarmup(2f));
    }

    void Update()
    {
        gasLevel -= gasDecreaseSpeed * Time.deltaTime;
        gasLevel = Mathf.Clamp(gasLevel, 0f, 100f);

        destinationProgress += destinationIncreaseSpeed * Time.deltaTime;
        destinationProgress = Mathf.Clamp(destinationProgress, 0f, 100f);

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
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void MoveRight()
    {
        float moveDirection = 1;
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void StopMoving()
    {
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
        rb.velocity = new Vector2(0, 0);
    }
}
