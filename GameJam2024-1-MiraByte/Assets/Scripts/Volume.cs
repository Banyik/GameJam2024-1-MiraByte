using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public GameObject soundWave;

    public void SetVolume(float sliderValue) 
    {
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
