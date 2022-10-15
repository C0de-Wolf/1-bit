﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    public int JumpCountController;
    private int extraJumps;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        extraJumps = JumpCountController;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatisGround );
        moveInput = Input.GetAxis("Horizontal");
        if(moveInput == 0)
        {
            anim.SetBool("isRunningR", false);
        }
        else
        {
            anim.SetBool("isRunningR", true);
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput<0)
        {
            Flip();
        }

    }
    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = JumpCountController;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            anim.SetTrigger("Jump");
            rb.velocity = Vector2.up*jumpForce;
            extraJumps--;
        }else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}