using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public float timer;
    public float pushForceX, pushForceY;
    public float damage;

    public GameObject deathEffect;
    public Transform Player;

    HitEffect hitEffect;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hitEffect = GetComponent<HitEffect>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;


        if (Player.position.x < transform.position.x)
        {
            rigidbody2D.AddForce(new Vector2(pushForceX, pushForceY), ForceMode2D.Force);

        }
        else
        {
            rigidbody2D.AddForce(new Vector2(-pushForceX, pushForceY), ForceMode2D.Force);

        }
        GetComponent<SpriteRenderer>().material = hitEffect.white;
        StartCoroutine(BackToNormal());
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().material = hitEffect.original;

    }
}
