using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip audiobee;
    public static bool isEnemyDeath = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Bee"))
        {
            AudioSource.PlayClipAtPoint(audiobee, other.transform.position);
            anim.SetTrigger("enemyDeath");
            StartCoroutine(Enemydestroy(other));
            isEnemyDeath = true;
        }
    }

    IEnumerator Enemydestroy(Collider2D other) 
    {
        yield return new WaitForSeconds(1f);
        Destroy(other.gameObject);

    }
}
