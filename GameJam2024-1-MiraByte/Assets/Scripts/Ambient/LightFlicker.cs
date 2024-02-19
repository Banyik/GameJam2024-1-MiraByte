using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light;
    public float min;
    public float max;
    void Update()
    {
        light.intensity = Random.Range(min, max);
    }
}
