using UnityEngine;

public class BirdPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public bool isMovingLeft = false;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(isMovingLeft)
            currentPoint = pointB.transform;
        else
            currentPoint = pointA.transform;
        anim.SetBool(anim.GetParameter(0).name, isMovingLeft);
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            anim.SetBool(anim.GetParameter(0).name, false);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            anim.SetBool(anim.GetParameter(0).name, true);
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
