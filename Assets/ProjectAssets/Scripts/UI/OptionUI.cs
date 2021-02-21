using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionUI : MonoBehaviour
{
    public AudioMixer mxr;

    public TextMeshProUGUI masterVolume;
    public TextMeshProUGUI ambience;
    public TextMeshProUGUI soundFX;
    public TextMeshProUGUI bgMusic;


    public void MasterVolume(float getValue)
    {
        mxr.SetFloat("Master", getValue);
        masterVolume.SetText(getValue.ToString("F2"));
    }

    public void Ambience(float getValue)
    {
        mxr.SetFloat("Ambient", getValue);
        ambience.SetText(getValue.ToString("F2"));
    }

    public void SoundFX(float getValue)
    {
        mxr.SetFloat("SoundFX", getValue);
        soundFX.SetText(getValue.ToString("F2"));
    }

    public void BgMusic(float getValue)
    {
        mxr.SetFloat("BGMusic", getValue);
        bgMusic.SetText(getValue.ToString("F2"));
    }

}
