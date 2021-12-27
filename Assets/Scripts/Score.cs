using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip audioStar;
    [SerializeField] private Animator anim;
    private bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Star"))
        {
            AudioSource.PlayClipAtPoint(audioStar, other.transform.position);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Chest") && !isOpen)
        {
            AudioSource.PlayClipAtPoint(audioStar, other.transform.position);
            anim.SetBool("open", true);
            isOpen = true;
        } 
    }
}
