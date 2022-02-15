using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        StartCoroutine(ExitDelay());
        Application.Quit();
    }

    IEnumerator ExitDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
