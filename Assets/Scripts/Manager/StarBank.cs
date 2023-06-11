using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBank : MonoBehaviour
{
    public int starBank;
    public static StarBank instance;
    public Text starText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StarAmountText();

    }

    // Update is called once per frame
    void Update()
    {
        StarAmountText();
    }
    public void Collect(int starCollected)
    {
        starBank += starCollected;
        StarAmountText();
        
    }
    void StarAmountText()
    {
        starText.text = "x " + starBank.ToString();
    }
}
