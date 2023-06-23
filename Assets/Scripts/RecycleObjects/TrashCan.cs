using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    int totalObjects;
    private void Start()
    {
        totalObjects = 3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == this.tag)
        {
            Destroy(collision.gameObject);
            totalObjects--;
        }


    }
}
