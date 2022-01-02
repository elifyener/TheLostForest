using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Vector2 checkPos;
    private Animator anim;
    public static bool isDeath;
    public static bool isAttack;
    [SerializeField] private AudioClip audiohurt;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthSystem.health--;
            isAttack = true;
            isDeath = true;
            AudioSource.PlayClipAtPoint(audiohurt, transform.position);
            Invoke("LoadCheckPoint", 2f);

        }
    }

    void LoadCheckPoint()
    {
        gameObject.transform.position = checkPos;
        isDeath = false;
        isAttack = false;
    }
}
