using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public float speed = 3f;
    public int lives = 5;
    public float jumpForce = 0.5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Animator anim;
    private bool isGrounded = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();


        anim = GetComponent<Animator>();
    }
    private void Run()
    {

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void checkGround()
    { 
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1; 
    }

    private void FixedUpdate()
    {
        checkGround();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal")) 
        {
            Run();
        }

        if (isGrounded && Input.GetButton("Jump")) 
        {
            Jump();
        }
    }
          
}

    




