using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip audioenemy;
    public static bool isEnemyDeath = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(audioenemy, other.transform.position);
            anim.SetTrigger("enemyDeath");
            isEnemyDeath = true;
            Invoke("EnemyDestroy", 1f);
        }
    }

    void EnemyDestroy() 
    {
        Destroy(gameObject);
        
    }
}
