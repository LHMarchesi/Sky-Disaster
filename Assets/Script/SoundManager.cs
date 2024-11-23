using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider soundFXSlider;
    [SerializeField] private Slider musicSlider;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(optionsMenu);
        }
        else
        {
            Destroy(gameObject);
        }
        optionsMenu.SetActive(false);
    }

    private void Start()
    {
        LoadSavedVolumeSettings();
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
        PlayerPrefs.SetFloat("MasterVolume", level);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("SoundFXVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("MusicVolume", level);
    }

    private void LoadSavedVolumeSettings()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        float soundFXVolume = PlayerPrefs.GetFloat("SoundFXVolume", 0.75f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

        audioMixer.SetFloat("masterVolume", Mathf.Log10(masterVolume) * 20f);
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(soundFXVolume) * 20f);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20f);

        if (masterVolumeSlider != null)
        {
           masterVolumeSlider.value = masterVolume;
        }
        if (soundFXSlider != null)
        { 
            soundFXSlider.value = soundFXVolume;
        }
        if (musicSlider != null)
        {
            musicSlider.value = musicVolume;
        }
    }
}
