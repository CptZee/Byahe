using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConArtist : MonoBehaviour
{
    public Transform destinationPoint;
    public Transform startPont;
    public float moveSpeed = 3.0f;
    void Update()
    {
        if (destinationPoint != null)
        {
            Vector3 targetPosition = new Vector3(destinationPoint.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - destinationPoint.position.x) < 3.0f)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = startPont.position.x;
                transform.position = newPosition;
            }
        }
    }
}
