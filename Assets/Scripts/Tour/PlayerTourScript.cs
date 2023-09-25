using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTourScript : MonoBehaviour
{
    
    public Renderer rend;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public float moveSpeed = 5;
    
    public Animator animator;
    
    void Start()
    {
        Time.timeScale = 1; //Resume the game if it is paused
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
