using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public float jumpSpeed;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    private bool isTouchingLeft;
    private bool isTouchingRight;
    private bool wallJumping;
    private float touchingLeftOrRight;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");


        if ((!isTouchingLeft && !isTouchingRight) || isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        new Vector2(0.9f, 0.2f), 0f, groundMask);

        isTouchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y),
        new Vector2(0.2f, 0.9f), 0f, groundMask);

        isTouchingRight = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y),
        new Vector2(0.2f, 0.9f), 0f, groundMask);

        if (isTouchingLeft)
        {
            touchingLeftOrRight = 1;
        }
        else if (isTouchingRight)
        {
            touchingLeftOrRight = -1;
        }

        if (Input.GetKeyDown("space") && (isTouchingRight || isTouchingLeft) && !isGrounded)
        {
            wallJumping = true;
            Invoke(nameof(SetJumpingToFalse), 0.08f);
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(walkSpeed * touchingLeftOrRight, jumpSpeed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));


        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));
    }

    void SetJumpingToFalse()
    {
        wallJumping = false;
    }



}