using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    
    private bool grounded = true;
    private bool jump;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator anim; 
    private SpriteRenderer _spriteRenderer;
    private float moveDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() 
    {
        if (_rigidbody2D.velocity!=Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            
            jump = false; 
        }
    }
    private void Update() 
    {
        if (grounded == true && (Input.GetAxis("Horizontal") != 0))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }

        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("grounded", true);
        }
    }
    
}
