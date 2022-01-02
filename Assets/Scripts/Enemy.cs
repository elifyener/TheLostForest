using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip audioDeadEnemy;
    [SerializeField] private AudioClip audioAttackEnemy;
    public static bool isEnemyDeath = false;
    private bool attack;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        if (Death.isAttack && attack)
        {
            anim.SetBool("enemyAttack", true);
        }
        else
        {
            anim.SetBool("enemyAttack", false);
            attack = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(audioDeadEnemy, other.transform.position);
            anim.SetTrigger("enemyDeath");
            isEnemyDeath = true;
            Invoke("EnemyDestroy", 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player") && audioAttackEnemy != null)
        {
            AudioSource.PlayClipAtPoint(audioAttackEnemy, transform.position);
            attack = true;
        }
        
    }

    void EnemyDestroy()
    {
        Destroy(gameObject);

    }
}
