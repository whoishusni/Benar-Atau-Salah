using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingScript : MonoBehaviour
{
    public AudioMixer musicMixer;
    public Slider volumeSlider;
   
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(setVolume);
    }

    public void setVolume(float volume) {
        musicMixer.SetFloat("BgVolume", volume);
      
    }
   
}
