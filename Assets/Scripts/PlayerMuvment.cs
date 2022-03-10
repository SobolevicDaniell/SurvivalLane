using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuvment : MonoBehaviour
{

    public float speed = 8f;
    public float jumpForce = 300f;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faseRight = true;
    public bool onGround;
    public bool onWall;
    public Transform GroundCheck;
    public Transform WallCheck;
    public float checkRadius = 0.2f;
    public LayerMask Ground, Cube;
    public int maxJmpValue = 1;


    private Vector2 moveVector;
    private Rigidbody2D rb;
    private int jumpCount = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Jump();
        ChakingGround();
        Reflect();
        WallChecker();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faseRight) || (moveVector.x < 0 && faseRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faseRight = !faseRight;
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || (++jumpCount < maxJmpValue)))
        {
            rb.AddForce(Vector2.up * jumpForce);
        } 
        if (onGround) { jumpCount = 0; }
    }


    void ChakingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground) || Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Cube);
        anim.SetBool("onGround", onGround);
    }
    void WallChecker()
    {
        onWall = Physics2D.OverlapCircle(WallCheck.position, checkRadius, Ground);
        anim.SetBool("onWall", onWall);
    }

    
}
