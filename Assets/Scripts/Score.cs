using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip audioStar;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Star") || other.gameObject.CompareTag("Carrot"))
        {
            _audioSource.PlayOneShot(audioStar, 0.5f);
            Destroy(other.gameObject);
        }
        
    }
}
