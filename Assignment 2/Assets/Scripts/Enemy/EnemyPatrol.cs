using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float forceStrength;     
    public float stopDistance;      
    public Vector2[] patrolPoints;  
    private int currentPoint = 0;     
    private Rigidbody2D ourRigidbody;   
    void Awake()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
        ourRigidbody.freezeRotation = true;
    }

    void Update()
    {
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;
        if (distance <= stopDistance)
        {
            currentPoint = currentPoint + 1;
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }
        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;
        ourRigidbody.AddForce(direction * forceStrength);
    }
}
