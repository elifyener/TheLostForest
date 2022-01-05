using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip audioStar;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int score = 0;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Star"))
        {
            score++;
            _scoreText.text = score.ToString();
            _audioSource.PlayOneShot(audioStar, 0.5f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Carrot"))
        {
            
            _audioSource.PlayOneShot(audioStar, 0.5f);
            Destroy(other.gameObject);
        }
    }
}
