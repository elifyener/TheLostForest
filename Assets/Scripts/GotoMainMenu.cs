using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMainMenu : MonoBehaviour
{
    public void GoMainMenu()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(1.5f);
        Score.carrot = 0;
        HealthSystem.health = 3;
        SceneManager.LoadScene(0);
    }
}
