using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{
    public float EffectTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,EffectTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
