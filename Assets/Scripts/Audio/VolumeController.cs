using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixerGroup Mixer;

    [SerializeField] private GameObject mainItems, settingsItems;

    //public static event Action<float> OnVolumeChanged;


    private void Start()
    {
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 1);
    }

    public void ChangeVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume",Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }


    //Кнопки переключения на микшер
    public void SettingsClick()
    {
        mainItems.SetActive(false);
        settingsItems.SetActive(true);
    }

    public void MainClick() {
        mainItems.SetActive(true);
        settingsItems.SetActive(false);
    }
}
