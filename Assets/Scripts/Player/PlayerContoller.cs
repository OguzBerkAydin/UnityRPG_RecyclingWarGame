using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerContoller : MonoBehaviour
{

    public static PlayerContoller instance;

    private float movementDirection; // ileri mi geri mi gideceðini belirten deðiþken +x ya da-x gibi.
    public float speed;
    public float jumpPower;
    public float groundCheckRadius;
    public float attackRate = 2f;
    public float damage;
    public float attackDistance;
    float nextAttack = 0;

    private bool isGrounded;
    private bool isFacingRight = true;

    public GameObject groundCheck;
    public LayerMask groundLayer;
    public GameObject ninjaStar;
    public LayerMask enemyLayers;

    public Transform attackPoint;
    public Transform firePoint;

    Rigidbody2D rb;
    Animator anim;
    WeaponStats WeaponStats;

    public AudioSource swordAs;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        WeaponStats = GetComponent<WeaponStats>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
        Jump();
        CheckSurface();
        CheckAnimations();

        if (Time.time > nextAttack)
        {
            AttackInput();
        }
        Shoot();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementDirection * speed, rb.velocity.y);
        anim.SetFloat("runSpeed", Math.Abs(movementDirection * speed));
    }
    void CheckRotation()
    {
        if (isFacingRight && movementDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementDirection > 0)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }

    }
    void CheckSurface()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
    void CheckAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    private void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
            nextAttack = Time.time + 1f / attackRate;
        }
    }
    public void Attack()
    {

        float num = UnityEngine.Random.Range(0, 2);
        if (num == 1)
        {
            anim.SetTrigger("attack1");
            AudioManager.instance.PlayAudio(swordAs);
        }
        else if (num == 0)
        {
            anim.SetTrigger("attack2");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(WeaponStats.DamageInput());
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (StarBank.instance.starBank > 0)
            {
                Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                StarBank.instance.starBank--;

                //PlayerPrefs.SetInt("StarAmount", StarBank.instance.starBank);
            }

        }
    }

}
