using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int waypointsindx = 0;
    [SerializeField] private float platformMovingSpeed = 2.0f;

    private void FixedUpdate()
    {

        if (Vector2.Distance(waypoints[waypointsindx].transform.position, transform.position) < .1f)
        {
            waypointsindx++;
            if (waypointsindx >= waypoints.Length)
            {
                waypointsindx = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointsindx].transform.position, Time.deltaTime * platformMovingSpeed);
    }
}
