using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] public GameObject resumeScreen;

    public void ResumeGame()
    {
        resumeScreen.SetActive(false);
        CharacterControl.resume = false;
        Time.timeScale = 1;
    }
}
