using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        ProcessInputs();

        //Animate
        Animate();


    }

    //Better for handling physics, can be called multiple times per update frame
    private void FixedUpdate()
    {
        //check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);

        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        //move
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection) * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector22(0f, jumpforce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection
    }