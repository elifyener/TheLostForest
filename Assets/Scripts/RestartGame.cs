using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] public AudioClip _audioclip;
    [SerializeField] public AudioSource _audiosource;
    [SerializeField] public GameObject gameOverScene;
    public void Restart()
    {
        _audiosource.PlayOneShot(_audioclip, 1);
        gameOverScene.SetActive(false);
        HealthSystem.health = 3;
        Score.carrot = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
