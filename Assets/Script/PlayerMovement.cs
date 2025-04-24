using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public ShardManager sm;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool doubleJumpAvailable;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1) Horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 2) Reset double jump when grounded
        if (isGrounded())
        {
            doubleJumpAvailable = true;
        }

        // 3) Jump logic
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                // First jump
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (doubleJumpAvailable)
            {
                // Double jump
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJumpAvailable = false;
            }
        }

        // 4) Flip sprite
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
        if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        anim.SetBool("isJumping", !isGrounded());
    }

    // Ground check via BoxCast
    private bool isGrounded()
    {
        return Physics2D.BoxCast(
            transform.position,
            boxSize,
            0f,
            Vector2.down,
            castDistance,
            groundLayer
        );
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(
            transform.position + Vector3.down * castDistance,
            boxSize
        );
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shard"))
        {
            Destroy(other.gameObject);
            sm.shardCount++;
        }
    }
}
