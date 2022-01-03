using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2.0f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex>= waypoints.Length)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                currentWaypointIndex = 0;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
