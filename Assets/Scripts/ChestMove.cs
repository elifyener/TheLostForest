using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMove : MonoBehaviour
{
    private Animator anim;
    private float horizontalInput;
    public float speed;
    private float spawnPosX=6;
    [SerializeField] GameObject carrot;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        InvokeRepeating("SpawnRandomCarrot", 2, 1.5f);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if ( horizontalInput != 0)
        {
            if (transform.position.x < -7)
            {
                transform.position = new Vector2(-7, transform.position.y);
            }
            else if (transform.position.x > 7)
            {
                transform.position = new Vector2(7, transform.position.y);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }

        }
    }
    private void SpawnRandomCarrot()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosX, spawnPosX), 6);
        Instantiate(carrot, spawnPos, carrot.transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("ChestEat",true);
        audioSource.Play();
        Destroy(other.gameObject);
        Invoke("ChestClose",0.5f);
    }
    private void ChestClose()
    {
        anim.SetBool("ChestEat",false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
