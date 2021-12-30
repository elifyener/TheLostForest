using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip audioStar;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Star"))
        {
            AudioSource.PlayClipAtPoint(audioStar, other.transform.position);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Carrot"))
        {
            AudioSource.PlayClipAtPoint(audioStar, other.transform.position);
            Destroy(other.gameObject);
        }
        
    }
}
