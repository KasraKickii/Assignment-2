using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool canJump = true;
    float horizontalMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("isJumping", true);
            canJump = false;
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
            animator.SetBool("isRunning", false);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            // Application.LoadLevel(Application.loadedLevel);
        }
        if (collision.gameObject.tag == "Platform")
        {
            animator.SetBool("isJumping", false);
            canJump = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
}
