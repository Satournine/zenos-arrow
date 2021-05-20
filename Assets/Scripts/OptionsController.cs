using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; //For audio

//This script controls the options menu
public class OptionsController : MonoBehaviour
{
    public AudioMixer audioMixerMusic; //For audio

    public static bool paused = false;
    public GameObject parentMenu;
    public GameObject optionsMenu;

    public Slider musicSlider;
    public Slider SfxSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        SfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }

    void Update()
    {

    }

    //Music adjustment
    public void SetMusic(float music)
    {
        audioMixerMusic.SetFloat("Music", music);
        PlayerPrefs.SetFloat("music", music);
    }

    //SFX adjustment
    public void SetSFX(float sfx)
    {
        audioMixerMusic.SetFloat("SFX", sfx);
        PlayerPrefs.SetFloat("sfx", sfx);
    }

    //To go back to the previous menu (main or pause)
    public void Back()
    {
        PlayerPrefs.Save();

        parentMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
