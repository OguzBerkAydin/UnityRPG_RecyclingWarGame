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

        currentExperience = PlayerPrefs.GetFloat("Experience", 0);
        expToNextLevel = PlayerPrefs.GetFloat("ExperienceTNL", expToNextLevel);
        currLvl = PlayerPrefs.GetInt("CurrentLevel", 1);

    }

    // Update is called once per frame
    void Update()
    {
        expImg.fillAmount = currentExperience / expToNextLevel;
        lvlText.text = currLvl.ToString();

    }
    public void ExpMod(float exp)
    {
       
        currentExperience += exp;

        expToNextLevel = PlayerPrefs.GetFloat("ExperienceTNL", expToNextLevel);

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

            //currLvl = PlayerPrefs.GetInt("CurrentLevel", currLvl);

        }
        

    }
    public void DataSave()
    {
        try
        {
            DataManager.instance.ExperienceData(currentExperience);
            DataManager.instance.ExperienceToNextLevel(expToNextLevel);
            DataManager.instance.LevelData(currLvl);

            DataManager.instance.CurrentHealth(PlayerHealth.instance.currentHealth);
            PlayerHealth.instance.currentHealth = PlayerPrefs.GetFloat("CurrentHealth");

            DataManager.instance.MaxHealth(PlayerHealth.instance.maxHealth);
            PlayerHealth.instance.maxHealth = PlayerPrefs.GetFloat("MaxHealth");

            currentExperience = PlayerPrefs.GetFloat("Experience");
            expToNextLevel = PlayerPrefs.GetFloat("ExperienceTNL");
            currLvl = PlayerPrefs.GetInt("CurrentLevel");

            DataManager.instance.CurrentStars(StarBank.instance.starBank);
            StarBank.instance.starBank = PlayerPrefs.GetInt("StarAmount");
        }
        catch
        {

            
        }
        
    }
}
