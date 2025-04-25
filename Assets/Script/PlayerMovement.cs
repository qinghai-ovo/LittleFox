using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private float velox;
    public float speed = 5f;
    public float jumpForce = 5f;

    private bool jumpPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        velox = speed * Input.GetAxisRaw("Horizontal");

        if (velox != 0 )
        {
            rb.velocity = new Vector3(velox, rb.velocity.y, 0f);
        }
        Jump();
    }

    void Jump()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;
        }
    }
}