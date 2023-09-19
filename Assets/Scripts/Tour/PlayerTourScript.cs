using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTourScript : MonoBehaviour
{
    
    private Renderer rend;
    private Rigidbody2D rb;
    public float moveSpeed = 5;
    
    private Animator animator;
    
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
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
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
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
        rb.velocity = new Vector2(0, 0);
    }

    
    public void StopMovingLeft()
    {
        Debug.Log("Standing...");
        animator.SetFloat("Vertical", -0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = new Vector2(0, 0);
    }
}
