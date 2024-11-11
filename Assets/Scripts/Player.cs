using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float speed;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 10f;

    bool sprinting;

    Vector2 initialLocalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        initialLocalScale = transform.localScale;
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift);
        speed = sprinting ? runSpeed : walkSpeed;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (HasHorizontalSpeed())
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void FlipSprite()
    {
        if (HasHorizontalSpeed())
        {
            transform.localScale = new Vector2(initialLocalScale.x * Mathf.Sign(rb.velocity.x), initialLocalScale.y);
        }
    }

    bool HasHorizontalSpeed()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    }
}
