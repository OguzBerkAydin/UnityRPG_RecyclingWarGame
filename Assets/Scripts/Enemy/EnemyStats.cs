using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float timer;
    public float pushForceX, pushForceY;
    public float damage;
    public float givenExp;

    private float currentHealth;

    public GameObject deathEffect;
    public Transform Player;

    HitEffect hitEffect;
    Rigidbody2D rigidbody2D;

    public AudioSource hitAS, deadAS;

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

        AudioManager.instance.PlayAudio(hitAS);


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
            Experience.instance.ExpMod(givenExp);
            AudioManager.instance.PlayAudio(deadAS);

        }
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().material = hitEffect.original;

    }
}
