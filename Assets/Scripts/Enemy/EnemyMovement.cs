using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;
    public bool isWalkingToRight;
    public bool isPatroller;

    public Transform wallCheck, groundCheck, gapCheck;
    public bool wallDetected, groundDetected, gapDetected;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    public bool moveToA, moveToB;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveToA = true;
    }
    void Update()
    {
        gapDetected = !Physics2D.OverlapCircle(gapCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        groundDetected = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

        if (gapDetected || wallDetected && groundDetected)
        {
            Flip();
        }
    }

   

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!isWalkingToRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);

            }
        }
        if (isPatroller)
        {
            anim.SetBool("Idle", false);
            if (moveToA)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                if (Vector2.Distance(transform.position,pointA.position) < 0.2f)
                {
                    Flip();
                    moveToA = false;
                    moveToB = true;
                }
            }
            if (moveToB)
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    Flip();
                    moveToA = true;
                    moveToB = false;
                }
            }
        }
    }
    private void Flip()
    {
        isWalkingToRight = !isWalkingToRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
