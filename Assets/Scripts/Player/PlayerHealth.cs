using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    public float maxHealth;
    public float currentHealth;
    public float immunityTime;

    bool isImmune;

    public Image healthBar;
    public GameObject deathMenu;

    Animator anim;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        maxHealth = PlayerPrefs.GetFloat("MaxHealth", maxHealth);
        currentHealth = PlayerPrefs.GetFloat("CurrentHealth", currentHealth);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            currentHealth -= collision.GetComponent<EnemyStats>().damage;
            StartCoroutine(Immunity());
            anim.SetTrigger("Hit");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
                deathMenu.SetActive(true);
            }
        }
    }
    IEnumerator Immunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityTime);
        isImmune = false;
    }
}
