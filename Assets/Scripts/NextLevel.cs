using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] public AudioClip _audioclip;
    [SerializeField] public AudioSource _audiosource;
    public void SkipNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player") && Score.carrot>2)
        {
            _audiosource.PlayOneShot(_audioclip, 1);
            StartCoroutine(LoadLevel());
        }    
    }
}
