using UnityEngine;

public class TravelLevelFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 movePosition = target.position + offset;
        movePosition.z = transform.position.z;  // Keep the original Z position

        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
