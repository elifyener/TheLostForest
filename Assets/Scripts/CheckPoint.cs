using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Death deathWall;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            deathWall.checkPos = other.transform.position;
        }
    }
}
