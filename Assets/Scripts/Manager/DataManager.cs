using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetMusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void FXData(float value)
    {
        PlayerPrefs.SetFloat("FXVolume", value);
    }
}
