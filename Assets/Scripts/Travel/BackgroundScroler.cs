using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BoxCollider2D collider2d;
    public Rigidbody2D rb;
    private float height;
    private float scrollSpeed = -4f;
    private float maxSpeed = -6f;
    private float speedIncreaseFactor = 0.003f;
    private float elapsedTime = 0f;

    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = collider2d.size.y;
        collider2d.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
        ResetObstacle();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        scrollSpeed = Mathf.Max(maxSpeed, scrollSpeed - speedIncreaseFactor * elapsedTime);

        rb.velocity = new Vector2(0, scrollSpeed);

        if (transform.position.y < -height)
        {
            Vector2 resetPosition = new Vector2(0, height * 2f);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObstacle();
        }
    }

    void ResetObstacle()
    {
        float currentY = 8.0f;  // Start position along the Y-axis
        float gap = 0.2f;  // Gap between each child, you can adjust this value

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float childHeight = 0f;

            // Get the height of the child from its renderer bounds
            if (child.GetComponent<Renderer>() != null)
            {
                childHeight = child.GetComponent<Renderer>().bounds.size.y;
            }
            // Alternatively, get it from its collider if it has one
            else if (child.GetComponent<Collider2D>() != null)
            {
                childHeight = child.GetComponent<Collider2D>().bounds.size.y;
            }

            // Set the new position
            float randomX = Random.Range(-2.2f, 2.4f);
            Vector3 newPosition = new Vector3(randomX, currentY - (childHeight / 2), 0f);
            child.localPosition = newPosition;

            // Update currentY for the next child
            currentY = newPosition.y - (childHeight / 2) - gap;
        }
    }
}
