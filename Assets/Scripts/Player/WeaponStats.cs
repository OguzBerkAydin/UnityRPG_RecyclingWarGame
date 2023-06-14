using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    float attackPower;
    float totalAttack;
    public float weaponAttack;

    public GameObject damageText;

    void Start()
    {

    }


    void Update()
    {

    }
    public float DamageInput()
    {
        totalAttack = attackPower + weaponAttack;
        float finalAttack = Mathf.Round(Random.Range(totalAttack - 7, totalAttack + 5));
        GameObject textDam = Instantiate(damageText, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
        textDam.GetComponent<TextMeshPro>().SetText(finalAttack.ToString());
        if (finalAttack > totalAttack - 4)
        {
            textDam.GetComponent<TextMeshPro>().SetText("CRITICAL!\n" + finalAttack.ToString());
            finalAttack *= 2;
        }
        return finalAttack;
    }
}
