using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Experience : MonoBehaviour
{
    public static Experience instance;

    public Image expImg;
    public Text lvlText;
    public int currLvl;

    public float currentExperience;
    public float expToNextLevel;

    public AudioSource levelUpAS;

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
        expImg.fillAmount = currentExperience / expToNextLevel;
        currLvl = 1;
        lvlText.text = currLvl.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        expImg.fillAmount = currentExperience / expToNextLevel;

    }
    public void ExpMod(float exp)
    {
        currentExperience += exp;
        expImg.fillAmount = currentExperience / expToNextLevel;

        if (currentExperience >= expToNextLevel)
        {
            expToNextLevel *= 2;
            currentExperience = 0;
            currLvl++;
            lvlText.text = currLvl.ToString();
            PlayerHealth.instance.maxHealth += 5;
            PlayerHealth.instance.currentHealth += 5;
            AudioManager.instance.PlayAudio(levelUpAS);
        }

    }
}
