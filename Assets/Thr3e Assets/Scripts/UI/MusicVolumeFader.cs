using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolumeFader : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        masterMixer.SetFloat("sfxVolume", -20f);
        masterMixer.SetFloat("musicVolume", -30f);
        sfxSlider.value = -20f;
        musicSlider.value = -30f;
    }

    public void SetSfxLevel(float sfxLvl)
    {

        masterMixer.SetFloat("sfxVolume", sfxLvl);

    }

    public void SetMusicLevel(float musicLvl)
    {

        masterMixer.SetFloat("musicVolume", musicLvl);

    }
}
