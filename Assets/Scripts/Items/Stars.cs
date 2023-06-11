using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int starAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarBank.instance.Collect(starAmount);
        Destroy(gameObject);
        
    }
}
