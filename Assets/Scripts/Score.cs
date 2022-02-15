using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip audioStar;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _carrotsImage0;
    [SerializeField] private Image _carrotsImage1;
    [SerializeField] private Image _carrotsImage2;
    public static int score = 0;
    public static int carrot = 0;
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
            _audioSource.PlayOneShot(audioStar, 0.05f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Carrot"))
        {
            switch (carrot)
            {
                case 0:
                    var tempColor0 = _carrotsImage0.color;
                    tempColor0.a = 1f;
                    _carrotsImage0.color = tempColor0;
                break;
                case 1:
                    var tempColor1 = _carrotsImage1.color;
                    tempColor1.a = 1f;
                    _carrotsImage1.color = tempColor1;
                break;
                case 2:
                    var tempColor2 = _carrotsImage2.color;
                    tempColor2.a = 1f;
                    _carrotsImage2.color = tempColor2;
                break;
            }
            carrot++;
            _audioSource.PlayOneShot(audioStar, 0.05f);
            Destroy(other.gameObject);
        }
    }
}
