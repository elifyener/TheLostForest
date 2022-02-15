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
        Score.score = 0;
        Enemy.killcounter = 0;
        Death.deathcounter = 0;
        SceneManager.LoadScene(0);
    }
}
