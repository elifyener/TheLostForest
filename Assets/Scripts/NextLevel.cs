using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] public AudioClip _audioclip;
    [SerializeField] public AudioSource _audiosource;
    [SerializeField] public GameObject ThinkingBallon;
    [SerializeField] public GameObject WinScene;
    public void SkipNextLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(0.5f);
        Score.carrot = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player") && Score.carrot>2)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                _audiosource.PlayOneShot(_audioclip, 1);
                Invoke("Delay", 1f);
            }
            else
            {
                _audiosource.PlayOneShot(_audioclip, 1);
                StartCoroutine(LoadLevel());
            }
            
        }
        else
        {
            ThinkingBallon.SetActive(true);
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        ThinkingBallon.SetActive(false);
    }
    void Delay()
    {
        WinScene.SetActive(true);
        Time.timeScale = 0;
    }
    
}
