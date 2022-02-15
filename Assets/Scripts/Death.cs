using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    public Vector2 checkPos;
    private Animator anim;
    private Collider2D _collider2D;
    public static bool isDeath;
    public static bool isAttack;
    [SerializeField] private AudioClip audiohurt;
    [SerializeField] private AudioSource audiosource;
    public static int deathcounter = 0;

    private void Start() 
    {
        _collider2D = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            anim.SetTrigger("death");
            isAttack = true;
            isDeath = true;
            HealthSystem.health--;
            deathcounter += 1;
            _collider2D.enabled = false;
            audiosource.PlayOneShot(audiohurt, 0.5f);
            Invoke("LoadCheckPoint", 1f);
            
        }
    }

    void LoadCheckPoint()
    {
        gameObject.transform.position = checkPos;
        isDeath = false;
        isAttack = false;
        _collider2D.enabled = true;
        CharacterControl.moving = true;

    }
}
