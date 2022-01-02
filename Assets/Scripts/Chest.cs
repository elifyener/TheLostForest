using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject carrot;
    [SerializeField] private AudioClip audioChest;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator anim;
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player") && !isOpen)
        {
            audioSource.PlayOneShot(audioChest, 0.5f);
            anim.SetBool("open", true);
            carrot.SetActive(true);
            isOpen = true;
        }
    }
}
