using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        currentpoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (currentpoint.position - transform.position).normalized; // Get direction
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); // Move in the right direction

        // Switch target point when close enough
        if (Vector2.Distance(transform.position, currentpoint.position) < 1.5f)
        {
            flip(); // Flip direction
            currentpoint = (currentpoint == pointB.transform) ? pointA.transform : pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the x-scale
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
