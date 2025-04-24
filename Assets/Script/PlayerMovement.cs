using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;

    public float jump;
    public bool isJumping;
    public ShardManager sm;
    public Vector2 ballSize;
    public float castDistance;
    public LayerMask groundLayer;

    bool facingRight = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if(Input.GetButtonDown("Jump")&& isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if (Move > 0 && !facingRight)
        {
            Flip();
        }
        if (Move < 0 && facingRight)
        {
            Flip();
        }
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, ballSize,0,-transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, ballSize);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        facingRight = !facingRight;
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        Vector3 normal = other.GetContact(0).normal;
    //        if (normal == Vector3.up)
    //        {
    //            isJumping = false;
    //        }

    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isJumping = true;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shard"))
        {
            Destroy(other.gameObject);
            sm.shardCount++;
        }
    }
}
