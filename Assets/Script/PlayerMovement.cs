using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public ShardManager sm;
    public Vector2 boxSize = new Vector2(0.5f, 0.1f);
    public float castDistance = 0.1f;
    public LayerMask groundLayer;

    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;
    private bool hasJumped = false;

    public MPUReader mpu; // assign via inspector

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip sprite based on movement
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        // Reset hasJumped if grounded and pitch netral
        if (isGrounded() && Mathf.Abs(mpu.pitch) < 15f)
        {
            hasJumped = false;
        }

        // Jump detection based on MPU pitch
        if (mpu.pitch > 30f && isGrounded() && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }

        // Set animations
        anim.SetBool("isRunning", moveInput != 0);
        anim.SetBool("isJumping", !isGrounded());
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // reset y-velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool isGrounded()
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
