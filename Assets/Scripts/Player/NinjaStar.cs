using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NinjaStar : MonoBehaviour
{

    public float speed;
    public float damage;
    Rigidbody2D rb;

    public GameObject damageText;
    public PlayerContoller player;
    public GameObject groundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerContoller>();
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            damage = Mathf.Round(Random.Range(damage - 5, damage + 5));
            GameObject textDam = Instantiate(damageText, new Vector2(collision.transform.position.x,collision.transform.position.y + 0.6f), Quaternion.identity);
            textDam.GetComponent<TextMeshPro>().SetText(damage.ToString());

            collision.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Instantiate(groundEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
