using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip audioDeadEnemy;
    [SerializeField] private AudioClip audioAttackEnemy;
    [SerializeField] private AudioSource audiosourceEnemy;
    public static bool isEnemyDeath = false;
    public static int killcounter = 0;
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
            audiosourceEnemy.PlayOneShot(audioDeadEnemy,0.5f);
            anim.SetTrigger("enemyDeath");
            isEnemyDeath = true;
            Invoke("EnemyDestroy", 1f);
            killcounter += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player") && audioAttackEnemy != null)
        {
            audiosourceEnemy.PlayOneShot(audioAttackEnemy,0.5f);
            attack = true;
        }
        
    }

    void EnemyDestroy()
    {
        Destroy(gameObject);

    }
}
