using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TriggerVignette : MonoBehaviour
{
    public float vignetteStrength;
    public VolumeProfile volume;

    Vignette vignette;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            volume.TryGet(out vignette);
            vignette.intensity.value = vignetteStrength;
        }
    }
}
