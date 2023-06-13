using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectMixer;
    public AudioSource backgroundMusicAS;

    public static AudioManager instance;
    public Slider masterSldr, effectSldr;

    [Range(-80, 20)]
    public float effectVol, masterVol;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        masterSldr.minValue = -80;
        masterSldr.maxValue = 20;

        effectSldr.minValue = -80;
        effectSldr.maxValue = 20;

        masterSldr.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        effectSldr.value = PlayerPrefs.GetFloat("FXVolume", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //MasterVolume();
        //EffectVolume();
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
    public void MasterVolume()
    {
        DataManager.instance.SetMusicData(masterSldr.value);
        musicMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }
    public void EffectVolume()
    {
        DataManager.instance.FXData(effectSldr.value);
        effectMixer.SetFloat("effectVolume", PlayerPrefs.GetFloat("FXVolume"));

    }
}
