using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Windows;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] private AudioMixer audioMixer;
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        optionsMenu.SetActive(false);
    }

    public void ToggleSoundMenuGame(bool input)
    {
        GameManager.instance.inOption = input;
        optionsMenu.SetActive(input);
    }

    public void ToggleSoundMenuMenu(bool input)
    {
        optionsMenu.SetActive(input);
    }

    public void SetMasterFXVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
}
