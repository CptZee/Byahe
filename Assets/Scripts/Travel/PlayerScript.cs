using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Slider gasSlider;
    public Slider destinationSlider;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;
    public GameObject nearIndicatorPanel;
    public float colliderReductionAmount = 1f;
    public float gasDecreaseSpeed = 0.25f;
    public float destinationIncreaseSpeed = 2.25f;
    public float collisionGasLoss = 2.5f;
    public Animator animator;

    private float gasLevel;
    private float destinationProgress = 0f;
    public Renderer rend;
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public float blinkDuration = 1f;
    public float blinkSpeed = 0.2f;
    private bool isCollisionEnabled = false;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public AudioManager audioManager;
    private int spriteVariation = 0;
    private bool gameOver = false;
    void Start()
    {
        Time.timeScale = 1; //Resume the game if it is paused

        // Adjust the Box Collider dimensions to match the Sprite dimensions
        boxCollider.size = spriteRenderer.sprite.bounds.size;

        BoxCollider2D[] colliders = FindObjectsOfType<BoxCollider2D>();

        // Iterate through each BoxCollider and match its size to the sprite's bounds
        foreach (BoxCollider2D collider in colliders)
        {
            MatchColliderSizeToSprite(collider);
        }

        gasSlider.value = gasLevel;
        destinationSlider.value = destinationProgress;

        StartCoroutine(EnableCollisionAfterWarmup(2f));
        gasLevel = DataManager.instance.Gas;
    }

    void Update()
    {
        DataManager manager = DataManager.instance;
        gasLevel -= gasDecreaseSpeed * Time.deltaTime;
        gasLevel = Mathf.Clamp(gasLevel, 0f, gasSlider.maxValue);

        destinationProgress += destinationIncreaseSpeed * Time.deltaTime;
        destinationProgress = Mathf.Clamp(destinationProgress, 0f, 100f);

        gasSlider.value = gasLevel;
        destinationSlider.value = destinationProgress;
        manager.Gas = gasLevel;

        if (gasSlider.value <= (0.15f * gasSlider.maxValue))
        {
            if (!audioManager.IsPlaying())
            {
                Debug.Log("Low Gas! " + gasSlider.value);
                audioManager.PlayAudio(1); //Play Low Gas Sound
            }
        }
        if (destinationProgress >= 80 && !gameOver)
        {
            nearIndicatorPanel.SetActive(true);
        }
        if (destinationProgress == 100 && !gameOver)
        {
            gameWonPanel.SetActive(true);
            gameOver = true;
            Time.timeScale = 0;
        }

        if (gasSlider.value <= 0 && !gameOver)
        {
            gameOverPanel.SetActive(true);
            manager.Money -= 10;
            Time.timeScale = 0;
            gameOver = true;
        }
        Debug.Log("Current Tour Actor: " + manager.TourActor);
        if (manager.TravelActor.Equals("Jeepney"))
        {
            spriteVariation = -1;
        }
        if (manager.TravelActor.Equals("Multicab"))
        {
            spriteVariation = 1;
        }
        Debug.Log("Current Sprite Variation " + spriteVariation);
        animator.SetFloat("SpriteVariation", spriteVariation);
        Debug.Log("Current Sprite Variation in animator " + animator.GetFloat("SpriteVariation"));

        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
    }

    void MatchColliderSizeToSprite(BoxCollider2D collider)
    {
        // Check if there is a SpriteRenderer attached to the same GameObject
        SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Get the trimmed size of the sprite
            Vector2 trimmedSize = spriteRenderer.sprite.textureRect.size / spriteRenderer.sprite.pixelsPerUnit;

            // Set the BoxCollider size to match the trimmed size
            collider.size = trimmedSize;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found for " + collider.gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollisionEnabled) return;
        if (other.gameObject.CompareTag("Obstacles"))
        {
            StartCoroutine(Blink());
            gasLevel -= collisionGasLoss;
            gasLevel = Mathf.Clamp(gasLevel, 0f, gasSlider.maxValue);
            audioManager.PlayAudio(0); //Play Crash Sound
            Debug.Log("Gas Level: " + gasLevel);
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
