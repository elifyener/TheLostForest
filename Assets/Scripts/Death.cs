using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Vector2 checkPos;
    private Animator anim; 
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Death"))
        {
            HealthSystem.health--;
            anim.SetTrigger("death");
            Invoke("LoadCheckPoint", 2f);
        }
    }

    void LoadCheckPoint()
    {
        gameObject.transform.position = checkPos;
    }
}
