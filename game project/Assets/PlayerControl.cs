using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public Transform ceilingCheck;
    public Transform groundcheck;

    private Rigidbody2D rb;
    private bool facingRight = true;
    public float moveDirection;
    private bool isJumping = false;

    //awake is called after all objects are intialized.called in random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //will look for component on game object
    }

    private void FixedUpdate()
    {
        ProcessInputs();
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    //better for handling physics can be called multiple times
    private void FixedUpdate()
    {

    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
