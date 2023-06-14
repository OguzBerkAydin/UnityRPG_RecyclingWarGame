using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingRoom : MonoBehaviour
{
    public GameObject saveText;
    public GameObject[] effects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Experience.instance.DataSave();

            for (int i = 0; i < 6; i++)
            {
                effects[i].SetActive(true);
            }
            saveText.SetActive(true);
            StartCoroutine(CloseText());
        }
    }
    IEnumerator CloseText()
    {
        yield return new WaitForSeconds(2);
        saveText.SetActive(false);
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
