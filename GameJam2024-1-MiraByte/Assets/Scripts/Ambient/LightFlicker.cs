using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light2d;
    public float min;
    public float max;
    void Update()
    {
        light2d.intensity = Random.Range(min, max);
    }
}
