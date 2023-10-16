using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Animator anim;
    private Rigidbody rb;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentPoint = pointA.transform;
        anim.SetBool("isLookingRight", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            anim.SetBool("isLookingRight", false);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            anim.SetBool("isLookingRight", true);
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        else if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
