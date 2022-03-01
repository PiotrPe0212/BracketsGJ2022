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
    //private Animator Animator;
    public LayerMask groundMask;
    private bool isTouchingLeft;
    private bool isTouchingRight;
    private bool normalJump;
    private bool wallJumping;
    private float touchingLeftOrRight;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer FlashLight;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource jumpSound;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = false;
        
    }
    private void Update()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
            walkSound.Stop();
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            animator.SetTrigger("IsJumping");
            }
      
        if (Input.GetKeyDown("space") && (isTouchingRight || isTouchingLeft) && !isGrounded)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(walkSpeed * touchingLeftOrRight * Time.fixedDeltaTime, jumpSpeed); ;
            Invoke(nameof(SetJumpingToFalse), 0.08f);
        }

        
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2.5f), new Vector2(0.9f, 0.2f));


        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y), new Vector2(0.2f, 0.9f));
    }


    private void FixedUpdate()
     {
        wallsChecking();
        horivontalMove();
      
     }
    void SetJumpingToFalse()
    {
        wallJumping = false;
    }

    private void horivontalMove()
    {

        if (moveInput != 0)
        {
            animator.SetBool("IsWalking", true);
            if(!walkSound.isPlaying) walkSound.Play();
            print("dzia³");

            if (moveInput == -1)
            {
                spriteRenderer.flipX = true;
                FlashLight.flipX = true;

            }
            else
            {
                spriteRenderer.flipX = false;
                FlashLight.flipX = false;
            }

        }
        else
        {
            animator.SetBool("IsWalking", false);
            walkSound.Stop();

        }

        if ((!isTouchingLeft && !isTouchingRight) || isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed * Time.deltaTime, rb.velocity.y);
            
            
        }
       


    }

    private void wallsChecking()
    {
        isGrounded = (Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2.5f),
       new Vector2(0.9f, 0.2f), 0f, groundMask));
        animator.SetBool("TouchingGround", isGrounded);

        isTouchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y),
        new Vector2(0.2f, 0.9f), 0f, groundMask);

        isTouchingRight = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y),
        new Vector2(0.2f, 0.9f), 0f, groundMask);

        if (isTouchingLeft)
        {
            touchingLeftOrRight = 1;
        }
        else if (isTouchingRight)
        {
            touchingLeftOrRight = -1;
        }
    }

    // void AnimatorFunction()
    // {
    //     if(moveInput == 0)
    //     {
    //         Animator.SetBool("IsWaiting", true);
    //         Animator.SetBool("IsWalking", false);
    //     }
    //     else
    //     {
    //         Animator.SetBool("IsWaiting", false);
    //         Animator.SetBool("IsWalking", true);
    //     }

    //     if (Input.GetKeyDown("space") && isGrounded) Animator.SetBool("IsJumping", true);

    // }


}