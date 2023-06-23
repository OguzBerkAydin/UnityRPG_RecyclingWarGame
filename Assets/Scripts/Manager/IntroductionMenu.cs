using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionMenu : MonoBehaviour
{
    List<string> Introductions = new List<string>() { "Welcome to the exciting world of Kirliþ! Here's a step-by-step guide on how to play the game.", "Use the W, A, S, and D keys to move your character in different directions.", "Press the Space bar to make your character jump over obstacles or reach higher platforms.", "Hold the Ctrl key to swing your sword and attack enemies in close combat.", "Press the Shift key to throw ninja stars, which can hit enemies from a distance." };
    public GameObject intorductionMenu;
    public Text msg;
    string crrMsg;
    int msgIndex;
    private void Awake()
    {
        
    }
    void Start()
    {
        intorductionMenu.SetActive(true);
        msgIndex = 0;
        crrMsg = Introductions[msgIndex];
        msg.text = crrMsg;
        Time.timeScale = 0;
    }


    void Update()
    {
        //Next();
    }

    public void Next()
    {
        try
        {
            msgIndex++;
            crrMsg = Introductions[msgIndex];
            msg.text = crrMsg;
        }
        catch 
        {
            intorductionMenu.SetActive(false);
            Time.timeScale = 1;

        }

    }
}
