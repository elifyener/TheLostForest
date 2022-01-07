using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] public AudioClip _audioclip;
    [SerializeField] public AudioSource _audiosource;
    [SerializeField] public GameObject pauseScene;
    public void Restart()
    {
        _audiosource.PlayOneShot(_audioclip, 1);
        pauseScene.SetActive(false);
        HealthSystem.health = 3;
        Score.carrot = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
