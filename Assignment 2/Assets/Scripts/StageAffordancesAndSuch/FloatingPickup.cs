using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animates the floating pickups found in the tutorial zone.
/// </summary>
public class FloatingPickup : MonoBehaviour
{
    private float radius = 0.8f;
    private float speed = 0.5f;
    private Vector2 startpoint;
    private Vector2 destination;
    private Vector2 start;
    private float progress = 0.0f;
    private float rotOffset = 90f;
    private float RotationSpeed = 3f;
    void Start()
    {
        start = transform.localPosition;
        startpoint = transform.localPosition;
        progress = 0.0f;
        PickNewRandomDestination();
    }
    
    void Update()
    {
        bool reached = false;
        progress += speed * Time.deltaTime;
        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }
        transform.localPosition = (destination * progress) + start * (1 - progress);
        if (reached)
        {
            start = destination;
            PickNewRandomDestination();
            progress = 0.0f;
        }
        RotateGameObject(destination, RotationSpeed, rotOffset);
    }
    void PickNewRandomDestination()
    {
        destination = Random.insideUnitCircle * radius + startpoint;
    }
    private void RotateGameObject(Vector2 destination, float RotationSpeed, float offset)
    {
        Vector3 target = destination;
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }
}
