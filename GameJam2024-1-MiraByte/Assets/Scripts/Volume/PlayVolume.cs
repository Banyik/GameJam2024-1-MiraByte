using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public GameObject soundWave;
    public Slider slider;

    public void Start()
    {
        if (!Volumevalue.isCalled)
        {
            Volumevalue.isCalled = true;
        }
        else
        {
            slider.value = Volumevalue.volume;
        }
        
    }

    public void SetVolume(float sliderValue) 
    {
        Volumevalue.volume = sliderValue;
        audioMixer.SetFloat("mastervol",Mathf.Log10(sliderValue) * 20);
        if (sliderValue > 0.001)
        {
            soundWave.SetActive(true);
        }
        else 
        {
            soundWave.SetActive(false);
        }
    }
}
