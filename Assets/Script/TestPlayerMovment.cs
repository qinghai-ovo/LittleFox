using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TestPlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;

    private float xVelocity;
    public float speed = 5f;
    public float jumpForce = 5f;

    private bool jumpPressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        MoveOnGround();
        ChangeGravitity();
    }

    private void ChangeGravitity()
    {
        if (jumpPressed)
        {
            rb.gravityScale *= -1;
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
            jumpPressed = false;
        }
    }

    private void MoveOnGround() 
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(xVelocity * speed, rb.velocity.y, 0f);
        FlipDirection();
    }

    private void FlipDirection()
    {
        if (xVelocity < 0) {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if (xVelocity > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
}
