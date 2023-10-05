using UnityEngine;

public class PlayerTourScript : MonoBehaviour
{

    public Renderer rend;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public float moveSpeed = 5;
    public Animator animator;

    //This part is really ifty and prolly should be moved to its own later on
    public GameObject uiButtons;
    public GameObject sign1;
    public GameObject sign2;
    public GameObject shop1;
    public GameObject shop2;
    public GameObject landmark;
    public GameObject gasStation;
    public GameObject modShop;
    public GameObject sign1UI;
    public GameObject sign2UI;
    public GameObject shop1UI;
    public GameObject shop2UI;

    void Start()
    {
        Time.timeScale = 1; //Resume the game if it is paused
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
    }

    public void MoveLeft()
    {
        float moveDirection = -1;
        Debug.Log("Moving Left...");
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        Debug.Log("Current Velocity: " + rb.velocity);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
        Debug.Log("New Velocity: " + rb.velocity);
    }

    public void MoveRight()
    {
        float moveDirection = 1;
        Debug.Log("Moving Right...");
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void StopMovingRight()
    {
        Debug.Log("Standing...");
        animator.SetFloat("Vertical", 0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }


    public void StopMovingLeft()
    {
        Debug.Log("Standing...");
        animator.SetFloat("Vertical", -0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }

    public void Interact()
    {
        Debug.Log("Interacting...");
        float distance = Vector3.Distance(transform.position, shop1.transform.position);
        if (distance < 3.0f && shop1.activeSelf)
        {
            Debug.Log("Interacting with Shop 1...");
            showUI(shop1UI);
        }
        distance = Vector3.Distance(transform.position, shop2.transform.position);
        if (distance < 3.0f && shop2.activeSelf)
        {
            Debug.Log("Interacting with Shop 2...");
            showUI(shop2UI);
        }
        distance = Vector3.Distance(transform.position, sign1.transform.position);
        if (distance < 3.0f && !shop1.activeSelf)
        {
            Debug.Log("Interacting with Shop 1 Sign...");
            showUI(sign1UI);
        }
        distance = Vector3.Distance(transform.position, sign2.transform.position);
        if (distance < 3.0f && !shop2.activeSelf)
        {
            Debug.Log("Interacting with Shop 2 Sign...");
            showUI(sign2UI);
        }
    }

    public void CloseShop1UI()
    {
        hideUI(shop1UI);
    }

    public void CloseShop2UI()
    {
        hideUI(shop2UI);
    }

    public void CloseSign1UI()
    {
        hideUI(sign1UI);
    }


    public void CloseSign2UI()
    {
        hideUI(sign2UI);
    }

    public void BuyShop1()
    {
        Debug.Log("Buying Shop 1...");
        shop1.SetActive(true);
        hideUI(sign1UI);
    }

    public void BuyShop2()
    {
        Debug.Log("Buying Shop 2...");
        shop2.SetActive(true);
        hideUI(sign2UI);
    }

    
    // Private methods just for modularization
    void showUI(GameObject menu)
    {
        menu.SetActive(true);
        uiButtons.SetActive(false);
        Time.timeScale = 0;
    }

    void hideUI(GameObject menu)
    {
        menu.SetActive(false);
        uiButtons.SetActive(true);
        Time.timeScale = 1;
    }
}
