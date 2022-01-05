using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public static int health = 3;
    [SerializeField] GameObject live3;
    [SerializeField] GameObject live2;
    [SerializeField] GameObject live1;
    [SerializeField] GameObject live0;
    private void Update() 
    {
        switch (health)
        {
            case 3:
                live3.SetActive(true);
                live2.SetActive(false);
                live1.SetActive(false);
                live0.SetActive(false);
            break;
            case 2:
                live3.SetActive(false);
                live2.SetActive(true);
                live1.SetActive(false);
                live0.SetActive(false);
            break;
            case 1:
                live3.SetActive(false);
                live2.SetActive(false);
                live1.SetActive(true);
                live0.SetActive(false);
            break;
            case 0:
                live3.SetActive(false);
                live2.SetActive(false);
                live1.SetActive(false);
                live0.SetActive(true);
                StartCoroutine(RestartLevel());
            break;
        }
    }
    IEnumerator RestartLevel(){
        yield return new WaitForSeconds(1f);
        health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
