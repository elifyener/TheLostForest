using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    
    private bool grounded = true;
    private bool jump;
    private bool fly;
    public static bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator anim; 
    private SpriteRenderer _spriteRenderer;
    private float moveDirection;

    private float vertical;
    [SerializeField] public GameObject resumeScreen;
    public static bool resume = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        moving = true;
    }
    private void FixedUpdate() 
    {

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
            fly = true;
        }
        if (Enemy.isEnemyDeath)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            Enemy.isEnemyDeath = false;
        }
        if (Climb.isClimbing)
        {
            _rigidbody2D.gravityScale = 0f;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Input.GetAxis("Vertical") * 1.5f * speed);
        }
        else
        {
            _rigidbody2D.gravityScale = 0.9f;
        }
        if (Death.isDeath)
        {
            _rigidbody2D.velocity = new Vector3(0, jumpForce/3, 0);
            _rigidbody2D.isKinematic = false;
            moving = false;
        }
        else
        {
            CharacterControl.moving = true;
        }
        
        
    }
    private void Update() 
    {
        if(moving && !resume){
            if (grounded && (Input.GetAxis("Horizontal") != 0))
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
            else if (grounded)
            {
                moveDirection = 0.0f;
                anim.SetFloat("speed", 0.0f);
            }
            if (fly)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        moveDirection = -1.0f;
                        _spriteRenderer.flipX = true;
                    }
                    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        moveDirection = 1.0f;
                        _spriteRenderer.flipX = false;
                    }

                }
            }

            if (grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
            {
                if (Climb.isLadder)
                {
                    Climb.isClimbing = true;
                    anim.SetTrigger("climb");
                }
                else
                {
                    jump = true;
                    anim.SetTrigger("jump");
                }
                grounded = false;
                anim.SetBool("grounded", false);
            }
            if (Climb.isLadder && !grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
            {
                grounded = true;
                anim.SetBool("grounded", true);
                Climb.isClimbing = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!resume)
            {
                resume = true;
                Time.timeScale = 0;
                resumeScreen.SetActive(true);
            }
            else
            {
                resume = false;
                Time.timeScale = 1;
                resumeScreen.SetActive(false);
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            fly = false;
            anim.SetBool("grounded", true);
        }
    }
    
}
