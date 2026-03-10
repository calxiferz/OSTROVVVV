using UnityEngine;

public class ObjectFollowMouse : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;

    Vector2 currentVelocity;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Offsets the target position so that the object keeps its distance.
        mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;

        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }
}

